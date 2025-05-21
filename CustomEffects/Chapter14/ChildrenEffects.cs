using BrutalAPI;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public class ChildrenPassiveAbility : BasePassiveAbilitySO
    {
        public static bool IsEnemy(EnemyCombat self, string enemy)
        {
            if (Check.EnemyExist(enemy))
            {
                return self.Enemy == LoadedAssetsHandler.GetEnemy(enemy);
            }
            return false;
        }
        public static string value => "Children_Internal_PA";
        public override bool DoesPassiveTrigger => true;
        public override bool IsPassiveImmediate => false;
        public override void TriggerPassive(object sender, object args)
        {
            if (sender is EnemyCombat enemy && args is DeathReference refff)
            {
                if (CombatManager.Instance._stats.LockedPassives.ContainsKey("Decay") && CombatManager.Instance._stats.LockedPassives["Decay"] > 0) return;
                if (!CombatManager.Instance._stats.IsPlayerTurn && enemy.SimpleGetStoredValue(value) > 0) return;
                if (refff.witheringDeath) return;
                EffectInfo[] array = new EffectInfo[1];
                if (IsEnemy(enemy, "Children6_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children5_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = Effects.GenerateEffect(ef, 0, Slots.Self);
                }
                else if (IsEnemy(enemy, "Children5_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children4_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = Effects.GenerateEffect(ef, 0, Slots.Self);
                }
                else if (IsEnemy(enemy, "Children4_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children3_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = Effects.GenerateEffect(ef, 0, Slots.Self);
                }
                else if (IsEnemy(enemy, "Children3_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children2_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = Effects.GenerateEffect(ef, 0, Slots.Self);
                }
                else if (IsEnemy(enemy, "Children2_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children1_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = Effects.GenerateEffect(ef, 0, Slots.Self);
                }
                else if (IsEnemy(enemy, "Children1_EN"))
                {
                    if (UnityEngine.Random.Range(0, 100) < 90) return;
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children0_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = Effects.GenerateEffect(ef, 0, Slots.Self);
                }
                else if (IsEnemy(enemy, "Children0_EN"))
                {
                    if (UnityEngine.Random.Range(0, 100) < 95) return;
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "ChildrenPrayer_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = Effects.GenerateEffect(ef, 0, Slots.Self);
                }
                else return;
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(enemy.ID, enemy.IsUnitCharacter, Passives.Example_Decay_MudLung.GetPassiveLocData().text, Passives.Example_Decay_MudLung.passiveIcon));
                CombatManager.Instance.AddSubAction(new EffectAction(array, enemy));
            }
            else if (args is DamageReceivedValueChangeException hitBy && sender is IUnit unit)
            {
                if (!CombatManager.Instance._stats.IsPlayerTurn && !hitBy.directDamage && hitBy.amount > 500) unit.SimpleSetStoredValue(value, 1);
            }
            else if (sender is IUnit unor)
            {
                unor.SimpleSetStoredValue(value, 0);
            }
        }
        public override void OnPassiveConnected(IUnit unit)
        {
            CombatManager.Instance._stats.AddStatusEffectReductionBlockedSource();
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance._stats.RemoveStatusEffectReductionBlockedSource();
        }
    }
    public class RandomFieldEffect : EffectSO
    {
        static ApplyShieldSlotEffect _shield;
        public static ApplyShieldSlotEffect Shield
        {
            get
            {
                if (_shield == null)
                {
                    _shield = ScriptableObject.CreateInstance<ApplyShieldSlotEffect>();
                }
                return _shield;
            }
        }
        static ApplyFireSlotEffect _fire;
        public static ApplyFireSlotEffect Fire
        {
            get
            {
                if (_fire == null)
                {
                    _fire = ScriptableObject.CreateInstance<ApplyFireSlotEffect>();
                }
                return _fire;
            }
        }
        static ApplyConstrictedSlotEffect _constricted;
        public static ApplyConstrictedSlotEffect Constricted
        {
            get
            {
                if (_constricted == null)
                {
                    _constricted = ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>();
                }
                return _constricted;
            }
        }
        static ApplyMoldFieldEffect _mold;
        public static ApplyMoldFieldEffect Mold
        {
            get
            {
                if (_mold == null)
                {
                    _mold = ScriptableObject.CreateInstance<ApplyMoldFieldEffect>();
                }
                return _mold;
            }
        }
        static ApplyRootsSlotEffect _roots;
        public static ApplyRootsSlotEffect Roots
        {
            get
            {
                if (_roots == null)
                {
                    _roots = ScriptableObject.CreateInstance<ApplyRootsSlotEffect>();
                }
                return _roots;
            }
        }
        static ApplyWaterSlotEffect _water;
        public static ApplyWaterSlotEffect Water
        {
            get
            {
                if (_water == null)
                {
                    _water = ScriptableObject.CreateInstance<ApplyWaterSlotEffect>();
                }
                return _water;
            }
        }
        static ApplySlipSlotEffect _slip;
        public static ApplySlipSlotEffect Slip
        {
            get
            {
                if (_slip == null)
                {
                    _slip = ScriptableObject.CreateInstance<ApplySlipSlotEffect>();
                }
                return _slip;
            }
        }
        public static EffectSO[] Array => new EffectSO[] { Shield, Fire, Constricted, Mold, Roots, Water, Slip };

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                List<EffectSO> list = new List<EffectSO>(Array);
                int picking = UnityEngine.Random.Range(0, list.Count);
                EffectSO first = list[picking];
                int choosing = UnityEngine.Random.Range(0, list.Count);
                while (choosing == picking)
                {
                    choosing = UnityEngine.Random.Range(0, list.Count);
                }
                EffectSO second = list[choosing];
                first.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exiting);
                exitAmount += exiting;
            }
            return exitAmount > 0;
        }
    }
    public class CasterSetStoredValueEffect : EffectSO
    {
        [SerializeField]
        public string _valueName = "";

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            caster.SimpleSetStoredValue(this._valueName, entryVariable);
            return exitAmount > 0;
        }
    }
    public class DealRandomAmountDamageConvertToParasiteEffect : EffectSO
    {
        [SerializeField]
        public string _deathType = "Basic";
        [SerializeField]
        public bool _usePreviousExitValue;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;
        [SerializeField]
        public bool _returnKillAsSuccess;
        [SerializeField]
        public int _minAmount = 0;
        [SerializeField]
        public BasePassiveAbilitySO _passiveToAdd = Passives.ParasiteParasitism;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            if (this._usePreviousExitValue)
                entryVariable *= this.PreviousExitValue;
            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int num1 = UnityEngine.Random.Range(this._minAmount, entryVariable);
                    int num2 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
                    int num3 = num1;
                    DamageInfo damageInfo;
                    if (this._indirect)
                    {
                        damageInfo = target.Unit.Damage(num3, (IUnit)null, this._deathType, num2, false, false, true);
                    }
                    else
                    {
                        int num4 = caster.WillApplyDamage(num3, target.Unit);
                        damageInfo = target.Unit.Damage(num4, caster, this._deathType, num2, true, true, this._ignoreShield);
                    }
                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                    if (damageInfo.damageAmount > 0)
                    {
                        int damageAmount = damageInfo.damageAmount;
                        IUnit unit = target.Unit;
                        if (!unit.ContainsPassiveAbility(PassiveType_GameIDs.Parasite.ToString()))
                            unit.AddPassiveAbility(this._passiveToAdd);
                        int num5 = unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString()) + damageAmount;
                        unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString(), num5);
                    }
                }
            }
            if (!this._indirect && exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
        }
    }
    public class ApplyParasiteEffect : EffectSO
    {
        [SerializeField]
        public BasePassiveAbilitySO _passiveToAdd = Passives.ParasiteParasitism;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    if (!targets[index].Unit.ContainsPassiveAbility(PassiveType_GameIDs.Parasite.ToString()))
                        targets[index].Unit.AddPassiveAbility(this._passiveToAdd);
                    int num = targets[index].Unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString()) + entryVariable;
                    targets[index].Unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString(), num);
                    targets[index].Unit.SimpleSetStoredValue(SpawnChildrenEffect.value, targets[index].Unit.SimpleGetStoredValue(SpawnChildrenEffect.value) + 1);
                    exitAmount += num;
                }
            }
            return exitAmount > 0;
        }
    }
    public class SpawnChildrenEffect : SpawnEnemyAnywhereEffect
    {
        public static string value => "ParasiteChildrenAmount_A";
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!stats.InCombat) return false;
            for (int i = (Math.Max(caster.SimpleGetStoredValue(value), 1)); i > 0; i -= 6)
            {
                if (i >= 6 && Check.EnemyExist("Children6_EN")) enemy = LoadedAssetsHandler.GetEnemy("Children6_EN");
                else if (Check.EnemyExist("Children" + i.ToString() + "_EN")) enemy = LoadedAssetsHandler.GetEnemy("Children" + i.ToString() + "_EN");
                else enemy = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN");
                base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int exi);
            }
            exitAmount = caster.SimpleGetStoredValue(value);
            caster.SimpleSetStoredValue(value, 0);
            return exitAmount > 0;
        }
    }
    public static class ParasiteEffection
    {
        public static ApplyParasiteEffect apply
        {
            get
            {
                ParasitePassiveAbility parasitePassiveAbility = ScriptableObject.CreateInstance<ParasitePassiveAbility>();
                parasitePassiveAbility.conditions = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.conditions;
                parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
                parasitePassiveAbility.connectionEffects = new EffectInfo[0];
                CasterSetStoredValueEffect casterSetStoredValueEffect = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
                casterSetStoredValueEffect._valueName = UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString();
                SpawnChildrenEffect sp = ScriptableObject.CreateInstance<SpawnChildrenEffect>();
                sp.enemy = Check.EnemyExist("Children1_EN") ? LoadedAssetsHandler.GetEnemy("Children1_EN") : LoadedAssetsHandler.GetEnemy("SilverSuckle_EN");
                sp._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
                parasitePassiveAbility.disconnectionEffects = new EffectInfo[]
                {
                Effects.GenerateEffect(casterSetStoredValueEffect, 0, Slots.Self, null),
                Effects.GenerateEffect(sp, 1, Slots.Self)
                };
                parasitePassiveAbility.connectionImmediateEffect = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).connectionImmediateEffect;
                parasitePassiveAbility.disconnectionImmediateEffect = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).disconnectionImmediateEffect;
                parasitePassiveAbility.doesPassiveTriggerInformationPanel = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.doesPassiveTriggerInformationPanel;
                DealRandomAmountDamageConvertToParasiteEffect dealRandomAmountDamageConvertToParasiteEffect = ScriptableObject.CreateInstance<DealRandomAmountDamageConvertToParasiteEffect>();
                dealRandomAmountDamageConvertToParasiteEffect._indirect = true;
                dealRandomAmountDamageConvertToParasiteEffect._minAmount = 1;
                dealRandomAmountDamageConvertToParasiteEffect._passiveToAdd = parasitePassiveAbility;
                parasitePassiveAbility.effects = new EffectInfo[]
                {
                Effects.GenerateEffect(dealRandomAmountDamageConvertToParasiteEffect, 1, Slots.Self, null)
                };
                parasitePassiveAbility.passiveIcon = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.passiveIcon;
                parasitePassiveAbility.specialStoredData = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).specialStoredData;
                parasitePassiveAbility.m_PassiveID = PassiveType_GameIDs.Parasite.ToString();
                parasitePassiveAbility._characterDescription = "Increases the damage received by 5% per point of Parasite. Parasite will decrease by the original unmutliplied damage amount. Parasite will remove 0-1 health from this party member at the end of every turn and convert it into more Parasite.";
                parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
                parasitePassiveAbility._enemyDescription = "Increases the damage received by 5% per point of Parasite. Parasite will decrease by the original unmutliplied damage amount. Parasite will remove 0-1 health from this enemy at the end of every turn and convert it into more Parasite.";
                parasitePassiveAbility._isFriendly = false;
                parasitePassiveAbility._parasiteShield = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._parasiteShield;
                parasitePassiveAbility._passiveName = "Parasitism";
                parasitePassiveAbility._secondTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._secondTriggerOn;
                parasitePassiveAbility._thirdTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._thirdTriggerOn;
                parasitePassiveAbility._triggerOn = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd._triggerOn;
                ApplyParasiteEffect applyParasiteEffect = ScriptableObject.CreateInstance<ApplyParasiteEffect>();
                applyParasiteEffect._passiveToAdd = parasitePassiveAbility;
                return applyParasiteEffect;
            }
        }
    }
}
