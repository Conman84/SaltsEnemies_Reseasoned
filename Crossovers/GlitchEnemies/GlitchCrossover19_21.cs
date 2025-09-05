using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GlitchCrossover19_21
    {
        public static void Add()
        {
            //shore
            AddTo easy = new AddTo(Shore.H.Flakkid.Easy);
            easy.AddRandomGroup("Flakkid_EN", "Waltz_EN", "Waltz_EN");
            easy.AddRandomGroup("Flakkid_EN", "Wall_EN", "Wall_EN");

            easy = new AddTo(Shore.H.Swine.Easy);
            easy.AddRandomGroup(Enemies.Swine, "Waltz_EN", "Waltz_EN");

            AddTo med = new AddTo(Shore.H.Flakkid.Med);
            med.AddRandomGroup("Flakkid_EN", "Flakkid_EN", "Wall_EN");
            med.AddRandomGroup("Flakkid_EN", "VoiceTrumpet_EN", Jumble.Yellow);

            med = new AddTo(Shore.H.Swine.Med);
            med.AddRandomGroup(Enemies.Swine, "Wall_EN", "Wall_EN");
            med.AddRandomGroup(Enemies.Swine, "VoiceTrumpet_EN", "ToyUfo_EN");
            med.AddRandomGroup(Enemies.Swine, "VoiceTrumpet_EN", Spoggle.Blue);

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "Flakkid_EN", "Flarblet_EN", "Flarblet_EN");
            med.AddRandomGroup("2009_EN", Enemies.Swine, "Pinano_EN");

            med = new AddTo(Shore.H.Trumpet.Med);
            med.AddRandomGroup("VoiceTrumpet_EN", "VoiceTrumpet_EN", "Flakkid_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.AddRandomGroup("Chiito_EN", Enemies.Swine, Enemies.Swine);
            med.AddRandomGroup("Chiito_EN", "Flakkid_EN", Jumble.Red, Jumble.Yellow);

            med = new AddTo(Shore.H.Pipe.Med);
            med.AddRandomGroup("NotAn_EN", "2009_EN", "Waltz_EN", "Waltz_EN");

            med = new AddTo(Shore.H.Bait.Med);
            med.AddRandomGroup("DryBait_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN");

            AddTo hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Flakkid_EN", Jumble.Yellow);
            hard.AddRandomGroup("Clown_EN", Enemies.Swine, Jumble.Red);
            hard.AddRandomGroup("Clown_EN", "NotAn_EN", "Waltz_EN");
            hard.AddRandomGroup("Clown_EN", "DryBait_EN", "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", "DryBait_EN", "DryBait_EN", "DryBait_EN");
            hard.AddRandomGroup("33_EN", Enemies.Swine, Enemies.Swine, "Flarblet_EN");
            hard.AddRandomGroup("33_EN", "Wall_EN", "NotAn_EN", "NobodyGrave_EN");

            //ORPHEUM
            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "Frostbite_EN", "Frostbite_EN", Bots.Yellow);
            med.AddRandomGroup("Wednesday_EN", "BackupDancer_EN", "BackupDancer_EN", "WindSong_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Frostbite_EN", "Frostbite_EN");
            med.AddRandomGroup("Solitaire_EN", "Scrungie_EN", "BackupDancer_EN");
            med.AddRandomGroup("Solitaire_EN", "BackupDancer_EN", "Solitaire_EN", Enemies.Suckle, Enemies.Suckle);

            easy = new AddTo(Orph.H.Frostbite.Easy);
            easy.SimpleAddGroup(2, "Frostbite_EN", 1, "Foxtrot_EN");

            med = new AddTo(Orph.H.Frostbite.Med);
            med.SimpleAddGroup(3, "Frostbite_EN", 1, "Foxtrot_EN");

            easy = new AddTo(Orph.H.Dancer.Easy);
            easy.SimpleAddGroup(2, "BackupDancer_EN", 1, "Foxtrot_EN");

            med = new AddTo(Orph.H.Dancer.Med);
            med.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "Solitaire_EN");
            med.AddRandomGroup("BackupDancer_EN", "MusicMan_EN", "MusicMan_EN", "Solitaire_EN");
            med.AddRandomGroup("BackupDancer_EN", "Author_EN", Spoggle.Red);

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", "BackupDancer_EN", "BackupDancer_EN");
            med.SimpleAddGroup(1, "Author_EN", 3, "Frostbite_EN");
            med.SimpleAddGroup(1, "Author_EN", 2, "Frostbite_EN", 1, "WindSong_EN");
        }
    }
}
