using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class LovelyPassive : PerformEffectPassiveAbility
    {
        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck);
        }
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.AttacksPerTurn.ToString() || name == TriggerCalls.ExtraAdditionalAttacks.ToString())
            {
                if (sender is EnemyCombat enemy && enemy.ContainsPassiveAbility("Lovely_PA") && !CombatManager.Instance._stats.IsPassiveLocked("Lovely_PA"))
                {
                    if (args is IntegerReference reference)
                    {
                        reference.value = 0;
                    }
                    if (args is List<string> list)
                    {
                        list.Clear();

                        foreach (CombatAbility abil in enemy.Abilities)
                        {
                            list.Add(abil.ability.name);
                        }
                    }
                }
            }
        }
    }

    public class NotSpawnedInCondition : EffectorConditionSO
    {
        public static string Value => "CorpseChan_PA";
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference && effector is IUnit unit)
            {
                unit.SimpleSetStoredValue(Value, 1);
                return false;
            }
            return (effector as IUnit).SimpleGetStoredValue(Value) > 0;
        }
    }
}
