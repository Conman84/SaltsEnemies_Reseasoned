using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class KarmicOffloadingEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddSubAction(new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("Monster_EN"), -1, false, trySpawnAnyways: false, "Spawn_Basic", 50));
            CombatManager.Instance.AddSubAction(new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("WindSong_EN"), -1, false, trySpawnAnyways: false, "Spawn_Basic", 50));
            CombatManager.Instance.AddSubAction(new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("ClockTower_EN"), -1, false, trySpawnAnyways: false, "Spawn_Basic", 50));
            CombatManager.Instance.AddSubAction(new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("MiniReaper_EN"), -1, false, trySpawnAnyways: false, "Spawn_Basic", 50));
            CombatManager.Instance.AddSubAction(new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("Delusion_EN"), -1, false, trySpawnAnyways: false, "Spawn_Basic", 50));
            exitAmount = 0;
            return true;
        }
    }
    public class GlueEyeCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException value)
            {
                if (value.damagedUnit != null) value.damagedUnit.ApplyStatusEffect(BrutalAPI.StatusField.DivineProtection, 1);
            }
            return true;
        }
    }
    public class CasterShowItemEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.ShowItem();
            return true;
        }
    }
    public class DamageTargetEffect : EffectSO
    {
        public IUnit Unit;

        [DeathTypeEnumRef]
        public string _DeathTypeID = "Basic";

        public bool _usePreviousExitValue;

        public bool _ignoreShield;

        public bool _indirect;

        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool flag = false;
            int amount = entryVariable;
            DamageInfo damageInfo;
            if (_indirect)
            {
                damageInfo = Unit.Damage(amount, null, _DeathTypeID, -1, addHealthMana: false, directDamage: false, ignoresShield: true);
            }
            else
            {
                amount = caster.WillApplyDamage(amount, Unit);
                damageInfo = Unit.Damage(amount, caster, _DeathTypeID, -1, addHealthMana: true, directDamage: true, _ignoreShield);
            }

            flag |= damageInfo.beenKilled;
            exitAmount += damageInfo.damageAmount;

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }

        public static DamageTargetEffect Create(IUnit unit)
        {
            DamageTargetEffect ret = ScriptableObject.CreateInstance<DamageTargetEffect>();
            ret.Unit = unit;
            return ret;
        }
    }
    public class DamageFromtTargetEffect : EffectSO
    {
        public IUnit Unit;
        public IUnit Dealer;

        [DeathTypeEnumRef]
        public string _DeathTypeID = "Basic";

        public bool _usePreviousExitValue;

        public bool _ignoreShield;

        public bool _indirect;

        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool flag = false;
            int amount = entryVariable;

            IUnit dealer = Dealer;
            if (dealer == null) dealer = caster;

            DamageInfo damageInfo;
            if (_indirect)
            {
                damageInfo = Unit.Damage(amount, null, _DeathTypeID, -1, addHealthMana: false, directDamage: false, ignoresShield: true);
            }
            else
            {
                amount = dealer.WillApplyDamage(amount, Unit);
                damageInfo = Unit.Damage(amount, dealer, _DeathTypeID, -1, addHealthMana: true, directDamage: true, _ignoreShield);
            }

            flag |= damageInfo.beenKilled;
            exitAmount += damageInfo.damageAmount;

            if (!_indirect && exitAmount > 0)
            {
                dealer.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }

    }
}
