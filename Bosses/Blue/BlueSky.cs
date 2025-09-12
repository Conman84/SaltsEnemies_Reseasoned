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
                Health = 160,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("MikuWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MikuWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MikuWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("WindSong_EN").enemyTemplate;

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
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1)
                ];

            template.AddPassives(new BasePassiveAbilitySO[] { acting, Passives.MultiAttack2, Passives.EssenceRed });

            ChangeTargetHealthColorEffect turnRed = ScriptableObject.CreateInstance<ChangeTargetHealthColorEffect>();
            turnRed.mana = Pigments.Red;
            DoubleTargetting doubleFront = ScriptableObject.CreateInstance<DoubleTargetting>();
            doubleFront.firstTargetting = Slots.Front;
            doubleFront.secondTargetting = Slots.Front;
            TargetIsHealthColorEffect isRed = ScriptableObject.CreateInstance<TargetIsHealthColorEffect>();
            isRed.mana = Pigments.Red;
            RandomizeTargetHealthColorEffect random = ScriptableObject.CreateInstance<RandomizeTargetHealthColorEffect>();
            random.mana = [Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Grey];

            Ability meet = new Ability("Meet Me Again", "Skies_Meet_A");
            meet.Description = "I will change the Opposing party member's health color to Red.\nI will then deal a Little damage to them twice and generate 2 Pigment of their health color, then I will move them Left or Right.";
            meet.Rarity = Rarity.GetCustomRarity("rarity5");
            meet.Effects = new EffectInfo[4];
            meet.Effects[0] = Effects.GenerateEffect(turnRed, 1, Slots.Front);
            meet.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, doubleFront);
            meet.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 2, Slots.Front);
            meet.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            meet.AddIntentsToTarget(Slots.Front, ["Mana_Modify", "Damage_1_2", "Mana_Generate"]);
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
            seek.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front, BasicEffects.DidThat(true));
            seek.Effects[4] = Effects.GenerateEffect(turnRed, 1, Slots.Front, BasicEffects.DidThat(false, 2));
            seek.Effects[5] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, Slots.Front, BasicEffects.DidThat(false, 3));
            seek.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            seek.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_3_6", "Mana_Modify", "Status_Ruptured"]);

            Ability dont = new Ability("Don't Leave Me", "Skies_Dont_A");
            dont.Description = "If the Opposing party member's health is not Red, I will deal an Agonizing amount of damage to them.\nOtherwise, I will randomize their health color and gain 2 Power.";
            dont.Rarity = Rarity.GetCustomRarity("rarity5");
            dont.Effects = new EffectInfo[4];
            dont.Effects[0] = Effects.GenerateEffect(isRed, 1, Slots.Front);
            dont.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, BasicEffects.DidThat(false));
            dont.Effects[2] = Effects.GenerateEffect(random, 1, Slots.Front, BasicEffects.DidThat(true, 2));
            dont.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Slots.Self, BasicEffects.DidThat(true, 3));
            dont.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_7_10", "Mana_Modify", Power.Intent]);
            dont.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            dont.AnimationTarget = Slots.Front;

            Ability please = new Ability("Please.", "Skies_Please_A");
            please.Description = "I will move in front of the closest Opposing party member and inflict 2 Constricted on them.\nI will gain 2 Power.";
            please.Rarity = Rarity.CreateAndAddCustomRarityToPool("skies_3", 3);
            please.Effects = new EffectInfo[4];
            please.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToClosestTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false));
            please.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Weep_A", false, Slots.Front));
            please.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, Slots.Front);
            please.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Slots.Self);
            please.AddIntentsToTarget(Slots.Self, ["Swap_Mass"]);
            please.AddIntentsToTarget(Slots.Front, ["Field_Constricted", Power.Intent]);

            Ability line = new Ability("Say My Line", "Skies_Line_A");
            line.Description = "If the Opposing party member's health color is Red, they instantly die.";
            line.Rarity = Rarity.CreateAndAddCustomRarityToPool("skies_7", 7);
            line.Effects = new EffectInfo[2];
            line.Effects[0] = Effects.GenerateEffect(isRed, 1, Slots.Front);
            line.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Front, BasicEffects.DidThat(true));
            line.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_Death"]);
            line.Visuals = CustomVisuals.GetVisuals("Salt/Lens");
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
                Health = 40,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("MikuWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MikuWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MikuWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            second.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("WindSong_EN").enemyTemplate;

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

            template.AddPassive(Passives.DecayGenerator(LoadedAssetsHandler.GetEnemy("RedSky_BOSS")));

            //ADD ENEMY
            template.AddEnemy(true);
        }
    }
}
