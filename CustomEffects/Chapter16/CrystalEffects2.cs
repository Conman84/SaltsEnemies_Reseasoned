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
                    case 12: return 4;
                    case 11: return 4;
                    case 10: return 4;
                    case 1: return 4;
                    case 2: return 4;
                    case 3: return 4;
                    default: return 1;
                }
            }
        }
    }
}
