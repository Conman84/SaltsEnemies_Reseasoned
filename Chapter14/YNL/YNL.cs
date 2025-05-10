using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public static class YNL
    {
        public static void Add()
        {
            Enemy lobotomy = new Enemy("Your New Life!", "YNL_EN")
            {
                Health = 35,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("LobotomyIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("LobotomyWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("LobotomyDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound,
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_YNL>()
            };
            lobotomy.PrepareMultiEnemyPrefab("assets/Lobotomy/Lobotomy_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Lobotomy/Lobotomy_Gibs.prefab").GetComponent<ParticleSystem>());
            (lobotomy.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (4)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (6)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (7)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (8)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (9)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (10)").GetComponent<SpriteRenderer>(),
            };

            //APPOINTMENT
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            DoubleExtraAttackPassiveAbility point = ScriptableObject.CreateInstance<DoubleExtraAttackPassiveAbility>();
            point.conditions = baseExtra.conditions;
            point.passiveIcon = baseExtra.passiveIcon;
            point.specialStoredData = baseExtra.specialStoredData;
            point.doesPassiveTriggerInformationPanel = baseExtra.doesPassiveTriggerInformationPanel;
            point.m_PassiveID = baseExtra.m_PassiveID;
            point._extraAbility = new ExtraAbilityInfo();
            point._extraAbility.rarity = baseExtra._extraAbility.rarity;
            point._extraAbility.cost = baseExtra._extraAbility.cost;
            point._secondExtraAbility = new ExtraAbilityInfo();
            point._secondExtraAbility.rarity = point._extraAbility.rarity;
            point._secondExtraAbility.cost = point._extraAbility.cost;
            point._passiveName = "Appointment";
            point._enemyDescription = "This enemy will perforn an extra ability \"Appointment\" each turn.";
            point._characterDescription = baseExtra._characterDescription;
            point._triggerOn = baseExtra._triggerOn;

            Ability bonus = new Ability("Appointment_A");
            bonus.Name = "Appointment";
            bonus.Description = "If there is no Opposing party member, queue \"Procedure\" as an additional action next turn.";
            bonus.Effects = new EffectInfo[3];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<IsUnitEffect>(), 1, Slots.Front);
            bonus.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Weep_A", false, Slots.Self), 1, Slots.Front, BasicEffects.DidThat(false));
            bonus.Effects[2] = Effects.GenerateEffect(BasicEffects.SetStoreValue(DoubleExtraAttackPassiveAbility.value), 1, Slots.Self, BasicEffects.DidThat(false, 2));
            bonus.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            bonus.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc_Additional.ToString()]);
            bonus.Visuals = null;
            bonus.AnimationTarget = Slots.Front;
            point._extraAbility.ability = bonus.GenerateEnemyAbility(true).ability;

            Ability bins = new Ability("Procedure_A");
            bins.Name = "Procedure";
            bins.Description = "Move to the Left or Right. Deal an Agonizing amount of damage to the Opposing party member and destroy their held item.";
            bins.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Absolve_1_A", true, Slots.Front)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Slots.Front),
            };
            bins.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);
            bins.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Misc.ToString()]);
            bins.Visuals = null;
            bins.AnimationTarget = Slots.Self;
            bins.Priority = Priority.Slow;
            point._secondExtraAbility.ability = bins.GenerateEnemyAbility(true).ability;


            lobotomy.AddPassives(new BasePassiveAbilitySO[] { point, Passives.Constricting });

            //shocks
            Ability shock = new Ability("ShockTherapy_A")
            {
                Name = "Shock Therapy",
                Description = "Transform the Opposing party member into a random party member. \nIf the Opposing party member has already been transformed by this ability, lower their level and produce 7 coins.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("ynl10", 10),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ShockTherapyEffect>(), 3, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<LobotomySongEffect>(), 0, Slots.Front, BasicEffects.DidThat(true))
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Zap"),
                AnimationTarget = Slots.Front,
            };
            shock.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Misc.ToString()]);
            shock.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc_Currency.ToString()]);

            //illuminate
            Ability illuminate = new Ability("Illuminate")
            {
                Name = "Illuminate",
                Description = "Remove all Status Effects from the Opposing party member. If no Status Effects were removed, inflict 3 Stunned and deal a Painful amount of damage to them.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsByAmountEffect>(), 3, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Front, BasicEffects.DidThat(false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 3, Slots.Front, BasicEffects.DidThat(false, 2)),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Spotlight"),
                AnimationTarget = Slots.Front,
            };
            illuminate.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Status_Stunned.ToString()]);

            //replacement
            Ability replace = new Ability("Replacement_A")
            {
                Name = "Replacement",
                Description = "Apply 3 Power on the Opposing party member. \nIf the Opposing party member has killed during this combat, deal an Agonizing amount of damage to them.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("ynl3", 3),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 3, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ReplacementDamageEffect>(), 8, Slots.Front)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Crush"),
                AnimationTarget = Slots.Front,
            };
            replace.AddIntentsToTarget(Slots.Front, [Power.Intent, IntentType_GameIDs.Damage_7_10.ToString()]);

            //ADD ENEMY
            lobotomy.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                shock.GenerateEnemyAbility(true),
                illuminate.GenerateEnemyAbility(true),
                replace.GenerateEnemyAbility(true)
            });
            lobotomy.AddEnemy(true, true);
        }
    }
}
