using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class RedBot
    {
        public static void Add()
        {
            BotGeneral.Add();

            Enemy red = new Enemy("Virile Apparatus", "RedBot_EN")
            {
                Health = 17,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("RedBotIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("RedBotWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("RedBotDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noise/ApparatusHit",
                DeathSound = "event:/Hawthorne/Noise/ApparatusDie",
                AbilitySelector = BotGeneral.Selector
            };
            red.PrepareEnemyPrefab("assets/bot/RedBot_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/bot/RedBot_Gibs.prefab").GetComponent<ParticleSystem>());

            red.AddPassives(new BasePassiveAbilitySO[] { BotGeneral.Pillar, Passives.MultiAttack2 });

            Targetting_ByUnit_SideCasterColor targettingCasterColor = ScriptableObject.CreateInstance<Targetting_ByUnit_SideCasterColor>();
            targettingCasterColor.getAllies = true;
            targettingCasterColor.getAllUnitSlots = true;
            Ability test = new Ability("Please the Politics", "PleaseThePolitics_A");
            test.Description = "Deal a Painful amount of damage to all party members Opposing enemies sharing this enemy's health color.";
            test.Rarity = Rarity.GetCustomRarity("bot3");
            test.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Targetting.Reverse(targettingCasterColor)).SelfArray();
            test.AddIntentsToTarget(Targeting.Unit_AllAllySlots, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            test.AddIntentsToTarget(Targetting.Reverse(targettingCasterColor), IntentType_GameIDs.Damage_3_6.ToString().SelfArray());
            test.Visuals = CustomVisuals.GetVisuals("Salt/Gears");
            test.AnimationTarget = Targetting.Reverse(targettingCasterColor);


            //ADD ENEMY
            red.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                BotGeneral.Left,
                BotGeneral.Right,
                BotGeneral.Middle,
                test.GenerateEnemyAbility(true),
            });
            red.AddEnemy(true, true);
        }
    }
}
