using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using Tools;
using UnityEngine;

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

    public class HasNoAbilitiesLeftCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            CombatStats stats = CombatManager.Instance._stats;

            if (effector is EnemyCombat enemy && enemy.TurnsInTimeline > 0)
            {
                for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
                {
                    if (stats.timeline.Round[i].isPlayer) continue;

                    if (stats.timeline.Round[i].turnUnit == enemy)
                    {
                        return false;
                    }
                }
            }

            if (effector.IsUnitCharacter && stats.IsPlayerTurn) return false;

            return true;
        }
    }
    public class OncePerRoundCondition : EffectorConditionSO
    {
        public string value => "OncePerRoundCondition";
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector.IsUnitCharacter) return true;

            if (args is IntegerReference reference && effector is IUnit unit)
            {
                unit.SimpleSetStoredValue(value, 1);
                return false;
            }

            if (effector is IUnit unt && unt.SimpleGetStoredValue(value) > 0)
            {
                unt.SimpleSetStoredValue(value, 0);
                return true;
            }

            return false;
        }
    }
}
