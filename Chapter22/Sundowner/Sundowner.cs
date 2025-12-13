using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Sundowner
    {
        public static void Add()
        {
            Enemy sundowner = new Enemy("Sundowner", "Sundowner_EN")
            {
                Health = 33,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("SundownerIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SundownerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SundownerDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sound2/SunsetHurt",
                DeathSound = "event:/Hawthorne/Sound2/SunsetDie",
            };
            sundowner.PrepareEnemyPrefab("Assets/Item/Sundowner_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Item/Sundowner_Gibs.prefab").GetComponent<ParticleSystem>());
            sundowner.enemy.enemyTemplate.m_Data.m_Renderer = sundowner.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>();

            sundowner.AddPassives(new BasePassiveAbilitySO[] { Violent.Generate(5) });

            Ability sunrise = new Ability("Sunrise", "Sundowner_Sunrise_A");
            sunrise.Description = "Heal the Opposing party member and inflict 3 Inverted on them.\nMove Left or Right.";
            sunrise.Rarity = Rarity.Common;
            sunrise.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 10, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyInvertedEffect>(), 3, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)
                ];
            sunrise.AddIntentsToTarget(Slots.Front, ["Heal_5_10", Inverted.Intent]);
            sunrise.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            sunrise.AnimationTarget = Slots.Front;
            sunrise.Visuals = CustomVisuals.GetVisuals("Salt/Alarm");

            Intents.CreateAndAddCustom_Basic_IntentToPool("Rem_Status_Inverted", Inverted.Object.EffectInfo.icon, Intents.GetInGame_IntentInfo(IntentType_GameIDs.Rem_Status_Frail)._color);

            RemoveStatusEffectEffect remInvert = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remInvert._status = Inverted.Object;

            Ability sunset = new Ability("Sunset", "Sundowner_Sunset_A");
            sunset.Description = "Remove all Inverted from the Opposing party member, then invert their health.\nIf there is available space, split in two.";
            sunset.Rarity = Rarity.Common;
            sunset.Effects = [
                Effects.GenerateEffect(remInvert, 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<InvertTargetHealthEffect>(), 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SplitInTwoEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<HasEnemySpaceEffectCondition>())
                ];
            sunset.AddIntentsToTarget(Slots.Front, ["Rem_Status_Inverted", IntentType_GameIDs.Other_MaxHealth_Alt.ToString()]);
            sunset.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_Spawn.ToString()]);
            sunset.AnimationTarget = Slots.Front;
            sunset.Visuals = CustomVisuals.GetVisuals("Salt/StageLights");
            sunset.Priority = Priority.Slow;

            //ADD ENEMY
            sundowner.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                sunrise.GenerateEnemyAbility(true),
                sunset.GenerateEnemyAbility(true)
            });
            sundowner.SilentAddEnemy(true, true);
        }
    }
}
