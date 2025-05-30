using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class StarGazer
    {
        public static void Add()
        {
            //Jumpy
            InvinciblePassiveAbility illusory = ScriptableObject.CreateInstance<InvinciblePassiveAbility>();
            illusory._passiveName = "Illusory";
            illusory.m_PassiveID = "Illusory_PA";
            illusory.passiveIcon = ResourceLoader.LoadSprite("StarPassive.png");
            illusory._characterDescription = "This character is immune to both direct and indirect damage.";
            illusory._enemyDescription = "This enemy is immune to both direct and indirect damage.";
            illusory.doesPassiveTriggerInformationPanel = false;
            illusory._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };

            //Enemy Code
            Enemy StarGazer = new Enemy("Star Gazer", "StarGazer_EN")
            {
                Health = 6,
                HealthColor = Pigments.Purple,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("IconBStars.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("IconStars.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("IconStars.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Nois2/StarsRoar",
                DeathSound = "event:/Hawthorne/Nois2/StarsDeath",
            };
            StarGazer.PrepareEnemyPrefab("assets/Senis3/Stars_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Senis3/Stars_Gibs.prefab").GetComponent<ParticleSystem>());

            StarGazer.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Infestation2, 
                illusory, 
                Passives.Skittish,
            });

            AddPassiveEffect addWither = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addWither._passiveToAdd = Passives.Withering;
            StarGazer.CombatEnterEffects = new EffectInfo[]
            {
                Effects.GenerateEffect(addWither, 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(70))
            };

            //Dance
            CasterStoredValueChangeEffect infestationUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            infestationUp._minimumValue = 0;
            infestationUp._increase = true;
            infestationUp.m_unitStoredDataID = UnitStoredValueNames_GameIDs.InfestationPA.ToString();

            Ability dance = new Ability("Slow Dance", "Salt_SlowDance_A");
            dance.Description = "Increase this character's Infestation by 1.";
            dance.Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity15", 15);
            dance.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(infestationUp, 1, Targeting.Slot_SelfSlot),
            };
            dance.Visuals = CustomVisuals.GetVisuals("Salt/Stars");
            dance.AnimationTarget = Targeting.Slot_SelfSlot;
            dance.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc"
            });

            //Finish
            Ability finish = new Ability("Abrupt Finish", "Salt_AbruptFinish_A");
            finish.Description = "Deal 1 damage to the opposing party member. Instantly kill self.";
            finish.Rarity = Rarity.GetCustomRarity("rarity5");
            finish.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            finish.Visuals = LoadedAssetsHandler.GetEnemyAbility("StrikeAChord_A").visuals;
            finish.AnimationTarget = Targeting.Slot_Front;
            finish.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_1_2"
            });
            finish.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Damage_Death"
            });

            //Add
            StarGazer.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                dance.GenerateEnemyAbility(true),
                finish.GenerateEnemyAbility(true),
            });
            StarGazer.AddEnemy(true, false, false);
        }
    }
}
