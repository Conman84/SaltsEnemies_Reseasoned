using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class MechanicalAngel
    {
        public static void Add()
        {
            Enemy mechanism = new Enemy("Mechanical Angel", "MechanicalAngel_EN")
            {
                Health = 39,
                HealthColor = Pigments.SplitPigment(Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple),
                CombatSprite = ResourceLoader.LoadSprite("MechanismIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MechanismWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MechanismDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("War_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("War_EN").deathSound,
            };
            mechanism.PrepareEnemyPrefab("Assets/Abyss/Mechanism_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Abyss/Puppet_Gibs.prefab").GetComponent<ParticleSystem>());

            //nylon
            PerformEffectPassiveAbility nylon = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            nylon._passiveName = "Nylon (3)";
            nylon.m_PassiveID = "Nylon_PA";
            nylon.name = "Nylon_3_PA";
            nylon.passiveIcon = ResourceLoader.LoadSprite("NylonPassive.png");
            nylon._enemyDescription = "On being directly damaged, apply 3 Slip on the Opposing position.";
            nylon._characterDescription = nylon._enemyDescription;
            nylon.doesPassiveTriggerInformationPanel = false;
            nylon.effects = Effects.GenerateEffect(CasterRootActionEffect.Create([Effects.GenerateEffect(ScriptableObject.CreateInstance<NylonPassiveEffect>()), Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 3, Slots.Front)]), 1, Slots.Self).SelfArray();
            nylon._triggerOn = [TriggerCalls.OnDirectDamaged];

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


            mechanism.AddPassives(new BasePassiveAbilitySO[] { nylon, escape });

            DirectCascadeIncreaseByEntryEffect left = ScriptableObject.CreateInstance<DirectCascadeIncreaseByEntryEffect>();
            left._doLeft = true;
            DirectCascadeIncreaseByEntryEffect right = ScriptableObject.CreateInstance<DirectCascadeIncreaseByEntryEffect>();
            right._doRight = true;
            DirectCascadeIncreaseByEntryEffect both = ScriptableObject.CreateInstance<DirectCascadeIncreaseByEntryEffect>();
            both._doLeft = true;
            both._doRight = true;

            Targetting_Furthest_Unit_To_Side leftmost = ScriptableObject.CreateInstance<Targetting_Furthest_Unit_To_Side>();
            leftmost._leftmost = true;
            leftmost.getAllies = false;
            Targetting_Furthest_Unit_To_Side rightmost = ScriptableObject.CreateInstance<Targetting_Furthest_Unit_To_Side>();
            rightmost._leftmost = false;
            rightmost.getAllies = false;
            GenericTargetting_BySlot_Index center = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            center.getAllies = false;
            center.slotPointerDirections = new int[] { 2 };

            RemoveFieldEffectEffect rem_slip = ScriptableObject.CreateInstance<RemoveFieldEffectEffect>();
            rem_slip._field = Slip.Object;




            //ADD ENEMY
            mechanism.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            mechanism.AddEnemy(true, true);
        }
    }
}
