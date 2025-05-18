using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class War
    {
        public static void Add()
        {
            Enemy template = new Enemy("War", "War_EN")
            {
                Health = 66,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("WarIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WarDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WarWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            template.PrepareEnemyPrefab("assets/group4/War/War_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/War/War_Gibs.prefab").GetComponent<ParticleSystem>());

            //DECAY
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay. m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            decay._enemyDescription = "Upon dying, this enemy decays into itself.";
            decay._characterDescription = "On dying, nothing happens. This effect won't work on party members. Be glad it doesnt break the game.";
            decay.doesPassiveTriggerInformationPanel = true;
            decay._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
            DeathReferenceDetectionEffectorCondition detectWither = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            detectWither._witheringDeath = false;
            detectWither._useWithering = true;
            decay.conditions = new EffectorConditionSO[]
            {
                detectWither
            };
            DelayRespawnEffect spawn = ScriptableObject.CreateInstance<DelayRespawnEffect>();
            decay.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(spawn, 1, Targeting.Slot_SelfSlot)
            };

            //parental
            ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
            ParentalPassiveAbility abandon = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
            abandon._passiveName = "Parental";
            abandon._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"Abandonment Play\" in retribution.";
            Ability parental = new Ability("War_Abandon_A");
            parental.Name = "Abandonment Play";
            parental.Description = "Apply 1 Constricted to the Opposing party member. Move this enemy to a random position.";
            parental.Effects = new EffectInfo[2];
            parental.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Targeting.Slot_Front);
            parental.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, Targeting.Slot_SelfSlot);
            parental.Visuals = CustomVisuals.GetVisuals("Salt/Alarm");
            parental.AnimationTarget = Targeting.Slot_Front;
            parental.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Field_Constricted.ToString() });
            parental.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Mass.ToString() });
            AbilitySO ability = parental.GenerateEnemyAbility(true).ability;
            abandon._parentalAbility.ability = ability;


            //SILENCE
            TargetStoredValueChangeEffect incNoise = ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>();
            incNoise._valueName = NoiseHandler.Noise;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;
            PerformEffectPassiveAbility silence = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            silence._passiveName = "Silence";
            silence.passiveIcon = ResourceLoader.LoadSprite("Passive_Silence.png");
            silence.m_PassiveID = "War_Silence_PA";
            silence._enemyDescription = "On any party member performing an ability, increase their Noise by 1.";
            silence._characterDescription = "On any enemy performing an ability, increase their Noise by 1.";
            silence.conditions = ScriptableObject.CreateInstance<SilenceCondition>().SelfArray();
            silence._triggerOn = CCTVHandler.Trigger.SelfArray();
            silence.effects = new EffectInfo[0];

            //addpassives
            template.AddPassives(new BasePassiveAbilitySO[] { silence, Passives.Unstable, Passives.Withering, decay, abandon });

            //Librarium
            Ability librarium = new Ability("Postmodern_Librarium_A")
            {
                Name = "Librarium",
                Description = "Kill all party members with a Noise level of 5 or higher. Reset the Noise of the Far Left and Far Right party members.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Static", false, Targeting.Slot_SelfSlot), 1, NoiseTargetting.Default(), ScriptableObject.CreateInstance<IsNoiseCondition>()),
                    Effects.GenerateEffect(BasicEffects.Die(true), 1, NoiseTargetting.Default()),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Wriggle_A", false, Targeting.GenerateSlotTarget(new int[] {-2, 2 }, false)), 1, NoiseTargetting.Default(), BasicEffects.DidThat(false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetSetValueChangeEffect>(), 0, Targeting.GenerateSlotTarget(new int[] {-2, 2 }, false))
                },
                Visuals = null,
                AnimationTarget = Targeting.Slot_SelfSlot,
            };
            librarium.AddIntentsToTarget(NoiseTargetting.Default(), new string[] { IntentType_GameIDs.Damage_Death.ToString() });
            librarium.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -2, 0, 2 }, false), new string[] {IntentType_GameIDs.Misc.ToString() });

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                librarium.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true);
        }
    }
}
