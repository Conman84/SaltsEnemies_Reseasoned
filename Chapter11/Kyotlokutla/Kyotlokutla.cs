using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Kyotlokutla
    {
        public static void Add()
        {
            Enemy snakegod = new Enemy("Kyotlokutla", "SnakeGod_EN")
            {
                Health = 144,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("SnakeGodIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SnakeGodWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SnakeGodDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/XylophoneHit",
                DeathSound = "event:/Hawthorne/Die/XylophoneDie",
            };
            snakegod.PrepareEnemyPrefab("assets/group4/SnakeGod/SnakeGod_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/SnakeGod/SnakeGod_Gibs.prefab").GetComponent<ParticleSystem>());
            snakegod.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_SnakeGod>();

            //snakegod
            SnakeGodManager.Setup();
            SnakeGodPassive hate = ScriptableObject.CreateInstance<SnakeGodPassive>();
            hate._passiveName = "Vindictive";
            hate.passiveIcon = ResourceLoader.LoadSprite("HateYou.png");
            hate.m_PassiveID = "Vindictive_PA";
            hate._enemyDescription = "This enemy remembers its oppressors. On taking direct damage, inflict 1 Scar on the attacker.";
            hate._characterDescription = "Won't work cuz i didn't set up the hook for it lol!";
            hate.doesPassiveTriggerInformationPanel = false;
            hate._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };
            hate.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(SnakeGodManager.Last);

            snakegod.AddPassives(new BasePassiveAbilitySO[] { hate, Passives.Formless });
            snakegod.AddLootData([new EnemyLootItemProbability() { isItemTreasure = true, amount = 3, probability = 100 }]);

            //silence
            Ability silence = new Ability("SilenceTheFoolish_A")
            {
                Name = "Silence the Foolish",
                Description = "Apply 2 Muted and 2 Fire to the last party member who dealt damage to this enemy. Produce 2 Red Pigment.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 2, Targetting_BySnakeGod.Create(false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 2, Targetting_BySnakeGod.Create(false)),
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 2, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Shush"),
                AnimationTarget = Targetting_BySnakeGod.Create(false),
            };
            silence.AddIntentsToTarget(Targetting_BySnakeGod.Create(false), [Muted.Intent, IntentType_GameIDs.Field_Fire.ToString()]);
            silence.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Generate.ToString()]);

            //hang
            Ability hang = new Ability("HangTheWeak_A")
            {
                Name = "Hang the Weak",
                Description = "Inflict 1 Constricted and 3 Oil-Slicked on every party member who dealt damage to this enemy. Produce 1 Red Pigment.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Targetting_BySnakeGod.Create(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, Targetting_BySnakeGod.Create(true)),
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 1, Slots.Self)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("FallingSkies_A").visuals,
                AnimationTarget = Targetting_BySnakeGod.Create(true),
            };
            hang.AddIntentsToTarget(Targetting_BySnakeGod.Create(true), [IntentType_GameIDs.Field_Constricted.ToString(), IntentType_GameIDs.Status_OilSlicked.ToString()]);
            hang.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Generate.ToString()]);

            //suffocate
            Ability suffocate = new Ability("SuffocateThePitiful_A")
            {
                Name = "Suffocate the Pitiful",
                Description = "Apply 1 Muted to all party members. Produce 2 Red Pigment.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 1, Targetting.AllEnemy),
                            Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 2, Slots.Self)
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Shush"),
                AnimationTarget = Targetting.AllEnemy,
            };
            suffocate.AddIntentsToTarget(Targetting.AllEnemy, [Muted.Intent]);
            suffocate.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Generate.ToString()]);

            //scare
            Ability scare = new Ability("TerrifyTheFeeble_A")
            {
                Name = "Terrify the Feeble",
                Description = "Make the party member with the lowest health instantly flee. Produce 4 Red pigment.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("snakegod15", 15),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targetting.LowestEnemy),
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 4, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Forest"),
                AnimationTarget = Targetting.LowestEnemy,
            };
            scare.AddIntentsToTarget(Targetting.LowestEnemy, [IntentType_GameIDs.PA_Fleeting.ToString()]);
            scare.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Generate.ToString()]);

            //ADD ENEMY
            snakegod.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                silence.GenerateEnemyAbility(true),
                hang.GenerateEnemyAbility(true),
                suffocate.GenerateEnemyAbility(true),
                scare.GenerateEnemyAbility(true)
            });
            snakegod.AddEnemy(true, true);
        }
    }
}
