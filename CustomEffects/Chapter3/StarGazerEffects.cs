using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class InvinciblePassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 0;


        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            //Debug.Log("passive started");
            IUnit unit = sender as IUnit;

            if (args is DamageReceivedValueChangeException HitBy && HitBy.amount > 0)
            {
                if (args is DamageReceivedValueChangeException && !(args as DamageReceivedValueChangeException).Equals((object)null))
                {
                    (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new InvincibleValueModifier(this._modifyVal));
                    (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new ImmZeroMod());
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, GetPassiveLocData().text, this.passiveIcon));

                }

            }


        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class InvincibleValueModifier : IntValueModifier
    {
        public readonly int FVAL;

        public InvincibleValueModifier(int exitVal)
          : base(999)
        {
            this.FVAL = exitVal;
        }

        public override int Modify(int value)
        {
            if (value > 0 && value >= this.FVAL)
            {
                value = this.FVAL;
            }
            return value;
        }
    }
}