using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned.SendingOver17
{
    public class AbilitySelector_EvilEye : AbilitySelector_ByRarity
    {
        public static string value => "Eyeball_Selector_A";
        public override bool UsesRarity => false;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            if (CombatManager.Instance._stats.IsPassiveLocked("Cyclical_PA")) return base.GetNextAbilitySlotUsage(abilities, unit);
            int ret = -1;
            if (unit is EnemyCombat enemy)
            {
                switch (enemy.SimpleGetStoredValue(value))
                {
                    case 0:
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter One");
                        enemy.SimpleSetStoredValue(value, 1);
                        break;
                    case 1:
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter Two");
                        enemy.SimpleSetStoredValue(value, 2);
                        break;
                    case 2:
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter Three");
                        enemy.SimpleSetStoredValue(value, 3);
                        break;
                    case 3:
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter Four");
                        enemy.SimpleSetStoredValue(value, 4);
                        break;
                    case 4:
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter Five");
                        enemy.SimpleSetStoredValue(value, 0);
                        break;
                }
            }
            if (ret >= 0) return ret;
            else return base.GetNextAbilitySlotUsage(abilities, unit);
        }

    }
}
