using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Nume
    {
        public static void Add()
        {
            Enemy nume = new Enemy("Nume", "Nume_EN")
            {
                Health = 25,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("NumeIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("NumeWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("NumeDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Enigma_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Enigma_EN").deathSound,
            };
            nume.PrepareEnemyPrefab("Assets/wip5/Nume_Wip_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Nume_Wip_Gibs.prefab").GetComponent<ParticleSystem>());

            PerformEffectImmediaterPassiveAbility causality = ScriptableObject.CreateInstance<PerformEffectImmediaterPassiveAbility>();
            causality.name = "Causality_3_PA";
            causality._passiveName = "Causality (3)";
            causality.m_PassiveID = "Causality_PA";
            causality.passiveIcon = ResourceLoader.LoadSprite("CausalityPassive.png");
            causality._enemyDescription = "On moving, deal a Barely Painful amount of damage to the current Opposing party member position at the start of the next turn.";
            causality._characterDescription = "On moving, deal a Barely Painful amount of damage to the current Opposing enemy position at the start of the next turn.";
            causality._triggerOn = [TriggerCalls.OnMoved];
            causality.conditions = [];
            causality.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 5, Slots.Front)];
            causality.AddToPassiveDatabase();

            //Revenge
            PerformEffectPassiveAbility revenge = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            revenge._passiveName = "Revenge";
            revenge.m_PassiveID = "Revenge_PA";
            revenge.passiveIcon = ResourceLoader.LoadSprite("Revenge.png");
            revenge._characterDescription = "On taking direct damage, give this enemy another ability.";
            revenge._enemyDescription = "On taking direct damage, give this enemy another action.";
            revenge.doesPassiveTriggerInformationPanel = true;
            revenge.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            revenge._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            revenge.conditions = Passives.Slippery.conditions;

            nume.AddPassives(new BasePassiveAbilitySO[] { causality, revenge, Passives.Skittish });


            Ability mars = new Ability("Mars", "Nume_Mars_A");
            mars.Description = "Inflict 2 Ruptured to the Opposing party member.";
            mars.Rarity = Rarity.CreateAndAddCustomRarityToPool("nume7", 7);
            mars.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.Front)];
            mars.AddIntentsToTarget(Slots.Front, ["Status_Ruptured"]);
            mars.AnimationTarget = Slots.Front;
            mars.Visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;

            Ability venus = new Ability("Venus", "Nume_Venus_A");
            venus.Description = "Inflict 2 Oil-Slicked to this enemy.";
            venus.Rarity = Rarity.GetCustomRarity("nume7");
            venus.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, Slots.Self)];
            venus.AddIntentsToTarget(Slots.Self, ["Status_OilSlicked"]);
            venus.AnimationTarget = Slots.Self;
            venus.Visuals = CustomVisuals.GetVisuals("Salt/Think");

            Ability murcury = new Ability("Murcury", "Nume_Murcury_A");
            murcury.Description = "Take a Little damage and Slightly heal this enemy.";
            murcury.Rarity = Rarity.GetCustomRarity("rarity5");
            murcury.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 2, Slots.Self)
                ];
            murcury.AddIntentsToTarget(Slots.Self, ["Damage_1_2", "Heal_1_4"]);
            murcury.AnimationTarget = Slots.Self;
            murcury.Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;

            //ADD ENEMY
            nume.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                mars.GenerateEnemyAbility(true),
                venus.GenerateEnemyAbility(true),
                murcury.GenerateEnemyAbility(true)
            });
            nume.SilentAddEnemy(true, true);
            nume.enemy.AddToSynodPool();
        }
    }
}
