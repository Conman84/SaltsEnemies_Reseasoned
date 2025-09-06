using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Smilers
    {
        public static void Add()
        {
            Ability bleed = new Ability("Bleed", "Smiler_Bleed_A");
            bleed.Description = "Inflict 3 Ruptured on the Opposing party member.";
            bleed.Rarity = Rarity.CreateAndAddCustomRarityToPool("smiler_2", 2);
            bleed.Effects = new EffectInfo[1];
            bleed.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, Slots.Front);
            bleed.AddIntentsToTarget(Slots.Front, ["Status_Ruptured"]);
            bleed.Visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals;
            bleed.AnimationTarget = Slots.Front;

            Ability skinning = new Ability("Skinning", "Smiler_Skinning_A");
            skinning.Description = "Inflict 2 Frail on the Left and Right party members.";
            skinning.Rarity = Rarity.GetCustomRarity("smiler_2");
            skinning.Effects = new EffectInfo[1];
            skinning.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Slots.LeftRight);
            skinning.AddIntentsToTarget(Slots.LeftRight, ["Status_Frail"]);
            skinning.Visuals = LoadedAssetsHandler.GetCharacterAbility("Purify_1_A").visuals;
            skinning.AnimationTarget = Slots.LeftRight;

            Ability spectate = new Ability("Spectate", "Smiler_Spectate_A");
            spectate.Description = "Focus this enemy.";
            spectate.Rarity = Rarity.GetCustomRarity("smiler_2");
            spectate.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Slots.Self)];
            spectate.AddIntentsToTarget(Slots.Self, ["Status_Focused"]);
            spectate.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            spectate.AnimationTarget = Slots.Self;

            Ability calcify = new Ability("Calcify", "Smiler_Calcify_A");
            calcify.Description = "Apply 7 Shield to this enemy.";
            calcify.Rarity = Rarity.GetCustomRarity("smiler_2");
            calcify.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 7, Slots.Self)];
            calcify.AddIntentsToTarget(Slots.Self, ["Field_Shield"]);
            calcify.Visuals = LoadedAssetsHandler.GetCharacterAbility("Thorns_1_A").visuals;
            calcify.AnimationTarget = Slots.Self;

            Ability slobber = new Ability("Slobber", "Smiler_Slobber_A");
            slobber.Description = "Inflict 3 Oil-Slicked on the Left and Right party members.";
            slobber.Rarity = Rarity.GetCustomRarity("smiler_2");
            slobber.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, Slots.LeftRight)];
            slobber.AddIntentsToTarget(Slots.LeftRight, ["Status_OilSlicked"]);
            slobber.Visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
            slobber.AnimationTarget = Slots.LeftRight;

            EnemyAbilityInfo[] abilities = [
                bleed.GenerateEnemyAbility(true),
                skinning.GenerateEnemyAbility(true),
                spectate.GenerateEnemyAbility(true),
                calcify.GenerateEnemyAbility(true),
                slobber.GenerateEnemyAbility(true)
                ];

            AddCorpse();

            BasePassiveAbilitySO decay = Passives.DecayGenerator(LoadedAssetsHandler.GetEnemy("Smiler_Corpse_BOSS"));
            decay._enemyDescription = "On death, the Smiler is mortally wounded and dies.";

            Rarity.CreateAndAddCustomRarityToPool("smiler_6", 10);

            AddBlood(abilities, decay);
            AddSkin(abilities, decay);
            AddSaliva(abilities, decay);
            AddBone(abilities, decay);
            AddEyes(abilities, decay);

        }
        public static void AddCorpse()
        {
            Enemy template = new Enemy("Corpse", "Smiler_Corpse_BOSS")
            {
                Health = 20,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Dying, Passives.Withering });

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
            });
            template.AddEnemy(true);
        }
        public static void AddBlood(EnemyAbilityInfo[] baseAbil, BasePassiveAbilitySO decay)
        {
            Enemy template = new Enemy("Smiler of Blood", "Smiler1_BOSS")
            {
                Health = 20,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Unstable, Passives.Skittish, decay });

            Ability custom = new Ability("Bloody Mess", "Smiler_RuptureSpecial_A");
            custom.Description = "If the Opposing party member is Ruptured, deal a Painful amount of damage to them.";
            custom.Rarity = Rarity.GetCustomRarity("smiler_6");
            custom.Effects = new EffectInfo[2];
            StatusEffectCheckerEffect hasStatus = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            hasStatus._status = StatusField.Ruptured;
            custom.Effects[0] = Effects.GenerateEffect(hasStatus, 0, Slots.Front);
            custom.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Front, BasicEffects.DidThat(true));
            custom.AddIntentsToTarget(Slots.Front, ["Misc", "Damage_3_6"]);
            custom.Visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
            custom.AnimationTarget = Slots.Front;

            //ADD ENEMY
            template.AddEnemyAbilities(baseAbil);
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                custom.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true);
        }
        public static void AddSkin(EnemyAbilityInfo[] baseAbil, BasePassiveAbilitySO decay)
        {
            Enemy template = new Enemy("Smiler of Skin", "Smiler2_BOSS")
            {
                Health = 20,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Unstable, Passives.Skittish, decay });

            Ability custom = new Ability("Skinned Mess", "Smiler_FrailSpecial_A");
            custom.Description = "If the Opposing party member is Frailed, remove Frail and inflict 4 Oil-Slicked and 4 Ruptured on them.";
            custom.Rarity = Rarity.GetCustomRarity("smiler_6");
            custom.Effects = new EffectInfo[4];
            StatusEffectCheckerEffect hasStatus = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            hasStatus._status = StatusField.Frail;
            custom.Effects[0] = Effects.GenerateEffect(hasStatus, 0, Slots.Front);
            RemoveStatusEffectEffect remFrail = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            remFrail._status = StatusField.Frail;
            custom.Effects[1] = Effects.GenerateEffect(remFrail, 1, Slots.Front, BasicEffects.DidThat(true));
            custom.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, Slots.Front, BasicEffects.DidThat(true, 2));
            custom.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 4, Slots.Front, BasicEffects.DidThat(true, 3));
            custom.AddIntentsToTarget(Slots.Front, ["Misc", IntentType_GameIDs.Rem_Status_Frail.ToString(), "Status_OilSlicked", "Status_Ruptured"]);
            custom.Visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
            custom.AnimationTarget = Slots.Front;

            //ADD ENEMY
            template.AddEnemyAbilities(baseAbil);
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                custom.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true);
        }
        public static void AddSaliva(EnemyAbilityInfo[] baseAbil, BasePassiveAbilitySO decay)
        {
            Enemy template = new Enemy("Smiler of Saliva", "Smiler3_BOSS")
            {
                Health = 20,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Unstable, Passives.Skittish, decay });

            Ability custom = new Ability("Drooling Mess", "Smiler_OilSpecial_A");
            custom.Description = "If either the Left or Right party members have Oil-Slicked, deal a Little damage to them both.";
            custom.Rarity = Rarity.GetCustomRarity("smiler_6");
            custom.Effects = new EffectInfo[2];
            StatusEffectCheckerEffect hasStatus = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            hasStatus._status = StatusField.OilSlicked;
            hasStatus._allTargetsHaveStatusEffect = false;
            custom.Effects[0] = Effects.GenerateEffect(hasStatus, 0, Slots.LeftRight);
            custom.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.LeftRight, BasicEffects.DidThat(true));
            custom.AddIntentsToTarget(Slots.LeftRight, ["Misc", "Damage_1_2"]);
            custom.Visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
            custom.AnimationTarget = Slots.Front;

            //ADD ENEMY
            template.AddEnemyAbilities(baseAbil);
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                custom.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true);
        }
        public static void AddBone(EnemyAbilityInfo[] baseAbil, BasePassiveAbilitySO decay)
        {
            Enemy template = new Enemy("Smiler of Bone", "Smiler4_BOSS")
            {
                Health = 20,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Unstable, Passives.Skittish, decay });

            Ability custom = new Ability("Skeletal Mess", "Smiler_ShieldSpecial_A");
            custom.Description = "If this enemy is in Shield, deal a Painful amount of damage to the Opposing party member.";
            custom.Rarity = Rarity.GetCustomRarity("smiler_6");
            custom.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front, HasFieldAmountEffectCondition.Create("Shield_ID", 0, true, true))];
            custom.AddIntentsToTarget(Slots.Self, ["Misc"]);
            custom.AddIntentsToTarget(Slots.Front, ["Damage_3_6"]);
            custom.Visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
            custom.AnimationTarget = Slots.Front;

            //ADD ENEMY
            template.AddEnemyAbilities(baseAbil);
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                custom.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true);
        }
        public static void AddEyes(EnemyAbilityInfo[] baseAbil, BasePassiveAbilitySO decay)
        {
            Enemy template = new Enemy("Smiler of Eyes", "Smiler5_BOSS")
            {
                Health = 20,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Unstable, Passives.Skittish, decay });

            Ability custom = new Ability("Self-Conscious Mess", "Smiler_FocusedSpecial_A");
            custom.Description = "Give all enemies with Focused an extra action.";
            custom.Rarity = Rarity.GetCustomRarity("smiler_6");
            AddTurnIfStatusEffect actions = ScriptableObject.CreateInstance<AddTurnIfStatusEffect>();
            actions.Status = "Focused_ID";
            custom.Effects = [Effects.GenerateEffect(actions, 1, Targeting.Unit_AllAllies)];
            custom.AddIntentsToTarget(Targeting.Unit_AllAllies, [IntentType_GameIDs.Misc_Additional.ToString()]);
            custom.Visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
            custom.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(baseAbil);
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                custom.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true);
        }
    }
}
