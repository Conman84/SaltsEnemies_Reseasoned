using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MaceratorCrossovers
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Shore.H.Macerator.Easy);
            easy.SimpleAddGroup(2, "Macerator_EN", 1, "LostSheep_EN");
            EcstasyPool.Add("Macerator_EN");
            //i wanted to add them to a bunch of other encounters but it doesnt seem like theyre really supposed to exist outside of their 1 rarity easy encounter.
        }
    }
}
