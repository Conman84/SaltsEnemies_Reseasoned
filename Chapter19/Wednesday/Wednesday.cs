using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Wednesday
    {
        public static void Add()
        {
            Enemy template = new Enemy("Wednesday", "Wednesday_EN")
            {
                Health = 17,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("PhoneIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PhoneWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PhoneDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sund/PhoneHit",
                DeathSound = "event:/Hawthorne/Sund/PhoneDie",
            };
            template.PrepareEnemyPrefab("Assets/enem3/Phone_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Phone_Gibs.prefab").GetComponent<ParticleSystem>());

            //REPRESSION
            RepressionPassiveAbility repression = ScriptableObject.CreateInstance<RepressionPassiveAbility>();
            repression._passiveName = "Repression";
            repression.passiveIcon = ResourceLoader.LoadSprite("repression.png");
            repression.m_PassiveID = "Repression_PA";
            repression._enemyDescription = "If this enemy took no damage of any kind last turn, this enemy gains another action per turn for the rest of combat.";
            repression._characterDescription = "won't work. oops!";
            repression.doesPassiveTriggerInformationPanel = false;
            repression.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(RepressionPassiveAbility.bonusTurns);
            repression._triggerOn = Passives.MultiAttack2._triggerOn;
            repression._isItAdditive = ((IntegerSetterPassiveAbility)Passives.MultiAttack2)._isItAdditive;
            repression.integerValue = 1;

            //backlash
            PerformEffectPassiveAbility backlash = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            backlash._passiveName = "Backlash";
            backlash.m_PassiveID = "Backlash_PA";
            backlash.passiveIcon = ResourceLoader.LoadSprite("BacklashPassive.png");
            backlash._enemyDescription = "On taking direct damage, apply Shield to this unit's position for the amount of damage taken.";
            backlash._characterDescription = backlash._enemyDescription;
            backlash.doesPassiveTriggerInformationPanel = false;
            backlash.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<BacklashCondition>() }.ToArray();
            backlash._triggerOn = [TriggerCalls.OnDirectDamaged];
            backlash.effects = [];

            //revenge
            PerformEffectPassiveAbility revenge = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            revenge._passiveName = "Revenge";
            revenge.m_PassiveID = "Revenge_PA";
            revenge.passiveIcon = ResourceLoader.LoadSprite("Revenge.png");
            revenge._characterDescription = "NOTHING!!!!";
            revenge._enemyDescription = "On taking direct damage, give this enemy another ability.";
            revenge.doesPassiveTriggerInformationPanel = true;
            revenge.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            revenge._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, repression, backlash, revenge });

            Ability silentNight = new Ability("Silent Night", "SilentNight_A");
            silentNight.Description = "It's all quiet for now.";
            silentNight.Rarity = Rarity.CreateAndAddCustomRarityToPool("phone7", 7);
            silentNight.Visuals = null;
            silentNight.Effects = new EffectInfo[0];
            silentNight.AnimationTarget = Slots.Self;

            Ability pickup = new Ability("Pick Up", "PickUp_A");
            pickup.Description = "All enemies gain another action on the timeline.";
            pickup.Rarity = Rarity.CreateAndAddCustomRarityToPool("phone3", 3);
            pickup.Priority = Priority.Slow;
            pickup.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, Targeting.Unit_AllAllies).SelfArray();
            pickup.AddIntentsToTarget(Targeting.Unit_AllAllies, IntentType_GameIDs.Misc_Additional.ToString().SelfArray());
            pickup.Visuals = CustomVisuals.GetVisuals("Salt/Call");
            pickup.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                silentNight.GenerateEnemyAbility(true),
                pickup.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true, true);
        }
    }
}
