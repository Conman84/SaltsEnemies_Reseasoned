using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace SaltsEnemies_Reseasoned
{
    public static class Skyloft
    {
        public static void Add()
        {
            Enemy skyloft = new Enemy("Skyloft", "Skyloft_EN")
            {
                Health = 2,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("SkyloftIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SkyloftDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SkyloftWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("WindSong_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("WindSong_EN").deathSound,
            };
            skyloft.PrepareEnemyPrefab("assets/group4/Skyloft/Skyloft_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Skyloft/Skyloft_Gibs.prefab").GetComponent<ParticleSystem>());


            //EVASIVE
            Connection_PerformEffectPassiveAbility evasive = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            evasive._passiveName = "Evasive";
            evasive.passiveIcon = ResourceLoader.LoadSprite("Dodge.png");
            evasive.m_PassiveID = "Evasive_PA";
            evasive._enemyDescription = "Permanently applies Dodge to this enemy.";
            evasive._characterDescription = "Permanently applies Dodge to this character.";
            evasive.doesPassiveTriggerInformationPanel = true;
            evasive.connectionEffects = new EffectInfo[] { Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPermanentDodgeEffect>(), 1, Slots.Self) }), 1, Slots.Self) };
            evasive.disconnectionEffects = new EffectInfo[0];
            evasive._triggerOn = new TriggerCalls[] { TriggerCalls.Count };

            //LAZY
            PerformEffectPassiveAbility lazy = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            lazy._passiveName = "Lazy (2)";
            lazy.passiveIcon = ResourceLoader.LoadSprite("Lazy.png");
            lazy._enemyDescription = "When fleeing, this enemy will return after 2 rounds if combat hasn't ended.";
            lazy._characterDescription = "When fleeing, this character will return at the end of the next 2 rounds if combat hasn't ended.";
            lazy.m_PassiveID = ButterflyUnboxer.SkyloftPassive;
            lazy.doesPassiveTriggerInformationPanel = true;
            lazy._triggerOn = new TriggerCalls[] { TriggerCalls.OnFleeting };
            lazy.effects = new EffectInfo[0];
            lazy.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<NotFlitheringCondition>() };

            //FLITHERING
            PerformEffectPassiveAbility flither = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            flither._passiveName = "Flithering";
            flither.passiveIcon = ResourceLoader.LoadSprite("FlitheringIcon.png");
            flither.m_PassiveID = FlitheringHandler.Flithering;
            flither._enemyDescription = "On any enemy dying, if there are no other enemies without \"Withering\" or \"Flithering\" as passives, instantly flee.\n" +
                "At the start and end of the enemies' turn, if there are no other enemies without \"Cowardice\" or \"Flithering\" as passives, instantly flee.";
            flither._characterDescription = "doesnt work";
            flither.doesPassiveTriggerInformationPanel = false;
            flither.effects = new EffectInfo[] { Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CowardEffect>(), 1, Slots.Self)
            }), 1, Slots.Self) };
            flither._triggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy, TriggerCalls.OnRoundFinished };
            flither.conditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<CowardCondition>()
            };

            //ADDPASSIVES
            skyloft.AddPassives(new BasePassiveAbilitySO[] { evasive, Passives.Cashout, lazy, flither });

            //lose control
            SkyloftIntent.Setup();
            Ability lose = new Ability("LoseControl_A")
            {
                Name = "Lose Control",
                Description = "Make the Opposing party member perform a random ability.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, Slots.Front),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                AnimationTarget = Slots.Front,
            };
            lose.AddIntentsToTarget(Slots.Front, SkyloftIntent.Intent.SelfArray());

            //sing
            TargettingByHealthNotSkyloft lowest = ScriptableObject.CreateInstance<TargettingByHealthNotSkyloft>();
            lowest.Lowest = true;
            lowest.getAllies = true;
            lowest.ignoreCastSlot = true;
            Ability sing = new Ability("SingForMe_A")
            {
                Name = "Sing for Me",
                Description = "Apply Spotlight and 1 Haste to the enemy with the lowest health that isn't a Skyloft. \n\"Just so I know you're near\"",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.PlaySound("event:/Hawthorne/Hurt/BirdSound"), 1, lowest),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, lowest),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyHasteEffect>(), 1, lowest)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Spotlight"),
                AnimationTarget = lowest,
            };
            sing.AddIntentsToTarget(lowest, new string[] { IntentType_GameIDs.Status_Spotlight.ToString(), Haste.Intent });

            //GONE
            Ability gone = new Ability("TooFarGone_A")
            {
                Name = "Too Far Gone",
                Description = "Instantly flee.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("skyloft3", 3),
                Priority = Priority.ExtremelyFast,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            gone.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.PA_Fleeting.ToString().SelfArray());


            //ADD ENEMY
            skyloft.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                lose.GenerateEnemyAbility(true),
                sing.GenerateEnemyAbility(true),
                gone.GenerateEnemyAbility(true)
            });
            skyloft.AddEnemy(true, true, true);
        }
    }
}
