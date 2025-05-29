using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BlackStar
    {
        public static void Add()
        {
            Enemy star = new Enemy("Black Star", "BlackStar_EN")
            {
                Health = 16,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("BlackstarIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("BlackstarWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("BlackstarDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound,
            };
            star.PrepareEnemyPrefab("assets/group4/Blackstar/Blackstar_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Blackstar/Blackstar_Gibs.prefab").GetComponent<ParticleSystem>());

            //decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Collapse";
            decay.passiveIcon = ResourceLoader.LoadSprite("CollapsePassive.png");
            decay.m_PassiveID = "Collapse_PA";
            decay._enemyDescription = "On dying from Withering, spawn a Singularity.";
            decay._characterDescription = "eh";
            decay.doesPassiveTriggerInformationPanel = true;
            SpawnEnemyInSlotFromEntryStringNameEffect si = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
            si.en = "Singularity_EN";
            si.trySpawnAnywhereIfFail = true;
            decay.effects = Effects.GenerateEffect(si, 0, Slots.Self).SelfArray();
            decay._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
            decay.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IsWitheringDeathCondition>() };

            //turbulent
            PerformEffectPassiveAbility turb = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            turb._passiveName = "Turbulent";
            turb.m_PassiveID = "Turbulent_PA";
            turb.passiveIcon = ResourceLoader.LoadSprite("BlackstarPassive.png");
            turb._enemyDescription = "On being directly damaged, shuffle the position of all enemies.";
            turb._characterDescription = turb._enemyDescription;
            turb.doesPassiveTriggerInformationPanel = true;
            turb.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)).SelfArray();
            turb._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };

            star.AddPassives(new BasePassiveAbilitySO[] { decay, Passives.Withering, turb, Passives.Unstable });

            //radioation
            Ability rad = new Ability("Radiation_A")
            {
                Name = "Radiation",
                Description = "Inflict 1 Scar on every party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targetting.AllEnemy),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals,
                AnimationTarget = Slots.Self,
            };
            rad.AddIntentsToTarget(Targetting.AllEnemy, IntentType_GameIDs.Status_Scars.ToString().SelfArray());

            //flare
            Ability flare = new Ability("SolarFlare_A")
            {
                Name = "Solar Flare",
                Description = "Generate 1 pigment of every enemy's health color.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<GeneratePigmentAllEnemies>(), 1, Slots.Self),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                AnimationTarget = Slots.Self,
            };
            flare.AddIntentsToTarget(Targeting.Unit_AllAllies, IntentType_GameIDs.Mana_Generate.ToString().SelfArray());


            //ADD ENEMY
            star.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                rad.GenerateEnemyAbility(true),
                flare.GenerateEnemyAbility(true)
            });
            star.AddEnemy(true, true);
        }
    }
}
