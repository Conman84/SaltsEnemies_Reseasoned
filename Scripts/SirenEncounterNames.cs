using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Siren
    {
        public static bool Exists => LoadedDBsHandler.EnemyDB.DoesEncounterPoolExist("TheSiren_Zone1");

        public static class H
        {
            public static class Ecstasy
            {
                public static class Red
                {
                    public static string Med => "H_ZoneSiren_Ecstasy13_Medium_EnemyBundle";
                }
                public static class Blue
                {
                    public static string Med => "H_ZoneSiren_Ecstasy09_Medium_EnemyBundle";
                }
                public static class Yellow
                {
                    public static string Med => "H_ZoneSiren_Ecstasy02_Medium_EnemyBundle";
                }
                public static class Purple
                {
                    public static string Med => "H_ZoneSiren_Ecstasy87_Medium_EnemyBundle";
                }
            }
        }
    }
}
