using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class GenericEffectItem<T> : MultiPerformEffectItem where T : MultiPerformEffectWearable
    {
        public GenericEffectItem(string itemID = "DefaultID_Item", EffectInfo[] effects = null, bool immediate = false)
        {
            item = ScriptableObject.CreateInstance<T>();
            item._immediateEffect = immediate;
            item.effects = effects;
            (item as MultiPerformEffectWearable).EffectTriggers = new List<EffectTrigger>();
            (item as MultiPerformEffectWearable).ConnectionEffects = [];
            (item as MultiPerformEffectWearable).DisconnectEffects = [];
            InitializeItemData(itemID);
        }
    }
}
