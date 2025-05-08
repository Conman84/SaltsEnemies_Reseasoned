using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class MortalSpoggle
    {
        public static void Add()
        {
            //Unmasking
            OnPissPassiveAbility substitute = ScriptableObject.CreateInstance<OnPissPassiveAbility>();
            substitute._passiveName = "Substitute";
            substitute.m_PassiveID = "Substitute_PA";
            substitute.passiveIcon = ResourceLoader.LoadSprite("DivineSacrifice.png");
            substitute._characterDescription = "placeholder description";
            substitute._enemyDescription = "Permanently applies Divine Sacrifice to this enemy.";
            substitute.doesPassiveTriggerInformationPanel = false;
            substitute._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("DivineSacrifice.png"), "Substitute", substitute._enemyDescription);

            //Enemy Code
            Enemy MortalSpoggle = new Enemy("Mortal Spoggle", "MortalSpoggle_EN")
            {
                Health = 38,
                HealthColor = Pigments.Grey,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("GSpogIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("GSpogDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("GSpogIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound,
            };
            MortalSpoggle.PrepareEnemyPrefab("assets/greyShit/GreySpog_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/greyShit/GreySpog_Gibs.prefab").GetComponent<ParticleSystem>());

            MortalSpoggle.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Pure, 
                Passives.Skittish, 
                Passives.Absorb,
                substitute
            });
            MortalSpoggle.AddUnitType(Inspiration.Passive);
            MortalSpoggle.CombatEnterEffects = Effects.GenerateEffect(RootActionEffect.Create(Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyInspirationEffect>(), 1, Slots.Self).SelfArray()), 1, Slots.Self).SelfArray();

            //Siphon
            ConsumeRandomButColorManaEffect notGrey = ScriptableObject.CreateInstance<ConsumeRandomButColorManaEffect>();
            notGrey._exceptionManas = new ManaColorSO[1] { Pigments.Grey };

            Ability siphon = new Ability("Siphon", "Salt_Siphon_A");
            siphon.Description = "This enemy consumes 3 pigment not of this enemy's health color.";
            siphon.Rarity = Rarity.GetCustomRarity("rarity5");
            siphon.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(notGrey, 3, Targeting.Slot_SelfSlot),
            };
            siphon.Visuals = LoadedAssetsHandler.GetEnemyAbility("Siphon_A").visuals;
            siphon.AnimationTarget = Targeting.Slot_SelfSlot;
            siphon.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Mana_Consume"
            });

            //Gnaw
            Ability gnaw = new Ability("Gnaw", "Salt_Gnaw_A");
            gnaw.Description = "Deal 4 damage to the left and right party members. Consume 2 pigment not of this enemy's health color.";
            gnaw.Rarity = Rarity.GetCustomRarity("rarity5");
            gnaw.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_OpponentSides),
                Effects.GenerateEffect(notGrey, 2, Targeting.Slot_SelfSlot),
            };
            gnaw.Visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals;
            gnaw.AnimationTarget = Targeting.Slot_OpponentSides;
            gnaw.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[]
            {
                "Damage_3_6"
            });
            gnaw.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Mana_Consume"
            });

            //Not Long
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;

            Ability notLong = new Ability("Divine Inspiration", "Salt_DivineInspiration_A");
            notLong.Description = "Apply 1 Inspiration to this enemy. \nIf this enemy already had Inspration, deal a Little damage to all party members.";
            notLong.Rarity = Rarity.GetCustomRarity("rarity5");
            notLong.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targetting.Everything(false), ScriptableObject.CreateInstance<HasInspirationCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyInspirationEffect>(), 1, Slots.Self, BasicEffects.DidThat(false)),
            };
            notLong.Visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            notLong.AnimationTarget = Slots.Self;
            notLong.AddIntentsToTarget(Slots.Self, new string[]
            {
                Inspiration.Intent, IntentType_GameIDs.Misc_Hidden.ToString()
            });
            notLong.AddIntentsToTarget(Targetting.Everything(false), [IntentType_GameIDs.Damage_1_2.ToString()]);

            //Add
            MortalSpoggle.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                siphon.GenerateEnemyAbility(true),
                gnaw.GenerateEnemyAbility(true),
                notLong.GenerateEnemyAbility(true),
            });
            MortalSpoggle.AddEnemy(true, false, false);
        }
    }
}