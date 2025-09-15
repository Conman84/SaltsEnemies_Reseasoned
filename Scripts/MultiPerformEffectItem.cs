using BrutalAPI.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class MultiPerformEffectItem : PerformEffect_Item
    {
        public bool ConnectImmediate
        {
            set
            {
                (item as MultiPerformEffectWearable).ImmediateConnect = value;
            }
        }
        public bool DisconnectImmediate
        {
            set
            {
                (item as MultiPerformEffectWearable).ImmediateDisconnect = value;
            }
        }
        public EffectInfo[] AttachEffects
        {
            get
            {
                return (item as MultiPerformEffectWearable).ConnectionEffects;
            }
            set
            {
                (item as MultiPerformEffectWearable).ConnectionEffects = value;
            }
        }
        public EffectInfo[] DettachEffects
        {
            get
            {
                return (item as MultiPerformEffectWearable).DisconnectEffects;
            }
            set
            {
                (item as MultiPerformEffectWearable).DisconnectEffects = value;
            }
        }
        public MultiPerformEffectItem(string itemID = "DefaultID_Item", EffectInfo[] effects = null, bool immediate = false)
        {
            item = ScriptableObject.CreateInstance<MultiPerformEffectWearable>();
            item._immediateEffect = immediate;
            item.effects = effects;
            (item as MultiPerformEffectWearable).EffectTriggers = new List<EffectTrigger>();
            (item as MultiPerformEffectWearable).ConnectionEffects = [];
            (item as MultiPerformEffectWearable).DisconnectEffects = [];
            InitializeItemData(itemID);
        }
        public void AddEffectTrigger(EffectTrigger effect) => (item as MultiPerformEffectWearable).EffectTriggers.Add(effect);
    }

    public class MultiPerformEffectWearable : PerformEffectWearable
    {
        public List<EffectTrigger> EffectTriggers;

        public bool ImmediateConnect;
        public EffectInfo[] ConnectionEffects;

        public bool ImmediateDisconnect;
        public EffectInfo[] DisconnectEffects;

        public override void OnTriggerAttachedAction(IWearableEffector caller)
        {
            base.OnTriggerAttachedAction(caller);

            if (ConnectionEffects == null) return;

            if (ImmediateConnect)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(ConnectionEffects, caller as IUnit), addToPreInit: true);
            }
            else
            {
                CombatManager.Instance.AddSubAction(new EffectAction(ConnectionEffects, caller as IUnit));
            }
        }
        public override void OnTriggerDettachedAction(IWearableEffector caller)
        {
            base.OnTriggerDettachedAction(caller);

            if (DisconnectEffects == null) return;

            if (ImmediateDisconnect)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(DisconnectEffects, caller as IUnit));
            }
            else
            {
                CombatManager.Instance.AddSubAction(new EffectAction(DisconnectEffects, caller as IUnit));
            }
        }
        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {
            base.CustomOnTriggerAttached(caller);

            if (EffectTriggers != null)
            {
                foreach (EffectTrigger effect in EffectTriggers)
                {
                    effect.SetItem(this);
                    foreach (TriggerCalls trigger in effect.Triggers)
                    {
                        CombatManager.Instance.AddObserver(effect.Listener, trigger.ToString(), caller);
                    }
                }
            }
        }
        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            base.CustomOnTriggerDettached(caller);

            if (EffectTriggers != null)
            {
                foreach (EffectTrigger effect in EffectTriggers)
                {
                    foreach (TriggerCalls trigger in effect.Triggers)
                    {
                        CombatManager.Instance.RemoveObserver(effect.Listener, trigger.ToString(), caller);
                    }
                }
            }
        }

    }
    public class EffectTrigger
    {
        public TriggerCalls[] Triggers;
        public EffectorConditionSO[] Conditions;
        public EffectorConditionSO[] ConsumeCheck;
        public EffectInfo[] Effects;
        public bool Immediate;
        public bool ShowPopup;
        public bool Consume;
        public BaseWearableSO Item;

        public EffectTrigger(EffectInfo[] _effects, TriggerCalls[] _triggers, EffectorConditionSO[] _conditions, bool show = true, bool _immediate = false)
        {
            Triggers = _triggers != null ? _triggers : [];
            Effects = _effects != null ? _effects : [];
            Conditions = _conditions != null ? _conditions : [];
            ShowPopup = show;
            Immediate = _immediate;
            Consume = false;
            ConsumeCheck = [];
        }
        public EffectTrigger SetConsumeInfo(bool consumeOnUse, EffectorConditionSO[] consumeChecks)
        {
            Consume = consumeOnUse;
            ConsumeCheck = consumeChecks != null ? consumeChecks : null;
            return this;
        }
        public void SetItem(BaseWearableSO item)
        {
            Item = item;
        }

        public void DoTrigger(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            if (Immediate)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(Effects, caster));
            }
            else
            {
                CombatManager.Instance.AddSubAction(new EffectAction(Effects, caster));
            }
        }
        public void Listener(object sender, object args)
        {
            if (!(sender is IWearableEffector wearableEffector) || wearableEffector.Equals(null) || !wearableEffector.CanWearableTrigger)
            {
                return;
            }

            if (Conditions != null && !Conditions.Equals(null))
            {
                EffectorConditionSO[] array = Conditions;
                for (int i = 0; i < array.Length; i++)
                {
                    if (!array[i].MeetCondition(wearableEffector, args))
                    {
                        return;
                    }
                }
            }

            if (Immediate)
            {
                CombatManager.Instance.ProcessImmediateAction(new EffectTriggerImmediateAction(this, sender, args));
            }
            else
            {
                CombatManager.Instance.AddSubAction(new EffectTriggerAction(this, sender, args));
            }
        }
        public void Finalize(object sender, object args)
        {
            if (sender is IWearableEffector wearableEffector && !wearableEffector.Equals(null) && !wearableEffector.IsWearableConsumed)
            {
                bool itemConsumed = false;
                if (Consume && MeetsConsumeConditions(wearableEffector, args))
                {
                    itemConsumed = true;
                    wearableEffector.ConsumeWearable();
                }

                if (ShowPopup)
                {
                    CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(wearableEffector.ID, Item.GetItemLocData().text, itemConsumed, Item.wearableImage));
                }

                DoTrigger(sender, args);
            }
        }
        public bool MeetsConsumeConditions(IWearableEffector effector, object args)
        {
            if (ConsumeCheck != null && !ConsumeCheck.Equals(null))
            {
                EffectorConditionSO[] array = ConsumeCheck;
                for (int i = 0; i < array.Length; i++)
                {
                    if (!array[i].MeetCondition(effector, args))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public class EffectTriggerImmediateAction : IImmediateAction
        {
            public object _sender;

            public object _args;

            public EffectTrigger _item;

            public EffectTriggerImmediateAction(EffectTrigger item, object sender, object args)
            {
                _item = item;
                _sender = sender;
                _args = args;
            }

            public void Execute(CombatStats stats)
            {
                if (!(_item == null) && !_item.Equals(null))
                {
                    _item.Finalize(_sender, _args);
                }
            }
        }
        public class EffectTriggerAction : CombatAction
        {
            public object _sender;

            public object _args;

            public EffectTrigger _item;

            public EffectTriggerAction(EffectTrigger item, object sender, object args)
            {
                _item = item;
                _sender = sender;
                _args = args;
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                if (!(_item == null) && !_item.Equals(null))
                {
                    _item.Finalize(_sender, _args);
                }

                yield break;
            }
        }
    }
}
