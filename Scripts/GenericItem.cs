using BrutalAPI.Items;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class GenericItem<T> : BaseItem where T : BaseWearableSO
    {
        public T item;
        public override BaseWearableSO Item => item;
        public GenericItem(string itemID = "DefaultID_Item")
        {
            item = ScriptableObject.CreateInstance<T>();
            InitializeItemData(itemID);
        }
    }
}
