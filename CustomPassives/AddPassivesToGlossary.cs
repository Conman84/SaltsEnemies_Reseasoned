using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    internal class AddPassivesToGlossary
    {
        public static void AddPassive(Sprite sprite, string Name, string Description)
        {
            GlossaryPassives glossaryPassives = new GlossaryPassives(Name, Description, sprite);
            LoadedDBsHandler.GlossaryDB.AddNewPassive(glossaryPassives);
        }
    }
}
