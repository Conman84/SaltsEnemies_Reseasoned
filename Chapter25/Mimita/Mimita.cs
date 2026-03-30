using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Mimita
    {
        public static void Add()
        {
            Enemy mimita = new Enemy("Mimita", "Mimita_EN")
            {
                Health = 3,
                HealthColor = Pigments.Red,
                Size = 3,
                CombatSprite = ResourceLoader.LoadSprite("MimitaIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MimitaIcon.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MimitaIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("PersonalAngel_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("PersonalAngel_EN").deathSound,
            };
            mimita.PrepareEnemyPrefab("Assets/Abyss/Mimita_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Abyss/Mimita_Gibs.prefab").GetComponent<ParticleSystem>());

            //desperate
            PerformEffectImmediatePassiveAbility desperate = ScriptableObject.CreateInstance<PerformEffectImmediatePassiveAbility>();
            desperate._passiveName = "Desperate (3)";
            desperate.m_PassiveID = "Desperate_PA";
            desperate.passiveIcon = ResourceLoader.LoadSprite("Desperate.png");
            desperate._characterDescription = "On taking any damage, 95% chance to apply 3 Determined to self.";
            desperate._enemyDescription = "On taking any damage, 95% chance to apply 3 Determined to self.";
            desperate.doesPassiveTriggerInformationPanel = true;
            PercentageEffectorCondition desperateChance = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            desperateChance.triggerPercentage = 95;
            desperate.conditions = new EffectorConditionSO[1]
            {
                desperateChance
            };
            desperate.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 3, Targeting.Slot_SelfSlot),
            };
            desperate._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };
            desperate.name = "Desperate_95_PA";

            //lovely
            LovelyPassive lovely = ScriptableObject.CreateInstance<LovelyPassive>();
            lovely.name = "Lovely_PA";
            lovely._passiveName = "Lovely";
            lovely.m_PassiveID = "Lovely_PA";
            lovely.passiveIcon = ResourceLoader.LoadSprite("LovelyPassive.png");
            lovely._enemyDescription = "This enemy will use all of its abilities every round.";
            lovely._characterDescription = "you might be rettartded";
            lovely._triggerOn = [];
            lovely.effects = [];
            lovely.conditions = [];

            mimita.AddPassives(new BasePassiveAbilitySO[] { desperate, Passives.Infantile, lovely, Passives.OverexertGenerator(3), Passives.Withering });

            Ability death = new Ability("The God Of Life And Death", "Mimita_Death_A");
            death.Description = "Take a Barely Painful amount of damage.";
            death.Rarity = Rarity.Common;
            death.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, TargettingSelf_NotSlot.Create())];
            death.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), ["Damage_3_6"]);
            death.AnimationTarget = TargettingSelf_NotSlot.Create();
            death.Visuals = Visuals.Headshot;

            Ability life = new Ability("My Darling, For You", "Mimita_Life_A");
            life.Description = "Spawn as many \"toys\" as possible.";
            life.Rarity = Rarity.Common;
            life.Effects = [Effects.GenerateEffect(ToysPool.Effect, 5, Slots.Self)];
            life.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), ["Other_Spawn"]);
            life.AnimationTarget = TargettingSelf_NotSlot.Create();
            life.Visuals = Visuals.Innocence;

            //ADD ENEMY
            mimita.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                death.GenerateEnemyAbility(true),
                life.GenerateEnemyAbility(true)
            });
            mimita.AddEnemy();
        }
    }
}
