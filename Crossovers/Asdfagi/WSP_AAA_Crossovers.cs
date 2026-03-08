using System;
using System.Collections.Generic;
using System.Text;

//WinterLantern_EN

//SomeoneSister_EN
//NooneSister_EN

//Phobia_Phobias_EN

namespace SaltsEnemies_Reseasoned
{
    public static class WSP_AAA_Crossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Siren.H.Ecstasy.Red.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Random, "BirdBath_EN", "WinterLantern_EN");
            med = new AddTo(Siren.H.Ecstasy.Blue.Med);
            med.AddRandomGroup(Ecstasy.Blue, Ecstasy.Red, "BirdBath_EN", "WinterLantern_EN");
            med = new AddTo(Siren.H.Ecstasy.Yellow.Med);
            med.AddRandomGroup(Ecstasy.Yellow, Ecstasy.Red, "BirdBath_EN", "WinterLantern_EN");
            med = new AddTo(Siren.H.Ecstasy.Purple.Med);
            med.AddRandomGroup(Ecstasy.Purple, Ecstasy.Red, "BirdBath_EN", "WinterLantern_EN");

            med = new AddTo(Siren.H.Winterlantern.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("WinterLantern_EN", Ecstasy.Random, "Stalker2_EN");
            else med.AddRandomGroup("WinterLantern_EN", "Tassnn_EN", "Stalker2_EN");

        }
    }
}
