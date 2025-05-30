using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static SaltsEnemies_Reseasoned.Orph.H;

namespace SaltsEnemies_Reseasoned
{
    public static class Amalga
    {
        public static void Add()
        {
            Enemy amalga = new Enemy("Amalga", "Amalga_EN")
            {
                Health = 33,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("AmalgaIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("AmalgaWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("AmalgaDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
                UnitTypes = ["Fish", "Bird", "Female_ID"]
            };

            amalga.PrepareMultiEnemyPrefab("Assets/Amalga/Amalga_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Amalga/Amalga_Gibs.prefab").GetComponent<ParticleSystem>());

            (amalga.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                amalga.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Hands").Find("Outline").GetComponent<SpriteRenderer>(),
                amalga.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").Find("Outline").GetComponent<SpriteRenderer>(),
                amalga.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("L_Ear").Find("Outline").GetComponent<SpriteRenderer>(),
                amalga.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("R_Ear").Find("Outine").GetComponent<SpriteRenderer>(),
            };


            //hiding
            AmalgaHandler.Setup();
            PerformEffectPassiveAbility hiding = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            hiding._passiveName = "Hide and Seek";
            hiding.passiveIcon = ResourceLoader.LoadSprite("HidingPassive.png");
            hiding.m_PassiveID = "Hiding_PA";
            hiding._enemyDescription = "On any party member using an ability, move Left or Right.";
            hiding._characterDescription = "On any enemy using an ability, move move Left or Right.";
            hiding.doesPassiveTriggerInformationPanel = true;
            hiding._triggerOn = new TriggerCalls[] { AmalgaHandler.call };
            hiding.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self).SelfArray();

            //seeking
            PerformEffectPassiveAbility seeking = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            seeking._passiveName = "Hide and Seek";
            seeking.passiveIcon = ResourceLoader.LoadSprite("SeekingPassive.png");
            seeking.m_PassiveID = "Seeking_PA";
            seeking._enemyDescription = "On using an ability, move in front of the closest party member.";
            seeking._characterDescription = "idk";
            seeking.doesPassiveTriggerInformationPanel = true;
            seeking._triggerOn = [TriggerCalls.OnAbilityUsed];
            seeking.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToClosestTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false)).SelfArray();

