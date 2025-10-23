using BepInEx.Configuration;
using MonoMod.RuntimeDetour;
using System;
using System.Linq;
using System.Reflection;

namespace SaltsEnemies_Reseasoned
{
    public static class Gatekeeper
    {
        public static string Gatekeeps => "SaltEnemies_RunTracker";
        public static int StoredRuns;

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(Gatekeeper).GetMethod(nameof(MainMenuController_OnEmbarkPressed), ~BindingFlags.Default));
            IDetour hook1 = new Hook(typeof(EnemyEncounterSelectorSO).GetMethod(nameof(EnemyEncounterSelectorSO.GetEnemyBundle), ~BindingFlags.Default), typeof(Gatekeeper).GetMethod(nameof(EnemyEncounterSelectorSO_GetEnemyBundle), ~BindingFlags.Default));
        }
        public static void MainMenuController_OnEmbarkPressed(Action<MainMenuController> orig, MainMenuController self)
        {
            StoredRuns = LoadedDBsHandler.InfoHolder.Game.GetIntData(Gatekeeps);
            StoredRuns++;
            //FOR NOW
            if (StoredRuns < 5) StoredRuns = 5;
            LoadedDBsHandler.InfoHolder.Game.SetIntData(Gatekeeps, StoredRuns);

            orig(self);
        }

        public static bool AllowEnemy(string enemy)
        {
            if (Salt.Beginner.Contains(enemy) && StoredRuns < 1) return false;
            if (Salt.Easy.Contains(enemy) && StoredRuns < 2) return false;
            if (Salt.Med.Contains(enemy) && StoredRuns < 3) return false;
            if (Salt.Hard.Contains(enemy) && StoredRuns < 4) return false;
            if (Salt.Expert.Contains(enemy) && StoredRuns < 5) return false;

            return true;
        }

        public static EnemyCombatBundle EnemyEncounterSelectorSO_GetEnemyBundle(Func<EnemyEncounterSelectorSO, EnemyCombatBundle> orig, EnemyEncounterSelectorSO self)
        {
            EnemyCombatBundle ret = orig(self);

            for (int i = 0; i < 999; i++)
            {
                foreach (EnemyBundleData enemyData in ret.Enemies)
                {
                    if (!AllowEnemy(enemyData.enemy.name))
                    {
                        ret = orig(self);
                        break;
                    }
                }

                return ret;
            }

            return ret;
        }
    }

    public static class Salt
    {
        public static string[] Bosses = ["Smilers_BOSS", "CrowChild_BOSS", "BlackAndBlue_BOSS", "Megalania_BOSS", "Invention_BOSS", "BlueSky_BOSS"];
        public static string[] Ch01 = ["EmbersofaDeadGod_EN", "LostSheep_EN", "Enigma_EN", "DeadPixel_EN", "LittleAngel_EN"];
        public static string[] Ch02 = ["TeachaMantoFish_EN", "Satyr_EN", "Something_EN", "Derogatory_EN"];
        public static string[] Ch03 = ["TheCrow_EN", "Freud_EN", "AFlower_EN", "StarGazer_EN"];
        public static string[] Ch04 = [Enemies.Camera, Spoggle.Gray, Jumble.Gray];
        public static string[] Ch06 = ["Delusion_EN", "FakeAngel_EN", Flower.Red, Flower.Yellow, Flower.Blue, Flower.Purple];
        public static string[] Ch07 = ["Postmodern_EN", "War_EN", "TheDeep_EN"];
        public static string[] Ch08 = ["ClockTower_EN", Enemies.Tank, "Sigil_EN", Enemies.Solvent, "WindSong_EN"];
        public static string[] Ch09 = ["Spectre_EN", "StalwartTortoise_EN", "Grandfather_EN", Flower.Grey];
        public static string[] Ch10 = ["EyePalm_EN", "Merced_EN", "Miriam_EN", "MiniReaper_EN", "Shua_EN", "Skyloft_EN"];
        public static string[] Ch11 = ["Damocles_EN", "GlassFigurine_EN", "SnakeGod_EN", "Nameless_EN", "Rabies_EN", "Tripod_EN"];
        public static string[] Ch12 = ["Firebird_EN", "Hunter_EN", "LittleBeak_EN", "Warbird_EN"];
        public static string[] Ch13 = ["BlackStar_EN", "Singularity_EN", "Maw_EN", "Indicator_EN", "Windle_EN"];
        public static string[] Ch14 = ["Clione_EN", "Arceles_EN", "Children6_EN", "Stoplight_EN", "Pinano_EN", "Minana_EN", "YNL_EN"];
        public static string[] Ch15 = ["GlassedSun_EN", Bots.Red, Bots.Yellow, Bots.Blue, Bots.Purple, Bots.Gray];
        public static string[] Ch16 = ["TheDragon_EN", "Crystal_EN", "CandyStone_EN", "OdeToHumanity_EN", "TortureMeNot_EN", "Cruelties1_EN"];
        public static string[] Ch17 = ["EvilDog_EN", "Evileye_EN", "ToyUfo_EN", "NobodyGrave_EN", "YellowAngel_EN"];
        public static string[] Ch18 = ["Complimentary_EN", "PersonalAngel_EN", Enemies.Shooter, "Sinker_EN"];
        public static string[] Ch19 = ["PawnA_EN", "Yin_EN", "Yang_EN", "Wednesday_EN", "Starless_EN", "Eyeless_EN"];
        public static string[] Ch20 = ["2009_EN", "Chiito_EN", "Solitaire_EN", "Spades_EN", "Foxtrot_EN"];
        public static string[] Ch21 = ["33_EN", "Wall_EN", "Clown_EN", "Waltz_EN", "VoiceTrumpet_EN", "Author_EN", "Monster_EN"];


        public static string[] Beginner = ["LostSheep_EN", "Enigma_EN", "DeadPixel_EN", "LittleAngel_EN", "EmbersofaDeadGod_EN", "TeachaMantoFish_EN", "Satyr_EN", "Something_EN", "Derogatory_EN", "TheCrow_EN", "Freud_EN", "AFlower_EN", "StarGazer_EN", Enemies.Camera];
        public static string[] Easy = ["Delusion_EN", "FakeAngel_EN", Flower.Yellow, Flower.Purple, Bots.Red, Bots.Yellow, "Sigil_EN", "WindSong_EN", Enemies.Solvent, "EyePalm_EN", "BlackStar_EN", "Skyloft_EN", "LittleBeak_EN", "Singularity_EN", "Pinano_EN", "Minana_EN", "Evileye_EN", "ToyUfo_EN", "Wall_EN", "Smilers_BOSS"];
        public static string[] Med = [Spoggle.Grey, Jumble.Grey, "Shiny_EN", "TheDeep_EN", "SnakeGod_EN", "Spectre_EN", "Grandfather_EN", Flower.Red, Flower.Blue, Bots.Blue, Bots.Purple, Bots.Grey, "Rabies_EN", "Tripod_EN", "Maw_EN", "Arceles_EN", "Clione_EN", "Sinker_EN", "VoiceTrumpet_EN", "Waltz_EN", "Foxtrot_EN", "PawnA_EN", "NobodyGrave_EN", "YellowAngel_EN", "Windle_EN", "MiniReaper_EN", "CrowChild_BOSS", "Megalania_BOSS"];
        public static string[] Hard = [Flower.Grey, "Postmodern_EN", "War_EN", "StalwartTortoise_EN", "ClockTower_EN", Enemies.Tank, "Merced_EN", "Miriam_EN", "Shua_EN", Enemies.Shooter, "2009_EN", "Chiito_EN", "Complimentary_EN", "33_EN", "Author_EN", "Monster_EN", "Wednesday_EN", "Starless_EN", "Yang_EN", "Crystal_EN", "TortureMeNot_EN", "Cruelties1_EN", "CandyStone_EN", "Hunter_EN", "Warbird_EN", "Indicator_EN", "Stoplight_EN", "GlassedSun_EN", "Clown_EN", "BlackAndBlue_BOSS", "Invention_BOSS"];
        public static string[] Expert = ["Damocles_EN", "GlassFigurine_EN", "Nameless_EN", "Children6_EN", "YNL_EN", "TheDragon_EN", "OdeToHumanity_EN", "EvilDog_EN", "PersonalAngel_EN", "Yin_EN", "Eyeless_EN", "Solitaire_EN", "Spades_EN"];
    }
}
