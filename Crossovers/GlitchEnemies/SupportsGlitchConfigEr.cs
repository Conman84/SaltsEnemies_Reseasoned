using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using static SaltsEnemies_Reseasoned.Check;
using System.Linq;

namespace SaltsEnemies_Reseasoned
{
    public static class SupportsGlitchConfigEr
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(Gatekeeper).GetMethod(nameof(Gatekeeper.AllowEnemy), ~BindingFlags.Default), typeof(LunopticonHandler).GetMethod(nameof(Gatekeeper_AllowEnemy), ~BindingFlags.Default));
        }

        public static bool Gatekeeper_AllowEnemy(Func<string, bool> orig, string enemy)
        {
            if (HasntEncounters(enemy, ["UnculturedSwine_EN"], ["SwineEasy", "SwineMed", "SwineHard"])) return false;
            if (HasntEncounters(enemy, ["DryBait_EN"], ["BaitMed", "BaitHard"])) return false;
            if (HasntEncounters(enemy, ["Enno_EN"], ["EnnoEasy", "EnnoMed"])) return false;
            if (HasntEncounters(enemy, ["NotAn_EN"], ["PipeMed"])) return false;
            if (HasntEncounters(enemy, ["Flakkid_EN"], ["FlakkidEasy", "FlakkidMed"])) return false;
            if (HasntEncounters(enemy, ["BackupDancer_EN"], ["BDancerEasy", "BDancerMed", "BDancerHard"])) return false;
            if (HasntEncounters(enemy, ["Frostbite_EN"], ["FrostbiteEasy", "FrostbiteMed", "FrostbiteHard"])) return false;
            if (HasntEncounters(enemy, ["Frostbite_Bipedal_EN"], ["BFrostbiteMed", "BFrostbiteHard"])) return false;
            if (HasntEncounters(enemy, ["ExternalIncubator_EN"], ["IncubatorHard"])) return false;
            if (HasntEncounters(enemy, ["Jansuli_EN"], ["JansuliEasy", "JansuliMed", "JansuliHard"])) return false;
            if (HasntEncounters(enemy, ["PrimitiveGizo_Calm_EN"], ["PGizoMed", "PGizoHard"])) return false;
            if (HasntEncounters(enemy, ["Gizard_EN"], ["GizardMed", "GizardHard"])) return false;
            if (HasntEncounters(enemy, ["Footshroom_EN"], ["FootshroomMed", "FootshroomHard"])) return false;
            if (HasntEncounters(enemy, ["MarbleMaw_EN"], ["MawEasy", "MawMed"])) return false;
            if (HasntEncounters(enemy, ["FrowningChancellor_EN"], ["ChancellorEasy", "ChancellorMed", "ChancellorHard"])) return false;
            if (HasntEncounters(enemy, ["GodsChalice_EN"], ["ChaliceMed", "ChaliceHard"])) return false;
            if (HasntEncounters(enemy, ["Vagabond_EN"], ["VagabondMed", "VagabondHard"])) return false;
            if (HasntEncounters(enemy, ["FuckYouGuy_EN"], ["FuckYouGuy"])) return false;

            return orig(enemy);
        }

        public static bool HasntEncounters(string enemy, string[] enemies, string[] encounters)
        {
            if (!enemies.Contains(enemy)) return false;

            foreach (string enounter in encounters)
            {
                if (BundleExist(enounter)) return false;
            }

            return true;
        }
    }
}
