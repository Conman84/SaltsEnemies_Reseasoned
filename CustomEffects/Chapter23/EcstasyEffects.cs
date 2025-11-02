using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class RandomTransformationNotSelfEffect : CasterRandomTransformationEffect
    {
        public List<TransformOption> _allTransforms;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (_allTransforms == null) return false;

            List<TransformOption> ret = new List<TransformOption>();
            foreach (TransformOption option in _allTransforms)
            {
                if (caster is CharacterCombat chara)
                {
                    if (option.characterTransformation != chara.Character.name) ret.Add(option);
                }
                else if (caster is EnemyCombat enemy)
                {
                    if (option.enemyTransformation.name != enemy.Enemy.name) ret.Add(option);
                }
            }

            _possibleTransformations = ret;

            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class AddRandomPassiveEffect : EffectSO
    {
        public BasePassiveAbilitySO[] Passives;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    List<BasePassiveAbilitySO> use = new List<BasePassiveAbilitySO>();
                    foreach (BasePassiveAbilitySO passive in Passives)
                    {
                        if (target.Unit.ContainsPassiveAbility(passive.m_PassiveID)) continue;
                        use.Add(passive);
                    }

                    if (use.Count > 0)
                    {
                        if (target.Unit.AddPassiveAbility(use.GetRandom())) exitAmount++;
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class TargetIsCasterHealthColorEffect : TargetIsHealthColorEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            base.mana = caster.HealthColor;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
