using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class NobodyGrave
    {
        public static void Add()
        {
            Enemy grave = new Enemy("Nobody's Grave", "NobodyGrave_EN")
            {
                Health = 20,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("GraveIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("GraveWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("GraveDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound,
            };
            grave.PrepareEnemyPrefab("assets/enemie/Grave_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/Grave_Gibs.prefab").GetComponent<ParticleSystem>());

            //Desecration
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility des = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            des._passiveName = "Desecration (12)";
            des.passiveIcon = ResourceLoader.LoadSprite("KarmaPassive.png");
            des._enemyDescription = "If this enemy has less than 12 health, it will perforn an extra ability \"Desecration\" each turn.";
            des.conditions = new List<EffectorConditionSO>(baseExtra.conditions != null ? baseExtra.conditions : new EffectorConditionSO[0]) { ScriptableObject.CreateInstance<DefenderCondition>() }.ToArray();
            Ability bonus = new Ability("Karma_Desecration_A");
            bonus.Name = "Desecration";
            bonus.Description = "Summon a Defender. Deal a Barely Painful amount of damage to this enemy.";
            SpawnEnemyByStringNameEffect defender = ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>();
            defender.enemyName = "Defender_EN";
            defender._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            bonus.Effects = new EffectInfo[2];
            bonus.Effects[0] = Effects.GenerateEffect(defender, 1, Slots.Self);
            bonus.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_SelfSlot);
            bonus.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_Spawn.ToString(), IntentType_GameIDs.Damage_3_6.ToString()]);
            bonus.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            bonus.AnimationTarget = Slots.Self;
            bonus.Rarity = Rarity.Impossible;
            AbilitySO ability = bonus.GenerateEnemyAbility(true).ability;
            des._extraAbility.ability = ability;

            grave.AddPassives(new BasePassiveAbilitySO[] { Passives.Inanimate, des, Passives.Withering });
            //NOTE: you should add the defender's passive to the glossary. it should be something like the bonus attack description in the main game, but its name shoudl be "Karma" and its description have, "If this enemy is below a certain amount of health," then the rest of the bonus attack description.

            //weathering
            Ability weathering = new Ability("Weathering", "Weathering_A");
            weathering.Rarity = Rarity.GetCustomRarity("rarity5");
            weathering.Description = "Inflict 10 Mold on this enemy's position and on the Opposing party member position.";
            weathering.Priority = Priority.Fast;
            weathering.Effects = new EffectInfo[2];
            weathering.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMoldFieldEffect>(), 10, Slots.Self);
            weathering.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMoldFieldEffect>(), 10, Slots.Front);
            weathering.AddIntentsToTarget(Slots.Self, Mold.Intent.SelfArray());
            weathering.AddIntentsToTarget(Slots.Front, [Mold.Intent]);
            weathering.Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;
            weathering.AnimationTarget = MultiTargetting.Create(Slots.Self, Slots.Front);

            //putrification
            Ability putrification = new Ability("Putrification", "Putrification_A");
            putrification.Rarity = weathering.Rarity;
            putrification.Description = "Inflict 6 Mold to the Left and Right enemy positions. \nInflict 3 Mold on the Left and Right party member positions.";
            putrification.Priority = Priority.Fast;
            putrification.Effects = new EffectInfo[2];
            putrification.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMoldFieldEffect>(), 6, Targeting.Slot_AllySides);
            putrification.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMoldFieldEffect>(), 3, Targeting.Slot_OpponentSides);
            putrification.AddIntentsToTarget(Slots.Sides, [Mold.Intent]);
            putrification.AddIntentsToTarget(Slots.LeftRight, [Mold.Intent]);
            putrification.AddIntentsToTarget(ScriptableObject.CreateInstance<EmptyTargetting>(), [Mold.Intent, Mold.Intent]);
            putrification.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            putrification.AnimationTarget = MultiTargetting.Create(Slots.Sides, Slots.LeftRight);

            //under
            Ability under = new Ability("Buried Under", "BuriedUnder_A");
            under.Rarity = weathering.Rarity;
            under.Description = "Inflict 1 Mold on All positions.";
            under.Priority = Priority.Fast;
            under.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMoldFieldEffect>(), 1, MultiTargetting.Create(Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], false), Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], true))).SelfArray();
            under.AddIntentsToTarget(Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], true), [Mold.Intent]);
            under.AddIntentsToTarget(Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], false), [Mold.Intent]);
            under.AddIntentsToTarget(ScriptableObject.CreateInstance<EmptyTargetting>(), [Mold.Intent, Mold.Intent, Mold.Intent]);
            under.Visuals = CustomVisuals.GetVisuals("Salt/Claws");
            under.AnimationTarget = MultiTargetting.Create(Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], true), Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], false));

            //ADD ENEMY
            grave.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                weathering.GenerateEnemyAbility(true),
                putrification.GenerateEnemyAbility(true),
                under.GenerateEnemyAbility(true)
            });
            grave.AddEnemy(true, true);
        }
    }
}
