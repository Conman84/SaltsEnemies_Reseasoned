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
            test.Description = "Inflict 2 Frail on all party members who used Yellow pigment last turn.";
            test.Rarity = Rarity.GetCustomRarity("bot3");
            test.Priority = Priority.Fast;
            test.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, TargettingByUsedYellow.Create(false)).SelfArray();
            test.AddIntentsToTarget(TargettingByUsedYellow.Create(false), IntentType_GameIDs.Status_Frail.ToString().SelfArray());
            test.AddIntentsToTarget(Targeting.Slot_OpponentAllSlots, IntentType_GameIDs.Misc.ToString().SelfArray());
            test.Visuals = CustomVisuals.GetVisuals("Salt/Keyhole");
            test.AnimationTarget = Slots.Self;


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
