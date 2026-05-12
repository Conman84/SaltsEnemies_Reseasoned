using BrutalAPI;
using JetBrains.Annotations;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class SystemicCondition : EffectorConditionSO
    {
        public int Max;
        public string Counter;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            bool ret = false;

            int count = (effector as IUnit).SimpleGetStoredValue(Counter);
            count++;

            if (count >= Max)
            {
                count = 0;
                ret = true;
            }

            (effector as IUnit).SimpleSetStoredValue(Counter, count);

            return ret;
        }
        public static SystemicCondition Create(int amount, string name)
        {
            SystemicCondition ret = ScriptableObject.CreateInstance<SystemicCondition>();
            ret.Max = amount;
            ret.Counter = name;
            return ret;
        }
    }
    public class RepeaterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromNameUsingAbilityName("Repeater") });
            }
            return true;
        }
    }
    public class ChanageValueByPreviousEffect : CasterStoredValueChangeEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return base.PerformEffect(stats, caster, targets, areTargetSlots, PreviousExitValue, out exitAmount);
        }
        public static ChanageValueByPreviousEffect Create(string value, bool increase, int min = 0)
        {
            ChanageValueByPreviousEffect ret = ScriptableObject.CreateInstance<ChanageValueByPreviousEffect>();
            ret.m_unitStoredDataID = value;
            ret._increase = increase;
            ret._minimumValue = min;
            return ret;
        }
    }
    public class HasCentralPartyMemberCondition : EffectConditionSO
    {
        public bool returnTrue = false;

        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            TargetSlotInfo[] check = Targeting.GenerateGenericTarget([2]).GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter);
            foreach (TargetSlotInfo target in check)
            {
                if (target.HasUnit) return returnTrue;
            }
            return !returnTrue;
        }
        public static HasCentralPartyMemberCondition Create(bool should)
        {
            HasCentralPartyMemberCondition ret = ScriptableObject.CreateInstance<HasCentralPartyMemberCondition>();
            ret.returnTrue = should;
            return ret;
        }
    }
    public class NobodyMovedCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return NobodyMoveHandler.Chara.Count <= 0;
        }
    }
    public class TargetingUnit_NotManuallyMoved : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] orig = base.GetTargets(slots, casterSlotID, isCasterCharacter);

            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();

            foreach (TargetSlotInfo target in orig)
            {
                if (target.HasUnit && !target.Unit.HasManuallySwappedThisTurn) ret.Add(target);
            }

            return ret.ToArray();
        }
    }
    public class EverybodyMovedCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (!chara.HasManuallySwappedThisTurn) return false;
            }
            return true;
        }
    }
    public class TargetingUnit_NotManuallyAbility : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] orig = base.GetTargets(slots, casterSlotID, isCasterCharacter);

            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();

            foreach (TargetSlotInfo target in orig)
            {
                if (target.HasUnit && !target.Unit.HasManuallyUsedAbilityThisTurn) ret.Add(target);
            }

            return ret.ToArray();
        }
    }
    public class EverybodyAbilityCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (!chara.HasManuallyUsedAbilityThisTurn) return false;
            }
            return true;
        }
    }
    public class TargetingUnit_ManuallyAbilityAndMoved : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] orig = base.GetTargets(slots, casterSlotID, isCasterCharacter);

            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();

            foreach (TargetSlotInfo target in orig)
            {
                if (target.HasUnit && (target.Unit.HasManuallyUsedAbilityThisTurn || target.Unit.HasManuallySwappedThisTurn)) ret.Add(target);
            }

            return ret.ToArray();
        }
    }

    public class ScrambleAllAbilitiesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<AbilitySO> abilities = [];
            List<ManaColorSO[]> costs = [];

            foreach (CharacterCombat chara in stats.CharactersOnField.Values)
            {
                foreach (CombatAbility ability in chara.CombatAbilities)
                {
                    abilities.Add(ability.ability);
                    costs.Add(ability.cost);
                }

                chara._combatAbilities = [];
            }

            int tick = 0;
            while (abilities.Count > stats.CharactersOnField.Count && tick < 10)
            {
                tick++;

                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (abilities.Count <= 0) break;
                    if (chara.CombatAbilities.Count >= 10) continue;

                    int a = UnityEngine.Random.Range(0, abilities.Count);
                    AbilitySO ability = abilities[a];
                    abilities.RemoveAt(a);

                    int c = UnityEngine.Random.Range(0, costs.Count);
                    ManaColorSO[] cost = costs[c];
                    costs.RemoveAt(c);

                    CombatAbility combat = new CombatAbility(ability, cost);

                    chara.CombatAbilities.Add(combat);

                    exitAmount++;
                }
            }

            tick = 0;
            while (abilities.Count > 0 && tick < 99)
            {
                tick++;

                List<CharacterCombat> charas = [.. stats.CharactersOnField.Values];
                CharacterCombat chara = charas[UnityEngine.Random.Range(0, charas.Count)];
                if (chara.CombatAbilities.Count >= 10) continue;

                int a = UnityEngine.Random.Range(0, abilities.Count);
                AbilitySO ability = abilities[a];
                abilities.RemoveAt(a);
                int c = UnityEngine.Random.Range(0, costs.Count);
                ManaColorSO[] cost = costs[c];
                costs.RemoveAt(c);
                CombatAbility combat = new CombatAbility(ability, cost);

                chara.CombatAbilities.Add(combat);

                exitAmount++;
            }

            foreach (CharacterCombat chara in stats.CharactersOnField.Values)
            {
                CombatManager.Instance.AddUIAction(new CharacterUpdateAllAttacksUIAction(chara.ID, chara.CombatAbilities.ToArray()));
            }

            return true;
        }
    }
}
