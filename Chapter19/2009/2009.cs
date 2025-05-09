using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class TwoThousandNine
    {
        public static void Add()
        {
            Enemy spinner = new Enemy("2009", "2009_EN")
            {
                Health = 13,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("2009Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("2009World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("2009Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("DeadPixel_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("DeadPixel_EN").deathSound,
            };
            spinner.PrepareEnemyPrefab("assets/enem3/2009_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/gib3/2009_Gibs.prefab").GetComponent<ParticleSystem>());

            spinner.enemy.enemyTemplate.m_Data.m_Renderer = spinner.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Face").Find("Outline").GetComponent<SpriteRenderer>();

            //ROTARY
            PerformEffectPassiveAbility rotary = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            rotary._passiveName = "Rotary";
            rotary.m_PassiveID = "Rotary_PA";
            rotary.passiveIcon = ResourceLoader.LoadSprite("RotaryPassive.png");
            rotary._enemyDescription = "On being damaged, move all the way to the Left or Right.";
            rotary._characterDescription = rotary._enemyDescription;
            rotary.doesPassiveTriggerInformationPanel = true;
            rotary.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveAllTheWayOneSideEffect>(), 1, Slots.Self).SelfArray();
            rotary._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            rotary.conditions = Passives.Slippery.conditions;

            spinner.AddPassives(new BasePassiveAbilitySO[] { rotary });

            Ability breaker = new Ability("Breakdown", "Breakdown_A");
            breaker.Description = "Inflict 2 Frail on the Opposing party member then give this enemy another action.\nDeal a Little damage to this enemy.";
            breaker.Rarity = Rarity.GetCustomRarity("rarity5");
            breaker.Effects = new EffectInfo[3];
            breaker.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Slots.Front);
            breaker.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self);
            breaker.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self);
            breaker.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Status_Frail.ToString()]);
            breaker.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc_Additional.ToString(), IntentType_GameIDs.Damage_1_2.ToString()]);
            breaker.Visuals = CustomVisuals.GetVisuals("Salt/Gears");
            breaker.AnimationTarget = Slots.Self;

            Ability classic = new Ability("The Classic", "TheClassic_A");
            classic.Description = "Deal 6 damage to the Opposing party member. This ability has random critical hits.\nMove to the Left or Right 3 times.";
            classic.Rarity = Rarity.GetCustomRarity("rarity5");
            classic.Effects = new EffectInfo[4];
            classic.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<CritDamageEffect>(), 6, Slots.Front);
            classic.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            classic.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            classic.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            classic.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            classic.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString()]);
            classic.Visuals = CustomVisuals.GetVisuals("Salt/Gunshot");
            classic.AnimationTarget = Slots.Front;

            Ability bart = new Ability("Bartimaeus", "Bartimaeus_A");
            bart.Description = "Inflict 2 Fire on the Opposing position and 1 Scar on this enemy.\n50% probability to give this enemy another action on the timeline.";
            bart.Rarity = Rarity.GetCustomRarity("rarity5");
            bart.Effects = new EffectInfo[3];
            bart.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 2, Slots.Front);
            bart.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Self);
            bart.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self, Effects.ChanceCondition(50));
            bart.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Field_Fire.ToString()]);
            bart.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Status_Scars.ToString(), IntentType_GameIDs.Misc_Additional.ToString()]);
            bart.Visuals = LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals;
            bart.AnimationTarget = Slots.Front;


            //ADD ENEMY
            spinner.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                breaker.GenerateEnemyAbility(true),
                classic.GenerateEnemyAbility(true),
                bart.GenerateEnemyAbility(true)
            });
            spinner.AddEnemy(true, true);
        }
    }
}
