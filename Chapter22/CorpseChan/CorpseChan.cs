using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class CorpseChan
    {
        public static void Add()
        {
            Enemy corpse = new Enemy("Corpse~Chan", "CorpseChan_EN")
            {
                Health = 40,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CorpseChanIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CorpseChanWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CorpseChanDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sosn2/RotHit",
                DeathSound = "event:/Hawthorne/Sosn2/RotDie",
            };
            corpse.PrepareEnemyPrefab("Assets/Item/CorpseChan_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Item/CorpseChan_Gibs.prefab").GetComponent<ParticleSystem>());

            LovelyPassive lovely = ScriptableObject.CreateInstance<LovelyPassive>();
            lovely.name = "Lovely_PA";
            lovely._passiveName = "Lovely";
            lovely.m_PassiveID = "Lovely_PA";
            lovely.passiveIcon = ResourceLoader.LoadSprite("LovelyPassive.png");
            lovely._enemyDescription = "This enemy will use all of its abilities every round.";
            lovely._characterDescription = "you might be rettartded";
            lovely._triggerOn = [];
            lovely.effects = [];
            lovely.conditions = [];
            LovelyPassive.Setup();

            PerformEffectPassiveAbility homunculus = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            homunculus.name = "Homunculus_5_PA";
            homunculus._passiveName = "Homunculus (5)";
            homunculus.m_PassiveID = "Homunculus_PA";
            homunculus.passiveIcon = ResourceLoader.LoadSprite("HomunculusPassive.png");
            homunculus._enemyDescription = "When this enemy has run out of abilities to use, deal a Painful amount of damage to the Opposing party member.";
            homunculus._characterDescription = "At the end of the timeline, deal 5 damage to the Opposing enemy.";
            homunculus._triggerOn = [TriggerCalls.OnPlayerTurnEnd_ForEnemy, TriggerCalls.OnAbilityUsed, TriggerCalls.TimelineEndReached];
            homunculus.effects = [Effects.GenerateEffect(BasicEffects.GetVisuals("Crush_A", false, Slots.Front), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front)];
            homunculus.conditions = [ScriptableObject.CreateInstance<HasNoAbilitiesLeftCondition>(), ScriptableObject.CreateInstance<OncePerRoundCondition>()];

            corpse.AddPassives(new BasePassiveAbilitySO[] { lovely, homunculus, Passives.Overexert1 });

            Ability h = new Ability("H", "CCH_A");
            h.Description = "Move Left twice.";
            h.Rarity = Rarity.GetCustomRarity("rarity5");
            h.Effects = [
                Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self)
                ];
            h.AddIntentsToTarget(Slots.Self, ["Swap_Left", "Swap_Left"]);
            h.Visuals = null;

            Ability m = new Ability("M", "CCM_A");
            m.Description = "Move Right.";
            m.Rarity = h.Rarity;
            m.Effects = [Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self)];
            m.AddIntentsToTarget(Slots.Self, ["Swap_Right"]);
            m.Visuals = null;

            Ability n = new Ability("N", "CCN_A");
            n.Description = "Move Left.";
            n.Rarity = h.Rarity;
            n.Effects = [Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self)];
            n.AddIntentsToTarget(Slots.Self, ["Swap_Left"]);
            n.Visuals = null;

            Ability k = new Ability("K", "CCK_A");
            k.Description = "Move Right twice.";
            k.Rarity = h.Rarity;
            k.Effects = [
                Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self)
                ];
            k.AddIntentsToTarget(Slots.Self, ["Swap_Right", "Swap_Right"]);
            k.Visuals = null;

            Ability er = new Ability("ER", "CCER_A");
            er.Description = "Move Left or Right.";
            er.Rarity = h.Rarity;
            er.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)];
            er.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            er.Visuals = null;

            //ADD ENEMY
            corpse.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                h.GenerateEnemyAbility(true),
                m.GenerateEnemyAbility(true),
                n.GenerateEnemyAbility(true),
                k.GenerateEnemyAbility(true),
                er.GenerateEnemyAbility(true),
            });
            corpse.AddEnemy(true, true);
        }
    }
}
