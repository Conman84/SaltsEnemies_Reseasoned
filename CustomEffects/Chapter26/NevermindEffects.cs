using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class EmptinessPassiveEffectorCondition : EffectorConditionSO
    {
        public BasePassiveAbilitySO passive;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference_Damage value)
            {
                if (value.directDamage && value.damagedUnit != null && value.possibleSourceUnit != null)
                {
                    if (passive != null)
                    {
                        CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(effector.ID, effector.IsUnitCharacter, passive._passiveName, passive.passiveIcon));
                    }

                    int selfmissing = value.damagedUnit.MaximumHealth - value.damagedUnit.CurrentHealth;

                    int killermissing = value.possibleSourceUnit.MaximumHealth - value.possibleSourceUnit.CurrentHealth;

                    value.damagedUnit.MaximizeHealth(value.damagedUnit.CurrentHealth + killermissing);
                    value.possibleSourceUnit.MaximizeHealth(value.possibleSourceUnit.CurrentHealth + selfmissing);
                }
            }
            return false;
        }
    }

    public class ForceTargetsUseSlapEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.TryPerformRandomAbility(LoadedAssetsHandler.GetCharacterAbility("Slap_A"))) exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }

    public class TargettingUnitsMaxHealth : TargettingByHealthUnits
    {
        public bool GetAllUnits;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            List<CombatSlot> opinion = new List<CombatSlot>();
            if (isCasterCharacter == getAllies || GetAllUnits)
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.MaximumHealth < opinion[0].Unit.MaximumHealth) || (!Lowest && slot.Unit.MaximumHealth > opinion[0].Unit.MaximumHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.MaximumHealth == opinion[0].Unit.MaximumHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            if (isCasterCharacter != getAllies || GetAllUnits)
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.Unit.SlotID))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.MaximumHealth < opinion[0].Unit.MaximumHealth) || (!Lowest && slot.Unit.MaximumHealth > opinion[0].Unit.MaximumHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.MaximumHealth == opinion[0].Unit.MaximumHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            foreach (CombatSlot slot in opinion)
            {
                targets.Add(slot.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    
    public class KillAllTargetsMaxHealthThresholdEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.MaximumHealth >= entryVariable)
                    {
                        if (target.Unit.DirectDeath(caster, false, out int num)) exitAmount += num;
                    }
                }
            }
            return exitAmount > 0;
        }
    }

    public class ApplyMutedMoreMaxHealthCasterTargetsEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.MaximumHealth > caster.MaximumHealth)
                {
                    if (target.Unit.ApplyStatusEffect(Muted.Object, entryVariable)) exitAmount += entryVariable;
                }
            }
            return exitAmount > 0;
        }
    }

    public class HalveCurrentAndMaxHealthEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int newhealth = (int)Math.Ceiling((float)target.Unit.CurrentHealth / 2f);
                    int newmax = Math.Max(newhealth, (int)Math.Ceiling((float)target.Unit.MaximumHealth / 2f));

                    if (newhealth != target.Unit.CurrentHealth) exitAmount++;

                    target.Unit.SetHealthTo(newhealth);
                    target.Unit.MaximizeHealth(newmax);
                }
            }
            return exitAmount > 0;
        }
    }

    public class EffectThatPerformsOtherEffects : EffectSO
    {
        public EffectSO[] effects;
        public int[] entryvariables;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < effects.Length && i < entryvariables.Length; i++)
            {
                effects[i].PerformEffect(stats, caster, targets, areTargetSlots, entryvariables[i], out int exi);
                exitAmount += exi;
            }
            return exitAmount > 0;
        }
    }
}
