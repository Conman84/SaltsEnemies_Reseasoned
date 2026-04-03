using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Hunter
    {
        public static void Add()
        {
            Enemy hunting = new Enemy("Hunter", "Hunter_EN")
            {
                Health = 42,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("HunterIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("HunterWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("HunterDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/HunterHurt",
                DeathSound = "event:/Hawthorne/Die/HunterDie"
            };
            hunting.PrepareEnemyPrefab("assets/group4/Hunter/Hunter_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Hunter/Hunter_Gibs.prefab").GetComponent<ParticleSystem>());

            //hunting
            HuntingPassiveAbility hunter = ScriptableObject.CreateInstance<HuntingPassiveAbility>();
            hunter._passiveName = "Horrifying (13)";
            hunter.passiveIcon = ResourceLoader.LoadSprite("hunterpassive.png");
            hunter.m_PassiveID = "Horrifying_PA";
            hunter._enemyDescription = "At the end of each round, if the Opposing party member has Terror deal an Deadly amount of damage to them.\nOn being directly damaged, inflict Terror on the Opposing party member.";
            hunter._characterDescription = "At the end of each round, if the Opposing enemy has Terror deal 15 damage to them.\nOn being directly damaged, inflict Terror on the Opposing enemy.";
            hunter.doesPassiveTriggerInformationPanel = true;
            hunter.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyTerrorEffect>(), 1, Slots.Front).SelfArray();
            hunter._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
            hunter.Amount = 13;

            hunting.AddPassives(new BasePassiveAbilitySO[] { Passives.Constricting, hunter });
            hunting.AddUnitType("Bird");

            //nest
            Ability nest = new Ability("Nest", "Hunter_Nest_A");
            nest.Description = "Remove all Shield from this enemy's position and then apply 6 Shield to it.\nDeal a Little damage to the Opposing party member and force them to move to the Left or Right 3 times.";
            nest.Rarity = Rarity.GetCustomRarity("rarity5");
            nest.Effects = new EffectInfo[4];
            nest.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllShieldsEffect>(), 1, Slots.Self);
            nest.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, Slots.Self);
            nest.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front);
            nest.Effects[3] = Effects.GenerateEffect(SubActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
            }), 1, Slots.Front);
            nest.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Rem_Field_Shield.ToString(), IntentType_GameIDs.Field_Shield.ToString()]);
            nest.AddIntentsToTarget(Slots.Front, new string[]
            {
                IntentType_GameIDs.Damage_1_2.ToString(),
                IntentType_GameIDs.Swap_Sides.ToString(),
            });
            nest.Visuals = CustomVisuals.GetVisuals("Salt/Ribbon");
            nest.AnimationTarget = MultiTargetting.Create(Slots.Self, Slots.Front);

            //patience
            Ability patience = new Ability("Patience", "Hunter_Patience_A");
            patience.Description = "If either the Left or Right party members are at full health, deal an Agonizing amount of damage to both of them.";
            patience.Rarity = Rarity.GetCustomRarity("rarity5");
            patience.Effects = new EffectInfo[3];
            patience.Effects[0] = Effects.GenerateEffect(BasicEffects.GetVisuals("Crush_A", false, Slots.LeftRight), 1, null, AnyTargetsAtMaxHealthCondition.Create(Slots.LeftRight));
            patience.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.LeftRight, AnyTargetsAtMaxHealthCondition.Create(Slots.LeftRight));
            patience.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 1, Slots.Self, BasicEffects.DidThat(false, 2));
            patience.AddIntentsToTarget(Slots.LeftRight, [IntentType_GameIDs.Misc_Hidden.ToString(), IntentType_GameIDs.Damage_3_6.ToString()]);
            patience.Visuals = null;
            patience.AnimationTarget = Slots.Self;

            //track
            StatusEffectCheckerEffect hasTerror = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            hasTerror._status = Terror.Object;
            hasTerror._allTargetsHaveStatusEffect = false;
            Ability track = new Ability("Hunter_TrackDown_A")
            {
                Name = "Track Down",
                Description = "This enemy moves to the Left or Right, and will always attempt to move in front of a target with Terror if possible.\nIf the Opposing party member does not have Terror, deal a Painful amount of damage to them.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<HuntDownEffect>(), 1, LeftRightTargetting.Create(false, true)),
                    Effects.GenerateEffect(hasTerror, 1, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Gaze", false, Slots.Front), 1, Slots.Front, BasicEffects.DidThat(false, 1)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Front, BasicEffects.DidThat(false, 2))
                },
                Visuals = null,
                AnimationTarget = MultiTargetting.Create(Slots.Self, Slots.LeftRight),
            };
            track.AddIntentsToTarget(LeftRightTargetting.Create(false, true), [IntentType_GameIDs.Misc_Hidden.ToString()]);
            track.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);

            //ADD ENEMY
            hunting.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                nest.GenerateEnemyAbility(true),
                patience.GenerateEnemyAbility(true),
                track.GenerateEnemyAbility(true)
            });
            hunting.AddEnemy(true, true);
            hunting.enemy.AddToSynodPool();
        }
    }
}
