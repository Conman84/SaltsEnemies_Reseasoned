using BrutalAPI;
using FMOD;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using SaltsEnemies_Reseasoned;

//call HooksGeneral.Setup() in awake

//for future, but make sure Chien Tindalou's Warping m_PassiveID = "Warping_PA"
//for future, when setting up the Dragon's awoken passive make sure the m_PassiveID = "DragonAwake_PA"
//for future, when setting up the Sinker's Lonely passive, make sure the trigger call is LonelySubAction.Trigger
//for future, when setting up Feather Gun (the item) the SaltEnemies.FeatherGun trigger call is now FeatherGunHandler.FeatherGun

namespace SaltEnemies_Reseasoned
{
    public static class HooksGeneral
    {
        public static void Setup()
        {
            IDetour idetour1 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.Damage), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(Damage), ~BindingFlags.Default));
            IDetour idetour2 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.Damage), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(Damage), ~BindingFlags.Default));
            IDetour idetour3 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.WillApplyDamage), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(WillApplyDamage), ~BindingFlags.Default));
            IDetour idetour4 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.WillApplyDamage), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(WillApplyDamage), ~BindingFlags.Default));
            IDetour idetour5 = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.Start), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(StartMenu), ~BindingFlags.Default));
            IDetour idetour6 = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(InitializeCombat), ~BindingFlags.Default));
            IDetour idetour7 = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(PlayerTurnStart), ~BindingFlags.Default));
            IDetour idetour8 = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnEnd), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(PlayerTurnEnd), ~BindingFlags.Default));
            IDetour idetour9 = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.PostNotification), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(PostNotification), ~BindingFlags.Default));
            IDetour idetour10 = new Hook(typeof(EffectAction).GetMethod(nameof(EffectAction.Execute), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(EffectActionExecute), ~BindingFlags.Default));
            //IDetour idetour11 = new Hook(typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(AddStoredValue), ~BindingFlags.Default));
            IDetour idetour12 = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.Awake), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(AwakeOverworld), ~BindingFlags.Default));
            IDetour idetour13 = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.LoadOldRun), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(LoadRun), ~BindingFlags.Default));
            IDetour idetour14 = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(LoadRun), ~BindingFlags.Default));
            IDetour idetour15 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.UseAbility), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(UseAbilityChara), ~BindingFlags.Default));
            IDetour idetour16 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.UseAbility), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(UseAbilityEnemy), ~BindingFlags.Default));

            ResistanceHandler.AddValues();
        }

        public static DamageInfo Damage(Func<IUnit, int, IUnit, string, int, bool, bool, bool, string, DamageInfo> orig, IUnit self, int amount, IUnit killer, string deathType, int targetSlotOffset = -1, bool addHealthMana = true, bool directDamage = true, bool ignoresShield = false, string specialDamage = "")
        {
            CombatManager.Instance.PostNotification(GlowingHatCondition.Trigger.ToString(), self, null);
            bool addDet = false;
            if (killer != null && killer.HasUsableItem && killer.HeldItem._itemName == "Silver Bullet" && !self.ContainsStatusEffect(Determined.StatusID))
            {
                addDet = true;
            }
            DamageInfo ret = orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
            if (addDet)
            {
                CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(killer.ID, killer.HeldItem.GetItemLocData().text, false, killer.HeldItem.wearableImage));
                ScriptableObject.CreateInstance<ApplyDeterminedEffect>().PerformEffect(CombatManager.Instance._stats, self, Targeting.Slot_SelfSlot.GetTargets(CombatManager.Instance._stats.combatSlots, self.SlotID, self.IsUnitCharacter), Targeting.Slot_SelfSlot.AreTargetSlots, 3, out int exi);
            }
            if (killer != null && killer.HasUsableItem && killer.HeldItem._itemName == "Echo" && ret.damageAmount > 0)
            {
                try
                {
                    GenericTargetting_BySlot_Index get = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                    get.slotPointerDirections = new int[] { targetSlotOffset > 0 ? self.SlotID + targetSlotOffset : self.SlotID };
                    get.getAllies = killer.IsUnitCharacter == self.IsUnitCharacter;

                    new DelayedAttack(ret.damageAmount, get.GetTargets(CombatManager.Instance._stats.combatSlots, killer.SlotID, killer.IsUnitCharacter)[0], killer).Add();
                    CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(killer.ID, killer.HeldItem.GetItemLocData().text, false, killer.HeldItem.wearableImage));
                }
                catch
                {
                    UnityEngine.Debug.LogError("Echo failed");
                }
            }
            if (killer != null && self.ContainsPassiveAbility(WarpingHandler.Type) && ret.damageAmount > 0)
            {
                WarpingPassiveEffect w = ScriptableObject.CreateInstance<WarpingPassiveEffect>();
                w.ID = self.ID;
                w.IsUnitCharacter = self.IsUnitCharacter;
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[]
                {
                    Effects.GenerateEffect(w, 1, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot)
                }, killer));
            }
            return ret;
        }
        public static int WillApplyDamage(Func<IUnit, int, IUnit, int> orig, IUnit self, int amount, IUnit targetUnit)
        {
            int currentHealth = targetUnit.CurrentHealth;
            bool opponentHealthIsBigger = self.CurrentHealth <= currentHealth;
            int ret = orig(self, amount, targetUnit);
            if (self.HasUsableItem && self.HeldItem._itemName == "Silver Bullet" && targetUnit.ContainsStatusEffect(Determined.StatusID))
            {
                CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(self.ID, self.HeldItem.GetItemLocData().text, false, self.HeldItem.wearableImage));
                ret *= 2;
            }
            DamageDealtValueChangeException ex = new DamageDealtValueChangeException(ret, opponentHealthIsBigger, targetUnit.Size, targetUnit.UnitTypes, self, targetUnit);
            CombatManager.Instance.PostNotification(FeatherGunHandler.FeatherGun.ToString(), self, ex);
            return ex.GetModifiedValue();
        }
        public static void StartMenu(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            //SaltEnemies.PCall(PerformRandomEffectsSpecificAmongEffects.GO);
        }
        public static void InitializeCombat(Action<CombatManager> orig, CombatManager self)
        {
            DragonSongEffect.WereDragons = false;
            CopyLastAbilityEffect.LastAbility = null;
            YNLHandler2.Reset();
            YNLHandler2.Grody();
            Roots.Clear();
            Water.Clear();
            orig(self);
        }
        public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            YNLHandler2.Grody();
        }
        public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                enemy.SimpleSetStoredValue(EnemyRefresher.Did, 0);
            }
        }
        public static void PostNotification(Action<CombatManager, string, object, object> orig, CombatManager self, string call, object sender, object args)
        {
            orig(self, call, sender, args);
            NotificationChecksIDGAF(call, sender, args);
        }
        public static IEnumerator EffectActionExecute(Func<EffectAction, CombatStats, IEnumerator> orig, EffectAction self, CombatStats stats)
        {
            return orig(self, stats);
        }
        public static void AwakeOverworld(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
        }
        public static void LoadRun(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
        }
        public static void UseAbilityChara(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            if (self.CombatAbilities.Count > abilityID) if (self.CombatAbilities[abilityID].ability._abilityName != "Replicate") CopyLastAbilityEffect.LastAbility = self.CombatAbilities[abilityID].ability;
            orig(self, abilityID, filledCost);
        }
        public static void UseAbilityEnemy(Action<EnemyCombat, int> orig, EnemyCombat self, int abilityID)
        {
            if (self.Abilities.Count > abilityID) CopyLastAbilityEffect.LastAbility = self.Abilities[abilityID].ability;
            orig(self, abilityID);
        }

        public static void NotificationChecksIDGAF(string notificationName, object sender, object args)
        {
            NobodyMoveHandler.NotifCheck(notificationName, sender, args);
            ReplacementHandler.NotifCheck(notificationName, sender, args);
            if (notificationName == TriggerCalls.OnMoved.ToString() && BadDogHandler.IsPlayerTurn()) BadDogHandler.RunCheckFunction();
            if (notificationName == TriggerCalls.OnAbilityUsed.ToString()) TrainHandler.SwitchTrainTargetting(sender);
            if (notificationName == TriggerCalls.OnDeath.ToString() && sender is ITurn) TrainHandler.CheckAll();
            //SigilSongHandler.NotifCheck(notificationName, sender, args);
            //StampHandler.NotifCheck(notificationName, sender, args);
            if (notificationName == TriggerCalls.CanChangeHealthColor.ToString() && sender is IUnit iu) iu.SwapPalm();
            if (notificationName == TriggerCalls.OnMoved.ToString())
            {
                if (sender is IUnit umnit)
                {
                    if (umnit.IsUnitCharacter)
                    {

                    }
                    else
                        foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values) CombatManager.Instance.PostNotification(JitteryHandler.Call.ToString(), chara, umnit);
                }
            }
            if (notificationName == TriggerCalls.OnAbilityUsed.ToString())
            {
                if (sender is IUnit umnit)
                {
                    if (umnit.IsUnitCharacter)
                    {
                        foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values) CombatManager.Instance.PostNotification(CCTVHandler.Trigger.ToString(), enemy, umnit);
                    }
                    else
                        foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values) CombatManager.Instance.PostNotification(CCTVHandler.Trigger.ToString(), chara, umnit);
                }
            }
            if (notificationName == TriggerCalls.OnSwapTo.ToString())
            {
                if (sender is CharacterCombat) foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values) CombatManager.Instance.PostNotification(JitteryHandler.Call.ToString(), enemy, sender);
            }
            if (sender is IUnit uuu && !uuu.IsUnitCharacter)
            {
                if (notificationName == TriggerCalls.OnDeath.ToString() || notificationName == TriggerCalls.OnFleetingEnd.ToString() || notificationName == TriggerCalls.OnMoved.ToString())
                {
                    CombatManager.Instance.AddSubAction(new LonelySubAction());
                }
            }
        }
    }
    public class GlowingHatCondition : EffectorConditionSO
    {
        public static TriggerCalls Trigger => (TriggerCalls)3739912;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                if (unit.HasUsableItem) CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(unit.ID, unit.HeldItem.GetItemLocData().text, false, unit.HeldItem.wearableImage));
                //Spotlight_StatusEffect spotlight_StatusEffect = new Spotlight_StatusEffect();
                //CombatManager.Instance._stats.statusEffectDataBase.TryGetValue(StatusEffectType.Spotlight, out var value);
                //spotlight_StatusEffect.SetEffectInformation(value);
                unit.ApplyStatusEffect(StatusField.Spotlight, 0);
            }
            return false;
        }
    }
    public static class WarpingHandler
    {
        public static string Type => "Warping_PA";
        static Sprite _icon;
        public static Sprite Icon
        {
            get
            {
                UnityEngine.Debug.LogError("make sure this is loading the right sprite");
                if (_icon == null) _icon = ResourceLoader.LoadSprite("WarpingIcon");
                return _icon;
            }
        }
    }
    public class WarpingPassiveEffect : EffectSO
    {
        public int ID;
        public bool IsUnitCharacter;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(ID, IsUnitCharacter, "Warping", WarpingHandler.Icon));
            exitAmount = 0;
            return true;
        }
    }
    public static class FeatherGunHandler
    {
        public static TriggerCalls FeatherGun => (TriggerCalls)7308109;
    }
    public class DragonSongEffect : EffectSO
    {
        public static bool WereDragons = false;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (changeMusic != null)
            {
                try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("train thread failed to shut down."); }
            }
            if (AreDragons())
            {
                if (!WereDragons)
                {
                    changeMusic = new System.Threading.Thread(GO);
                    changeMusic.Start();
                }
            }
            else
            {
                if (WereDragons)
                {
                    changeMusic = new System.Threading.Thread(STOP);
                    changeMusic.Start();
                }
            }
            WereDragons = AreDragons();
            return true;
        }

        public static System.Threading.Thread changeMusic;
        public static void GO()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("DragonAwake", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 10; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("DragonAwake", i);
                System.Threading.Thread.Sleep(80);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
        public static void STOP()
        {
            int start = 10;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("DragonAwake", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i >= 0; i--)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("DragonAwake", i);
                System.Threading.Thread.Sleep(80);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
        public static string DragonAwakeType => "DragonAwake_PA";
        public static bool AreDragons()
        {
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                if (enemy.ContainsPassiveAbility(DragonAwakeType)) return true;
            }
            return false;
        }
    }
    public class CopyLastAbilityEffect : EffectSO
    {
        public static AbilitySO LastAbility;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (LastAbility == null) return false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.TryPerformRandomAbility(LastAbility))
                {
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
    public class ResistanceCondition : EffectorConditionSO
    {
        public static string Red => "ResistanceCondition_Red";
        public static string Blue => "ResistanceCondition_Blue";
        public static string Yellow => "ResistanceCondition_Yellow";
        public static string Purple => "ResistanceCondition_Purple";
        public static string Grey => "ResistanceCondition_Grey";
        public static Sprite sprite;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (PigmentUsedCollector.lastUsed == null) return false;
            if (effector is IUnit unit && args is DamageReceivedValueChangeException e)
            {
                if (sprite == null) sprite = ResourceLoader.LoadSprite("ResistancePassive.png");
                if (!e.directDamage) return false;
                ManaColorSO[] has = unit.GetResistances();
                for (int i = 0; i < PigmentUsedCollector.lastUsed.Count; i++)
                {
                    if (has.Contains(PigmentUsedCollector.lastUsed[i]))
                    {
                        CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, "Resistance", sprite));
                        e.AddModifier(new MultiplyIntValueModifier(false, 0));
                        return false;
                    }
                }
            }
            else if (effector is IUnit uni) return uni.GetResistances().Length <= 0;
            return false;
        }

    }
    public static class ResistanceHandler
    {
        public static string Red => ResistanceCondition.Red;
        public static string Blue => ResistanceCondition.Blue;
        public static string Yellow => ResistanceCondition.Yellow;
        public static string Purple => ResistanceCondition.Purple;
        public static string Grey => ResistanceCondition.Grey;
        public static ManaColorSO[] GetResistances(this IUnit unit)
        {
            List<ManaColorSO> res = new List<ManaColorSO>();
            if (unit.SimpleGetStoredValue(Red) > 0) res.Add(Pigments.Red);
            if (unit.SimpleGetStoredValue(Blue) > 0) res.Add(Pigments.Blue);
            if (unit.SimpleGetStoredValue(Yellow) > 0) res.Add(Pigments.Yellow);
            if (unit.SimpleGetStoredValue(Purple) > 0) res.Add(Pigments.Purple);
            if (unit.SimpleGetStoredValue(Grey) > 0) res.Add(Pigments.Grey);
            return res.ToArray();
        }
        public static void SetAllResistances(this IUnit unit, ManaColorSO[] res)
        {
            if (res.Contains(Pigments.Red)) unit.SimpleSetStoredValue(Red, 1);
            else unit.SimpleSetStoredValue(Red, 0);
            if (res.Contains(Pigments.Blue)) unit.SimpleSetStoredValue(Blue, 1);
            else unit.SimpleSetStoredValue(Blue, 0);
            if (res.Contains(Pigments.Yellow)) unit.SimpleSetStoredValue(Yellow, 1);
            else unit.SimpleSetStoredValue(Yellow, 0);
            if (res.Contains(Pigments.Purple)) unit.SimpleSetStoredValue(Purple, 1);
            else unit.SimpleSetStoredValue(Purple, 0);
            if (res.Contains(Pigments.Grey)) unit.SimpleSetStoredValue(Grey, 1);
            else unit.SimpleSetStoredValue(Grey, 0);

        }
        public static void AddResistance(this IUnit unit, ManaColorSO res)
        {
            if (res == Pigments.Red) unit.SimpleSetStoredValue(Red, 1);
            if (res == Pigments.Blue) unit.SimpleSetStoredValue(Blue, 1);
            if (res == Pigments.Yellow) unit.SimpleSetStoredValue(Yellow, 1);
            if (res == Pigments.Purple) unit.SimpleSetStoredValue(Purple, 1);
            if (res == Pigments.Grey) unit.SimpleSetStoredValue(Grey, 1);
        }
        public static void RemoveResistance(this IUnit unit, ManaColorSO res)
        {
            if (res == Pigments.Red) unit.SimpleSetStoredValue(Red, 0);
            if (res == Pigments.Blue) unit.SimpleSetStoredValue(Blue, 0);
            if (res == Pigments.Yellow) unit.SimpleSetStoredValue(Yellow, 0);
            if (res == Pigments.Purple) unit.SimpleSetStoredValue(Purple, 0);
            if (res == Pigments.Grey) unit.SimpleSetStoredValue(Grey, 0);
        }
        public static ManaColorSO[] GenerateRandomResistances(this IUnit unit, int amount)
        {
            List<ManaColorSO> ret = new List<ManaColorSO>();
            List<ManaColorSO> orig = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            if (amount >= 4)
            {
                amount = 3;
                ret.Add(Pigments.Grey);
            }
            List<ManaColorSO> has = new List<ManaColorSO>(unit.GetResistances());
            for (int i = 0; i < 4 - amount; i++)
            {
                if (has.Count > 0)
                {
                    ManaColorSO pick = has.GetRandom();
                    has.Remove(pick);
                    if (orig.Contains(pick)) orig.Remove(pick);
                }
            }
            for (int i = 0; i < amount; i++)
            {
                if (orig.Count > 0)
                {
                    ManaColorSO pick = orig.GetRandom();
                    orig.Remove(pick);
                    ret.Add(pick);
                }
            }
            return ret.ToArray();
        }
        public static void AddValues()
        {
            UnitStoreData_ModIntSO red = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            red.m_Text = "Resists Red";
            red._UnitStoreDataID = Red;
            red.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
            red.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Red))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Red] = red;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(red._UnitStoreDataID, red);

            UnitStoreData_ModIntSO blue = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            blue.m_Text = "Resists Blue";
            blue._UnitStoreDataID = Blue;
            blue.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData("TearsA") as UnitStoreData_IntSO).m_TextColor;
            blue.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Blue))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Blue] = blue;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(blue._UnitStoreDataID, blue);

            UnitStoreData_ModIntSO yellow = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            yellow.m_Text = "Resists Yellow";
            yellow._UnitStoreDataID = Yellow;
            yellow.m_TextColor = UnityEngine.Color.yellow;
            yellow.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Yellow))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Yellow] = yellow;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(yellow._UnitStoreDataID, yellow);

            UnitStoreData_ModIntSO purple = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            purple.m_Text = "Resists Purple";
            purple._UnitStoreDataID = Purple;
            purple.m_TextColor = UnityEngine.Color.magenta;
            purple.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Purple))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Purple] = purple;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(purple._UnitStoreDataID, purple);

            UnitStoreData_ModIntSO grey = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            grey.m_Text = "Resists Grey";
            grey._UnitStoreDataID = Grey;
            grey.m_TextColor = UnityEngine.Color.grey;
            grey.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Grey))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Grey] = grey;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(grey._UnitStoreDataID, grey);
        }
    }
    public class RandomizeResistancesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.SetAllResistances(caster.GenerateRandomResistances(caster.GetResistances().Length));
            return true;
        }
    }
    public class RemoveRandomResistanceEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.GetResistances().Length <= 0) return false;
            caster.RemoveResistance(caster.GetResistances().GetRandom());
            return true;
        }
    }
    public class GainRandomResistancesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.SetAllResistances(caster.GenerateRandomResistances(entryVariable));
            return true;
        }
    }
    public class AddResistanceEffect : EffectSO
    {
        public ManaColorSO resistance;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.AddResistance(resistance);
            return true;
        }
        public static AddResistanceEffect Create(ManaColorSO mana)
        {
            AddResistanceEffect ret = ScriptableObject.CreateInstance<AddResistanceEffect>();
            ret.resistance = mana;
            return ret;
        }
    }
    public static class ReplacementHandler
    {
        public static string Value => "ReplacementHandler_Internal";
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (notificationName == TriggerCalls.OnKill.ToString() && sender is IUnit unit)
            {
                unit.SimpleSetStoredValue(Value, unit.SimpleGetStoredValue(Value) + 1);
            }
        }
    }
    public class ReplacementDamageEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> newTarg = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets) if (target.HasUnit && target.Unit.SimpleGetStoredValue(ReplacementHandler.Value) > 0) newTarg.Add(target);
            return base.PerformEffect(stats, caster, newTarg.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public static class JitteryHandler
    {
        public static TriggerCalls Call => (TriggerCalls)831209474;
    }
    public static class EyePalmHandler
    {
        public static void Swap(IUnit unit)
        {
            if (unit.IsUnitCharacter) return;
            if (CombatManager.Instance._combatUI._enemiesInCombat.TryGetValue(unit.ID, out var value))
            {
                if (CombatManager.Instance._combatUI._enemyZone._enemies.Length > value.FieldID)
                {
                    if (unit.HealthColor.SharesPigmentColor(Pigments.Red))
                    {
                        CombatManager.Instance._combatUI._enemyZone._enemies[value.FieldID].FieldEntity.m_Data.m_Locator.transform.Find("Sprite").GetChild(1).gameObject.SetActive(false);
                    }
                    else
                    {
                        CombatManager.Instance._combatUI._enemyZone._enemies[value.FieldID].FieldEntity.m_Data.m_Locator.transform.Find("Sprite").GetChild(1).gameObject.SetActive(true);
                    }
                }
            }
        }
        public static void SwapPalm(this IUnit unit)
        {
            if (Check.EnemyExist("EyePalm_EN"))
            {
                if (unit is EnemyCombat enemy && enemy.Enemy == LoadedAssetsHandler.GetEnemy("EyePalm_EN"))
                {
                    CombatManager.Instance.AddUIAction(new SwapPalmUIAction(unit));
                }
            }
        }
        public class SwapPalmUIAction : CombatAction
        {
            public IUnit unit;
            public SwapPalmUIAction(IUnit unit)
            {
                this.unit = unit;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                EyePalmHandler.Swap(unit);
                yield return null;
            }
        }
    }
    public class LonelySubAction : CombatAction
    {
        public static TriggerCalls Trigger => (TriggerCalls)301832;
        public override IEnumerator Execute(CombatStats stats)
        {
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values) CombatManager.Instance.PostNotification(Trigger.ToString(), enemy, null);
            yield return null;
        }
    }
}
