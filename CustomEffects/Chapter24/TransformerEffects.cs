using BrutalAPI;
using HarmonyLib;
using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace SaltsEnemies_Reseasoned
{
    public class TransformerEnemyHandler
    {
        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.TransformEnemy), ~BindingFlags.Default), typeof(TransformerEnemyHandler).GetMethod(nameof(EnemyCombat_TransformEnemy), ~BindingFlags.Default));
        }
        public static void EnemyCombat_TransformEnemy(Action<EnemyCombat, EnemySO, bool, bool, bool> orig, EnemyCombat self, EnemySO enemy, bool fullyHeal, bool maintainMaxHealth, bool currentToMaxHealth)
        {
            if (self.Enemy.name != Ecstasy.Gray)
            {
                orig(self, enemy, fullyHeal, maintainMaxHealth, currentToMaxHealth);
                return;
            }


            self.FinalizationEnd();
            //self.Enemy = enemy;
            //self.Name = self.Enemy.GetName();
            //self.UnitTurnSprite = self.Enemy.enemySprite;
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
            //self.DefaultPassiveAbilityInitialization();

            if (self.ExternalPassives != null)
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
            }

            if (enemy.passiveAbilities == null)
            {
                return;
            }

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
}
