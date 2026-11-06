using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Vivarium
    {
        public static void Add()
        {
            Enemy vivarium = new Enemy("Vivarium Hypothesis", "Vivarium_EN")
            {
                Health = 37,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("VivariumIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("VivariumEmptyWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("VivariumEmptyWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy(Spoggle.Red).damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy(Spoggle.Red).deathSound,
            };
            vivarium.PrepareEnemyPrefab("Assets/ch_26/Vivarium_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/ch_26/Vivarium_Gibs.prefab").GetComponent<ParticleSystem>());

            BasePassiveAbilitySO multi0 = Passives.MultiAttackGenerator(0);
            multi0.name = "Nonomnumuburamuma_PA";
            multi0.m_PassiveID = "Nonomnumuburamuma_PA";
            multi0._passiveName = "Nonomnumuburamuma";
            multi0._locID = "";
            multi0._enemyDescription = "This enemy will perform 0 actions each turn by default.";
            multi0.passiveIcon = ResourceLoader.LoadSprite("NonomnumuburamumaPassive.png");

            //FLITHERING
            PerformEffectPassiveAbility flither = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            flither._passiveName = "Flithering";
            flither.passiveIcon = ResourceLoader.LoadSprite("FlitheringIcon.png");
            flither.m_PassiveID = FlitheringHandler.Flithering;
            flither._enemyDescription = "On any enemy dying, if there are no other enemies without \"Withering\" or \"Flithering\" as passives, instantly flee.\n" +
                "At the start and end of the enemies' turn, if there are no other enemies without \"Cowardice\" or \"Flithering\" as passives, instantly flee.";
            flither._characterDescription = "doesnt work";
            flither.doesPassiveTriggerInformationPanel = false;
            flither.effects = new EffectInfo[] { Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CowardEffect>(), 1, Slots.Self)
            }), 1, Slots.Self) };
            flither._triggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy, TriggerCalls.OnRoundFinished };
            flither.conditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<CowardCondition>()
            };

            AnyOtherAllyDamagedHandler.Setup();
            PerformEffectPassiveAbility Apostle = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Apostle.name = "Apostle_PA";
            Apostle._passiveName = "Apostle";
            Apostle.passiveIcon = ResourceLoader.LoadSprite("ApostlePassive.png");
            Apostle._enemyDescription = "On any other enemy being directly damaged, prematurely perform this enemy's next action on the timeline.";
            //ch desc
            Apostle.m_PassiveID = "Apostle_PA";
            Apostle.doesPassiveTriggerInformationPanel = true;
            Apostle._triggerOn = [AnyOtherAllyDamagedHandler.Trigger];
            Apostle.effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetForceFirstActionEffect>(), 1, Slots.Self),
                ];
            Apostle.conditions = [ScriptableObject.CreateInstance<HasTurnsCondition>()];
            Apostle.AddToPassiveDatabase();

            vivarium.AddPassives(new BasePassiveAbilitySO[] { multi0, flither, Passives.Masochism1, Apostle });
            vivarium.CombatEnterEffects = Effects.GenerateEffect(VivariumConnectionEffect.Create(true)).SelfArray();
            vivarium.CombatExitEffects = Effects.GenerateEffect(VivariumConnectionEffect.Create(false)).SelfArray();

            TargettingByHealthUnitsStatus dpHigh = ScriptableObject.CreateInstance<TargettingByHealthUnitsStatus>();
            dpHigh.getAllies = false;
            dpHigh.Lowest = false;
            dpHigh.Status = StatusField_GameIDs.DivineProtection_ID.ToString();
            dpHigh.shouldHave = false;
            dpHigh._randomOne = true;

            StatusEffectCheckerEffect all_dp = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            all_dp._status = StatusField.DivineProtection;
            all_dp._allTargetsHaveStatusEffect = true;

            RefreshAbilityUseEffect exhaust = ScriptableObject.CreateInstance<RefreshAbilityUseEffect>();
            exhaust._doesExhaustInstead = true;

            Ability torii = new Ability("God_Torii_A");
            torii.Name = "Torii";
            torii.Description = "If the Opposing party member is not Divinely Protected, Divinely Protect them and exhaust their ability usage.\nOtherwise, deal an Agonizing amount of damage to them.";
            torii.Rarity = Rarity.GetCustomRarity("rarity5");
            torii.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionIfNoneEffect>(), 3, Slots.Front),
                Effects.GenerateEffect(exhaust, 1, Slots.Front, BasicEffects.DidThat(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, BasicEffects.DidThat(false))
                ];
            torii.AddIntentsToTarget(Slots.Front, ["Status_DivineProtection", "Misc", "Damage_7_10"]);
            torii.AnimationTarget = Slots.Front;
            torii.Visuals = CustomVisuals.GetVisuals("Salt/Door");

            Ability beta = new Ability("God_ApotheosisBeta_A");
            beta.Name = "Apotheosis Beta";
            beta.Description = "Divinely Protect and exhaust the ability usage of the highest health party member without Divine Protection.";
            beta.Rarity = torii.Rarity;
            beta.Effects = [
                Effects.GenerateEffect(exhaust, 1, dpHigh),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, dpHigh)
                ];
            beta.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            beta.AddIntentsToTarget(dpHigh, ["Status_DivineProtection"]);
            beta.AnimationTarget = Slots.Self;
            beta.Visuals = CustomVisuals.GetVisuals("Salt/Think");

            Ability rome = new Ability("God_AllRoads_A");
            rome.Name = "All Roads Lead to Rome";
            rome.Description = "Divinely Protect the Left, Right, and Opposing party members if they are not already Divinely Protected.\nIf all party members are Divinely Protected, randomly shuffle all party member positions.";
            rome.Rarity = torii.Rarity;
            rome.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionIfNoneEffect>(), 3, Slots.FrontLeftRight),
                Effects.GenerateEffect(all_dp, 1, Targeting.Unit_AllOpponents),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, Targetting.Everything(false), BasicEffects.DidThat(true))
                ];
            rome.AddIntentsToTarget(Slots.FrontLeftRight, ["Status_DivineProtection"]);
            rome.AddIntentsToTarget(Targetting.Everything(false), ["Swap_Mass"]);
            rome.AnimationTarget = Slots.Self;
            rome.Visuals = CustomVisuals.GetVisuals("Salt/Ribbon");

            ApplyDivineProtectionIfNoneEffect onlyone = ScriptableObject.CreateInstance<ApplyDivineProtectionIfNoneEffect>();
            onlyone._JustOneRandomTarget = true;

            Ability samsara = new Ability("God_SawSamsara_A");
            samsara.Name = "I Saw Samsara In My Dreams";
            samsara.Description = "Divinely Protect a random non-Divinely Protected party member.\nIf it is currently the Player's turn, queue another action on the timeline.\n\"And It Was Horrible.\"";
            samsara.Rarity = torii.Rarity;
            samsara.Effects = [
                Effects.GenerateEffect(onlyone, 3, Targeting.Unit_AllOpponents),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsPlayerTurnEffectCondition>())
                ];
            samsara.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Status_DivineProtection"]);
            samsara.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc_Additional.ToString()]);
            samsara.AnimationTarget = Slots.Self;
            samsara.Visuals = CustomVisuals.GetVisuals("Salt/Pop");


            //ADD ENEMY
            vivarium.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                torii.GenerateEnemyAbility(true),
                beta.GenerateEnemyAbility(true),
                rome.GenerateEnemyAbility(true),
                samsara.GenerateEnemyAbility(true),
            });
            vivarium.AddEnemy(true, true, true);
            vivarium.enemy.AddToEcstasyPool();
            vivarium.enemy.AddToToysPool();
        }
    }
}
