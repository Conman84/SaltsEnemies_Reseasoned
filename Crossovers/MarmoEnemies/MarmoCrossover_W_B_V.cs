using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoCrossover_W_B_V
    {
        public static void Add_Orph()
        {
            AddTo med = new AddTo(Orph.H.Feckle.Med);
            med.SimpleAddGroup(1, "Feckle_EN", 1, "LostSheep_EN", 3, "Gungrot_EN");
            med.SimpleAddGroup(1, "Feckle_EN", 1, "TortureMeNot_EN", 3, "Gungrot_EN");
            med.SimpleAddGroup(1, "Feckle_EN", 1, "Nameless_EN", 3, "Gungrot_EN");
            med.SimpleAddGroup(1, "Feckle_EN", 1, "Sigil_EN", 3, "Gungrot_EN");
            med.SimpleAddGroup(1, "Feckle_EN", 1, "WindSong_EN", 2, "Gungrot_EN");
            med.SimpleAddGroup(1, "Feckle_EN", 1, Enemies.Solvent, 2, "Gungrot_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Feckle_EN", Spoggle.Yellow);
            med.AddRandomGroup("Something_EN", "Feckle_EN", Spoggle.Unstable);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Feckle_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Feckle_EN", Bots.Blue);

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, "Feckle_EN", Jumble.Unstable);

            AddTo easy = new AddTo(Orph.H.Delusion.Easy);
            easy.AddRandomGroup("Delusion_EN", "Delusion_EN", "Feckle_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Delusion_EN", "Feckle_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Feckle_EN");
            med.AddRandomGroup(Flower.Yellow, "Enigma_EN", "Enigma_EN", "Feckle_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Feckle_EN");
            med.AddRandomGroup(Flower.Purple, "Feckle_EN", "Rabies_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "MusicMan_EN", "MusicMan_EN", "Feckle_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Feckle_EN", Spoggle.Red);

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Feckle_EN", "SingingStone_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Feckle_EN", "Feckle_EN");

            med = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Feckle_EN", Jumble.Purple, Jumble.Red);

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Feckle_EN");

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Yellow, Bots.Red, "Feckle_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, "Feckle_EN", "Surrogate_EN", "Surrogate_EN");

            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Purple, "Feckle_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Feckle_EN", Enemies.Solvent);
            med.AddRandomGroup("Crystal_EN", "Feckle_EN", Enemies.Shooter);

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Feckle_EN", "Romantic_EN", "Romantic_EN");
            hard.AddRandomGroup("TheDragon_EN", "Feckle_EN", Jumble.Unstable, Jumble.Yellow);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Feckle_EN", Enemies.Shooter);
            med.AddRandomGroup("Evileye_EN", "Feckle_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Evileye_EN", "Feckle_EN", Jumble.Unstable, Jumble.Yellow);
            med.AddRandomGroup("Evileye_EN", "Feckle_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup("Evileye_EN", "Feckle_EN", "LostSheep_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Feckle_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("YellowAngel_EN", "Feckle_EN", "Author_EN");
            med.AddRandomGroup("YellowAngel_EN", "Feckle_EN", "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            easy = new AddTo(Orph.H.Shooter.Easy);
            easy.AddRandomGroup(Enemies.Shooter, "Feckle_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, "Feckle_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "Feckle_EN", "MusicMan_EN", "MusicMan_EN");
            med.SimpleAddGroup(1, "Wednesday_EN", 1, "Feckle_EN", 3, "Gungrot_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Solitaire_EN", "Feckle_EN");
            med.AddRandomGroup("Solitaire_EN", "Feckle_EN", Bots.Blue);

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", "Feckle_EN");
            med.AddRandomGroup("Author_EN", "Feckle_EN", "Scrungie_EN");
            med.AddRandomGroup("Author_EN", "Feckle_EN", "WindSong_EN");
        }
        public static void Add_Garden()
        {
            AddTo med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "Bonsai_EN", "Bonsai_EN");

            med = new AddTo(Garden.H.Bonsai.Med);
            med.AddRandomGroup("Bonsai_EN", "Bonsai_EN", Enemies.Camera, Enemies.Camera);
            med.SimpleAddGroup(2, "Bonsai_EN", 1, Flower.Red);
            med.SimpleAddGroup(2, "Bonsai_EN", 1, Flower.Blue);
            med.SimpleAddGroup(2, "Bonsai_EN", 2, "EyePalm_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "Indicator_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 2, "EvilDog_EN");
            med.SimpleAddGroup(1, "Bonsai_EN", 3, "PawnA_EN");
            med.SimpleAddGroup(3, "Bonsai_EN", 1, "PawnA_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "Grandfather_EN");
            med.SimpleAddGroup(3, "Bonsai_EN", 1, "Damocles_EN");

            AddTo easy = new AddTo(Garden.H.Bonsai.Easy);
            easy.AddRandomGroup("Bonsai_EN", "Bonsai_EN", Flower.Yellow);
            easy.AddRandomGroup("Bonsai_EN", "Bonsai_EN", Flower.Purple);
            med.SimpleAddGroup(1, "Bonsai_EN", 2, "PawnA_EN");
            med.SimpleAddGroup(1, "Bonsai_EN", 2, "EyePalm_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "BlackStar_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "GlassFigurine_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "Skyloft_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "Merced_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Bonsai_EN");
            med.AddRandomGroup(Flower.Red, "Bonsai_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, Flower.Red, "Bonsai_EN");
            med.AddRandomGroup(Flower.Blue, "Bonsai_EN", "PawnA_EN", "PawnA_EN");

            AddTo hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Bonsai_EN", "Bonsai_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "Bonsai_EN", "Bonsai_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHerImage_EN", "Bonsai_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHerImage_EN", "Bonsai_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Bonsai_EN", "Bonsai_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Bonsai_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Bonsai_EN", "Attrition_EN");
            med.AddRandomGroup("Firebird_EN", "Bonsai_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Bonsai_EN", "Bonsai_EN");
            med.AddRandomGroup("YNL_EN", "Bonsai_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Bonsai_EN", "Attrition_EN");
            med.AddRandomGroup("Stoplight_EN", "Bonsai_EN", "Damocles_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Bonsai_EN", "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Bonsai_EN", "EvilDog_EN", "EvilDog_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "Bonsai_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Bonsai_EN", "Bonsai_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Bonsai_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Bonsai_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Bonsai_EN", "Bonsai_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Bonsai_EN", "Bonsai_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "PawnA_EN", "Bonsai_EN");
            med.AddRandomGroup("Starless_EN", "Bonsai_EN", "Bonsai_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Bonsai_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Bonsai_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Yang_EN", "Bonsai_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", "Yang_EN", "Bonsai_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Bonsai_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Bonsai_EN", "Shua_EN");
        }
    }
}
