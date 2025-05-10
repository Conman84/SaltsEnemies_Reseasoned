using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class PurpleBot
    {
        public static void Add()
        {
            BotGeneral.Add();

            Enemy purple = new Enemy("Projecting Apparatus", "PurpleBot_EN")
            {
                Health = 26,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("PurpleBotIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PurpleBotWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PurpleBotDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noise/ApparatusHit",
                DeathSound = "event:/Hawthorne/Noise/ApparatusDie",
            };
            purple.PrepareEnemyPrefab("assets/bot/PurpleBot_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/bot/PurpleBot_Gibs.prefab").GetComponent<ParticleSystem>());

            purple.AddPassives(new BasePassiveAbilitySO[] { BotGeneral.Pillar, Passives.MultiAttack2 });

            //selector
            AbilitySelector_Bots newbots = ScriptableObject.CreateInstance<AbilitySelector_Bots>();
            newbots.Isolate = new string[] { "PleaseThePlight_A" };
            newbots.NoAlone = "Bot_Postular_A";
            purple.AbilitySelector = newbots;

            Ability test = new Ability("Please the Plight", "PleaseThePlight_A");
            test.Description = "Randomize all Pigment not of this enemy's health color into this enemy's health color.\nRandomize all Pigment of this enemy's health color into Pigments not of this enemy's health color.";
            test.Rarity = Rarity.GetCustomRarity("bot3");
            test.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeHealthColorAndNonHealthColorEffect>(), 1, Slots.Self).SelfArray();
            test.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Randomize.ToString()]);
            test.Visuals = CustomVisuals.GetVisuals("Salt/Shatter");
            test.AnimationTarget = Slots.Self;


            //ADD ENEMY
            purple.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                BotGeneral.Left,
                BotGeneral.Right,
                BotGeneral.Middle,
                test.GenerateEnemyAbility(true),
            });
            purple.AddEnemy(true, true);
        }
    }
}
