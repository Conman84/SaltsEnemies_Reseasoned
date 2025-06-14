﻿using BrutalAPI;
using UnityEngine;
using SaltEnemies_Reseasoned;
using System.Collections.Generic;

namespace SaltsEnemies_Reseasoned
{
    public static class Medamaude
    {
        public static void Add()
        {
            Enemy template = new Enemy("Medamaude", "EyePalm_EN")
            {
                Health = 21,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("EyePalmIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("EyePalmDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("EyePalmWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").deathSound,
            };
            template.PrepareEnemyPrefab("assets/group4/EyePalm/EyePalm_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/EyePalm/EyePalm_Gibs.prefab").GetComponent<ParticleSystem>());

            //miss faced
            BasePassiveAbilitySO mf = ScriptableObject.Instantiate(Passives.TwoFaced);
            mf._locID = "";
            mf.passiveIcon = ResourceLoader.LoadSprite("MissFaced.png");
            mf._passiveName = "Miss-Faced";
            mf._enemyDescription = "On being direct damaged and at the end of each round, this unit's health color changes between Red and Blue.";
            mf.m_PassiveID = "MissFaced_PA";
            mf._characterDescription = mf._enemyDescription;
            mf._triggerOn = new List<TriggerCalls>(Passives.TwoFaced._triggerOn) { TriggerCalls.OnRoundFinished }.ToArray();

            //scramble
            /*
            ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
            ParentalPassiveAbility scramble = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
            scramble._passiveName = "Parental";
            scramble._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"Scramble\" in retribution.";
            Ability parental = new Ability("EyePalm_Scramble_A");
            parental.Name = "Scramble";
            parental.Description = "Randomize all enemy positions.";
            parental.Effects = new EffectInfo[1];
            parental.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, Targetting.AllAlly);
            parental.AddIntentsToTarget(Targetting.AllAlly, new string[] { IntentType_GameIDs.Swap_Mass.ToString() });
            parental.Visuals = CustomVisuals.GetVisuals("Salt/Alarm");
            parental.AnimationTarget = Targeting.Slot_SelfSlot;
            AbilitySO ability = parental.GenerateEnemyAbility(true).ability;
            scramble._parentalAbility.ability = ability;
            */
            ClownPassiveAbility.Setup();
            PerformEffectPassiveAbility scramble = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            scramble._passiveName = "Scramble";
            scramble.passiveIcon = ResourceLoader.LoadSprite("ScramblePassive.png");
            scramble.m_PassiveID = "Scramble_PA";
            scramble._enemyDescription = "On any Infantile enemy being damaged, randomize the positions of all enemies.";
            scramble._characterDescription = "idk";
            scramble.doesPassiveTriggerInformationPanel = true;
            scramble.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, Targetting.AllAlly).SelfArray();
            scramble._triggerOn = [ClownPassiveAbility.Trigger];

            //add passives
            template.AddPassives(new BasePassiveAbilitySO[] { mf, scramble });

            Targetting_ByUnit_SideCasterColor targettingCasterColor = ScriptableObject.CreateInstance<Targetting_ByUnit_SideCasterColor>();
            targettingCasterColor.getAllies = true;
            targettingCasterColor.getAllUnitSlots = true;
            Targetting_ByUnit_SideCasterColor targettingSingleSizeColor = ScriptableObject.CreateInstance<Targetting_ByUnit_SideCasterColor>();
            targettingSingleSizeColor.getAllies = true;
            targettingSingleSizeColor.getAllUnitSlots = true;
            targettingSingleSizeColor.SingleSize = true;
            BaseCombatTargettingSO allEnemy = Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false);
            BaseCombatTargettingSO allAlly = Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true);

            //pigs in blue
            Ability blue = new Ability("PigsInBlue_A");
            blue.Name = "Pigs in Blue";
            blue.Description = "If any enemies share this enemy's health color, deal a Painful amount of damage to their Opposing positions.\nInflict 1 Constricted on the Opposing position.";
            blue.Rarity = Rarity.GetCustomRarity("rarity5");
            blue.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targetting.Reverse(targettingCasterColor)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.Front)
            };
            blue.AddIntentsToTarget(Targetting.Reverse(targettingCasterColor), new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            blue.AddIntentsToTarget(allEnemy, new string[] { IntentType_GameIDs.Misc.ToString() });
            blue.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Field_Constricted.ToString()]);
            blue.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            blue.AnimationTarget = Targetting.Reverse(targettingCasterColor);

            //blood in crazy
            Ability red = new Ability("BloodInCrazy_A");
            red.Name = "Blood in Crazy";
            red.Description = "If any single-tile enemies share this enemy's health color, shuffle the positions between them.";
            red.Rarity = Rarity.GetCustomRarity("rarity5");
            red.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ShufflePositionsAmongTargetsEffect>(), 0, targettingSingleSizeColor)
            };
            red.AddIntentsToTarget(targettingSingleSizeColor, new string[] { IntentType_GameIDs.Swap_Mass.ToString() });
            red.AddIntentsToTarget(allAlly, new string[] { IntentType_GameIDs.Misc.ToString() });
            red.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            red.AnimationTarget = targettingSingleSizeColor;
            red.Priority = Priority.Fast;

            //PINCH
            ChangeCasterHealthColorBetweenColorsEffect effect = ScriptableObject.CreateInstance<ChangeCasterHealthColorBetweenColorsEffect>();
            effect._color1 = Pigments.Red;
            effect._color2 = Pigments.Blue;
            Ability pinch = new Ability("EyePalm_Pinch_A")
            {
                Name = "Pinch",
                Description = "Deal an Agonizing amount of damage to the Opposing party member. Change this enemy's health color between Red and Blue.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Targeting.Slot_Front),
                            Effects.GenerateEffect(effect, 1, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Class"),
                AnimationTarget = Targeting.Slot_Front,
            };
            pinch.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            pinch.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Modify.ToString() });
            pinch.Priority = Priority.Slow;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                red.GenerateEnemyAbility(true),
                blue.GenerateEnemyAbility(true),
                pinch.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true, true);
        }
    }
}
