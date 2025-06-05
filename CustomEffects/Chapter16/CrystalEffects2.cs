using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class Winter
    {
        public static int Mod
        {
            get
            {
                switch (DateTime.Now.Month)
                {
                    case 12: return 5;
                    case 11: return 4;
                    case 10: return 3;
                    case 1: return 4;
                    case 2: return 4;
                    case 3: return 3;
                    default: return April.Birthday ? 3 : 1;
                }
            }
        }
        public static bool Chance
        {
            get
            {
                return UnityEngine.Random.Range(0, 2) < Mod;
            }
        }
    }
}
