using BrutalAPI;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.UI.CanvasScaler;

//i have a whole firebird rework planned

namespace SaltEnemies_Reseasoned
{
    public class AbilitySelector_Firebird : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string trackDown = "Fiery Death";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            int orig = 35;
            if (unit is EnemyCombat enemy) orig = enemy.Enemy.health;
            string name = ability.ability._abilityName;
            return unit.CurrentHealth >= orig && name == this.trackDown;
        }
    }
    public class RejuvinationPassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            if (args is BooleanReference booleanReference && sender is IUnit unit)
            {
                if (booleanReference.value == false) return;
                if (unit.MaximumHealth > 4)
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, _passiveName, passiveIcon));
                    if (GibsWithHeal(unit, unit.MaximumHealth - unit.CurrentHealth, null, true) > 0)
                    {
                        booleanReference.value = false;
                        float gap = unit.MaximumHealth;
                        gap /= 2;
                        unit.MaximizeHealth((int)Math.Floor(gap));
                        if (unit.IsUnitCharacter)
                        {
                            ScriptableObject.CreateInstance<ApplyStunnedEffect>().PerformEffect(CombatManager.Instance._stats, unit, Slots.Self.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int graggler);
                        }
                        else
                        {
                            CombatManager.Instance.ProcessImmediateAction(new OverexertTriggeredAction(unit.ID, unit.IsUnitCharacter));
                        }
                    }
                }
                ScriptableObject.CreateInstance<ApplyFireSlotEffect>().PerformEffect(CombatManager.Instance._stats, unit, Slots.Self.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int exit);
            }
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }

        public static int GibsWithHeal(IUnit unit, int amount, IUnit source, bool directHeal, string healTypeID = "", ExtraHealReturnInfo extraInfo = null)
        {
            if (!unit.IsUnitCharacter)
            {
                if (!unit.CanHeal(directHeal, amount))
                {
                    return 0;
                }
                if (!unit.IsUnitCharacter) CombatManager.Instance.AddUIAction(new SpawnEnemyGibsUIAction(unit.ID));

                if (healTypeID == "")
                {
                    healTypeID = CombatType_GameIDs.Heal_Basic.ToString();
                }

                HealingReceivedValueChangeException ex = new HealingReceivedValueChangeException(amount, directHeal, source, unit);
                CombatManager.Instance.PostNotification(TriggerCalls.OnBeingHealed.ToString(), unit, ex);
                int modifiedValue = ex.GetModifiedValue();
                IntegerReference args = new IntegerReference(modifiedValue);
                CombatManager.Instance.PostNotification(TriggerCalls.OnWillBeHealed.ToString(), unit, args);
                int num = Mathf.Min(unit.CurrentHealth + modifiedValue, unit.MaximumHealth);
                int num2 = num - unit.CurrentHealth;
                if (num2 != 0)
                {
                    (unit as EnemyCombat).CurrentHealth = num;
                    CombatManager.Instance.AddUIAction(new EnemyHealedUIAction(unit.ID, unit.CurrentHealth, unit.MaximumHealth, modifiedValue, healTypeID));
                    IntegerReference args2 = new IntegerReference(num2);
                    CombatManager.Instance.PostNotification(TriggerCalls.OnHealed.ToString(), unit, args2);
                    if (directHeal)
                    {
                        CombatManager.Instance.PostNotification(TriggerCalls.OnDirectHealed.ToString(), unit, args2);
                    }
                }
                else
                {
                    CombatManager.Instance.AddUIAction(new EnemyNotHealedUIAction(unit.ID, modifiedValue, healTypeID));
                }

                if (extraInfo != null)
                {
                    extraInfo.attemptedHealAmount = modifiedValue;
                }

                return num2;
            }
            else
            {
                return unit.Heal(amount, source, directHeal, healTypeID, extraInfo);
            }
        }

    }
    public class SingeClawsEffect : EffectSO
    {
        [SerializeField]
        public string _deathType = DeathType_GameIDs.Basic.ToString();

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                int DoFire = entryVariable;
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                    }

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                    DoFire -= damageInfo.damageAmount;
                }
                if (DoFire > 0)
                {
                    stats.combatSlots.ApplyFieldEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, StatusField.OnFire, DoFire);
                }
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }
    }
    public class CasterInFireCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.IsUnitCharacter)
            {
                return CombatManager.Instance._stats.combatSlots.CharacterSlots[caster.SlotID].ContainsFieldEffect(StatusField_GameIDs.OnFire_ID.ToString());
            }
            return CombatManager.Instance._stats.combatSlots.EnemySlots[caster.SlotID].ContainsFieldEffect(StatusField_GameIDs.OnFire_ID.ToString());
        }
    }
    public class CombativePassiveAbility : FleetingPassiveAbility
    {
        public void OnSecondTriggered(object sender, object args)
        {
            (sender as IUnit).SimpleSetStoredValue(fleeting_USD, 0);
        }
        public override void OnPassiveConnected(IUnit unit)
        {
            base.OnPassiveConnected(unit);
            CombatManager.Instance.AddObserver(OnSecondTriggered, TriggerCalls.OnDamaged.ToString(), unit);
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance.RemoveObserver(OnSecondTriggered, TriggerCalls.OnDamaged.ToString(), unit);
            base.OnPassiveDisconnected(unit);
        }
    }
}
