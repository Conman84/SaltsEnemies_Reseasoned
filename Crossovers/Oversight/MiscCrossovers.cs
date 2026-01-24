using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoneds
{
    public static class MiscCrossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Nameless.Med);
            med.SimpleAddGroup(2, "Nameless_EN", 2, "Frostbite_EN");
            med.SimpleAddGroup(2, "Nameless_EN", 2, "Moone_EN");
            med.AddRandomGroup("Nameless_EN", "Nameless_EN", "BackupDancer_EN", "MusicMan_EN");
            med.AddRandomGroup("Nameless_EN", "Gungrot_EN", "Gungrot_EN", "Spectre_EN");
            med.SimpleAddGroup(2, "Nameless_EN", 1, Jumble.Purple, 1, Jumble.Unstable);
            med.SimpleAddGroup(2, "Nameless_EN", 1, Jumble.Blue, 1, Jumble.Unstable);

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.SimpleAddGroup(1, "CorpseChan_EN", 2, "Git_EN");
            med.SimpleAddGroup(1, "CorpseChan_EN", 2, "Attrition_EN");
            med.SimpleAddGroup(2, "CorpseChan_EN", 1, "Beakart_EN");
            med.SimpleAddGroup(2, "CorpseChan_EN", 1, Noses.Red);
            med.SimpleAddGroup(2, "CorpseChan_EN", 1, Noses.Blue);
            med.SimpleAddGroup(2, "CorpseChan_EN", 1, Noses.Yellow);
            med.SimpleAddGroup(2, "CorpseChan_EN", 1, Noses.Purple);
            med.SimpleAddGroup(2, "CorpseChan_EN", 1, "EggKeeper_EN");
            med.SimpleAddGroup(2, "CorpseChan_EN", 1, Noses.Grey);
            med.SimpleAddGroup(1, "CorpseChan_EN", 2, "Bonsai_EN");
            med.SimpleAddGroup(2, "CorpseChan_EN", 1, Enemies.Polyp);

            med = new AddTo(Shore.H.Hauntling.Med);
            med.SimpleAddGroup(3, "Hauntling_EN", 1, "Snaurce_EN");
            med.SimpleAddGroup(2, "Hauntling_EN", 1, "Flakkid_EN");
            med.SimpleAddGroup(2, "Hauntling_EN", 1, Enemies.Swine);
            med.SimpleAddGroup(2, "Hauntling_EN", 1, Colophon.Red);
            med.SimpleAddGroup(2, "Hauntling_EN", 1, "Mungman_EN");
            med.SimpleAddGroup(2, "Hauntling_EN", 1, "Squirmer_EN");

            med = new AddTo(Orph.H.Insider.Med);
            med.SimpleAddGroup(2, "Insider_EN", 1, "BackupDancer_EN");
            med.SimpleAddGroup(2, "Insider_EN", 1, Jumble.Red, 1, Jumble.Unstable);
            med.SimpleAddGroup(2, "Insider_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, "Insider_EN", 2, "Gungrot_EN");
            med.SimpleAddGroup(2, "Insider_EN", 1, "Feckle_EN");
            med.SimpleAddGroup(2, "Insider_EN", 1, "Moone_EN");
            med.SimpleAddGroup(2, "Insider_EN", 1, Enemies.Shuffler);
            med.SimpleAddGroup(2, "Insider_EN", 1, Colophon.Red, 1, Colophon.Blue);
            med.SimpleAddGroup(2, "Insider_EN", 1, "ClayChildSleep_EN", 1, "ClayChild_EN");
            med.SimpleAddGroup(2, "Insider_EN", 1, "Byakhee_EN");
            med.SimpleAddGroup(2, "Insider_EN", 1, "Bloatfinger_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.SimpleAddGroup(2, "Attrition_EN", 1, "InTheDark_EN");
            med.SimpleAddGroup(2, "Git_EN", 1, "InTheDark_EN");
            med.AddRandomGroup("InTheDark_EN", "OdeToHumanity_EN", "Surrogate_EN");
            med.SimpleAddGroup(2, "Romantic_EN", 1, "Yang_EN", 1, "InTheDark_EN");
            med.AddRandomGroup("InTheDark_EN", "CorpseChan_EN", "EggKeeper_EN");
            med.AddRandomGroup("InTheDark_EN", Noses.Blue, "PawnA_EN");
            med.AddRandomGroup("InTheDark_EN", Noses.Purple, "Grandfather_EN");
            med.AddRandomGroup("InTheDark_EN", "Beakart_EN", "Children6_EN");
            med.AddRandomGroup("InTheDark_EN", Noses.Yellow, "Merced_EN");
            med.SimpleAddGroup(1, "InTheDark_EN", 2, "Bonsai_EN");
            med.AddRandomGroup("InTheDark_EN", "PersonalAngel_EN", "Romantic_EN");

            AddTo hard = new AddTo(Garden.H.Dark.Hard);
            hard.AddRandomGroup("InTheDark_EN", Noses.Blue, Noses.Yellow);
            hard.AddRandomGroup("InTheDark_EN", Noses.Red, Noses.Purple);
            hard.SimpleAddGroup(2, "InTheDark_EN", 2, "Git_EN");
            hard.AddRandomGroup("InTheDark_EN", "Hunter_EN", "Beakart_EN");
            hard.SimpleAddGroup(2, "InTheDark_EN", 2, "EggKeeper_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.SimpleAddGroup(1, "Snaurce_EN", 1, "Jabberwocky_EN", 2, "MudLung_EN");
            med.SimpleAddGroup(2, "Surimi_EN", 1, "Jabberwocky_EN");
            med.AddRandomGroup("VoiceTrumpet_EN", "Jabberwocky_EN", Jumble.Unstable);
            med.AddRandomGroup("Jabberwocky_EN", Spoggle.Unstable, Jumble.Yellow, "Snaurce_EN");
            med.AddRandomGroup("Jabberwocky_EN", Enemies.Swine, Enemies.Swine);
            med.AddRandomGroup("Jabberwocky_EN", "Mungman_EN", "Mungman_EN");
            med.AddRandomGroup("Jabberwocky_EN", "Squirmer_EN", Spoggle.Unstable);
            med.AddRandomGroup("Jabberwocky_EN", "Draugr_EN", Colophon.Blue);
            med.AddRandomGroup("Jabberwocky_EN", Colophon.Red, Colophon.Blue);
            med.AddRandomGroup("Jabberwocky_EN", "Pinano_EN", Jumble.Unstable);

            med = new AddTo(Garden.H.Sundowner.Med);
            med.SimpleAddGroup(4, "Sundowner_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(4, "Sundowner_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(4, "Sundowner_EN", 1, "EggKeeper_EN");
        }
    }
}
