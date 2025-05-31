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
        public static GameObject Tree;
        public static GameObject Bush;
        public static void Add()
        {
            Enemy vase = new Enemy("Ode to Humanity", "OdeToHumanity_EN")
            {
                Health = 40,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("VaseIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("VaseWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("VaseDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Combat/StatusEffects/SE_Cursed_Apl",
                DeathSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound,
            };
            vase.PrepareMultiEnemyPrefab("assets/16/Vase_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/16/Vase_Gibs.prefab").GetComponent<ParticleSystem>());
            (vase.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Mouth").GetComponent<SpriteRenderer>(),
                vase.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Eyes1_1").GetComponent<SpriteRenderer>(),
            };
            Tree = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/16/Vase_Tree.prefab");
            Bush = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/16/Vase_Bush.prefab");
            OdeFieldHandler.Setup();

            //prefab trigger: "Color"

            //weakness
            WeaknessHandler.Setup();
            PerformEffectPassiveAbility weakness = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            weakness._passiveName = "Weakness";
            weakness.passiveIcon = ResourceLoader.LoadSprite("WeaknessPassive.png");
            weakness.m_PassiveID = WeaknessHandler.Passive;
            weakness._enemyDescription = "All party members and enemies without \"Weakness\" as a passive who share this enemy's health color receive double damage.";
            weakness._characterDescription = "All party members and enemies without \"Weakness\" as a passive who share this party member's health color receive double damage.";
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

            vase.AddPassives(new BasePassiveAbilitySO[] { weakness, rewrite, Passives.Transfusion, Passives.Skittish });
            vase.CombatEnterEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<OdeEnterEffect>()).SelfArray();

            Ability colors = new Ability("Remember Colors", "RememberColors_A");
            colors.Description = "Change this enemy's health color to match the Opposing party member's health color.\nCurse all units with a health color not matching this enemy's.";
            colors.Rarity = Rarity.GetCustomRarity("rarity5");
            colors.Effects = new EffectInfo[2];
            colors.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterChangeHealthColorForTargetEffect>(), 0, Slots.Front);
            colors.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<CurseAllNotSelfColorEffect>(), 1, Targeting.AllUnits);
            colors.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            colors.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Modify.ToString()]);
            colors.AddIntentsToTarget(Targeting.AllUnits, [IntentType_GameIDs.Status_Cursed.ToString()]);
            colors.Visuals = CustomVisuals.GetVisuals("Salt/Rose");
            colors.AnimationTarget = Slots.Self;


            RemoveStatusEffectEffect remCurse = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remCurse._status = StatusField.Cursed;

            Ability holdhands = new Ability("Hold Hands", "HoldHands_A");
            holdhands.Description = "Attempt to remove Cursed from the Opposing party member. If successful, inflict 3 Frail on them.\nOtherwise, deal an Agonizing amount of damage to the Opposing party member.";
            holdhands.Rarity = Rarity.GetCustomRarity("rarity5");
            holdhands.Effects = new EffectInfo[3];
            holdhands.Effects[0] = Effects.GenerateEffect(remCurse, 1, Slots.Front);
            holdhands.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, Slots.Front, BasicEffects.DidThat(true));
            holdhands.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, BasicEffects.DidThat(false, 2));
            holdhands.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Rem_Status_Cursed.ToString(), IntentType_GameIDs.Status_Frail.ToString(), IntentType_GameIDs.Damage_7_10.ToString()]);
            holdhands.Visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals;
            holdhands.AnimationTarget = Slots.Front;

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
            yourvoice.Description = "Apply Inspiration on the Opposing party member and deal a Little damage to them.";
            yourvoice.Rarity = Rarity.GetCustomRarity("rarity5");
            yourvoice.Effects = new EffectInfo[2];
            yourvoice.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyInspirationEffect>(), 1, Slots.Front);
            yourvoice.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front);
            yourvoice.AddIntentsToTarget(Slots.Front, [Inspiration.Intent, IntentType_GameIDs.Damage_1_2.ToString()]);
            yourvoice.Visuals = CustomVisuals.GetVisuals("Salt/Whisper");
            yourvoice.AnimationTarget = Slots.Front;

            //ADD ENEMY
            vase.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                holdhands.GenerateEnemyAbility(true),
                colors.GenerateEnemyAbility(true),
                yourvoice.GenerateEnemyAbility(true),
            });
            vase.AddEnemy(true, true);
        }
    }
}
