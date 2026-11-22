using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Crossovers_Marmo_EggKeeper_6_7_8
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Orph.H.Jumble.Unstable.Easy);
            easy.AddRandomGroup(Jumble.Unstable, Jumble.Yellow, "LivingSolvent_EN");

            easy = new AddTo(Orph.H.Solvent.Easy);
            easy.AddRandomGroup("LivingSolvent_EN", Jumble.Unstable, Jumble.Yellow);

            easy = new AddTo(Orph.H.Delusion.Easy);
            easy.AddRandomGroup("Delusion_EN", Jumble.Unstable, "FakeAngel_EN");
            easy.AddRandomGroup("Delusion_EN", Spoggle.Unstable, "FakeAngel_EN");

            AddTo med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Jumble.Unstable, "FakeAngel_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Jumble.Unstable, "WindSong_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Spoggle.Unstable, "FakeAngel_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Spoggle.Unstable, "LivingSolvent_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Romantic_EN", "FakeAngel_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Romantic_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "MusicMan_EN", "MusicMan_EN", Jumble.Unstable);
            med.AddRandomGroup("Sigil_EN", "MusicMan_EN", "MusicMan_EN", Jumble.Unstable, "SingingStone_EN");
            med.AddRandomGroup("Sigil_EN", "MusicMan_EN", "MusicMan_EN", Spoggle.Unstable);
            med.AddRandomGroup("Sigil_EN", "Delusion_EN", "Delusion_EN", Spoggle.Unstable, "FakeAngel_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "MusicMan_EN", "MusicMan_EN", Jumble.Unstable);
            med.AddRandomGroup("WindSong_EN", Jumble.Blue, Jumble.Unstable, "MusicMan_EN");
            med.AddRandomGroup("WindSong_EN", "MusicMan_EN", "MusicMan_EN", Spoggle.Unstable);
            med.AddRandomGroup("WindSong_EN", Spoggle.Red, Spoggle.Unstable, "SilverSuckle_EN", "SilverSuckle_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "WindSong_EN", Jumble.Unstable, Jumble.Yellow);
            med.AddRandomGroup("Freud_EN", Spoggle.Unstable, "WindSong_EN", "SilverSuckle_EN", "SilverSuckle_EN");
            med.AddRandomGroup("Freud_EN", "Sigil_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "LivingSolvent_EN", Jumble.Unstable);
            med.AddRandomGroup("TheCrow_EN", Spoggle.Unstable, "LivingSolvent_EN");
            med.AddRandomGroup("TheCrow_EN", "WindSong_EN", "Surrogate_EN");
            med.AddRandomGroup("TheCrow_EN", "Gungrot_EN", "Gungrot_EN", "WindSong_EN");

            AddTo hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "WindSong_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", Jumble.Unstable, "LivingSolvent_EN");
            med.AddRandomGroup("Conductor_EN", Jumble.Unstable, "Sigil_EN", "SilverSuckle_EN", "SilverSuckle_EN");

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Unstable, "LivingSolvent_EN");
            med.AddRandomGroup(Jumble.Blue, "WindSong_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, Jumble.Unstable, "LivingSolvent_EN");

            easy = new AddTo(Orph.H.Spoggle.Unstable.Easy);
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Blue, "LivingSolvent_EN");
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Blue, "LivingSolvent_EN");

            easy = new AddTo(Orph.H.Solvent.Easy);
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup("LivingSolvent_EN", Spoggle.Unstable, Spoggle.Yellow);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup("LivingSolvent_EN", Spoggle.Unstable, Spoggle.Blue);

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Spoggle.Unstable, "LivingSolvent_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, Spoggle.Unstable, Spoggle.Purple, "WindSong_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", Spoggle.Unstable, "WindSong_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Unstable, "WindSong_EN", "SilverSuckle_EN", "SilverSuckle_EN");

            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Purple, Spoggle.Unstable, "WindSong_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "Romantic_EN", "LivingSolvent_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Romantic_EN", "FakeAngel_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Flower.Yellow, "MusicMan_EN", "MusicMan_EN", "Romantic_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Flower.Yellow, "Enigma_EN", "Enigma_EN", "Romantic_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, Flower.Yellow, "Romantic_EN", "FakeAngel_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Flower.Purple, "MusicMan_EN", "MusicMan_EN", "Romantic_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Flower.Purple, "Enigma_EN", "Enigma_EN", "Romantic_EN");

            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Blue, Flower.Red, "Romantic_EN");

            easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.AddRandomGroup(Flower.Red, Flower.Blue, "Romantic_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, "InHerImage_EN", "InHerImage_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, "InHisImage_EN", "InHisImage_EN", "Romantic_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, Enemies.Shivering, "Romantic_EN");
            hard.AddRandomGroup("ClockTower_EN", Enemies.Minister, Enemies.Minister, "Romantic_EN");
            hard.AddRandomGroup("ClockTower_EN", "ChoirBoy_EN", "Surrogate_EN", "Surrogate_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Romantic_EN", "Romantic_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "WindSong_EN", "Romantic_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Sigil_EN", "Romantic_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Enemies.Solvent, "Romantic_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Flower.Yellow, "Romantic_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Flower.Purple, "Romantic_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup(Enemies.Sacrifice, Flower.Yellow, Flower.Purple, "Romantic_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Revola_EN", Flower.Yellow, "Romantic_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("Revola_EN", Flower.Purple, "Romantic_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("Conductor_EN", Flower.Yellow, Flower.Purple, "Romantic_EN");
            hard.AddRandomGroup("Conductor_EN", "Surrogate_EN", "WindSong_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Delusion_EN", "Surrogate_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Delusion_EN", "Delusion_EN", Flower.Yellow, "Surrogate_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Delusion_EN", "Delusion_EN", Flower.Purple, "Surrogate_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "WindSong_EN", "Surrogate_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Surrogate_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Gungrot_EN", "Gungrot_EN");
            med = new AddTo(Orph.H.Flower.Purple.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Flower.Purple, Flower.Yellow, "Surrogate_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Flower.Purple, Flower.Yellow, "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "Delusion_EN", "Delusion_EN", "Surrogate_EN");

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, "Surrogate_EN", "Delusion_EN", "Delusion_EN");

            easy = new AddTo(Orph.H.Flower.Yellow.Easy);
            easy.AddRandomGroup(Flower.Yellow, "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Something_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("WindSong_EN", "Gungrot_EN", "Gungrot_EN", "Scrungie_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("WindSong_EN", Jumble.Purple, "Gungrot_EN", "Gungrot_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("WindSong_EN", Jumble.Blue, "Gungrot_EN", "Gungrot_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("WindSong_EN", Flower.Yellow, "Gungrot_EN", "Gungrot_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("WindSong_EN", Flower.Purple, "Gungrot_EN", "Gungrot_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "Delusion_EN", "Delusion_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", "Sigil_EN", "SilverSuckle_EN", "SilverSuckle_EN", "SilverSuckle_EN");
            med.AddRandomGroup("Errant_EN", "Sigil_EN", "Gungrot_EN", "Gungrot_EN");

            hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", "WindSong_EN", "SilverSuckle_EN", "SilverSuckle_EN", "SilverSuckle_EN");
            hard.AddRandomGroup("Errant_EN", "WindSong_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("Errant_EN", "WindSong_EN", "Romantic_EN");
            hard.AddRandomGroup("Errant_EN", "Something_EN", "Sigil_EN");

            easy = new AddTo(Garden.H.Git.Easy);
            easy.AddRandomGroup("WindSong_EN", "Git_EN", "Git_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Git_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, Flower.Red, "Git_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Flower.Blue, "Git_EN");
            med.AddRandomGroup("Satyr_EN", Flower.Red, "Git_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Git_EN", "Git_EN");
            hard.AddRandomGroup(Enemies.Tank, "Attrition_EN");
            hard.AddRandomGroup(Enemies.Tank, "EggKeeper_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Git_EN", "Git_EN", Flower.Red);
            hard.AddRandomGroup("ClockTower_EN", "Attrition_EN", "Attrition_EN", "Attrition_EN");
            hard.AddRandomGroup("ClockTower_EN", "Attrition_EN", Flower.Red, Flower.Blue);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, Enemies.Skinning, "EggKeeper_EN");
            hard.AddRandomGroup("ClockTower_EN", Enemies.Minister, "ChoirBoy_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", Flower.Red, "Git_EN");
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", Flower.Red, "EggKeeper_EN");
            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", Flower.Blue, "Git_EN");
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", Flower.Blue, "EggKeeper_EN");

            easy = new AddTo(Garden.H.Attrition.Easy);
            easy.AddRandomGroup("Attrition_EN", "Attrition_EN", "WindSong_EN");

            med = new AddTo(Garden.H.Attrition.Med);
            med.AddRandomGroup("Attrition_EN", "Attrition_EN", "Attrition_EN", Flower.Blue);
            med.AddRandomGroup("Attrition_EN", "Attrition_EN", "Attrition_EN", Flower.Red);

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Attrition_EN", Flower.Blue);
            hard.AddRandomGroup("Satyr_EN", "Attrition_EN", Flower.Red);

            med = new AddTo(Garden.H.EggKeeper.Med);
            med.AddRandomGroup("EggKeeper_EN", "ChoirBoy_EN", "WindSong_EN");

            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup(Flower.Red, Flower.Blue, "EggKeeper_EN");
            easy = new AddTo(Garden.H.Flower.Red.Easy);
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup(Flower.Red, Flower.Blue, "EggKeeper_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Enemies.Minister, Flower.Blue, "EggKeeper_EN");
        }
    }
}
