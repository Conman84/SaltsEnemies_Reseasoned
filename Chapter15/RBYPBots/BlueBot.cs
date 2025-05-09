using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BlueBot
    {
        public static void Add()
        {
            BotGeneral.Add();

            Enemy blue = new Enemy("Mirrored Apparatus", "BlueBot_EN")
            {
                Health = 21,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("BlueBotIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("BlueBotWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("BlueBotDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noise/ApparatusHit",
                DeathSound = "event:/Hawthorne/Noise/ApparatusDie",
                AbilitySelector = BotGeneral.Selector
            };
            blue.PrepareEnemyPrefab("assets/bot/BlueBot_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/bot/BlueBot_Gibs.prefab").GetComponent<ParticleSystem>());

            blue.AddPassives(new BasePassiveAbilitySO[] { BotGeneral.Pillar, Passives.MultiAttack2 });

            Ability test = new Ability("Please the Portrait", "PleaseThePortrait_A");
            test.Description = "If the Opposing party member used Pigment of this enemy's health color last turn, deal a Painful amount of damage to them and lower their maximum health to their current health.";
            test.Rarity = Rarity.GetCustomRarity("bot3");
            test.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<BlueBotSpecialEffect>(), 5, Slots.Front).SelfArray();
            test.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Misc.ToString()]);
            test.Visuals = CustomVisuals.GetVisuals("Salt/Door");
            test.AnimationTarget = Slots.Front;


            //ADD ENEMY
            blue.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                BotGeneral.Left,
                BotGeneral.Right,
                BotGeneral.Middle,
                test.GenerateEnemyAbility(true),
            });
            blue.AddEnemy(true, true);
        }
    }
}
