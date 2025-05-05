using BrutalAPI;
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
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
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
}

/*-------------------EXTRA STUFF: GROUP 19 PATHS (all in meowy)-----------------*/

//Assets/enem3/Phone_Enemy.prefab
//Assets/gib3/Phone_Gibs.prefab

//Assets/enem3/Starless_Enemy.prefab
//Assets/gib3/Starless_Gibs.prefab

//Assets/enem3/Eyeless_Enemy.prefab
//Assets/gib3/EyelessGibs.prefab

//Assets/enem3/Pawn_Enemy.prefab
//Assets/gib3/Pawn_Gibs.prefab

//event:/Hawthorne/PawnSong

//Assets/enem3/Yang_Enemy.prefab
//Assets/gib3/Yang_Gibs.prefab

//Assets/enem3/Yin_Enemy.prefab
//Assets/gib3/Yin_Gibs.prefab

//event:/Hawthorne/BishopSong

//Assets/enem3/2009_Enemy.prefab
//m_Locator.Find("Sprite").Find("Face").GetComponent
//Assets/gib3/2009_Gibs.prefab

//Assets/enem3/Chiito_Enemy.prefab
//Assets/gib3/Chiito_Gibs.prefab