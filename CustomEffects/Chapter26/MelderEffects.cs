using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class CasterMeldTargetEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (caster.ContainsPassiveAbility("Melded_PA"))
                    {
                        caster.TryRemovePassiveAbility("Melded_PA");
                    }

                    PerformEffectPassiveAbility meld = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    meld.name = "Melded_PA";
                    meld._passiveName = "Melded";
                    meld.m_PassiveID = "Melded_PA";
                    meld.passiveIcon = ResourceLoader.LoadSprite("MeldedPassive.png");
                    meld._enemyDescription = "On fleeing, halve " + target.Unit.Name + "'s current health and inflict a slew of Negative Status Effects on them.";
                    meld._characterDescription = "On fleeing, halve " + target.Unit.Name + "'s current health and inflict a slew of Negative Status Effects on them.";
                    TriggerMeldEffect trigger = ScriptableObject.CreateInstance<TriggerMeldEffect>();
                    trigger.target = target.Unit;
                    meld.effects = [Effects.GenerateEffect(trigger)];
                    meld._triggerOn = [TriggerCalls.OnFleeting];
                    meld.conditions = [];
                    meld.specialStoredData = UnitStoreData.GetCustom_UnitStoreData("Melded_PA");

                    int num = target.Unit.ID;
                    if (num == 0) num = -1;
                    caster.SimpleSetStoredValue("Melded_PA", num);

                    caster.AddPassiveAbility(meld);
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Melded with " + target.Unit.Name, meld.passiveIcon));
                    return true;
                }
            }

            return false;
        }
    }

    public class TriggerMeldEffect : EffectSO
    {
        public IUnit target;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (target != null)
            {
                int num = (int)Math.Floor((float)target.CurrentHealth / 2f);
                if (num <= 0)
                {
                    target.DirectDeath(caster, false, out int temp);
                }
                else
                {
                    target.SetHealthTo(num);
                }

                target.ApplyStatusEffect(StatusField.Cursed, 1);
                target.ApplyStatusEffect(StatusField.Scars, 1);
                target.ApplyStatusEffect(StatusField.Ruptured, 2);
                target.ApplyStatusEffect(Acid.Object, 1);
                target.ApplyStatusEffect(Entropy.Object, 3);
                target.ApplyStatusEffect(StatusField.Frail, 2);
                target.ApplyStatusEffect(Pimples.Object, 2);
                target.ApplyStatusEffect(StatusField.OilSlicked, 3);

                return true;
            }

            return false;
        }
    }

    public class FrontIsWeakestOfTargetsEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            IUnit front = null;
            if (caster.IsUnitCharacter) front = stats.combatSlots.EnemySlots[caster.SlotID].Unit;
            else front = stats.combatSlots.CharacterSlots[caster.SlotID].Unit;
            if (front == null || front.Equals(null)) return false;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.MaximumHealth < front.MaximumHealth)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class FullHealthDamageEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> t2 = [];
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.CurrentHealth >= target.Unit.MaximumHealth)
                {
                    t2.Add(target);
                }
            }
            return base.PerformEffect(stats, caster, t2.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }

    public class TargetGeneratePigmentEffect : EffectSO
    {
        public ManaColorSO pigment = Pigments.Red;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(pigment, entryVariable, target.Unit.IsUnitCharacter, target.Unit.ID));
                    exitAmount += entryVariable;
                }
            }
            return exitAmount > 0;
        }
    }
    public class MaxToCurrentEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int orig = target.Unit.MaximumHealth;
                    target.Unit.MaximizeHealth(target.Unit.CurrentHealth);
                    exitAmount += orig - target.Unit.MaximumHealth;
                }
            }
            return exitAmount > 0;
        }
    }
    public class UnitStoreData_MelderTargetSO : UnitStoreData_BasicSO
    {
        public override bool TryGetUnitStoreDataToolTip(UnitStoreDataHolder holder, out string result)
        {
            result = GenerateString(holder.m_MainData);
            return result != "";
        }

        public string GenerateString(int value)
        {
            if (value == 0) return "";
            CharacterCombat chara = null;
            int check = value;
            if (check == -1) check = 0;
            foreach (CharacterCombat ch in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (ch.ID == check) chara = ch;
            }
            if (chara == null) return "";
            string str2 = "Melded with: " + chara._currentName;
            string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.yellow) + ">";
            string str4 = "</color>";
            return str3 + str2 + str4;
        }
    }
}
