using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class OdeToHumanity
    {
        public static void Add()
        {
            Enemy vase = new Enemy("Ode to Humanity", "OdeToHumanity_EN")
            {
                Health = 40,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("VaseIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("VaseWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("VaseDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Combat/StatusEffects/SE_Cursed_Apl",
                DeathSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound,
            };
            vase.PrepareMultiEnemyPrefab("assets/16/Vase_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/16/Vase_Gibs.prefab").GetComponent<ParticleSystem>());
            (vase.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Mouth").GetComponent<SpriteRenderer>(),
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Eyes1_1").GetComponent<SpriteRenderer>(),
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Rotator").Find("Eyes2_2").GetComponent<SpriteRenderer>(),
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Rotator").Find("Eyes2_1").GetComponent<SpriteRenderer>(),
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Rotator").Find("Eyes3_2").GetComponent<SpriteRenderer>(),
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Rotator").Find("Eyes3_1").GetComponent<SpriteRenderer>(),
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Rotator").Find("Eyes4_2").GetComponent<SpriteRenderer>(),
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Rotator").Find("Eyes4_1").GetComponent<SpriteRenderer>(),
            };

            //weakness
            WeaknessHandler.Setup();
            PerformEffectPassiveAbility weakness = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            weakness._passiveName = "Weakness";
            weakness.passiveIcon = ResourceLoader.LoadSprite("WeaknessPassive.png");
            weakness.m_PassiveID = WeaknessHandler.Passive;
            weakness._enemyDescription = "All party members and enemies without \"Weakness\" as a passive who share this enemy's health color receive 2x damage.";
            weakness._characterDescription = "All party members and enemies without \"Weakness\" as a passive who share this party member's health color receive 2x damage.";
            weakness.effects = [];
            weakness.doesPassiveTriggerInformationPanel = false;
            weakness._triggerOn = [TriggerCalls.Count];

            PerformEffectPassiveAbility rewrite = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            rewrite._passiveName = "Rewrite";
            rewrite.passiveIcon = ResourceLoader.LoadSprite("RewritePassive.png");
            rewrite.m_PassiveID = "Rewrite_PA";
            rewrite._enemyDescription = "On receiving direct damage, randomize the health colors of all party members and enemies.";
            rewrite._characterDescription = rewrite._enemyDescription;
            rewrite.conditions = Passives.Slippery.conditions;
            rewrite.doesPassiveTriggerInformationPanel = true;
            rewrite.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeTargetHealthColorEffect>(), 1, Targeting.AllUnits).SelfArray();
            rewrite._triggerOn = [TriggerCalls.OnDirectDamaged];

            vase.AddPassives(new BasePassiveAbilitySO[] { weakness, rewrite, Passives.Transfusion });

            Ability colors = new Ability("Remember Colors", "RememberColors_A");
            colors.Description = "Produce 2 Pigment of every primary color.";
            colors.Rarity = Rarity.GetCustomRarity("rarity5");
            colors.Effects = new EffectInfo[4];
            colors.Effects[0] = Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 2, Slots.Self);
            colors.Effects[1] = Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Blue), 2, Slots.Self);
            colors.Effects[2] = Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Yellow), 2, Slots.Self);
            colors.Effects[3] = Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Purple), 2, Slots.Self);
            colors.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Generate.ToString()]);
            colors.Visuals = CustomVisuals.GetVisuals("Salt/Rose");
            colors.AnimationTarget = Slots.Self;

            Ability holdhands = new Ability("Hold Hands", "HoldHands_A");
            holdhands.Description = "Deal a Barely Painful amount of damage to the Opposing party member and change their health color to this enemy's. \nMove this enemy to the Left or Right.";
            holdhands.Rarity = Rarity.GetCustomRarity("rarity5");
            holdhands.Effects = new EffectInfo[3];
            holdhands.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Front);
            holdhands.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeHealthColorByCasterColorEffect>(), 1, Slots.Front);
            holdhands.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            holdhands.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Mana_Modify.ToString()]);
            holdhands.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);
            holdhands.Visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals;
            holdhands.AnimationTarget = Slots.Self;

            Ability lockfingers = new Ability("Lock Fingers", "LockFingers_A");
            lockfingers.Description = "Move to the Left or Right, then deal a Barely Painful amount of damage to the Opposing party member and change their health color to this enemy's.";
            lockfingers.Rarity = Rarity.GetCustomRarity("rarity5");
            lockfingers.Effects = new EffectInfo[4];
            lockfingers.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            lockfingers.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Weave_1_A", true, Slots.Front));
            lockfingers.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Front);
            lockfingers.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeHealthColorByCasterColorEffect>(), 1, Slots.Front);
            lockfingers.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);
            lockfingers.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Mana_Modify.ToString()]);
            lockfingers.Visuals = null;
            lockfingers.AnimationTarget = Slots.Self;

            Ability yourvoice = new Ability("Your Voice", "YourVoice_A");
            yourvoice.Description = "Deal almost no damage to this enemy.";
            yourvoice.Rarity = Rarity.GetCustomRarity("rarity5");
            yourvoice.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Slots.Self).SelfArray();
            yourvoice.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_1_2.ToString()]);
            yourvoice.Visuals = CustomVisuals.GetVisuals("Salt/Whisper");
            yourvoice.AnimationTarget = Slots.Self;

            //ADD ENEMY
            vase.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                holdhands.GenerateEnemyAbility(true),
                colors.GenerateEnemyAbility(true),
                lockfingers.GenerateEnemyAbility(true),
                yourvoice.GenerateEnemyAbility(true),
            });
            vase.AddEnemy(true, true);
        }
    }
}
