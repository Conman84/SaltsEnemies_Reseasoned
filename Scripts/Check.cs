using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Check
    {
        public static List<string> Printeds = new List<string>();
        public static bool EnemyExist(string name)
        {
            if (!LoadedAssetsHandler.LoadedEnemies.ContainsKey(name) && LoadedAssetsHandler.LoadEnemy(name) == null) { if (DoDebugs.EnemyNull && !Printeds.Contains(name)) { Debug.LogWarning("Enemy: " + name + " is null"); Printeds.Add(name); } return false; }
            return LoadedAssetsHandler.GetEnemy(name) != null;
        }
        public static bool BundleExist(string name)
        {
            if (!LoadedAssetsHandler.LoadedEnemyBundles.ContainsKey(name) && LoadedAssetsHandler.LoadEnemyBundle(name) == null) { if (DoDebugs.EnemyNull) Debug.LogWarning("Bundle: " + name + " is null"); return false; }
            return LoadedAssetsHandler.GetEnemyBundle(name) != null;
        }
        public static bool MultiENExistInternal(string[] names)
        {
            foreach (string name in names)
            {
                if (!EnemyExist(name)) return false;
            }
            return true;
        }
        public static class DoDebugs
        {
            public static bool All => false;
            public static bool EnemyNull => true && All;
            public static bool SpriteNull => false && All;
            public static bool GenInfo => false && All;
            public static bool MiscInfo => false && All;
        }

        public static bool Trolling(int num) => SaltsReseasoned.trolling == num;
        public static bool Silly(int num) => SaltsReseasoned.silly == num;
        public static bool Rando(int num) => SaltsReseasoned.rando == num;
    }
}
