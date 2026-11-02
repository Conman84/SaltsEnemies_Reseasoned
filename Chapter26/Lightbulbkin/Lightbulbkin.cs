using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Lightbulbkin
    {
        public static void Add()
        {
            Enemy lightbulbkin = new Enemy("LIghtbulbkin", "Lightbulbkin_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("LightbulbkinIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("LightbulbkinWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("LightbulbkinDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            lightbulbkin.PrepareEnemyPrefab("Assets/ch_26/Lightbulbkin_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/ch_26/Lightbulbkin_Gibs.prefab").GetComponent<ParticleSystem>());
            
            //fantastic
            PerformEffectPassiveAbility fantastic = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fantastic._passiveName = "Fantastic (2)";
            fantastic.name = "Fantastic_2_PA";
            fantastic.passiveIcon = ResourceLoader.LoadSprite("PassiveFantastic.png");
            fantastic.m_PassiveID = "Fantastic_PA";
            fantastic._enemyDescription = "On being directly damaged, gain 2 Dodge.";
            fantastic._characterDescription = "On being directly damaged, gain 2 Dodge.";
            fantastic.doesPassiveTriggerInformationPanel = true;
            fantastic.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 2, Slots.Self).SelfArray();
            fantastic._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };

            //parental
            ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
            ParentalPassiveAbility radial = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
            radial._passiveName = "Parental";
            radial._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"Radial Dichotomy\" in retribution.";
            Ability parental = new Ability("RadialDichotomy_A");
            parental.Name = "Radial Dichotomy";
            parental.Description = "Inflict 0 or 10 Slip on all party member and enemy positions.";
            parental.Effects = new EffectInfo[3];
            parental.Effects[0] = Effects.GenerateEffect(ZeroOrEntryEffect.Create(ScriptableObject.CreateInstance<ApplySlipSlotEffect>()), 10, MultiTargetting.Create(Targetting.Everything(true), Targetting.Everything(false)));
            parental.AddIntentsToTarget(Targetting.Everything(true), [Slip.Intent]);
            parental.AddIntentsToTarget(Targetting.Everything(false), [Slip.Intent]);
            parental.Visuals = CustomVisuals.GetVisuals("Salt/Wheel");
            parental.AnimationTarget = Slots.Self;
            AbilitySO ability = parental.GenerateEnemyAbility(true).ability;
            radial._parentalAbility.ability = ability;

            lightbulbkin.AddPassives(new BasePassiveAbilitySO[] { Passives.Forgetful, Passives.OverexertGenerator(3), fantastic, radial });

            Ability atrophy = new Ability("DivineAtrophy_A");
            atrophy.Name = "Divine Atrophy";
            atrophy.Description = "Bless the Opposing party member with 3 Divine Protection and 33 Entropy.\nGain 13 Shield.";
            atrophy.Rarity = Rarity.Common;
            atrophy.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 33, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 13, Slots.Self),
                ];
            atrophy.AddIntentsToTarget(Slots.Front, ["Status_DivineProtection", Entropy.Intent]);
            atrophy.AddIntentsToTarget(Slots.Self, ["Field_Shield"]);
            atrophy.Visuals = Visuals.Excommunicate;
            atrophy.AnimationTarget = Slots.Front;

            TargettingFurthestSide side = ScriptableObject.CreateInstance<TargettingFurthestSide>();
            side.getAllies = false;

            Ability shift = new Ability("ShiftDistalParadigm_A");
            shift.Name = "Shift Distal Paradigm";
            shift.Description = "Deal an Agonizing amount of damage to the Opposing party member. If there is no Opposing party member, inflict 1 Linked on all party members on the side of this enemy towards the Center of the field.\nIf this enemy has Dodge, move towards the nearest edge of the field, then queue this ability again if successful.";
            shift.Rarity = Rarity.CreateAndAddCustomRarityToPool("bulb15", 15);
            shift.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 1, side, IsFrontTargetCondition.Create(false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveTowardsEdgeEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<HasDodgeCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<QueueShiftEffect>(), 1, Slots.Self, BasicEffects.DidThat(true))
                ];
            shift.AddIntentsToTarget(Slots.Front, ["Damage_7_10"]);
            shift.AddIntentsToTarget(side, ["Status_Linked"]);
            shift.AddIntentsToTarget(Slots.Self, ["Misc_Hidden", "Swap_Sides"]);
            shift.Visuals = CustomVisuals.GetVisuals("Salt/Ribbon");
            shift.AnimationTarget = Slots.Front;


            //ADD ENEMY
            lightbulbkin.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                atrophy.GenerateEnemyAbility(true),
                shift.GenerateEnemyAbility(true)
            });
            lightbulbkin.AddEnemy(true, true);
            lightbulbkin.enemy.AddToSynodPool();
            lightbulbkin.enemy.AddToToysPool();
            lightbulbkin.enemy.AddToEcstasyPool();
        }
    }
}
