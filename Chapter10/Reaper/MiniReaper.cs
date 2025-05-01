using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class MiniReaper
    {
        public static void Add()
        {
            Enemy template = new Enemy("Death's Notice", "MiniReaper_EN")
            {
                Health = 30,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("ReaperIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReaperWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReaperDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound,
            };
            template.PrepareEnemyPrefab("assets/group4/Reaper/Reaper_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Reaper/Reaper_Gibs.prefab").GetComponent<ParticleSystem>());

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering });

            //LEFT
            AnimationVisualsIfUnitEffect play = ScriptableObject.CreateInstance<AnimationVisualsIfUnitEffect>();
            play._animationTarget = Slots.Front;
            play._visuals = CustomVisuals.GetVisuals("Salt/Hung");
            play._noUnitAnimationTarget = Slots.Front;
            play._noUnitVisuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            Ability leftKill = new Ability("LeftToDie_A")
            {
                Name = "Left to Die",
                Description = "Move left. Instantly kill the Opposing party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    Effects.GenerateEffect(play, 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Front),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            leftKill.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Left.ToString().SelfArray());
            leftKill.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_Death.ToString().SelfArray());

            //RIGHT
            AnimationVisualsIfUnitEffect right = ScriptableObject.CreateInstance<AnimationVisualsIfUnitEffect>();
            right._animationTarget = Slots.Front;
            right._visuals = CustomVisuals.GetVisuals("Salt/Hung");
            right._noUnitAnimationTarget = Slots.Front;
            right._noUnitVisuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            Ability rightKill = new Ability("RighteousExecution_A")
            {
                Name = "Righteous Execution",
                Description = "Move right. Instantly kill the Opposing party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self),
                    Effects.GenerateEffect(right, 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Front),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            rightKill.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Right.ToString().SelfArray());
            rightKill.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_Death.ToString().SelfArray());

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                leftKill.GenerateEnemyAbility(true),
                rightKill.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true, true);
        }
    }
}
