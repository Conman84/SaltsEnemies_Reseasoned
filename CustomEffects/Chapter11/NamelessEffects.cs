using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class AbilitySelector_Nameless : AbilitySelector_ByRarity
    {
        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int num = base.GetNextAbilitySlotUsage(abilities, unit);
            if (num >= 0)
            {
                if (abilities[num].ability.name == "TheVolumeOfABeatingHeart_A")
                {
                    NamelessHandler.CreateFile();
                }
            }
            return num;
        }
    }
}
