using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class StalwartTortoise
    {
        public static void Add()
        {
            Enemy tortoise = new Enemy("Stalwart Tortoise", "StalwartTortoise_EN")
            {
                Health = 66,
                HealthColor = Pigments.Red,
                Size = 2,
                CombatSprite = ResourceLoader.LoadSprite("TortoiseIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("TortoiseWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("TortoiseDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").deathSound,
            };
            tortoise.PrepareEnemyPrefab("assets/group4/Tortoise/Tortoise_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Tortoise/Tortoise_Gibs.prefab").GetComponent<ParticleSystem>());

            //armmor
            ArmorManager.Setup();
            PerformEffectPassiveAbility armor = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            armor._passiveName = "Heavily Armored (10)";
            armor.passiveIcon = ResourceLoader.LoadSprite("heavily_armored");
            armor._enemyDescription = "If any of this enemy's positions have no Shield, apply 10 Shield there.";
            armor._characterDescription = "If this party member's position has no Shield, apply 10 Shield there.";
            armor.m_PassiveID = ArmorManager.Armor;
            armor.doesPassiveTriggerInformationPanel = false;
            armor._triggerOn = new TriggerCalls[] { TriggerCalls.OnMoved };
            armor.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ArmorEffect>(), 1, Targetting.AllSelfSlots).SelfArray();

            //painless
            PainCondition.Setup();
            PerformEffectPassiveAbility painless = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            painless._passiveName = "Algophobia (20)";
            painless.passiveIcon = ResourceLoader.LoadSprite("algophobia");
            painless._enemyDescription = "Taking 20 or more damage in one turn will make this enemy instantly flee.";
            painless._characterDescription = "Taking 20 or more damage in one turn will make this party member instantly flee. But also it wont work on party members anyway lol.";
            painless.m_PassiveID = "Algophobia_PA";
            painless.doesPassiveTriggerInformationPanel = true;
            painless._triggerOn = new TriggerCalls[] { TriggerCalls.OnDamaged, TriggerCalls.OnPlayerTurnEnd_ForEnemy };
            painless.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<PainCondition>() };
            painless.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self).SelfArray();
            painless.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(PainCondition.Pain);

            tortoise.AddPassives(new BasePassiveAbilitySO[] { armor, painless, Passives.Forgetful, Passives.FleetingGenerator(9) });
            tortoise.CombatEnterEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ArmorEffect>(), 1, Targetting.AllSelfSlots).SelfArray();

            //breath
            Ability breath = new Ability("DeepBreaths_A")
            {
                Name = "Deep Breaths",
                Description = "Apply 4 Shield to this enemy's positions. Inflict 2-3 Scars on this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, Targetting.AllSelfSlots),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 2, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50))
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals,
                AnimationTarget = Targetting.AllSelfSlots,
            };
            breath.AddIntentsToTarget(Targetting.AllSelfSlots, [IntentType_GameIDs.Field_Shield.ToString()]);
            breath.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), [IntentType_GameIDs.Status_Scars.ToString()]);

            //hurdle
            Ability hurdle = new Ability("Hurdle_A")
            {
                Name = "Hurdle",
                Description = "Deal a Painful amount of damage to the Opposing party members. Move this enemy to the Left or Right.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Crush"),
                AnimationTarget = Slots.Front,
            };
            hurdle.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            hurdle.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), [IntentType_GameIDs.Swap_Sides.ToString()]);

            //disembowel
            Ability disembowel = new Ability("Disemboweling_A")
            {
                Name = "Disemboweling",
                Description = "Apply 6 Shield to the Left and Right enemy positions. Inflict 3 Ruptured on this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, Slots.Sides),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, Targeting.Slot_SelfSlot),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Shatter"),
                AnimationTarget = Targetting.AllSelfSlots,
            };
            disembowel.AddIntentsToTarget(Slots.Sides, [IntentType_GameIDs.Field_Shield.ToString()]);
            disembowel.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), [IntentType_GameIDs.Status_Ruptured.ToString()]);

            //ADD ENEMY
            tortoise.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                breath.GenerateEnemyAbility(true),
                hurdle.GenerateEnemyAbility(true),
                disembowel.GenerateEnemyAbility(true)
            });
            tortoise.AddEnemy(true, true);
        }
    }
}
