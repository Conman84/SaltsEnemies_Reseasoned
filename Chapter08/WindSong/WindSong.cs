using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class WindSong
    {
        public static void Add()
        {
            WindSongManager.Setup();

            Enemy windsong = new Enemy("Wind Song", "WindSong_EN")
            {
                Health = 42,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("WindSongIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WindSongDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WindSongWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/BirdSound",
                DeathSound = "event:/Hawthorne/Hurt/BirdSound",
            };
            windsong.PrepareEnemyPrefab("assets/group4/WindSong/WindSong_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/WindSong/WindSong_Gibs.prefab").GetComponent<ParticleSystem>());

            //CODA
            PerformDoubleEffectPassiveAbility coda = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
            coda._passiveName = "Coda";
            coda.passiveIcon = ResourceLoader.LoadSprite("CodaIcon.png");
            coda._enemyDescription = "On death, apply 3 Dodge, 2 Haste, and 1 Hollow to every other enemy.";
            coda._characterDescription = "On death, apply 3 Dodge, 2 Haste, and 1 Hollow to every other party member.";
            coda.m_PassiveID = "Coda_PA";
            coda.doesPassiveTriggerInformationPanel = true;
            coda._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllies = true;
            allAlly.getAllUnitSlots = false;
            allAlly.ignoreCastSlot = true;
            coda.effects = new EffectInfo[]
            {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<WindSongEffect>(), 1, Targeting.Slot_SelfSlot),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 3, allAlly),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyHasteEffect>(), 2, allAlly),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyHollowEffect>(), 1, allAlly),
            };
            coda._secondDoesPerformPopUp = false;
            coda._secondTriggerOn = new TriggerCalls[] { TriggerCalls.Count };
            coda._secondEffects = new EffectInfo[]
            {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<WindSongEffect>(), 1, Targeting.Slot_SelfSlot)
            };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("CodaIcon.png"), "Coda", coda._enemyDescription);

            //ADDPASSIVES
            windsong.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, Passives.Formless, coda });
            windsong.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<WindSongExitEffect>()) };
            windsong.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<WindSongEnterEffect>()) };

            //THROTTLE
            DamageEffect OnKill = ScriptableObject.CreateInstance<DamageEffect>();
            OnKill._returnKillAsSuccess = true;
            Ability throttle = new Ability("Throttle_A")
            {
                Name = "Throttle",
                Description = "Deal a Deadly amount of damage to the Opposing party member and heals them a moderate amount of health. If this attack kills, it doesn't, and applies Focused and Cursed on them.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("WindSong_1", 1),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(OnKill, 13, Targeting.Slot_Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<WindSongEffect>(), 1, Targeting.Slot_Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 5, Targeting.Slot_Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Targeting.Slot_Front, BasicEffects.DidThat(true, 3)),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Targeting.Slot_Front, BasicEffects.DidThat(true, 4))
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Piano"),
                AnimationTarget = Targeting.Slot_Front
            };
            throttle.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_11_15.ToString(), IntentType_GameIDs.Heal_5_10.ToString(), IntentType_GameIDs.Status_Focused.ToString(), IntentType_GameIDs.Status_Cursed.ToString() });

            //CODA
            Ability finale = new Ability("Coda_A")
            {
                Name = "Coda",
                Description = "\"The closing is near.\"\n",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("WindSong_20", 20),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<WindSongEffect>(), 1, Targeting.Slot_SelfSlot)
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Coda"),
                AnimationTarget = Targeting.Slot_SelfSlot
            };
            finale.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { WindSongManager.Intent });

            //ADD ENEMY
            windsong.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                throttle.GenerateEnemyAbility(true),
                finale.GenerateEnemyAbility(true)
            });
            windsong.AddEnemy(true, true);
        }
    }
}
