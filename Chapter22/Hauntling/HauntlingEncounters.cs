using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HauntlingEncounters
    {
        public static void Add()
        {
            Add_Shore();
            Add_Garden();
        }
        public static void Add_Shore()
        {
            Portals.AddPortalSign("Salt_HauntlingEncounter_Sign", ResourceLoader.LoadSprite("HauntlingWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Hauntling.Med, "Salt_HauntlingEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/HauntlingSong";
            med.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            med.SimpleAddEncounter(2, "Hauntling_EN", 1, "MudLung_EN");
            med.SimpleAddEncounter(2, "Hauntling_EN", 1, Jumble.Red);
            med.SimpleAddEncounter(2, "Hauntling_EN", 1, Enemies.Mungling);
            med.SimpleAddEncounter(2, "Hauntling_EN", 1, "ToyUfo_EN");
            med.SimpleAddEncounter(2, "Hauntling_EN", 2, "Wall_EN");
            med.SimpleAddEncounter(2, "Hauntling_EN", 2, "Waltz_EN");
            med.SimpleAddEncounter(2, "Hauntling_EN", 1, "Pinano_EN");
            med.SimpleAddEncounter(2, "Hauntling_EN", 2, "Keko_EN");
            med.SimpleAddEncounter(2, "Hauntling_EN", 1, "VoiceTrumpet_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Hauntling.Med, 1 * April.MoreMod, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Garden()
        {
            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Hauntling.Easy, "Salt_HauntlingEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/HauntlingSong";
            easy.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            easy.SimpleAddEncounter(5, "Hauntling_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Hauntling.Easy, April.Birthday ? 15 : 0, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Shore.H.Pinano.Med);
            med.SimpleAddGroup(2, "Pinano_EN", 1, "Hauntling_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "Hauntling_EN");
            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "Hauntling_EN");
            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, "Hauntling_EN", "MudLung_EN");
            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, "Hauntling_EN", "MudLung_EN");

            med = new AddTo(Shore.H.DeadPixel.Med);
            med.SimpleAddGroup(2, "DeadPixel_EN", 1, "Hauntling_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", Jumble.Yellow, "Hauntling_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "Hauntling_EN", Spoggle.Yellow);

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.SimpleAddGroup(1, "LittleBeak_EN", 2, "Hauntling_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.SimpleAddGroup(1, "Chiito_EN", 2, "Hauntling_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.SimpleAddGroup(1, "AFlower_EN", 2, "Hauntling_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.SimpleAddGroup(1, "Sinker_EN", 2, "Hauntling_EN");

            med = new AddTo(Shore.H.Surimi.Med);
            med.SimpleAddGroup(1, "Surimi_EN", 2, "Hauntling_EN");

            med = new AddTo(Shore.H.Flakkid.Med);
            med.AddRandomGroup("Flakkid_EN", Jumble.Unstable, "Hauntling_EN");

            med = new AddTo(Shore.H.Swine.Med);
            med.AddRandomGroup(Enemies.Swine, Enemies.Swine, "Hauntling_EN");

            med = new AddTo(Shore.H.Pipe.Med);
            med.AddRandomGroup("NotAn_EN", "Hauntling_EN", "Wall_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "Hauntling_EN", "Hauntling_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "MudLung_EN", "Hauntling_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Hauntling_EN", Spoggle.Yellow);

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "Hauntling_EN", Spoggle.Unstable);

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Hauntling_EN", Enemies.Mungling);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Hauntling_EN", "Hauntling_EN", Jumble.Red);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Hauntling_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Hauntling_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Hauntling_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "Hauntling_EN", "FlaMinGoa_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.SimpleAddGroup(1, "33_EN", 3, "Hauntling_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Hauntling_EN", Jumble.Unstable);

            med = new AddTo(Shore.H.Bait.Med);
            med.AddRandomGroup("DryBait_EN", "Hauntling_EN", Jumble.Red);

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "Hauntling_EN");

            med = new AddTo(Shore.H.Digger.Med);
            med.AddRandomGroup("Digger_EN", "Hauntling_EN", Jumble.Yellow);

            hard = new AddTo(Shore.H.Wailer.Hard);
            hard.AddRandomGroup("Wailer_EN", "Hauntling_EN", "VoiceTrumpet_EN");

            //GARDEN
            AddTo easy = new AddTo(Garden.H.BlackStar.Easy);
            easy.SimpleAddGroup(1, "BlackStar_EN", 2, "Hauntling_EN");

            easy = new AddTo(Garden.H.Pawn.Easy);
            easy.SimpleAddGroup(2, "PawnA_EN", 2, "Hauntling_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.SimpleAddGroup(1, "Grandfather_EN", 3, "Hauntling_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.SimpleAddGroup(2, "InHerImage_EN", 1, "InHerImage_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(3, "InHisImage_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, "PawnA_EN", "PawnA_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, "EyePalm_EN", "EyePalm_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.SimpleAddGroup(1, "Satyr_EN", 3, "Hauntling_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, "Hauntling_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "EyePalm_EN", "EyePalm_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.SimpleAddGroup(1, "Starless_EN", 2, Enemies.Shivering, 1, "Hauntling_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, "PawnA_EN", "PawnA_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.SimpleAddGroup(1, Spoggle.Gray, 2, "PawnA_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Gray, "EyePalm_EN", "EyePalm_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Hauntling_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.SimpleAddGroup(1, "Firebird_EN", 2, "InHerImage_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.SimpleAddGroup(1, "OdeToHumanity_EN", 3, "Hauntling_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Hauntling_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.SimpleAddGroup(1, "YNL_EN", 2, "InHisImage_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "PawnA_EN", "PawnA_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(2, "Yang_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Attrition_EN", "Hauntling_EN");
            med.AddRandomGroup("Stoplight_EN", "Bonsai_EN", "Hauntling_EN");
            med.SimpleAddGroup(1, "Stoplight_EN", 2, "PawnA_EN", 1, "Hauntling_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Hauntling_EN", "Hauntling_EN", "Hauntling_EN", "Hauntling_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.SimpleAddGroup(1, Enemies.Tank, 2, "Hauntling_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.SimpleAddGroup(1, "SnakeGod_EN", 2, "Hauntling_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.SimpleAddGroup(2, "Yin_EN", 1, "Hauntling_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Hauntling_EN", "Hauntling_EN");

            easy = new AddTo(Garden.H.Git.Easy);
            easy.SimpleAddGroup(2, "Git_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(2, "Attrition_EN", 2, "Hauntling_EN");

            med = new AddTo(Garden.H.Nosestone.Red.Med);
            med.AddRandomGroup(Noses.Red, "PawnA_EN", "PawnA_EN", "Hauntling_EN");

            med = new AddTo(Garden.H.Nosestone.Blue.Med);
            med.SimpleAddGroup(1, Noses.Blue, 2, "EyePalm_EN", 1, "Hauntling_EN");

            med = new AddTo(Garden.H.Nosestone.Yellow.Hard);
            hard.AddRandomGroup(Noses.Yellow, Noses.Red, "Hauntling_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "Hauntling_EN", "Shua_EN");

            med = new AddTo(Garden.H.Bonsai.Med);
            med.AddRandomGroup("Bonsai_EN", "Indicator_EN", "Hauntling_EN", "Hauntling_EN");
        }
    }
}
