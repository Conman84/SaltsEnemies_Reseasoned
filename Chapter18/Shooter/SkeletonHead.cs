using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class SkeletonHead
    {
        public static ParticleSystem SuicideGibs;
        public static void Add()
        {
            Enemy template = new Enemy("Skeleton Head", "SkeletonHead_EN")
            {
                Health = 15,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("HeadIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("HeadWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("HeadDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noisy/Bone_Hit",
                DeathSound = "event:/Hawthorne/Noisy/Bone_Death",
                UnitTypes = ["SkeletonHead_EN"]
            };
            template.PrepareEnemyPrefab("assets/enemie/Head_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/enem2/Shooter2/Head_Normal_Gibs.prefab").GetComponent<ParticleSystem>());
            SuicideGibs = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/enem2/Shooter2/Head_Suicide_Gibs.prefab").GetComponent<ParticleSystem>();
            SuicideGibs.transform.GetChild(3).gameObject.AddComponent<HeadGibsManager>().SetTargetSystem(SuicideGibs.transform.GetChild(3).GetComponent<ParticleSystem>());
            SuicideGibs.transform.GetChild(4).gameObject.AddComponent<HeadGibsManager>().SetTargetSystem(SuicideGibs.transform.GetChild(4).GetComponent<ParticleSystem>());
            SuicideGibs.transform.GetChild(5).gameObject.AddComponent<HeadGibsManager>().SetTargetSystem(SuicideGibs.transform.GetChild(5).GetComponent<ParticleSystem>());
            SuicideGibs.transform.GetChild(6).gameObject.AddComponent<HeadGibsManager>().SetTargetSystem(SuicideGibs.transform.GetChild(6).GetComponent<ParticleSystem>());
            SuicideGibs.transform.GetChild(7).gameObject.AddComponent<HeadGibsManager>().SetTargetSystem(SuicideGibs.transform.GetChild(7).GetComponent<ParticleSystem>());

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Forgetful, Passives.Enfeebled });

            SetCasterAnimationParameterEffect suiciding = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            suiciding._parameterName = "Suiciding";
            suiciding._parameterValue = 1;
            SetCasterAnimationParameterEffect suicide = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            suicide._parameterName = "Suicide";
            suicide._parameterValue = 1;
            HeadHandler.Setup();

            //obliterate
            Ability obliterate = new Ability("Obliterate_A")
            {
                Name = "Obliterate",
                Description = "Deal this enemy's current health as damage to the Opposing party member and obliterate this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(suiciding),
                    Effects.GenerateEffect(suicide),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Curse", false, Slots.Front)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageByCasterHealthEffect>(), 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self),
                },
                Visuals = null,
                AnimationTarget = Slots.Front,
            };
            obliterate.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_16_20.ToString().SelfArray());
            obliterate.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Damage_Death.ToString().SelfArray());

            //wobble
            Ability wobble = new Ability("Wobble_A")
            {
                Name = "Wobble",
                Description = "Move to the Left or Right.\nApply 5 Shield to this enemy's position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, Slots.Self),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals,
                AnimationTarget = Slots.Self,
            };
            wobble.AddIntentsToTarget(Slots.Self, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Field_Shield.ToString() });

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                obliterate.GenerateEnemyAbility(true),
                wobble.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true, true);
            template.enemy.AddToToysPool();
        }
    }
}
