using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Marmo17_18
    {
        public static void AddShore()
        {
            AddTo easy = new AddTo(Shore.H.Snaurce.Easy);
            easy.SimpleAddGroup(2, "Snaurce_EN", 1, "NobodyGrave_EN");

            easy = new AddTo(Shore.H.Surimi.Easy);
            easy.SimpleAddGroup(2, "Surimi_EN", 1, "NobodyGrave_EN");

            AddTo med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", "Surimi_EN");
            med.SimpleAddGroup(1, "ToyUfo_EN", 2, "Snaurce_EN", 1, "TortureMeNot_EN");
            med.AddRandomGroup("ToyUfo_EN", "Snaurce_EN", "Pinano_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", Jumble.Yellow);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", Jumble.Red);
            med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", Jumble.Unstable);
            med.AddRandomGroup("ToyUfo_EN", "Snaurce_EN", Spoggle.Unstable);
            med.AddRandomGroup("ToyUfo_EN", "Pinano_EN", Jumble.Unstable);
            med.AddRandomGroup("ToyUfo_EN", "MudLung_EN", Spoggle.Unstable);
            med.AddRandomGroup("ToyUfo_EN", "Snaurce_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("ToyUfo_EN", "Snaurce_EN", "Snaurce_EN", "Skyloft_EN");
            med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", "MudLung_EN");
            med.SimpleAddGroup(1, "ToyUfo_EN", 3, "Snaurce_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "Surimi_EN");
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "Snaurce_EN");
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Jumble.Unstable);

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Surimi_EN", "Sinker_EN");
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Spoggle.Unstable);

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", "Snaurce_EN");
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", "Surimi_EN");
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", Jumble.Unstable);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "ToyUfo_EN", "Surimi_EN", "Surimi_EN");
            hard.AddRandomGroup("Warbird_EN", "NobodyGrave_EN", Jumble.Unstable, Jumble.Red);

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", "Surimi_EN");
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", "Snaurce_EN");
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", Jumble.Unstable);

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", "Surimi_EN");
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", "Snaurce_EN");
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", Jumble.Unstable);
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", Spoggle.Unstable);

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Snaurce_EN", "Arceles_EN");
            med.AddRandomGroup("Sinker_EN", "Surimi_EN", "Skyloft_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Sinker_EN", Spoggle.Yellow, Spoggle.Unstable);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Sinker_EN", Spoggle.Blue, Spoggle.Unstable);

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.SimpleAddGroup(1, "Sinker_EN", 3, "Snaurce_EN");
            hard.SimpleAddGroup(1, "Sinker_EN", 3, "Surimi_EN");
            hard.AddRandomGroup("Sinker_EN", Jumble.Unstable, Jumble.Yellow, Jumble.Red);

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, Jumble.Unstable, "NobodyGrave_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, Jumble.Unstable, "NobodyGrave_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Unstable, "ToyUfo_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Unstable, "ToyUfo_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "Snaurce_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "Surimi_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", Jumble.Unstable);
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", Spoggle.Unstable);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "NobodyGrave_EN", Spoggle.Unstable);
            hard.AddRandomGroup("Flarb_EN", "NobodyGrave_EN", Jumble.Unstable);
        }
        public static void AddOrpheum()
        {
            AddTo easy = new AddTo(Orph.Shooter.Easy);
            easy.AddRandomGroup(Enemies.Shooter, "Romantic_EN");
            easy.AddRandomGroup(Enemies.Shooter, Jumble.Red, "Romantic_EN");
            easy.AddRandomGroup(Enemies.Shooter, Jumble.Unstable, "Romantic_EN");
            easy.AddRandomGroup(Enemies.Shooter, "Gungrot_EN", "Gungrot_EN");

            AddTo med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, "Romantic_EN");
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, "Surrogate_EN");
            med.SimpleAddGroup(1, Enemies.Shooter, 3, "Gungrot_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Enemies.Shooter, Spoggle.Unstable);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Enemies.Shooter, Jumble.Unstable, Jumble.Yellow);

            AddTo hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", Enemies.Shooter, "Romantic_EN");
            hard.AddRandomGroup("TheDragon_EN", "Evileye_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("TheDragon_EN", "YellowAngel_EN", "Romantic_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", Enemies.Shooter, "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Enemies.Shooter, "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Enemies.Shooter, "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Purple, Enemies.Shooter, "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", Enemies.Shooter, "Romantic_EN", "Romantic_EN");
            med.AddRandomGroup("Crystal_EN", Enemies.Shooter, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Crystal_EN", Enemies.Shooter, "Surrogate_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.SimpleAddGroup(1, "Evileye_EN", 4, "Gungrot_EN");
            med.SimpleAddGroup(1, "Evileye_EN", 3, "Gungrot_EN");
            med.SimpleAddGroup(1, "Evileye_EN", 3, "Surrogate_EN");
            med.AddRandomGroup("Evileye_EN", Bots.Blue, Bots.Purple, "Surrogate_EN");
            med.AddRandomGroup("Evileye_EN", Jumble.Blue, Jumble.Purple, "Surrogate_EN");
            med.AddRandomGroup("Evileye_EN", Flower.Yellow, Flower.Purple, "Surrogate_EN");
            med.AddRandomGroup("Evileye_EN", Enemies.Shooter, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Evileye_EN", "Delusion_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Evileye_EN", "Gungrot_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Evileye_EN", "MusicMan_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Evileye_EN", Jumble.Yellow, Jumble.Unstable, Jumble.Red);
            med.AddRandomGroup("Evileye_EN", Spoggle.Red, Spoggle.Unstable);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", Jumble.Yellow, Jumble.Red, Jumble.Unstable);
            med.SimpleAddGroup(1, "YellowAngel_EN", 3, "Gungrot_EN");
            med.AddRandomGroup("YellowAngel_EN", "MusicMan_EN", "MusicMan_EN", "Romantic_EN");
            med.AddRandomGroup("YellowAngel_EN", "Delusion_EN", "Delusion_EN", "Surrogate_EN");
            med.AddRandomGroup("YellowAngel_EN", "Gungrot_EN", "Gungrot_EN", Jumble.Blue);
            med.AddRandomGroup("YellowAngel_EN", "Gungrot_EN", "Gungrot_EN", Jumble.Purple);
            med.AddRandomGroup("YellowAngel_EN", "Romantic_EN", "Romantic_EN", Spoggle.Red);
            med.AddRandomGroup("YellowAngel_EN", "Romantic_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Shooter, "Surrogate_EN");
            med.AddRandomGroup("YellowAngel_EN", Spoggle.Unstable, "Spectre_EN", "Spectre_EN");

            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", Enemies.Shooter, Jumble.Unstable);
            med.AddRandomGroup("Errant_EN", Enemies.Shooter, Spoggle.Unstable);
            med.AddRandomGroup("Errant_EN", Enemies.Shooter, Bots.Red);
            med.AddRandomGroup("Errant_EN", Enemies.Shooter, Bots.Yellow);

            hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", "Evileye_EN", "LostSheep_EN");
            hard.AddRandomGroup("Errant_EN", "Evileye_EN", "Nameless_EN");
            hard.AddRandomGroup("Errant_EN", "YellowAngel_EN", "Romantic_EN");
            hard.AddRandomGroup("Errant_EN", "YellowAngel_EN", "Surrogate_EN");

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, Enemies.Shooter, "Surrogate_EN");
            med.AddRandomGroup(Jumble.Blue, Enemies.Shooter, "Romantic_EN");

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, Enemies.Shooter, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup(Jumble.Purple, Enemies.Shooter, Jumble.Unstable);

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "Evileye_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("Conductor_EN", "YellowAngel_EN", "Romantic_EN", "Romantic_EN");
        }
        public static void AddGarden()
        {
            AddTo med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Git_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Attrition_EN", "Attrition_EN");
            med.AddRandomGroup("PersonalAngel_EN", "Git_EN", "Git_EN");
            med.AddRandomGroup("PersonalAngel_EN", "YNL_EN", "Surrogate_EN", "Surrogate_EN");
            med.AddRandomGroup("PersonalAngel_EN", "ChoirBoy_EN", "Surrogate_EN");
            med.AddRandomGroup("PersonalAngel_EN", "Firebird_EN", "Romantic_EN");
            med.AddRandomGroup("PersonalAngel_EN", Spoggle.Grey, "Surrogate_EN", "Skyloft_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Attrition_EN", "Attrition_EN");
            med.AddRandomGroup("Complimentary_EN", "Git_EN", "Git_EN");
            med.AddRandomGroup("Complimentary_EN", "Attrition_EN", "Romantic_EN");
            med.AddRandomGroup("Complimentary_EN", "Git_EN", "Surrogate_EN");
            med.AddRandomGroup("Complimentary_EN", "Git_EN", "MiniReaper_EN");
            med.AddRandomGroup("Complimentary_EN", "Git_EN", "Romantic_EN");
            med.AddRandomGroup("Complimentary_EN", "Romantic_EN", "Merced_EN");

            AddTo hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "PersonalAngel_EN", "Git_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Complimentary_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "EvilDog_EN", "EvilDog_EN", "Surrogate_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "PersonalAngel_EN", "Romantic_EN", "Romantic_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Complimentary_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Git_EN", "EvilDog_EN", "EvilDog_EN");
        }
    }
}
