using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BrutalAPI;
using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using UnityEngine;

//Set the notouch passive's triggercall to OnClickPassiveAbility.Trigger

namespace SaltEnemies_Reseasoned
{
    public class OnClickPassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;
        public override bool DoesPassiveTrigger => true;
        public static string TimesClicked => "OnClick_TimesClicked_PA";
        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            if ((unit as EnemyCombat)._currentName != "Strange Box")
            {
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, GetPassiveLocData().text, this.passiveIcon));
                EffectInfo entering = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, Targeting.Slot_SelfSlot);
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(new EffectInfo[] { entering }, unit));
            }
            unit.SimpleSetStoredValue(TimesClicked, unit.SimpleGetStoredValue(TimesClicked) + 1);

        }
        public override void OnPassiveConnected(IUnit unit)
        {
            Setup();
            EffectInfo entering = Effects.GenerateEffect(ScriptableObject.CreateInstance<TurnOnOnClickTriggerEffect>(), 1, Targeting.Slot_SelfAll);
            CombatManager.Instance.AddPriorityRootAction(new EffectAction(new EffectInfo[] { entering }, unit));
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            EffectInfo exiting = Effects.GenerateEffect(ScriptableObject.CreateInstance<TurnOffOnClickTriggerEffect>(), 1, Targeting.Slot_SelfAll);
            CombatManager.Instance.AddPriorityRootAction(new EffectAction(new EffectInfo[] { exiting }, unit));
        }
        public static int inCombatClicking = 0;
        public static void Reset()
        {
            inCombatClicking = 0;
        }
        public static void OnClicked(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout enemyOfField)
        {
            orig(enemyOfField);
            if (inCombatClicking <= 0)
            {
                return;
            }
            else
            {
                if (enemyOfField == null)
                {
                    Debug.Log("layout was null, quitting");
                    return;
                }

                CombatManager.Instance.AddPrioritySubAction(new TryTriggerOnClickEffectAction(enemyOfField.EnemyID, false));
            }
        }
        public static void OnTimelineSelected(Action<TimelineSlotLayout> orig, TimelineSlotLayout self)
        {
            orig(self);
            if (inCombatClicking <= 0)
            {
                return;
            }
            CombatStats stats = CombatManager.Instance._stats;
            TimelineInfo timelineInfo = stats.combatUI._TimelineHandler.TimelineSlotInfo[self.TimelineSlotID];
            if (timelineInfo.isSecret)
            {
                return;
            }
            int enemyID = timelineInfo.enemyID;
            int num = -1;
            if (stats.combatUI._enemiesInCombat.TryGetValue(enemyID, out EnemyCombatUIInfo value))
            {
                num = value.ID;
            }


            CombatManager.Instance.AddPrioritySubAction(new TryTriggerOnClickEffectAction(num, false));
        }
        static bool Set;
        public static void Setup()
        {
            if (Set) return;
            Set = true;
            IDetour addOnClickedIDetour = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.OnSlotClicked), ~BindingFlags.Default), typeof(OnClickPassiveAbility).GetMethod(nameof(OnClicked), ~BindingFlags.Default));
            IDetour addTimelineClickedIDetour = new Hook(typeof(TimelineSlotLayout).GetMethod(nameof(TimelineSlotLayout.OnSlotClicked), ~BindingFlags.Default), typeof(OnClickPassiveAbility).GetMethod(nameof(OnTimelineSelected), ~BindingFlags.Default));
            MainMenuException.AddAction(Reset);
        }
        public static TriggerCalls Trigger => (TriggerCalls)8982177;
    }
    public class TryTriggerOnClickEffectAction : CombatAction
    {
        public int _ID;
        public bool _IsChara;
        public TryTriggerOnClickEffectAction(int ID, bool chara)
        {
            _ID = ID;
            _IsChara = chara;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (_IsChara)
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (chara.ID == _ID) CombatManager.Instance.PostNotification(OnClickPassiveAbility.Trigger.ToString(), chara, null);
                }
            }
            else
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.ID == _ID) CombatManager.Instance.PostNotification(OnClickPassiveAbility.Trigger.ToString(), enemy, null);
                }
            }
            yield break;
        }
    }
    public class TurnOffOnClickTriggerEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            if (caster.SimpleGetStoredValue("OnClickPA") > 0)
            {
                OnClickPassiveAbility.inCombatClicking -= 1;
                caster.SimpleSetStoredValue("OnClickPA", 0);
            }
            exitAmount = 1;
            return true;
        }
    }
    public class TurnOnOnClickTriggerEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.SimpleGetStoredValue("OnClickPA") == 0)
            {
                OnClickPassiveAbility.inCombatClicking += 1;
                caster.SimpleSetStoredValue("OnClickPA", 1);
            }
            return true;
        }
    }
    public class UnlockingEffectCondition : EffectConditionSO
    {
        public static string value => "Freud_Unlocking_A";
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            caster.SimpleSetStoredValue(value, Math.Max(0, caster.SimpleGetStoredValue(value) - 1));
            if (caster.SimpleGetStoredValue(value) <= 0) return true;
            return false;
        }
    }
    public class FreudEnterEffect : EffectSO
    {
        public static UnitStoreData_BasicSO Reader
        {
            get
            {
                if (!set)
                {
                    set = true;
                    UnitStoreData_ModIntSO value_unlocking = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
                    value_unlocking.m_Text = "Unlocking: {0}";
                    value_unlocking._UnitStoreDataID = UnlockingEffectCondition.value;
                    value_unlocking.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
                    value_unlocking.m_CompareDataToThis = -1;
                    if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(UnlockingEffectCondition.value))
                        LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[UnlockingEffectCondition.value] = value_unlocking;
                    else
                        LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_unlocking._UnitStoreDataID, value_unlocking);

                    IntentInfoBasic unlockingintent = new IntentInfoBasic();
                    unlockingintent._color = Color.white;
                    unlockingintent._sprite = ResourceLoader.LoadSprite("UnlockingIntent.png");
                    if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(UnlockingEffectCondition.value)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[UnlockingEffectCondition.value] = unlockingintent;
                    else LoadedDBsHandler.IntentDB.AddNewBasicIntent(UnlockingEffectCondition.value, unlockingintent);
                }
                return LoadedDBsHandler.MiscDB.GetUnitStoreData(UnlockingEffectCondition.value);
            }
        }
        static bool set;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (!set)
            {
                UnitStoreData_BasicSO a = Reader;
            }
            caster.SimpleSetStoredValue(UnlockingEffectCondition.value, 3);
            exitAmount = 0;
            return true;
        }
    }
    public class UnlockingEffect : AddTurnTargetToTimelineEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            List<EnemyCombat> enemies = new List<EnemyCombat>();
            List<int> abilities = new List<int>();

            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                int num = UnityEngine.Random.Range(0, 3);
                if (UnityEngine.Random.Range(0f, 1f) < 0.25f) num++;

                for (int i = 0; i < num; i++)
                {
                    enemies.Add(enemy);
                    abilities.Add(enemy.GetSingleAbilitySlotUsage(-1));
                }
            }

            stats.timeline.AddExtraEnemyTurns(enemies, abilities);

            exitAmount = abilities.Count;

            return exitAmount > 0;
        }
    }
}