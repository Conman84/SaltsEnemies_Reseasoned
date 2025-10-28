using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Untitled
    {
        public static void Add()
        {
            Enemy template = new Enemy("Untitled_EN", "Untitled_EN")
            {
                Health = 5,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("UntitledIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("UntitledWarning.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("UntitledDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sosn2/MercedHit",
                DeathSound = "event:/Hawthorne/Sosn2/MercedDie",
            };
            template.PrepareEnemyPrefab("Assets/Item/Untitled_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Item/Untitled_Gibs.prefab").GetComponent<ParticleSystem>());

            PerformEffectPassiveAbility untitled = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            untitled._passiveName = "Untitled";
            untitled.m_PassiveID = "Aprils_Untitled";
            untitled.passiveIcon = ResourceLoader.LoadSprite("UntitledPassive.png");
            untitled._enemyDescription = "On dying excluding from Withering, restart combat.";
            untitled._characterDescription = "On dying excluding from Withering, restart combat.";
            untitled.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<UntitledEffect>())];
            untitled._triggerOn = [TriggerCalls.OnDeath];
            untitled.conditions = [ScriptableObject.CreateInstance<IsntWitheringDeathCondition>()];

            template.AddPassives(new BasePassiveAbilitySO[] { untitled, Passives.Withering });

            template.CombatEnterEffects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<UntitledSongEffect>())];

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
            });
            template.AddEnemy();
        }
    }
}