            //focus
            Connection_PerformEffectPassiveAbility focus = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            focus._passiveName = "33";
            focus.passiveIcon = ResourceLoader.LoadSprite("MimicPassive.png");
            focus.m_PassiveID = "33_PA";
            focus._enemyDescription = "On entering combat, gain Focus.";
            focus._characterDescription = focus._enemyDescription;
            focus.doesPassiveTriggerInformationPanel = false;
            focus._triggerOn = [TriggerCalls.Count];
            focus.connectionEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Slots.Self).SelfArray();
            focus.disconnectionEffects = [];

            //bonus attack
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility cannon = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            cannon._passiveName = "33";
            cannon._enemyDescription = "This enemy will perforn the extra ability \"33\" each turn.";
            Ability bonus = new Ability("33_A");
            bonus.Name = "33";
            bonus.Description = "Deal an Deadly amount of damage to the Opposing party member.";
            bonus.Priority = Priority.Fast;
            bonus.Effects = new EffectInfo[1];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 13, Slots.Front);
            bonus.Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bonus.AnimationTarget = Targeting.Slot_Front;
            bonus.AddIntentsToTarget(Targeting.Slot_Front, IntentType_GameIDs.Damage_11_15.ToString().SelfArray());
            AbilitySO ability = bonus.GenerateEnemyAbility(true).ability;
            cannon._extraAbility.ability = ability;

            amalga.AddPassives(new BasePassiveAbilitySO[] { hiding, seeking, focus, cannon });

            AmalgaSongEffect add = ScriptableObject.CreateInstance<AmalgaSongEffect>();
            add.Add = true;
            AmalgaSongEffect remove = ScriptableObject.CreateInstance<AmalgaSongEffect>();
            remove.Add = false;
            amalga.CombatEnterEffects = Effects.GenerateEffect(add).SelfArray();
            amalga.CombatExitEffects = new EffectInfo[]
            {
                Effects.GenerateEffect(remove),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AmalgaDropFishEffect>(), 3)
            };


            EnemyAbilityInfo devour = new EnemyAbilityInfo()
            {
                ability = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemyAbility("Devour_A")),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            devour.ability._abilityName = "33";
            EnemyAbilityInfo nibble = new EnemyAbilityInfo()
            {
                ability = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemyAbility("Nibble_A")),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            nibble.ability._abilityName = "33";
            EnemyAbilityInfo blush = new EnemyAbilityInfo()
            {
                ability = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemyAbility("Blush_A")),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            blush.ability._abilityName = "33";
            EnemyAbilityInfo flail = new EnemyAbilityInfo()
            {
                ability = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemyAbility("Pinano_Flail_A")),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            flail.ability._abilityName = "33";

            //ADD ENEMY
            amalga.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                devour,
                nibble,
                blush,
                flail
            });
            amalga.AddEnemy();


            Add_Alt();
            Add_Fake();
        }
        public static void Add_Alt()
        {
            Enemy amalga = new Enemy("Amalga", "Amalga_Alt_EN")
            {
                Health = 33,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("AmalgaIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("AmalgaWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("AmalgaDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
                UnitTypes = ["Fish", "Bird", "Female_ID"]
            };
            amalga.PrepareMultiEnemyPrefab("Assets/Amalga/Amalga_Alt_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Amalga/Amalga_Gibs.prefab").GetComponent<ParticleSystem>());
            (amalga.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                amalga.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Hands").Find("Outline").GetComponent<SpriteRenderer>(),
                amalga.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").Find("Outline").GetComponent<SpriteRenderer>(),
                amalga.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("L_Ear").Find("Outline").GetComponent<SpriteRenderer>(),
                amalga.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("R_Ear").Find("Outine").GetComponent<SpriteRenderer>(),
            };

            //hiding
            PerformEffectPassiveAbility hiding = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            hiding._passiveName = "Hide and Seek";
            hiding.passiveIcon = ResourceLoader.LoadSprite("HidingPassive.png");
            hiding.m_PassiveID = "Hiding_PA";
            hiding._enemyDescription = "On any party member using an ability, move Left or Right.";
            hiding._characterDescription = "On any enemy using an ability, move move Left or Right.";
            hiding.doesPassiveTriggerInformationPanel = true;
            hiding._triggerOn = new TriggerCalls[] { AmalgaHandler.call };
            hiding.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self).SelfArray();

            //seeking
            PerformEffectPassiveAbility seeking = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            seeking._passiveName = "Hide and Seek";
            seeking.passiveIcon = ResourceLoader.LoadSprite("SeekingPassive.png");
            seeking.m_PassiveID = "Seeking_PA";
            seeking._enemyDescription = "On using an ability, move in front of the closest party member.";
            seeking._characterDescription = "idk";
            seeking.doesPassiveTriggerInformationPanel = true;
            seeking._triggerOn = [TriggerCalls.OnAbilityUsed];
            seeking.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToClosestTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false)).SelfArray();

            //focus
            Connection_PerformEffectPassiveAbility focus = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            focus._passiveName = "33";
            focus.passiveIcon = ResourceLoader.LoadSprite("MimicPassive.png");
            focus.m_PassiveID = "33_PA";
            focus._enemyDescription = "On entering combat, gain Focus.";
            focus._characterDescription = focus._enemyDescription;
            focus.doesPassiveTriggerInformationPanel = false;
            focus._triggerOn = [TriggerCalls.Count];
            focus.connectionEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Slots.Self).SelfArray();
            focus.disconnectionEffects = [];

            //bonus attack
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility cannon = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            cannon._passiveName = "33";
            cannon._enemyDescription = "This enemy will perforn the extra ability \"33\" each turn.";
            Ability bonus = new Ability("33_A");
            bonus.Name = "33";
            bonus.Description = "Deal an Deadly amount of damage to the Opposing party member.";
            bonus.Priority = Priority.Fast;
            bonus.Effects = new EffectInfo[1];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 13, Slots.Front);
            bonus.Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bonus.AnimationTarget = Targeting.Slot_Front;
            bonus.AddIntentsToTarget(Targeting.Slot_Front, IntentType_GameIDs.Damage_11_15.ToString().SelfArray());
            AbilitySO ability = bonus.GenerateEnemyAbility().ability;
            cannon._extraAbility.ability = ability;

            amalga.AddPassives(new BasePassiveAbilitySO[] { hiding, seeking, focus, cannon });

            AmalgaSongEffect add = ScriptableObject.CreateInstance<AmalgaSongEffect>();
            add.Add = true;
            AmalgaSongEffect remove = ScriptableObject.CreateInstance<AmalgaSongEffect>();
            remove.Add = false;
            amalga.CombatEnterEffects = Effects.GenerateEffect(add).SelfArray();
            amalga.CombatExitEffects = new EffectInfo[]
            {
                Effects.GenerateEffect(remove),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AmalgaDropFishEffect>(), 3)
            };

            EnemyAbilityInfo devour = new EnemyAbilityInfo()
            {
                ability = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemyAbility("Devour_A")),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            devour.ability._abilityName = "33";
            EnemyAbilityInfo nibble = new EnemyAbilityInfo()
            {
                ability = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemyAbility("Nibble_A")),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            nibble.ability._abilityName = "33";
            EnemyAbilityInfo blush = new EnemyAbilityInfo()
            {
                ability = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemyAbility("Blush_A")),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            blush.ability._abilityName = "33";
            EnemyAbilityInfo flail = new EnemyAbilityInfo()
            {
                ability = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemyAbility("Pinano_Flail_A")),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            flail.ability._abilityName = "33";

            //ADD ENEMY
            amalga.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                devour,
                nibble,
                blush,
                flail
            });
            amalga.AddEnemy(true, true);
        }
        public static void Add_Fake()
        {
            Enemy wall1 = new Enemy("Wall?", "33_EN")
            {
                Health = 10,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("WallIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WallWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("AmalgaDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound,
                Priority = Priority.GetCustomPriority("wall1")
            };
            //wall1.PrepareEnemyPrefab("assets/enem3/Wall_1_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Wall_Gibs.prefab").GetComponent<ParticleSystem>());
            wall1.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Wall_EN").enemyTemplate;
            wall1.CombatEnterEffects = Effects.GenerateEffect(AmalgaWallConnectionEffect.Create(true)).SelfArray();
            wall1.CombatExitEffects = Effects.GenerateEffect(AmalgaWallConnectionEffect.Create(false)).SelfArray();

            //crush
            EnemyAbilityInfo crush = new EnemyAbilityInfo
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Crush_A"),
                rarity = Rarity.GetCustomRarity("Wall_20")
            };

            //ADD ENEMY
            wall1.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                crush
            });
            wall1.AddEnemy();
        }
    }
}
