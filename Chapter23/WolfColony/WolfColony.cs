using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class WolfColony
    {
        public static void Add()
        {
            Enemy template = new Enemy("Wolf Colony", "WolfColony_EN")
            {
                Health = 23,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("WolfIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WolfWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WolfDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Ssound/WolfHit",
                DeathSound = "event:/Hawthorne/Ssound/WolfDie",
            };
            template.PrepareEnemyPrefab("Assets/Siren2/WolfColony_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Siren2/WolfColony_Gibs.prefab").GetComponent<ParticleSystem>());

            //Decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay.name = "Decay_WolfLarvae";
            decay._passiveName = "Decay";
            decay.m_PassiveID = "Decay_PA";
            decay.passiveIcon = ResourceLoader.LoadSprite("Decay.png");
            decay._characterDescription = "shouldnt be on a character. idk what it'd do. fuck you up, maybe?";
            decay._enemyDescription = "Upon dying, this enemy decays into as many Wolf Larvae as possible.";
            decay.doesPassiveTriggerInformationPanel = true;
            SpawnEnemyByStringNameEffect larvae = ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>();
            larvae.enemyName = "WolfLarvae_EN";
            larvae._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            decay.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(larvae, 5, Targeting.Slot_SelfSlot),
            };
            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };

            template.AddPassives(new BasePassiveAbilitySO[] { decay, Passives.Anchored });

            Ability tickler = new Ability("Wolf_Tickler_A");
            tickler.Name = "Tickler";
            tickler.Description = "Heal all enemies 2 Health.\nIf the total amount of healing dealt is less than 3, deal a Barely Painful amount of damage to the Left, Right, and Opposing party members.";
            tickler.Rarity = Rarity.GetCustomRarity("rarity5");
            tickler.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 2, Targeting.Unit_AllAllies),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<PrevExitMeetsEntryEffect>(), 3),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Anchoring", false, Slots.FrontLeftRight), 1, Slots.Self, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.FrontLeftRight, BasicEffects.DidThat(true))
                ];
            tickler.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Heal_1_4"]);
            tickler.AddIntentsToTarget(Slots.FrontLeftRight, ["Misc_Hidden", "Damage_3_6"]);
            tickler.Visuals = LoadedAssetsHandler.GetCharacterAbility("Decimation_1_A").visuals;
            tickler.AnimationTarget = Slots.Self;

            Ability tomure = new Ability("Wolf_Tomure_A");
            tomure.Name = "Tomure";
            tomure.Description = "Slightly heal the Lowest health enemy.\nIf no healing is dealt, deal an Agonizing amount of damage to the Opposing party member. Otherwise, Curse this enemy.";
            tomure.Rarity = Rarity.GetCustomRarity("rarity5");
            tomure.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 2, Targetting.LowestAlly),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Self, BasicEffects.DidThat(true)),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Anchoring", false, Slots.Front), 1, Slots.Self, BasicEffects.DidThat(false, 2)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front, BasicEffects.DidThat(true)),
                ];
            tomure.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Heal_1_4"]);
            tomure.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_7_10"]);
            tomure.AddIntentsToTarget(Slots.Self, ["Status_Cursed"]);
            tomure.Visuals = LoadedAssetsHandler.GetCharacterAbility("Buster_1_A").visuals;
            tomure.AnimationTarget = Slots.Self;

            Ability larvate = new Ability("Wolf_Larvate_A");
            larvate.Name = "Larvate";
            larvate.Description = "Slightly heal the Opposing party member and Curse them.\nIf no healing is dealt, deal a Little damage to the Opposing party member.";
            larvate.Rarity = Rarity.GetCustomRarity("rarity5");
            larvate.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 2, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front, BasicEffects.DidThat(false, 2))
                ];
            larvate.AddIntentsToTarget(Slots.Front, ["Heal_1_4", "Status_Cursed", "Damage_1_2"]);
            larvate.Visuals = LoadedAssetsHandler.GetCharacterAbility("Mend_1_A").visuals;
            larvate.AnimationTarget = Slots.Front;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                tickler.GenerateEnemyAbility(true),
                tomure.GenerateEnemyAbility(true),
                larvate.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true, true);
            template.enemy.AddToSynodPool();
        }
    }
}
