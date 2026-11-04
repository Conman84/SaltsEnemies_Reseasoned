using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SuckleModUpdate26
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Melder.Med);
            med.AddRandomGroup("Melder_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Melder_EN", "Melder_EN", Enemies.Feaster, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Melder_EN", Enemies.Alchemist, Enemies.Feaster, Enemies.Feaster);
            med.AddRandomGroup("Melder_EN", "Melder_EN", Enemies.Feaster, Enemies.Accelerator);

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("ILoveYou_EN", Enemies.Feaster, Enemies.Feaster, Enemies.Alchemist);
            med.AddRandomGroup("ILoveYou_EN", Enemies.Alchemist, Enemies.Suckle, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("ILoveYou_EN", Enemies.Accelerator, Enemies.Accelerator, "MusicMan_EN");
            med.AddRandomGroup("ILoveYou_EN", Enemies.Accelerator, Enemies.Feaster);

            AddTo hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.SimpleAddGroup(2, "ILoveYou_EN", 2, Enemies.Accelerator);
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, Enemies.Feaster, 2, Enemies.Suckle);
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, Enemies.Alchemist, 2, Enemies.Suckle);
        }
    }
}
