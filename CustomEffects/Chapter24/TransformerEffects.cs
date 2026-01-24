using BrutalAPI;
using HarmonyLib;
using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.UI.CanvasScaler;

namespace SaltsEnemies_Reseasoned
{
    public static class TransformerEnemyHandler
    {
        public static Sprite Wish;
        public static void Setup()
        {
            Wish = ResourceLoader.LoadSprite("WishIcon.png");
            IDetour hook1 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.TransformEnemy), ~BindingFlags.Default), typeof(TransformerEnemyHandler).GetMethod(nameof(EnemyCombat_TransformEnemy), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(CombatVisualizationController).GetMethod(nameof(CombatVisualizationController.TryTransformEnemy), ~BindingFlags.Default), typeof(TransformerEnemyHandler).GetMethod(nameof(CombatVisualizationController_TryTransformEnemy), ~BindingFlags.Default));
            IDetour hook3 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.FinalizationEnd), ~BindingFlags.Default), typeof(TransformerEnemyHandler).GetMethod(nameof(EnemyCombat_FinalizationEnd), ~BindingFlags.Default));
            IDetour hook4 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.InitializationEnd), ~BindingFlags.Default), typeof(TransformerEnemyHandler).GetMethod(nameof(EnemyCombat_InitializationEnd), ~BindingFlags.Default));
        }
        public static void EnemyCombat_TransformEnemy(Action<EnemyCombat, EnemySO, bool, bool, bool> orig, EnemyCombat self, EnemySO enemy, bool fullyHeal, bool maintainMaxHealth, bool currentToMaxHealth)
        {
            if (self.Enemy.name != Ecstasy.Gray)
            {
                orig(self, enemy, fullyHeal, maintainMaxHealth, currentToMaxHealth);
                return;
            }

            self.FinalizationEnd();


            self.SimpleSetStoredValue(Ecstasy.Gray, 1);
            if (self.TryGetStoredData(Ecstasy.Gray, out UnitStoreDataHolder holder, false))
            {
                holder.m_ObjectData = enemy;
            }

            //self.Enemy = enemy;
            //self.Name = self.Enemy.GetName();
            //self.UnitTurnSprite = self.Enemy.enemySprite;
            CombatManager.Instance.AddUIAction(new TransformerUIAction(self, enemy));

            if (!maintainMaxHealth)
            {
                self.MaximumHealth = enemy.health;
            }

            if (currentToMaxHealth)
            {
                self.MaximumHealth = Mathf.Max(self.CurrentHealth, 1);
            }

            self.HealthColor = enemy.healthColor;
            self.CurrentHealth = (fullyHeal ? self.MaximumHealth : Mathf.Min(self.CurrentHealth, self.MaximumHealth));

            List<string> temp = [.. enemy.unitTypes];
            temp.Add("Robot");
            self.UnitTypes = temp.ToArray();

            //self.Size = self.Enemy.size;
            self.AbilitySelector = enemy.abilitySelector;
            //self.SetUpDefaultAbilities(updateUI: false);
            self.Abilities = new List<CombatAbility>();
            foreach (EnemyAbilityInfo ability in enemy.abilities)
            {
                self.Abilities.Add(new CombatAbility(ability));
            }

            foreach (ExtraAbilityInfo extraAbility in self.ExtraAbilities)
            {
                self.Abilities.Add(new CombatAbility(extraAbility.ability, extraAbility.rarity));
            }

            self.Priority = enemy.priority;
            self._passiveAbilities = [];
            self.DefaultPassiveAbilityInitialization();

            /*if (self.ExternalPassives != null)
            {
                foreach (BasePassiveAbilitySO externalPassife in self.ExternalPassives)
                {
                    if (!self.ContainsPassiveAbility(externalPassife.m_PassiveID))
                    {
                        self.PassiveAbilities.Add(externalPassife);
                        externalPassife.OnTriggerAttached(self);
                    }
                }

                return;
            }*/

            if (enemy.passiveAbilities != null)
            {
                foreach (BasePassiveAbilitySO passiveAbility in enemy.passiveAbilities)
                {
                    if (!self.ContainsPassiveAbility(passiveAbility.m_PassiveID))
                    {
                        self.PassiveAbilities.Add(passiveAbility);
                        passiveAbility.OnTriggerAttached(self);
                    }
                }
            }
        }
        public static void CombatVisualizationController_TryTransformEnemy(Action<CombatVisualizationController, EnemyCombat, ManaColorSO, int, int> orig, CombatVisualizationController self, EnemyCombat newEnemInfo, ManaColorSO newHealthColor, int newCurrentHealth, int newMaxHealth)
        {
            if (newEnemInfo.SimpleGetStoredValue(Ecstasy.Gray) <= 0)
            {
                orig(self, newEnemInfo, newHealthColor, newCurrentHealth, newMaxHealth);
                return;
            }
            if (self._enemiesInCombat.TryGetValue(newEnemInfo.ID, out var value))
            {
                value.Transform(newEnemInfo, newHealthColor, newCurrentHealth, newMaxHealth);
                self._enemyZone._enemies[value.FieldID].UpdateHealthLayout(value.HealthColor, value.CurrentHealth, value.MaxHealth, value.HealthBarSpriteType);
                self.TryUpdateEnemyIDInformation(newEnemInfo.ID);
            }
        }
        public static void EnemyCombat_FinalizationEnd(Action<EnemyCombat, bool> orig, EnemyCombat self, bool disconnectPassives)
        {
            if (self.TryGetStoredData(Ecstasy.Gray, out UnitStoreDataHolder holder, false) && holder.m_MainData > 0 && holder.m_ObjectData is EnemySO enem)
            {
                self.RemoveAndDisconnectAllPassiveAbilities(disconnectPassives);
                if (enem.exitEffects != null)
                {
                    CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(enem.exitEffects, self));
                }
                return;
            }

            orig(self, disconnectPassives);
        }
        public static void EnemyCombat_InitializationEnd(Action<EnemyCombat> orig, EnemyCombat self)
        {
            if (self.TryGetStoredData(Ecstasy.Gray, out UnitStoreDataHolder holder, false) && holder.m_MainData > 0 && holder.m_ObjectData is EnemySO enem)
            {
                if (enem.enterEffects != null)
                {
                    CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(enem.enterEffects, self));
                }
                return;
            }

            orig(self);
        }
    }
    public class TransformerUIAction : CombatAction
    {
        public IUnit unit;
        public EnemySO enemy;
        public TransformerUIAction(IUnit unit, EnemySO enemy)
        {
            this.unit = unit;
            this.enemy = enemy;
        }
        public static void Transform(IUnit unit, Sprite image)
        {
            if (unit.IsUnitCharacter) return;
            if (CombatManager.Instance._combatUI._enemiesInCombat.TryGetValue(unit.ID, out var value))
            {
                if (CombatManager.Instance._combatUI._enemyZone._enemies.Length > value.FieldID)
                {
                    CombatManager.Instance._combatUI._enemyZone._enemies[value.FieldID].FieldEntity.m_Data.m_Locator.transform.Find("Sprite").Find("Icon").GetComponent<SpriteRenderer>().sprite = image;

                    Vector3 newpos = CombatManager.Instance._combatUI._enemyZone._enemies[value.FieldID].FieldEntity.m_Data.m_Locator.transform.Find("Sprite").Find("Icon").position;
                    newpos.y = image.pivot.y < 1 ? 2.06f : 2.56f;
                    //if (image.pivot.y != 0f & image.pivot.y != 0.5f) Debug.Log("sprite pivot Y " + image.pivot.y);

                    Vector3 newscale = CombatManager.Instance._combatUI._enemyZone._enemies[value.FieldID].FieldEntity.m_Data.m_Locator.transform.Find("Sprite").Find("Icon").localScale;
                    if (image.pivot.y > 32)
                    {
                        newscale.x = 0.6f;
                        newscale.y = 0.6f;
                    }
                    else
                    {
                        newscale.x = 1f;
                        newscale.y = 1f;
                    }

                    CombatManager.Instance._combatUI._enemyZone._enemies[value.FieldID].FieldEntity.m_Data.m_Locator.transform.Find("Sprite").Find("Icon").position = newpos;
                    CombatManager.Instance._combatUI._enemyZone._enemies[value.FieldID].FieldEntity.m_Data.m_Locator.transform.Find("Sprite").Find("Icon").localScale = newscale;
                }
            }
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (unit is EnemyCombat target)
            {
                if (target.Enemy.name == Ecstasy.Gray)
                {
                    Sprite icon = enemy.enemySprite;

                    if (enemy.name == Ecstasy.Gray)
                    {
                        icon = TransformerEnemyHandler.Wish;
                    }

                    Transform(target, icon);
                }
            }
            yield return null;
        }
    }

    public class GenerateNewEnemyTurnEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            List<EnemyCombat> list1 = [];
            List<int> abilities = [];

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit is EnemyCombat enemy)
                {
                    int[] temp = enemy.GetNextAbilitySlotUsage();
                    for (int i = 0; i < temp.Length; i++) list1.Add(enemy);
                    abilities.AddRange(temp);
                }
            }

            stats.timeline.AddExtraEnemyTurns(list1, abilities);

            exitAmount = list1.Count;
            return exitAmount > 0;
        }
    }
    public class TransformRandomEnemyEffect : CasterTransformationEffect
    {
        public static EnemySO GetRandomEnemy(EnemySO exclude = null, int attempts = 0)
        {
            EnemySO ret;

            if (LoadedDBsHandler.EnemyDB.TryGetEnemyPoolEffect(PoolList_GameIDs.Bronzo.ToString(), out SpawnRandomEnemyAnywhereEffect list))
            {
                ret =  list._enemies.GetRandom();
            }
            else
            {
                ret = LoadedAssetsHandler.LoadedEnemies.Values.ToArray().GetRandom();
            }

            if (ret == null || ret.Equals(null)) return GetRandomEnemy(exclude, attempts + 1);

            if (exclude == null) return ret;

            if (attempts > 10) Debug.LogWarning("ecstasy99 what are you doing????");
            if ((ret.name == exclude.name || ret == exclude) && attempts < 999) return GetRandomEnemy(exclude, attempts + 1);

            return ret;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _fullyHeal = false;
            _maintainMaxHealth = true;
            _maintainTimelineAbilities = false;

            int origSize = -1;
            bool is_selfing = false;

            EnemySO exclude = null;
            if (caster.TryGetStoredData(Ecstasy.Gray, out UnitStoreDataHolder holder, false) && holder.m_MainData > 0 && holder.m_ObjectData is EnemySO en)
            {
                exclude = en;
                is_selfing = true;
            }
            else if (caster is EnemyCombat enemyself)
            {
                exclude = enemyself.Enemy;
            }
            //Debug.Log("transforming; exclude isnt null: " + (exclude != null).ToString());

            _enemyTransformation = GetRandomEnemy(exclude);
            if (is_selfing)
            {
                origSize = _enemyTransformation.size;
                _enemyTransformation.size = caster.Size;
            }

            bool ret = base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);

            if (origSize > 0)
            {
                _enemyTransformation.size = origSize;
            }

            return ret;
        }
    }
    public class ShowMissDosePassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Miss-Dose", ResourceLoader.LoadSprite("MissDosePassive.png")));
            return true;
        }
    }
}
