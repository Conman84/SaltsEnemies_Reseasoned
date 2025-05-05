using System;
using System.Collections.Generic;
using System.Text;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public class LonelyEffect : SwapToOneSideEffect
    {
        //public static UnitStoredValueNames value => (UnitStoredValueNames)8282501;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int left = -1;
            int right = -1;
            foreach (CombatSlot slot in caster.IsUnitCharacter ? stats.combatSlots.CharacterSlots : stats.combatSlots.EnemySlots)
            {
                if (!slot.HasUnit) continue;
                if (slot.SlotID >= caster.SlotID && slot.SlotID < caster.SlotID + caster.Size) continue;
                if (slot.SlotID < caster.SlotID) left = caster.SlotID - (slot.SlotID + 1);
                else if (slot.SlotID >= caster.SlotID + caster.Size) right = slot.SlotID - (caster.SlotID + caster.Size);
            }
            if (left <= 0 && right <= 0) return false;
            if (left <= 0) left = 99;
            if (right <= 0) right = 99;
            bool goLeft = (left < right) || (left == right && UnityEngine.Random.Range(0, 100) < 50);
            //caster.SetStoredValue(value, 1);
            if (goLeft)
            {
                _swapRight = false;
                for (int i = 0; i < left - 1; i++) base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, entryVariable, out exitAmount);
            }
            else
            {

                _swapRight = true;
                for (int i = 0; i < right - 1; i++) base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, entryVariable, out exitAmount);
            }
            //caster.SetStoredValue(value, 0);
            return left > 0 || right > 0;
        }
    }
    public class LonelyCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (CombatManager.Instance._stats.EnemiesOnField.Count <= 1) return false;
            //if ((effector as IUnit).GetStoredValue(LonelyEffect.value) > 0) return false;
            foreach (CombatSlot slot in effector.IsUnitCharacter ? CombatManager.Instance._stats.combatSlots.CharacterSlots : CombatManager.Instance._stats.combatSlots.EnemySlots)
            {
                if (slot.SlotID == effector.SlotID - 1 && slot.HasUnit) return false;
                else if (slot.SlotID == effector.SlotID + (effector as IUnit).Size && slot.HasUnit) return false;
            }
            return true;
        }
    }
    public class SpawnFishEffect : SpawnEnemyAnywhereEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            List<EnemySO> fish = new List<EnemySO>();
            for (int i = 0; i < 12; i++) fish.Add(LoadedAssetsHandler.GetEnemy("MudLung_EN"));
            for (int i = 0; i < 2; i++) fish.Add(LoadedAssetsHandler.GetEnemy("Mung_EN"));
            fish.Add(LoadedAssetsHandler.GetEnemy("Goa_EN"));
            for (int i = 0; i < 4; i++) fish.Add(LoadedAssetsHandler.GetEnemy("MunglingMudLung_EN"));
            for (int i = 0; i < 4; i++) fish.Add(LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN"));
            for (int i = 0; i < 3; i++) fish.Add(LoadedAssetsHandler.GetEnemy("Mungie_EN"));
            for (int i = 0; i < 3; i++) fish.Add(LoadedAssetsHandler.GetEnemy("Keko_EN"));
            if (Check.EnemyExist("Pinano_EN"))
            {
                fish.Add(LoadedAssetsHandler.GetEnemy("Minana_EN"));
                for (int i = 0; i < 5; i++) fish.Add(LoadedAssetsHandler.GetEnemy("Pinano_EN"));
            }
            fish.Add(LoadedAssetsHandler.GetEnemy("Wringle_EN"));
            for (int i = 0; i < 2; i++) fish.Add(LoadedAssetsHandler.GetEnemy("Spoggle_Spitfire_EN"));
            fish.Add(LoadedAssetsHandler.GetEnemy("ManicHips_EN"));
            if (Check.EnemyExist("AFlower_EN")) for (int i = 0; i < 3; i++) fish.Add(LoadedAssetsHandler.GetEnemy("AFlower_EN"));
            if (Check.EnemyExist("TeachaMantoFish_EN")) fish.Add(LoadedAssetsHandler.GetEnemy("TeachaMantoFish_EN"));
            foreach (EnemySO en in LoadedAssetsHandler.LoadedEnemies.Values)
            {
                if (en.unitTypes.Contains(UnitType_GameIDs.Fish.ToString()) && en.size == 1 && en.health <= 30)
                {
                    if (!fish.Contains(en)) fish.Add(en);
                }
            }
            enemy = fish.GetRandom();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class AlarmCondition : HasEnemySpaceEffectCondition
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int pass = 30;
            if (CombatManager.Instance._stats.EnemiesOnField.Count <= 1) pass *= 2;
            if (UnityEngine.Random.Range(0, 100) > pass) return false;
            return base.MeetCondition(caster, effects, currentIndex);
        }
    }
}
