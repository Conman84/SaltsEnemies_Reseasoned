﻿using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SkyloftEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_SkyloftEncounter_Sign", ResourceLoader.LoadSprite("SkyloftPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Skyloft.Easy, "Salt_SkyloftEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SkyloftSong";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("Mordrake_CH").dxSound;

            med.AddRandomEncounter("Skyloft_EN", "Mung_EN", "Mung_EN", "Mung_EN");
            med.AddRandomEncounter("Skyloft_EN", "MudLung_EN");
            med.AddRandomEncounter("Skyloft_EN", Jumble.Red);
            med.AddRandomEncounter("Skyloft_EN", Jumble.Yellow);
            med.AddRandomEncounter("Skyloft_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("Skyloft_EN", Jumble.Yellow, "MudLung_EN");
            med.AddRandomEncounter("Skyloft_EN", Jumble.Red, "MudLung_EN");
            med.AddRandomEncounter("Skyloft_EN", "MudLung_EN", "Mung_EN");
            med.AddRandomEncounter("Skyloft_EN", "MudLung_EN", "MudLung_EN", "Mung_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Skyloft.Easy, 4 * April.Mod, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }

        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.MudLung.Easy);
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup("MudLung_EN", "MudLung_EN", "Skyloft_EN");

            AddTo med = new AddTo(Shore.H.MudLung.Med);
            med.SimpleAddGroup(3, "MudLung_EN", 1, "Skyloft_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "Skyloft_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "Skyloft_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Spoggle.Yellow, "MudLung_EN", "Skyloft_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, "Skyloft_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Spoggle.Blue, "MudLung_EN", "Skyloft_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Spoggle.Blue, Spoggle.Yellow, "Skyloft_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "MudLung_EN", "Skyloft_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("FlaMinGoa_EN", "MudLung_EN", "LostSheep_EN", "Skyloft_EN");

            AddTo hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "MunglingMudLung_EN", Jumble.Yellow, "Skyloft_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "AFlower_EN", "Skyloft_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup("MunglingMudLung_EN", "Skyloft_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("MunglingMudLung_EN", "MudLung_EN", "Mung_EN", "Skyloft_EN");
            med.AddRandomGroup("MunglingMudLung_EN", "MudLung_EN", "LostSheep_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Flarblet_EN", "Skyloft_EN");
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("Flarb_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup("Voboola_EN", "Skyloft_EN");

            easy = new AddTo(Shore.H.DeadPixel.Easy);
            if (SaltsReseasoned.silly > 50) easy.SimpleAddGroup(2, "DeadPixel_EN", 1, "Mung_EN", 1, "Skyloft_EN");

            med = new AddTo(Shore.H.DeadPixel.Med);
            if (SaltsReseasoned.silly < 50) med.SimpleAddGroup(2, "DeadPixel_EN", 1, "MudLung_EN", 1, "Skyloft_EN");

            med = new AddTo(Shore.H.Angler.Med);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("AFlower_EN", Jumble.Yellow, Jumble.Red, "Skyloft_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("AFlower_EN", "MudLung_EN", "MudLung_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("AFlower_EN", Spoggle.Blue, Spoggle.Yellow, "Skyloft_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("AFlower_EN", "MunglingMudLung_EN", "MudLung_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "MunglingMudLung_EN", "MunglingMudLung_EN", "Skyloft_EN");
            hard.AddRandomGroup(Enemies.Camera, "FlaMinGoa_EN", Spoggle.Blue, "Skyloft_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "Skyloft_EN");

            easy = new AddTo(Garden.H.InHerImage.Easy);
            if (SaltsReseasoned.trolling > 50) easy.SimpleAddGroup(2, "InHerImage_EN", 1, "NextOfKin_EN", 1, "Skyloft_EN");

            easy = new AddTo(Garden.H.InHisImage.Easy);
            if (SaltsReseasoned.trolling < 50) easy.SimpleAddGroup(2, "InHisImage_EN", 1, "NextOfKin_EN", 1, "Skyloft_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup("ChoirBoy_EN", "ChoirBoy_EN", "Skyloft_EN");
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup("ChoirBoy_EN", "Skyloft_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Enemies.Skinning, Jumble.Grey, "Skyloft_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, "Skyloft_EN");

            easy = new AddTo(Garden.H.Minister.Easy);
            if (SaltsReseasoned.silly > 50) easy.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Skyloft_EN");

            med = new AddTo(Garden.H.Minister.Med);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Enemies.Minister, Enemies.Minister, Enemies.Shivering, "Skyloft_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Jumble.Grey, Enemies.Shivering, Enemies.Shivering, "Skyloft_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHisImage_EN", "Skyloft_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", "Skyloft_EN");

            med = new AddTo(Garden.H.Camera.Med);
            if (SaltsReseasoned.trolling < 50) med.SimpleAddGroup(4, Enemies.Camera, 1, "Skyloft_EN");

            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Flower.Blue, Flower.Red, "Skyloft_EN");
            easy = new AddTo(Garden.H.Flower.Red.Easy);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Flower.Red, Flower.Blue, "Skyloft_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.SimpleAddGroup(1, "Grandfather_EN", 3, "EyePalm_EN", 1, "Skyloft_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "EyePalm_EN", "EyePalm_EN", "Skyloft_EN");

            easy = new AddTo(Garden.H.EyePalm.Easy);
            if (SaltsReseasoned.trolling > 50) easy.SimpleAddGroup(3, "EyePalm_EN", 1, "Skyloft_EN");
            if (SaltsReseasoned.trolling < 50) easy.SimpleAddGroup(2, "EyePalm_EN", 1, "Skyloft_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("ClockTower_EN", "ChoirBoy_EN", Enemies.Minister, "Skyloft_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup(Enemies.Tank, "WindSong_EN", "Skyloft_EN");
        }
    }
}
