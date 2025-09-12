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
                Health = 60,
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

            Ability bb = new Ability("Idk!", "BlackAndBlue_A");
            bb.Description = "Deal a Painful amount of damage to the Opposing party member.\nRemove all Status Effects from them and from this enemy.";
            bb.Rarity = Rarity.Common;
            bb.Effects = new EffectInfo[2];
            bb.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);
            bb.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, MultiTargetting.Create(Slots.Front, Slots.Self));
            bb.AddIntentsToTarget(Slots.Front, ["Damage_3_6", "Misc"]);
            bb.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            bb.AnimationTarget = Slots.Front;


            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                bb.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true);
        }
    }
}
