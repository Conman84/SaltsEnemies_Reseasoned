using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Celebration
    {
        public static void Add()
        {
            Enemy pumpkin = new Enemy("Celebration", "Celebration_EN")
            {
                Health = 33,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CelebrationIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CelebrationWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CelebrationDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            pumpkin.PrepareEnemyPrefab("Assets/ch_26/Celebration_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/ch_26/Celebration_Gibs.prefab").GetComponent<ParticleSystem>());

            ChangeCasterHealthColorBetweenColorsEffect redpurple = ScriptableObject.CreateInstance<ChangeCasterHealthColorBetweenColorsEffect>();
            redpurple._color1 = Pigments.Red;
            redpurple._color2 = Pigments.Purple;
            //JITERRY
            PerformEffectPassiveAbility pawsome = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            pawsome._passiveName = "Pawsome";
            pawsome.name = "Pawsome_RedPurple_PA";
            pawsome.m_PassiveID = "Pawsome_PA";
            pawsome.passiveIcon = ResourceLoader.LoadSprite("PawsomePassive.png");
            pawsome._enemyDescription = "On any party member manually moving, this enemy will change its health color from Red to Purple or vice versa.";
            pawsome._characterDescription = "On any party member manually moving, this party member will change its health color from Red to Purple or vice versa.";
            pawsome.doesPassiveTriggerInformationPanel = true;
            pawsome.effects = Effects.GenerateEffect(redpurple, 1, Slots.Self).SelfArray();
            pawsome._triggerOn = new TriggerCalls[] { JitteryHandler.Call };
            pawsome.conditions = new EffectorConditionSO[0];
            pawsome.AddToPassiveDatabase();

            pumpkin.AddPassives(new BasePassiveAbilitySO[] { pawsome, Passives.SlipperyGenerator(3), Violent.Generate(3), Passives.OverexertGenerator(3) });

            Ability eidolon = new Ability("Pawsome_Eidolon_A");
            eidolon.Name = "Eidolon";
            eidolon.Description = "Deals a Barely Painful amount of damage to this enemy.";
            eidolon.Rarity = Rarity.CreateAndAddCustomRarityToPool("pawesome20", 20);
            eidolon.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Self)];
            eidolon.AddIntentsToTarget(Slots.Self, ["Damage_3_6"]);
            eidolon.Visuals = Visuals.Slap;
            eidolon.AnimationTarget = Slots.Self;

            //ADD ENEMY
            pumpkin.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                eidolon.GenerateEnemyAbility(true),
            });
            pumpkin.AddEnemy(true, true);
            pumpkin.enemy.AddToSynodPool();
            pumpkin.enemy.AddToToysPool();
            pumpkin.enemy.AddToEcstasyPool();
        }
    }
}
