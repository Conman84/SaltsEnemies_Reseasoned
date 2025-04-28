using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Sigil
    {
        public static void Add()
        {
            SigilManager.Add();
            SigilSongHandler.Setup();

            Enemy monolith = new Enemy("Sigil", "Sigil_EN")
            {
                Health = 30,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("SigilIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SigilWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SigilDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").deathSound,
                Priority = Priority.VeryFast
            };
            monolith.PrepareEnemyPrefab("assets/group4/Sigil/Sigil_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Sigil/Sigil_Gibs.prefab").GetComponent<ParticleSystem>());

            //PASSIVE
            SigilPassiveAbility sigil = ScriptableObject.CreateInstance<SigilPassiveAbility>();
            sigil._passiveName = "Sigil";
            sigil.passiveIcon = ResourceLoader.LoadSprite("sigilPassive.png");
            sigil._enemyDescription = "At the start of each turn, reset this enemy's Sigil.";
            sigil._characterDescription = "At the start of each turn, reset this party member's Sigil.";
            sigil.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(SigilManager.Sigil);
            sigil.m_PassiveID = SigilManager.Sigil;
            sigil.doesPassiveTriggerInformationPanel = false;
            sigil._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnStart };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("sigilPassive.png"), "Sigil", sigil._enemyDescription);

            monolith.AddPassives(new BasePassiveAbilitySO[] { sigil, Passives.Formless, Passives.Withering });

            //OFFENSE
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllies = true;
            allAlly.getAllUnitSlots = false;
            CasterStoredValueSetEffect value = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            value._valueName = SigilManager.Sigil;
            Ability offense = new Ability("Sigil_Offense_A")
            {
                Name = "Offensive Sigil",
                Description = "All enemies will deal 3 more damage this turn, until this enemy's next turn.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Sigil_10", 10),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(value, 2, allAlly),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SigilSongCheckEffect>(), 1, allAlly),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SigilEffect>(), 1, allAlly)
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals,
                AnimationTarget = allAlly,
            };
            offense.AddIntentsToTarget(allAlly, new string[] { SigilManager.AtkTxt, SigilManager.OtherUpAlt });

            //DEFENSE
            Ability defense = new Ability("Sigil_Defense_A")
            {
                Name = "Defensive Sigil",
                Description = "All enemies will take 50% less direct damage this turn, until this enemy's next turn.",
                Rarity = Rarity.GetCustomRarity("Sigil_10"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(value, 1, allAlly),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SigilSongCheckEffect>(), 1, allAlly),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SigilEffect>(), 0, allAlly)
                        },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Resolve_1_A").visuals,
                AnimationTarget = allAlly,
            };
            defense.AddIntentsToTarget(allAlly, new string[] { SigilManager.DefTxt, SigilManager.UpArrow });

            //SPECTRAL
            Ability spectral = new Ability("Sigil_Spectral_A")
            {
                Name = "Spectral Sigil",
                Description = "This enemy is immune to damage until its next turn.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(value, 3, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SigilSongCheckEffect>(), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SigilEffect>(), 2, Targeting.Slot_SelfSlot)
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                AnimationTarget = Targeting.Slot_SelfSlot,
            };
            spectral.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { SigilManager.Spectral });

            //PURE
            Ability pure = new Ability("Sigil_Pure_A")
            {
                Name = "Pure Sigil",
                Description = "This enemy does nothing.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Sigil_1", 10),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(value, 4, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SigilSongCheckEffect>(), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SigilEffect>(), 3, Targeting.Slot_SelfSlot)
                        },
                Visuals = null,
                AnimationTarget = Targeting.Slot_SelfSlot,
            };
            pure.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString() });

            //ADD ENEMY
            monolith.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                offense.GenerateEnemyAbility(true),
                defense.GenerateEnemyAbility(true),
                spectral.GenerateEnemyAbility(true),
                pure.GenerateEnemyAbility(true)
            });
            monolith.AddEnemy(true, true);
        }
    }
}
