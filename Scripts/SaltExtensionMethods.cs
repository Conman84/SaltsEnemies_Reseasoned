using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class SaltExtensionMethods
    {
        public static T GetRandom<T>(this T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
        public static T GetRandom<T>(this List<T> list)
        {
            return list.ToArray().GetRandom();
        }
        public static T[] UpTo<T>(this T[] array, int index)
        {
            List<T> ret = new List<T>();
            for (int i = 0; i < index && i < array.Length; i++)
            {
                ret.Add(array[i]);
            }
            return ret.ToArray();
        }
        public static T[] Exclude<T>(this T[] array, T exclude)
        {
            List<T> ret = new List<T>();
            foreach (T str in array)
            {
                if (exclude != null && str.Equals(exclude)) continue;
                ret.Add(str);
            }
            return ret.ToArray();
        }
        public static T[] SelfArray<T>(this T target)
        {
            return new T[] { target };
        }
    }
    public static class StatusExtensions
    {
        public static StatusEffect_Holder GetStatus(this IUnit self, string id)
        {
            if (!self.ContainsStatusEffect(id)) return null;
            foreach (IStatusEffect holder in (self as IStatusEffector).StatusEffects)
            {
                if (holder.StatusID == id && holder is StatusEffect_Holder ret) return ret;
            }
            return null;
        }
        public static int GetStatusAmount(this IUnit self, string id, bool includeRestrictor = false)
        {
            StatusEffect_Holder holder = self.GetStatus(id);
            if (holder != null)
            {
                return includeRestrictor ? holder.StatusContent + holder.Restrictor : holder.StatusContent;
            }
            return 0;
        }
        public static FieldEffect_Holder GetField(this CombatSlot self, string id)
        {
            if (!self.ContainsFieldEffect(id)) return null;
            foreach (IFieldEffect holder in (self as IFieldSlotEffector).FieldEffects)
            {
                if (holder.FieldID == id && holder is FieldEffect_Holder ret) return ret;
            }
            return null;
        }
        public static FieldEffect_Holder GetFieldFromID(int slot, bool chara, string id)
        {
            if (chara) return CombatManager.Instance._stats.combatSlots.CharacterSlots[slot].GetField(id);
            return CombatManager.Instance._stats.combatSlots.EnemySlots[slot].GetField(id);
        }
        public static FieldEffect_Holder GetField(this TargetSlotInfo self, string id) => GetFieldFromID(self.SlotID, self.IsTargetCharacterSlot, id);
        public static int GetFieldAmount(this CombatSlot self, string id, bool includeRestrictor = false)
        {

            FieldEffect_Holder holder = self.GetField(id);
            if (holder != null)
            {
                return includeRestrictor ? holder.FieldContent + holder.Restrictor : holder.FieldContent;
            }
            return 0;
        }
        public static int GetFieldAmount(this TargetSlotInfo self, string id, bool includeRestrictor = false)
        {

            FieldEffect_Holder holder = self.GetField(id);
            if (holder != null)
            {
                return includeRestrictor ? holder.FieldContent + holder.Restrictor : holder.FieldContent;
            }
            return 0;
        }
        public static int GetFieldAmountFromID(int slot, bool chara, string id, bool includeRestrictor = false)
        {

            FieldEffect_Holder holder = GetFieldFromID(slot, chara, id);
            if (holder != null)
            {
                return includeRestrictor ? holder.FieldContent + holder.Restrictor : holder.FieldContent;
            }
            return 0;
        }
    }
    public static class EncounterExtensions
    {
        public static void AddRandomEncounter(this EnemyEncounter_API self, string enemy1 = "", string enemy2 = "", string enemy3 = "", string enemy4 = "", string enemy5 = "")
        {
            List<string> ret = new List<string>();
            if (enemy1 != "") ret.Add(enemy1);
            if (enemy2 != "") ret.Add(enemy2);
            if (enemy3 != "") ret.Add(enemy3);
            if (enemy4 != "") ret.Add(enemy4);
            if (enemy5 != "") ret.Add(enemy5);
            self.CreateNewEnemyEncounterData(ret.ToArray());
        }
    }
}