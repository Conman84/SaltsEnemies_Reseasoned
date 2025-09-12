using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class CrowChild
    {
        public static void Add()
        {
            Enemy template = new Enemy("Crow Child", "CrowChild_BOSS")
            {
                Health = 55,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CrowChildWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CrowChildWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CrowChildWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("LittleBeak_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.SlipperyGenerator(3), Violent.Generate(5) });

            Ability first = new Ability("Ability A", "CrowChild1_A");
            first.Description = "Inflict 1 Constricted and 1 Frail to the Left and Right party members.";
            first.Rarity = Rarity.GetCustomRarity("rarity5");
            first.Effects = new EffectInfo[2];
            first.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.LeftRight);
            first.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, Slots.LeftRight);
            first.AddIntentsToTarget(Slots.LeftRight, ["Field_Constricted", "Status_Frail"]);
            first.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            first.AnimationTarget = Slots.LeftRight;

            Ability second = new Ability("Ability B", "CrowChild2_A");
            second.Description = "Deal a Little damage to this enemy.";
            second.Rarity = Rarity.GetCustomRarity("rarity5");
            second.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self)];
            second.AddIntentsToTarget(Slots.Self, ["Damage_1_2"]);
            second.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            second.AnimationTarget = Slots.Self;

            Ability third = new Ability("Ability C", "CrowChild3_A");
            third.Description = "Consume 3 random pigment.";
            third.Rarity = Rarity.GetCustomRarity("rarity5");
            third.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 3, Slots.Self)];
            third.AddIntentsToTarget(Slots.Self, ["Mana_Consume"]);
            third.Visuals = LoadedAssetsHandler.GetEnemyAbility("Gulp_A").visuals;
            third.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                first.GenerateEnemyAbility(true),
                second.GenerateEnemyAbility(true),
                third.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true);
        }
    }
}
