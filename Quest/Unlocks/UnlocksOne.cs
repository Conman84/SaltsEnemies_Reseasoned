using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class UnlocksOne
    {
        public static void Add()
        {
            PassiveLockingEffect cogEffect = ScriptableObject.CreateInstance<PassiveLockingEffect>();
            cogEffect.m_PassiveIDs = [
                PassiveType_GameIDs.Skittish.ToString(), PassiveType_GameIDs.Slippery.ToString(), PassiveType_GameIDs.Constricting.ToString(),
                "Jumpy_PA", "Lightweight_PA", "Scramble_PA", "Evasive_PA", "Turbulent_PA", "CCTV_PA", "Jittery_PA", "Fluttery_PA", WarpingHandler.Type,
                "Lonely_PA", "Melancholy_PA", "Gluttony_PA", "Rotary_PA", MarchingHandler.Passive, "Hiding_PA", "Seeking_PA"
                ];
        }
    }
}
