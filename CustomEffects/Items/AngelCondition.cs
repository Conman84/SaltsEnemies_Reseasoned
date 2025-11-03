using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class AngelCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException damage)
            {
                int num = 0;
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.UnitTypes != null && enemy.UnitTypes.Contains("Angel")) num += 2;
                }
                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    if ((chara.UnitTypes != null && chara.UnitTypes.Contains("Angel")) || (chara.HasUsableItem && chara.HeldItem.IsItemType("Angel"))) num += 2;
                }

                if (num > 0) (effector as IUnit).ShowItem();
                damage.AddModifier(new AdditionValueModifier(true, num));
                return true;
            }
            else if (args is HealingDealtValueChangeException heal)
            {
                int num = 0;
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.UnitTypes.Contains("Angel")) num += 2;
                }
                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    if (chara.UnitTypes.Contains("Angel") || (chara.HasUsableItem && chara.HeldItem.name.Contains("Salt_Angel"))) num += 2;
                }

                if (num > 0) (effector as IUnit).ShowItem();
                heal.AddModifier(new AdditionValueModifier(true, num));
                return true;
            }
            return false;
        }
    }
    public class OnlyPartyMemberCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return CombatManager.Instance._stats.CharactersOnField.Count <= 1;
        }
    }
}
