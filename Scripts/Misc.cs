using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class April
    {
        public static bool Birthday
        {
            get
            {
                if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1) return true;
                return false;
            }
        }
        public static int Mod
        {
            get
            {
                if (Birthday) return 5;
                return 1;
            }
        }
        public static int MoreMod
        {
            get
            {
                if (Birthday) return 50;
                return 1;
            }
        }
        public static int LessMod
        {
            get
            {
                if (Birthday) return 25;
                return 0;
            }
        }
    }
}
