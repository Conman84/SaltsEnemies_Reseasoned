using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem.HID;

namespace SaltsEnemies_Reseasoned
{
    public static class Maw
    {
        public static void Add()
        {
            Enemy maw = new Enemy("Maw", "Maw_EN")
            {
                Health = 40,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("MawIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MawWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MawDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("LongLiver_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Leviat_CH").deathSound,
                Priority = Priority.VeryFast
            };
            maw.PrepareEnemyPrefab("assets/group4/Maw/Maw_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Maw/Maw_Gibs.prefab").GetComponent<ParticleSystem>());

            //BAD DOG
            BadDogPassiveAbility bad = ScriptableObject.CreateInstance<BadDogPassiveAbility>();
            bad._passiveName = "Bad Dog";
            bad.m_PassiveID = "BadDog_PA";
            bad.passiveIcon = ResourceLoader.LoadSprite("MawPassive.png");
            bad._enemyDescription = "During the player's turn, whenever anything moves, if this enemy has an Opposing party member, remove all of its actions from the timeline. \nOtherwise, return all lost actions.";
            bad._characterDescription = "wont work";
            bad.doesPassiveTriggerInformationPanel = true;
            bad.effects = new EffectInfo[0];
            bad._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };

            maw.AddPassives(new BasePassiveAbilitySO[] { bad, Passives.MultiAttack3, Passives.Slippery });

            //HIDE
            Ability hide = new Ability("Hide", "BadDog_Hide_A");
            hide.Description = "Moves Left or Right then applies 10 Shield to this enemy's current position. \nDeals a Painful amount of damage to the Opposing party member and moves them to the Left or Right.";
            hide.Rarity = Rarity.GetCustomRarity("rarity5");
            hide.Effects = new EffectInfo[5];
            hide.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            hide.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Entwined_1_A", true, Slots.Front));
            hide.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, Slots.Self);
            hide.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);
            hide.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Front);
            hide.AddIntentsToTarget(Slots.Self, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Field_Shield.ToString() });
            hide.AddIntentsToTarget(Slots.Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Swap_Sides.ToString() });
            hide.Visuals = null;
            hide.AnimationTarget = Slots.Self;

            //SEEK
            AnimationVisualsEffect a = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            a._animationTarget = Slots.Front;
            a._visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals;
            Ability seek = new Ability("BadDog_Seek_A")
            {
                Name = "Seek",
                Description = "Move to the Left or Right 3 times. Deal an Agonizing amount of damage to the Opposing party member and inflict 3 Ruptured on them.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                            Effects.GenerateEffect(a, 1, Slots.Self),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, Slots.Front)
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            seek.AddIntentsToTarget(Slots.Self, new string[] { "Swap_Sides", "Swap_Sides", "Swap_Sides" });
            seek.AddIntentsToTarget(Slots.Front, new string[] {IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });

            //STAY
            Ability stay = new Ability("Stay", "BadDog_Stay_A");
            stay.Description = "Inflict 2 Constricted on the Opposing party member position.\nInflict 5 Ruptured on the Opposing party member.";
            stay.Rarity = Rarity.GetCustomRarity("rarity5");
            stay.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 5, Slots.Front)
            };
            stay.AddIntentsToTarget(Slots.Front, new string[] { IntentType_GameIDs.Field_Constricted.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });
            stay.AnimationTarget = Slots.Front;
            stay.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;

            //Play
            Ability play = new Ability("Play!!", "BadDog_Play_A");
            play.Description = "Deal a Painful amount of damage to the Opposing party member and inflict 2 Ruptured on them.\nMove to the Left or Right.";
            play.Rarity = Rarity.GetCustomRarity("rarity5");
            play.Effects = new EffectInfo[3];
            play.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);
            play.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.Front);
            play.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            play.AddIntentsToTarget(Slots.Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });
            play.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());
            play.Visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals;
            play.AnimationTarget = Slots.Front;

            //salivate
            Ability salivate = new Ability("Salivate", "BadDog_Salivate_A");
            salivate.Description = "Inflict 3 Oil-Slicked on all enemies and party members.";
            salivate.Rarity = Rarity.GetCustomRarity("rarity5");
            salivate.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, Targeting.AllUnits).SelfArray();
            salivate.AddIntentsToTarget(Targeting.Unit_AllAllies, IntentType_GameIDs.Status_OilSlicked.ToString().SelfArray());
            salivate.AddIntentsToTarget(Targeting.Unit_AllOpponents, IntentType_GameIDs.Status_OilSlicked.ToString().SelfArray());
            salivate.Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            salivate.AnimationTarget = Slots.Self;

            //ADD ENEMY
            maw.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                hide.GenerateEnemyAbility(true),
                seek.GenerateEnemyAbility(true),
                stay.GenerateEnemyAbility(true),
                play.GenerateEnemyAbility(true),
                salivate.GenerateEnemyAbility(true)
            });
            maw.AddEnemy(true, true);
        }
    }
}
