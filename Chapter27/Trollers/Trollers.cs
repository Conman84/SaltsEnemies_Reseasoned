using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Trollers
    {
        public static void Add()
        {
            Add_Help();
            Add_Reckoner();
        }
        public static void Add_Help()
        {
            Enemy troller = new Enemy("HELP", "Help_Troller_EN")
            {
                Health = 30,
                HealthColor = Pigments.Red,
                Priority = Priority.Slow,
                CombatSprite = ResourceLoader.LoadSprite("HelpIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("HelpWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("HelpDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Delusion_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Delusion_EN").deathSound,
            };
            troller.PrepareEnemyPrefab("Assets/ch_27/Help_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/ch_27/Help_Gibs.prefab").GetComponent<ParticleSystem>());

            //reborn
            PerformEffectPassiveAbility reborn = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            reborn.name = "Reborn_Reckoner";
            reborn._passiveName = "Reborn";
            reborn.m_PassiveID = Passives.RebornToInHerImage.m_PassiveID;
            reborn.passiveIcon = ResourceLoader.LoadSprite("RebornRedPurplePassive.png");
            reborn._characterDescription = "idfk";
            reborn._enemyDescription = "On being directly damaged, this enemy is reborn as A Reckoner.";
            reborn.conditions = Passives.RebornToInHerImage.conditions;
            reborn._triggerOn = Passives.RebornToInHerImage._triggerOn;
            CasterTransformByStringEffect born = ScriptableObject.CreateInstance<CasterTransformByStringEffect>();
            born.enemy = "Reckoner_Troller_EN";
            born._maintainTimelineAbilities = true;
            born._fullyHeal = false;
            born._maintainMaxHealth = true;
            reborn.effects = [
                Effects.GenerateEffect(born, 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<FixCasterTimelineIntentsEffect>(), 1, Slots.Self),
                ];

            //vivacious
            PerformEffectPassiveAbility viv = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            viv.name = "Vivacious_2_PA";
            viv._passiveName = "Vivacious (2)";
            viv.m_PassiveID = "Vivacious_PA";
            viv.passiveIcon = ResourceLoader.LoadSprite("VivaciousPassive.png");
            viv._characterDescription = "At the end of each round, move Left or Right twice.";
            viv._enemyDescription = viv._characterDescription;
            viv.conditions = [];
            viv._triggerOn = [TriggerCalls.OnRoundFinished];
            viv.effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                ];

            troller.AddPassives(new BasePassiveAbilitySO[] { reborn, viv, Passives.Absorb });

            Ability emuls = new Ability("Emulsion", "Troller_Emulsion_A");
            emuls.Description = "Deals a Painful amount of damage and inflicts 2 Magnetism on the Left and Right enemies.";
            emuls.Rarity = Rarity.Common;
            emuls.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Sides),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMagnetismEffect>(), 2, Slots.Sides),
                ];
            emuls.AddIntentsToTarget(Slots.Sides, ["Damage_3_6", Magnetism.Intent]);
            emuls.AnimationTarget = Slots.Sides;
            emuls.Visuals = Visuals.Intrusion;

            Ability gravi = new Ability("Gravipulsion", "Troller_Gravipulsion_A");
            gravi.Description = "Consume 3 Pigment of this enemy's health color.\nInflict 5 Magnetism and 2 Dodge on this enemy.";
            gravi.Rarity = Rarity.Common;
            gravi.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeAllTargetHealthManaEffect>(), 3, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMagnetismEffect>(), 5, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 2, Slots.Self),
                ];
            gravi.AddIntentsToTarget(Slots.Self, ["Mana_Consume", Magnetism.Intent, Dodge.Intent]);
            gravi.AnimationTarget = Slots.Self;
            gravi.Visuals = Visuals.Crush;

            Ability neru = new Ability("Nerulsion", "Troller_Nerulsion_A");
            neru.Description = "Deal a Little damage to this and the Left and Right enemies.\nInflict 2 Ruptured on the Left, Right, and Opposing party members.";
            neru.Rarity = Rarity.Common;
            neru.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_SelfAndSides),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.FrontLeftRight),
                ];
            neru.AddIntentsToTarget(Targeting.Slot_SelfAndSides, ["Damage_1_2"]);
            neru.AddIntentsToTarget(Slots.FrontLeftRight, ["Status_Ruptured"]);
            neru.AnimationTarget = MultiTargetting.Create(Targeting.Slot_SelfAll_AndSides, Slots.FrontLeftRight);
            neru.Visuals = CustomVisuals.GetVisuals("Salt/Shatter");


            //ADD ENEMY
            troller.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                emuls.GenerateEnemyAbility(true),
                gravi.GenerateEnemyAbility(true),
                neru.GenerateEnemyAbility(true),
            });
            troller.AddEnemy(true, true);
            troller.enemy.AddToEcstasyPool();
            troller.enemy.AddToToysPool();
        }
        public static void Add_Reckoner()
        {
            Enemy troller = new Enemy("RECKONER", "Reckoner_Troller_EN")
            {
                Health = 30,
                HealthColor = Pigments.Purple,
                Priority = Priority.Slow,
                CombatSprite = ResourceLoader.LoadSprite("ReckonerIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReckonerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReckonerDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Delusion_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Delusion_EN").deathSound,
            };
            troller.PrepareEnemyPrefab("Assets/ch_27/Reckoner_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/ch_27/Reckoner_Gibs.prefab").GetComponent<ParticleSystem>());

            //reborn
            PerformEffectPassiveAbility reborn = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            reborn.name = "Reborn_Help";
            reborn._passiveName = "Reborn";
            reborn.m_PassiveID = Passives.RebornToInHerImage.m_PassiveID;
            reborn.passiveIcon = ResourceLoader.LoadSprite("RebornRedPurplePassive.png");
            reborn._characterDescription = "idfk";
            reborn._enemyDescription = "On being directly damaged, this enemy is reborn as The Help.";
            reborn.conditions = Passives.RebornToInHerImage.conditions;
            reborn._triggerOn = Passives.RebornToInHerImage._triggerOn;
            CasterTransformByStringEffect born = ScriptableObject.CreateInstance<CasterTransformByStringEffect>();
            born.enemy = "Help_Troller_EN";
            born._maintainTimelineAbilities = true;
            born._fullyHeal = false;
            born._maintainMaxHealth = true;
            reborn.effects = [
                Effects.GenerateEffect(born, 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<FixCasterTimelineIntentsEffect>(), 1, Slots.Self),
                ];

            troller.AddPassives(new BasePassiveAbilitySO[] { reborn, Passives.Skittish2, Passives.Absorb });

            Ability emuls = new Ability("Emulation", "Troller_Emulation_A");
            emuls.Description = "Deals a Painful amount of damage and inflicts 2 Magnetism on the Left and Right party members.";
            emuls.Rarity = Rarity.Common;
            emuls.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.LeftRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMagnetismEffect>(), 2, Slots.LeftRight),
                ];
            emuls.AddIntentsToTarget(Slots.LeftRight, ["Damage_3_6", Magnetism.Intent]);
            emuls.AnimationTarget = Slots.LeftRight;
            emuls.Visuals = Visuals.Intrusion;

            Ability gravi = new Ability("Gravipulation", "Troller_Gravipulation_A");
            gravi.Description = "Consume 3 Pigment of the Opposing party member's health color.\nInflict 5 Magnetism and 2 Dodge on the Opposing party member.";
            gravi.Rarity = Rarity.Common;
            gravi.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeAllTargetHealthManaEffect>(), 3, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMagnetismEffect>(), 5, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 2, Slots.Front),
                ];
            gravi.AddIntentsToTarget(Slots.Front, ["Mana_Consume", Magnetism.Intent, Dodge.Intent]);
            gravi.AnimationTarget = Slots.Front;
            gravi.Visuals = Visuals.Crush;

            Ability neru = new Ability("Nerulation", "Troller_Nerulation_A");
            neru.Description = "Deal a Little damage to the Left, Right, and Opposing party members.\nInflict 2 Ruptured on the this and the Left and Right enemies.";
            neru.Rarity = Rarity.Common;
            neru.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.FrontLeftRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Targeting.Slot_SelfAndSides),
                ];
            neru.AddIntentsToTarget(Slots.FrontLeftRight, ["Damage_1_2"]);
            neru.AddIntentsToTarget(Targeting.Slot_SelfAndSides, ["Status_Ruptured"]);
            neru.AnimationTarget = MultiTargetting.Create(Targeting.Slot_SelfAll_AndSides, Slots.FrontLeftRight);
            neru.Visuals = CustomVisuals.GetVisuals("Salt/Shatter");


            //ADD ENEMY
            troller.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                emuls.GenerateEnemyAbility(true),
                gravi.GenerateEnemyAbility(true),
                neru.GenerateEnemyAbility(true),
            });
            troller.AddEnemy(true, true);
            troller.enemy.AddToEcstasyPool();
            troller.enemy.AddToToysPool();
        }
    }
}
