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
            leftmost._offset = [0];
            Targetting_Furthest_Unit_To_Side rightmost = ScriptableObject.CreateInstance<Targetting_Furthest_Unit_To_Side>();
            rightmost._rightmost = true;
            rightmost.getAllies = false;
            rightmost._offset = [0];
            GenericTargetting_BySlot_Index center = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            center.getAllies = false;
            center.slotPointerDirections = new int[] { 2 };

            Targetting_Furthest_Unit_To_Side left_left = ScriptableObject.CreateInstance<Targetting_Furthest_Unit_To_Side>();
            left_left._leftmost = true;
            left_left.getAllies = false;
            left_left._offset = [1, 2, 3, 4];
            Targetting_Furthest_Unit_To_Side right_right = ScriptableObject.CreateInstance<Targetting_Furthest_Unit_To_Side>();
            right_right._rightmost = true;
            right_right.getAllies = false;
            right_right._offset = [1, 2, 3, 4];

            GenericTargetting_BySlot_Index center_left = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            center_left.getAllies = false;
            center_left.slotPointerDirections = new int[] { 1, 0 };
            GenericTargetting_BySlot_Index center_right = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            center_right.getAllies = false;
            center_right.slotPointerDirections = new int[] { 3, 4 };

            RemoveFieldEffectEffect rem_slip = ScriptableObject.CreateInstance<RemoveFieldEffectEffect>();
            rem_slip._field = Slip.Object;


            Ability perfect_left = new Ability("Perfect Left", "angel_left_A");
            perfect_left.Description = "Deal 0 damage to the Leftmost party member.\nDamage directly spreads Right increasing by 3 each time.";
            perfect_left.Rarity = Rarity.GetCustomRarity("rarity5");
            perfect_left.Effects = [Effects.GenerateEffect(right, 3, leftmost)];
            perfect_left.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            perfect_left.AddIntentsToTarget(leftmost, ["Damage_1_2"]);
            perfect_left.AddIntentsToTarget(left_left, [FallColor.Intent, "Damage_3_6", "Damage_7_10", "Damage_11_15"]);
            perfect_left.Visuals = CustomVisuals.GetVisuals("Salt/Gears");
            perfect_left.AnimationTarget = leftmost;

            Ability perfect_right = new Ability("Perfect Right", "angel_right_A");
            perfect_right.Description = "Deal 0 damage to the Rightmost party member.\nDamage directly spreads Left increasing by 3 each time.";
            perfect_right.Rarity = Rarity.GetCustomRarity("rarity5");
            perfect_right.Effects = [Effects.GenerateEffect(left, 3, rightmost)];
            perfect_left.AddIntentsToTarget(right_right, [FallColor.Intent, "Damage_3_6", "Damage_7_10", "Damage_11_15"]);
            perfect_left.AddIntentsToTarget(rightmost, ["Damage_1_2"]);
            perfect_left.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            perfect_left.Visuals = CustomVisuals.GetVisuals("Salt/Gears");
            perfect_left.AnimationTarget = rightmost;

            Ability perfect_center = new Ability("Perfect Center", "angel_center_A");
            perfect_center.Description = "Deal 0 damage to the Central party member position.\nDamage directly spreads to adjacent units increasing by 5 each time.";
            perfect_center.Rarity = Rarity.GetCustomRarity("rarity5");
            perfect_center.Effects = [Effects.GenerateEffect(both, 5, center)];
            perfect_center.AddIntentsToTarget(center_left, [FallColor.Intent, "Damage_3_6", "Damage_7_10", FallColor.StopIntent]);
            perfect_center.AddIntentsToTarget(center, ["Damage_1_2"];
            perfect_center.AddIntentsToTarget(center_right, [FallColor.Intent, "Damage_3_6", "Damage_7_10"]);

            //ADD ENEMY
            mechanism.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            mechanism.AddEnemy(true, true);
        }
    }
}
