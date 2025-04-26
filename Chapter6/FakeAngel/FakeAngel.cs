using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using BrutalAPI;
using SaltEnemies_Reseasoned;
using System.Text.RegularExpressions;

namespace SaltsEnemies_Reseasoned
{
    public static class FakeAngel
    {
        public static void Add()
        {
            Debug.LogError("Make sure to load the group4 assetbundle!");

            Enemy angel = new Enemy("Fake Angel", "FakeAngel_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("AngelIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("AngelWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("AngelDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            angel.PrepareEnemyPrefab("assets/group4/Angel/Angel_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Angel/Angel_Gibs.prefab").GetComponent<ParticleSystem>());

            angel.AddPassives(new BasePassiveAbilitySO[] { Passives.Leaky1, Passives.Withering });

            //Pray

            Ability pray = new Ability("Pray", "FakeAngel_Pray_A")
            {
                Description = "Apply Favor on the Opposing Party Member and generate 3 pigment of their health color.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFavorEffect>() , 1, Targeting.Slot_Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 3, Targeting.Slot_Front)
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Malpractice_1_A").visuals,
                AnimationTarget = Targeting.Slot_Front
            };
            pray.AddIntentsToTarget(Targeting.Slot_Front, new string[] { Favor.Intent, IntentType_GameIDs.Mana_Generate.ToString() });

            //Add
            angel.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                new EnemyAbilityInfo()
                {
                    rarity = Rarity.GetCustomRarity("rarity5"),
                    ability = LoadedAssetsHandler.GetEnemyAbility("Weep_A")
                },
                pray.GenerateEnemyAbility(true),
            });
            angel.AddEnemy(true, true);
        }
    }
}
