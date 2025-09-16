using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class TrackIntegerReferenceCondition : EffectorConditionSO
    {
        public string StoredValue;
        public int Above;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference reference)
            {
                (effector as IUnit).SimpleSetStoredValue(StoredValue, (effector as IUnit).SimpleGetStoredValue(StoredValue) + reference.value);
            }
            if ((effector as IUnit).SimpleGetStoredValue(StoredValue) > Above) return true;
            return false;
        }
    }
}
