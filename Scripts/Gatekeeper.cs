using BepInEx;
using BepInEx.Configuration;
using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using System.IO;
using UnityEngine.Networking.Types;

//i want to set this up for the achievements update but i think it would be better to save this for the superboss update. 
//really it wouldve been better to run this from the start but hindsight is 20/20.. oh well.

namespace SaltsEnemies_Reseasoned
{
    public static class Gatekeeper
    {
        public static ConfigEntry<bool> ConfigValue;
        public static bool DoGatekeep => ConfigValue != null ? ConfigValue.Value : true;

        public static string Gatekeeps => "SaltEnemies_RunTracker";
        public static int StoredRuns;

        public static bool Randoming;
        public static bool SetRandoming(bool value) => Randoming = value;

        public static int CurrentRuns;

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(Gatekeeper).GetMethod(nameof(MainMenuController_OnEmbarkPressed), ~BindingFlags.Default));
            IDetour hook1 = new Hook(typeof(EnemyEncounterSelectorSO).GetMethod(nameof(EnemyEncounterSelectorSO.GetEnemyBundle), ~BindingFlags.Default), typeof(Gatekeeper).GetMethod(nameof(EnemyEncounterSelectorSO_GetEnemyBundle), ~BindingFlags.Default));

            SetRandoming(false);

            Config();

