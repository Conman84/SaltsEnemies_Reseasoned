using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using BrutalAPI;
using UnityEngine;
using SaltsEnemies_Reseasoned;
using System.Collections.Generic;
using static UnityEngine.EventSystems.EventTrigger;

/*I DO THESE*/
//call SigilManager.Add() in awake.
//also, pull the Sigil's custom intents out of this class. SigilManager.AtkTxt, for instance

namespace SaltEnemies_Reseasoned
{
    public static class SigilManager
    {
        public static string AtkTxt => "AtkTxt";
        public static string DefTxt => "DefTxt";
        public static string SpdTxt => "SpdTxt";
        public static string MndTxt => "MndTxt";
        public static string UpArrow => "UpArrow";
        public static string DownArrow => "DownArrow";
        public static string OtherUpAlt => "OtherUpAlt";
        public static string UpPurple => "UpPurple";
        public static string Spectral => "Spectral";
        public static SigilPassiveAbility GetSigilPassive(IPassiveEffector unit)
        {
            foreach (BasePassiveAbilitySO passive in unit.PassiveAbilities)
            {
                if (passive is SigilPassiveAbility sigility) return sigility;
            }
            return null;
        }
        public static void NotificationCheck(string notificationName, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                List<int> ids = new List<int>();
                List<bool> ischara = new List<bool>();
                List<string> passi = new List<string>();
                List<Sprite> icons = new List<Sprite>();
                int pigment = 0;
                if (unit.IsUnitCharacter)
                {
                    foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                    {
                        if (notificationName == TriggerCalls.OnWillApplyDamage.ToString() && GetSigilPassive(chara) != null && GetSigilPassive(chara)._sigil == SigilType.Offensive && args is DamageDealtValueChangeException hitting)
                        {
                            ids.Add(chara.ID);
                            ischara.Add(chara.IsUnitCharacter);
                            passi.Add(GetSigilPassive(chara)._passiveName);
                            icons.Add(GetSigilPassive(chara).passiveIcon);
                            decimal gap = chara.CurrentHealth;
                            gap /= 3;
                            hitting.AddModifier(new AdditionValueModifier(true, (int)Math.Ceiling(gap)));
                        }
                        if (notificationName == TriggerCalls.OnDirectDamaged.ToString() && GetSigilPassive(chara) != null && GetSigilPassive(chara)._sigil == SigilType.Intensive)
                        {
                            if (unit.HealthColor.canGenerateMana)
                            {
                                ids.Add(chara.ID);
                                ischara.Add(chara.IsUnitCharacter);
                                passi.Add(GetSigilPassive(chara)._passiveName);
                                icons.Add(GetSigilPassive(chara).passiveIcon);
                                pigment+= 2;
                            }
                        }
                        if (notificationName == TriggerCalls.OnDirectDamaged.ToString() && GetSigilPassive(chara) != null && GetSigilPassive(chara)._sigil == SigilType.Defensive)
                        {
                            CombatManager.Instance.AddSubAction(new SubActionAction(new SigilSwapSideAction(unit, chara)));
                        }
                        if (notificationName == TriggerCalls.OnAbilityUsed.ToString() && GetSigilPassive(chara) != null && GetSigilPassive(chara)._sigil == SigilType.Defensive)
                        {
                            CombatManager.Instance.AddSubAction(new SubActionAction(new SigilSwapSideAction(unit, chara)));
                        }
                    }
                    if (notificationName == TriggerCalls.OnBeingDamaged.ToString() && sender is CharacterCombat CH && GetSigilPassive(CH) != null && GetSigilPassive(CH)._sigil == SigilType.Spectral && args is DamageReceivedValueChangeException hits)
                    {
                        ids.Add(CH.ID);
                        ischara.Add(CH.IsUnitCharacter);
                        passi.Add(GetSigilPassive(CH)._passiveName);
                        icons.Add(GetSigilPassive(CH).passiveIcon);
                        hits.AddModifier(new FloatMod(0f, false));
                    }
                }
                else
                {
                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                    {
                        if (notificationName == TriggerCalls.OnWillApplyDamage.ToString() && GetSigilPassive(enemy) != null && GetSigilPassive(enemy)._sigil == SigilType.Offensive && args is DamageDealtValueChangeException hitting)
                        {
                            ids.Add(enemy.ID);
                            ischara.Add(enemy.IsUnitCharacter);
                            passi.Add(GetSigilPassive(enemy)._passiveName);
                            icons.Add(GetSigilPassive(enemy).passiveIcon);
                            decimal gap = enemy.CurrentHealth;
                            gap /= 3;
                            hitting.AddModifier(new AdditionValueModifier(true, (int)Math.Ceiling(gap)));
                        }
                        if (notificationName == TriggerCalls.OnDirectDamaged.ToString() && GetSigilPassive(enemy) != null && GetSigilPassive(enemy)._sigil == SigilType.Intensive)
                        {
                            if (unit.HealthColor.canGenerateMana)
                            {
                                ids.Add(enemy.ID);
                                ischara.Add(enemy.IsUnitCharacter);
                                passi.Add(GetSigilPassive(enemy)._passiveName);
                                icons.Add(GetSigilPassive(enemy).passiveIcon);
                                pigment+= 2;
                            }
                        }
                        if (notificationName == TriggerCalls.OnDirectDamaged.ToString() && GetSigilPassive(enemy) != null && GetSigilPassive(enemy)._sigil == SigilType.Defensive)
                        {
                            CombatManager.Instance.AddSubAction(new SubActionAction(new SigilSwapSideAction(unit, enemy)));
                        }
                        if (notificationName == TriggerCalls.OnAbilityUsed.ToString() && GetSigilPassive(enemy) != null && GetSigilPassive(enemy)._sigil == SigilType.Defensive)
                        {
                            CombatManager.Instance.AddSubAction(new SubActionAction(new SigilSwapSideAction(unit, enemy)));
                        }
                    }
                    if (notificationName == TriggerCalls.OnBeingDamaged.ToString() && sender is EnemyCombat EN && GetSigilPassive(EN) != null && GetSigilPassive(EN)._sigil == SigilType.Spectral && args is DamageReceivedValueChangeException hits)
                    {
                        ids.Add(EN.ID);
                        ischara.Add(EN.IsUnitCharacter);
                        passi.Add(GetSigilPassive(EN)._passiveName);
                        icons.Add(GetSigilPassive(EN).passiveIcon);
                        hits.AddModifier(new FloatMod(0f, false));
                    }
                }
                if (ids.Count > 0) CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(ids.ToArray(), ischara.ToArray(), passi.ToArray(), icons.ToArray()));
                if (pigment > 0) unit.GenerateHealthMana(pigment);
            }
        }
        public static string Sigil = "SigilPA";
        static bool Set;
        public static void Setup()
        {
            if (Set) return;
            Set = true;
            NotificationHook.AddAction(NotificationCheck);
            UnitStoreData_SigilStateSO sigil_value = ScriptableObject.CreateInstance<UnitStoreData_SigilStateSO>();
            sigil_value._UnitStoreDataID = Sigil;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Sigil))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Sigil] = sigil_value;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(sigil_value._UnitStoreDataID, sigil_value);
        }
        public static void Add()
        {
            Setup();
            Intents.CreateAndAddCustom_Basic_IntentToPool(DefTxt, ResourceLoader.LoadSprite("defenseicon.png"), Color.white);
            Intents.CreateAndAddCustom_Basic_IntentToPool(AtkTxt, ResourceLoader.LoadSprite("atkicon.png"), Color.white);
            Intents.CreateAndAddCustom_Basic_IntentToPool(SpdTxt, ResourceLoader.LoadSprite("speedicon.png"), Color.white);
            Intents.CreateAndAddCustom_Basic_IntentToPool(MndTxt, ResourceLoader.LoadSprite("mindicon.png"), Color.white);
            Intents.CreateAndAddCustom_Basic_IntentToPool(UpArrow, ResourceLoader.LoadSprite("blueUpIcon.png"), Color.white);
            Intents.CreateAndAddCustom_Basic_IntentToPool(DownArrow, ResourceLoader.LoadSprite("downicon.png"), Color.white);
            Intents.CreateAndAddCustom_Basic_IntentToPool(OtherUpAlt, ResourceLoader.LoadSprite("upicon.png"), Color.white);
            Intents.CreateAndAddCustom_Basic_IntentToPool(UpPurple, ResourceLoader.LoadSprite("PurpleUpIcon.png"), Color.white);
            Intents.CreateAndAddCustom_Basic_IntentToPool(Spectral, ResourceLoader.LoadSprite("spectralicon.png"), Color.white);
        }
    }
    public class UnitStoreData_SigilStateSO : UnitStoreData_BasicSO
    {
        public override bool TryGetUnitStoreDataToolTip(UnitStoreDataHolder holder, out string result)
        {
            result = GenerateString(holder.m_MainData);
            return result != "";
        }

        public string GenerateString(int value)
        {
            if (value <= 0 || value > 4) return "";
            string text = "";
            Color color = Color.white;
            switch (value)
            {
                case 1: 
                    text = "Defensive Sigil";
                    color = (LoadedDBsHandler.MiscDB.GetUnitStoreData("TearsA") as UnitStoreData_IntSO).m_TextColor;
                    break;
                case 2:
                    text = "Offensive Sigil";
                    color = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
                    break;
                case 3:
                    text = "Spectral Sigil";
                    color = Color.green;
                    break;
                case 4:
                    text = "Pure Sigil";
                    color = Color.magenta;
                    break;
                case 5:
                    text = "Intensive Sigil";
                    color = Color.yellow;
                    break;
                default: goto case 4;
            }
            string text2 = ColorUtility.ToHtmlStringRGB(color);
            string text3 = "<color=#" + text2 + ">";
            string text4 = "</color>";
            return text3 + text + text4;
        }
    }
    public class SigilPassiveAbility : BasePassiveAbilitySO
    {
        public override bool DoesPassiveTrigger => true;
        public override bool IsPassiveImmediate => true;
        public IUnit Actor;
        public SigilType _sigil
        {
            get
            {
                if (Actor == null)
                {
                    return 0;
                }
                else
                {
                    SigilType ret = (SigilType)Actor.SimpleGetStoredValue(SigilManager.Sigil);
                    return ret;
                }
            }
        }
        public override void TriggerPassive(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                unit.SimpleSetStoredValue(SigilManager.Sigil, 4);
                if (CasterSetSigilPassiveEffect.Purple == null || CasterSetSigilPassiveEffect.Purple.Equals(null)) CasterSetSigilPassiveEffect.Purple = ResourceLoader.LoadSprite("SigilP_Purple.png");
                _enemyDescription = "At the start of each turn, reset this enemy's Sigil.";
                _characterDescription = "At the start of each turn, reset this party member's Sigil.";
                passiveIcon = CasterSetSigilPassiveEffect.Purple;
                CombatManager.Instance.AddUIAction(new EnemyPassiveAbilityChangeUIAction(unit.ID, (unit as IPassiveEffector).PassiveAbilities.ToArray()));
            }
        }
        public bool Added = false;
        public bool ReplaceAdd = false;
        public override void OnPassiveConnected(IUnit unit)
        {
            SigilManager.Setup();
            if (Added)
            {
                CombatManager.Instance.AddPrioritySubAction(new NewSigilSubAction(unit, this));
                return;
            }
            EffectInfo[] array = new EffectInfo[]
            {
                Effects.GenerateEffect(BasicEffects.SetStoreValue(SigilManager.Sigil), 4, Targeting.Slot_SelfSlot)
            };
            EffectInfo[] root = new EffectInfo[]
            {
                Effects.GenerateEffect(RootActionEffect.Create(array), 1, Targeting.Slot_SelfSlot)
            };
            CombatManager.Instance.AddRootAction(new EffectAction(new EffectInfo[]
            {
                Effects.GenerateEffect(RootActionEffect.Create(root), 1, Targeting.Slot_SelfSlot)
            }, unit));
            Actor = unit;
            Added = true;
        }
        public bool KeepActor = false;
        public override void OnPassiveDisconnected(IUnit unit)
        {
            unit.SimpleSetStoredValue(SigilManager.Sigil, 0);
            if (!KeepActor) Actor = null;
            else
            {
                KeepActor = false;
            }
            if (unit.IsUnitCharacter)
            {
                CombatManager.Instance._stats.combatUI.TrySetCharacterAnimatorParameter(unit.ID, "color", 0);
            }
            else
            {
                CombatManager.Instance._stats.combatUI.TrySetEnemyAnimatorParameter(unit.ID, "color", 0);
            }
        }
    }
    public class NewSigilSubAction : CombatAction
    {
        public IUnit unit;
        public SigilPassiveAbility pass;
        public NewSigilSubAction(IUnit unit, SigilPassiveAbility pass)
        {
            this.unit = unit;
            this.pass = pass;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (unit.IsAlive || unit.CurrentHealth > 0)
            {
                pass.KeepActor = true;
                unit.TryRemovePassiveAbility(pass.m_PassiveID);
                SigilPassiveAbility add = ScriptableObject.Instantiate(pass);
                add.Added = false;
                add.Actor = null;
                add.ReplaceAdd = true;
                unit.AddPassiveAbility(add);
            }
            yield return null;
        }
    }
    public enum SigilType
    {
        Unavailable = 0,
        Defensive = 1,
        Offensive = 2,
        Spectral = 3,
        Pure = 4,
        Intensive = 5
    }
    public class FloatMod : IntValueModifier
    {
        public readonly float mod;
        public readonly bool roundUp;
        public FloatMod(float _mod, bool _RoundUp) : base(74)
        {
            this.mod = _mod;
            this.roundUp = _RoundUp;
        }

        public override int Modify(int value)
        {
            float gap = value;
            gap *= mod;
            if (roundUp)
            {
                value = (int)Math.Ceiling(gap);
            }
            else
            {
                value = (int)Math.Floor(gap);
            }
            return value;
        }
    }
    public static class SigilSongHandler
    {
        public static int Spectre = 0;
        public static void Check()
        {
            int news = 0;
            if (!SaltsEnemies_Reseasoned.Check.EnemyExist("Sigil_EN")) return;
            foreach (EnemyCombat EN in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                if (SigilManager.GetSigilPassive(EN) != null && SigilManager.GetSigilPassive(EN)._sigil == SigilType.Spectral && EN.CurrentHealth > 0)
                {
                    news++;
                }
            }
            foreach (CharacterCombat CH in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (SigilManager.GetSigilPassive(CH) != null && SigilManager.GetSigilPassive(CH)._sigil == SigilType.Spectral && CH.CurrentHealth > 0)
                {
                    news++;
                }
            }
            if (news != Spectre)
            {
                Spectre = news;
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Spectral", Spectre > 0 ? 1 : 0);
            }
        }
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (notificationName == TriggerCalls.OnFleetingEnd.ToString() || notificationName == TriggerCalls.OnDeath.ToString()) Check();
        }
        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck);
        }
    }
    public class SigilSongCheckUIAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            SigilSongHandler.Check();
            yield return null;
        }
    }
    public class SigilSongCheckEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new SigilSongCheckUIAction());
            return true;
        }
    }
    public class SigilEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "color", entryVariable));
            return true;
        }
    }
    public class AnimationParameterSetterIntUIAction : CombatAction
    {
        public int _id;

        public bool _isCharacter;

        public string _parameterName;

        public int _parameterValue;

        public AnimationParameterSetterIntUIAction(int id, bool isCharacter, string parameterName, int parameterValue)
        {
            _id = id;
            _isCharacter = isCharacter;
            _parameterName = parameterName;
            _parameterValue = parameterValue;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (_isCharacter)
            {
                stats.combatUI.TrySetCharacterAnimatorParameter(_id, _parameterName, _parameterValue);
            }
            else
            {
                stats.combatUI.TrySetEnemyAnimatorParameter(_id, _parameterName, _parameterValue);
            }

            yield break;
        }
    }
}
