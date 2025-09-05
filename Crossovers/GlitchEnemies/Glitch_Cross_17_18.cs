using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Glitch_Cross_17_18
    {
        public static void Add()
        {
            //SHORE
            AddTo easy = new AddTo(Shore.H.Flakkid.Easy);
            easy.AddRandomGroup("Flakkid_EN", "NobodyGrave_EN", "Flakkid_EN");

            easy = new AddTo(Shore.H.Swine.Easy);
            easy.AddRandomGroup(Enemies.Swine, "NobodyGrave_EN", Jumble.Red);

            AddTo med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "Flakkid_EN", Spoggle.Blue);

            med = new AddTo(Shore.H.Flakkid.Med);
            med.AddRandomGroup("ToyUfo_EN", "Flakkid_EN", "Flakkid_EN");
            med.AddRandomGroup("Flakkid_EN", Jumble.Yellow, "ToyUfo_EN");

            med = new AddTo(Shore.H.Swine.Med);
            med.AddRandomGroup(Enemies.Swine, "ToyUfo_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup(Enemies.Swine, Enemies.Swine, "ToyUfo_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Flakkid_EN", Spoggle.Yellow);
            med.AddRandomGroup("Sinker_EN", Enemies.Swine, "Pinano_EN");

            med = new AddTo(Shore.H.Bait.Med);
            med.AddRandomGroup("DryBait_EN", "ToyUfo_EN", "Pinano_EN");
            med.AddRandomGroup("DryBait_EN", "ToyUfo_EN", Jumble.Unstable);

            AddTo hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", Enemies.Swine, Enemies.Swine);
            hard.AddRandomGroup("Sinker_EN", "DryBait_EN", "Pinano_EN", "Pinano_EN");

            //ORPH
            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "BackupDancer_EN", Jumble.Blue);
            med.AddRandomGroup("Evileye_EN", "Frostbite_EN", "Frostbite_EN", Bots.Yellow);
            med.AddRandomGroup("Evileye_EN", "BackupDancer_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "BackupDancer_EN", "BackupDancer_EN");
            med.AddRandomGroup("YellowAngel_EN", "BackupDancer_EN", "WindSong_EN");
            med.AddRandomGroup("YellowAngel_EN", "Frostbite_EN", "Frostbite_EN", "Frostbite_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, "BackupDancer_EN");

            med = new AddTo(Orph.H.Dancer.Med);
            med.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Frostbite.Med);
            med.AddRandomGroup("Frostbite_EN", "Frostbite_EN", "Frostbite_EN", Enemies.Shooter);
        }
    }
}
