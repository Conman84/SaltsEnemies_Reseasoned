using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static SaltsEnemies_Reseasoned.Garden.H;

namespace SaltsEnemies_Reseasoned
{
    public static class Papereater
    {
        public static void Add()
        {
            Enemy eater = new Enemy("Papereater", "Papereater_EN")
            {
                Health = 10,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("PapereaterIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PapereaterWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PapereaterDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sound2/EaterHurt",
                DeathSound = "event:/Hawthorne/Sound2/EaterDie",
            };
            eater.PrepareEnemyPrefab("Assets/wip5/Papereater_Wip_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Papereater_Wip_Gibs.prefab").GetComponent<ParticleSystem>());

            //escapist
            PerformEffectPassiveAbility escape = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            escape.name = "Escapist_PA";
            escape._passiveName = "Escapist";
            escape.passiveIcon = ResourceLoader.LoadSprite("EscapistPassive.png");
            escape.m_PassiveID = "Escapist_PA";
            escape._enemyDescription = "On using an ability, move to a random unoccupied position.";
            escape._characterDescription = escape._enemyDescription;
            escape._triggerOn = [TriggerCalls.OnAbilityUsed];
            escape.conditions = [];
            escape.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToRandomEmptyTileEffect>(), 1, Slots.Self)];


            eater.AddPassives(new BasePassiveAbilitySO[] { escape });


            Ability eat = new Ability("Eats Paper", "EatsPaper_A");
            eat.Description = "Apply 2 Slip to the Opposing party member position.";
            eat.Rarity = Rarity.Common;
            eat.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.Front)];
            eat.AddIntentsToTarget(Slots.Front, [Slip.Intent]);
            eat.AnimationTarget = Slots.Front;
            eat.Visuals = CustomVisuals.GetVisuals("Salt/Ribbon");

            Ability hurter = new Ability("Hurter", "Hurter_A");
            hurter.Description = "Deal a Little damage to the Opposing party member and apply 1 Slip to their position.";
            hurter.Rarity = Rarity.Common;
            hurter.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Front)];
            hurter.AddIntentsToTarget(Slots.Front, ["Damage_1_2", Slip.Intent]);
            hurter.AnimationTarget = Slots.Front;
            hurter.Visuals = Visuals.Nibble;

            //ADD ENEMY
            eater.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                eat.GenerateEnemyAbility(true),
                hurter.GenerateEnemyAbility(true)
            });
            eater.SilentAddEnemy(true, true);
            eater.enemy.AddToSynodPool();
            eater.enemy.AddToToysPool();
            eater.enemy.AddToEcstasyPool();
        }
    }
}
