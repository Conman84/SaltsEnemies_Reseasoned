using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoCrossovers21
    {
        public static void AddOrph()
        {
            AddTo med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", Jumble.Unstable);
            med.AddRandomGroup("Author_EN", "Author_EN", Spoggle.Unstable);
            med.AddRandomGroup("Author_EN", "Surrogate_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Author_EN", Jumble.Blue, Jumble.Unstable);
            med.AddRandomGroup("Author_EN", Jumble.Purple, Jumble.Unstable);
            med.AddRandomGroup("Author_EN", "Enigma_EN", "Enigma_EN", "Surrogate_EN");
            med.AddRandomGroup("Author_EN", Bots.Red, Bots.Yellow, "Romantic_EN");
            med.AddRandomGroup("Author_EN", "Sigil_EN", "Scrungie_EN", "Romantic_EN");
            med.AddRandomGroup("Author_EN", "Gungrot_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Author_EN", "Solitaire_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Author_EN", "MusicMan_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Author_EN", "Rabies_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Author_EN", Spoggle.Red, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Author_EN", "Something_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Author_EN", Flower.Purple, Flower.Yellow, "Romantic_EN");
            med.AddRandomGroup("Author_EN", "Surrogate_EN", "Surrogate_EN", "Surrogate_EN", "Surrogate_EN");
            med.AddRandomGroup("Author_EN", "Solitaire_EN", Spoggle.Unstable);

            AddTo hard = new AddTo(Orph.H.Author.Hard);
            hard.SimpleAddGroup(1, "Author_EN", 4, "Gungrot_EN");
            hard.SimpleAddGroup(3, "Author_EN", 1, Spoggle.Unstable);
            hard.SimpleAddGroup(3, "Author_EN", 1, Jumble.Unstable);
            hard.SimpleAddGroup(3, "Author_EN", 1, "Romantic_EN");
            hard.SimpleAddGroup(3, "Author_EN", 1, "Surrogate_EN");

            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", "Author_EN", "Romantic_EN");
            med.AddRandomGroup("Errant_EN", "Author_EN", Jumble.Unstable);
            med.AddRandomGroup("Errant_EN", "Author_EN", "MusicMan_EN");
            med.AddRandomGroup("Errant_EN", "Author_EN", "Solitaire_EN");
            med.AddRandomGroup("Errant_EN", "Author_EN", "Surrogate_EN");
            med.AddRandomGroup("Errant_EN", "Author_EN", "Sigil_EN");
            med.AddRandomGroup("Errant_EN", "Author_EN", "Romantic_EN", "Romantic_EN");

            hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", "Author_EN", "Author_EN");
            hard.AddRandomGroup("Errant_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("Errant_EN", "Author_EN", "Evileye_EN");
            hard.AddRandomGroup("Errant_EN", "Author_EN", "YellowAngel_EN");
            hard.AddRandomGroup("Errant_EN", "Author_EN", Jumble.Red, Jumble.Unstable);
            hard.AddRandomGroup("Errant_EN", "Author_EN", "LostSheep_EN", "LostSheep_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Author_EN", "Romantic_EN", "Romantic_EN");
            med.AddRandomGroup("Freud_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Evileye_EN", "Author_EN", "Romantic_EN", Jumble.Blue);
            med.AddRandomGroup("Evileye_EN", "Author_EN", "Romantic_EN", Bots.Yellow);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("YellowAngel_EN", "Author_EN", Spoggle.Yellow, Spoggle.Unstable);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("YellowAngel_EN", "Author_EN", Spoggle.Blue, Spoggle.Unstable);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Maw_EN", "Author_EN", "Romantic_EN", "Romantic_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Author_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("TheDragon_EN", "Author_EN", Jumble.Yellow, Jumble.Unstable);
        }
        public static void AddShore()
        {
            AddTo easy = new AddTo(Shore.H.Wall.Easy);
            easy.AddRandomGroup("Wall_EN", Jumble.Unstable);
            easy.AddRandomGroup("Wall_EN", "Snaurce_EN");

            AddTo med = new AddTo(Shore.H.Wall.Med);
            med.AddRandomGroup("Wall_EN", "Wall_EN", Jumble.Unstable);
            med.AddRandomGroup("Wall_EN", "Wall_EN", "Snaurce_EN");
            med.AddRandomGroup("Wall_EN", Jumble.Yellow, "Snaurce_EN");

            AddTo hard = new AddTo(Shore.H.Amalga.Hard);
            hard.SimpleAddGroup(1, "33_EN", 3, "Snaurce_EN");
            hard.SimpleAddGroup(1, "33_EN", 3, "Surimi_EN");
            hard.AddRandomGroup("33_EN", Jumble.Red, Jumble.Yellow, Jumble.Unstable);

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Waltz_EN", Jumble.Unstable);
            hard.AddRandomGroup("Clown_EN", "Waltz_EN", Spoggle.Unstable);
            hard.AddRandomGroup("Clown_EN", "Snaurce_EN", "Snaurce_EN");
            hard.AddRandomGroup("Clown_EN", "Waltz_EN", "Surimi_EN");
            hard.AddRandomGroup("Clown_EN", Jumble.Yellow, Jumble.Unstable);
            hard.AddRandomGroup("Clown_EN", Jumble.Red, Jumble.Unstable);
            hard.AddRandomGroup("Clown_EN", Spoggle.Yellow, Spoggle.Unstable);
            hard.AddRandomGroup("Clown_EN", Spoggle.Blue, Spoggle.Unstable);
            hard.AddRandomGroup("Clown_EN", "Surimi_EN", "Surimi_EN");
            hard.AddRandomGroup("Clown_EN", "Waltz_EN", "Snaurce_EN");
            hard.AddRandomGroup("Clown_EN", "Pinano_EN", "Snaurce_EN");
            hard.AddRandomGroup("Clown_EN", "Pinano_EN", "Surimi_EN");
            hard.AddRandomGroup("Clown_EN", Enemies.Mungling, "Snaurce_EN");
            hard.AddRandomGroup("Clown_EN", Enemies.Mungling, "Surimi_EN");

            easy = new AddTo(Shore.H.Trumpet.Easy);
            easy.AddRandomGroup("VoiceTrumpet_EN", Jumble.Unstable);
            easy.AddRandomGroup("VoiceTrumpet_EN", "Snaurce_EN");

            med = new AddTo(Shore.H.Trumpet.Med);
            med.AddRandomGroup("VoiceTrumpet_EN", "VoiceTrumpet_EN", Jumble.Unstable);
            med.AddRandomGroup("VoiceTrumpet_EN", "VoiceTrumpet_EN", "Snaurce_EN");
            med.AddRandomGroup("VoiceTrumpet_EN", "VoiceTrumpet_EN", "Surimi_EN");

            easy = new AddTo(Shore.H.Snaurce.Easy);
            easy.AddRandomGroup("Snaurce_EN", "Waltz_EN", "Waltz_EN");
            easy.AddRandomGroup("Snaurce_EN", "Snaurce_EN", "Waltz_EN");
            easy.AddRandomGroup("Snaurce_EN", "Wall_EN");

            med = new AddTo(Shore.H.Snaurce.Med);
            med.AddRandomGroup("Snaurce_EN", "Snaurce_EN", "Wall_EN");
            med.AddRandomGroup("Snaurce_EN", "Snaurce_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("Snaurce_EN", "Snaurce_EN", "VoiceTrumpet_EN");

            easy = new AddTo(Shore.H.Surimi.Easy);
            easy.AddRandomGroup("Surimi_EN", "Waltz_EN", "Waltz_EN");
            easy.AddRandomGroup("Surimi_EN", "Surimi_EN", "Waltz_EN");

            med = new AddTo(Shore.H.Surimi.Med);
            med.AddRandomGroup("Surimi_EN", "Surimi_EN", "Wall_EN");
            med.AddRandomGroup("Surimi_EN", "Surimi_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("Surimi_EN", "Surimi_EN", "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Yellow, Jumble.Unstable, "Wall_EN");
            med.AddRandomGroup(Jumble.Yellow, Jumble.Unstable, "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Jumble.Yellow, Jumble.Unstable, "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Unstable, "Wall_EN");
            med.AddRandomGroup(Jumble.Red, Jumble.Unstable, "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Jumble.Red, Jumble.Unstable, "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Unstable, "Wall_EN");
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Unstable, "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Unstable, "Waltz_EN");
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Unstable, "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Unstable, "Wall_EN");
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Unstable, "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Unstable, "Waltz_EN");
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Unstable, "VoiceTrumpet_EN");
        }
    }
}
