using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Author
    {
        public static void Add()
        {
            Enemy author = new Enemy("Author", "Author_EN")
            {
                Health = 10,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("AuthorIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("AuthorDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("AuthorWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Freud_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Freud_EN").deathSound,
            };
            author.PrepareMultiEnemyPrefab("Assets/enem3/Author_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Author_Gibs.prefab").GetComponent<ParticleSystem>());
            (author.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                author.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Book").Find("Outline").GetComponent<SpriteRenderer>(),
                author.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Nail").Find("Outline").GetComponent<SpriteRenderer>(),
                author.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Arm").Find("Outline").GetComponent<SpriteRenderer>(),
            };

            //prophecy
            PerformEffectPassiveAbility prophet = ScriptableObject.CreateInstance<AuthorPassive>();
            prophet._passiveName = "Prophecy";
            prophet.passiveIcon = ResourceLoader.LoadSprite("ProphecyPassive.png");
            prophet.m_PassiveID = "Prophecy_PA";
            prophet._characterDescription = "On death, spawn the Monster.\nIncrease the Monster's health proportional to the amount of turns this enemy has been in combat.\nTransfer all status effects from this enemy to the Monster.";
            prophet._enemyDescription = prophet._characterDescription;
            prophet.doesPassiveTriggerInformationPanel = false;
            prophet._triggerOn = [TriggerCalls.OnDeath, TriggerCalls.TimelineEndReached];
            prophet.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ProphecyEffect>(), 0, null, ScriptableObject.CreateInstance<InsideOutCondition>()),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Monster", false, Slots.Self), 0, null, ScriptableObject.CreateInstance<InsideOutCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnMonsterEffect>())
            };

            author.AddPassives(new BasePassiveAbilitySO[] { prophet, Passives.Forgetful });
            author.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Author>();
            author.AddUnitType("Female_ID");

            //news reel
            Ability news = new Ability("News Reel", AuthorHandler.Spotlight);
            news.Description = "Gain Spotlight.";
            news.Rarity = Rarity.GetCustomRarity("rarity5");
            news.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, Slots.Self).SelfArray();
            news.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Status_Spotlight.ToString()]);
            news.Visuals = CustomVisuals.GetVisuals("Salt/Spotlight");
            news.AnimationTarget = Slots.Self;

            //blood crawl
            Ability blood = new Ability("Blood Crawl", "BloodCrawl_A");
            blood.Description = "Inflict 1 Scar and deal a Little damage to this enemy.\nProduce 2 Red Pigment.";
            blood.Rarity = Rarity.GetCustomRarity("rarity5");
            blood.Effects = new EffectInfo[3];
            blood.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Self);
            blood.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self);
            blood.Effects[2] = Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 2, Slots.Self);
            blood.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Status_Scars.ToString(), IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Mana_Generate.ToString()]);
            blood.Visuals = CustomVisuals.GetVisuals("Salt/Claws");
            blood.AnimationTarget = Slots.Self;

            //cataclysm
            Ability cat = new Ability("Mini-Cataclysm", AuthorHandler.Cataclysm);
            cat.Description = "Deal a Painful amount of damage to all enemies and party members.";
            cat.Rarity = Rarity.GetCustomRarity("rarity5");
            cat.Effects = new EffectInfo[2];
            cat.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targetting.AllAlly);
            cat.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targetting.AllEnemy);
            cat.AddIntentsToTarget(Targetting.AllAlly, [IntentType_GameIDs.Damage_3_6.ToString()]);
            cat.AddIntentsToTarget(Targetting.AllEnemy, [IntentType_GameIDs.Damage_3_6.ToString()]);
            cat.Visuals = CustomVisuals.GetVisuals("Salt/StarBomb");
            cat.AnimationTarget = Slots.Self;

            //suicide
            Ability suicide = new Ability("Inside Out", AuthorHandler.Suicide);
            suicide.Description = "Apply 5 Power to this enemy.\nInstantly kill this enemy.";
            suicide.Rarity = Rarity.GetCustomRarity("rarity5");
            suicide.Effects = new EffectInfo[3];
            suicide.Effects[0] = Effects.GenerateEffect(BasicEffects.SetStoreValue(AuthorHandler.Suicide), 1, Slots.Self);
            suicide.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 5, Slots.Self);
            suicide.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self);
            suicide.AddIntentsToTarget(Slots.Self, [Power.Intent, IntentType_GameIDs.Damage_Death.ToString()]);
            suicide.Visuals = CustomVisuals.GetVisuals("Salt/Monster");
            suicide.AnimationTarget = Slots.Self;


            //ADD ENEMY
            author.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                news.GenerateEnemyAbility(true),
                blood.GenerateEnemyAbility(true),
                cat.GenerateEnemyAbility(true),
                suicide.GenerateEnemyAbility(true)
            });
            author.AddEnemy(true);
        }
    }
}
