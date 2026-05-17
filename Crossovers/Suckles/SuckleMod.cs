using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SuckleModCrossovers
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Orph.H.Feaster.Easy);
            easy.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, "Enigma_EN");
            easy.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, "LostSheep_EN");
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Solvent);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, "Foxtrot_EN");

            AddTo med = new AddTo(Orph.H.Feaster.Med);
            med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "LostSheep_EN");
            med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "Nameless_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "Sigil_EN", Enemies.Suckle);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "Wednesday_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "Enigma_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, "Enigma_EN", "Enigma_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Feaster, Bots.Red);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Feaster, Bots.Yellow);
            med.AddRandomGroup(Enemies.Feaster, Enemies.Suckle, Enemies.Suckle, Enemies.Alchemist, "TheWhale_EN");

            easy = new AddTo(Orph.H.Enigma.Easy);
            easy.SimpleAddGroup(2, "Enigma_EN", 1, Enemies.Accelerator);

            med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, Enemies.Accelerator);

            med = new AddTo(Orph.H.Sigil.Med);
            med.SimpleAddGroup(1, "Sigil_EN", 3, Enemies.Feaster);
            med.SimpleAddGroup(1, "Sigil_EN", 2, Enemies.Feaster, 1, Enemies.Alchemist, 1, Enemies.Suckle);

            med = new AddTo(Orph.H.Rabies.Med);
            med.SimpleAddGroup(2, "Rabies_EN", 1, Enemies.Accelerator);

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, Enemies.Suckle, Enemies.Accelerator);
            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, Enemies.Suckle, Enemies.Accelerator);

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, Enemies.Feaster);
            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, Enemies.Feaster);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", Enemies.Suckle, Enemies.Suckle, Enemies.Feaster, Enemies.Alchemist);
            med.AddRandomGroup("Evileye_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Accelerator);

            easy = new AddTo(Orph.H.Shooter.Easy);
            easy.AddRandomGroup(Enemies.Shooter, Enemies.Accelerator, Enemies.Accelerator);

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, Enemies.Accelerator);

            easy = new AddTo(Orph.H.Something.Easy);
            easy.AddRandomGroup("Something_EN", Enemies.Feaster);

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Enemies.Feaster, Enemies.Alchemist);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Enemies.Suckle, Enemies.Suckle, Enemies.Feaster, Enemies.Alchemist);
            med.AddRandomGroup("TheCrow_EN", Spoggle.Red, Enemies.Accelerator, Enemies.Accelerator);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Enemies.Suckle, Enemies.Suckle, Enemies.Feaster, Enemies.Alchemist);
            med.AddRandomGroup("Freud_EN", Enemies.Shooter, Enemies.Alchemist);

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Feaster, Enemies.Feaster);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Accelerator, "Scrungie_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "FakeAngel_EN", Enemies.Accelerator);

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Enemies.Suckle, Enemies.Suckle, Enemies.Feaster, Enemies.Alchemist);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, Enemies.Feaster);
            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, Enemies.Accelerator, Enemies.Accelerator, Enemies.Alchemist);
            med.AddRandomGroup(Flower.Purple, Flower.Purple, Enemies.Feaster);

            easy = new AddTo(Orph.H.Solvent.Easy);
            easy.AddRandomGroup(Enemies.Solvent, Enemies.Feaster, Enemies.Accelerator);

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, Enemies.Suckle);
            med.AddRandomGroup("WindSong_EN", Bots.Red, Bots.Blue, Enemies.Accelerator);

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", Enemies.Feaster, Enemies.Alchemist);
            hard.AddRandomGroup("StalwartTortoise_EN", Enemies.Feaster, Enemies.Suckle);

            med = new AddTo(Orph.H.Nameless.Med);
            med.AddRandomGroup("Nameless_EN", "Nameless_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Feaster);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Enemies.Alchemist, Enemies.Suckle, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Maw_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Accelerator);

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist);
            hard.AddRandomGroup("Maw_EN", "TheWhale_EN", "TheWhale_EN", Enemies.Accelerator);

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", Enemies.Feaster, Enemies.Feaster);
            med.AddRandomGroup("Crystal_EN", Jumble.Red, Jumble.Purple, Enemies.Accelerator);

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", Enemies.Feaster, Enemies.Alchemist, Enemies.Suckle);
            hard.AddRandomGroup("TheDragon_EN", Enemies.Accelerator, Enemies.Accelerator);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Feaster);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Alchemist, Enemies.Suckle, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Accelerator, "Scrungie_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            if (SaltsReseasoned.rando < 33) med.AddRandomGroup("Wednesday_EN", Enemies.Accelerator, Enemies.Accelerator, Enemies.Accelerator, "MusicMan_EN");
            med.AddRandomGroup("Wednesday_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Suckle);

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(2, "Solitaire_EN", 2, Enemies.Feaster);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, Enemies.Accelerator);
            med.SimpleAddGroup(2, "Solitaire_EN", 1, Enemies.Alchemist, 2, Enemies.Suckle);

            easy = new AddTo(Orph.H.Foxtrot.Easy);
            easy.SimpleAddGroup(3, "Foxtrot_EN", 1, Enemies.Accelerator);

            med = new AddTo(Orph.H.Author.Med);
            med.SimpleAddGroup(1, "Author_EN", 2, Enemies.Feaster, 1, Enemies.Accelerator);
            med.SimpleAddGroup(1, "Author_EN", 2, "MusicMan_EN", 1, Enemies.Accelerator);
            med.SimpleAddGroup(1, "Author_EN", 1, Enemies.Alchemist, 3, Enemies.Suckle);

            hard = new AddTo(Orph.H.Author.Hard);
            hard.SimpleAddGroup(3, "Author_EN", 1, Enemies.Alchemist);
            hard.SimpleAddGroup(3, "Author_EN", 1, Enemies.Accelerator, 1, Enemies.Suckle);

            med = new AddTo(Orph.H.Insider.Med);
            med.SimpleAddGroup(2, "insider_EN", 1, Enemies.Feaster, 2, Enemies.Suckle);

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", Enemies.Feaster, Enemies.Feaster);
            med.AddRandomGroup("Nume_EN", Jumble.Red, Jumble.Blue, Enemies.Accelerator);

            med = new AddTo(Orph.H.Whale.Med);
            med.SimpleAddGroup(2, "TheWhale_EN", 2, Enemies.Feaster, 1, Enemies.Suckle);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, Enemies.Alchemist, 1, Enemies.Accelerator, 1, Enemies.Suckle);

            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", Enemies.Accelerator, "TheWhale_EN");

            hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", Enemies.Accelerator, Enemies.Camera);

            med = new AddTo(Orph.H.MusicMan.Med);
            med.AddRandomGroup("MusicMan_EN", "MusicMan_EN", Enemies.Shooter, Enemies.Alchemist);

            med = new AddTo(Orph.H.Shuffler.Med);
            med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, "Enigma_EN", Enemies.Accelerator);

            med = new AddTo(Orph.H.Colophon.Yellow.Med);
            med.AddRandomGroup(Colophon.Yellow, "Enigma_EN", "Enigma_EN", Enemies.Accelerator);

            med = new AddTo(Orph.H.Colophon.Purple.Med);
            med.AddRandomGroup(Colophon.Purple, "Spectre_EN", "Spectre_EN", Enemies.Accelerator);

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", Enemies.Accelerator, Bots.Red, Enemies.Suckle);

            hard = new AddTo(Orph.H.Heehoo.Hard);
            hard.AddRandomGroup("Heehoo_EN", "Solitaire_EN", "Solitaire_EN", Enemies.Alchemist);

            EcstasyPool.Add(Enemies.Feaster);
            EcstasyPool.Add(Enemies.Alchemist);
            EcstasyPool.Add(Enemies.Accelerator);
            EcstasyPool.Add("GalvanizedGuzzler_EN");
            EcstasyPool.Add("IridescentKnight_EN");
        }
    }
}
