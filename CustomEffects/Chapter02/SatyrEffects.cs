using BrutalAPI;
using MonoMod.RuntimeDetour;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System;
using UnityEngine;
using System.Drawing;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public static class MultiSpriteEnemyLayoutSetup
    {
        public static void PrepareMultiEnemyPrefab(this Enemy E, string prefabBundlePath, AssetBundle fileBundle, ParticleSystem gibs = null)
        {
            GameObject gameObject = fileBundle.LoadAsset<GameObject>(prefabBundlePath);
            MultiSpriteEnemyLayout enemyInFieldLayout = gameObject.AddComponent<MultiSpriteEnemyLayout>();
            EnemyInFieldLayout_Data enemyInFieldLayout_Data = gameObject.GetComponent<EnemyInFieldLayout_Data>();
            if (enemyInFieldLayout_Data == null)
            {
                enemyInFieldLayout_Data = gameObject.AddComponent<EnemyInFieldLayout_Data>();
                enemyInFieldLayout_Data.SetDefaultData();
            }

            if (gibs != null)
            {
                enemyInFieldLayout_Data.m_Gibs = gibs;
            }

            enemyInFieldLayout.m_Data = enemyInFieldLayout_Data;
            E.enemy.enemyTemplate = enemyInFieldLayout;

            MultiSpriteEnemyLayout.Setup();
        }
    }
    public class MultiSpriteEnemyLayout : EnemyInFieldLayout
    {
        public SpriteRenderer[] OtherRenderers;
        public void Prepare()
        {
            if (OtherRenderers != null) foreach (SpriteRenderer rend in OtherRenderers) rend.material = _enemyMaterialInstance;
        }
        public void UpdateRends()
        {
            UnityEngine.Color value = (TurnSelected ? LoadedDBsHandler.CombatData.EnemyTurnColor : (TargetSelected ? LoadedDBsHandler.CombatData.EnemyTargetColor : ((!MouseSelected) ? LoadedDBsHandler.CombatData.EnemyBasicColor : LoadedDBsHandler.CombatData.EnemyHoverColor)));
            float value2 = ((MouseSelected || TargetSelected || TurnSelected) ? 1 : 0);
            if (OtherRenderers != null) foreach (SpriteRenderer rend in OtherRenderers)
                {
                    rend.material.SetColor("_OutlineColor", value);
                    rend.material.SetFloat("_OutlineAlpha", value2);
                }
        }
        public static void BaseIni(Action<EnemyInFieldLayout, int, Vector3> orig, EnemyInFieldLayout self, int id, Vector3 location3D)
        {
            orig(self, id, location3D);
            if (self is MultiSpriteEnemyLayout l) l.Prepare();
        }
        public static void BaseUpi(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout self)
        {
            orig(self);
            if (self is MultiSpriteEnemyLayout l) l.UpdateRends();
        }
        public static bool HooksSet;
        public static void Setup()
        {
            if (HooksSet) return;
            HooksSet = true;
            IDetour hook2 = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(Initialization), ~BindingFlags.Default), typeof(MultiSpriteEnemyLayout).GetMethod(nameof(BaseIni), ~BindingFlags.Default));
            IDetour hook3 = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(UpdateSlotSelection), ~BindingFlags.Default), typeof(MultiSpriteEnemyLayout).GetMethod(nameof(BaseUpi), ~BindingFlags.Default));
        }
    }
    public class AbilitySelector_Satyr : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string flavor = "Bitter Flavor";
        public string flavour = "Bitter Flavour";

        public override bool UsesRarity => true;
        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return CombatManager.Instance._stats.TurnsPassed < 2 && (name == this.flavor || name == this.flavour);
        }
    }
    public class ApplyDivineProtectionEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = StatusField.DivineProtection;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class SpawnEnemyFromDeadListEffect : EffectSO
    {
        public EnemySO enemy;

        public bool givesExperience;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public bool IsntSuperboss(EnemyCombat enemy)
        {
            if (enemy.Enemy._enemyName == "Strange Box")
                return false;
            if (enemy.Enemy._enemyName == "544517")
                return false;
            if (enemy.Enemy._enemyName == "544516")
                return false;
            if (enemy.Enemy._enemyName == "544515")
                return false;
            if (enemy.Enemy._enemyName == "544514")
                return false;
            if (enemy.Enemy._enemyName == "544513")
                return false;
            return true;
        }
        public static bool ContainsPassiveAbility(EnemySO enemy, string passive)
        {
            foreach (BasePassiveAbilitySO passi in enemy.passiveAbilities)
            {
                if (passi.m_PassiveID == passive) return true;
            }
            return false;
        }
        public bool CanLive(EnemyCombat enemy)
        {
            if (ContainsPassiveAbility(enemy.Enemy, PassiveType_GameIDs.Dying.ToString())) return false;
            if (ContainsPassiveAbility(enemy.Enemy, PassiveType_GameIDs.Inanimate.ToString())) return false;
            return true;
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int candidatesLength = 0;
            exitAmount = 0;
            for (int index = 0; index < stats.Enemies.Count; index++)
            {
                EnemyCombat targetEnemy = stats.Enemies[index];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled && IsntSuperboss(targetEnemy) && CanLive(targetEnemy))
                {
                    candidatesLength++;
                }
            }
            if (candidatesLength <= 0)
            {
                return false;
            }
            int[] candidates = new int[candidatesLength];
            int addAt = 0;
            for (int index = 0; index < stats.Enemies.Count; index++)
            {
                EnemyCombat targetEnemy = stats.Enemies[index];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled)
                {
                    if (addAt < candidates.Length)
                    {
                        candidates[addAt] = index;
                        addAt++;
                    }
                }
            }
            for (int i = 0; i < entryVariable; i++)
            {
                int picking = UnityEngine.Random.Range(0, candidates.Length);
                int choosing = candidates[picking];
                EnemyCombat targetEnemy = stats.Enemies[choosing];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled && IsntSuperboss(targetEnemy) && CanLive(targetEnemy))
                {
                    int num = stats.GetRandomEnemySlot(targetEnemy.Enemy.size);
                    if (num != -1)
                    {
                        float newMax = targetEnemy.Enemy.health / 3f;
                        if (stats.AddNewEnemy(targetEnemy.Enemy, num, false, _spawnType, Math.Max(1, (int)Math.Floor(newMax))))
                        {
                            targetEnemy.HasFled = true;
                            exitAmount++;
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ReviveReKillEnemyEffect : EffectSO
    {
        public EnemySO enemy;

        public bool givesExperience;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public bool IsntSuperboss(EnemyCombat enemy)
        {
            if (enemy.Enemy._enemyName == "Strange Box")
                return false;
            if (enemy.Enemy._enemyName == "544517")
                return false;
            if (enemy.Enemy._enemyName == "544516")
                return false;
            if (enemy.Enemy._enemyName == "544515")
                return false;
            if (enemy.Enemy._enemyName == "544514")
                return false;
            if (enemy.Enemy._enemyName == "544513")
                return false;
            return true;
        }
        public static bool ContainsPassiveAbility(EnemySO enemy, string passive)
        {
            foreach (BasePassiveAbilitySO passi in enemy.passiveAbilities)
            {
                if (passi.m_PassiveID == passive) return true;
            }
            return false;
        }
        public bool CanLive(EnemyCombat enemy)
        {
            if (ContainsPassiveAbility(enemy.Enemy, PassiveType_GameIDs.Dying.ToString())) return false;
            if (ContainsPassiveAbility(enemy.Enemy, PassiveType_GameIDs.Inanimate.ToString())) return false;
            return true;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int candidatesLength = 0;
            exitAmount = 0;
            for (int index = 0; index < stats.Enemies.Count; index++)
            {
                EnemyCombat targetEnemy = stats.Enemies[index];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled && IsntSuperboss(targetEnemy) && CanLive(targetEnemy))
                {
                    candidatesLength++;
                }
            }
            if (candidatesLength <= 0)
            {
                return false;
            }
            int[] candidates = new int[candidatesLength];
            int addAt = 0;
            for (int index = 0; index < stats.Enemies.Count; index++)
            {
                EnemyCombat targetEnemy = stats.Enemies[index];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled)
                {
                    if (addAt < candidates.Length)
                    {
                        candidates[addAt] = index;
                        addAt++;
                    }
                }
            }
            for (int i = 0; i < entryVariable; i++)
            {
                int picking = UnityEngine.Random.Range(0, candidates.Length);
                int choosing = candidates[picking];
                EnemyCombat targetEnemy = stats.Enemies[choosing];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled && IsntSuperboss(targetEnemy) && CanLive(targetEnemy))
                {
                    int num = stats.GetRandomEnemySlot(targetEnemy.Enemy.size);
                    if (num != -1)
                    {
                        if (stats.AddNewEnemy(targetEnemy.Enemy, num, false, _spawnType, targetEnemy.Enemy.health))
                        {
                            targetEnemy.HasFled = true;
                            exitAmount++;
                            EnemyCombat newborn = stats.Enemies[stats.Enemies.Count - 1];
                            if (newborn is IUnit unit)
                            {
                                exitAmount++;
                                EffectInfo DP = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 1, Targeting.Slot_SelfAll);
                                DamageEffect indirect = ScriptableObject.CreateInstance<DamageEffect>();
                                indirect._indirect = true;
                                int maxHP = unit.CurrentHealth;
                                if (Check.EnemyExist("MechanicalLens_EN") && newborn.Enemy == LoadedAssetsHandler.GetEnemy("MechanicalLens_EN")) maxHP = 20;
                                //maxHP *= 2;
                                EffectInfo hit = Effects.GenerateEffect(indirect, maxHP, Targeting.Slot_SelfAll);
                                RemoveStatusEffectEffect DPGone = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                                DPGone._status = StatusField.DivineProtection;
                                EffectInfo noDP = Effects.GenerateEffect(DPGone, 1, Targeting.Slot_SelfAll);
                                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { DP, hit, noDP }, unit));
                            }
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class Extra1Or2LootOptionsEffect : ExtraLootOptionsEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int num)) exitAmount++;
            if (UnityEngine.Random.Range(0f, 1f) < 0.5f)
                if (base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int nuu)) exitAmount++;
            return exitAmount > 0;
        }
    }
    public class SatyrAnimationVisualsEffect : EffectSO
    {
        [Header("Visual")]
        [SerializeField]
        public AttackVisualsSO _visuals;

        [SerializeField]
        public BaseCombatTargettingSO _animationTarget;

        [SerializeField]
        public AttackVisualsSO _visuals2;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {

            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(_visuals, _animationTarget, caster));
                    exitAmount++;
                }
                else
                {
                    CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(_visuals2, _animationTarget, caster));
                }
            }
            return exitAmount > 0;
        }
    }
    public class NoKillingDamageEffect : EffectSO
    {
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
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.NoKillDamage(amount, null, _DeathTypeID, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.NoKillDamage(amount, caster, _DeathTypeID, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                    }

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }

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
    }
    public static class WontKillDamageExtension
    {
        public static DamageInfo NoKillDamageCH(this CharacterCombat self, int amount, IUnit killer, string deathTypeID, int targetSlotOffset = -1, bool addHealthMana = true, bool directDamage = true, bool ignoresShield = false, string specialDamage = "")
        {
            int num = self.SlotID;
            int num2 = self.SlotID + self.Size - 1;
            if (targetSlotOffset >= 0)
            {
                targetSlotOffset = Mathf.Clamp(self.SlotID + targetSlotOffset, num, num2);
                num = targetSlotOffset;
                num2 = targetSlotOffset;
            }

            DamageReceivedValueChangeException ex = new DamageReceivedValueChangeException(amount, specialDamage, directDamage, ignoresShield, num, num2, killer, self);
            CombatManager.Instance.PostNotification(TriggerCalls.OnBeingDamaged.ToString(), self, ex);
            int modifiedValue = ex.GetModifiedValue();
            if (modifiedValue >= self.CurrentHealth) modifiedValue = self.CurrentHealth - 1;
            if (killer != null && !killer.Equals(null))
            {
                CombatManager.Instance.ProcessImmediateAction(new UnitDamagedImmediateAction(modifiedValue, killer.IsUnitCharacter));
            }

            int num3 = Mathf.Max(self.CurrentHealth - modifiedValue, 0);
            int num4 = self.CurrentHealth - num3;
            if (num4 != 0)
            {
                self.GetHit();
                self.CurrentHealth = num3;
                if (specialDamage == "")
                {
                    specialDamage = Tools.Utils.GetBasicDamageIDFromAmount(modifiedValue);
                }

                CombatManager.Instance.AddUIAction(new CharacterDamagedUIAction(self.ID, self.CurrentHealth, self.MaximumHealth, modifiedValue, specialDamage));
                if (addHealthMana && self.IsAlive)
                {
                    CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(self.HealthColor, LoadedDBsHandler.CombatData.CharacterPigmentAmount, self.IsUnitCharacter, self.ID));
                }

                CombatManager.Instance.PostNotification(TriggerCalls.OnDamaged.ToString(), self, new IntegerReference(num4));
                string notificationName = (directDamage ? TriggerCalls.OnDirectDamaged.ToString() : TriggerCalls.OnIndirectDamaged.ToString());
                CombatManager.Instance.PostNotification(notificationName, self, new IntegerReference(num4));
            }
            else if (!ex.ShouldIgnoreUI)
            {
                CombatManager.Instance.AddUIAction(new CharacterNotDamagedUIAction(self.ID, CombatType_GameIDs.Dmg_Weak.ToString()));
            }

            bool flag = self.IsAlive && self.CurrentHealth == 0 && num4 != 0;
            if (flag)
            {
                CombatManager.Instance.AddSubAction(new CharacterDeathAction(self.ID, killer, deathTypeID));
            }

            return new DamageInfo(num4, flag);
        }
        public static DamageInfo NoKillDamageEN(this EnemyCombat self, int amount, IUnit killer, string deathTypeID, int targetSlotOffset = -1, bool addHealthMana = true, bool directDamage = true, bool ignoresShield = false, string specialDamage = "")
        {
            int num = self.SlotID;
            int num2 = self.SlotID + self.Size - 1;
            if (targetSlotOffset >= 0)
            {
                targetSlotOffset = Mathf.Clamp(self.SlotID + targetSlotOffset, num, num2);
                num = targetSlotOffset;
                num2 = targetSlotOffset;
            }

            DamageReceivedValueChangeException ex = new DamageReceivedValueChangeException(amount, specialDamage, directDamage, ignoresShield, num, num2, killer, self);
            CombatManager.Instance.PostNotification(TriggerCalls.OnBeingDamaged.ToString(), self, ex);
            int modifiedValue = ex.GetModifiedValue();
            if (modifiedValue >= self.CurrentHealth) modifiedValue = self.CurrentHealth - 1;
            if (killer != null && !killer.Equals(null))
            {
                CombatManager.Instance.ProcessImmediateAction(new UnitDamagedImmediateAction(modifiedValue, killer.IsUnitCharacter));
            }

            int num3 = Mathf.Max(self.CurrentHealth - modifiedValue, 0);
            int num4 = self.CurrentHealth - num3;
            if (num4 != 0)
            {
                self.CurrentHealth = num3;
                if (specialDamage == "")
                {
                    specialDamage = Tools.Utils.GetBasicDamageIDFromAmount(modifiedValue);
                }

                CombatManager.Instance.AddUIAction(new EnemyDamagedUIAction(self.ID, self.CurrentHealth, self.MaximumHealth, modifiedValue, specialDamage));
                if (addHealthMana)
                {
                    CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(self.HealthColor, LoadedDBsHandler.CombatData.EnemyPigmentAmount, self.IsUnitCharacter, self.ID));
                }

                CombatManager.Instance.PostNotification(TriggerCalls.OnDamaged.ToString(), self, new IntegerReference(num4));
                string notificationName = (directDamage ? TriggerCalls.OnDirectDamaged.ToString() : TriggerCalls.OnIndirectDamaged.ToString());
                CombatManager.Instance.PostNotification(notificationName, self, new IntegerReference(num4));
            }
            else if (!ex.ShouldIgnoreUI)
            {
                CombatManager.Instance.AddUIAction(new EnemyNotDamagedUIAction(self.ID));
            }

            bool flag = self.CurrentHealth == 0 && num4 != 0;
            if (flag)
            {
                CombatManager.Instance.AddSubAction(new EnemyDeathAction(self.ID, killer, deathTypeID));
            }

            return new DamageInfo(num4, flag);
        }
        public static DamageInfo NoKillDamage(this IUnit self, int amount, IUnit killer, string deathTypeID, int targetSlotOffset = -1, bool addHealthMana = true, bool directDamage = true, bool ignoresShield = false, string specialDamage = "")
        {
            if (self is CharacterCombat chara) return chara.NoKillDamageCH(amount, killer, deathTypeID, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
            else return (self as EnemyCombat).NoKillDamageEN(amount, killer, deathTypeID, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
        }

    }
}