using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Template
    {
        public static void Add()
        {
            Enemy template = new Enemy("Template", "Template_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Leaky1, Passives.Withering });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true, true);
        }
    }

    public static class TemplateEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_TemplateEncounter_Sign", ResourceLoader.LoadSprite("TemplateWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, "H_Zone03_Template_Med_EnemyBundle", "Salt_TemplateEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewCoffinTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Grandfather.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}

/*-------------------EXTRA STUFF: GROUP 19 PATHS (all in meowy)-----------------*/

//Assets/enem3/Foxtrot_Enemy.prefab
//Sprite => Handle => Outline
//Assets/gib3/Foxtrot_Gibs.prefab
//event:/Hawthorne/Sund/FoxtrotHit
//event:/Hawthorne/Sund/FoxtrotDie