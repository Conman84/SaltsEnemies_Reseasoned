using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace SaltsEnemies_Reseasoned
{
    public static class PersonalAngel
    {
        public static void Add()
        {
            Enemy devil = new Enemy("Personal Angel", "PersonalAngel_EN")
            {
                Health = 42,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("PersonalIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PersonalWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PersonalDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noisy/PA_Hit",
                DeathSound = "event:/Hawthorne/Noisy/PA_Die",
            };
            devil.PrepareEnemyPrefab("assets/enemie/Personal_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/Personal_Gibs.prefab").GetComponent<ParticleSystem>());

            //punisher
            PerformEffectImmediaterPassiveAbility punish = ScriptableObject.CreateInstance<PerformEffectImmediaterPassiveAbility>();
            punish._passiveName = "Punisher (7)";
            punish.m_PassiveID = "Punisher_PA";
            punish.passiveIcon = ResourceLoader.LoadSprite("PunisherPassive.png");
            punish._enemyDescription = "On moving, 7 Pale comes for the Opposing party member. \nIf they already had over 100 Pale, it takes them.";
            punish._characterDescription = punish._enemyDescription;
            punish.doesPassiveTriggerInformationPanel = true;
            punish.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<TryTriggerPaleEffect>(), 1, Slots.Front), Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 7, Slots.Front, BasicEffects.DidThat(false)), };
            punish._triggerOn = new TriggerCalls[1] { TriggerCalls.OnMoved };
            punish.conditions = [ScriptableObject.CreateInstance<FrontExistEffectorCondition>()];

            //judgement
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility judgement = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            judgement._passiveName = "Judgement";
            judgement._enemyDescription = "This enemy will peform the extra ability \"Judgement\" each turn.";
            Ability bonus = new Ability("Punisher_Judgement_A");
            bonus.Name = "Judgement";
            bonus.Description = "10 Pale comes for every party member.";
            bonus.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 10, Targetting.Everything(false)).SelfArray();
            bonus.AddIntentsToTarget(Targetting.Everything(false), [Pale.Intent]);
            bonus.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            bonus.AnimationTarget = Targetting.Everything(false);
            bonus.Rarity = Rarity.GetCustomRarity("sniper_0");
            AbilitySO ability = bonus.GenerateEnemyAbility(true).ability;
            judgement._extraAbility.ability = ability;

            //add the pasis
            devil.AddPassives(new BasePassiveAbilitySO[] { Passives.SlipperyGenerator(2), punish, Passives.Forgetful });
            devil.UnitTypes = new List<string> { "FemaleID", "Angel" };

            //heaven
            MoveToClosestTargetEffect imm = ScriptableObject.CreateInstance<MoveToClosestTargetEffect>();
            imm.Immediate = true;
            Ability heaven = new Ability("GatesOfHeaven_A")
            {
                Name = "Gates of Heaven",
                Description = "10 Pale comes for every party member.\nMove in front of the nearest party member.",
                Rarity = Rarity.Common,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleByTenEffect>(), 1, Targeting.Unit_AllOpponents),
                    Effects.GenerateEffect(imm, 1, Slots.SlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                },
                Visuals = Visuals.UglyOnTheInside,
                AnimationTarget = Targetting.Everything(false),
            };
            heaven.AddIntentsToTarget(Targetting.Everything(false), [Pale.Intent]);
            heaven.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);

            //hell
            Ability hell = new Ability("CirclesOfHell_A")
            {
                Name = "Circles of Hell",
                Description = "50 Pale comes for the Opposing party member.",
                Rarity = Rarity.Uncommon,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleByTenEffect>(), 5, Slots.Front)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Curse"),
                AnimationTarget = Slots.Front,
            };
            hell.AddIntentsToTarget(Slots.Front, [Pale.Intent]);

            //ADD ENEMY
            devil.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                heaven.GenerateEnemyAbility(true),
                hell.GenerateEnemyAbility(true),
            });
            devil.AddEnemy(true, true);
            devil.enemy.AddToSynodPool();
            devil.enemy.AddToEcstasyPool();
        }
    }
}
