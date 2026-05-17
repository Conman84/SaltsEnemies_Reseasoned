using System;
using System.Collections.Generic;
using System.Text;

//Call RoundCrossovers.Shufflers_1_4() in postloading

namespace SaltsEnemies_Reseasoned
{
    public static class RoundCrossovers
    {
        public static void Shufflers_1_4()
        {
            string shuffler = "Shawled_Shuffler_EN";

            AddTo easy = new AddTo("RR_Zone02_Shawled_Shuffler_Easy_EnemyBundle");
            easy.AddRandomGroup(shuffler, "Enigma_EN");
            easy.AddRandomGroup(shuffler, "Enigma_EN", "Enigma_EN");
            easy.AddRandomGroup(shuffler, "MusicMan_EN", "LostSheep_EN");

            AddTo med = new AddTo("RR_Zone02_Shawled_Shuffler_Medium_EnemyBundle");
            med.AddRandomGroup(shuffler, "Enigma_EN", "Enigma_EN", "LostSheep_EN");
            med.AddRandomGroup(shuffler, shuffler, "LostSheep_EN");
            med.AddRandomGroup(shuffler, "Something_EN", "LostSheep_EN");
            med.AddRandomGroup(shuffler, shuffler, "MechanicalLens_EN");

            med = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            med.AddRandomGroup("Something_EN", shuffler, "Enigma_EN");
            med.AddRandomGroup("Something_EN", shuffler, "LostSheep_EN");

            med = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            med.AddRandomGroup("TheCrow_EN", shuffler, "SingingStone_EN");
            med.AddRandomGroup("TheCrow_EN", shuffler, "MusicMan_EN");
            med.AddRandomGroup("TheCrow_EN", shuffler, "Enigma_EN");

            med = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            med.AddRandomGroup("Freud_EN", shuffler, Jumble.Yellow);

            med = new AddTo("H_Zone02_Conductor_Medium_EnemyBundle");
            med.AddRandomGroup("Conductor_EN", shuffler, "LostSheep_EN");

            AddTo hard = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            hard.AddRandomGroup("Conductor_EN", shuffler, "Something_EN");

            hard = new AddTo("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle");
            hard.AddRandomGroup("WrigglingSacrifice_EN", shuffler, "Enigma_EN");
        }
        public static void Shufflers_5_10()
        {
            AddTo easy = new AddTo(Orph.H.Shuffler.Easy);
            easy.SimpleAddGroup(1, Enemies.Shuffler, 2, "Delusion_EN");
            if (SaltsReseasoned.rando == 83) easy.SimpleAddGroup(1, Enemies.Shuffler, 2, "Spectre_EN");

            AddTo med = new AddTo(Orph.H.Shuffler.Med);
            med.AddRandomGroup(Enemies.Shuffler, Flower.Yellow, Flower.Purple);
            med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, "Sigil_EN");
            med.SimpleAddGroup(2, Enemies.Shuffler, 1, Enemies.Solvent);
            med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, "WindSong_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", Enemies.Shuffler, Enemies.Suckle);
            hard.AddRandomGroup("StalwartTortoise_EN", Enemies.Shuffler, "LostSheep_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", Enemies.Shuffler, "Sigil_EN");
            med.AddRandomGroup("Conductor_EN", Enemies.Shuffler, "Delusion_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", Enemies.Shuffler, "WindSong_EN");
        }
        public static void Shufflers_11_14()
        {
            AddTo med = new AddTo(Orph.H.Shuffler.Med);
            med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, "Rabies_EN");
            med.AddRandomGroup(Enemies.Shuffler, "Rabies_EN", Jumble.Purple);
            med.AddRandomGroup(Enemies.Shuffler, "Rabies_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup(Enemies.Shuffler, "Rabies_EN", "WindSong_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Enemies.Shuffler, "Sigil_EN");
            med.AddRandomGroup("Maw_EN", Enemies.Shuffler, "MusicMan_EN");
            med.AddRandomGroup("Maw_EN", Enemies.Shuffler, Enemies.Suckle, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Maw_EN", Enemies.Shuffler, Enemies.Solvent);

            AddTo hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Enemies.Shuffler, Enemies.Shuffler);
            hard.AddRandomGroup("Maw_EN", Enemies.Shuffler, Jumble.Blue, Jumble.Purple);
            hard.AddRandomGroup("Maw_EN", Enemies.Shuffler, Spoggle.Blue, Spoggle.Yellow);
            hard.AddRandomGroup("Maw_EN", Enemies.Shuffler, "WindSong_EN", Enemies.Suckle, Enemies.Suckle);
        }
        public static void Shufflers_15_18()
        {
            AddTo med = new AddTo(Orph.H.Shuffler.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, Bots.Red);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, Bots.Yellow);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, Bots.Blue);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, Bots.Purple);
            med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, Enemies.Shooter);

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, Enemies.Shuffler);

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, Enemies.Shuffler);

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, Enemies.Shuffler);

            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, Enemies.Shuffler);

            AddTo hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", Enemies.Shuffler, Enemies.Shuffler);

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", Spoggle.Red, Enemies.Shuffler);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", Enemies.Shuffler, "Something_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Scrungie_EN", Enemies.Shuffler);
        }
        public static void Shufflers_19_21()
        {
            AddTo med = new AddTo(Orph.H.Shuffler.Med);
            med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup(Enemies.Shuffler, "Solitaire_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, "Solitaire_EN");

            AddTo easy = new AddTo(Orph.H.Shuffler.Easy);
            easy.SimpleAddGroup(1, Enemies.Shuffler, 3, "Foxtrot_EN");

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", Enemies.Shuffler, "SingingStone_EN");

            EcstasyPool.Add(Enemies.Shuffler);
        }
    }
}
