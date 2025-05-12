using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class MawCheckAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            BadDogHandler.RunCheckFunction(true);
            yield return null;
        }
    }
}
