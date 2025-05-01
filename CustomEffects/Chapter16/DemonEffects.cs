using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class WeaknessHandler
    {
        public static string Passive => "Demon_Weakness_PA";
        public static void NotifCheck(string notifname, object sender, object args)
        {
            if (notifname != TriggerCalls.OnBeingDamaged.ToString()) return;
            if (sender is IUnit unit && args is DamageReceivedValueChangeException hitBy)
            {
                int mod = 1;
                List<int> ids = new List<int>();
                List<bool> charas = new List<bool>();
                List<string> names = new List<string>();
                List<Sprite> icons = new List<Sprite>();

                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.TryGetPassiveAbility(Passive, out BasePassiveAbilitySO ret))
                    {
                        mod *= 2;
                        ids.Add(enemy.ID);
                        charas.Add(false);
                        names.Add(ret._passiveName);
                        icons.Add(ret.passiveIcon);
                    }
                }

                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    if (chara.TryGetPassiveAbility(Passive, out BasePassiveAbilitySO ret))
                    {
                        mod *= 2;
                        ids.Add(chara.ID);
                        charas.Add(true);
                        names.Add(ret._passiveName);
                        icons.Add(ret.passiveIcon);
                    }
                }

                if (ids.Count <= 0) return;

                hitBy.AddModifier(new MultiplyIntValueModifier(false, mod));

                CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(ids.ToArray(), charas.ToArray(), names.ToArray(), icons.ToArray()));
            }
        }
        public static void Setup() => NotificationHook.AddAction(NotifCheck);
    }
}
