using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace YourNamespace
{
    //this is an exmample of how yo'd set up these passives
    public static class ExampleClass
    {
        public static void ExamplePassive()
        {
            UnitStoreData.CreateAndAdd_IntTooltip_UnitStoreDataToPool("YourPassive_PA", "Showstopper: {0}", Misc.GetInGame_UITextColor(Misc.UITextColorIDs.Positive), false);
            //this will display as "Showstopper: 2" for instance if its at 2. the {0} gets replaced by the amount in game

            //notes: you only have to call this 1 line of code here ONCE in ur entire mod. just before u instantiate any passie that relies on the stored value.
            //notes 2: u can also sest the color to Red by changing Misc.UiTextColorIDs.Positive to .Negative;

            PerformEffectPassiveAbility showstopper = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            //ujust set the normal passive data if not explicitly mentioned
            showstopper._triggerOn = [TriggerCalls.OnAnyAbilityUsed];
            showstopper.specialStoredData = UnitStoreData.GetCustom_UnitStoreData("YourPassive_PA");//if u change the stored data key to something else, make sure to change it among all intances
            
            StoredValueTrackerCondition condition = ScriptableObject.CreateInstance<StoredValueTrackerCondition>();
            condition.Amount = 3;//but it can be any number, ust the amount u want.
            condition.Value = "YourPassive_PA";
            condition.GetAllies = false;

            //actually add the condition to the passive:
            showstopper.conditions = [condition];

            //special note: if ur c# lang version is wrong, the like, [] square bracket stuff is gonna give ur red squiggly underlines
            //just replace them with like, new TriggereCalls[] { TriggerCalls.OnAnyAbilityUsed } or new EffectorConditionSO[] { condition }
        }
    }


    //this c ustom effect u ust need somewhre n ur mod files oesnt matter where ust in ur mod. 
    public class StoredValueTrackerCondition : EffectorConditionSO
    {
        public int Amount;
        public string Value;

        public bool GetAllies;

        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is AbilityUsageReference reference)
            {
                if (GetAllies != (reference.m_IsUnitCharacter == effector.IsUnitCharacter)) return false;
            }

            if (effector is IUnit unit)
            {
                int num = unit.SimpleGetStoredValue(Value) + 1;
                if (num >= Amount)
                {
                    unit.SimpleSetStoredValue(Value, 0);
                    return true;
                }

                unit.SimpleSetStoredValue(Value, num);
            }

            return false;
        }
    }
}
