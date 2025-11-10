using System;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Help
    {
        public static DamageInfo GenerateDamageInfo(int exit, int entry, bool killed)
        {
            DamageInfo ret = new DamageInfo();
            ret.damageAmount = exit;
            ret.beenKilled = killed;

            if (typeof(DamageInfo).GetField("attemptedDamageAmount") != null)
            {
                typeof(DamageInfo).GetField("attemptedDamageAmount").SetValue(ret, entry);

                Debug.Log("exists attempteddamageamount in damageinfo");
            }

            return ret;
        }

        public static IntegerReference GenerateDamageIntReference(int amount, string damageTypeID, bool directDamage, bool ignoreShield, int affectedStartSlot, int affectedEndSlot, IUnit possibleSourceUnit, IUnit damagedUnit)
        {
            if (Type.GetType("IntegerReference_Damage", false) != null)
            {
                object ret = Type.GetType("IntegerReference_Damage").GetConstructor([typeof(int), typeof(string), typeof(bool), typeof(bool), typeof(int), typeof(int), typeof(IUnit), typeof(IUnit)]).Invoke([amount, damageTypeID, directDamage, ignoreShield, affectedStartSlot, affectedEndSlot, possibleSourceUnit, damagedUnit]);

                Debug.Log("exists integerreference_damage");

                return ret as IntegerReference;
            }

            return new IntegerReference(amount);
        }
    }
}
