using BrutalAPI;
using HarmonyLib;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.EventSystems.EventTrigger;


namespace SaltsEnemies_Reseasoned
{
    public class Enigma
    {
        public static void Add()
        {
            //Enemy Code
            Enemy Enigma = new Enemy("Enigma", "Enigma_EN")
            {
                Health = 13,
                HealthColor = Pigments.Purple,
                Priority = BrutalAPI.Priority.CreateAndAddCustomPriorityToPool("priority0", 0),
                CombatSprite = ResourceLoader.LoadSprite("enigma_iconb.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("enigma_dead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("enigma_icon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Surround/EnigmaHurt",
                DeathSound = "event:/Hawthorne/Surround/EnigmaDie",
            };
            Enigma.PrepareEnemyPrefab("assets/PissShitFartCum/FalseTruth_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/FalseTruth_Gibs.prefab").GetComponent<ParticleSystem>());

            Enigma.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Unstable,
                Passives.Skittish,
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1]
            });

            /* SUPERBOSS DROP - DO WHEN READY
            gone.exitEffects = new Effect[1]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<LockedBoxEffect>(), 1, new IntentType?(), Slots.Self, Conditions.Chance(4))
            };
            */

            //Terrorize
            AnimationVisualsEffect talons = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons._animationTarget = Targeting.GenerateSlotTarget(new int[] { 1, -4 }, false);
            talons._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            AnimationVisualsEffect talons2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons2._animationTarget = Targeting.GenerateSlotTarget(new int[] { -1, 4 }, false);
            talons2._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            PreviousEffectCondition didnt2That = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didnt2That.wasSuccessful = false;
            didnt2That.previousAmount = 2;

            Rarity.CreateAndAddCustomRarityToPool("rarity3", 3);

            Ability terrorize = new Ability("Terrorize", "Salt_Terrorize_A");
            terrorize.Description = "Deal a Painful amount of damage to either the Left or Right party members.\nThis ability assumes the grid loops around.";
            terrorize.Rarity = Rarity.CreateAndAddCustomRarityToPool("enigma5", 5);
            terrorize.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(talons, 1, Targeting.GenerateSlotTarget(new int[]{1, -4}, false), Effects.ChanceCondition(50)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.GenerateSlotTarget(new int[]{1, -4}, false), didThat),
                Effects.GenerateEffect(talons2, 1, Targeting.GenerateSlotTarget(new int[]{-1, 4}, false), didnt2That),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.GenerateSlotTarget(new int[]{-1, 4}, false), didThat),
            };
            terrorize.Visuals = null;
            terrorize.AnimationTarget = Targeting.Slot_SelfSlot;
            terrorize.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { 4, 1, -1, -4 }, false), new string[]
            {
                "Damage_3_6"
            });

            //Paranoia
            AnimationVisualsEffect headshot = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            headshot._animationTarget = Targeting.GenerateSlotTarget(new int[] { 1, -4 }, false);
            headshot._visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            AnimationVisualsEffect headshot2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            headshot2._animationTarget = Targeting.GenerateSlotTarget(new int[] { -1, 4 }, false);
            headshot2._visuals = CustomVisuals.GetVisuals("Salt/Gaze");

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;

            Rarity.CreateAndAddCustomRarityToPool("rarity6", 6);

            Ability paranoia = new Ability("Paranoia", "Paranoia_A");
            paranoia.Description = "Inflict 3 Frail on the Left or Right party members.\nThis ability assumes the grid loops around.";
            paranoia.Rarity = Rarity.CreateAndAddCustomRarityToPool("enigma_11", 11);
            paranoia.Effects = new EffectInfo[]
            {
                //Effects.GenerateEffect(headshot, 1, Targeting.GenerateSlotTarget(new int[]{1, -4}, false), Effects.ChanceCondition(50)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, Targeting.GenerateSlotTarget(new int[]{4, 1, -1, -4}, false)),
                //Effects.GenerateEffect(headshot2, 1, Targeting.GenerateSlotTarget(new int[]{-1, 4}, false), didnt2That),
                //Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, Targeting.GenerateSlotTarget(new int[]{-1, 4}, false)),
            };
            paranoia.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            paranoia.AnimationTarget = Targeting.GenerateSlotTarget(new int[] { 4, 1, -1, -4 }, false);
            paranoia.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { 4, 1, -1, -4 }, false), new string[]
            {
                "Status_Frail"
            });

            AnimationVisualsEffect paradox_anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            paradox_anim._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            paradox_anim._animationTarget = Slots.Front;

            //Paradox
            Ability paradox = new Ability("Paradox", "Paradox_A");
            paradox.Description = "If both the Left and Right party members are Frailed, deal an Agonizing amount of damage to the Opposing party member. \nThis ability assumes the grid loops around.";
            paradox.Rarity = Rarity.GetCustomRarity("rarity6");
            paradox.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<IsFrailEffect>(), 2, Targeting.GenerateSlotTarget(new int[4] {-4, -1, 1, 4}, false)),
                Effects.GenerateEffect(paradox_anim, 0, null, BasicEffects.DidThat(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Targeting.Slot_Front, BasicEffects.DidThat(true, 2)),
            };
            //paradox.Visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            paradox.Visuals = null;
            paradox.AnimationTarget = Targeting.Slot_Front;
            paradox.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[4] { -4, -1, 1, 4 }, false), new string[]
            {
                "Misc_Hidden"
            });
            paradox.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_7_10"
            });
            Enigma.enemy.passiveAbilities[2] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(Enigma.enemy.passiveAbilities[2]);
            Enigma.enemy.passiveAbilities[2]._passiveName = "Paradox";
            Enigma.enemy.passiveAbilities[2]._enemyDescription = "This enemy will perform an extra ability \"Paradox\" each turn.";
            ((ExtraAttackPassiveAbility)Enigma.enemy.passiveAbilities[2])._extraAbility.ability = paradox.GenerateEnemyAbility(true).ability;

            //Add
            Enigma.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                terrorize.GenerateEnemyAbility(true),
                paranoia.GenerateEnemyAbility(true),
            });
            Enigma.AddEnemy(true, true, false);
            Enigma.enemy.AddToSynodPool();
            Enigma.enemy.AddToEcstasyPool();
        }
    }
}
