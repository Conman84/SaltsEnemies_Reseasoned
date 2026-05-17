using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class AbandonedPuppet
    {
        public static void Add()
        {
            Enemy puppet = new Enemy("Abandoned Puppet", "AbandonedPuppet_EN")
            {
                Health = 15,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("PuppetIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PuppetWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PuppetDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Damocles_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Damocles_EN").deathSound,
                Priority = Priority.Fast
            };
            puppet.PrepareEnemyPrefab("Assets/Abyss/Puppet_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Abyss/Puppet_Gibs.prefab").GetComponent<ParticleSystem>());

            //parental
            ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
            ParentalPassiveAbility loved = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
            loved._passiveName = "Parental";
            loved._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"It Must Be Nice To Be Loved.\" in retribution.";
            BaseCombatTargettingSO allnotfront = Slots.SlotTarget([-4, -3, -2, -1, 1, 2, 3, 4], false);
            Ability parental = new Ability("ItMustBeNiceToBeLoved_A");
            parental.Name = "It Must Be Nice To Be Loved.";
            parental.Description = "Deal a Painful amount of damage to all party members Not Opposing this enemy.";
            parental.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, allnotfront)];
            parental.AddIntentsToTarget(allnotfront, ["Damage_3_6"]);
            parental.Visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;
            parental.AnimationTarget = allnotfront;
            AbilitySO ability = parental.GenerateEnemyAbility(true).ability;
            loved._parentalAbility.ability = ability;

            //intimidated
            PerformEffectPassiveAbility fear = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fear._passiveName = "Intimidated";
            fear.passiveIcon = ResourceLoader.LoadSprite("intimidated.png");
            fear.m_PassiveID = "Intimidated_PA";
            fear._enemyDescription = "When a party member moves in front of this enemy, reroll one of this enemy's actions.";
            fear._characterDescription = "wotn workn...";
            fear.doesPassiveTriggerInformationPanel = true;
            fear.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ReRollTargetTimelineAbilityEffect>(), 1, Targeting.Slot_SelfSlot) };
            fear._triggerOn = new TriggerCalls[1] { (TriggerCalls)AmbushManager.Patiently };

            puppet.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, loved, fear });

            Ability absent = new Ability("Absentee", "Absentee_A");
            absent.Description = "Move to a random currently unoccupied position.\nIf successful, deal a Painful amount of damage to the Opposing party member.";
            absent.Rarity = Rarity.GetCustomRarity("rarity5");
            absent.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToRandomEmptyTileEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Claws", false, Slots.Front), 0, null, BasicEffects.DidThat(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Front, BasicEffects.DidThat(true, 2))
                ];
            absent.AddIntentsToTarget(Slots.Self, ["Swap_Mass"]);
            absent.AddIntentsToTarget(Slots.Front, ["Damage_3_6"]);
            absent.Visuals = null;
            absent.AnimationTarget = Slots.Self;

            Ability lost = new Ability("Lost And Found", "Salt_LAF_A");
            lost.Description = "Inflict 3 Frail and Curse the Opposing party member.";
            lost.Rarity = Rarity.CreateAndAddCustomRarityToPool("puppet_higher", 7);
            lost.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Front)
                ];
            lost.AddIntentsToTarget(Slots.Front, ["Status_Frail", "Status_Cursed"]);
            lost.Visuals = LoadedAssetsHandler.GetEnemyAbility("Sob_A").visuals;
            lost.AnimationTarget = Slots.Front;

            SpawnEnemyByStringNameEffect mimita = ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>();
            mimita._spawnTypeID = "Spawn_Basic";
            mimita.enemyName = "Mimita_EN";

            Ability found = new Ability("Found And Lost", "Salt_FAL_A");
            found.Description = "Call for Mimita.\nIf unsuccessful, inflict 1 Frail on all party members Not Opposing this enemy.";
            found.Rarity = Rarity.GetCustomRarity("rarity5");
            found.Effects = [
                Effects.GenerateEffect(mimita, 1, null, FitSizeCondition.Create(3)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, allnotfront, BasicEffects.DidThat(false))
                ];
            found.AddIntentsToTarget(Slots.Self, ["Other_Spawn"]);
            found.AddIntentsToTarget(allnotfront, ["Status_Frail"]);
            found.Visuals = Visuals.Weep;
            found.AnimationTarget = Slots.Self;

            //ADD ENEMY
            puppet.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                absent.GenerateEnemyAbility(true),
                lost.GenerateEnemyAbility(true),
                found.GenerateEnemyAbility(true)
            });
            puppet.AddEnemy(true, true);
            puppet.enemy.AddToSynodPool();
            puppet.enemy.AddToToysPool();
            puppet.enemy.AddToEcstasyPool();
        }
    }
}
