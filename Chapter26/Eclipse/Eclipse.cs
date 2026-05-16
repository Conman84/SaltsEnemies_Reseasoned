using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using Tools;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Eclipse
    {

        public static void Add()
        {
            Enemy eclipse = new Enemy("Eclipse Rising", "EclipseRising_EN")
            {
                Health = 31,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("RisingIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("RisingWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("RisingDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Yang_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Yang_EN").deathSound,
            };
            eclipse.PrepareEnemyPrefab("assets/group4/Rising/Rising_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Rising/Rising_Gibs.prefab").GetComponent<ParticleSystem>());

            Enemy awake = new Enemy("Eclipse Awakened", "EclipseAwakened_EN")
            {
                Health = 31,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("AwakenedIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("AwakenedWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("AwakenedDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Yin_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Yin_EN").deathSound,
            };
            awake.PrepareEnemyPrefab("assets/group4/Rising/Rising_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Rising/Rising_Gibs.prefab").GetComponent<ParticleSystem>());


            //JITERRY
            PerformEffectPassiveAbility jitter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            jitter._passiveName = "Jittery";
            jitter.m_PassiveID = "Jittery_PA";
            jitter.passiveIcon = ResourceLoader.LoadSprite("JitteryPassive.png");
            jitter._enemyDescription = "On any party member manually moving, move to the Left or Right.";
            jitter._characterDescription = jitter._enemyDescription;
            jitter.doesPassiveTriggerInformationPanel = true;
            jitter.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self).SelfArray();
            jitter._triggerOn = new TriggerCalls[] { JitteryHandler.Call };
            jitter.conditions = new EffectorConditionSO[0];
            //scary
            PerformEffectPassiveAbility scary = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            scary._passiveName = "Scary";
            scary.passiveIcon = ResourceLoader.LoadSprite("ScaryPassive.png");
            scary.m_PassiveID = "Scary_PA";
            scary._enemyDescription = "On being directly damaged, Curse the Opposing party member.";
            scary._characterDescription = "On being directly damaged, Curse the Opposing enemy.";
            scary.doesPassiveTriggerInformationPanel = true;
            scary.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Front).SelfArray();
            scary._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };

            eclipse.AddPassives(new BasePassiveAbilitySO[] { jitter, scary });

            CasterAddExtraAbilitySetFromPreviousEffect random_set = ScriptableObject.CreateInstance<CasterAddExtraAbilitySetFromPreviousEffect>();
            IntListWrapper a = new IntListWrapper() { list = { } };
            IntListWrapper b = new IntListWrapper() { list = { 0 } };
            IntListWrapper c = new IntListWrapper() { list = { 0, 0 } };
            IntListWrapper d = new IntListWrapper() { list = { 0, 0, 0 } };
            IntListWrapper e = new IntListWrapper() { list = { 0, 0, 0, 0 } };
            IntListWrapper f = new IntListWrapper() { list = { 0, 0, 0, 0, 0 } };
            random_set._AbilitySets = [ a, b, c, d, e, f ];

            ExtraAbilityInfoListWrapper pool = new ExtraAbilityInfoListWrapper() { list = [] };
            random_set._PoolsData = [pool];

            Ability fate = new Ability("Invisible Fates", "InvisibleFate_A");
            fate.Description = "If the Opposing party member is Cursed, deal an Agonizing amount of damage to them.";
            fate.Rarity = Rarity.CreateAndAddCustomRarityToPool("knight_20", 20);
            fate.Priority = Priority.Fast;
            StatusEffectCheckerEffect has_curse = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            has_curse._status = StatusField.Cursed;
            fate.Effects = [Effects.GenerateEffect(has_curse, 1, Slots.Front), Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, BasicEffects.DidThat(true))];
            fate.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_7_10"]);
            fate.AnimationTarget = Slots.Front;
            fate.Visuals = LoadedAssetsHandler.GetCharacterAbility("Conversion_1_A").visuals;

            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility bonusattack = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            bonusattack._passiveName = "Invisible Fates";
            bonusattack._enemyDescription = "This enemy will perforn the extra ability \"Invisible Fates\" each turn.";
            bonusattack._extraAbility.ability = fate.GenerateEnemyAbility(true).ability;

            awake.AddPassives([jitter, scary, bonusattack]);

            Ability second = new Ability("Second Pain", "Eclipse2_A");
            second.Description = "Inflict 4 Slip on the Left and Right enemy positions then a Little damage to all enemies in Slip.\nRemove this ability from this enemy's moveset.";
            second.Rarity = Rarity.Common;
            second.Effects = new EffectInfo[3];
            second.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 4, Slots.Sides);
            second.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<InSlipDamageEffect>(), 2, Targeting.Unit_AllAllies);
            second.AddIntentsToTarget(Slots.Sides, [Slip.Intent]);
            second.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Damage_1_2"]);
            second.AddIntentsToTarget(Slots.Self, ["Misc"]);
            second.AnimationTarget = Slots.Self;
            second.Visuals = Visuals.Melt;
            second.GenerateEnemyAbility(true);

            pool.list.Add(second.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_second));
            second.Effects[2] = Effects.GenerateEffect(remove_second);

            Ability third = new Ability("Third Pain", "Eclipse3_A");
            third.Description = "Inflict 2 Oil-Slicked on all enemies and take a Little damage.\nRemove this ability from this enemy's moveset.";
            third.Rarity = Rarity.Common;
            third.Effects = new EffectInfo[3];
            third.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, Targeting.Unit_AllAllies);
            third.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self);
            third.AddIntentsToTarget(Targeting.Unit_AllAllies, [IntentType_GameIDs.Status_OilSlicked.ToString()]);
            third.AddIntentsToTarget(Slots.Self, ["Damage_1_2", "Misc"]);
            third.AnimationTarget = Slots.Self;
            third.Visuals = Visuals.Melt;
            third.GenerateEnemyAbility(true);

            pool.list.Add(third.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_third));
            third.Effects[2] = Effects.GenerateEffect(remove_third);

            Ability fourth = new Ability("Fourth Pain", "Eclipse4_A");
            fourth.Description = "Deal an Agonizing amount of damage to the Opposing party member and inflict 4 Slip on the Opposing position.\nRemove this ability from this enemy's moveset.";
            fourth.Rarity = Rarity.Common;
            fourth.Effects = new EffectInfo[3];
            fourth.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front);
            fourth.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 4, Slots.Front);
            fourth.AddIntentsToTarget(Slots.Front, ["Damage_7_10", Slip.Intent]);
            fourth.AddIntentsToTarget(Slots.Self, ["Misc"]);
            fourth.AnimationTarget = Slots.Front;
            fourth.Visuals = Visuals.Melt;
            fourth.GenerateEnemyAbility(true);

            pool.list.Add(fourth.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_fourth));
            fourth.Effects[2] = Effects.GenerateEffect(remove_fourth);

            Ability sixth = new Ability("Sixth Pain", "Eclipse6_A");
            sixth.Description = "Inflict 4 Slip on the Opposing position, then Curse the Left, Right, an Opposing party members.\nRemove this ability from this enemy's moveset.";
            sixth.Rarity = Rarity.CreateAndAddCustomRarityToPool("eclipse15", 15);
            sixth.Effects = new EffectInfo[3];
            sixth.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 4, Slots.Front);
            sixth.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.FrontLeftRight);
            sixth.AddIntentsToTarget(Slots.Front, [Slip.Intent]);
            sixth.AddIntentsToTarget(Slots.FrontLeftRight, ["Status_Cursed"]);
            sixth.AddIntentsToTarget(Slots.Self, ["Misc"]);
            sixth.AnimationTarget = Slots.FrontLeftRight;
            sixth.Visuals = Visuals.Melt;
            sixth.GenerateEnemyAbility(true);

            pool.list.Add(sixth.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_sixth));
            sixth.Effects[2] = Effects.GenerateEffect(remove_sixth);

            Ability eighth = new Ability("Eighth Pain", "Eclipse8_A");
            eighth.Description = "Inflict 2 Slip on the Left, Right, and Opposing positions.\nRemove this ability from this enemy's moveset.";
            eighth.Rarity = Rarity.Common;
            eighth.Effects = new EffectInfo[2];
            eighth.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.FrontLeftRight);
            eighth.AddIntentsToTarget(Slots.FrontLeftRight, [Slip.Intent]);
            eighth.AddIntentsToTarget(Slots.Self, ["Misc"]);
            eighth.AnimationTarget = Slots.FrontLeftRight;
            eighth.Visuals = Visuals.Melt;
            eighth.GenerateEnemyAbility(true);

            pool.list.Add(eighth.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_eighth));
            eighth.Effects[1] = Effects.GenerateEffect(remove_eighth);

            Ability ninth = new Ability("Ninth Pain", "Eclipse9_A");
            ninth.Description = "Inflict 3 Oil-Slicked and deal a Barely Painful amount of damage to the Opposing party member 3 times.\nRemove this ability from this enemy's moveset";
            ninth.Rarity = Rarity.Common;
            ninth.Effects = new EffectInfo[5];
            ninth.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, Slots.Front);
            ninth.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Front);
            ninth.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Front);
            ninth.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Front);
            ninth.AddIntentsToTarget(Slots.Front, ["Status_OilSlicked", "Damage_3_6", "Damage_3_6", "Damage_3_6"]);
            ninth.AddIntentsToTarget(Slots.Self, ["Misc"]);
            ninth.AnimationTarget = Slots.Front;
            ninth.Visuals = Visuals.Melt;
            ninth.GenerateEnemyAbility(true);

            pool.list.Add(ninth.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_ninth));
            ninth.Effects[4] = Effects.GenerateEffect(remove_ninth);

            Ability twelfth = new Ability("Twelfth Pain", "Eclipse12_A");
            twelfth.Description = "Move Left or Right and queue another action.\nRemove this ability from this enemy's moveset.";
            twelfth.Rarity = Rarity.Common;
            twelfth.Effects = new EffectInfo[3];
            twelfth.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            twelfth.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self);
            twelfth.AddIntentsToTarget(Slots.Self, ["Swap_Sides", "Misc_Additional", "Misc"]);
            twelfth.AnimationTarget = Slots.Self;
            twelfth.Visuals = Visuals.Melt;
            twelfth.GenerateEnemyAbility(true);

            pool.list.Add(twelfth.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_twelfth));
            twelfth.Effects[1] = Effects.GenerateEffect(remove_twelfth);

            Ability fifteenth = new Ability("Fifteenth Pain", "Eclipse15_A");
            fifteenth.Description = "Fully heal this enemy and gain Spotlight.\nRemove this ability from this enemy's moveset.";
            fifteenth.Rarity = Rarity.Common;
            fifteenth.Effects = new EffectInfo[3];
            fifteenth.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<FullHealEffect>(), 999, Slots.Self);
            fifteenth.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, Slots.Self);
            fifteenth.AddIntentsToTarget(Slots.Self, ["Heal_11_20", "Status_Spotlight", "Misc"]);
            fifteenth.AnimationTarget = Slots.Self;
            fifteenth.Visuals = Visuals.Melt;
            fifteenth.GenerateEnemyAbility(true);

            pool.list.Add(fifteenth.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_fifteenth));
            fifteenth.Effects[2] = Effects.GenerateEffect(remove_fifteenth);

            Ability eighteenth = new Ability("Eighteenth Pain", "Eclipse18_A");
            eighteenth.Description = "Add 2 more abilities to this enemy's moveset and gain 10 Shield.\nRemove this ability from this enemy's moveset.";
            eighteenth.Rarity = Rarity.GetCustomRarity("rarity5");
            eighteenth.Effects = new EffectInfo[3];
            eighteenth.Effects[1] = Effects.GenerateEffect(random_set, 2, Slots.Self);
            eighteenth.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, Slots.Self);
            eighteenth.AddIntentsToTarget(Slots.Self, ["Field_Shield", "Misc"]);
            eighteenth.AnimationTarget = Slots.Self;
            eighteenth.Visuals = Visuals.Melt;
            eighteenth.GenerateEnemyAbility(true);

            pool.list.Add(eighteenth.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_eighteenth));
            eighteenth.Effects[0] = Effects.GenerateEffect(remove_eighteenth);

            CasterTransformByStringEffect awaken = ScriptableObject.CreateInstance<CasterTransformByStringEffect>();
            awaken.enemy = "EclipseAwakened_EN";
            awaken._fullyHeal = true;
            
            Ability twentieth = new Ability("Twentieth Pain", "Eclipse20_A");
            twentieth.Description = "Awaken.";
            twentieth.Rarity = Rarity.GetCustomRarity("rarity5");
            twentieth.Effects = [Effects.GenerateEffect(awaken, 1, Slots.Self)];
            twentieth.AddIntentsToTarget(Slots.Self, ["Yin_Yang"]);
            twentieth.AnimationTarget = Slots.Self;
            twentieth.Visuals = CustomVisuals.GetVisuals("Salt/YinYang");
            twentieth.GenerateEnemyAbility(true);

            pool.list.Add(twentieth.ExtraAbility(out CasterAddOrRemoveExtraAbilityEffect remove_twentieth));

            eclipse.CombatEnterEffects = [Effects.GenerateEffect(random_set, 2, Slots.Self)];
            awake.CombatEnterEffects = [Effects.GenerateEffect(random_set, 4, Slots.Self)];

            //ADD ENEMY
            eclipse.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                fate.GenerateEnemyAbility(true),
            });
            eclipse.AddEnemy(true, true);

            awake.AddEnemy(true, true);
        }
    }
}
