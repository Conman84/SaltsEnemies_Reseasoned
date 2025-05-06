using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class YellowBot
    {
        public static void Add()
        {
            BotGeneral.Add();

            Enemy yellow = new Enemy("Projecting Apparatus", "YellowBot_EN")
            {
                Health = 21,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("YellowBotIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("YellowBotWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("YellowBotDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noise/ApparatusHit",
                DeathSound = "event:/Hawthorne/Noise/ApparatusDie",
                AbilitySelector = BotGeneral.Selector
            };
            yellow.PrepareMultiEnemyPrefab("assets/bot/YellowBot_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/bot/YellowBot_Gibs.prefab").GetComponent<ParticleSystem>());
            (yellow.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                yellow.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("WALL_L").GetComponent<SpriteRenderer>(),
                yellow.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("WALL_R").GetComponent<SpriteRenderer>(),
                yellow.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("WALL_T").GetComponent<SpriteRenderer>(),
            };
            yellow.AddPassives(new BasePassiveAbilitySO[] { BotGeneral.Pillar, Passives.MultiAttack2 });

            Ability test = new Ability("Please the Point", "PleaseThePoint_A");
            test.Description = "If the Opposing party member used Pigment of this enemy's health color last turn, deal an Agonizing amount of damage to them.";
            test.Rarity = Rarity.GetCustomRarity("bot3");
            test.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<YellowBotSpecialEffect>(), 10, Slots.Front).SelfArray();
            test.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Misc.ToString()]);
            test.Visuals = CustomVisuals.GetVisuals("Salt/Keyhole");
            test.AnimationTarget = Slots.Front;


            //ADD ENEMY
            yellow.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                BotGeneral.Left,
                BotGeneral.Right,
                BotGeneral.Middle,
                test.GenerateEnemyAbility(true),
            });
            yellow.AddEnemy(true, true);
        }
    }
}
