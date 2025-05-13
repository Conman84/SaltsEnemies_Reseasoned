using FMODUnity;
using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static SaltsEnemies_Reseasoned.Check;

namespace SaltsEnemies_Reseasoned
{
    public static class GibsFix
    {
        public static IEnumerator PlayEnemyDeathAnimation(Func<EnemyInFieldLayout, string, IEnumerator> orig, EnemyInFieldLayout self, string deathSound)
        {
            IEnumerator ret = orig(self, deathSound);
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (EnemyExist("SnakeGod_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("SnakeGod_EN"))
                {
                    self.StartCoroutine(self.PlayGibs(0.2f));
                }
                else if (EnemyExist("Skyloft_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Skyloft_EN"))
                {
                    self.StartCoroutine(self.PlayGibs(0.5f));
                }
                else if (EnemyExist("GreyFlower_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("GreyFlower_EN"))
                {
                    self.StartCoroutine(self.PlayGibs(0.2f));
                }
                else if (EnemyExist("MortalSpoggle_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("MortalSpoggle_EN"))
                {
                    //I think we fixed the mortal spoggle gibs already
                    //self.StartCoroutine(self.PlayGibs(0.2f));
                }
            }
            return ret;
        }
        public static IEnumerator PlayGibs(this EnemyInFieldLayout layout, float time)
        {
            float gap = time;
            while (gap > 0)
            {
                yield return null;
                gap -= Time.deltaTime;
            }
            layout.SpawnGibs();
            yield return null;
        }

        public static void SpawnGibs(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout self)
        {
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (EnemyExist("WindSong_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("WindSong_EN") && value.CurrentHealth > 0)
                {
                    if (self.m_Data.m_Gibs != null)
                    {
                        RuntimeManager.PlayOneShot(self.m_Data.m_GibsEvent, self.Position);
                        UnityEngine.Object.Instantiate(self.m_Data.m_Gibs, self.transform.position, self.transform.rotation);
                        return;
                    }
                }
                if (EnemyExist("TheDragon_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("TheDragon_EN"))
                {
                    if (self.m_Data.m_Gibs != null && self.m_Data.m_Animator.GetBool("Awake"))
                    {
                        RuntimeManager.PlayOneShot(self.m_Data.m_GibsEvent, self.Position);
                        UnityEngine.Object.Instantiate(self.m_Data.m_Gibs, self.transform.position, self.transform.rotation);
                        return;
                    }
                    else
                    {
                        RuntimeManager.PlayOneShot(self.m_Data.m_GibsEvent, self.Position);
                        UnityEngine.Object.Instantiate(Dragon.Green, self.transform.position, self.transform.rotation);
                        return;
                    }
                }
            }
            orig(self);
        }

        //------------------this seems to be the thing that makes the butterfly's hit sound not play when it flees which i already fixed withs omething else? accidentally
        /*
        public static IEnumerator PlayEnemyFleetingAnimation(Func<EnemyZoneHandler, int, string, string, IEnumerator> orig, EnemyZoneHandler self, int fieldID, string enemySound, string exitType)
        {
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self._enemies[fieldID].FieldEntity.EnemyID, out var value))
            {
                if (EnemyExist("Butterfly_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Butterfly_EN"))
                {
                    Vector3 fieldPosition = self._enemies[fieldID].FieldPosition;
                    self._unitSoundsHandler.PlayExitEvent(fieldPosition, exitType);

                    yield return self._enemies[fieldID].FieldEntity.PlayFleeting();
                }
                else yield return orig(self, fieldID, enemySound, exitType);
            }
            else yield return orig(self, fieldID, enemySound, exitType);
        }
        */

        public static void DamageEnemy(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout self)
        {
            orig(self);
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (EnemyExist("2009_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("2009_EN"))
                {
                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                    {
                        if (enemy.ID != self.EnemyID) continue;
                        if (enemy.SimpleGetStoredValue(TriggerOnlyOnceEffectCondition.Value) <= 0)
                        {
                            enemy.SimpleSetStoredValue(TriggerOnlyOnceEffectCondition.Value, 1);
                            SetMusicParameterByStringEffect.Trigger("2009", 1);
                        }
                    }
                }
                if (EnemyExist("Wednesday_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Wednesday_EN"))
                {
                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                    {
                        if (enemy.ID != self.EnemyID) continue;
                        if (enemy.SimpleGetStoredValue(TriggerOnlyOnceEffectCondition.Value) <= 0)
                        {
                            enemy.SimpleSetStoredValue(TriggerOnlyOnceEffectCondition.Value, 1);
                            WednesdayEffect.Trigger(true);
                        }
                    }
                }
            }
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.PlayEnemyDeathAnimation), ~BindingFlags.Default), typeof(GibsFix).GetMethod(nameof(PlayEnemyDeathAnimation), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.SpawnGibs), ~BindingFlags.Default), typeof(GibsFix).GetMethod(nameof(SpawnGibs), ~BindingFlags.Default));
            //IDetour rock = new Hook(typeof(EnemyZoneHandler).GetMethod(nameof(EnemyZoneHandler.PlayEnemyFleetingAnimation), ~BindingFlags.Default), typeof(GibsFix).GetMethod(nameof(PlayEnemyFleetingAnimation), ~BindingFlags.Default));
            IDetour horse = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.DamageEnemy), ~BindingFlags.Default), typeof(GibsFix).GetMethod(nameof(DamageEnemy), ~BindingFlags.Default));
        }
    }
}
