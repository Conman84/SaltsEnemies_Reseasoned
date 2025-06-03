using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Miriam
    {
        public static void Add()
        {
            Enemy miriam = new Enemy("Miriam", "Miriam_EN")
            {
                Health = 60,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("MiriamIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MiriamWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MiriamDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Bimini_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Bimini_CH").deathSound,
            };
            miriam.PrepareEnemyPrefab("assets/group4/Miriam/Miriam_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Miriam/Miriam_Gibs.prefab").GetComponent<ParticleSystem>());

            miriam.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, Passives.MultiAttack2, Passives.Formless });
            miriam.AddLootData(new EnemyLootItemProbability[] { new EnemyLootItemProbability() { isItemTreasure = true, amount = 3, probability = 100 } });


            Intents.CreateAndAddCustom_Damage_IntentToPool("Damage_Delay", ResourceLoader.LoadSprite("DelayedAttackIcon.png"), (Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_11_15) as IntentInfoDamage).GetColor(true),
                ResourceLoader.LoadSprite("DelayedAttackIcon.png"), (Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_11_15) as IntentInfoDamage).GetColor(false));

            //see dream
            Ability dreams = new Ability("SeeWhatIDream_A")
            {
                Name = "See What I Dream",
                Description = "Inflict 2 Ruptured and apply 3 Dodge on the Opposing party member. Move this enemy to the Left or Right.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("miriam4", 4),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 3, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals,
                AnimationTarget = Slots.Front,
            };
            dreams.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Status_Ruptured.ToString(), Dodge.Intent]);
            dreams.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);

            //take bones
            Ability bones = new Ability("TakeMyBones_A")
            {
                Name = "Take My Bones",
                Description = "At the start of the next turn, deal an Agonizing amount of damage to this enemy's current Left and Right party member positions. Deal a Painful amount of damage to this enemy, this damage ignores Shield.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 7, Slots.LeftRight),
                    Effects.GenerateEffect(BasicEffects.ShieldPierce, 3, Slots.Self)
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals,
                AnimationTarget = MultiTargetting.Create(Slots.LeftRight, Slots.Self),
            };
            bones.AddIntentsToTarget(Slots.LeftRight, [IntentType_GameIDs.Damage_7_10.ToString(), "Damage_Delay"]);
            bones.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_3_6.ToString()]);

            //lies
            Ability lies = new Ability("BeyondTheLies_A")
            {
                Name = "Beyond the Lies",
                Description = "Deal a Painful amount of damage to the Opposing party member. \nIf there is no Opposing party member, at the start of the next turn deal a Painful amount of damage to all party member positions not currently facing an enemy. \n\"All things live and all things die\"",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<IsUnitEffect>(), 1, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Crush_A", false, Slots.Front), 1, null, BasicEffects.DidThat(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Wriggle_A", false, ScriptableObject.CreateInstance<TargettingByFacingTarget>()), 1, null, BasicEffects.DidThat(false, 3)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 5, ScriptableObject.CreateInstance<TargettingByFacingTarget>(), BasicEffects.DidThat(false, 4)),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            lies.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Misc_Hidden.ToString()]);
            lies.AddIntentsToTarget(ScriptableObject.CreateInstance<TargettingByFacingTarget>(), [IntentType_GameIDs.Damage_3_6.ToString(), "Damage_Delay"]);

            //die
            Ability die = new Ability("IWantToDieWithYou_A")
            {
                Name = "I Want to Die with You",
                Description = "Move to a random position. At the start of the next turn, deal a really really really large amount of damage to the current Opposing party member position. \n\"As I want to live with you\"",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("miriam3", 3),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, Slots.Self),
                            Effects.GenerateEffect(SubActionEffect.Create(new EffectInfo[]
                            {
                                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Bullet", false, Slots.Front), 1, Slots.Self),
                                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 99, Slots.Front)
                            }), 1, Slots.Self),
                            Effects.GenerateEffect(BasicEffects.Empty, 0, Slots.Front)
                        },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            die.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Mass.ToString()]);
            die.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_Death.ToString(), "Damage_Delay"]);

            //ADD ENEMY
            miriam.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                dreams.GenerateEnemyAbility(true),
                bones.GenerateEnemyAbility(true),
                lies.GenerateEnemyAbility(true),
                die.GenerateEnemyAbility(true)
            });
            miriam.AddEnemy(true);
        }
    }
}
