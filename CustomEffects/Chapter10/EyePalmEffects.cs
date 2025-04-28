using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//EyePalm rework
//Pigs in Blue: If any enemies share this enemy's health color, inflict 1 Constricted on their Opposing positions.
// - for targetting, use Targetting_ByUnit_SideCasterColor instead of Targetting_ByUnit_SideColor
//Blood in Crazy: If any single-tile enemies share this enemy's health color, shuffle their positions between them.
// - for targeting, use Targetting_ByUnit_SideCasterColor instead of the WHOLE thing.
// - the effect, use ShufflePositionsAmongTargetsEffect
// - set it to 3 ability priority

namespace SaltEnemies_Reseasoned
{
    public class HasHealthColorCondition : EffectConditionSO
    {
        public bool characters;
        public ManaColorSO color;
        public bool all;

        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            CombatStats stats = CombatManager.Instance._stats;
            if (characters)
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (all && chara.HealthColor != color) return false;
                    if (!all && chara.HealthColor == color) return true;
                }
            }
            else
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (all && enemy.HealthColor != color) return false;
                    if (!all && enemy.HealthColor == color) return true;
                }
            }
            if (all) return true;
            else return false;
        }
        public static HasHealthColorCondition Create(ManaColorSO Color, bool getChara, bool ifAll = false)
        {
            HasHealthColorCondition ret = ScriptableObject.CreateInstance<HasHealthColorCondition>();
            ret.color = Color;
            ret.characters = getChara;
            ret.all = ifAll;
            return ret;
        }
    }
    public class HasCasterHealthColorCondition : HasHealthColorCondition
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            color = caster.HealthColor;
            return base.MeetCondition(caster, effects, currentIndex);
        }
        public static HasCasterHealthColorCondition Create(bool getChara, bool ifAll = false)
        {
            HasCasterHealthColorCondition ret = ScriptableObject.CreateInstance<HasCasterHealthColorCondition>();
            ret.characters = getChara;
            ret.all = ifAll;
            return ret;
        }
    }
    public class Targetting_ByUnit_SideCasterColor : Targetting_ByUnit_Side
    {
        public ManaColorSO Color;
        public bool SingleSize;
        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => getAllUnitSlots;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            CombatSlot caster = null;
            if (isCasterCharacter) { foreach (CombatSlot slot in slots.CharacterSlots) { if (slot.SlotID == casterSlotID) caster = slot; } }
            else { foreach (CombatSlot slot in slots.EnemySlots) { if (slot.SlotID == casterSlotID) caster = slot; } }
            if (caster == null || caster.Equals(null)) return new TargetSlotInfo[0];
            if (!caster.HasUnit) return new TargetSlotInfo[0];
            Color = caster.Unit.HealthColor;
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.HealthColor.SharesPigmentColor(Color))
                {
                    if (!SingleSize || target.Unit.Size == 1)
                    ret.Add(target);
                }
            }
            return ret.ToArray();
        }
    }
    public class ShufflePositionsAmongTargetsEffect : EffectSO
    {
        public int MassEnemySwapSwapping(SlotsCombat self, List<int> slots)
        {
            int num = 0;
            List<int> foundSlots = new List<int>();
            List<IUnit> foundUnits = new List<IUnit>();
            foreach (int i in slots)
            {
                if (i < 0 || i >= 5) continue;
                if (!self.EnemySlots[i].HasUnit) continue;
                else if (self.EnemySlots[i].Unit.Size >= 2) continue;
                else if (self.EnemySlots[i].Unit.SlotID == i)
                {
                    if (!self.EnemySlots[i].Unit.CanBeSwapped)
                    {
                        //return 0;
                        continue;
                    }

                    foundUnits.Add(self.EnemySlots[i].Unit);
                    foundSlots.Add(i);
                    num++;
                }
            }

            if (num == 0)
            {
                return 0;
            }

            int pointInArray = 0;
            int newSlotID = foundSlots[pointInArray];
            int[] ret_IDs = new int[foundUnits.Count];
            int[] ret_Slots = new int[foundUnits.Count];
            List<int> swappedSlots = new List<int>();
            int index = (foundUnits.Count > 1) ? UnityEngine.Random.Range(0, foundUnits.Count) : 0;
            while (foundUnits.Count > 0)
            {
                IUnit unit = foundUnits[index];
                foundUnits.RemoveAt(index);
                index = UnityEngine.Random.Range(0, foundUnits.Count);
                bool hasUnit = unit != null && !unit.Equals(null);
                int Size = ((!hasUnit) ? 1 : unit.Size);
                for (int j = 0; j < Size; j++)
                {
                    self.EnemySlots[newSlotID + j].SetUnit(unit);
                }

                if (hasUnit)
                {
                    swappedSlots.Add(newSlotID);
                    ret_IDs[pointInArray] = unit.ID;
                }
                else
                {
                    ret_IDs[pointInArray] = -1;
                }

                ret_Slots[pointInArray] = newSlotID;
                pointInArray++;
                if (foundSlots.Count > pointInArray)
                    newSlotID = foundSlots[pointInArray];
            }

            CombatManager.Instance.AddUIAction(new EnemySlotsHaveSwappedUIAction(ret_IDs, ret_Slots, CombatType_GameIDs.Swap_Mass.ToString()));
            foreach (int item in swappedSlots)
            {
                self.EnemySlots[item].Unit.SwappedTo(item);
            }

            return num;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<int> ret = new List<int>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                int num5 = (targetSlotInfo.HasUnit ? targetSlotInfo.Unit.SlotID : targetSlotInfo.SlotID);
                int num6 = ((!targetSlotInfo.HasUnit) ? 1 : targetSlotInfo.Unit.Size);
                if (targetSlotInfo.IsTargetCharacterSlot)
                {
                    continue;
                }
                else
                {
                    ret.Add(targetSlotInfo.SlotID);
                }
            }

            if (ret.Count > 0)
            {
                exitAmount += MassEnemySwapSwapping(stats.combatSlots, ret);
            }

            return exitAmount > 0;
        }
    }
}
