using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class DeadOrAlive
    {
        public static void Add()
        {
            Enemy clown = new Enemy("Dead or Alive", "Clown_EN")
            {
                Health = 25,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CorpseIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CorpseWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CorpseDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Derogatory_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Derogatory_EN").deathSound,
            };
            clown.PrepareEnemyPrefab("assets/enem4/Corpse_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/enem4/Corpse_Gibs.prefab").GetComponent<ParticleSystem>());

            //production
            ClownPassiveAbility.Setup();
            ClownPassiveAbility produce = ScriptableObject.CreateInstance<ClownPassiveAbility>();
            produce._passiveName = "Production";
            produce.passiveIcon = ResourceLoader.LoadSprite("ProductionPassive.png");
            produce.m_PassiveID = "Production_PA";
            produce._enemyDescription = "On any infantile enemy being damaged, spawn a Waltz.";
            produce._characterDescription = "idk";
            produce.doesPassiveTriggerInformationPanel = true;
            SpawnEnemyByStringNameEffect spawnWaltz = ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>();
            spawnWaltz.enemyName = "Waltz_EN";
            produce.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>(), 1, Slots.Self).SelfArray();
            produce._triggerOn = [ClownPassiveAbility.Trigger];

            clown.AddPassives(new BasePassiveAbilitySO[] { produce, Passives.Dying });

            AbilitySelector_Clown selector = ScriptableObject.CreateInstance<AbilitySelector_Clown>();
            selector.Ability = "MySpecialAttack_A";
            selector.CheckPassive = PassiveType_GameIDs.Infantile.ToString();
            clown.AbilitySelector = selector;

            Ability special = new Ability("My Special Attack", "MySpecialAttack_A");
            special.Description = "Turn Blue.\nIf this enemy was already Blue, spawn a Waltz.";
            special.Rarity = Rarity.GetCustomRarity("rarity5");
            special.Effects = new EffectInfo[2];
            special.Effects[0] = Effects.GenerateEffect(spawnWaltz, 1, Slots.Self, ScriptableObject.CreateInstance<IsBlueEffectCondition>());
            ChangeHealthColorEffect turnBlue = ScriptableObject.CreateInstance<ChangeHealthColorEffect>();
            turnBlue.color = Pigments.Blue;
            special.Effects[1] = Effects.GenerateEffect(turnBlue, 1, Slots.Self, BasicEffects.DidThat(false));
            special.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), [IntentType_GameIDs.Mana_Modify.ToString(), IntentType_GameIDs.Other_Spawn.ToString()]);
            special.Visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
            special.AnimationTarget = TargettingSelf_NotSlot.Create();

            //life
            Ability life = new Ability("As in Life", "AsInLife_A");
            life.Description = "Deal a Painful amount of damage to the Opposing party members.\nTurn all Grey enemies Red.";
            life.Rarity = Rarity.GetCustomRarity("rarity5");
            life.Effects = new EffectInfo[2];
            life.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front);
            ChangeHealthColorEffect turnRed = ScriptableObject.CreateInstance<ChangeHealthColorEffect>();
            turnRed.color = Pigments.Red;
            Targetting_ByUnit_SideColor allGrey = ScriptableObject.CreateInstance<Targetting_ByUnit_SideColor>();
            allGrey.getAllies = true;
            allGrey.getAllUnitSlots = false;
            allGrey.Color = Pigments.Grey;
            life.Effects[1] = Effects.GenerateEffect(turnRed, 1, allGrey);
            life.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            life.AddIntentsToTarget(Targetting.AllAlly, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            life.AddIntentsToTarget(allGrey, [IntentType_GameIDs.Mana_Modify.ToString()]);
            life.Visuals = LoadedAssetsHandler.GetCharacterAbility("Mend_1_A").visuals;
            life.AnimationTarget = TargettingSelf_NotSlot.Create();

            //death
            ChangeHealthColorEffect turnGrey = ScriptableObject.CreateInstance<ChangeHealthColorEffect>();
            turnGrey.color = Pigments.Grey;
            Targetting_ByUnit_SideColor allRed = ScriptableObject.CreateInstance<Targetting_ByUnit_SideColor>();
            allRed.getAllies = true;
            allRed.getAllUnitSlots = false;
            allRed.Color = Pigments.Red;
            Ability dead = new Ability("As in Death", "AsInDeath_A");
            dead.Description = "Inflict 1 Mold on all enemy positions.\nTurn all Red enemies Grey.";
            dead.Effects = new EffectInfo[2];
            dead.Rarity = Rarity.GetCustomRarity("rarity5");
            dead.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMoldFieldEffect>(), 1, Targetting.Everything(true));
            dead.Effects[1] = Effects.GenerateEffect(turnGrey, 1, allRed);
            dead.Visuals = CustomVisuals.GetVisuals("Salt/Claws");
            dead.AnimationTarget = TargettingSelf_NotSlot.Create();
            dead.AddIntentsToTarget(Targetting.Everything(true), [Mold.Intent]);
            dead.AddIntentsToTarget(Targetting.AllAlly, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            dead.AddIntentsToTarget(allGrey, [IntentType_GameIDs.Mana_Modify.ToString()]);

            //ADD ENEMY
            clown.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                life.GenerateEnemyAbility(true),
                dead.GenerateEnemyAbility(true),
                special.GenerateEnemyAbility(true)
            });
            clown.AddEnemy(true, true);
        }
    }
}
