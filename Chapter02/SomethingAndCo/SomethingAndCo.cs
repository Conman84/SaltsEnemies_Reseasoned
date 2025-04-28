using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Denial
    {
        public static void Add()
        {
            //Enemy Code
            Enemy Denial = new Enemy("Denial", "Denial_EN")
            {
                Health = 3,
                HealthColor = Pigments.Purple,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority-1"),
                CombatSprite = ResourceLoader.LoadSprite("DenialIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("BubbleDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DenialIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Oisenay/Something_B_Hurt",
                DeathSound = "event:/Hawthorne/Oisenay/Something_B_Die",
            };
            Denial.PrepareEnemyPrefab("assets/Senis2/Something_Denial_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Denial_Gibs.prefab").GetComponent<ParticleSystem>());

            Denial.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Skittish,
                Passives.Withering,
            });

            //A Lie
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;

            Ability lie = new Ability("A Lie", "Salt_ALie_A");
            lie.Description = "Deal a painful amount of damage to the left and right party members.";
            lie.Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity10", 10);
            lie.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<LyingDamageEffect>(), 4, Targeting.Slot_OpponentSides),
            };
            lie.Visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
            lie.AnimationTarget = Targeting.Slot_Front;
            lie.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[]
            {
                "Damage_3_6"
            });

            //Danger
            Ability danger = new Ability("This Is A Very Dangerous Ability", "Salt_ThisIsAVeryDangerousAbility_A");
            danger.Description = "This is a very dangerous ability.";
            danger.Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity12", 12);
            danger.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomAnimEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            danger.Visuals = null;
            danger.AnimationTarget = Targeting.Slot_Front;
            danger.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc"
            });

            //Add
            Denial.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                lie.GenerateEnemyAbility(true),
                danger.GenerateEnemyAbility(true),
            });
            Denial.AddEnemy(true, true, true);
        }
    }
    public static class Derogatory
    {
        public static void Add()
        {
            //Decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.m_PassiveID = "Decay_PA";
            decay.passiveIcon = ResourceLoader.LoadSprite("Decay.png");
            decay._characterDescription = "shouldnt be on a character. idk what it'd do. fuck you up, maybe?";
            decay._enemyDescription = "Upon dying, this enemy has a 33% chance to decay into a Denial.";
            decay.doesPassiveTriggerInformationPanel = true;
            PercentageEffectorCondition decay33P = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            decay33P.triggerPercentage = 33;
            DeathReferenceDetectionEffectorCondition detectWither = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            detectWither._witheringDeath = false;
            detectWither._useWithering = true;
            decay.conditions = new EffectorConditionSO[2]
            {
                decay33P, detectWither
            };
            SpawnEnemyInSlotFromEntryEffect spawnDenial = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryEffect>();
            spawnDenial.enemy = LoadedAssetsHandler.GetEnemy("Denial_EN");
            spawnDenial._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            decay.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(spawnDenial, 0, Targeting.Slot_SelfSlot),
            };
            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };   

            //Enemy Code
            Enemy Derogatory = new Enemy("Derogatory", "Derogatory_EN")
            {
                Health = 3,
                HealthColor = Pigments.Yellow,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority-1"),
                CombatSprite = ResourceLoader.LoadSprite("DerogatoryIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("BubbleDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DerogatoryIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Oisenay/Something_A_Hurt",
                DeathSound = "event:/Hawthorne/Oisenay/Something_A_Die",
            };
            Derogatory.PrepareEnemyPrefab("assets/Senis2/Something_Derogatory_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Derogatory_Gibs.prefab").GetComponent<ParticleSystem>());

            Derogatory.AddPassives(new BasePassiveAbilitySO[]
            {
                decay,
                Passives.Slippery,
                Passives.Withering,
            });

            //Conversation
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;

            Ability convo = new Ability("Conversation", "Salt_Conversation_A");
            convo.Description = "Apply 1 Stunned to the opposing party member. If successful, apply 2 Stunned to self.";
            convo.Rarity = Rarity.GetCustomRarity("rarity10");
            convo.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Ads", false, Targeting.Slot_Front), 1, Targeting.Slot_Front, ScriptableObject.CreateInstance<AnimationsOnEffectCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 1, Targeting.Slot_SelfSlot, ScriptableObject.CreateInstance<AnimationsOffEffectCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 2, Targeting.Slot_SelfSlot, didThat),
            };
            convo.Visuals = null;
            convo.AnimationTarget = Targeting.Slot_SelfSlot;
            convo.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Status_Stunned"
            });
            convo.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Stunned"
            });

            //Add
            Derogatory.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                convo.GenerateEnemyAbility(true),
            });
            Derogatory.AddEnemy(true, true, true);
        }
    }

    public static class Something
    {
        public static void Add()
        {
            //Decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.m_PassiveID = "Decay_PA";
            decay.passiveIcon = ResourceLoader.LoadSprite("Decay.png");
            decay._characterDescription = "shouldnt be on a character. idk what it'd do. fuck you up, maybe?";
            decay._enemyDescription = "Upon dying, this enemy decays into 3-5 Derogatories.";
            decay.doesPassiveTriggerInformationPanel = true;
            SpawnEnemyAnywhereEffect spawnDerogatory = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            spawnDerogatory.enemy = LoadedAssetsHandler.GetEnemy("Derogatory_EN");
            spawnDerogatory._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            decay.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(spawnDerogatory, 3, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(spawnDerogatory, 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)),
                Effects.GenerateEffect(spawnDerogatory, 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(33)),
            };
            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };

            //Enemy Code
            Enemy Something = new Enemy("Something", "Something_EN")
            {
                Health = 35,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("SomethingIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SomethingDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SomethingIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Oisenay/SomethingHurt",
                DeathSound = "event:/Hawthorne/Oisenay/SomethingDie",
            };
            Something.PrepareMultiEnemyPrefab("assets/Senis2/Something_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Gibs.prefab").GetComponent<ParticleSystem>());
            (Something.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                Something.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("body").GetComponent<SpriteRenderer>()
            };

            Something.AddPassives(new BasePassiveAbilitySO[]
            {
                decay,
                Passives.Forgetful,
            });

            //Bore
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            WasteTimeEffect boreTalk = ScriptableObject.CreateInstance<WasteTimeEffect>();
            boreTalk._text = new string[3] { "...", "...", "..." };

            Ability bore = new Ability("Bore", "Salt_Bore_A");
            bore.Description = "Deal a Painful amount of damage to the Opposing Party Member. \nIf no damage is dealt, for all Derogatories in combat remove Withering as a passive and add the extra ability \"Interrupt.\"";
            bore.Rarity = Rarity.GetCustomRarity("rarity10");
            bore.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(boreTalk, 3, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveWitheringFromDerogatoriesEffect >(), 1, Targeting.Slot_SelfSlot, didntThat),
            };
            bore.Visuals = null;
            bore.AnimationTarget = Targeting.Slot_Front;
            bore.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_3_6"
            });
            bore.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc"
            });

            //Affectionate
            Ability affectionate = new Ability("Affectionate", "Salt_Affectionate_A");
            affectionate.Description = "Attempt to spawn a Derogatory.";
            affectionate.Rarity = Rarity.GetCustomRarity("rarity5");
            affectionate.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(spawnDerogatory, 1, Targeting.Slot_SelfSlot),
            };
            affectionate.Visuals = CustomVisuals.GetVisuals("Salt/Think");
            affectionate.AnimationTarget = Targeting.Slot_SelfSlot;
            affectionate.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Other_Spawn"
            });

            //Add
            Something.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                bore.GenerateEnemyAbility(true),
                affectionate.GenerateEnemyAbility(true),
            });
            Something.AddEnemy(true, true, false);
        }
    }
}