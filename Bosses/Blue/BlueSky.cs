using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BlueSky
    {
        public static void Add()
        {
            Enemy template = new Enemy("Blue Skies", "BlueSky_BOSS")
            {
                Health = 140,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("MikuWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MikuWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MikuWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Blackwater/Noise/BSHit",
                DeathSound = LoadedAssetsHandler.GetEnemy("Starless_EN").deathSound,
            };
            template.PrepareEnemyPrefab("Assets/TestSprites/Test_BlueSky_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/TestSprites/Test_BlueSky_Gibs.prefab").GetComponent<ParticleSystem>());
            //template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("WindSong_EN").enemyTemplate;


            SpecialSceneEndingSetUpEffect gameover = ScriptableObject.CreateInstance<SpecialSceneEndingSetUpEffect>();
            gameover._shouldCombatEnd = false;
            gameover._specialScene = SpecialSceneType.HardEnding;

            template.CombatEnterEffects = [Effects.GenerateEffect(gameover)];

            Unlocks.GetOrCreateUnlock_CustomFinalBoss("BlueSky_BOSS", ResourceLoader.LoadSprite("BlueSkyPearl.png"));

            PerformEffectPassiveAbility acting = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            acting.name = "Acting_PA";
            acting._passiveName = "Acting";
            //icon
            acting._enemyDescription = "On being damaged, perform this enemy's next ability on the timeline and queue another one.";
            //ch desc
            acting.m_PassiveID = "Acting_PA";
            acting.doesPassiveTriggerInformationPanel = true;
            acting._triggerOn = [TriggerCalls.OnDirectDamaged];
            acting.effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetForceFirstActionEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self, BasicEffects.DidThat(true))
                ];
            acting.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<HasTurnsCondition>() }.ToArray();

            template.AddPassives(new BasePassiveAbilitySO[] { acting, Passives.MultiAttack2, Passives.EssenceRed });

            ChangeTargetHealthColorEffect turnRed = ScriptableObject.CreateInstance<ChangeTargetHealthColorEffect>();
            turnRed.mana = Pigments.Red;
            DoubleTargetting doubleFront = ScriptableObject.CreateInstance<DoubleTargetting>();
            doubleFront.firstTargetting = Slots.Front;
            doubleFront.secondTargetting = Slots.Front;
            TargetIsHealthColorEffect isRed = ScriptableObject.CreateInstance<TargetIsHealthColorEffect>();
            isRed.mana = Pigments.Red;
            IsTargetIsHealthColorEffect realRed = ScriptableObject.CreateInstance<IsTargetIsHealthColorEffect>();
            realRed.mana = Pigments.Red;
            RandomizeTargetHealthColorNormalEffect random = ScriptableObject.CreateInstance<RandomizeTargetHealthColorNormalEffect>();
            random.mana = [Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Grey];

            Ability meet = new Ability("Meet Me Again", "Skies_Meet_A");
            meet.Description = "I will change the Opposing party member's health color to Red.\nI will then deal a Almost No damage to them twice and generate 2 Pigment of their health color, then I will move them Left or Right.";
            meet.Rarity = Rarity.GetCustomRarity("rarity5");
            meet.Effects = new EffectInfo[4];
            meet.Effects[0] = Effects.GenerateEffect(turnRed, 1, Slots.Front);
            meet.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, doubleFront);
            meet.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 2, Slots.Front);
            meet.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            meet.AddIntentsToTarget(Slots.Front, ["Mana_Modify", "Damage_1_2", "Damage_1_2", "Mana_Generate"]);
            meet.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            meet.Visuals = LoadedAssetsHandler.GetCharacterAbility("Conversion_1_A").visuals;
            meet.AnimationTarget = Slots.Front;

            Ability seek = new Ability("Seeking You Out", "Skies_Seek_A");
            seek.Description = "I will move Left or Right.\nIf the Opposing party member is Red, I will deal a Painful amount of damage to them.\nOtherwise, I will change their health color to Red and inflict 3 Ruptured on them.";
            seek.Rarity = Rarity.GetCustomRarity("rarity5");
            seek.Effects = new EffectInfo[6];
            seek.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            seek.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Gaze", false, Slots.Front));
            seek.Effects[2] = Effects.GenerateEffect(isRed, 1, Slots.Front);
            seek.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front, BasicEffects.DidThat(true));
            seek.Effects[4] = Effects.GenerateEffect(turnRed, 1, Slots.Front, BasicEffects.DidThat(false, 2));
            seek.Effects[5] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, Slots.Front, BasicEffects.DidThat(false, 3));
            seek.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            seek.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_3_6", "Mana_Modify", "Status_Ruptured"]);

            Ability dont = new Ability("Don't Leave Me", "Skies_Dont_A");
            dont.Description = "If the Opposing party member's health color is Red or cannot be changed to Red, I will deal an Agonizing amount of damage to them and randomize their health color.\nOtherwise, I will change their health color to Red.";
            dont.Rarity = Rarity.GetCustomRarity("rarity5");
            dont.Effects = new EffectInfo[3];
            dont.Effects[0] = Effects.GenerateEffect(turnRed, 1, Slots.Front);
            dont.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.Front, BasicEffects.DidThat(false));
            dont.Effects[2] = Effects.GenerateEffect(random, 1, Slots.Front, BasicEffects.DidThat(false, 2));
            dont.AddIntentsToTarget(Slots.Front, ["Mana_Modify", "Misc_Hidden", "Damage_7_10"]);
            dont.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            dont.AnimationTarget = Slots.Front;

            MoveToClosestTargetEffect immediate = ScriptableObject.CreateInstance<MoveToClosestTargetEffect>();
            immediate.Immediate = true;

            Ability please = new Ability("Please.", "Skies_Please_A");
            please.Description = "I will move in front of the closest party member and inflict 1 Constricted and 2 Ruptured on them.";
            please.Rarity = Rarity.CreateAndAddCustomRarityToPool("skies_3", 3);
            please.Effects = new EffectInfo[4];
            please.Effects[0] = Effects.GenerateEffect(immediate, 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false));
            please.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Weep_A", false, Slots.Front));
            please.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.Front);
            please.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.Front);
            please.AddIntentsToTarget(Slots.Self, ["Swap_Mass"]);
            please.AddIntentsToTarget(Slots.Front, ["Field_Constricted", "Status_Ruptured"]);

            Ability line = new Ability("Say My Line", "Skies_Line_A");
            line.Description = "If the Opposing party member's health color is Red, they instantly die.\nOtherwise, gain 2 Power.";
            line.Rarity = Rarity.CreateAndAddCustomRarityToPool("skies_7", 7);
            line.Effects = new EffectInfo[5];
            line.Effects[0] = Effects.GenerateEffect(isRed, 1, Slots.Front);
            line.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/MyLove", false, Slots.Front), 0, Slots.Front, BasicEffects.DidThat(true));
            line.Effects[2] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Lens", false, Slots.Front), 0, Slots.Front, BasicEffects.DidThat(false, 2));
            line.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Front, BasicEffects.DidThat(true, 3));
            line.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Slots.Self, BasicEffects.DidThat(false, 4));
            line.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_Death"]);
            line.AddIntentsToTarget(Slots.Self, [Power.Intent]);
            line.Visuals = null;
            line.AnimationTarget = Slots.Front;


            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                meet.GenerateEnemyAbility(true),
                seek.GenerateEnemyAbility(true),
                dont.GenerateEnemyAbility(true),
                please.GenerateEnemyAbility(true),
                line.GenerateEnemyAbility(true)
            });

            //sub decay
            Enemy second = new Enemy("Red Skies", "RedSky_BOSS")
            {
                Health = 60,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("RedMikuWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("RedMikuWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("RedMikuWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Eyeless_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Eyeless_EN").deathSound,
            };
            second.PrepareEnemyPrefab("Assets/TestSprites/Test_RedSky_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/TestSprites/Test_Gibs.prefab").GetComponent<ParticleSystem>());
            //second.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("WindSong_EN").enemyTemplate;

            second.CombatEnterEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("RedSky"), 1)];

            second.AddPassives(new BasePassiveAbilitySO[] { acting, Passives.MultiAttack4, Passives.EssenceBlue });
            second.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                meet.GenerateEnemyAbility(),
                seek.GenerateEnemyAbility(),
                dont.GenerateEnemyAbility(),
                please.GenerateEnemyAbility(),
                line.GenerateEnemyAbility()
            });
            second.AddEnemy(true);

            //decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.m_PassiveID = PassiveType_GameIDs.Decay.ToString();
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay._enemyDescription = "On death, this enemy gets a second chance.";
            decay._characterDescription = decay._enemyDescription;
            decay.doesPassiveTriggerInformationPanel = true;
            decay.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<RedSkyDecayCondition>() };
            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            decay.effects = new EffectInfo[0];

            template.AddPassive(decay);

            //ADD ENEMY
            template.AddEnemy(true);
        }
    }
}
