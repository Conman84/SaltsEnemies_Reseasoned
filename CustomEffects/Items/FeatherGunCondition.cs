using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class FeatherGunCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException hitting)
            {
                (effector as IUnit).ShowItem();
                if (hitting.opponentUnitType != null && hitting.opponentUnitType.Contains("Bird")) hitting.AddModifier(new FloatMod(2.0f, true));
                else hitting.AddModifier(new FloatModMin1(1.15f, false));
            }
            return false;
        }

        public static void AddTypes()
        {
            LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("Revola_EN").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("Scrungie_EN").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("Charcarrion_Corpse_BOSS").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").unitTypes.Add("Bird");
        }
    }
    public class KindnessHammerCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                value.damagedUnit.Heal(4, effector as IUnit, true, CombatType_GameIDs.Heal_Basic.ToString());
                value.AddModifier(new PercentageValueModifier(true, 25, true));
            }
            return true;
        }
    }
    public class IsCursedEffectorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return (effector as IUnit).ContainsStatusEffect(StatusField_GameIDs.Cursed_ID.ToString());
        }
    }
    public class DoesNotHaveAbilityEffectorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return !effector.IsUnitCharacter || !(effector as CharacterCombat).CanUseAbilitiesNoTrigger;
        }
    }
    public class ReduceAllNegativeStatusEffect : EffectSO
    {
        [SerializeField]
        public List<string> Exclude = new List<string>();
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            entryVariable = -1 * Math.Abs(entryVariable);
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    if (targetSlotInfo.Unit is IStatusEffector effector)
                    {
                        foreach (IStatusEffect status in new List<IStatusEffect>(effector.StatusEffects))
                        {
                            if (!status.IsPositive && !Exclude.Contains(status.StatusID))
                            {
                                if (status.StatusContent > Math.Abs(entryVariable))
                                {
                                    if (status.TryAddContent(entryVariable, 0))
                                    {
                                        effector.StatusEffectValuesChanged(status.StatusID, entryVariable, true);
                                        exitAmount += Math.Abs(entryVariable);
                                    }
                                }
                                else
                                {
                                    exitAmount += targetSlotInfo.Unit.TryRemoveStatusEffect(status.StatusID);
                                }
                            }
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class ReduceNegStatusOnHealTargetsEffectorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingDealtValueChangeException value && value.healingUnit != null)
            {
                if (value.healingUnit.StatusEffectCount <= 0) return false;

                CombatManager.Instance.AddSubAction(new EffectAction([Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterShowItemEffect>())], effector as IUnit));
                CombatManager.Instance.AddSubAction(new EffectAction([Effects.GenerateEffect(ScriptableObject.CreateInstance<ReduceAllNegativeStatusEffect>(), 2, Slots.Self)], value.healingUnit));
            }
            return false;
        }
    }
    public class IncreaseDamageByPigmentUsedCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                value.AddModifier(new AdditionValueModifier(true, PigmentUsedCollector.PigmentsUsed.Count));
            }
            return false;
        }
    }
    public class DamagelMoreByBlueCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException reference)
            {
                int num = 0;
                foreach (ManaBarSlot slot in CombatManager.Instance._stats.MainManaBar.ManaBarSlots)
                {
                    if (!slot.IsEmpty && slot.ManaColor.SharesPigmentColor(Pigments.Blue)) num++;
                }

                if (num > 0)
                {
                    (effector as IUnit).ShowItem();
                    reference.AddModifier(new AdditionValueModifier(true, num));
                }
            }
            return false;
        }
    }
    public class IncreaseHealIfManuallyMovedCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingDealtValueChangeException value)
            {
                if ((effector as IUnit).HasManuallySwappedThisTurn)
                {
                    (effector as IUnit).ShowItem();
                    value.AddModifier(new PercentageValueModifier(true, 40, true));
                }
            }
            return true;
        }
    }
    public class RecyclerCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            CombatManager.Instance.AddSubAction(new RootActionAction(
                new EffectAction([
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterShowItemEffect>()),
                    Effects.GenerateEffect(GeneratePigmentByArrayEffect.Create(PigmentUsedCollector.lastUsed.ToArray()))
                    ], effector as IUnit)));
            return true;
        }
    }
    public class GeneratePigmentByArrayEffect : GenerateColorManaEffect
    {
        public ManaColorSO[] Pigments;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (ManaColorSO mana in Pigments)
            {
                this.mana = mana;
                base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int exi);
                exitAmount += exi;
            }
            return exitAmount > 0;
        }
        public static GeneratePigmentByArrayEffect Create(ManaColorSO[] array)
        {
            GeneratePigmentByArrayEffect ret = ScriptableObject.CreateInstance<GeneratePigmentByArrayEffect>();
            ret.Pigments = array;
            return ret;
        }
    }

}
