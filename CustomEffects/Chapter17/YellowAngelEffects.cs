using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class PriorityRootActionEffect : EffectSO
    {
        public EffectInfo[] effects;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] info = effects;
            exitAmount = 0;
            CombatManager.Instance.AddPriorityRootAction(new EffectAction(info, caster));
            return true;
        }

        public static PriorityRootActionEffect Create(EffectInfo[] e)
        {
            PriorityRootActionEffect ret = ScriptableObject.CreateInstance<PriorityRootActionEffect>();
            ret.effects = e;
            return ret;
        }
    }
    public class FlutteryCondition : EffectorConditionSO
    {
        static Sprite _icon;
        public static Sprite Icon
        {
            get
            {
                if (_icon == null) _icon = ResourceLoader.LoadSprite("FlutteryIcon.png");
                return _icon;
            }
        }
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector.SlotID >= 4 || effector.SlotID <= 0) return false;
            if (args is IntegerReference inty)
            {
                if (inty.value < effector.SlotID)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(PriorityRootActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<FlutteryPassiveEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsAliveEffectCondition>()),
                        Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self, ScriptableObject.CreateInstance<IsAliveEffectCondition>())
                    }), 1, Slots.Self) }, effector as IUnit));
                }
                else if (inty.value > effector.SlotID)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] {Effects.GenerateEffect(PriorityRootActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<FlutteryPassiveEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsAliveEffectCondition>()),
                        Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self, ScriptableObject.CreateInstance<IsAliveEffectCondition>())
                    }), 1, Slots.Self) }, effector as IUnit));
                }
                else return false;
            }
            return false;
        }
    }
    public class FlutteryPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Fluttery", FlutteryCondition.Icon));
            exitAmount = 0;
            return true;
        }
    }
    public class IsAliveEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.IsAlive;
        }
    }
    public class OnSightEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> targeti = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.HasManuallySwappedThisTurn || target.Unit.HasManuallyUsedAbilityThisTurn) targeti.Add(target);
                }
            }
            return base.PerformEffect(stats, caster, targeti.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class MarkThemEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> targeti = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.ContainsStatusEffect(StatusField_GameIDs.Frail_ID.ToString())) targeti.Add(target);
                }
            }
            return base.PerformEffect(stats, caster, targeti.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class MaybeApplySlipUpToEntryEffect : ApplySlipSlotEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, UnityEngine.Random.Range(0, entryVariable + 1), out int exi))
                {
                    exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
    public class AnyHasFrailEffectCondition : EffectConditionSO
    {
        public bool getAllies;
        public bool returnHas;
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if ((caster.IsUnitCharacter && getAllies) || (!caster.IsUnitCharacter && !getAllies))
            {
                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    if (chara.ContainsStatusEffect(StatusField_GameIDs.Frail_ID.ToString())) return returnHas;
                }
            }
            else
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.ContainsFieldEffect(StatusField_GameIDs.Frail_ID.ToString())) return returnHas;
                }
            }
            return !returnHas;
        }
        public static AnyHasFrailEffectCondition Create(bool getAlly, bool has)
        {
            AnyHasFrailEffectCondition ret = ScriptableObject.CreateInstance<AnyHasFrailEffectCondition>();
            ret.getAllies = getAlly;
            ret.returnHas = has;
            return ret;
        }
    }

    public class AbilitySelector_Yellow : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string[] NoIfCenter = [];

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
                {
                    return index;
                }
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                {
                    return index;
                }
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability.name;


            return unit.SlotID == 2 && NoIfCenter.Contains(name);
        }
    }
}
