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
            public static class Piscina
            {
                public static string Hard => "PiscinaHard";
            }
            public static class Tumult
            {
                public static string Easy => "TumultEasy";
                public static string Med => "TumultMed";
            }
            public static class Boiler
            {
                public static string Easy => "BoilerEasy";
                public static string Med => "BoilerMed";
            }
            public static class Tassnn
            {
                public static string Easy => "TassnnEasy";
                public static string Med => "TassnnMed";
            }
            public static class Olmic
            {
                public static string Med => "OlmicMed";
                public static string Hard => "OlmicHard";
            }
            public static class Phalaris
            {
                public static string Hard => "PhalarisHard";
            }

            //ita
            public static class Soothsayer
            {
                public static string Med => "H_ZoneSiren_Soothsayer_Medium_EnemyBundle";
            }

            //hif
            public static class OneShooter
            {
                public static string Med => "H_ZoneSiren_OneShooter_Medium_EnemyBundle";
            }
        }
    }
}
