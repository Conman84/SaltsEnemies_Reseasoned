using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Tweak
    {
        public static void Setup()
        {
            Yolk();
        }

        public static void Yolk()
        {
            LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").enemyTemplate.m_Data.m_Gibs = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Extra/Yolk_Gibs.prefab").GetComponent<ParticleSystem>();
        }
    }
}
