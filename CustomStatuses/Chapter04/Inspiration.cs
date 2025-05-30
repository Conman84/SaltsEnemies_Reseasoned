using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Inspiration
    {
        public static string StatusID => "Inspiration_ID";
        public static string Intent => "Status_Inspiration";
        public static InspirationSE_SO Object;
        public static string Multiattack => "Inspiration_Multiattack_SO";
        public static string Prevent => "Inspiration_SO";
        public static string Passive => "Inspiration_PA";
        public static BasePassiveAbilitySO Inspired;

        public static void Add()
        {
            StatusEffectInfoSO InspireInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            InspireInfo.icon = ResourceLoader.LoadSprite("InspirationIcon");
            InspireInfo._statusName = "Inspiration";
            InspireInfo._description = "On taking damage, transfer Inspiration to the attacker and give them another action.\nOn dealing damage, transfer Inspiration to the target and give them another action.";//note: i changed it. cuz the old way it decreased sucked
            InspireInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo._applied_SE_Event;
            InspireInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            InspireInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            InspirationSE_SO InspireSO = ScriptableObject.CreateInstance<InspirationSE_SO>();
            InspireSO._StatusID = StatusID;
            InspireSO._EffectInfo = InspireInfo;
            Object = InspireSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = InspireSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(InspireSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("InspirationIcon");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);

            UnitStoreData_ModIntSO multiattack_value = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            multiattack_value.m_Text = "Extra Actions +{0}";
            multiattack_value._UnitStoreDataID = Multiattack;
            multiattack_value.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.PunchA.ToString()) as UnitStoreData_IntSO).m_TextColor;
            multiattack_value.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Multiattack))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Multiattack] = multiattack_value;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(multiattack_value._UnitStoreDataID, multiattack_value);

            PerformEffectPassiveAbility inspired = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            inspired._passiveName = "Inspired";
            inspired.m_PassiveID = Passive;
            inspired.passiveIcon = ResourceLoader.LoadSprite("InspirationIcon");
            inspired._enemyDescription = "This enemy is Inspired.";
            inspired._characterDescription = "This party member is Inspired.";
            inspired.doesPassiveTriggerInformationPanel = false;
            inspired._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
            inspired.effects = new EffectInfo[0];
            Inspired = inspired;
           
            NotificationHook.AddAction(NotifCheck);

            InspirationHandler.Setup();
        }

        public static void NotifCheck(string notifname, object sender, object args)
        {
            if (notifname != TriggerCalls.OnAbilityUsed.ToString()) return;
            if (sender is IUnit unit && unit.IsUnitCharacter && unit.SimpleGetStoredValue(Inspiration.Multiattack) > 0)
            {
                if (unit.RefreshAbilityUse())
                {
                    unit.SimpleSetStoredValue(Inspiration.Multiattack, unit.SimpleGetStoredValue(Inspiration.Multiattack) - 1);
                }
            }
        }
    }

    public class InspirationSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            //CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
            if (caller is IUnit unit)
            {
                if (unit.SimpleGetStoredValue(Inspiration.Prevent) > 0)
                {
                    unit.SimpleSetStoredValue(Inspiration.Prevent, 0);
                    return;
                }
                if (unit.IsUnitCharacter) CombatManager.Instance.AddRootAction(new PartyMemberInspirationApplicationAction(unit));
                else CombatManager.Instance._stats.timeline.TryAddNewExtraEnemyTurns(unit as EnemyCombat, 1);
            }
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            //CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
        }
        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit && unit.IsUnitCharacter && unit.SimpleGetStoredValue(Inspiration.Multiattack) > 0)
            {
                if (unit.RefreshAbilityUse())
                {
                    unit.SimpleSetStoredValue(Inspiration.Multiattack, unit.SimpleGetStoredValue(Inspiration.Multiattack) - 1);
                }
            }
        }
        public override bool TryUseNumberOnPopUp => false;
        public override int MinimumRequiredToApply => 0;
        public override StatusEffect_Holder GenerateHolder(int content, int restrictor)
        {
            return new StatusEffect_Holder(this);
        }
        public override int GetStatusContent(StatusEffect_Holder holder)
        {
            return 1;
        }
        public override bool CanBeRemoved(StatusEffect_Holder holder)
        {
            return true;
        }
        public override string DisplayText(StatusEffect_Holder holder)
        {
            string text = "";
            if (holder.Restrictor > 0)
            {
                text = text + "(" + holder.Restrictor + ")";
            }

            return text;
        }
        public override bool TryAddContent(StatusEffect_Holder holder, int content, int restrictor)
        {
            return false;
        }
        public override bool TryIncreaseContent(StatusEffect_Holder holder, int amount)
        {
            return false;
        }
        public override int JustRemoveAllContent(StatusEffect_Holder holder)
        {
            return 0;
        }
    }

    public class RemoveInspirationAction : CombatAction
    {
        public static List<int> Charas;
        public static List<int> Enemies;
        public int ID;
        public bool IsChara;
        public bool Skip;

        public RemoveInspirationAction(int id, bool ischara)
        {
            ID = id;
            IsChara = ischara;
            if (IsChara)
            {
                if (Charas == null) Charas = new List<int>();
                if (Charas.Contains(ID)) Skip = true;
                else Charas.Add(ID);
            }
            else
            {
                if (Enemies == null) Enemies = new List<int>();
                if (Enemies.Contains(ID)) Skip = true;
                else Enemies.Add(ID);
            }
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (Skip) yield break;
            else
            {
                if (Charas == null) Charas = new List<int>();
                if (Enemies == null) Enemies = new List<int>();
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (Charas.Contains(chara.ID))
                    {
                        chara.RemoveStatusEffect(Inspiration.StatusID);
                        if (chara.UnitTypes.Contains(Inspiration.Passive)) chara.TryRemovePassiveAbility(Inspiration.Passive);
                    }
                }
                Charas.Clear();
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (Enemies.Contains(enemy.ID))
                    {
                        enemy.RemoveStatusEffect(Inspiration.StatusID);
                        if (enemy.UnitTypes.Contains(Inspiration.Passive)) enemy.TryRemovePassiveAbility(Inspiration.Passive);
                    }
                }
                Enemies.Clear();
            }
        }
    }
    public class ApplyInspirationAction : CombatAction
    {
        public static List<int> Charas;
        public static List<int> Enemies;
        public int ID;
        public bool IsChara;
        public bool Skip;

        public ApplyInspirationAction(int id, bool ischara)
        {
            ID = id;
            IsChara = ischara;
            if (IsChara)
            {
                if (Charas == null) Charas = new List<int>();
                if (Charas.Contains(ID)) Skip = true;
                else Charas.Add(ID);
            }
            else
            {
                if (Enemies == null) Enemies = new List<int>();
                if (Enemies.Contains(ID)) Skip = true;
                else Enemies.Add(ID);
            }
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (Skip) yield break;
            if (Inspiration.Object == null || Inspiration.Object.Equals(null)) Debug.LogError("inspiration null");
            else
            {
                if (Charas == null) Charas = new List<int>();
                if (Enemies == null) Enemies = new List<int>();
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (Charas.Contains(chara.ID))
                    {
                        if (!chara.ApplyStatusEffect(Inspiration.Object, 1)) continue;
                        if (chara.UnitTypes.Contains(Inspiration.Passive)) if (Inspiration.Inspired != null && !Inspiration.Inspired.Equals(null)) chara.AddPassiveAbility(Inspiration.Inspired);
                    }
                }
                Charas.Clear();
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (Enemies.Contains(enemy.ID))
                    {
                        if (!enemy.ApplyStatusEffect(Inspiration.Object, 1)) continue;
                        if (enemy.UnitTypes.Contains(Inspiration.Passive)) if (Inspiration.Inspired != null && !Inspiration.Inspired.Equals(null)) enemy.AddPassiveAbility(Inspiration.Inspired);
                    }
                }
                Enemies.Clear();
            }
        }
    }
    public class PartyMemberInspirationApplicationAction : CombatAction
    {
        public IUnit unit;
        public PartyMemberInspirationApplicationAction(IUnit unit)
        {
            this.unit = unit;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (!stats.IsPlayerTurn)
            {
                unit.SimpleSetStoredValue(Inspiration.Multiattack, unit.SimpleGetStoredValue(Inspiration.Multiattack) + 1);
            }
            else
            {
                if (!unit.RefreshAbilityUse())
                {
                    unit.SimpleSetStoredValue(Inspiration.Multiattack, unit.SimpleGetStoredValue(Inspiration.Multiattack) + 1);
                }
            }
            yield return null;
        }
    }

    public static class InspirationHandler
    {
        public static void Clear()
        {
            ApplyInspirationAction.Charas = new List<int>();
            ApplyInspirationAction.Enemies = new List<int>();
            RemoveInspirationAction.Charas = new List<int>();
            RemoveInspirationAction.Enemies = new List<int>();
        }
        public static void NotifCheck(string notifname, object sender, object args)
        {
            if (notifname == TriggerCalls.OnCombatEnd.ToString()) Clear();
            else if (notifname == TriggerCalls.OnBeforeCombatStart.ToString()) Clear();
        }
        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck);
            MainMenuException.AddAction(Clear);
        }
    }

    public class ApplyInspirationEffect : EffectSO
    {
        [Header("Status")]
        public StatusEffect_SO _Status;

        [Header("Data")]
        public bool _ApplyToFirstUnit;

        public bool _JustOneRandomTarget;

        public bool _RandomBetweenPrevious;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Inspiration.Object;

            exitAmount = 0;
            if (_Status == null)
            {
                Inspiration.Add();
            }

            if (_ApplyToFirstUnit || _JustOneRandomTarget)
            {
                List<TargetSlotInfo> list = new List<TargetSlotInfo>();
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    if (targetSlotInfo.HasUnit)
                    {
                        list.Add(targetSlotInfo);
                        if (_ApplyToFirstUnit)
                        {
                            break;
                        }
                    }
                }

                if (list.Count > 0)
                {
                    int index = UnityEngine.Random.Range(0, list.Count);
                    exitAmount += ApplyStatusEffect(list[index].Unit, entryVariable);
                }
            }
            else
            {
                for (int j = 0; j < targets.Length; j++)
                {
                    if (targets[j].HasUnit)
                    {
                        exitAmount += ApplyStatusEffect(targets[j].Unit, entryVariable);
                    }
                }
            }

            return exitAmount > 0;
        }

        public int ApplyStatusEffect(IUnit unit, int entryVariable)
        {
            int num = (_RandomBetweenPrevious ? UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1) : entryVariable);
            if (num < _Status.MinimumRequiredToApply)
            {
                return 0;
            }

            if (!unit.ContainsStatusEffect(Inspiration.StatusID)) unit.SimpleSetStoredValue(Inspiration.Prevent, 1);
            if (!unit.ApplyStatusEffect(_Status, num))
            {
                unit.SimpleSetStoredValue(Inspiration.Prevent, 0);
                return 0;
            }
            if (unit.UnitTypes.Contains(Inspiration.Passive)) if (Inspiration.Inspired != null && !Inspiration.Inspired.Equals(null)) unit.AddPassiveAbility(Inspiration.Inspired);
            unit.SimpleSetStoredValue(Inspiration.Prevent, 0);
            return Mathf.Max(1, num);
        }
    }
}
