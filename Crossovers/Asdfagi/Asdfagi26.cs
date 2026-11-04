using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.AI;


//Bloatfinger_EN (30 red)
//UttershroomSpore_EN
//Blemmigan_EN
//yellow aggregate


//SomeoneSister_EN
//NooneSister_EN

//Phobia_Phobias_EN

namespace SaltsEnemies_Reseasoned
{
    public static class Asdfagi26
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Bloatfinger.Med);
            med.SimpleAddGroup(2, "Bloatfinger_EN", 1, "Melder_EN");

            med = new AddTo(Orph.H.Melder.Med);
            med.SimpleAddGroup(2, "Melder_EN", 1, "Bloatfinger_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", Aggregates.Yellow, Enemies.Solvent);
            med.AddRandomGroup("ILoveYou_EN", "Bloatfinger_EN", "Nameless_EN");

            AddTo hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.AddRandomGroup("ILoveYou_EN", "UttershroomSpore_EN", "Blemmigan_EN", "Blemmigan_EN");
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, "Bloatfinger_EN");
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, Aggregates.Yellow);

            //garden

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, Enemies.MainSister, Enemies.SubSister);
            med.AddRandomGroup(Enemies.Eclipse, "SomeoneSister_EN", "Indicator_EN");
            med.AddRandomGroup(Enemies.Eclipse, "SomeoneSister_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 1, "SomeoneSister_EN");
            
            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 1, "SomeoneSister_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.AddRandomGroup(Enemies.Eclipse, Enemies.Eclipse, Enemies.MainSister);
            hard.AddRandomGroup(Enemies.Eclipse, "NooneSister", "Celebration_EN");

            hard = new AddTo(Garden.H.Celebration.Med);
            hard.SimpleAddGroup(2, "Celebration_EN", 1, "NooneSister_EN");

            med = new AddTo(Garden.H.Sisters.Med);
            med.AddRandomGroup(Enemies.MainSister, "SomeoneSister_EN", "Celebration_EN");
            med.AddRandomGroup(Enemies.MainSister, "SomeoneSister_EN", "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.Sisters.Hard);
            hard.AddRandomGroup(Enemies.MainSister, "InHisImage_EN", "InHerImage_EN", "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Phobia.Med);
            med.AddRandomGroup(Enemies.Phobia, Enemies.Eclipse, "BlackStar_EN");
            med.AddRandomGroup(Enemies.Phobia, "Celebration_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Phobia, "Lightbulbkin_EN", "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.Phobia.Hard);
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, "Celebration_EN");
            hard.SimpleAddGroup(1, Enemies.Phobia, 2, "Celebration_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, Enemies.Eclipse);
            hard.AddRandomGroup(Enemies.Phobia, "Lightbulbkin_EN", "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomGroup(Enemies.Phobia, "Lightbulbkin_EN", "InHerImage_EN", "InHerImage_EN");
        }
    }
}
