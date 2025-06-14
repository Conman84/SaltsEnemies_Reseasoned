﻿using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//roar: event:/Hawthorne/Noi3e/PawnRoar

namespace SaltsEnemies_Reseasoned
{
    public static class Pawn
    {
        public static void Add()
        {
            Enemy pawn = new Enemy("Pawn A", "PawnA_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("PawnIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PawnDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PawnWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noi3e/PawnHit",
                DeathSound = "event:/Hawthorne/Noi3e/PawnDie",
            };
            pawn.PrepareEnemyPrefab("Assets/enem3/Pawn_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Pawn_Gibs.prefab").GetComponent<ParticleSystem>());

            //traitor
            TraitorHandler.Setup();
            PerformEffectPassiveAbility traitor = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            traitor._passiveName = "Traitor";
            traitor.passiveIcon = ResourceLoader.LoadSprite("TraitorPassive.png");
            traitor.m_PassiveID = "Traitor_PA";
            traitor._enemyDescription = "On receiving damage from an enemy, deal a Painful amount of damage to the Opposing party member.\nOn receiving damage from a party member, deal a Little damage to the Left and Right enemies.\nThis passive does not trigger if this enemy dies.";
            traitor._characterDescription = "Wont work cuz i didnt bother setting up the other half of the hook";
            traitor.conditions = [ScriptableObject.CreateInstance<TraitorCondition>()];
            traitor._triggerOn = [TraitorHandler.Call];
            traitor.effects = new EffectInfo[0];

            //parental
            ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
            ParentalPassiveAbility martyr = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
            martyr._passiveName = "Parental";
            martyr._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"Martyr\" in retribution.";
            Ability parental = new Ability("Martyr_A");
            parental.Name = "Martyr A";
            parental.Description = "Give this enemy \"Infestation (1)\" as a passive. If this enemy already had \"Infestation\" as a passive, increase \"Infestation\" on the Left and Right enemies by 1 instead.\nConsume 1 random Pigment.";
            parental.Effects = new EffectInfo[3];
            parental.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddInfestationEffect>(), 1, Targeting.Slot_AllySides, HasInfestationEffectCondition.Create(true));
            parental.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddInfestationEffect>(), 1, Targeting.Slot_SelfSlot, HasInfestationEffectCondition.Create(false));
            parental.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, Slots.Self);
            parental.AddIntentsToTarget(Targeting.Slot_SelfAndSides, new string[] { IntentType_GameIDs.PA_Infestation.ToString() });
            parental.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Consume.ToString()]);
            parental.Visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;
            parental.AnimationTarget = Targeting.Slot_SelfSlot;
            AbilitySO ability = parental.GenerateEnemyAbility(true).ability;
            martyr._parentalAbility.ability = ability;

            pawn.AddPassives(new BasePassiveAbilitySO[] { Passives.Absorb, traitor, martyr, });
            pawn.UnitTypes = new List<string> { "FemaleID" };

            //mercenary
            Ability merc = new Ability("Mercenary A", "Mercenary_A");
            merc.Description = "Deal a Little damage to the lowest health enemy.\nConsume 1 random Pigment.";
            merc.Rarity = Rarity.GetCustomRarity("rarity5");
            merc.Effects = new EffectInfo[2];
            merc.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targetting.LowestAlly);
            merc.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, Slots.Self);
            merc.AddIntentsToTarget(Targeting.Unit_AllAllies, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            merc.AddIntentsToTarget(Targetting.LowestAlly, [IntentType_GameIDs.Damage_1_2.ToString()]);
            merc.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Consume.ToString()]);
            merc.Visuals = CustomVisuals.GetVisuals("Salt/Reload");
            merc.AnimationTarget = Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], true);

            //merchant
            Ability merchant = new Ability("Merchant A", "Merchant_A");
            merchant.Description = "Transfer all Status Effects from the Opposing party member to this enemy.\nConsume 1 random Pigment.";
            merchant.Rarity = Rarity.GetCustomRarity("rarity5");
            merchant.Effects = new EffectInfo[3];
            merchant.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<CopyStatusOntoCasterEffect>(), 1, Slots.Front);
            merchant.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, Slots.Front);
            merchant.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, Slots.Self);
            merchant.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Misc.ToString()]);
            merchant.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Consume.ToString()]);
            merchant.Visuals = LoadedAssetsHandler.GetCharacterAbility("Mend_1_A").visuals;
            merchant.AnimationTarget = Slots.Front;

            //murder
            Ability murder = new Ability("Murderer A", "Murderer_A");
            murder.Description = "Might deal an Agonizing amount of damage to the Opposing party member.\nConsume 1 random Pigment.";
            murder.Rarity = Rarity.GetCustomRarity("rarity5");
            murder.Effects = new EffectInfo[2];
            murder.Effects[0] = Effects.GenerateEffect(ChanceZeroDamageEffect.Create(0.5f), 8, Slots.Front);
            murder.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, Slots.Self);
            murder.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString()]);
            murder.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Consume.ToString()]);
            murder.Visuals = CustomVisuals.GetVisuals("Salt/Reload");
            murder.AnimationTarget = Slots.Front;

            //ADD ENEMY
            pawn.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                merc.GenerateEnemyAbility(true),
                merchant.GenerateEnemyAbility(true),
                murder.GenerateEnemyAbility(true)
            });
            pawn.AddEnemy(true, true);
        }
    }
}
