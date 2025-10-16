using BrutalAPI;
using JetBrains.Annotations;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class ReplicatorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is StringReference reference && effector is CharacterCombat chara)
            {
                foreach (CombatAbility abil in chara.CombatAbilities)
                {
                    if (abil.ability.name == (!effector.ContainsStatusEffect("Muted_ID") ? reference.value : "Slap_A"))
                    {
                        ReplicatorEffect_A effectA = ScriptableObject.CreateInstance<ReplicatorEffect_A>();
                        effectA.Use = abil;
                        ReplicatorEffect_B effectB = ScriptableObject.CreateInstance<ReplicatorEffect_B>();
                        effectB.Use = abil;

                        CombatManager.Instance.AddSubAction(new RootActionAction(new EffectAction([
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterShowItemEffect>()),
                            Effects.GenerateEffect(effectA),
                            Effects.GenerateEffect(effectB, 1, Slots.Front),
                            ], effector as IUnit)));
                    }
                }
            }
            return false;
        }
    }

    public class ReplicatorEffect_A : EffectSO
    {
        public CombatAbility Use;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            if (Use != null && caster.IsUnitCharacter) (caster as CharacterCombat).TryPerformRandomAbility(Use.ability);

            return true;
        }
    }

    public class ReplicatorEffect_B : EffectSO
    {
        public CombatAbility Use;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            ExtraAbilityInfo load = new ExtraAbilityInfo();
            load.ability = Use.ability;
            load.cost = Use.cost;
            load.rarity = Rarity.GetCustomRarity("rarity5");

            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    target.Unit.AddExtraAbility(load);
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
}
