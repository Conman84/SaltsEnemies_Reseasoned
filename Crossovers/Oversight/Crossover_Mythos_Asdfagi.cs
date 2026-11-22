using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

//SandSifter (16 grey)
//Asterism (14 split red purp)

//Byakhee (30 red)
//StarVampire (25 colors)
//Bloatfinger (30 red)
//Lloigor_EN (grey withering)

//Polyp (35 red)

namespace SaltsEnemies_Reseasoned
{
    public static class Crossover_Mythos_Asdfagi
    {
        public static void Add()
        {
            Add_Shore();
            Add_Orph();
            Add_Garden();
        }
        public static void Add_Shore()
        {
            AddTo med = new AddTo(Shore.H.Asterism.Med);
            med.SimpleAddGroup(1, "Asterism_EN", 2, "DeadPixel_EN");
            med.SimpleAddGroup(2, "Asterism_EN", 1, "LostSheep_EN");
            med.SimpleAddGroup(2, "Asterism_EN", 1, "Skyloft_EN");
            med.SimpleAddGroup(1, "Asterism_EN", 1, "MudLung_EN", 3, "TortureMeNot_EN");
            med.SimpleAddGroup(1, "Asterism_EN", 2, "Waltz_EN");
            med.SimpleAddGroup(1, "Asterism_EN", 1, "Hauntling_EN", 1, Jumble.Red);
            med.SimpleAddGroup(1, "Asterism_EN", 1, "ToyUfo_EN", 1, "NobodyGrave_EN");
            med.AddRandomGroup("Asterism_EN", "VoiceTrumpet_EN", "2009_EN");

            EcstasyPool.Add("Asterism_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Asterism_EN", "Windle_EN");
            med.AddRandomGroup("AFlower_EN", "SandSifter_EN", "Pinano_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Asterism_EN", "Skyloft_EN");
            med.AddRandomGroup("LittleBeak_EN", "SandSifter_EN", "Arceles_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Asterism_EN", "LostSheep_EN");
            med.AddRandomGroup("Clione_EN", "SandSifter_EN", Jumble.Red);

            EcstasyPool.Add("SandSifter_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "SandSifter_EN", Spoggle.Blue);

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Asterism_EN", "LostSheep_EN");
            med.AddRandomGroup("Sinker_EN", "SandSifter_EN", Jumble.Unstable);

            med = new AddTo(Shore.H.Chiito.Med);
            med.AddRandomGroup("Chiito_EN", "Asterism_EN", "Pinano_EN");
            med.AddRandomGroup("Chiito_EN", "SandSifter_EN", "DeadPixel_EN", "DeadPixel_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.AddRandomGroup("Jabberwocky_EN", "SandSifter_EN", "Pinano_EN");
            med.AddRandomGroup("Jabberwocky_EN", "Asterism_EN", "LostSheep_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Asterism_EN", Spoggle.Yellow);
            hard.AddRandomGroup("AFlower_EN", "SandSifter_EN", "DeadPixel_EN", "DeadPixel_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "Asterism_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup(Enemies.Camera, "SandSifter_EN", "SandSifter_EN", "2009_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Asterism_EN", "Chiito_EN");
            hard.AddRandomGroup("Tripod_EN", "SandSifter_EN", "LittleBeak_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Asterism_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("Warbird_EN", "SandSifter_EN", "Pinano_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Asterism_EN", "ToyUfo_EN");
            hard.AddRandomGroup("Clione_EN", "SandSifter_EN", Jumble.Yellow, Jumble.Red);

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "Asterism_EN", "2009_EN");
            hard.AddRandomGroup("Sinker_EN", "SandSifter_EN", "DeadPixel_EN", "DeadPixel_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.SimpleAddGroup(2, "Asterism_EN", 1, "33_EN");
            hard.AddRandomGroup("33_EN", "SandSifter_EN", "Clione_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Asterism_EN");
            hard.AddRandomGroup("Clown_EN", "SandSifter_EN", "Waltz_EN");
        }
        public static void Add_Orph()
        {
            AddTo med = new AddTo(Orph.H.Bloatfinger.Med);
            med.AddRandomGroup("Bloatfinger_EN", "Bloatfinger_EN", "LostSheep_EN");
            med.SimpleAddGroup(1, "Bloatfinger_EN", 3, "Enigma_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Bloatfinger_EN", "Something_EN", Jumble.Unstable);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Bloatfinger_EN", "Something_EN", Spoggle.Unstable);
            med.SimpleAddGroup(1, "Bloatfinger_EN", 2, "Delusion_EN", 1, "FakeAngel_EN");
            med.AddRandomGroup("Bloatfinger_EN", Flower.Yellow, Flower.Purple);
            med.AddRandomGroup("Bloatfinger_EN", "Rabies_EN", Jumble.Yellow, "Sigil_EN");
            med.AddRandomGroup("Bloatfinger_EN", Enemies.Solvent, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Bloatfinger_EN", "WindSong_EN", "Scrungie_EN");
            if (SaltsReseasoned.rando <= 15) med.SimpleAddGroup(1, "Bloatfinger_EN", 3, "Spectre_EN");
            med.AddRandomGroup("Bloatfinger_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Bloatfinger_EN", Bots.Blue, Bots.Purple);
            med.AddRandomGroup("Bloatfinger_EN", Enemies.Shooter, "Nameless_EN");
            med.AddRandomGroup("Bloatfinger_EN", "Solitaire_EN", "Solitaire_EN", "Nameless_EN");
            med.SimpleAddGroup(1, "Bloatfinger_EN", 2, "Foxtrot_EN", 1, "Wednesday_EN");
            med.AddRandomGroup("Bloatfinger_EN", "Author_EN", Jumble.Blue);

            EcstasyPool.Add("Bloatfinger_EN");

            med = new AddTo(Orph.H.Byakhee.Med);
            med.SimpleAddGroup(1, "Byakhee_EN", 3, "Spectre_EN");
            med.SimpleAddGroup(1, "Byakhee_EN", 3, "Enigma_EN");
            med.AddRandomGroup("Byakhee_EN", "Freud_EN", Jumble.Purple);
            med.AddRandomGroup("Byakhee_EN", "WindSong_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Byakhee_EN", Flower.Yellow, Flower.Purple);
            med.AddRandomGroup("Byakhee_EN", Bots.Red, Bots.Yellow, "LostSheep_EN");
            med.AddRandomGroup("Byakhee_EN", Bots.Blue, Bots.Purple);
            med.AddRandomGroup("Byakhee_EN", "Scrungie_EN", "Scrungie_EN", "Sigil_EN");
            med.AddRandomGroup("Byakhee_EN", Enemies.Solvent, Spoggle.Red);
            med.AddRandomGroup("Byakhee_EN", "Rabies_EN", Bots.Red);
            med.AddRandomGroup("Byakhee_EN", Spoggle.Red, Spoggle.Purple, "Nameless_EN");
            if (Winter.Chance) med.AddRandomGroup("Byakhee_EN", "Crystal_EN", "Lloigor_EN");
            med.AddRandomGroup("Byakhee_EN", "MusicMan_EN", "MusicMan_EN", "Wednesday_EN");
            med.AddRandomGroup("Byakhee_EN", Enemies.Shooter, "Wednesday_EN");
            med.AddRandomGroup("Byakhee_EN", "Solitaire_EN", "Scrungie_EN", "Lloigor_EN");
            med.AddRandomGroup("Byakhee_EN", "Author_EN", "WindSong_EN");
            med.SimpleAddGroup(1, "Byakhee_EN", 3, "Foxtrot_EN");
            med.SimpleAddGroup(1, "Byakhee_EN", 2, "Insider_EN");

            EcstasyPool.Add("Byakhee_EN");

            med = new AddTo(Orph.H.Vampire.Med);
            med.SimpleAddGroup(2, "StarVampire_EN", 2, "Enigma_EN");
            med.AddRandomGroup("StarVampire_EN", Enemies.Camera, "MusicMan_EN", "MusicMan_EN");
            med.SimpleAddGroup(1, "StarVampire_EN", 2, "Delusion_EN", 1, "FakeAngel_EN");
            med.AddRandomGroup("StarVampire_EN", "Scrungie_EN", Flower.Purple);
            med.AddRandomGroup("StarVampire_EN", "Scrungie_EN", Flower.Yellow);
            med.AddRandomGroup("StarVampire_EN", Enemies.Solvent, "Delusion_EN", "Delusion_EN");
            med.AddRandomGroup("StarVampire_EN", "WindSong_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("StarVampire_EN", "Nameless_EN",Bots.Red, Bots.Yellow);
            med.AddRandomGroup("StarVampire_EN", Bots.Blue, "Solitaire_EN");
            med.AddRandomGroup("StarVampire_EN", Bots.Purple, Enemies.Shooter);
            med.SimpleAddGroup(1, "StarVampire_EN", 1, "Author_EN", 3, "TortureMeNot_EN");
            med.AddRandomGroup("StarVampire_EN", "Foxtrot_EN", Jumble.Purple, Enemies.Camera);

            EcstasyPool.Add("StarVampire_EN");

            AddTo easy = new AddTo(Orph.H.Enigma.Easy);
            easy.SimpleAddGroup(2, "Enigma_EN", 1, "Lloigor_EN");

            med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, "Lloigor_EN");

            med = new AddTo(Orph.H.Something.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Bloatfinger_EN", "Something_EN", Jumble.Unstable);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Bloatfinger_EN", "Something_EN", Spoggle.Unstable);
            med.AddRandomGroup("Something_EN", "StarVampire_EN", "StarVampire_EN");
            med.AddRandomGroup("Something_EN", "StarVampire_EN", "Sigil_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Bloatfinger_EN", Enemies.Solvent);
            med.AddRandomGroup("TheCrow_EN", "Byakhee_EN", Spoggle.Red);
            med.AddRandomGroup("TheCrow_EN", "StarVampire_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Bloatfinger_EN", Jumble.Blue);
            med.AddRandomGroup("Freud_EN", "Byakhee_EN", Flower.Purple);
            med.AddRandomGroup("Freud_EN", "StarVampire_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, "StarVampire_EN", "Scrungie_EN");
            med.SimpleAddGroup(2, Enemies.Camera, 1, "Bloatfinger_EN", 1, "Romantic_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.SimpleAddGroup(2, "Delusion_EN", 1, "StarVampire_EN", 1, "FakeAngel_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, "StarVampire_EN", "MusicMan_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, "StarVampire_EN", "MusicMan_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "StarVampire_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "StarVampire_EN", Enemies.Shooter);

            easy = new AddTo(Orph.H.Solvent.Easy);
            easy.AddRandomGroup(Enemies.Solvent, "Lloigor_EN", Jumble.Red);

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "StarVampire_EN", Enemies.Solvent);
            hard.AddRandomGroup("StalwartTortoise_EN", "Byakhee_EN", "Enigma_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", "SingingStone_EN", "Lloigor_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", "Bloatfinger_EN", "Wednesday_EN");

            med = new AddTo(Orph.H.Butterfly.Med);
            if (SaltsReseasoned.rando <= 5) med.SimpleAddGroup(3, "Spectre_EN", 1, "Lloigor_EN");

            med = new AddTo(Orph.H.Nameless.Med);
            med.AddRandomGroup("Nameless_EN", "Lloigor_EN", Enemies.Solvent);
            med.AddRandomGroup("Nameless_EN", "StarVampire_EN", "Rabies_EN");

            EcstasyPool.Add("Lloigor_EN");

            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Lloigor_EN");
            med.SimpleAddGroup(2, "Rabies_EN", 1, "StarVampire_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.SimpleAddGroup(2, "StarVampire_EN", 1, "Maw_EN");
            med.AddRandomGroup("Maw_EN", "Bloatfinger_EN", "WindSong_EN");
            med.AddRandomGroup("Maw_EN", "Solitaire_EN", "Solitaire_EN", "Lloigor_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "StarVampire_EN", "Solitaire_EN", "Solitaire_EN");
            hard.AddRandomGroup("Maw_EN", "Byakhee_EN", "Byakhee_EN", "Lloigor_EN");
            hard.AddRandomGroup("Maw_EN", "Bloatfinger_EN", "Freud_EN");

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "StarVampire_EN");
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Lloigor_EN");

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "StarVampire_EN");
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Lloigor_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Bloatfinger_EN", "Enigma_EN");
            med.AddRandomGroup("Crystal_EN", "Byakhee_EN", "Lloigor_EN");
            med.AddRandomGroup("Crystal_EN", "Scrungie_EN", "StarVampire_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.SimpleAddGroup(1, "TheDragon_EN", 2, "StarVampire_EN");
            hard.AddRandomGroup("TheDragon_EN", "Bloatfinger_EN", Bots.Blue);
            hard.AddRandomGroup("TheDragon_EN", "Byakhee_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "StarVampire_EN", "StarVampire_EN");
            med.AddRandomGroup("Evileye_EN", "StarVampire_EN", Enemies.Shooter);
            med.AddRandomGroup("Evileye_EN", "Byakhee_EN", Spoggle.Red);
            med.AddRandomGroup("Evileye_EN", "Bloatfinger_EN", "Bloatfinger_EN");

            easy = new AddTo(Orph.H.Shooter.Easy);
            easy.AddRandomGroup("Lloigor_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Shooter.Med);
            med.SimpleAddGroup(2, Enemies.Shooter, 1, "Lloigor_EN");
            med.SimpleAddGroup(2, Enemies.Shooter, 1, "StarVampire_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", "StarVampire_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, "StarVampire_EN");
            med.SimpleAddGroup(2, "Solitaire_EN", 1, "Lloigor_EN", 1, Jumble.Unstable);

            easy = new AddTo(Orph.H.Foxtrot.Easy);
            easy.SimpleAddGroup(3, "Foxtrot_EN", 1, "Lloigor_EN");

            med = new AddTo(Orph.H.Author.Med);
            med.SimpleAddGroup(2, "Author_EN", 1, "Lloigor_EN");
            med.AddRandomGroup("Author_EN", "Author_EN", "StarVampire_EN", Jumble.Yellow);
            med.AddRandomGroup("Author_EN", "Byakhee_EN", "Romantic_EN", "Romantic_EN");
            med.AddRandomGroup("Author_EN", "Bloatfinger_EN", "Author_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Insider.Med);
            med.SimpleAddGroup(2, "Insider_EN", 1, "StarVampire_EN", 1, "SingingStone_EN");
            med.SimpleAddGroup(2, "Insider_EN", 1, "Byakhee_EN");
            med.SimpleAddGroup(2, "Insider_EN", 1, "Bloatfinger_EN");

            EcstasyPool.Add("LemurianConstruct_EN");
        }
        public static void Add_Garden()
        {
            AddTo med = new AddTo(Garden.H.Polyp.Med);
            med.AddRandomGroup(Enemies.Polyp, Spoggle.Grey, "InHisImage_EN", "InHisImage_EN");
            med.SimpleAddGroup(1, Enemies.Polyp, 1, Jumble.Grey, 2, "PawnA_EN");
            med.AddRandomGroup(Enemies.Polyp, "Bonsai_EN", "Bonsai_EN", "LittleAngel_EN");
            med.SimpleAddGroup(1, Enemies.Polyp, 3, "EyePalm_EN");
            med.AddRandomGroup(Enemies.Polyp, "Grandfather_EN", "ChoirBoy_EN");
            med.AddRandomGroup(Enemies.Polyp, "MiniReaper_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomGroup(Enemies.Polyp, "Merced_EN", "YNL_EN");
            med.AddRandomGroup(Enemies.Polyp, "Damocles_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Polyp, "GlassFigurine_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Enemies.Polyp, "BlackStar_EN", "InHerImage_EN", "InHisImage_EN");
            med.AddRandomGroup(Enemies.Polyp, "Children6_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup(Enemies.Polyp, "EvilDog_EN", "EvilDog_EN", "EvilDog_EN");
            med.SimpleAddGroup(1, Enemies.Polyp, 3, "Sundowner_EN");
            med.SimpleAddGroup(1, Enemies.Polyp, 3, "Insider_EN");
            med.AddRandomGroup(Enemies.Polyp, "Attrition_EN", "Attrition_EN", "TortureMeNot_EN");
            med.AddRandomGroup(Enemies.Polyp, "Indicator_EN", "Attrition_EN", "Attrition_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Enemies.Polyp, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Satyr_EN", Enemies.Polyp, Noses.Yellow);

            EcstasyPool.Add(Enemies.Polyp);

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", Enemies.Polyp);
            hard.AddRandomGroup("Satyr_EN", Enemies.Polyp, "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Enemies.Polyp);

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, Flower.Red, Enemies.Polyp);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Polyp, "InHisImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("ClockTower_EN", Enemies.Polyp, "Eyeless_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Polyp);

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Gray, Flower.Yellow, Enemies.Polyp);
            med.AddRandomGroup(Flower.Grey, Flower.Purple, Enemies.Polyp);

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, "MiniReaper_EN", Enemies.Polyp, "Damocles_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup(Enemies.Polyp, "MiniReaper_EN", "Git_EN", "Git_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", Enemies.Polyp, "EyePalm_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", Enemies.Polyp, "MiniReaper_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Enemies.Polyp);

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup(Enemies.Polyp, "Hunter_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", Enemies.Polyp, Enemies.Minister);

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup(Enemies.Polyp, "YNL_EN", "BlackStar_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Enemies.Polyp, "EggKeeper_EN");
            med.AddRandomGroup("Stoplight_EN", Enemies.Polyp, "Bonsai_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Polyp, Bots.Grey);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Polyp, Noses.Yellow);

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, Enemies.Polyp, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup(Bots.Grey, Enemies.Polyp, Bots.Red);

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", Enemies.Polyp, "InHisImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", Enemies.Polyp, "EvilDog_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", Enemies.Polyp);

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", Enemies.Polyp, "EyePalm_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", Enemies.Polyp, "Attrition_EN");
            hard.AddRandomGroup("Eyeless_EN", Enemies.Polyp, Noses.Blue);
            hard.AddRandomGroup("Eyeless_EN", Enemies.Polyp, "Insider_EN");
            hard.AddRandomGroup("Eyeless_EN", Enemies.Polyp, "Damocles_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", Enemies.Polyp, "PawnA_EN");
            med.AddRandomGroup("Yang_EN", Enemies.Polyp, "Indicator_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(2, "Yang_EN", 1, Enemies.Polyp);

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", Enemies.Polyp);

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", Enemies.Polyp, "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("CorpseChan_EN", Enemies.Polyp, "ChoirBoy_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", Enemies.Polyp, "EggKeeper_EN");
            med.AddRandomGroup("InTheDark_EN", Enemies.Polyp, "WindSong_EN");

            hard = new AddTo(Garden.H.Dark.Med);
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, Enemies.Polyp);

            EcstasyPool.Add("Unflarb_EN");
            EcstasyPool.Add("Flarbleft_EN");
            EcstasyPool.Add("LipBug_EN");
            EcstasyPool.Add("Seraphim_EN");
            EcstasyPool.Add("NakedGizo_EN");
            EcstasyPool.Add("Gizo_EN");
            EcstasyPool.Add("Chapman_EN");
            EcstasyPool.Add("Ophanim_EN");
            EcstasyPool.Add("SterileBud_EN");
            EcstasyPool.Add("Unterling_EN");
            EcstasyPool.Add("TitteringPeon_EN");
            EcstasyPool.Add("ScreamingHomunculus_EN");
        }
    }
}
