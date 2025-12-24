using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class HasEnemySpaceCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots) if (!slot.HasUnit) return true;
            return false;
        }
    }
    public class HasEnemySpaceEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots) if (!slot.HasUnit) return true;
            return false;
        }
    }
    public class SplitInTwoEffect : EffectSO
    {
        public bool SilentDeath(EnemyCombat self, IUnit killer, bool obliteration = false)
        {
            int currentHealth = self.CurrentHealth;
            self.CurrentHealth = 0;
            self.HasFled = true;
            CombatManager.Instance.AddUIAction(new EnemyDamagedUIAction(self.ID, self.CurrentHealth, self.MaximumHealth, currentHealth, CombatType_GameIDs.Dmg_Weak.ToString()));
            CombatManager.Instance.AddSubAction(new GuaranteedEnemyDeathAction(self.ID, killer, DeathType_GameIDs.DirectDeath.ToString()));
            return true;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.CurrentHealth <= 1) return false;
            float gap = caster.CurrentHealth;
            gap /= 2;
            gap = Math.Max(1, gap);
            int final = (int)Math.Ceiling(gap);
            if (!(caster is EnemyCombat enemy)) return false;
            EnemySO en = enemy.Enemy;
            List<string> abilities = new List<string>();
            for (int i = 0; i < stats.timeline.Round.Count; i++)
            {
                if (stats.timeline.CurrentTurn >= i) continue;
                TurnInfo turn = stats.timeline.Round[i];
                if (!turn.isPlayer && turn.turnUnit.ID == caster.ID)
                {
                    if (turn.abilitySlot < caster.AbilityCount)
                    {
                        abilities.Add(enemy.Abilities[turn.abilitySlot].ability._abilityName);
                    }
                }
            }
            List<IStatusEffect> status = new List<IStatusEffect>((caster as IStatusEffector).StatusEffects);
            List<BasePassiveAbilitySO> passives = new List<BasePassiveAbilitySO>((caster as IPassiveEffector).PassiveAbilities);
            Dictionary<string, UnitStoreDataHolder> stored = null;
            if (caster is CharacterCombat chara) stored = chara.StoredValues;
            if (caster is EnemyCombat) stored = enemy.StoredValues;
            SilentDeath(enemy, null);
            CombatManager.Instance.AddSubAction(new Spawn2HalvesAction(en, final, abilities, status, passives, caster.HealthColor, stored));
            return true;
        }
        public class Spawn2HalvesAction : CombatAction
        {
            public EnemySO en;
            public int final;
            public List<string> abilities;
            public List<IStatusEffect> status;
            public List<BasePassiveAbilitySO> passives;
            public ManaColorSO healthColor;
            public Dictionary<string, UnitStoreDataHolder> data;
            public Spawn2HalvesAction(EnemySO en, int final, List<string> abilities, List<IStatusEffect> status, List<BasePassiveAbilitySO> passives, ManaColorSO healthColor = null, Dictionary<string, UnitStoreDataHolder> data = null)
            {
                this.en = en;
                this.final = final;
                this.abilities = abilities;
                this.status = status;
                this.passives = passives;
                this.healthColor = healthColor;
                this.data = data;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                for (int a = 0; a < 2; a++)
                {
                    int num = stats.GetRandomEnemySlot(en.size);
                    if (num != -1)
                    {
                        if (stats.AddNewEnemy(en, num, false, CombatType_GameIDs.Spawn_Basic.ToString(), final))
                        {
                            EnemyCombat newborn = stats.Enemies[stats.Enemies.Count - 1];
                            if (newborn is IUnit unit)
                            {
                                if (data != null)
                                {
                                    if (newborn.StoredValues == null) newborn.StoredValues = new Dictionary<string, UnitStoreDataHolder>();
                                    foreach (string key in data.Keys)
                                    {
                                        UnitStoreDataHolder clone = new UnitStoreDataHolder(data[key]._UnitData);
                                        clone.m_MainData = data[key].m_MainData;
                                        clone.m_MainString = data[key].m_MainString;
                                        clone.m_ObjectData = data[key].m_ObjectData;

                                        newborn.StoredValues[key] = clone;
                                    }
                                }
                                if (healthColor != null && !healthColor.Equals(null)) CombatManager.Instance.AddSubAction(new ApplyHealthColorAction(healthColor, unit));
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
                                        Debug.LogError("Spawn2HalvesAction: trying to apply status effects fail");
                                        Debug.LogError(ex.ToString());
                                    }
                                }
                                foreach (BasePassiveAbilitySO passive in passives)
                                {
                                    try
                                    {
                                        CombatManager.Instance.AddSubAction(new ApplyPassiveAction(passive, unit));
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.LogError("Spawn2HalvesAction: trying to add passive fail");
                                        Debug.LogError(ex.ToString());
                                    }
                                }
                                List<EnemyCombat> list = new List<EnemyCombat>();
                                List<int> actions = new List<int>();
                                for (int i = 0; i < abilities.Count; i++)
                                {
                                    list.Add(newborn);
                                    int add = newborn.GetLastAbilityIDFromNameUsingAbilityName(abilities[i]);
                                    if (add < 0) add = UnityEngine.Random.Range(0, newborn.AbilityCount);
                                    actions.Add(add);
                                }
                                stats.timeline.AddExtraEnemyTurns(list, actions);
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
        public class ApplyPassiveAction : CombatAction
        {
            public BasePassiveAbilitySO passive;
            public IUnit unit;
            public ApplyPassiveAction(BasePassiveAbilitySO passive, IUnit unit)
            {
                this.passive = passive;
                this.unit = unit;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                if (!unit.ContainsPassiveAbility(passive.m_PassiveID)) unit.AddPassiveAbility(passive);
                yield return null;
            }
        }
        public class ApplyHealthColorAction : CombatAction
        {
            public ManaColorSO health;
            public IUnit unit;
            public ApplyHealthColorAction(ManaColorSO health, IUnit unit)
            {
                this.health = health;
                this.unit = unit;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                if (health != null && !health.Equals(null))
                {
                    if (unit.HealthColor != health)
                        unit.ChangeHealthColor(health);
                }
                yield return null;
            }
        }

        public class GuaranteedEnemyDeathAction : CombatAction
        {
            public int _enemyID;
            public IUnit _killer;
            public string _deathType;

            public GuaranteedEnemyDeathAction(int enemyID, IUnit killer, string deathType)
            {
                _enemyID = enemyID;
                _killer = killer;
                _deathType = deathType;
            }
            public static void SilentEnemyDeath(EnemyCombat self, DeathReference deathReference, string deathTypeID)
            {
                self.IsAlive = false;
                self.DeathBy = deathTypeID;

                self.DisconnectPassives();
                self.RemoveAllStatusEffects(showInfo: false);
                self.FinalizationEnd(disconnectPassives: false);
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                EnemyCombat enemyCombat = stats.TryGetEnemyOnField(_enemyID);
                if (enemyCombat != null)
                {
                    DeathReference deathReference = new DeathReference(_killer, witheringDeath: false, _deathType);
                    SilentEnemyDeath(enemyCombat, deathReference, _deathType);
                    CombatManager.Instance.AddUIAction(new EnemyDeathUIAction(enemyCombat.ID, playDeathSound: true));
                    stats.RemoveEnemy(_enemyID);
                }

                yield break;
            }
        }
    }
    public class HasCasterSizeEffectCondition : EffectConditionSO
    {
        public bool EnemySpace(int size)
        {
            for (int i = 0; i < 5; i++)
            {
                if (CombatManager.Instance._stats.combatSlots.GetEnemyFitSlot(i, size) != -1) return true;
            }
            return false;
        }
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.IsUnitCharacter) return CombatManager.Instance._stats.CharactersOnField.Count < 5;

            return EnemySpace(caster.Size);
        }
    }
}
