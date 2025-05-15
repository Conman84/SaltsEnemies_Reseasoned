using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class NoiseTargetting : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.SimpleGetStoredValue(NoiseHandler.Noise) >= 5)
                {
                    ret.Add(target);
                }
            }
            return ret.ToArray();
        }

        public static NoiseTargetting Default()
        {
            NoiseTargetting ret = ScriptableObject.CreateInstance<NoiseTargetting>();
            ret.getAllies = false;
            ret.getAllUnitSlots = false;
            return ret;
        }
    }
    public class IsNoiseCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (chara.SimpleGetStoredValue(NoiseHandler.Noise) >= 5)
                {
                    return true;
                }
            }

            return false;
        }
    }
    public class DelayRespawnEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddRootAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<RespawnEffect>(), 1, Targeting.Slot_SelfSlot) }, caster));
            return true;
        }
    }
    public class RespawnEffect : EffectSO
    {
        public bool givesExperience;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0; if (caster.IsUnitCharacter) return false;
            EnemySO enemy = (caster as EnemyCombat).Enemy;
            for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, caster.SlotID, givesExperience, trySpawnAnyways: true, _spawnType));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
    public class ApplyConstrictedSlotEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Field = StatusField.Constricted;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class SilenceCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IUnit unit)
            {
                unit.SimpleSetStoredValue(NoiseHandler.Noise, unit.SimpleGetStoredValue(NoiseHandler.Noise) + 1);
            }
            return true;
        }
    }
}
