using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class ILoveYou
    {
        public static void Add()
        {
            Enemy lullaby = new Enemy("ILOVEYOU", "ILoveYou_EN")
            {
                Health = 35,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("LullabyIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("LullabyWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("LullabyDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Keko_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Keko_EN").deathSound,
                UnitTypes = ["FemaleID", "FemaleLooking"]
            };
            lullaby.PrepareLullabyEnemyPrefab("Assets/ch_26/Lullaby_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/ch_26/Lullaby_Gibs.prefab").GetComponent<ParticleSystem>());

            //autoidact
            PerformEffectPassiveAbility auto = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            auto._passiveName = "Autodidact";
            auto.name = "Autodidact_PA";
            auto.passiveIcon = ResourceLoader.LoadSprite("AutodidactPassive.png");
            auto.m_PassiveID = "Autodidact_PA";
            auto._enemyDescription = "At the end of the Player's turn, reroll all of this enemy's abilities.";
            auto._characterDescription = "wont work lol";
            auto.conditions = [];
            auto.doesPassiveTriggerInformationPanel = true;
            auto.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ReRollAllTargetTimelineAbilityEffect>(), 1, Slots.Self)];
            auto._triggerOn = [TriggerCalls.OnPlayerTurnEnd_ForEnemy];
            //box
            PerformEffectPassiveAbility box = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            box._passiveName = "Curio";
            box.m_PassiveID = "Curio_PA";
            box.passiveIcon = ResourceLoader.LoadSprite("BoxPassive.png");
            box._enemyDescription = "When the Player's mouse is not hovering over this enemy, it becomes more aggressive and will attempt to perform its next ability in the timeline.";
            box._characterDescription = "Wont do jackshit";
            box.doesPassiveTriggerInformationPanel = true;
            box.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetForceFirstActionEffect>(), 1, Slots.Self).SelfArray();
            box._triggerOn = new TriggerCalls[] { MouseHover_EnemyInFieldLayout.Trigger };
            box.conditions = [ScriptableObject.CreateInstance<HasTurnsCondition>(), ScriptableObject.CreateInstance<IsPlayerTurnEffectorCondition>()];
            //fantastic
            PerformEffectPassiveAbility fantastic = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fantastic._passiveName = "Fantastic (2)";
            fantastic.name = "Fantastic_2_PA";
            fantastic.passiveIcon = ResourceLoader.LoadSprite("PassiveFantastic.png");
            fantastic.m_PassiveID = "Fantastic_PA";
            fantastic._enemyDescription = "On being directly damaged, gain 2 Dodge.";
            fantastic._characterDescription = "On being directly damaged, gain 2 Dodge.";
            fantastic.doesPassiveTriggerInformationPanel = true;
            fantastic.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 2, Slots.Self).SelfArray();
            fantastic._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
            fantastic.AddToPassiveDatabase();

            lullaby.AddPassives(new BasePassiveAbilitySO[] { auto, box, fantastic, Passives.Fleeting6 });


            AnimationVisualsEffect front = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            front._animationTarget = Slots.Front;
            front._visuals = Visuals.Intrusion;
            

            //punish
            Ability punish = new Ability("Lullaby_PUNISHMENT_A")
            {
                Name = "PUNISHMENT",
                Description = "Move Left, Right, or Stay in place. Deal an Agonizing amount of damage to the Opposing party member.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Lullaby_High", 99),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self, Effects.ChanceCondition(60)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<StopMusicEffect>(), 0, Slots.Self, CheckSpecificSongEffectCondition.Create("event:/Hawthorne/ILoveYouTheme")),
                    Effects.GenerateEffect(front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front),
                    Effects.GenerateEffect(OverrideMusicEffect.Create("event:/Hawthorne/ILoveYou2Theme"), 0, Slots.Self, BasicEffects.DidThat(true, 3))
                },
                Visuals = null,
                AnimationTarget = Slots.Front,
            };
            punish.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            punish.AddIntentsToTarget(Slots.Front, ["Damage_7_10"]);

            

            //eat
            Ability eat = new Ability("Lullaby_EAT_A")
            {
                Name = "Are You Gonna Eat That?",
                Description = "Inflict 3 Frail and 3 Oil-Slicked on the Left, Right, and Opposing party members.\nConsume all pigment not of this enemy's health color.\nRandomize this enemy's health color.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, Slots.FrontLeftRight),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, Slots.FrontLeftRight),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomButCasterHealthManaEffect>(), 10, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeTargetHealthColorEffect>(), 0, Slots.Self)

                },
                Visuals = Visuals.Gulp,
                AnimationTarget = Slots.FrontLeftRight,
            };
            eat.AddIntentsToTarget(Slots.FrontLeftRight, ["Status_Frail", "Status_OilSlicked"]);
            eat.AddIntentsToTarget(Slots.Self, ["Mana_Consume", "Mana_Modify"]);



            //reward
            Ability reward = new Ability("Lullaby_REWARD_A")
            {
                Name = "REWARD",
                Description = "Inflict 3 Oil-Slicked on this enemy and bleed 3 Red Pigment.\nRandomize the health colors of the Left and Right enemies to not match this enemy's health color.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 3, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeTargetHealthColorsNotCasterEffect>(), 0, Slots.Sides),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Gaze"),
                AnimationTarget = Slots.Self,
            };
            reward.AddIntentsToTarget(Slots.Self, ["Status_OilSlicked", "Mana_Generate"]);
            reward.AddIntentsToTarget(Slots.Sides, ["Mana_Modify"]);


            //ADD ENEMY
            lullaby.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                punish.GenerateEnemyAbility(true),
                eat.GenerateEnemyAbility(true),
                reward.GenerateEnemyAbility(true),
            });
            lullaby.SilentAddEnemy(true, true);//SILENT!!
            lullaby.enemy.AddToToysPool();
            lullaby.enemy.AddToEcstasyPool();
        }
    }
}
