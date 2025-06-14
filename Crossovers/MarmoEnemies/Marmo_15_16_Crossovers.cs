using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Marmo_15_16_Crossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Romantic_EN");
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Surrogate_EN");

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Romantic_EN");
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Surrogate_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Romantic_EN");
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Surrogate_EN");

            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Romantic_EN");
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Surrogate_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Gungrot_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Crystal_EN", "MusicMan_EN", "Romantic_EN");
            med.AddRandomGroup("Crystal_EN", "Enigma_EN", "Enigma_EN", "Romantic_EN");
            med.AddRandomGroup("Crystal_EN", "Surrogate_EN", "TheCrow_EN");
            med.AddRandomGroup("Crystal_EN", "Sigil_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Crystal_EN", "Surrogate_EN", "Romantic_EN");
            med.AddRandomGroup("Crystal_EN", "WindSong_EN", "Surrogate_EN");
            med.AddRandomGroup("Crystal_EN", "Romantic_EN", "Something_EN");
            med.AddRandomGroup("Crystal_EN", "Gungrot_EN", "Gungrot_EN", Jumble.Blue);
            med.AddRandomGroup("Crystal_EN", "Gungrot_EN", "Gungrot_EN", Jumble.Purple);
            med.AddRandomGroup("Crystal_EN", "Gungrot_EN", "Gungrot_EN", Spoggle.Unstable);
            med.AddRandomGroup("Crystal_EN", "Crystal_EN", Jumble.Unstable);

            AddTo hard = new AddTo(Orph.H.Dragon.Hard);
            hard.SimpleAddGroup(1, "TheDragon_EN", 3, "Romantic_EN");
            hard.AddRandomGroup("TheDragon_EN", "Romantic_EN", "Maw_EN");
            hard.AddRandomGroup("TheDragon_EN", "Surrogate_EN", "Crystal_EN");
            hard.AddRandomGroup("TheDragon_EN", "Gungrot_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("TheDragon_EN", "Romantic_EN", Jumble.Purple, Jumble.Unstable);
            hard.AddRandomGroup("TheDragon_EN", Spoggle.Unstable, "WindSong_EN");

            AddTo easy = new AddTo(Orph.H.Jumble.Unstable.Easy);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup(Jumble.Unstable, Jumble.Red, "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup(Jumble.Unstable, Jumble.Yellow, "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            easy = new AddTo(Orph.H.Spoggle.Unstable.Easy);
            if (SaltsReseasoned.silly > 50) easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Blue, "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");
        }
    }
}
