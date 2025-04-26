using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using SaltsEnemies_Reseasoned;

//when calling the skyloft's wheel intent, use SkyloftIntent.Intent

namespace SaltEnemies_Reseasoned
{
    public class ApplyPermanentDodgeEffect : PermenantStatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Dodge.Object;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public static class SkyloftIntent
    {
        public static string Intent => "Skyloft_Wheel";
        public static void Setup()
        {
            Intents.CreateAndAddCustom_Basic_IntentToPool(Intent, LoadedAssetsHandler.GetWearable("WheelOfFortune_TW").wearableImage, UnityEngine.Color.white);
        }
    }
    public class TargettingByHealthNotSkyloft : TargettingByHealthUnits
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            List<CombatSlot> opinion = new List<CombatSlot>();
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.Unit.SlotID) && slot.Unit is EnemyCombat Enemy && Check.EnemyExist("Skyloft_EN") && Enemy.Enemy != LoadedAssetsHandler.GetEnemy("Skyloft_EN"))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
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
    public class NotFlitheringCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is bool b) return b;
            return true;
        }
    }
}
