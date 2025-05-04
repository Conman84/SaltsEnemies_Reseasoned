using BrutalAPI;
using FMODUnity;
using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

//raise Shua's fleeting to 4 instead of 3

//note: SaltEnemies.CursedNoise = "event:/Combat/StatusEffects/SE_Cursed_Apl"

//when setting up shua, make sure UnitTypes = new List<string> { "FemaleID" }

namespace SaltEnemies_Reseasoned
{
    public class AbilitySelector_Shua : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string wanderlust = "Wanderlust";

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
            return unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()) == 1 && name == this.wanderlust;
        }
    }
    public static class ShuaHandler
    {
        static ParticleSystem hits;
        public static ParticleSystem Hits
        {
            get
            {
                if (hits == null)
                {
                    hits = SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/group4/Shua/Shua_HitEffect.prefab").GetComponent<ParticleSystem>();
                }
                return hits;
            }
        }
        public static void DamageEnemy(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout self)
        {
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (Check.EnemyExist("Shua_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Shua_EN"))
                {
                    UnityEngine.Object.Instantiate(Hits, self.transform.position, self.transform.rotation);
                }
            }
            orig(self);
        }
        public static IEnumerator PlayEnemyDeathAnimation(Func<EnemyInFieldLayout, string, IEnumerator> orig, EnemyInFieldLayout self, string deathSound)
        {
            bool IS = false;
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (Check.EnemyExist("BlackStar_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("BlackStar_EN"))
                {
                    IS = true;
                }
                else if (Check.EnemyExist("Singularity_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Singularity_EN"))
                {
                    IS = true;
                }
            }
            if (!IS)
            {
                yield return orig(self, deathSound);
            }
            else
            {
                self.FinishedAnimation = false;
                self.m_Data.m_Animator.SetTrigger("Dying");
                if (deathSound != "")
                {
                    RuntimeManager.PlayOneShot(deathSound, self.Position);
                    RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/RingingSound", self.Position);
                }

                float saveCounter = self.m_Data.m_SaveAnimationTime;
                while (!self.FinishedAnimation)
                {
                    yield return null;
                    saveCounter -= Time.deltaTime;
                    if (saveCounter <= 0f)
                    {
                        break;
                    }
                }

                self.FinishedAnimation = true;
            }
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.DamageEnemy), ~BindingFlags.Default), typeof(ShuaHandler).GetMethod(nameof(DamageEnemy), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.PlayEnemyDeathAnimation), ~BindingFlags.Default), typeof(ShuaHandler).GetMethod(nameof(PlayEnemyDeathAnimation), ~BindingFlags.Default));
        }
    }
}
