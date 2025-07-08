using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Marmo_Crossovers_20
    {
        public static void Add20Shore()
        {
            AddTo med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "Surimi_EN", "Surimi_EN");
            med.AddRandomGroup("2009_EN", "Surimi_EN", "Pinano_EN");
            med.AddRandomGroup("2009_EN", "Snaurce_EN", Jumble.Yellow);
            med.AddRandomGroup("2009_EN", "Snaurce_EN", Jumble.Unstable);
            med.AddRandomGroup("2009_EN", "Snaurce_EN", Jumble.Red);

            med = new AddTo(Shore.H.Chiito.Med);
            med.AddRandomGroup("Chiito_EN", "Snaurce_EN", "Snaurce_EN");
            med.AddRandomGroup("Chiito_EN", Jumble.Unstable, Jumble.Yellow);
            med.AddRandomGroup("Chiito_EN", "Surimi_EN", "ToyUfo_EN");
            med.AddRandomGroup("Chiito_EN", "Surimi_EN", "Surimi_EN", "Skyloft_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "2009_EN", "Snaurce_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "2009_EN", "Surimi_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "2009_EN", Jumble.Unstable);

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "2009_EN", "Snaurce_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "2009_EN", "Surimi_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "2009_EN", Jumble.Unstable);

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "2009_EN", "Surimi_EN");

            AddTo hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Chiito_EN", "Surimi_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Chiito_EN", "Snaurce_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Chiito_EN", "Surimi_EN");
        }
        public static void Add20Orph()
        {
            AddTo easy = new AddTo(Orph.H.Foxtrot.Easy);
            easy.SimpleAddGroup(3, "Foxtrot_EN", 1, Jumble.Unstable);
            easy.SimpleAddGroup(3, "Foxtrot_EN", 1, Spoggle.Unstable);

            easy = new AddTo(Orph.H.Jumble.Unstable.Easy);
            easy.AddRandomGroup(Jumble.Yellow, Jumble.Unstable, "Foxtrot_EN");

            easy = new AddTo(Orph.H.Spoggle.Unstable.Easy);
            easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Yellow, "Foxtrot_EN");
            easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Blue, "Foxtrot_EN");

            AddTo med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(3, "Solitaire_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, "Solitaire_EN", 3, "Gungrot_EN");
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", Jumble.Unstable, Jumble.Red);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", Jumble.Unstable, Jumble.Yellow);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", Spoggle.Unstable, Spoggle.Yellow);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", Spoggle.Unstable, Spoggle.Blue);


            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", "Foxtrot_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "MusicMan_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "Romantic_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "LostSheep_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "Spectre_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", Colophon.Yellow);
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "Scrungie_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", Enemies.Camera);
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "Nameless_EN");
            med.AddRandomGroup("Errant_EN", "Solitaire_EN", "Wednesday_EN");

            AddTo hard = new AddTo(Orph.H.Errant.Hard);
            hard.SimpleAddGroup(1, "Errant_EN", 3, "Solitaire_EN");
            hard.AddRandomGroup("Errant_EN", "Solitaire_EN", "Solitaire_EN", "Romantic_EN", "Romantic_EN");
            hard.AddRandomGroup("Errant_EN", "Solitaire_EN", "Solitaire_EN", Jumble.Unstable);
            hard.AddRandomGroup("Errant_EN", "Solitaire_EN", Bots.Red, Bots.Yellow);
            hard.AddRandomGroup("Errant_EN", "Solitaire_EN", Bots.Blue, Bots.Purple);
            hard.AddRandomGroup("Errant_EN", "Solitaire_EN", Jumble.Blue, Jumble.Purple);
            hard.AddRandomGroup("Errant_EN", "Solitaire_EN", "Something_EN");
            hard.AddRandomGroup("Errant_EN", "Solitaire_EN", "WindSong_EN");


            easy = new AddTo(Orph.H.Enigma.Easy);
            easy.AddRandomGroup("Enigma_EN", "Enigma_EN", "Foxtrot_EN", "Romantic_EN");

            easy = new AddTo(Orph.H.Solvent.Easy);
            easy.AddRandomGroup(Enemies.Solvent, "Foxtrot_EN", "Gungrot_EN");

            easy = new AddTo(Orph.H.Shooter.Easy);
            easy.AddRandomGroup(Enemies.Shooter, "Foxtrot_EN", "Romantic_EN");
            easy.AddRandomGroup(Enemies.Shooter, "Foxtrot_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "Solitaire_EN", "Gungrot_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Solitaire_EN", "Romantic_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, "Solitaire_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, "Solitaire_EN", "Solitaire_EN", "Surrogate_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Solitaire_EN", "Surrogate_EN", "Surrogate_EN", "Surrogate_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Solitaire_EN", "Solitaire_EN", "Romantic_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Solitaire_EN", "Foxtrot_EN", "Romantic_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Solitaire_EN", "Romantic_EN", "Romantic_EN");
            med.AddRandomGroup("Crystal_EN", "Solitaire_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Solitaire_EN", "Solitaire_EN", "Surrogate_EN");
            med.AddRandomGroup("Evileye_EN", "Solitaire_EN", Jumble.Unstable, Jumble.Yellow);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Solitaire_EN", "Solitaire_EN", "Romantic_EN");
            med.AddRandomGroup("YellowAngel_EN", "Solitaire_EN", Spoggle.Unstable, Spoggle.Yellow);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Solitaire_EN", "Gungrot_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Maw_EN", "Solitaire_EN", Jumble.Unstable, Jumble.Purple);

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Solitaire_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("TheDragon_EN", "Solitaire_EN", Jumble.Unstable, Jumble.Unstable);

            hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Solitaire_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Scrungie.Med);
            med.AddRandomGroup("Scrungie_EN", "Solitaire_EN", "Solitaire_EN", "Romantic_EN");

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, "Solitaire_EN", Jumble.Yellow, Jumble.Unstable);

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, "Solitaire_EN", Jumble.Yellow, Jumble.Unstable);

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Spoggle.Red, "Solitaire_EN", Spoggle.Unstable, Spoggle.Yellow);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Spoggle.Red, "Solitaire_EN", Spoggle.Unstable, Spoggle.Blue);

            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Spoggle.Purple, "Solitaire_EN", Spoggle.Unstable, Spoggle.Yellow);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Spoggle.Purple, "Solitaire_EN", Spoggle.Unstable, Spoggle.Blue);

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "Solitaire_EN", "Solitaire_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup(Enemies.Sacrifice, "Solitaire_EN", "Solitaire_EN", "Solitaire_EN", "Romantic_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Solitaire_EN", Jumble.Unstable);

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "Solitaire_EN", "Solitaire_EN", "Surrogate_EN");
        }
    }
}
