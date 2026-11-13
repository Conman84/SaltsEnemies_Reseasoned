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
            announce._passiveName = "Announcement";
            announce.passiveIcon = ResourceLoader.LoadSprite("AnnouncementPassive.png");
            announce.m_PassiveID = "Announcement_PA";
            announce.name = "Announcement_PA";
            announce._enemyDescription = "Upon being removed from combat by any means, including dying or fleeing, inflict a slew of Negative Status Effects on the Opposing party member.";
            announce._characterDescription = "Upon being removed from combat by any means, including dying or fleeing, inflict a slew of Negative Status Effects on the Opposing enemy.";
            announce.doesPassiveTriggerInformationPanel = false;
            announce._triggerOn = [TriggerCalls.Count];
            announce.connectionEffects = [];
            announce.disconnectionEffects = new EffectInfo[3];
            announce.disconnectionEffects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<AnnouncementPassiveEffect>(), 7);
            announce.disconnectionEffects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Bellow_A", false, Slots.Front));
            announce.disconnectionEffects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SlewStatusEffect>(), 1, Slots.Front);
            announce.AddToPassiveDatabase();

            //diviner
            PerformEffectPassiveAbility escape = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            escape.name = "Diviner_PA";
            escape._passiveName = "Diviner";
            escape.passiveIcon = ResourceLoader.LoadSprite("DivinerPassive.png");
            escape.m_PassiveID = "Diviner_PA";
            escape._enemyDescription = "On being directly damaged, even if the damage was fatal, move to a random unoccupied position if possible.";
            escape._characterDescription = escape._enemyDescription;
            escape._triggerOn = [TriggerCalls.OnDirectDamaged];
            escape.conditions = [];
            escape.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToRandomEmptyTileEffect>(), 1, Slots.Self)];
            escape.AddToPassiveDatabase();

            trumpet.AddPassives(new BasePassiveAbilitySO[] { announce, Passives.Fleeting3, Passives.Formless, escape });

            Ability first = new Ability("First", "First_A");
            first.Description = "Applies 2 Shield to this enemy's position and to its Left and Right.";
            first.Rarity = Rarity.Uncommon;
            first.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 2, Targeting.Slot_SelfAll_AndSides).SelfArray();
            first.AddIntentsToTarget(Targeting.Slot_SelfAll_AndSides, [IntentType_GameIDs.Field_Shield.ToString()]);
            first.Visuals = LoadedAssetsHandler.GetEnemyAbility("Rupture_A").visuals;
            first.AnimationTarget = Slots.Self;


            GenerateRandomManaBetweenEffect random = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            random.possibleMana = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            Ability third = new Ability("Third", "Third_A");
            third.Description = "Generates 3 random Pigment.";
            third.Rarity = Rarity.Common;
            third.Effects = new EffectInfo[1];
            third.Effects[0] = Effects.GenerateEffect(random, 3, Targeting.Slot_SelfSlot);
            third.AddIntentsToTarget(Slots.Self, ["Mana_Generate"]);
            third.Visuals = LoadedAssetsHandler.GetEnemyAbility("Rupture_A").visuals;
            third.AnimationTarget = Slots.Self;

            Ability seventh = new Ability("Seventh", "Seventh_A");
            seventh.Description = "Deals an Agonizing amount of damage to the Opposing party member.\nInstantly kills this enemy.";
            seventh.Rarity = Rarity.GetCustomRarity("rarity5");
            seventh.Effects = [
                Effects.GenerateEffect(BasicEffects.GetVisuals("Rupture_A", false, Slots.Front), 0, null, IsFrontTargetCondition.Create(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self)
                ];
            seventh.AddIntentsToTarget(Slots.Front, ["Damage_7_10"]);
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
            trumpet.AddEnemy(true);
            //trumpet.enemy.AddToSynodPool();
            trumpet.enemy.AddToEcstasyPool();
        }
    }
}
