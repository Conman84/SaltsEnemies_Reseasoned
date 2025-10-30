using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoneds
{
    public static class MiscCrossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Nameless.Med);
            med.SimpleAddGroup(2, "Nameless_EN", 2, "Frostbite_EN");
            med.SimpleAddGroup(2, "Nameless_EN", 2, "Moone_EN");
            med.AddRandomEncounter("Nameless_EN", "Nameless_EN", "BackupDancer_EN", "MusicMan_EN");
            med.AddRandomEncounter("Nameless_EN", "Gungrot_EN", "Gungrot_EN", "Spectre_EN");
        }
    }
}
