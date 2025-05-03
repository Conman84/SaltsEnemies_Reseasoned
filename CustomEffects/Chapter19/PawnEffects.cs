using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class TraitorCondition : EffectorConditionSO
    {
        static Sprite _icon;
        public static Sprite Icon
        {
            get
            {
                if (_icon == null) _icon = ResourceLoader.LoadSprite("idk.png");
                Debug.LogWarning("get the traitor passive icon here: TraitorCondition.Sprite");
                return _icon;
            }
        }
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageReceivedValueChangeException hitBy)
            {
                if (hitBy.possibleSourceUnit == null) return false;
                if (hitBy.possibleSourceUnit.IsUnitCharacter != effector.IsUnitCharacter)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(PriorityRootActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<TraitorPassiveEffect>(), 1, Slots.Self),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Sides)
                    }), 1, Slots.Self) }, effector as IUnit));
                }
                else
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(PriorityRootActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<TraitorPassiveEffect>(), 1, Slots.Self),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front)
                    }), 1, Slots.Self) }, effector as IUnit));
                }
            }
            return false;
        }
    }
    public class TraitorPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Traitor", TraitorCondition.Icon));
            exitAmount = 0;
            return true;
        }
    }
    public class HasInfestationEffectCondition : EffectConditionSO
    {
        public bool ShouldHave;
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.ContainsPassiveAbility(PassiveType_GameIDs.Infestation.ToString()) == ShouldHave;
        }
        public static HasInfestationEffectCondition Create(bool shouldHave)
        {
            HasInfestationEffectCondition ret = ScriptableObject.CreateInstance<HasInfestationEffectCondition>();
            ret.ShouldHave = shouldHave;
            return ret;
        }
    }
    public class AddInfestationEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.ContainsPassiveAbility(PassiveType_GameIDs.Infestation.ToString())) target.Unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.InfestationPA.ToString(), target.Unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.InfestationPA.ToString()) + 1);
                    else target.Unit.AddPassiveAbility(Passives.Infestation1);
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class ChanceZeroDamageEffect : DamageEffect
    {
        public float Chance;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, UnityEngine.Random.Range(0f, 1f) < Chance ? 0 : entryVariable, out int exi))
                    exitAmount += exi;
            }
            return exitAmount > 0;
        }
    }
}
