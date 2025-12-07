using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class BulwarkCondition : EffectorConditionSO
    {
        public int MaxInclusive;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageReceivedValueChangeException change)
            {
                change.AddModifier(new BulwarkModifier(MaxInclusive, effector as IUnit));
            }
            return true;
        }
        public static BulwarkCondition Create (int maxInc)
        {
            BulwarkCondition ret = ScriptableObject.CreateInstance<BulwarkCondition>();
            ret.MaxInclusive = maxInc;
            return ret;
        }
    }

    public class BulwarkModifier : IntValueModifier
    {
        public int MaxInclusive;
        public IUnit Caster;
        public BulwarkModifier(int maxInclusive, IUnit itemHolder = null) : base(55)
        {
            MaxInclusive = maxInclusive;
            Caster = itemHolder;
        }
        public override int Modify(int value)
        {
            if (value <= MaxInclusive && value > 0)
            {
                if (Caster != null) Caster.ShowItem();
                return 0;
            }
            return value;
        }
    }

    public class BooleanValueInSlipSetter : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is BooleanReference reference)
            {
                reference.value = (effector as IUnit).ContainsFieldEffect("Slip_ID");
                if (reference.value) (effector as IUnit).ShowItem();
            }
            return true;
        }
    }

    public class IsMainCharaEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster is CharacterCombat chara && chara.IsMainCharacter;
        }
    }

    public class NineKeyEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            bool run = UnityEngine.Random.Range(0, 100) < 10;

            bool chara = caster is IEffectorChecks effector && effector.IsUnitCharacter;

            if (chara && UnityEngine.Random.Range(0, 100) < 50) run = true;

            if (!run) return false;

            CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(((LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").passiveAbilities[0] as ExtraAttackPassiveAbility)._extraAbility.ability.effects[0].effect as AnimationVisualsIfUnitEffect)._visuals, Slots.Self, caster));

            if (chara || UnityEngine.Random.Range(0, 100) < 50) return caster.DirectDeath(caster);

            else return stats.EnemiesOnField.Values.ToList().GetRandom().DirectDeath(caster);

        }
    }
}
