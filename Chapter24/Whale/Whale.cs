using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Whale
    {
        public static ParticleSystem Collisionless;
        public static void Add()
        {
            Enemy whale = new Enemy("The Whale", "TheWhale_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("WhaleIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WhaleWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WhaleDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TheDeep_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("TheDeep_EN").deathSound,
            };
            whale.PrepareEnemyPrefab("Assets/wip5/Whale_Wip_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Whale_Wip_Gibs.prefab").GetComponent<ParticleSystem>());
            Collisionless = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Whale_Far_Wip_Gibs.prefab").GetComponent<ParticleSystem>();

            Ability tele = new Ability("TelescopingSeries_A");
            tele.Name = "Telescoping Series";
            tele.Description = "Move the Opposing party member Left twice or Right twice.\nGain 2 Slip.";
            tele.Rarity = Rarity.GetCustomRarity("rarity5");
            tele.Effects = [
                Effects.GenerateEffect(SubActionEffect.Create([
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self)
                    ]), 1, Slots.Front, Effects.ChanceCondition(50)),
                Effects.GenerateEffect(SubActionEffect.Create([
                    Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self)
                    ]), 1, Slots.Front, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.Self),
                ];
            tele.AddIntentsToTarget(Slots.Front, ["Swap_Left", "Swap_Left", "Swap_Right", "Swap_Right"]);
            tele.AddIntentsToTarget(Slots.Self, [Slip.Intent]);
            tele.Visuals = CustomVisuals.GetVisuals("Salt/Door");
            tele.AnimationTarget = Slots.Front;

            Ability geo = new Ability("GeometricSequence_A");
            geo.Name = "Geometric Sequence";
            geo.Description = "Apply 1 Slip to the Left and Right party member positions.\nMove Left or Right.";
            geo.Rarity = Rarity.GetCustomRarity("rarity5");
            geo.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.LeftRight),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)];
            geo.AddIntentsToTarget(Slots.LeftRight, [Slip.Intent]);
            geo.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            geo.Visuals = Visuals.Wriggle;
            geo.AnimationTarget = Slots.LeftRight;

            Ability taylor = new Ability("TaylorPolynomial_A");
            taylor.Name = "Taylor Polynomial";
            taylor.Description = "At the start of the next turn, deal an Agonizing amount of damage to this enemy's current Opposing position.\nInflict 2 Oil-Slicked on the Opposing party member.";
            taylor.Rarity = Rarity.GetCustomRarity("rarity5");
            taylor.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 7, Slots.Front),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, Slots.Front)];
            taylor.AddIntentsToTarget(Slots.Front, ["Damage_7_10", "Damage_Delay", "Status_OilSlicked"]);
            taylor.Visuals = CustomVisuals.GetVisuals("Salt/Reload");
            taylor.AnimationTarget = Slots.Front;

            //ADD ENEMY
            whale.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                tele.GenerateEnemyAbility(true),
                geo.GenerateEnemyAbility(true),
                taylor.GenerateEnemyAbility(true)
            });
            whale.AddEnemy(true, true);
        }
    }
}
