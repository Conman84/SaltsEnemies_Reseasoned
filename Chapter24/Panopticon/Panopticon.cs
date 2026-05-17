using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Panopticon
    {
        public static void Add()
        {
            Enemy panopticon = new Enemy("Panopticon", "Panopticon_EN")
            {
                Health = 34,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("PanopticonIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PanopticonWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PanopticonDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("RealisticTank_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("RealisticTank_EN").deathSound,
            };
            panopticon.PrepareEnemyPrefab("Assets/wip5/Panopticon_Wip_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Panopticon_Wip_Gibs.prefab").GetComponent<ParticleSystem>());

            //HETEROCHROMIA
            PerformEffectPassiveAbility colors = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            colors._passiveName = "Heterochromia";
            colors.m_PassiveID = "Heterochromia_PA";
            colors.passiveIcon = ResourceLoader.LoadSprite("Hemochromia.png");
            colors._enemyDescription = "Upon receiving any kind of damage, randomize this enemy's health colour.";
            colors._characterDescription = "Upon receiving any kind of damage, randomize this party member's health colour.";
            ChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
                        Pigments.Blue,
                        Pigments.Red,
                        Pigments.Yellow,
                        Pigments.Purple
            };
            colors.effects = new EffectInfo[]
            {
                        Effects.GenerateEffect((EffectSO) randomize, 1, Slots.Self)
            };
            colors._triggerOn = new TriggerCalls[]
            {
                        TriggerCalls.OnDamaged
            };

            //commissioner
            PerformEffectPassiveAbility commissioner = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            commissioner.name = "Commissioner_PA";
            commissioner._passiveName = "Commissioner";
            commissioner.passiveIcon = ResourceLoader.LoadSprite("ComissionerPassive.png");
            commissioner._enemyDescription = "On being damaged, force the Opposing party member to perform this enemy's first action.\nIf successful, remove that action and give this enemy another one.";
            //ch desc
            commissioner.m_PassiveID = "Commissioner_PA";
            commissioner.doesPassiveTriggerInformationPanel = true;
            commissioner._triggerOn = [TriggerCalls.OnDirectDamaged];
            commissioner.effects = [
                Effects.GenerateEffect(ComissionerEffect.Create([
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveFirstCasterActionEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self)
                    ]), 1, Slots.Front),
                ];
            commissioner.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<HasTurnsCondition>() }.ToArray();

            //escapist
            PerformEffectPassiveAbility escape = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            escape.name = "Escapist_PA";
            escape._passiveName = "Escapist";
            escape.passiveIcon = ResourceLoader.LoadSprite("EscapistPassive.png");
            escape.m_PassiveID = "Escapist_PA";
            escape._enemyDescription = "On using an ability, move to a random unoccupied position.";
            escape._characterDescription = escape._enemyDescription;
            escape._triggerOn = [TriggerCalls.OnAbilityUsed];
            escape.conditions = [];
            escape.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToRandomEmptyTileEffect>(), 1, Slots.Self)];
            //escape.AddToPassiveDatabase();

            panopticon.AddPassives([colors, commissioner, escape]);


            Ability left = new Ability("Escapee On The West Side Of The Gate", "Panopticon_Left_A");
            left.Description = "Deal a Painful amount of damage to the Left party member.\nGain 1 Ruptured and consume 1 random Pigment.";
            left.Rarity = Rarity.GetCustomRarity("rarity5");
            left.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Left),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, Slots.Self)];
            left.AddIntentsToTarget(Slots.Left, ["Damage_3_6"]);
            left.AddIntentsToTarget(Slots.Self, ["Status_Ruptured", "Mana_Consume"]);
            left.AnimationTarget = Slots.Left;
            left.Visuals = Visuals.Takedown;

            Ability right = new Ability("Detainee On The East Side Of The Gate", "Panopticon_Right_A");
            right.Description = "Gain 1 Ruptured.\nDeal a Painful amount of damage to the Right party member and consume 1 random Pigment.";
            right.Rarity = left.Rarity;
            right.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Right),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, Slots.Self),];
            right.AddIntentsToTarget(Slots.Self, ["Status_Ruptured"]);
            right.AddIntentsToTarget(Slots.Right, ["Damage_3_6"]);
            right.AddIntentsToTarget(Slots.Self, ["Mana_Consume"]);
            right.AnimationTarget = Slots.Right;
            right.Visuals = Visuals.Takedown;

            Ability fall = new Ability("1989 The Wall Falls", "Panopticon_Fall_A");
            fall.Description = "Consume all Pigment of this enemy's health color and take a Painful amount of damage.\nAt the start of the next turn, deal a Painful amount of damage to all currently unoccupied party member positions.";
            fall.Rarity = left.Rarity;
            fall.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeAllCasterHealthManaEffect>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 4, Targetting_ByUnit_Side_Empty.Create(false))];
            fall.AddIntentsToTarget(Slots.Self, ["Mana_Consume", "Damage_3_6"]);
            fall.AddIntentsToTarget(Targetting_ByUnit_Side_Empty.Create(false), ["Damage_3_6", "Damage_Delay"]);
            fall.AnimationTarget = Slots.Self;
            fall.Visuals = CustomVisuals.GetVisuals("Salt/Gears");

            //ADD ENEMY
            panopticon.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                left.GenerateEnemyAbility(true),
                fall.GenerateEnemyAbility(true),
                right.GenerateEnemyAbility(true)
            });
            panopticon.SilentAddEnemy(true, true);
            panopticon.enemy.AddToSynodPool();
            panopticon.enemy.AddToEcstasyPool();
        }
    }
}
