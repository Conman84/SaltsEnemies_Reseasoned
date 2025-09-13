using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BlackAndBlue
    {
        public static void Add()
        {
            Enemy template = new Enemy("Black And Blue", "BlackAndBlue_BOSS")
            {
                Health = 80,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("WarCriminalWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WarCriminalWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WarCriminalWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());

            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").enemyTemplate;

            Connection_PerformEffectPassiveAbility sunk = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            sunk.name = "Sunk_PA";
            sunk._passiveName = "Sunk";
            sunk._enemyDescription = "All positions are in permenant Deep Water.";
            sunk.m_PassiveID = "Sunk_PA";
            sunk.connectionEffects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<PermenantApplyWaterEffect>(), 1, MultiTargetting.Create(Targetting.Everything(true), Targetting.Everything(false)))];
            sunk.disconnectionEffects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveRestrictorWaterEffect>(), 1, MultiTargetting.Create(Targetting.Everything(true), Targetting.Everything(false)))];
            
            template.AddPassives(new BasePassiveAbilitySO[] { sunk, Passives.Skittish, Passives.Constricting });

            Ability bb = new Ability("Hoist", "BlackAndBlue_A");
            bb.Description = "Deal a Painful amount of damage to the Opposing party member.\nRemove all Status Effects from them.";
            bb.Rarity = Rarity.Common;
            bb.Effects = new EffectInfo[2];
            bb.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);
            bb.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, Slots.Front);
            bb.AddIntentsToTarget(Slots.Front, ["Damage_3_6", "Misc"]);
            bb.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            bb.AnimationTarget = Slots.Front;

            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            RemoveStatusEffectEffect remDrown = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remDrown._status = Drowning.Object;

            Ability cc = new Ability("Submerge", "BlueAndBlack_A");
            cc.Description = "Remove all Drowning from this enemy.\nMove all party members towards this enemy.";
            cc.Rarity = Rarity.CreateAndAddCustomRarityToPool("bb30", 30);
            cc.Effects = [
                Effects.GenerateEffect(remDrown, 1, Slots.Self),
                Effects.GenerateEffect(goRight, 1, Targeting.GenerateSlotTarget(new int[1] { -1 })),
                Effects.GenerateEffect(goRight, 1, Targeting.GenerateSlotTarget(new int[1] { -2 })),
                Effects.GenerateEffect(goRight, 1, Targeting.GenerateSlotTarget(new int[1] { -3 })),
                Effects.GenerateEffect(goRight, 1, Targeting.GenerateSlotTarget(new int[1] { -4 })),
                Effects.GenerateEffect(goLeft, 1, Targeting.GenerateSlotTarget(new int[1] { 1 })),
                Effects.GenerateEffect(goLeft, 1, Targeting.GenerateSlotTarget(new int[1] { 2 })),
                Effects.GenerateEffect(goLeft, 1, Targeting.GenerateSlotTarget(new int[1] { 3 })),
                Effects.GenerateEffect(goLeft, 1, Targeting.GenerateSlotTarget(new int[1] { 4 })),
                ];

            Intents.CreateAndAddCustom_Basic_IntentToPool("Rem_Status_Drowning", ResourceLoader.LoadSprite("Drowning.png"), Intents.GetInGame_IntentInfo(IntentType_GameIDs.Rem_Status_Frail)._color);

            cc.AddIntentsToTarget(Slots.Self, ["Rem_Status_Drowning"]);
            cc.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[4] { -1, -2, -3, -4 }, false), new string[]
            {
                "Swap_Right",
            });
            cc.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[4] { 1, 2, 3, 4 }, false), new string[]
            {
                "Swap_Left",
            });
            cc.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            cc.AnimationTarget = Slots.Self;

            template.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_BlackAndBlue>();

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                bb.GenerateEnemyAbility(true),
                cc.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true);
        }
    }
}
