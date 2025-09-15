using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class RestrictorEffectWearable : MultiPerformEffectWearable
    {
        public StatusEffect_SO Status;
        public override void OnTriggerAttachedAction(IWearableEffector caller)
        {
            base.OnTriggerAttachedAction(caller);
            if (Status == null) return;
            CombatManager.Instance.AddSubAction(new SubActionAction(new SERestrictorItemConnectedAction(caller.ID, GetItemLocData().text, wearableImage, Status)));
        }
        public override void OnTriggerDettachedAction(IWearableEffector caller)
        {
            base.OnTriggerDettachedAction(caller);
            if (Status == null) return;
            CombatManager.Instance.AddSubAction(new SubActionAction(new SERestrictorItemDisconnectedAction(caller.ID, Status)));
        }
    }

    public class SERestrictorItemConnectedAction : CombatAction
    {
        public int _unitID;

        public string _itemLocName;

        public Sprite _itemSprite;

        public StatusEffect_SO _Status;

        public SERestrictorItemConnectedAction(int unitID, string itemLocName, Sprite itemSprite, StatusEffect_SO status)
        {
            _unitID = unitID;
            _itemLocName = itemLocName;
            _itemSprite = itemSprite;
            _Status = status;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            IUnit unit = stats.TryGetCharacterOnField(_unitID);
            if (unit != null && unit.IsAlive)
            {
                ShowItemInformationUIAction showPassiveInformationUIAction = new ShowItemInformationUIAction(_unitID, _itemLocName, false, _itemSprite);
                yield return showPassiveInformationUIAction.Execute(stats);
                unit.ApplyStatusEffect(_Status, 0, 1);
            }
        }
    }
    public class SERestrictorItemDisconnectedAction : CombatAction
    {
        public int _toID;

        public StatusEffect_SO _Status;

        public SERestrictorItemDisconnectedAction(int toID, StatusEffect_SO status)
        {
            _toID = toID;
            _Status = status;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            IUnit unit = stats.TryGetCharacterOnField(_toID);
            if (unit != null && unit.IsAlive)
            {
                unit.DettachStatusRestrictor(_Status.StatusID);
            }

            yield break;
        }
    }
}
