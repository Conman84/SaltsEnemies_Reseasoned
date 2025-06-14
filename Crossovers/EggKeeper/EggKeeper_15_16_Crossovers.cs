using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EggKeeper_15_16_Crossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Garden.H.GreyBot.Med);
            med.SimpleAddGroup(1, Bots.Grey, 2, "InHisImage_EN", 1, "EggKeeper_EN");
            med.SimpleAddGroup(1, Bots.Grey, 2, "InHerImage_EN", 1, "EggKeeper_EN");
            med.SimpleAddGroup(1, Bots.Grey, 2, "EyePalm_EN", 1, "EggKeeper_EN");

            AddTo hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "EggKeeper_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Shua_EN", "EggKeeper_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Grandfather_EN", "EggKeeper_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Firebird_EN", "EggKeeper_EN");

            AddTo easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "EggKeeper_EN", "TortureMeNot_EN");

            med = new AddTo(Garden.H.EggKeeper.Med);
            med.AddRandomGroup("ChoirBoy_EN", "EggKeeper_EN", "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Bots.Grey, "EggKeeper_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "EggKeeper_EN", "OdeToHumanity_EN");
        }
    }
}
