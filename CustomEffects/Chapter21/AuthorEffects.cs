using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class AuthorHandler
    {
        public static Dictionary<int, List<IStatusEffect>> StatusEffects;
        public static string Turns => "Author_Turns";
        public static string Spotlight => "NewsReel_A";
        public static string Cataclysm => "MiniCataclysm_A";
        public static string Suicide => "InsideOut_A";
        public static void Reset() => StatusEffects = new Dictionary<int, List<IStatusEffect>>();
        public static void CheckToReset(string notif, object sender, object args)
        {
            if (notif == TriggerCalls.OnBeforeCombatStart.ToString()) Reset();
        }
        public static void Setup() => NotificationHook.AddAction(CheckToReset);
    }
    public class SpawnMonsterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int num = 20;
            num += caster.SimpleGetStoredValue(AuthorHandler.Turns) * 10;
            EnemySO en = LoadedAssetsHandler.GetEnemy("Monster_EN");
            List<IStatusEffect> status = [];
            if (AuthorHandler.StatusEffects != null && AuthorHandler.StatusEffects.TryGetValue(caster.ID, out List<IStatusEffect> effects)) status = effects; 
            CombatManager.Instance.AddSubAction(new SpawnMonsterAction(en, caster.SlotID, num, status));
            return true;
        }
        public class SpawnMonsterAction : CombatAction
        {
            public EnemySO en;
            public int final;
            public List<IStatusEffect> status;
            public int slot;
            public SpawnMonsterAction(EnemySO en, int slot, int final, List<IStatusEffect> status)
            {
                this.en = en;
                this.slot = slot;
                this.final = final;
                this.status = status;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                int num = stats.combatSlots.GetEnemyFitSlot(slot, en.size);
                if (num == -1)
                {
                    num = stats.GetRandomEnemySlot(en.size);
                }
                if (num != -1)
                {
                    if (stats.AddNewEnemy(en, num, false, "Basic", final))
                    {
                        EnemyCombat newborn = stats.Enemies[stats.Enemies.Count - 1];
                        if (newborn is IUnit unit)
                        {
                            foreach (IStatusEffect effect in status)
                            {
                                try
                                {
                                    if (effect is StatusEffect_Holder holder)
                                    {
                                        CombatManager.Instance.AddSubAction(new ApplyStatusAction(holder._Status, holder.m_ContentMain, unit));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.LogError("spawnmonster fail");
                                }
                            }
                        }
                    }
                }
                yield return null;
            }
        }
        public class ApplyStatusAction : CombatAction
        {
            public StatusEffect_SO status;
            public int amount;
            public IUnit unit;
            public ApplyStatusAction(StatusEffect_SO status, int amount, IUnit unit)
            {
                this.status = status;
                this.amount = amount;
                this.unit = unit;
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                unit.ApplyStatusEffect(status, amount);
                yield return null;
            }
        }
    }
    public class AuthorPassive : PerformEffectPassiveAbility
    {
        public override void TriggerPassive(object sender, object args)
        {
            if (!(args is DeathReference) && sender is IUnit unit)
            {
                unit.SimpleSetStoredValue(AuthorHandler.Turns, unit.SimpleGetStoredValue(AuthorHandler.Turns) + 1);
                unit.SimpleSetStoredValue(AuthorHandler.Spotlight, 0);
                unit.SimpleSetStoredValue(AuthorHandler.Cataclysm, 0);
                return;
            }
            base.TriggerPassive(sender, args);
        }
        public void SetStatusList(object sender, object args)
        {
            if (sender is IStatusEffector effector)
            {
                if (AuthorHandler.StatusEffects == null) AuthorHandler.Reset();
                AuthorHandler.StatusEffects.Add(effector.StatusEffectorID, new List<IStatusEffect>(effector.StatusEffects));
            }
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            base.OnPassiveConnected(unit);
            CombatManager.Instance.AddObserver(SetStatusList, TriggerCalls.CanDie.ToString(), unit);
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance.RemoveObserver(SetStatusList, TriggerCalls.CanDie.ToString(), unit);
            base.OnPassiveDisconnected(unit);
        }
    }
    public class AbilitySelector_Author : BaseAbilitySelectorSO
    {
        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int num = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < abilities.Count; i++)
            {
                if (!ShouldBeIgnored(abilities[i], unit))
                {
                    num += abilities[i].rarity.rarityValue;
                    list.Add(i);
                }
            }

            if (list.Count <= 0)
            {
                return -1;
            }

            int num2 = UnityEngine.Random.Range(0, num);
            num = 0;
            foreach (int item in list)
            {
                num += abilities[item].rarity.rarityValue;
                if (num2 < num)
                {
                    AfterSelectionAction(abilities[item]);
                    return item;
                }
            }

            return -1;
        }

        public void AfterSelectionAction(CombatAbility ability)
        {
            if (ability.ability.name == AuthorHandler.Spotlight)
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    enemy.SimpleSetStoredValue(AuthorHandler.Spotlight, 1);
                }
            }
            if (ability.ability.name == AuthorHandler.Cataclysm)
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    enemy.SimpleSetStoredValue(AuthorHandler.Cataclysm, 1);
                }
            }
        }
        public bool ShouldBeIgnored(CombatAbility ability, IUnit caster)
        {
            if (ability.ability.name == AuthorHandler.Spotlight && caster.SimpleGetStoredValue(AuthorHandler.Spotlight) > 0) return true;

            if (ability.ability.name == AuthorHandler.Cataclysm && caster.SimpleGetStoredValue(AuthorHandler.Cataclysm) > 0) return true;

            if (ability.ability.name == AuthorHandler.Cataclysm && CombatManager.Instance._stats.TurnsPassed < 1) return true;

            return false;
        }
    }
    public class InsideOutCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.SimpleGetStoredValue(AuthorHandler.Suicide) <= 0;
        }
    }
    public class ProphecyEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Prophecy", ResourceLoader.LoadSprite("ProphecyPassive.png")));
            exitAmount = 0;
            return true;
        }
    }

    public class MonsterSongEffect : EffectSO
    {
        public static int Amount = 0;
        public static void Reset() => Amount = 0;
        public bool Add = true;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool GOING = Amount > 0;
            if (Add) Amount++;
            else Amount--;
            if ((Amount > 0) == GOING) return Amount > 0;
            if (Amount > 0)
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("author thread failed to shut down."); }
                }
                changeMusic = new System.Threading.Thread(GO);
                changeMusic.Start();
            }
            else
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("author thread failed to shut down."); }
                }
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Monster", 0);
            }
            return Amount > 0;
        }

        public static System.Threading.Thread changeMusic;
        public static void GO()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("Monster", out float num) == FMOD.RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 100 && Amount > 0; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Monster", i);
                System.Threading.Thread.Sleep(20);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
    }
}
