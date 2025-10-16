using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class DistributeHealCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingReceivedValueChangeException reference && reference.directHealing)
            {
                (effector as IUnit).ShowItem();
                reference.AddModifier(new DistributeHealValueModifier(effector as IUnit));
            }
            return false;
        }
    }



    public class DistributeHealValueModifier : IntValueModifier
    {
        public readonly IUnit attackedUnit;

        public DistributeHealValueModifier(IUnit attackedUnit)
            : base(102)
        {
            this.attackedUnit = attackedUnit;
        }

        public override int Modify(int value)
        {
            IntegerReference integerReference = new IntegerReference(value);
            CombatManager.Instance.ProcessImmediateAction(new TriggerDistributeHealImmediateAction(attackedUnit, integerReference));
            return integerReference.value;
        }
    }
    public class TriggerDistributeHealImmediateAction : IImmediateAction
    {
        public IUnit _attackedUnit;

        public IntegerReference _damageReference;

        public TriggerDistributeHealImmediateAction(IUnit attackedUnit, IntegerReference damageReference)
        {
            _attackedUnit = attackedUnit;
            _damageReference = damageReference;
        }

        public void Execute(CombatStats stats)
        {
            List<IUnit> list = new List<IUnit>();
            if (_attackedUnit.IsUnitCharacter)
            {
                foreach (CharacterCombat value in stats.CharactersOnField.Values)
                {
                    if (value.IsAlive && value.ID != _attackedUnit.ID && value.CurrentHealth > 0)
                    {
                        list.Add(value);
                    }
                }
            }
            else
            {
                foreach (EnemyCombat value2 in stats.EnemiesOnField.Values)
                {
                    if (value2.IsAlive && value2.ID != _attackedUnit.ID)
                    {
                        list.Add(value2);
                    }
                }
            }

            if (list.Count > 0)
            {
                float num = _damageReference.value;
                while (list.Count > 0 && num > 0f)
                {
                    int num2 = Mathf.CeilToInt(num / (float)list.Count);
                    int index = UnityEngine.Random.Range(0, list.Count);
                    IUnit unit = list[index];
                    list.RemoveAt(index);
                    unit.Heal(num2, null, false);
                    num -= (float)num2;
                }

                _damageReference.value = 0;
            }
        }
    }
}
