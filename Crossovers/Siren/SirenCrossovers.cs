using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SirenCrossovers
    {
        public static void Add()
        {
            Add_Scuttlebunk();
            Add_Tortures();
        }
        public static void Add_Scuttlebunk()
        {
            AddTo med = new AddTo(Siren.H.Scuttle.Med);
            med.AddRandomGroup("Scuttlebunk_EN", "Stalker2_EN", "Stalker2_EN");

            AddTo hard = new AddTo(Siren.H.Scuttle.Hard);
            hard.AddRandomGroup("Scuttlebunk_EN", Ecstasy.Random, Ecstasy.Random);
            hard.AddRandomGroup("Scuttlebunk_EN", "WolfColony_EN", "WolfColony_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("Scuttlebunk_EN", Ecstasy.Random, "Tassnn_EN");
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Scuttlebunk_EN", Ecstasy.Random, "Tumult_EN");
        }
        public static void Add_Tortures()
        {
            AddTo med = new AddTo(Siren.H.Ecstasy.Red.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Random, Ecstasy.Random, "TortureMeNot_EN");
            med = new AddTo(Siren.H.Ecstasy.Yellow.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Yellow, Ecstasy.Random, "TortureMeNot_EN");
            med = new AddTo(Siren.H.Ecstasy.Blue.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Blue, Ecstasy.Random, "TortureMeNot_EN");
            med = new AddTo(Siren.H.Ecstasy.Purple.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Purple, Ecstasy.Random, "TortureMeNot_EN");

            med = new AddTo(Siren.H.Wolf.Med);
            med.SimpleAddGroup(2, "WolfColony_EN", 2, "TortureMeNot_EN");

            AddTo hard = new AddTo(Siren.H.Piscina.Hard);
            if (SaltsReseasoned.rando < 40) hard.SimpleAddGroup(1, "LivingPiscina_EN", 3, "TortureMeNot_EN");

            AddTo easy = new AddTo(Siren.H.Tumult.Easy);
            easy.AddRandomGroup("Tumult_EN", "Tumult_EN", "TortureMeNot_EN");
            med = new AddTo(Siren.H.Tumult.Med);
            if (SaltsReseasoned.trolling < 50) med.SimpleAddGroup(3, "Tumult_EN", 2, "TortureMeNot_EN");

            easy = new AddTo(Siren.H.Boiler.Easy);
            easy.AddRandomGroup("Boiler_EN", "Boiler_EN", "TortureMeNot_EN");
            med = new AddTo(Siren.H.Boiler.Med);
            if (SaltsReseasoned.trolling > 50) med.SimpleAddGroup(3, "Boiler_EN", 2, "TortureMeNot_EN");

            easy = new AddTo(Siren.H.Tassnn.Easy);
            easy.AddRandomGroup("Tassnn", "Tassnn", "TortureMeNot_EN");
            med = new AddTo(Siren.H.Tassnn.Med);
            if (SaltsReseasoned.silly > 50) med.SimpleAddGroup(2, "Tassnn", 2, "TortureMeNot_EN", 1, Ecstasy.Random);
            if (SaltsReseasoned.silly < 50) med.SimpleAddGroup(2, "Tassnn", 2, "TortureMeNot_EN", 1, "Boiler_EN");

            med = new AddTo(Siren.H.Olmic.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Olmic_EN", "Boiler_EN", "Boiler_EN", "TortureMeNot_EN");

            hard = new AddTo(Siren.H.Olmic.Hard);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Olmic_EN", Ecstasy.Random, Ecstasy.Random, "TortureMeNot_EN");

            hard = new AddTo(Siren.H.Phalaris.Hard);
            hard.AddRandomGroup(Enemies.Phalaris, "Tassnn_EN", "Tassnn_EN", "TortureMeNot_EN");
            hard.AddRandomGroup(Enemies.Phalaris, "Stalker2_EN", "TortureMeNot_EN", "TortureMeNot_EN", "Tassnn_EN");

            med = new AddTo(Siren.H.Scuttle.Med);
            med.AddRandomGroup("Scuttlebunk_EN", "TortureMeNot_EN", "TortureMeNot_EN");
        }
    }
}
