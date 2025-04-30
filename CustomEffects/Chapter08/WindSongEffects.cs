using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using SaltsEnemies_Reseasoned;

/*I DID THESE*/
//call WindSongManager.Setup() in awake
//also for the WindSong's special intent, call WindSongManager.Intent

namespace SaltEnemies_Reseasoned
{
    public static class WindSongManager
    {
        public static ParticleSystem MainEffect;
        public static ParticleSystem SideEffectOne;
        public static ParticleSystem SideEffectTwo;
        public static string Intent => "Dmg_Coda";
        public static DamageInfo Damage(Func<EnemyCombat, int, IUnit, string, int, bool, bool, bool, string, DamageInfo> orig, EnemyCombat self, int amount, IUnit killer, string deathType, int targetSlotOffset = -1, bool addHealthMana = true, bool directDamage = true, bool ignoresShield = false, string specialDamage = "")
        {
            if (Check.EnemyExist("WindSong_EN") && self.Enemy == LoadedAssetsHandler.GetEnemy("WindSong_EN"))
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

                    CombatManager.Instance.AddUIAction(new WindSongUIActionAgain(self.ID, num3 == 0));
                    CombatManager.Instance.AddUIAction(new EnemyDamagedUIAction(self.ID, self.CurrentHealth, self.MaximumHealth, modifiedValue, specialDamage));
                    //TrySpawnWindSongEffect(CombatManager.Instance._stats.combatUI, self.ID, num3 == 0);
                    if (addHealthMana)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(self.HealthColor, LoadedDBsHandler.CombatData.EnemyPigmentAmount, self.IsUnitCharacter, self.ID));
                    }

                    CombatManager.Instance.PostNotification(TriggerCalls.OnDamaged.ToString(), self, new IntegerReference(num4));
                    if (directDamage)
                    {
                        CombatManager.Instance.PostNotification(TriggerCalls.OnDirectDamaged.ToString(), self, new IntegerReference(num4));
                    }
                }
                else if (!ex.ShouldIgnoreUI)
                {
                    CombatManager.Instance.AddUIAction(new EnemyNotDamagedUIAction(self.ID));
                }

                bool flag = self.CurrentHealth == 0 && num4 != 0;
                if (flag)
                {
                    CombatManager.Instance.AddSubAction(new EnemyDeathAction(self.ID, killer, deathType));
                }

                return new DamageInfo(num4, flag);
            }
            return orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
        }
        public class WindSongUIActionAgain : CombatAction
        {
            public int ID;
            public bool Extra;
            public WindSongUIActionAgain(int ID, bool Extra)
            {
                this.ID = ID;
                this.Extra = Extra;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                TrySpawnWindSongEffect(stats.combatUI, ID, Extra);
                yield return null;
            }
        }
        public static void TrySpawnWindSongEffect(CombatVisualizationController UI, int id, bool extra = false)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID, extra);
            }
        }
        public static void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID, bool extra)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity, extra);
        }
        public static void SpawnEffect(EnemyInFieldLayout field, bool extra)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(MainEffect, field.transform.position, field.transform.rotation);
            if (!extra) return;
            //Quaternion randomRot = new Quaternion(field.transform.rotation.x, UnityEngine.Random.Range(0, 360), field.transform.rotation.z, field.transform.rotation.w);
            UnityEngine.Object.Instantiate(SideEffectOne, field.transform.position, field.transform.rotation);
            UnityEngine.Object.Instantiate(SideEffectTwo, field.transform.position, field.transform.rotation);
        }
        public static void Setup()
        {
            string ID = "WindSong";
            MainEffect = SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Effect.prefab").GetComponent<ParticleSystem>();
            SideEffectOne = SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Burst.prefab").GetComponent<ParticleSystem>();
            SideEffectTwo = SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Blast.prefab").GetComponent<ParticleSystem>();
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.Damage), ~BindingFlags.Default), typeof(WindSongManager).GetMethod(nameof(Damage), ~BindingFlags.Default));
            Intents.CreateAndAddCustom_Damage_IntentToPool(Intent, ResourceLoader.LoadSprite("intentcoda.png"), (Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_3_6) as IntentInfoDamage).GetColor(true), ResourceLoader.LoadSprite("intentcoda.png"), (Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_3_6) as IntentInfoDamage).GetColor(false));
        }
    }
    public class WindSongEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter)
            {
                return false;
            }

            TrySpawnWindSongEffect(stats.combatUI, caster.ID);
            //CombatManager.Instance.AddUIAction(new WindSongEffectUIAction(caster.ID));
            return true;
        }

        public void TrySpawnWindSongEffect(CombatVisualizationController UI, int id)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID);
            }
        }
        public void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity);
        }
        public void SpawnEffect(EnemyInFieldLayout field)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(WindSongManager.MainEffect, field.transform.position, field.transform.rotation);
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(field.EnemyID, out var value))
            {
                Quaternion randomRot = new Quaternion(field.transform.rotation.x, UnityEngine.Random.Range(0, 360), field.transform.rotation.z, field.transform.rotation.w);
                if (Check.EnemyExist("WindSong_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("WindSong_EN") && value.CurrentHealth <= 0)
                {
                    UnityEngine.Object.Instantiate(WindSongManager.SideEffectOne, field.transform.position, randomRot);
                    UnityEngine.Object.Instantiate(WindSongManager.SideEffectTwo, field.transform.position, randomRot);
                }
            }
        }
    }
    public class WindSongEffectUIAction : CombatAction
    {
        public int _enemyID;

        public WindSongEffectUIAction(int enemyID)
        {
            _enemyID = enemyID;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            TrySpawnWindSongEffect(stats.combatUI, _enemyID);
            yield break;
        }

        public void TrySpawnWindSongEffect(CombatVisualizationController UI, int id)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID);
            }
        }

        public void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity);
        }

        public void SpawnEffect(EnemyInFieldLayout field)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(WindSongManager.MainEffect, field.transform.position, field.transform.rotation);
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(field.EnemyID, out var value))
            {
                Quaternion randomRot = new Quaternion(field.transform.rotation.x, UnityEngine.Random.Range(0, 360), field.transform.rotation.z, field.transform.rotation.w);
                if (Check.EnemyExist("WindSong_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("WindSong_EN") && value.CurrentHealth <= 0)
                {
                    UnityEngine.Object.Instantiate(WindSongManager.SideEffectOne, field.transform.position, randomRot);
                    UnityEngine.Object.Instantiate(WindSongManager.SideEffectTwo, field.transform.position, randomRot);
                }
            }
        }
    }
    public class WindSongEnterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("WindSong", 1);
            return true;
        }
    }
    public class WindSongExitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (!Check.EnemyExist("WindSong_EN")) break;
                if (!enemy.IsAlive) continue;
                if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("WindSong_EN")) return false;
            }
            CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("WindSong", 0);
            return true;
        }
    }
}
