using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Celebration
    {
        public static void Add()
        {
            Enemy pumpkin = new Enemy("Celebration", "Celebration_EN")
            {
                Health = 33,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CelebrationIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CelebrationWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CelebrationDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Snound1/PumkinHit",
                DeathSound = "event:/Hawthorne/Snound1/PumkinDie",
                UnitTypes = ["FemaleID", "FemaleLooking"]
            };
            pumpkin.PrepareEnemyPrefab("Assets/ch_26/Celebration_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/ch_26/Celebration_Gibs.prefab").GetComponent<ParticleSystem>());

            ChangeCasterHealthColorBetweenColorsEffect redpurple = ScriptableObject.CreateInstance<ChangeCasterHealthColorBetweenColorsEffect>();
            redpurple._color1 = Pigments.Red;
            redpurple._color2 = Pigments.Purple;
            //JITERRY
            PerformEffectPassiveAbility pawsome = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            pawsome._passiveName = "Pawsome";
            pawsome.name = "Pawsome_RedPurple_PA";
            pawsome.m_PassiveID = "Pawsome_PA";
            pawsome.passiveIcon = ResourceLoader.LoadSprite("PawsomePassive.png");
            pawsome._enemyDescription = "On any party member manually moving, this enemy will change its health color from Red to Purple or vice versa.";
            pawsome._characterDescription = "On any enemy \"manually moving\" (this cant happen), this party member will change its health color from Red to Purple or vice versa.";
            pawsome.doesPassiveTriggerInformationPanel = true;
            pawsome.effects = Effects.GenerateEffect(redpurple, 1, Slots.Self).SelfArray();
            pawsome._triggerOn = new TriggerCalls[] { JitteryHandler.Call };
            pawsome.conditions = new EffectorConditionSO[0];
            pawsome.AddToPassiveDatabase();

            pumpkin.AddPassives(new BasePassiveAbilitySO[] { pawsome, Passives.SlipperyGenerator(3), Violent.Generate(3), Passives.OverexertGenerator(3) });

            Ability eidolon = new Ability("Pawsome_Eidolon_A");
            eidolon.Name = "Eidolon";
            eidolon.Description = "Deals a Barely Painful amount of damage to this enemy.";
            eidolon.Rarity = Rarity.CreateAndAddCustomRarityToPool("pawesome20", 20);
            eidolon.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Self)];
            eidolon.AddIntentsToTarget(Slots.Self, ["Damage_3_6"]);
            eidolon.Visuals = Visuals.Slap;
            eidolon.AnimationTarget = Slots.Self;

            Ability birthday = new Ability("Pawsome_Birthday_A");
            birthday.Name = "Birthday!";
            birthday.Description = "Deals a Mortal amount of indirect damage to this enemy.\nInflict 3 Fire on all party member positions.";
            birthday.Rarity = Rarity.GetCustomRarity("rarity5");
            birthday.Effects = [Effects.GenerateEffect(BasicEffects.Indirect, 20, Slots.Self), Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 3, Targetting.Everything(false))];
            birthday.AddIntentsToTarget(Slots.Self, ["Damage_16_20"]);
            birthday.AddIntentsToTarget(Targetting.Everything(false), ["Field_Fire"]);
            birthday.Visuals = CustomVisuals.GetVisuals("Salt/Smile");
            birthday.AnimationTarget = Slots.Self;

            AbilitySelector_Heaven nobirthday = ScriptableObject.CreateInstance<AbilitySelector_Heaven>();
            nobirthday._ComeHomeAbility = "Pawsome_Birthday_A";
            nobirthday._useAfterTurns = 3;
            pumpkin.AbilitySelector = nobirthday;

            //ADD ENEMY
            pumpkin.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                eidolon.GenerateEnemyAbility(true),
                birthday.GenerateEnemyAbility(true),
            });
            pumpkin.SilentAddEnemy(true, true);
            pumpkin.enemy.AddToSynodPool();
            pumpkin.enemy.AddToToysPool();
            pumpkin.enemy.AddToEcstasyPool();
        }
    }
}
