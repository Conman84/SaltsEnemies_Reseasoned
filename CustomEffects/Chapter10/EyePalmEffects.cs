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
                if (target.HasUnit && target.Unit.HealthColor.SharesPigmentColor(Color)) ret.Add(target);
            }
            return ret.ToArray();
        }
    }
    public class ShufflePositionsAmongTargetsEffect : EffectSO
    {
        public int MassEnemySwapSwapping(SlotsCombat self, List<int> slots)
        {
            int num = 0;
            List<int> slots2 = new List<int>();
            List<IUnit> list = new List<IUnit>();
            foreach (int i in slots)
            {
                if (i < 0 || i >= 5) continue;
                if (!self.EnemySlots[i].HasUnit) continue;
                else if (self.EnemySlots[i].Unit.Size >= 2) continue;
                else if (self.EnemySlots[i].Unit.SlotID == i)
                {
                    if (!self.EnemySlots[i].Unit.CanBeSwapped)
                    {
                        return 0;
                    }

                    list.Add(self.EnemySlots[i].Unit);
                    slots2.Add(i);
                    num++;
                }
            }

            if (num == 0)
            {
                return 0;
            }

            int yoy = 0;
            int num2 = slots2[yoy];
            int num3 = 0;
            int[] array = new int[list.Count];
            int[] array2 = new int[list.Count];
            List<int> list2 = new List<int>();
            int index = ((list.Count > 1) ? UnityEngine.Random.Range(1, list.Count) : 0);
            while (list.Count > 0)
            {
                IUnit unit = list[index];
                list.RemoveAt(index);
                index = UnityEngine.Random.Range(0, list.Count);
                bool flag = unit != null && !unit.Equals(null);
                int num4 = ((!flag) ? 1 : unit.Size);
                for (int j = 0; j < num4; j++)
                {
                    self.EnemySlots[num2 + j].SetUnit(unit);
                }

                if (flag)
                {
                    list2.Add(num2);
                    array[num3] = unit.ID;
                }
                else
                {
                    array[num3] = -1;
                }

                array2[num3] = num2;
                num3++;
                yoy++;
                num2 = slots2[yoy];
            }

            CombatManager.Instance.AddUIAction(new EnemySlotsHaveSwappedUIAction(array, array2, CombatType_GameIDs.Swap_Mass.ToString()));
            foreach (int item in list2)
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
