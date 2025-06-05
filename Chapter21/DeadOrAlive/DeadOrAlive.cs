using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class DeadOrAlive
    {
        public static void Add()
        {
            Enemy clown = new Enemy("Dead or Alive", "Clown_EN")
            {
                Health = 25,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CorpseIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CorpseWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CorpseDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Derogatory_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Derogatory_EN").deathSound,
            };
            clown.PrepareEnemyPrefab("assets/enem4/Corpse_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/enem4/Corpse_Gibs.prefab").GetComponent<ParticleSystem>());

            //production
            ClownPassiveAbility.Setup();
            ClownPassiveAbility produce = ScriptableObject.CreateInstance<ClownPassiveAbility>();
            produce._passiveName = "Production";
            produce.passiveIcon = ResourceLoader.LoadSprite("ProductionPassive.png");
            produce.m_PassiveID = "Production_PA";
            produce._enemyDescription = "On any infantile enemy being damaged, spawn a Waltz.";
            produce._characterDescription = "idk";
            produce.doesPassiveTriggerInformationPanel = true;
            SpawnEnemyByStringNameEffect spawnWaltz = ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>();
            spawnWaltz.enemyName = "Waltz_EN";
            produce.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>(), 1, Slots.Self).SelfArray();
            produce._triggerOn = [ClownPassiveAbility.Trigger];

            clown.AddPassives(new BasePassiveAbilitySO[] { produce, Passives.Dying });

            AbilitySelector_Clown selector = ScriptableObject.CreateInstance<AbilitySelector_Clown>();
            selector.Ability = "MySpecialAttack_A";
            selector.CheckPassive = PassiveType_GameIDs.Infantile.ToString();
            clown.AbilitySelector = selector;

            

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            clown.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            clown.AddEnemy(true, true);
        }
    }
}
