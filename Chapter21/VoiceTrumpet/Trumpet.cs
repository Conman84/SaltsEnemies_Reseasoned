using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Trumpet
    {
        public static void Add()
        {
            Enemy trumpet = new Enemy("Voice Trumpet", "VoiceTrumpet_EN")
            {
                Health = 12,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("TrumpetIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("TrumpetWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("TrumpetDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Warbird_EN").damageSound,
                DeathSound = "event:/Hawthorne/HissingNoise",
            };
            trumpet.PrepareEnemyPrefab("assets/enem4/Trumpet_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/enem4/Trumpet_Gibs.prefab").GetComponent<ParticleSystem>());

            //announcement
            Connection_PerformEffectPassiveAbility announce = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            announce._passiveName = "Announcement (10)";
            announce.passiveIcon = ResourceLoader.LoadSprite("AnnouncementPassive.png");
            announce.m_PassiveID = "Announcement_PA";
            announce._enemyDescription = "On leaving combat, deal an Agonizing amount of damage to the Opposing party member.";
            announce._characterDescription = "On leaving combat, deal 10 damage to the Opposing enemy.";
            announce.doesPassiveTriggerInformationPanel = true;
            announce._triggerOn = [TriggerCalls.Count];
            announce.connectionEffects = [];
            announce.disconnectionEffects = new EffectInfo[3];
            announce.disconnectionEffects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Bellow_A", false, Slots.Front));
            announce.disconnectionEffects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front);

            trumpet.AddPassives(new BasePassiveAbilitySO[] { announce, Passives.Fleeting3, Passives.Formless });

            Ability first = new Ability("First", "First_A");
            first.Description = "Apply 3 Shield to this enemy's position and to its Left and Right.";
            first.Rarity = Rarity.GetCustomRarity("rarity5");
            first.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 3, Targeting.Slot_SelfAll_AndSides).SelfArray();
            first.AddIntentsToTarget(Targeting.Slot_SelfAll_AndSides, [IntentType_GameIDs.Field_Shield.ToString()]);
            first.Visuals = LoadedAssetsHandler.GetEnemyAbility("Rupture_A").visuals;
            first.AnimationTarget = Slots.Self;

            Ability third = new Ability("Third", "Third_A");
            third.Description = "Deal a Barely Painful amount of damage to the Opposing party member and inflict 2 Frail on them.";
            third.Rarity = Rarity.GetCustomRarity("rarity5");
            third.Effects = new EffectInfo[2];
            third.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Front);
            third.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Slots.Front);
            third.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Status_Frail.ToString()]);
            third.Visuals = LoadedAssetsHandler.GetEnemyAbility("Rupture_A").visuals;
            third.AnimationTarget = Slots.Self;

            Ability seventh = new Ability("Seventh", "Seventh_A");
            seventh.Description = "Instantly kill this enemy.";
            seventh.Rarity = Rarity.GetCustomRarity("rarity5");
            seventh.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self).SelfArray();
            seventh.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_Death.ToString()]);
            seventh.Visuals = null;
            seventh.AnimationTarget = Slots.Self;


            //ADD ENEMY
            trumpet.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                first.GenerateEnemyAbility(true),
                third.GenerateEnemyAbility(true),
                seventh.GenerateEnemyAbility(true)
            });
            trumpet.AddEnemy(true, true);
        }
    }
}
