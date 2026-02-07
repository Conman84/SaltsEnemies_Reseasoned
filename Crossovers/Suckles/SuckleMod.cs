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
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "Sigil_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "Wednesday_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "Enigma_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, "Enigma_EN", "Enigma_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Feaster, Bots.Red);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Feaster, Bots.Yellow);
            med.AddRandomGroup(Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist, "TheWhale_EN");

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
            med.AddRandomGroup("Evileye_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist);
            med.AddRandomGroup("Evileye_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Accelerator);

            easy = new AddTo(Orph.H.Something.Easy);
            easy.AddRandomGroup("Something_EN", Enemies.Feaster);

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Enemies.Feaster, Enemies.Alchemist);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist);
            med.AddRandomGroup("TheCrow_EN", Spoggle.Red, Enemies.Accelerator, Enemies.Accelerator);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist);
            med.AddRandomGroup("Freud_EN", Enemies.Shooter, Enemies.Alchemist);

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Feaster, Enemies.Feaster);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Accelerator, "Scrungie_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "FakeAngel_EN", Enemies.Accelerator);

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist);
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
        }
    }
}
