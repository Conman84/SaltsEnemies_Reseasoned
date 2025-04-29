using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using SaltsEnemies_Reseasoned;
using UnityEngine.UI;


/*--------------------------I DID ALL THESE-------------------------------*/
//When adding abilities and passives, call them directly out of IllusionHandler. for instance, IllusionHandler.Illusion, IllusionHandler.Drain, etc
//Has to be done this way bc the Delusion's kit is super recursive
//note: remove the delusion's entry effect, also the fakegutted passive, and just give it 20 health. also i reworked some of the moves.

namespace SaltEnemies_Reseasoned
{
    public class ShadowEnterEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public bool entryAsPercentage;

        [SerializeField]
        public bool _directHeal = true;

        [SerializeField]
        public bool _onlyIfHasHealthOver0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPermanentGuttedEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance <ShadowHealEffect>(), 1, Targeting.Slot_SelfSlot)
            }, caster));
            return true;
        }
    }
    public class PermenantStatusEffect_Apply_Effect : EffectSO
    {
        [Header("Status")]
        public StatusEffect_SO _Status;

        [Header("Data")]
        public bool _ApplyToFirstUnit;

        public bool _JustOneRandomTarget;

        public bool _RandomBetweenPrevious;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (_Status == null)
            {
                return false;
            }

            if (_ApplyToFirstUnit || _JustOneRandomTarget)
            {
                List<TargetSlotInfo> list = new List<TargetSlotInfo>();
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    if (targetSlotInfo.HasUnit)
                    {
                        list.Add(targetSlotInfo);
                        if (_ApplyToFirstUnit)
                        {
                            break;
                        }
                    }
                }

                if (list.Count > 0)
                {
                    int index = UnityEngine.Random.Range(0, list.Count);
                    exitAmount += ApplyStatusEffect(list[index].Unit, entryVariable);
                }
            }
            else
            {
                for (int j = 0; j < targets.Length; j++)
                {
                    if (targets[j].HasUnit)
                    {
                        exitAmount += ApplyStatusEffect(targets[j].Unit, entryVariable);
                    }
                }
            }

            return exitAmount > 0;
        }

        public int ApplyStatusEffect(IUnit unit, int entryVariable)
        {
            int num = (_RandomBetweenPrevious ? UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1) : entryVariable);
            if (num < _Status.MinimumRequiredToApply)
            {
                return 0;
            }

            if (!unit.ApplyStatusEffect(_Status, 0, num))
            {
                return 0;
            }

            return Mathf.Max(1, num);
        }
    }
    public class ApplyPermanentGuttedEffect : PermenantStatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = StatusField.Gutted;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class ShadowHealEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public bool entryAsPercentage;

        [SerializeField]
        public bool _directHeal = true;

        [SerializeField]
        public bool _onlyIfHasHealthOver0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int min = 5;
            int max = 11;
            int mon = 2;
            if (CombatManager.Instance._informationHolder.Run.CurrentZoneID >= 2)
            {
                min += 5;
                max += 5;
                mon++;
            }
            entryVariable = UnityEngine.Random.Range(min, max);

            int minimize = 5;
            if (caster is EnemyCombat enemy)
            {
                foreach (EnemyCombat guy in stats.EnemiesOnField.Values)
                {
                    if (guy.Enemy == enemy.Enemy) minimize--;
                }
                for (int i = 0; i < minimize; i++)
                {
                    entryVariable += UnityEngine.Random.Range(mon, 5);
                }
            }
            int second = 0;
            for (int i = 0; i < stats.TurnsPassed; i++)
            {
                if (CombatManager.Instance._informationHolder.Run.CurrentZoneID < 2) second += mon;
                if (UnityEngine.Random.Range(0, 100) < 45) second++;
                if (UnityEngine.Random.Range(0, 100) < 15) second++;
            }
            entryVariable = Math.Max(0, entryVariable - second);

            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && (!_onlyIfHasHealthOver0 || targetSlotInfo.Unit.CurrentHealth > 0))
                {
                    int num = entryVariable;
                    if (entryAsPercentage)
                    {
                        num = targetSlotInfo.Unit.CalculatePercentualAmount(num);
                    }

                    exitAmount += targetSlotInfo.Unit.Heal(num, null, _directHeal);
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyShieldSlotEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Field = StatusField.Shield;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class RerollSwapCasterAbilitiesEffect : EffectSO
    {
        [Header("Abilities To Swap Data")]
        [SerializeField]
        public ExtraAbilityInfo[] _abilitiesToSwap;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool num = caster.SwapWithExtraAbilities(_abilitiesToSwap);
            if (num && !caster.IsUnitCharacter)
            {
                stats.timeline.TryReRollRandomEnemyTurns(caster as EnemyCombat, 99, true);
            }
            return num;
        }
    }
    public class SpawnEnemyCopySelfEffect : EffectSO
    {
        public bool givesExperience;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemm)
            {
                EnemySO enemy = enemm.Enemy;
                for (int i = 0; i < entryVariable; i++)
                {
                    CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnType));
                }
            }
            else return false;
            exitAmount = entryVariable;
            return true;
        }
    }
    public static class IllusionHandler
    {
        static BasePassiveAbilitySO _illusion;
        public static BasePassiveAbilitySO Illusion
        {
            get
            {
                if (_illusion == null)
                {
                    IllusionStatePassiveAbility fake = ScriptableObject.CreateInstance<IllusionStatePassiveAbility>();
                    fake._passiveName = "Delirium";
                    fake.passiveIcon = ResourceLoader.LoadSprite("IllusionPassive.png");
                    fake._enemyDescription = "This enemy has an Offense and a Supportive State and randomly picks between the two on entering battle.";
                    fake._characterDescription = "yurghle";
                    fake.m_PassiveID = "Salt_Illusion_PA";
                    fake.doesPassiveTriggerInformationPanel = false;
                    fake._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
                    _illusion = fake;
                    AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("IllusionPassive.png"), "Delirium", fake._enemyDescription);
                }
                return _illusion;
            }
        }
        public static string State = "Delusion_State";
        public static bool set = false;
        public static void Setup()
        {
            if (set) return; set = true;
            UnitStoreData_IllusionStateSO value_count = ScriptableObject.CreateInstance<UnitStoreData_IllusionStateSO>();
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(State))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[State] = value_count;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_count._UnitStoreDataID, value_count);
        }
        static Ability _drain;
        public static Ability Drain
        {
            get
            {
                if (_drain == null)
                {
                    ChangeMaxHealthEffect inc = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
                    inc._increase = true;
                    _drain = new Ability("Salt_Drowse_A")
                    {
                        Name = "Drowse",
                        Description = "Increase this enemy's maximum health by 2. Consume 2 Pigment.",
                        Rarity = Rarity.CreateAndAddCustomRarityToPool("Delusion_6", 6),
                        Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(inc, 2, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 2, Slots.Self)
                        },
                        Visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                        AnimationTarget = Targeting.Slot_SelfSlot
                    };
                    _drain.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_MaxHealth.ToString(), IntentType_GameIDs.Mana_Consume.ToString() });
                }
                return _drain;
            }
        }
        static Ability _haunt;
        public static Ability Haunt
        {
            get
            {
                if (_haunt == null)
                {
                    _haunt = new Ability("Salt_Haunting_A")
                    {
                        Name = "Haunting",
                        Description = "Apply 3 Muted to the Opposing party member.",
                        Rarity = Rarity.GetCustomRarity("Delusion_5"),
                        Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 3, Targeting.Slot_Front),
                        },
                        Visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                        AnimationTarget = Targeting.Slot_Front
                    };
                    _haunt.AddIntentsToTarget(Targeting.Slot_Front, new string[] { Muted.Intent });
                }
                return _haunt;
            }
        }
        static Ability _gnaw;
        public static Ability Gnaw
        {
            get
            {
                if (_gnaw == null)
                {
                    _gnaw = new Ability("Salt_Gnaw_A")
                    {
                        Name = "Gnaw",
                        Description = "Deal a Painful amount of damage to the Left and Right party members. \nThis enemy consumes 2 Pigment not of this enemy's health colour.",
                        Rarity = Rarity.CreateAndAddCustomRarityToPool("Delusion_8", 8),
                        Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_OpponentSides),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomButCasterHealthManaEffect>(), 2, Targeting.Slot_SelfSlot)
                        },
                        Visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals,
                        AnimationTarget = Targeting.Slot_OpponentSides
                    };
                    _gnaw.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
                    _gnaw.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Consume.ToString() });
                }
                return _gnaw;
            }
        }
        static Ability _insight;
        public static Ability Insight
        {
            get
            {
                if (_insight == null)
                {
                    GenerateRandomManaBetweenEffect random = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
                    random.possibleMana = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
                    _insight = new Ability("Salt_Insight_A")
                    {
                        Name = "Divination",
                        Description = "Apply Focused to this enemy. Generate 3 random pigment and apply 5 Shield to the Left and Right enemy positions.",
                        Rarity = Rarity.GetCustomRarity("Delusion_5"),
                        Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(random, 3, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, Targeting.Slot_AllySides)
                        },
                        Visuals = CustomVisuals.GetVisuals("Salt/Think"),
                        AnimationTarget = Targeting.Slot_SelfSlot,
                    };
                    _insight.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Focused.ToString(), IntentType_GameIDs.Mana_Generate.ToString() });
                    _insight.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
                }
                return _insight;
            }
        }
        static Ability _swapSupport;
        public static Ability SwapSupport
        {
            get
            {
                if (_swapSupport == null)
                {
                    RerollSwapCasterAbilitiesEffect abili = ScriptableObject.CreateInstance<RerollSwapCasterAbilitiesEffect>();
                    EnemyAbilityInfo haunt = Haunt.GenerateEnemyAbility();
                    EnemyAbilityInfo ins = Insight.GenerateEnemyAbility();
                    EnemyAbilityInfo rage = ResetDefault.GenerateEnemyAbility();
                    abili._abilitiesToSwap = new ExtraAbilityInfo[]
                    {
                        new ExtraAbilityInfo() { ability = haunt.ability, rarity = haunt.rarity },
                        new ExtraAbilityInfo() { ability = ins.ability, rarity = ins.rarity },
                        new ExtraAbilityInfo() { ability = rage.ability, rarity = rage.rarity }
                    };
                    SwapCasterPassivesEffect passi = ScriptableObject.CreateInstance<SwapCasterPassivesEffect>();
                    passi._passivesToSwap = new BasePassiveAbilitySO[]
                    {
                        Passives.Skittish, Illusion, Passives.Forgetful
                    };
                    _swapSupport = new Ability("Salt_SwapSupport_A")
                    {
                        Name = "Lucidity",
                        Description = "Swap this enemy to a Supportive State and spawn a copy of this enemy with maximum health equal to this enemy's missing health.",
                        Rarity = Rarity.CreateAndAddCustomRarityToPool("Delusion_4", 4),
                        Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(abili, 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(passi, 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(BasicEffects.SetStoreValue(State), 2, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyCopyBasedOffMissingHealth>(), 1, Targeting.Slot_SelfSlot)
                        },
                        Visuals = CustomVisuals.GetVisuals("Salt/Cube"),
                        AnimationTarget = Targeting.Slot_SelfSlot,
                    };
                    _swapSupport.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Other_Spawn.ToString() });
                }
                return _swapSupport;
            }
        }
        static Ability _resetDefault;
        public static Ability ResetDefault
        {
            get
            {
                if (_resetDefault == null)
                {
                    _resetDefault = new Ability("Salt_ResetDefault_A")
                    {
                        Name = "Enrage",
                        Description = "Swap this enemy to an Offense State and spawn a copy of this enemy with maximum health equal to this enemy's missing health.",
                        Rarity = Rarity.CreateAndAddCustomRarityToPool("Delusion_1", 1),
                        Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterAbilitiesToDefaultEffect>(), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterPassivesToDefaultEffect>(), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(BasicEffects.SetStoreValue(State), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyCopyBasedOffMissingHealth>(), 1, Targeting.Slot_SelfSlot)
                        },
                        Visuals = CustomVisuals.GetVisuals("Salt/Notif"),
                        AnimationTarget = Targeting.Slot_SelfSlot,
                    };
                    _resetDefault.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Other_Spawn.ToString() });
                }
                return _resetDefault;
            }
        }
    }
    public class UnitStoreData_IllusionStateSO : UnitStoreData_BasicSO
    {
        public override bool TryGetUnitStoreDataToolTip(UnitStoreDataHolder holder, out string result)
        {
            result = GenerateString(holder.m_MainData);
            return result != "";
        }

        public string GenerateString(int value)
        {
            if (value <= 0 || value > 2) return "";
            string text = value == 1 ? "Offense State" : "Support State";
            string text2 = ColorUtility.ToHtmlStringRGB(value == 1 ? (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor : (LoadedDBsHandler.MiscDB.GetUnitStoreData("TearsA") as UnitStoreData_IntSO).m_TextColor);
            string text3 = "<color=#" + text2 + ">";
            string text4 = "</color>";
            return text3 + text + text4;
        }
    }
    public class IllusionStatePassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => false;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            if (unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()) > 0) return;
            unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString(), 1);
            IllusionHandler.Setup();
            if (UnityEngine.Random.Range(0, 100) < 50)
            {
                EffectInfo[] ee = new EffectInfo[]
                {
                    IllusionHandler.ResetDefault.Effects[2]
                };
                EffectInfo[] aa = new EffectInfo[]
                {
                    Effects.GenerateEffect(RootActionEffect.Create(ee), 1, Targeting.Slot_SelfSlot)
                };
                CombatManager.Instance.AddRootAction(new EffectAction(new EffectInfo[]
                {
                    Effects.GenerateEffect(RootActionEffect.Create(aa), 1, Targeting.Slot_SelfSlot)
                }, unit));
                return;
            }
            EffectInfo[] ef = new EffectInfo[]
            {
                IllusionHandler.SwapSupport.Effects[0],
                IllusionHandler.SwapSupport.Effects[1],
                IllusionHandler.SwapSupport.Effects[2],
            };
            EffectInfo[] af = new EffectInfo[]
            {
                    Effects.GenerateEffect(RootActionEffect.Create(ef), 1, Targeting.Slot_SelfSlot)
            };
            CombatManager.Instance.AddRootAction(new EffectAction(new EffectInfo[]
            {
                Effects.GenerateEffect(RootActionEffect.Create(af), 1, Targeting.Slot_SelfSlot)
            }, unit));
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class ApplyFocusedEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = StatusField.Focused;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class SpawnEnemyCopyBasedOffMissingHealth : EffectSO
    {
        public EnemySO enemy;

        public bool givesExperience;

        [CombatIDsEnumRef]
        public string _spawnTypeID = "";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (_spawnTypeID == "") _spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            if (caster is EnemyCombat en) enemy = en.Enemy;
            else return false;
            if (caster.CurrentHealth >= caster.MaximumHealth) return false;
            for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnTypeID, Math.Max(1, caster.MaximumHealth - caster.CurrentHealth)));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
}
