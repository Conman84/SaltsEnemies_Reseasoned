using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public static class Windle
    {
        public static void Add()
        {
            Enemy windle = new Enemy("Windle", "Windle_EN")
            {
                Health = 12,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("WindleIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WindleWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WindleDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Doll_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Doll_CH").deathSound,
            };
            windle.PrepareMultiEnemyPrefab("assets/group4/Windle/Windle_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Windle/Windle_Gibs.prefab").GetComponent<ParticleSystem>());
            (windle.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                windle.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
            };


            windle.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery });
            windle.AddUnitType("Fish");

            CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect win = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect>();
            win._characterCopy = "Windle_CH";
            win._rank = 0;
            win._permanentSpawn = true;
            win._extraModifiers = new WearableStaticModifierSetterSO[0];
            win._usePreviousAsHealth = true;
            Ability _windle1 = new Ability("Whime_A")
            {
                Name = "Whime",
                Description = "If there is space, this enemy joins the party. Otherwise, this enemy takes a Little damage. \n(This enemy does not intend to help.)",
                Rarity = Rarity.Common,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(win, 1, Slots.Self, ScriptableObject.CreateInstance<HasSpaceCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self, BasicEffects.DidThat(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self, BasicEffects.DidThat(false, 2)),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Keyhole"),
                AnimationTarget = Slots.Self,
            };
            _windle1.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_Spawn.ToString(), IntentType_GameIDs.PA_Fleeting.ToString(), IntentType_GameIDs.Damage_1_2.ToString()]);

            //ADD ENEMY
            windle.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                _windle1.GenerateEnemyAbility(true)
            });
            windle.AddEnemy(true, true);

            WindleCharacter.Add();
        }
    }
}
