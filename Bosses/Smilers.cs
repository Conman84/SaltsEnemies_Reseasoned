using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Smilers
    {
        public static void Add()
        {
            AddCorpse();
            AddEnemy();

        }
        public static void AddCorpse()
        {
            Enemy template = new Enemy("Corpse", "Smiler_Corpse_BOSS")
            {
                Health = 16,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Dying, Passives.Withering });

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
            });
            template.AddEnemy(true);
        }
        public static void AddEnemy()
        {
            Enemy template = new Enemy("Smilers", "Smilers_BOSS")
            {
                Health = 16,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            // template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("BronzoExtra_EN").enemyTemplate;

            BasePassiveAbilitySO decay = Passives.DecayGenerator(LoadedAssetsHandler.GetEnemy("Smiler_Corpse_BOSS"));
            decay._enemyDescription = "On death, the Smiler is mortally wounded and dies.";

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Unstable, Passives.Skittish, decay });

            Ability first = new Ability("Smiler A", "Smiler_Ability1_A");
            first.Description = "Deal a Little damage to the Opposing party member.";
            first.Rarity = Rarity.GetCustomRarity("rarity5");
            first.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front)];
            first.AddIntentsToTarget(Slots.Front, ["Damage_1_2"]);
            first.Visuals = LoadedAssetsHandler.GetCharacterAbility("Shank_1_A").visuals;
            first.AnimationTarget = Slots.Front;

            Ability second = new Ability("Smiler B", "Smiler_Ability2_A");
            second.Description = "Inflict 2 Ruptured on the Left and Right party members.";
            second.Rarity = first.Rarity;
            second.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.LeftRight)];
            second.AddIntentsToTarget(Slots.LeftRight, ["Status_Ruptured"]);
            second.Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;
            second.AnimationTarget = Slots.Front;

            Ability third = new Ability("Smiler C", "Smiler_Ability3_A");
            third.Description = "If the Opposing party member is Ruptured, deal an Agonizing amount of damage to them.";
            third.Rarity = first.Rarity;
            third.Effects = new EffectInfo[2];
            StatusEffectCheckerEffect rupture = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            rupture._status = StatusField.Ruptured;
            third.Effects[0] = Effects.GenerateEffect(rupture, 1, Slots.Front);
            third.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front, BasicEffects.DidThat(true));
            third.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_7_10"]);
            third.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            third.AnimationTarget = Slots.Front;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                first.GenerateEnemyAbility(true),
                second.GenerateEnemyAbility(true),
                third.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true, true);
        }
    }
}
