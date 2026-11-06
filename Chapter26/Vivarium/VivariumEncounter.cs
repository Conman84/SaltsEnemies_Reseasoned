using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class VivariumEncounters
    {
        //make a thing for..? ? music... hmm.
        public static void Add()
        {
            Portals.AddPortalSign("Salt_VivariumEncounter_Sign", ResourceLoader.LoadSprite("VivariumWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Vivarium.Easy, "Salt_VivariumEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/VivariumTheme";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemy(Spoggle.Red).deathSound;

            easy.SimpleAddEncounter(3, "Vivarium_EN");
            easy.SimpleAddEncounter(4, "Vivarium_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Vivarium.Easy, April.LessMod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }

        public static void Post()
        {
            AddTo easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.SimpleAddGroup(2, "InHerImage_EN", 1, "Vivarium_EN");

            easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.SimpleAddGroup(2, "InHisImage_EN", 1, "Vivarium_EN");

            AddTo med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHisImage_EN", "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(3, "InHisImage_EN", 2, "Vivarium_EN");

            easy = new AddTo(Garden.H.Minister.Easy);
            easy.SimpleAddGroup(2, Enemies.Minister, 1, "Vivarium_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "EvilDog_EN", "EvilDog_EN", "Vivarium_EN");

            AddTo hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", "InHerImage_EN", "Vivarium_EN");
            hard.AddRandomGroup(Enemies.Minister, "ChoirBoy_EN", "ChoirBoy_EN", "Vivarium_EN");
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, Enemies.Foundling, "Vivarium_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, Enemies.Shivering, "Vivarium_EN");
            med.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Vivarium_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");
            hard.AddRandomGroup(Enemies.Skinning, "InHerImage_EN", "InHerImage_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Foundling.Med);
            med.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, "Vivarium_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.SimpleAddGroup(3, Enemies.Foundling, 2, "Vivarium_EN");
            hard.AddRandomGroup(Enemies.Foundling, "PawnA_EN", "PawnA_EN", "PawnA_EN", "Vivarium_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "Vivarium_EN", "NextOfKin_EN", "NextOfKin_EN");

            med = new AddTo(Garden.H.EggKeeper.Med);
            med.AddRandomGroup("ChoirBoy_EN", "EggKeeper_EN", "Vivarium_EN", "ChoirBoy_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "InHerImage_EN", "InHerImage_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Foundling, "Bonsai_EN", "Bonsai_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Gray, "Vivarium_EN", Jumble.Mythos, "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "Vivarium_EN", "InHerImage_EN", "InHerImage_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Camera.Med);
            med.SimpleAddGroup(4, Enemies.Camera, 1, "Vivarium_EN");

            easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.SimpleAddGroup(1, Flower.Red, 3, "NextOfKin_EN", 1, "Vivarium_EN");
            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.SimpleAddGroup(1, Flower.Blue, 3, "NextOfKin_EN", 1, "Vivarium_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");
            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "InHisImage_EN", "InHisImage_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Blue, "Vivarium_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 4, "Vivarium_EN");
            hard.AddRandomGroup("ClockTower_EN", "Vivarium_EN", Enemies.Shambler, "Vivarium_EN");

            easy = new AddTo(Garden.H.WindSong.Easy);
            easy.SimpleAddGroup(1, "WindSong_EN", 3, "NextOfKin_EN", 1, "Vivarium_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "Vivarium_EN", "PawnA_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Vivarium_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "Vivarium_EN");

            easy = new AddTo(Garden.H.EyePalm.Med);
            easy.AddRandomGroup("EyePalm_EN", "EyePalm_EN", "Vivarium_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(4, "EyePalm_EN", 1, "Vivarium_EN");

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", "EggKeeper_EN", "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "EyePalm_EN", "EyePalm_EN", "Vivarium_EN");

            easy = new AddTo(Garden.H.Damocles.Easy);
            easy.SimpleAddGroup(4, "Damocles_EN", 1, "Vivarium_EN");

            easy = new AddTo(Garden.H.GlassFigurine.Easy);
            easy.AddRandomGroup("GlassFigurine_EN", Enemies.Shivering, Enemies.Shivering, "Vivarium_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Vivarium_EN", "Yang_EN", "Yang_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Shua_EN", "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");
            med.AddRandomGroup("Firebird_EN", "Children6_EN", "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");

            easy = new AddTo(Garden.H.BlackStar.Easy);
            easy.SimpleAddGroup(1, "BlackStar_EN", 4, "Vivarium_EN");

            easy = new AddTo(Garden.H.Indicator.Easy);
            easy.AddRandomGroup("Indicator_EN", Enemies.Shivering, Enemies.Shivering, "Vivarium_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Bonsai_EN", "Bonsai_EN", "Vivarium_EN");
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHisImage_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "ChoirBoy_EN", "Vivarium_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "Yang_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Vivarium_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomGroup(Bots.Grey, Enemies.Prior, Enemies.Prior, "Vivarium_EN");
            med.AddRandomGroup(Bots.Grey, "PawnA_EN", "PawnA_EN", "Vivarium_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 2, "Vivarium_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Attrition_EN", "Attrition_EN", "Vivarium_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Spoggle.Mythos, Spoggle.Mythos, "Vivarium_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(4, "EvilDog_EN", 1, "Vivarium_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Vivarium_EN", Jumble.Mythos);

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Vivarium_EN", "Vivarium_EN", "NooneSister_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Bonsai_EN", "Bonsai_EN", "Vivarium_EN");
            med.AddRandomGroup("Starless_EN", Enemies.Minister, "Vivarium_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "InHerImage_EN", "InHerImage_EN", "Vivarium_EN", "Vivarium_EN");

            easy = new AddTo(Garden.H.Pawn.Easy);
            easy.SimpleAddGroup(3, "PawnA_EN", 1, "Vivarium_EN");

            med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(4, "PawnA_EN", 1, "Vivarium_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(2, "Yang_EN", 1, "EggKeeper_EN", 1, "Vivarium_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, "Vivarium_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "PawnA_EN", "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Vivarium_EN", Noses.Red, "Vivarium_EN");
            med.AddRandomGroup("CorpseChan_EN", "Vivarium_EN", "Ascendant_EN", "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.SimpleAddGroup(1, "InTheDark_EN", 4, "Vivarium_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Vivarium_EN", Bots.Grey);
            med.AddRandomGroup("Lunoscope_EN", "Vivarium_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", "Vivarium_EN", "SomeoneSister_EN", "SomeoneSister_EN");

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 2, "Vivarium_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(3, Ecstasy.Gray, 2, "Vivarium_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, "Vivarium_EN", "Git_EN", "Git_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 2, "Vivarium_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 2, "Vivarium_EN");
            med.AddRandomGroup("Celebration_EN", "InHisImage_EN", "InHisImage_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.AddRandomGroup("Celebration_EN", "Celebration_EN", "Ascendant_EN", "Vivarium_EN");

            easy = new AddTo(Garden.H.Lightbulbkin.Easy);
            easy.AddRandomGroup("Lightbulbkin_EN", "NextOfKin_EN", "NextOfKin_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "InHerImage_EN", "InHerImage_EN", "Vivarium_EN");
            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup(Ecstasy.Gray, "InHisImage_EN", "InHisImage_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "Lightbulbkin_EN", "Surrogate_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Sisters.Med);
            med.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, "Vivarium_EN");

            hard = new AddTo(Garden.H.Sisters.Hard);
            hard.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, Ecstasy.Gray, "Vivarium_EN");

            med = new AddTo(Garden.H.Vessel.Med);
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Vessel.Hard);
            hard.SimpleAddGroup(2, Enemies.Vessel, 1, Enemies.Spirit, 1, "Vivarium_EN");

            med = new AddTo(Garden.H.Logos.Red.Med);
            med.AddRandomGroup(Logos.Red, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");
            med = new AddTo(Garden.H.Logos.Blue.Med);
            med.AddRandomGroup(Logos.Blue, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");
            med = new AddTo(Garden.H.Logos.Yellow.Med);
            med.AddRandomGroup(Logos.Yellow, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");
            med = new AddTo(Garden.H.Logos.Purple.Med);
            med.AddRandomGroup(Logos.Purple, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Logos.Red.Hard);
            hard.AddRandomGroup(Logos.Red, Enemies.Minister, "Vivarium_EN", "Vivarium_EN");
            hard = new AddTo(Garden.H.Logos.Blue.Hard);
            hard.AddRandomGroup(Logos.Blue, Enemies.Minister, "Vivarium_EN", "Vivarium_EN");
            hard = new AddTo(Garden.H.Logos.Yellow.Hard);
            hard.AddRandomGroup(Logos.Yellow, Enemies.Minister, "Vivarium_EN", "Vivarium_EN");
            hard = new AddTo(Garden.H.Logos.Purple.Hard);
            hard.AddRandomGroup(Logos.Purple, Enemies.Minister, "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Phobia.Med);
            med.SimpleAddGroup(2, Enemies.Phobia, 1, "Vivarium_EN");

            hard = new AddTo(Garden.H.Phobia.Hard);
            hard.AddRandomGroup(Enemies.Phobia, Ecstasy.Gray, Ecstasy.Gray, "Vivarium_EN");
            hard.AddRandomGroup(Enemies.Phobia, "Bonsai_EN", "Bonsai_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Portrait.Hard);
            hard.AddRandomGroup(Enemies.Portrait, "Vivarium_EN", "Vivarium_EN", "Grandfather_EN");
            hard.AddRandomGroup(Enemies.Portrait, "Yang_EN", "PawnA_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Nosestone.Red.Med);
            med.AddRandomGroup(Noses.Red, "Vivarium_EN", "EvilDog_EN", "EvilDog_EN");
            med = new AddTo(Garden.H.Nosestone.Blue.Med);
            med.AddRandomGroup(Noses.Blue, "EyePalm_EN", "EyePalm_EN", "Vivarium_EN");
            med = new AddTo(Garden.H.Nosestone.Yellow.Med);
            med.AddRandomGroup(Noses.Yellow, "PawnA_EN", "PawnA_EN", "Vivarium_EN");
            med = new AddTo(Garden.H.Nosestone.Purple.Med);
            med.AddRandomGroup(Noses.Purple, "Ascendant_EN", "Vivarium_EN", "Vivarium_EN");
            med = new AddTo(Garden.H.Nosestone.Grey.Med);
            med.AddRandomGroup(Noses.Gray, "PawnA_EN", "PawnA_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Nosestone.Red.Hard);
            hard.AddRandomGroup(Noses.Red, Ecstasy.Gray, Ecstasy.Gray, "Vivarium_EN");
            hard = new AddTo(Garden.H.Nosestone.Blue.Hard);
            hard.AddRandomGroup(Noses.Blue, Noses.Red, "Vivarium_EN", "ChoirBoy_EN");
            hard = new AddTo(Garden.H.Nosestone.Yellow.Hard);
            hard.AddRandomGroup(Noses.Yellow, Noses.Red, "Vivarium_EN", Ecstasy.Gray);
            hard = new AddTo(Garden.H.Nosestone.Purple.Hard);
            hard.AddRandomGroup(Noses.Purple, Noses.Red, "Vivarium_EN", "Vivarium_EN", "Bonsai_EN");
            hard = new AddTo(Garden.H.Nosestone.Grey.Hard);
            hard.AddRandomGroup(Noses.Grey, Noses.Red, "Vivarium_EN", "SomeoneSister_EN");

            easy = new AddTo(Garden.H.Git.Easy);
            easy.AddRandomGroup("Git_EN", "Git_EN", Enemies.Shivering, "Vivarium_EN");

            med = new AddTo(Garden.H.Git.Med);
            med.SimpleAddGroup(3, "Git_EN", 2, "Vivarium_EN");

            easy = new AddTo(Garden.H.Attrition.Easy);
            easy.SimpleAddGroup(2, "Attrition_EN", 3, "Vivarium_EN");

            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(3, "Attrition_EN", 2, "Vivarium_EN");

            easy = new AddTo(Garden.H.Bonsai.Easy);
            easy.SimpleAddGroup(2, "Bonsai_EN", 3, "Vivarium_EN");

            med = new AddTo(Garden.H.Bonsai.Med);
            med.SimpleAddGroup(3, "Bonsai_EN", 2, "Vivarium_EN");

            med = new AddTo(Garden.H.Polyp.Med);
            med.AddRandomGroup(Enemies.Polyp, "InHerImage_EN", "InHerImage_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Shambler.Med);
            med.AddRandomGroup(Enemies.Shambler, Ecstasy.Gray, "Vivarium_EN");

            hard = new AddTo(Garden.H.Shambler.Hard);
            hard.AddRandomGroup(Enemies.Shambler, Enemies.MainSister, "Vivarium_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Starless_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "EvilDog_EN", "EvilDog_EN", "Vivarium_EN");
        }
    }
}
