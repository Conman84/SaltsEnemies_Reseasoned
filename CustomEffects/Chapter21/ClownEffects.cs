using BrutalAPI;
using JetBrains.Annotations;
using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class ClownPassiveAbility : PerformEffectPassiveAbility
    {
        public static TriggerCalls Trigger => (TriggerCalls)1207959;
        public static bool Set;
        public static void Setup()
        {
            if (Set) return;
            Set = true;
            NotificationHook.AddAction(NotifCheck);
        }
        public static void NotifCheck(string notifname, object sender, object args)
        {
            if (notifname == TriggerCalls.OnDirectDamaged.ToString())
            {
                if (sender is IUnit unit && !CombatManager.Instance._stats.IsPassiveLocked(PassiveType_GameIDs.Infantile.ToString()))
                {
                    if (unit.IsUnitCharacter)
                    {
                        foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                            CombatManager.Instance.PostNotification(Trigger.ToString(), chara, unit);
                    }
                    else
                    {
                        foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                            CombatManager.Instance.PostNotification(Trigger.ToString(), enemy, unit);
                    }
                }
            }
        }
    }
    public class AbilitySelector_Clown : AbilitySelector_ByRarity
    {
        public string Ability;
        public string CheckPassive;
        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                if (enemy.ContainsPassiveAbility(CheckPassive)) return base.GetNextAbilitySlotUsage(abilities, unit);
            }

            int ret = (unit as EnemyCombat).GetLastAbilityIDFromName(Ability);
            if (ret > -1) return ret;

            return base.GetNextAbilitySlotUsage(abilities, unit);
        }
    }
    public class IsBlueEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.HealthColor == Pigments.Blue;
        }
    }
}
