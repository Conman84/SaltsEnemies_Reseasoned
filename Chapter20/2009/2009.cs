using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class TwoThousandNine
    {
        public static void Add()
        {
            Enemy spinner = new Enemy("2009", "2009_EN")
            {
                Health = 13,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("2009Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("2009World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("2009Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("DeadPixel_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("DeadPixel_EN").deathSound,
            };
            spinner.PrepareEnemyPrefab("assets/enem3/2009_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/gib3/2009_Gibs.prefab").GetComponent<ParticleSystem>());
            
            spinner.enemy.enemyTemplate.m_Data.m_Renderer = spinner.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Face").Find("Outline").GetComponent<SpriteRenderer>();

            spinner.AddUnitType("Robot");

            //ROTARY
            PerformEffectPassiveAbility rotary = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            rotary._passiveName = "Rotary";
            rotary.m_PassiveID = "Rotary_PA";
            rotary.passiveIcon = ResourceLoader.LoadSprite("RotaryPassive.png");
            rotary._enemyDescription = "On being damaged, move all the way to the Left or Right.";
            rotary._characterDescription = rotary._enemyDescription;
            rotary.doesPassiveTriggerInformationPanel = true;
            rotary.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveAllTheWayOneSideEffect>(), 1, Slots.Self).SelfArray();
            rotary._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            rotary.conditions = Passives.Slippery.conditions;

            spinner.AddPassives(new BasePassiveAbilitySO[] { rotary });
            spinner.CombatExitEffects = Effects.GenerateEffect(SetMusicParameterByStringIfCasterValueEffect._Create("2009"), -1).SelfArray();

            GenericTargetting_BySlot_Index furthest = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            furthest.getAllies = true;
            furthest.slotPointerDirections = new int[] { 0, 4 };

            Ability breaker = new Ability("Breakdown", "Breakdown_A");
            breaker.Description = "Apply 6 Shield to the Furthest Left and Right enemy positions.";
            breaker.Rarity = Rarity.GetCustomRarity("rarity5");
            breaker.Effects = new EffectInfo[1];
            breaker.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, furthest);
            breaker.AddIntentsToTarget(furthest, [IntentType_GameIDs.Field_Shield.ToString()]);
            breaker.Visuals = CustomVisuals.GetVisuals("Salt/Gears");
            breaker.AnimationTarget = furthest;

            Ability classic = new Ability("The Classic", "TheClassic_A");
            classic.Description = "Deal 6 damage to the Opposing party member. This ability has random critical hits.\nMove to the Left or Right 3 times.";
            classic.Rarity = Rarity.GetCustomRarity("rarity5");
            classic.Effects = new EffectInfo[4];
            classic.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<CritDamageEffect>(), 6, Slots.Front);
            classic.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            classic.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            classic.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            classic.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            classic.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString()]);
            classic.Visuals = CustomVisuals.GetVisuals("Salt/Gunshot");
            classic.AnimationTarget = Slots.Front;

            StatusWithDamageEffect rupture = ScriptableObject.CreateInstance<StatusWithDamageEffect>();
            rupture.Status = StatusField.Ruptured;
            BaseCombatTargettingSO left = Slots.SlotTarget([0, -1, -2], false);
            BaseCombatTargettingSO right = Slots.SlotTarget([0, 1, 2], false);

            Ability bart_l = new Ability("Bartimaeus Left", "BartimaeusLeft_A");
            bart_l.Description = "Inflict 2 Ruptured on the Opposing, Left, and Far Left party members.\nIf they already were Ruptured, deal a Little damage to them.";
            bart_l.Rarity = Rarity.GetCustomRarity("rarity5");
            bart_l.Effects = new EffectInfo[1];
            bart_l.Effects[0] = Effects.GenerateEffect(rupture, 2, left);
            bart_l.AddIntentsToTarget(left, ["Status_Ruptured", "Damage_1_2"]);
            bart_l.Visuals = CustomVisuals.GetVisuals("Salt/Four");
            bart_l.AnimationTarget = left;

            Ability bart_r = new Ability("Bartimaeus Right", "BartimaeusRight_A");
            bart_r.Description = "Inflict 2 Ruptured on the Opposing, Right, and Far Right party members.\nIf they already were Ruptured, deal a Little damage to them.";
            bart_r.Rarity = Rarity.GetCustomRarity("rarity5");
            bart_r.Effects = new EffectInfo[1];
            bart_r.Effects[0] = Effects.GenerateEffect(rupture, 2, right);
            bart_r.AddIntentsToTarget(right, ["Status_Ruptured", "Damage_1_2"]);
            bart_r.Visuals = CustomVisuals.GetVisuals("Salt/Four");
            bart_r.AnimationTarget = right;


            //ADD ENEMY
            spinner.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                bart_l.GenerateEnemyAbility(true),
                classic.GenerateEnemyAbility(true),
                bart_r.GenerateEnemyAbility(true),
                breaker.GenerateEnemyAbility(true),
            });
            spinner.AddEnemy(true, true);
            spinner.enemy.AddToSynodPool();
        }
    }
}