            CurrentRuns = 0;
        }

        public static void Config()
        {
            ConfigFile seatbelt = new ConfigFile(Path.Combine(Paths.ConfigPath, "WeDontNeedNoSeatbeltsWhereWereGoing.cfg"), true);
            ConfigValue = seatbelt.Bind<bool>("SaltenemysTm", "DoSeatbelts", true, "Locks more complicated enemies from appearing in runs based off a combination of runs played with salt enemies and enemies encountered.\nMeant to be mostly unnoticeable but you can turn it off here. Dont tell anyone about this its a secret");
        }


        public static void MainMenuController_OnEmbarkPressed(Action<MainMenuController> orig, MainMenuController self)
        {
            StoredRuns = LoadedDBsHandler.InfoHolder.Game.GetIntData(Gatekeeps);
            StoredRuns++;
            CurrentRuns++;
            LoadedDBsHandler.InfoHolder.Game.SetIntData(Gatekeeps, StoredRuns);

            orig(self);
        }

        //when adding things for this, the process is:
        //if conditions: return false.
        //if no conditions, return true (at the end).
        public static bool AllowEnemy(string enemy)
        {
            if (!Check.EnemyExist(enemy)) return false;

            //if (enemy == "Untitled_EN" && enemy == "ReverseFalseHydra_EN") return false;

            if (April.Birthday || Randoming) return true;
            if (DataManager.Secret.Contains(enemy) && !April.Custom) return false;

            if (enemy == "Stalker2_EN" && CurrentRuns != 2 && (!April.Custom || SaltsReseasoned.rando > 15)) return false;
            if (enemy == "Hauntling_EN" && !April.Birthday && SaltsReseasoned.rando < 95) return false;

            if (!DoGatekeep) return true;

            //return true;//FOR NOW

            if (StoredRuns > 25) return true;
            if (StoredRuns > 15 && SaltsReseasoned.rando < 50) return true;

            //by complexity
            if (DataManager.Start.Contains(enemy) && StoredRuns < 1) return false;
            if (DataManager.Beginner.Contains(enemy) && StoredRuns < 2) return false;
            if (DataManager.Easy.Contains(enemy) && StoredRuns < 3) return false;
            if (DataManager.EM.Contains(enemy) && StoredRuns < 4) return false;
            if (DataManager.Med.Contains(enemy) && StoredRuns < 5) return false;
            if (DataManager.MH.Contains(enemy) && StoredRuns < 6) return false;
            if (DataManager.Hard.Contains(enemy) && StoredRuns < 7) return false;
            if (DataManager.Harder.Contains(enemy) && StoredRuns < 8) return false;
            if (DataManager.Hardest.Contains(enemy) && StoredRuns < 9) return false;
            if (DataManager.Expert.Contains(enemy) && StoredRuns < 10) return false;
            if (DataManager.Hidden.Contains(enemy) && StoredRuns < 11) return false;
            if (DataManager.Secret.Contains(enemy) && StoredRuns < 12) return false;

            //by prereq
            if (enemy == "Evileye_EN" && !Tracker.Track(["LostSheep_EN", "AFlower_EN"])) return false;
            if (enemy == Ecstasy.Red && !Tracker.Track("DeadPixel_EN")) return false;
            if (enemy == Ecstasy.Blue && !Tracker.Track("DeadPixel_EN")) return false;
            if (enemy == Ecstasy.Yellow && !Tracker.Track("DeadPixel_EN")) return false;
            if (enemy == Ecstasy.Purple && !Tracker.Track("DeadPixel_EN")) return false;
            if (enemy == "Delusion_EN" && !Tracker.Track("DeadPixel_EN")) return false;
            if (enemy == "WindSong_EN" && !Tracker.Track("LostSheep_EN")) return false;
            if (enemy == Enemies.Solvent && !Tracker.Track("Enigma_EN")) return false;
            if (enemy == "Sigil_EN" && !Tracker.Track("LostSheep_EN")) return false;
            if (enemy == "EyePalm_EN" && !Tracker.Track(["Enigma_EN", "AFlower_EN"])) return false;
            if (enemy == "BlackStar_EN" && !Tracker.Track(["Enigma_EN", "Sigil_EN"])) return false;
            if (enemy == "Skyloft_EN" && !Tracker.Track(["Freud_EN", "WindSong_EN", Enemies.Solvent])) return false;
            if (enemy == "ToyUfo_EN" && !Tracker.Track("AFlower_EN")) return false;
            if (enemy == "Smilers_BOSS" && !Tracker.Track(["Enigma_EN", "Something_EN"])) return false;
            if (enemy == "Wall_EN" && !Tracker.Track("Pinano_EN")) return false;
            if (enemy == "Grandfather_EN" && !Tracker.Track([Enemies.Solvent, "Sigil_EN", "WindSong_EN"])) return false;
            if (enemy == Flower.Red && !Tracker.Track([Flower.Purple, Flower.Yellow])) return false;
            if (enemy == Flower.Blue && !Tracker.Track([Flower.Purple, Flower.Yellow])) return false;
            if (enemy == Bots.Purple && !Tracker.Track([Bots.Red, Bots.Yellow])) return false;
            if (enemy == Bots.Blue && !Tracker.Track([Bots.Red, Bots.Yellow])) return false;
            if (enemy == "Windle_EN" && !Tracker.Track("Satyr_EN")) return false;
            if (enemy == "Rabies_EN" && !Tracker.Track("Wall_EN")) return false;
            if (enemy == "YellowAngel_EN" && !Tracker.Track("MiniReaper_EN")) return false;
            if (enemy == "NobodyGrave_EN" && !Tracker.Track("Pinano_EN")) return false;
            if (enemy == "MiniReaper_EN" && !Tracker.Track("Delusion_EN")) return false;
            if (enemy == "Megalania_BOSS" && !Tracker.Track(["Enigma_EN", "YellowAngel_EN", "DeadPixel_EN", Enemies.Camera])) return false;
            if (enemy == Spoggle.Grey && !Tracker.Track([Jumble.Grey, "Freud_EN"])) return false;
            if (enemy == "CoinHunter_EN" && !Tracker.Track(["FakeAngel_EN", Enemies.Camera, "TheCrow_EN", "LittleBeak_EN"])) return false;
            if (enemy == "TheDeep_EN" && !Tracker.Track("Grandfather_EN")) return false;
            if (enemy == "SnakeGod_EN" && !Tracker.Track(["Something_EN", "WindSong_EN", Enemies.Camera])) return false;
            if (enemy == "Spectre_EN" && !Tracker.Track("Skyloft_EN")) return false;
            if (enemy == Bots.Grey && !Tracker.Track([Bots.Red, Bots.Yellow, Bots.Blue, Bots.Purple, "AFlower_EN", "ToyUfo_EN"])) return false;
            if (enemy == "Tripod_EN" && !Tracker.Track(["Pinano_EN", "AFlower_EN", "LostSheep_EN"])) return false;
            if (enemy == "Maw_EN" && !Tracker.Track(["Pinano_EN", "WindSong_EN", Enemies.Solvent, "ToyUfo_EN"])) return false;
            if (enemy == "Arceles_EN" && !Tracker.Track("YellowAngel_EN")) return false;
            if (enemy == "Clione_EN" && !Tracker.Track("Pinano_EN")) return false;
            if (enemy == "Sinker_EN" && !Tracker.Track(["AFlower_EN", "ToyUfo_EN"])) return false;
            if (enemy == "VoiceTrumpet_EN" && !Tracker.Track(["Wall_EN", "Butterfly_EN", "MiniReaper_EN"])) return false;
            if (enemy == "Waltz_EN" && !Tracker.Track("Pinano_EN")) return false;
            if (enemy == "Foxtrot_EN" && !Tracker.Track("ToyUfo_EN")) return false;
            if (enemy == "PawnA_EN" && !Tracker.Track("Enigma_EN")) return false;
            if (enemy == "CrowChild_BOSS" && !Tracker.Track(["TheCrow_EN", "LittleBeak_EN", "Pinano_EN"])) return false;
            if (enemy == Flower.Grey && !Tracker.Track([Flower.Red, Flower.Blue, Flower.Yellow, Flower.Purple, "Grandfather_EN"])) return false;
            if (enemy == "StalwartTortoise_EN" && !Tracker.Track(["Clione_EN", "LostSheep_EN", "Butterfly_EN"])) return false;
            if (enemy == "Merced_EN" && !Tracker.Track("Skyloft_EN")) return false;
            if (enemy == "Shua_EN" && !Tracker.Track([Enemies.Solvent, "WindSong_EN"])) return false;
            if (enemy == Enemies.Shooter && !Tracker.Track("Something_EN")) return false;
            if (enemy == "2009_EN" && !Tracker.Track(["ToyUfo_EN", "DeadPixel_EN", Enemies.Camera])) return false;
            if (enemy == "Crystal_EN" && !Tracker.Track(["LostSheep_EN", "Evileye_EN", "TheCrow_EN", "Freud_EN", "WindSong_EN"])) return false;
            if (enemy == "TortureMeNot_EN" && !Tracker.Track("Satyr_EN")) return false;
            if (enemy == "CandyStone_EN" && !Tracker.Track("Crystal_EN")) return false;
            if (enemy == "Invention_BOSS" && !Tracker.Track(["Enigma_EN", Enemies.Solvent, "Sigil_EN"])) return false;
            if (enemy == "Chiito_EN" && !Tracker.Track(["Butterfly_EN", "Foxtrot_EN"])) return false;
            if (enemy == "Complimentary_EN" && !Tracker.Track(["Something_EN", "LostSheep_EN", "Grandfather_EN"])) return false;
            if (enemy == "Hunter_EN" && !Tracker.Track(["LittleBeak_EN", "AFlower_EN"])) return false;
            if (enemy == "Warbird_EN" && !Tracker.Track(["TheCrow_EN", "LittleBeak_EN", "WindSong_EN", "Shua_EN"])) return false;
            if (enemy == "Indicator_EN" && !Tracker.Track(["Skyloft_EN", Enemies.Solvent, "WindSong_EN", "Shua_EN"])) return false;
            if (enemy == "Wednesday_EN" && !Tracker.Track(["Warbird_EN", "Indicator_EN"])) return false;
            if (enemy == "GlassedSun_EN" && !Tracker.Track([Spoggle.Grey, Jumble.Grey, Bots.Grey, Flower.Grey])) return false;
            if (enemy == "Stoplight_EN" && !Tracker.Track(["Enigma_EN", "Sigil_EN"])) return false;
            if (enemy == "Clown_EN" && !Tracker.Track(["Something_EN", "Waltz_EN"])) return false;
            if (enemy == "BlackAndBlue_BOSS" && !Tracker.Track(["Clione_EN", "Warbird_EN"])) return false;
            if (enemy == "Postmodern_EN" && !Tracker.Track(["Enigma_EN", "Waltz_EN", "Grandfather_EN", Enemies.Tank])) return false;
            if (enemy == "ClockTower_EN" && !Tracker.Track(["Delusion_EN", "Enigma_EN"])) return false;
            if (enemy == Enemies.Tank && !Tracker.Track(["Sigil_EN", "StalwartTortoise_EN", "Wednesday_EN", "DeadPixel_EN"])) return false;
            if (enemy == "Miriam_EN" && !Tracker.Track(["EyePalm_EN", "Shua_EN", "Merced_EN", "Skyloft_EN", "WindSong_EN"])) return false;
            if (enemy == "33_EN" && !Tracker.Track(["Wall_EN", "Clown_EN", "Tripod_EN"])) return false;
            if (enemy == "Author_EN" && !Tracker.Track(["Something_EN", "Crystal_EN", "Freud_EN"])) return false;
            if (enemy == "Starless_EN" && !Tracker.Track(["DeadPixel_EN", "LostSheep_EN", "Pinano_EN", "BlackStar_EN"])) return false;
            if (enemy == "Yang_EN" && !Tracker.Track(["Enigma_EN", "Grandfather_EN", "Pinano_EN", "PawnA_EN"])) return false;
            if (enemy == "Cruelties1_EN" && !Tracker.Track([Flower.Grey, Bots.Grey, Spoggle.Grey, Jumble.Grey, "PersonalAngel_EN", "TortureMeNot_EN"])) return false;
            if (enemy == "YNL_EN" && !Tracker.Track(["DeadPixel_EN", "LostSheep_EN", "Something_EN", Enemies.Camera])) return false;
            if (enemy == "Firebird_EN" && !Tracker.Track(["Hunter_EN", "DeadPixel_EN"])) return false;
            if (enemy == "Damocles_EN" && !Tracker.Track(["EyePalm_EN", "Skyloft_EN", "Starless_EN", "Miriam_EN"])) return false;
            if (enemy == "GlassFigurine_EN" && !Tracker.Track(["Windle_EN", "WindSong_EN", Enemies.Solvent, "Indicator_EN"])) return false;
            if (enemy == "Nameless_EN" && !Tracker.Track(["ClockTower_EN", "Warbird_EN", "LittleAngel_EN", "Butterfly_EN"])) return false;
            if (enemy == "Children6_EN" && !Tracker.Track(["DeadPixel_EN", "StarGazer_EN", "Merced_EN", "NobodyGrave_EN"])) return false;
            if (enemy == "TheDragon_EN" && !Tracker.Track(["Monster_EN", "NobodyGrave_EN","Wall_EN"])) return false;
            if (enemy == "OdeToHumanity_EN" && !Tracker.Track([Spoggle.Grey, "YNL_EN", "Enigma_EN", Bots.Red, Bots.Blue, Bots.Yellow, Bots.Purple])) return false;
            if (enemy == "EvilDog_EN" && !Tracker.Track("YellowAngel_EN")) return false;
            if (enemy == "PersonalAngel_EN" && !Tracker.Track(["LittleAngel_EN", "Firebird_EN"])) return false;
            if (enemy == "Yin_EN" && !Tracker.Track(["Yang_EN", "Hunter_EN"])) return false;
            if (enemy == "Eyeless_EN" && !Tracker.Track("Starless_EN")) return false;
            if (enemy == "Solitaire_EN" && !Tracker.Track(["YellowAngel_EN", "Evileye_EN", "Enigma_EN", "Sigil_EN", "DeadPixel_EN"])) return false;
            if (enemy == "Spades_EN" && !Tracker.Track("Solitaire_EN")) return false;
            if (enemy == "WolfColony_EN" && !Tracker.Track(["Ecstasy_EN", "Clown_EN", Flower.Blue, "Monster_EN"])) return false;
            if (enemy == "WolfLarvae_EN" && !Tracker.Track("WolfColony_EN")) return false;
            if (enemy == "Stalker2_EN" && !Tracker.Track(["LittleAngel_EN", "Ecstasy_EN", "YellowAngel_EN", "FakeAngel_EN"])) return false;
            if (enemy == "Hauntling_EN" && !Tracker.Track(["ClockTower_EN", "Satyr_EN"])) return false;
            if (enemy == "Insider_EN" && !Tracker.Track(["YellowAngel_EN", "EyePalm_EN"])) return false;
            if (enemy == "Jabberwocky_EN" && !Tracker.Track(["EvilDog_EN", Enemies.Solvent])) return false;
            if (enemy == "Nume_EN" && !Tracker.Track(["Miriam_EN", "CoinHunter_EN"])) return false;
            if (enemy == "Papereater_EN" && !Tracker.Track(["YellowAngel_EN", "Arceles_EN"])) return false;
            if (enemy == "TheWhale_EN" && !Tracker.Track("Freud_EN")) return false;
            if (enemy == "CorpseChan_EN" && !Tracker.Track(["ToyUfo_EN", "2009_EN"])) return false;
            if (enemy == "InTheDark_EN" && !Tracker.Track(["Monster_EN", "Satyr_EN"])) return false;
            if (enemy == "Sundowner_EN" && !Tracker.Track(["DeadPixel_EN", "Complimentary_EN"])) return false;
            if (enemy == "Panopticon_EN" && !Tracker.Track(["Papereater_EN", "Enigma_EN"])) return false;
            if (enemy == "Lunoscope_EN" && !Tracker.Track(["Panopticon_EN", "Nume_EN"])) return false;
            if (enemy == "ReverseFalseHydra_EN" && !Tracker.Track("TortureMeNot_EN")) return false;

            return true;
        }

        public static EnemyCombatBundle EnemyEncounterSelectorSO_GetEnemyBundle(Func<EnemyEncounterSelectorSO, EnemyCombatBundle> orig, EnemyEncounterSelectorSO self)
        {
            EnemyCombatBundle ret = orig(self);

            for (int i = 0; i < 999; i++)
            {
                bool safe = true;

                foreach (EnemyBundleData enemyData in ret.Enemies)
                {
                    if (!AllowEnemy(enemyData.enemy.name) || IsDefaultColorInSiren(enemyData.enemy.name, self))
                    {
                        if (SaltsReseasoned.DebugVer) Debug.LogWarning("blocking enemy for gatekeeping: " + enemyData.enemy.name);
                        ret = orig(self);
                        safe = false;
                        break;
                    }
                }

                if (safe)
                {
                    return ret;
                }
            }

            Debug.LogError("failed progress blocking i think.");

            return ret;
        }

        public static string[] DefaultColors = [Jumble.Red, Jumble.Yellow, Jumble.Blue, Jumble.Purple, Spoggle.Red, Spoggle.Yellow, Spoggle.Blue, Spoggle.Purple];
        public static bool IsDefaultColorInSiren(string enemy, EnemyEncounterSelectorSO self)
        {
            if (!DefaultColors.Contains(enemy))
            {
                if (enemy.ToLower().Contains("spoggle") || enemy.ToLower().Contains("jumble"))
                {
                    if (UnityEngine.Random.Range(0, 100) < 35) return false;
                }
                else return false;
            }

            if (!Siren.Exists) return false;

            if (!LoadedDBsHandler.EnemyDB.m_EnemyEncounterPool.TryGetValue("TheSiren_Zone1", out var value))
            {
                return false;
            }

            if (self == value.m_EasySelector || self == value.m_MediumSelector || self == value.m_HardSelector)
            {
                return UnityEngine.Random.Range(0, 100) < 66;
            }

            return false;
        }
    }

    
}

//test commit
