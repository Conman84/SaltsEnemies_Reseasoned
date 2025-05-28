using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class NamelessEncounters
    {
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Something_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Jumble.Blue, "Nameless_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Delusion.Med);
            med.SimpleAddGroup(3, "Delusion_EN", 1, "FakeAngel_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "LostSheep_EN", "Nameless_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.SimpleAddGroup(1, "WindSong_EN", 1, "Nameless_EN", 3, "MusicMan_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Nameless_EN", Flower.Purple);

            med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(4, "MusicMan_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, "Nameless_EN", "Something_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Nameless_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", Enemies.Camera, Enemies.Camera, "Nameless_EN");
        }
    }
}
