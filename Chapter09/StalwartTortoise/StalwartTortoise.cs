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
                OverworldAliveSprite = ResourceLoader.LoadSprite("TortoiseWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("TortoiseDead.png", new Vector2(0.5f, 0f), 32),
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
            painless.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(PainCondition.Modifier);

            tortoise.AddPassives(new BasePassiveAbilitySO[] { armor, painless, Passives.Forgetful });
            tortoise.CombatEnterEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ArmorEffect>(), 1, Targetting.AllSelfSlots).SelfArray();
            AbilitySelector_Heaven turn1 = ScriptableObject.CreateInstance<AbilitySelector_Heaven>();
            turn1._useAfterTurns = 1;
            turn1._ComeHomeAbility = "Disemboweling_A";
            tortoise.AbilitySelector = turn1;

            //breath
            Ability breath = new Ability("DeepBreaths_A")
            {
                Name = "Deep Breaths",
                Description = "Apply 6 Shield to this enemy's positions. Inflict 2-3 Scars on this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, Targetting.AllSelfSlots),
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
                Description = "Deal damage to the Opposing party members by the double amount of Shield on this enemy's positions. Move this enemy to the Left or Right.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(DamageByFieldAmountEffect.Create(StatusField_GameIDs.Shield_ID.ToString(), true, true), 2, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Crush"),
                AnimationTarget = Slots.Front,
            };
            hurdle.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString()]);
            hurdle.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), [IntentType_GameIDs.Swap_Sides.ToString()]);

            //disembowel
            Ability disembowel = new Ability("Disemboweling_A")
            {
                Name = "Disemboweling",
                Description = "If this enemy is defended by more than 8 Shield, deal a Painful amount of damage and inflict 2 Frail on all party members.\nOtherwise, decrease Algophobia's threshold by 5 and produce 3 Blue pigment.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Weep_A", false, TargettingSelf_NotSlot.Create()), 1, Targeting.Slot_SelfSlot, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.Shield_ID.ToString(), 8, false, true)),
                    Effects.GenerateEffect(BasicEffects.ChangeValue(PainCondition.Modifier, true), 5, Targeting.Slot_SelfSlot, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.Shield_ID.ToString(), 8, false, true)),
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Blue), 3, Targeting.Slot_SelfSlot, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.Shield_ID.ToString(), 8, false, true)),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Shatter", false, TargettingSelf_NotSlot.Create()), 1, Targeting.Slot_SelfSlot, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.Shield_ID.ToString(), 8, true, true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Unit_AllOpponents, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.Shield_ID.ToString(), 8, true, true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Targeting.Unit_AllOpponents, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.Shield_ID.ToString(), 8, true, true)),
                },
                Visuals = null,
                AnimationTarget = Targetting.AllSelfSlots,
            };
            disembowel.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), [IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Mana_Generate.ToString()]);
            disembowel.AddIntentsToTarget(Targeting.Unit_AllOpponentSlots, [IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Status_Frail.ToString()]);

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
