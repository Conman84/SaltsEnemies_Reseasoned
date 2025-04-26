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
}