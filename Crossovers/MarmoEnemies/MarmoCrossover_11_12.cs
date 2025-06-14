﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoCrossover_11_12
    {
        public static void Add()
        {
            //FLAR SORE
            AddTo hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Surimi_EN", "Surimi_EN", Jumble.Red);
            hard.AddRandomGroup("Tripod_EN", "Snaurce_EN", "Snaurce_EN", Jumble.Yellow);
            hard.SimpleAddGroup(1, "Tripod_EN", 3, "Snaurce_EN");
            hard.AddRandomGroup("Tripod_EN", "LittleBeak_EN", "Snaurce_EN");
            hard.AddRandomGroup("Tripod_EN", "Surimi_EN", Jumble.Red, Jumble.Yellow);
            hard.AddRandomGroup("Tripod_EN", "Surimi_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Tripod_EN", "Skyloft_EN", "Snaurce_EN", "Snaurce_EN");
            hard.AddRandomGroup("Tripod_EN", Enemies.Mungling, "Snaurce_EN");
            hard.AddRandomGroup("Tripod_EN", "AFlower_EN", "Surimi_EN");
            hard.AddRandomGroup("Tripod_EN", Jumble.Red, Jumble.Yellow, Jumble.Unstable);
            hard.AddRandomGroup("Tripod_EN", "LittleBeak_EN", Spoggle.Unstable);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "LittleBeak_EN", "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", Enemies.Mungling, "Surimi_EN");
            hard.AddRandomGroup("Warbird_EN", "Skyloft_EN", "Snaurce_EN", "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", "Surimi_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Warbird_EN", Spoggle.Yellow, Spoggle.Blue, "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", Jumble.Red, "Surimi_EN", "Surimi_EN");
            hard.AddRandomGroup("Warbird_EN", Jumble.Red, Jumble.Yellow, Jumble.Unstable);
            hard.AddRandomGroup("Warbird_EN", Spoggle.Yellow, Spoggle.Unstable, "LostSheep_EN");
            hard.AddRandomGroup("Warbird_EN", Spoggle.Blue, Spoggle.Unstable, "LostSheep_EN");
            hard.AddRandomGroup("Warbird_EN", "LittleBeak_EN", Jumble.Unstable);

            AddTo med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Snaurce_EN", "Snaurce_EN");
            med.AddRandomGroup("LittleBeak_EN", "Surimi_EN", Jumble.Yellow);
            med.AddRandomGroup("LittleBeak_EN", "Surimi_EN", Spoggle.Yellow);
            med.AddRandomGroup("LittleBeak_EN", "Snaurce_EN", "Skyloft_EN", "Mung_EN");
            med.AddRandomGroup("LittleBeak_EN", "Surimi_EN", Enemies.Mungling);
            med.AddRandomGroup("LittleBeak_EN", "Surimi_EN", "Surimi_EN");
            med.AddRandomGroup("LittleBeak_EN", Jumble.Unstable, Jumble.Yellow);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("LittleBeak_EN", Spoggle.Unstable, Spoggle.Blue);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("LittleBeak_EN", Spoggle.Unstable, Spoggle.Yellow);

            hard = new AddTo(Shore.H.Angler.Hard);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("AFlower_EN", "LittleBeak_EN", "Snaurce_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("AFlower_EN", "LittleBeak_EN", "Surimi_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "LittleBeak_EN", "Snaurce_EN", "Snaurce_EN");
            hard.AddRandomGroup(Enemies.Camera, "AFlower_EN", "Surimi_EN");

            //ORPHEmUM

            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Romantic_EN", "Enigma_EN");
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Romantic_EN", "Romantic_EN");
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Gungrot_EN", "Gungrot_EN", "Romantic_EN");

            //garben
            hard = new AddTo(Garden.H.SnakeGod.Hard);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("SnakeGod_EN", "Git_EN");
            hard.SimpleAddGroup(1, "SnakeGod_EN", 2, "Attrition_EN");
            if (SaltsReseasoned.trolling < 50) hard.SimpleAddGroup(1, "SnakeGod_EN", 2, "Git_EN");
            if (SaltsReseasoned.silly < 33) hard.SimpleAddGroup(1, "SnakeGod_EN", 1, "Romantic_EN");
            if (SaltsReseasoned.silly > 33 && SaltsReseasoned.silly < 66) hard.SimpleAddGroup(1, "SnakeGod_EN", 2, "Romantic_EN");
            if (SaltsReseasoned.silly > 66) hard.SimpleAddGroup(1, "SnakeGod_EN", 3, "Romantic_EN");
            hard.AddRandomGroup("SnakeGod_EN", "WindSong_EN", "Romantic_EN");
            hard.AddRandomGroup("SnakeGod_EN", "Surrogate_EN");

            AddTo easy = new AddTo(Garden.H.GlassFigurine.Easy);
            easy.SimpleAddGroup(1, "GlassFigurine_EN", 3, "Romantic_EN");

            easy = new AddTo(Garden.H.Attrition.Easy);
            easy.SimpleAddGroup(2, "Attrition_EN", 1, "Damocles_EN");
            easy.SimpleAddGroup(2, "Attrition_EN", 1, "GlassFigurine_EN");

            easy = new AddTo(Garden.H.Git.Easy);
            easy.SimpleAddGroup(2, "Git_EN", 2, "Damocles_EN");
            easy.SimpleAddGroup(2, "Git_EN", 1, "GlassFigurine_EN");

            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(3, "Attrition_EN", 1, "Damocles_EN");
            med.AddRandomGroup("Attrition_EN", "Attrition_EN", "Hunter_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "Git_EN", "GlassFigurine_EN");
            med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(2, "InHisImage_EN", 1, "Git_EN", 1, "Damocles_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.SimpleAddGroup(1, "Hunter_EN", 2, "Attrition_EN", 1, "Damocles_EN");
            med.SimpleAddGroup(1, "Hunter_EN", 2, "Attrition_EN", 1, "Surrogate_EN");
            med.AddRandomGroup("Hunter_EN", "Attrition_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Firebird.Med);
            med.SimpleAddGroup(1, "Firebird_EN", 3, "Git_EN");
            med.SimpleAddGroup(1, "Firebird_EN", 2, "Attrition_EN");
            med.AddRandomGroup("Firebird_EN", "InHisImage_EN", "InHerImage_EN", "Git_EN");
            med.AddRandomGroup("Firebird_EN", "Attrition_EN", "Attrition_EN", "Damocles_EN");
            med.AddRandomGroup("Firebird_EN", "Attrition_EN", "Attrition_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Hunter_EN", "Surrogate_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "Attrition_EN", "Attrition_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Hunter_EN", "Surrogate_EN", "MiniReaper_EN");

            
        }
    }
}
