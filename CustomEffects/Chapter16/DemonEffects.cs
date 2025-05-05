using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

//call weaknesshandelr.setup in awake

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
                if (unit.ContainsPassiveAbility(Passive)) return;
                int mod = 1;
                List<int> ids = new List<int>();
                List<bool> charas = new List<bool>();
                List<string> names = new List<string>();
                List<Sprite> icons = new List<Sprite>();

                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.TryGetPassiveAbility(Passive, out BasePassiveAbilitySO ret))
                    {
                        if (!enemy.HealthColor.SharesPigmentColor(unit.HealthColor)) continue;
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
                        if (!chara.HealthColor.SharesPigmentColor(unit.HealthColor)) continue;
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
    public class RandomizeTargetHealthColorEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    IUnit unit = target.Unit;
                    List<ManaColorSO> colors = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Grey };
                    if (unit is EnemyCombat enemy && !colors.Contains(enemy.Enemy.healthColor)) colors.Add(enemy.Enemy.healthColor);
                    else if (unit is CharacterCombat chara && !colors.Contains(chara.Character.healthColor)) colors.Add(chara.Character.healthColor);
                    if (colors.Contains(unit.HealthColor)) colors.Remove(unit.HealthColor);
                    if (unit.ChangeHealthColor(colors.GetRandom())) exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
}
