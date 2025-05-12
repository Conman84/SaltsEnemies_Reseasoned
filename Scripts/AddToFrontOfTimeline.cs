using BrutalAPI;
using JetBrains.Annotations;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace SaltEnemies_Reseasoned
{
    public static class Try
    {
        public static void AddNewFrontExtraEnemyTurns(ITurn Unit, int turnsToAdd)
        {
            List<ITurn> units = new List<ITurn>();
            List<int> turns = new List<int>();
            for (int i = 0; i < turnsToAdd; i++)
            {
                units.Add(Unit);
                turns.Add(Unit.GetSingleAbilitySlotUsage(-1));
            }

            if (AddGilbertActionsToTimeLineAction.IsPending)
            {
                AddGilbertActionsToTimeLineAction.AddToPending(units.ToArray(), turns.ToArray());
            }
            else
            {
                CombatManager._instance.AddRootAction(new AddGilbertActionsToTimeLineAction(units.ToArray(), turns.ToArray()));
            }
        }
        public static void AddNewFrontEnemyTurns(List<EnemyCombat> units, List<int> turns)
        { 
            if (AddGilbertActionsToTimeLineAction.IsPending)
            {
                AddGilbertActionsToTimeLineAction.AddToPending(units.ToArray(), turns.ToArray());
            }
            else
            {
                CombatManager._instance.AddRootAction(new AddGilbertActionsToTimeLineAction(units.ToArray(), turns.ToArray()));
            }
        }
    }
    public class AddGilbertActionsToTimeLineAction : CombatAction
    {
        private static List<ITurn> Units = new List<ITurn>();

        private static List<int> AbilityID = new List<int>();

        public static bool IsPending;

        public static void ClearPending()
        {
            Units.Clear();
            AbilityID.Clear();
            IsPending = false;
        }

        public static void AddToPending(ITurn unit, int abilityID)
        {
            Units.Add(unit);
            AbilityID.Add(abilityID);
        }
        public static void AddToPending(ITurn[] units, int[] abilityIDs)
        {
            foreach (ITurn unit in units) Units.Add(unit);
            foreach (int abilityID in abilityIDs) AbilityID.Add(abilityID);
        }

        public static void TryRemoveFromPending(ITurn unit)
        {
            for (int i = 0; i < Units.Count; i++)
            {
                if (Units[i] == unit)
                {
                    Units.RemoveAt(i);
                    AbilityID.RemoveAt(i);
                }
            }
        }

        public AddGilbertActionsToTimeLineAction(ITurn unit, int abilityID)
        {
            ClearPending();
            Units.Add(unit);
            AbilityID.Add(abilityID);
            IsPending = true;
        }
        public AddGilbertActionsToTimeLineAction(ITurn[] units, int[] abilityIDs)
        {
            ClearPending();
            foreach (ITurn unit in units) Units.Add(unit);
            foreach (int abilityID in abilityIDs) AbilityID.Add(abilityID);
            IsPending = true;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            yield return UnitsCheck(stats);
            if (Units.Count == 0)
            {
                ClearPending();
            }
            else
            {
                ExtraUtils.AddGilbertActionsToTimeline(Units.ToArray(), AbilityID.ToArray());
            }
        }

        public IEnumerator UnitsCheck(CombatStats stats)
        {
            for (int i = 0; i < Units.Count; i++)
            {
                EnemyCombat Enemy = stats.TryGetEnemyOnField(Units[i].ID);
                if (Enemy == null || !Enemy.IsAlive || Enemy.CurrentHealth <= 0)
                {
                    Units.RemoveAt(i);
                    AbilityID.RemoveAt(i);
                }
            }
            yield break;
        }
    }
    public static class ExtraUtils
    {
        public static void AddGilbertActionsToTimeline(ITurn[] units, int[] abilitIDs)
        {
            Timeline_Base timeline = CombatManager._instance._stats.timeline;
            List<TurnInfo> list = new List<TurnInfo>();
            List<TurnInfo> list2 = new List<TurnInfo>();
            list.Add(CombatManager._instance._stats.timeline.Round[0]);
            //Debug.Log("CombatManager.Instance._stats.timeline.CurrentTurn " + CombatManager.Instance._stats.timeline.CurrentTurn);
            if (CombatManager._instance._stats.timeline.Round.Count > 1)
            {
                for (int i = 1; i < CombatManager._instance._stats.timeline.Round.Count; i++)
                {
                    //list2.Add(timeline.Round[i]);
                    if (i <= CombatManager.Instance._stats.timeline.CurrentTurn && !CombatManager.Instance._stats.IsPlayerTurn)
                    {
                        list.Add(timeline.Round[i]);
                    }
                    else
                    {
                        list2.Add(timeline.Round[i]);
                    }
                }
            }
            List<TurnUIInfo> list3 = new List<TurnUIInfo>();
            for (int j = 0; j < units.Length; j++)
            {
                TurnInfo item = new TurnInfo(units[j], abilitIDs[j], player: false);
                list.Add(item);
                list3.Add(item.GenerateTurnUIInfo(list.Count - 1, confused: false));
                units[j].TurnsInTimeline++;
            }
            list.AddRange(list2);
            timeline.Round = list;
            CombatManager._instance.AddUIAction(new GilbertUpdateTimelineVisualsAction(list3.ToArray()));
            CombatManager.Instance.AddUIAction(new UpdateTimelinePointerUIAction(timeline.CurrentTurn));
            AddGilbertActionsToTimeLineAction.ClearPending();
        }

        public static IEnumerator GiblertAddTimelineSlots(TurnUIInfo[] newTurns)
        {
            TimelineLayoutHandler_TurnBased TimelineHandler = CombatManager._instance._combatUI._TimelineHandler as TimelineLayoutHandler_TurnBased;
            TimelineInfo[] NewInfo = new TimelineInfo[newTurns.Length];
            List<TimelineInfo> NewSortTimelineinfo = new List<TimelineInfo>();
            List<TimelineInfo> OldSortTimelineinfo = new List<TimelineInfo>();
            NewSortTimelineinfo.Add(TimelineHandler.TimelineSlotInfo[0]);
            //Debug.Log("GilbertAddTimelineSlots");
            //Debug.Log("TimelineHandler.TimelineLayout._pointerIndex " + TimelineHandler.TimelineLayout._pointerIndex);
            for (int j = 1; j < TimelineHandler.TimelineSlotInfo.Count; j++)
            {
                //OldSortTimelineinfo.Add(TimelineHandler.TimelineSlotInfo[j]);
                if (j <= TimelineHandler.TimelineLayout._pointerIndex + 1 && !CombatManager.Instance._stats.IsPlayerTurn)
                //if (j <= CombatManager.Instance._stats.timeline.CurrentTurn && !CombatManager.Instance._stats.IsPlayerTurn)
                {
                    NewSortTimelineinfo.Add(TimelineHandler.TimelineSlotInfo[j]);
                }
                else
                {
                    OldSortTimelineinfo.Add(TimelineHandler.TimelineSlotInfo[j]);
                }
            }
            //Debug.Log("before " + NewSortTimelineinfo.Count);
            //Debug.Log("after " + OldSortTimelineinfo.Count);
            for (int i = 0; i < newTurns.Length; i++)
            {
                TurnUIInfo turnUIInfo = newTurns[i];
                EnemyCombatUIInfo enemyCombatUIInfo = TimelineHandler.EnemiesInCombat[turnUIInfo.enemyID];
                enemyCombatUIInfo.AddTimelineTurn(turnUIInfo);
                NewInfo[i] = new TimelineInfo(icon: turnUIInfo.isSecret ? null : enemyCombatUIInfo.Portrait, ab: enemyCombatUIInfo.Abilities[turnUIInfo.abilitySlotID].ability, info: turnUIInfo);
                NewSortTimelineinfo.Add(NewInfo[i]);
            }
            NewSortTimelineinfo.AddRange(OldSortTimelineinfo);
            TimelineHandler.TimelineSlotInfo = NewSortTimelineinfo;
            yield return GilbertUpdateTimelineVisuals(NewInfo, newTurns);
        }

        public static IEnumerator GilbertUpdateTimelineVisuals(TimelineInfo[] Info, TurnUIInfo[] UIInfos)
        {
            TimelineZoneLayout TimelineLayout = CombatManager._instance._combatUI._timeline;
            List<TimelineSlotGroup> NewSlots = new List<TimelineSlotGroup>();
            TimelineLayout._slotsInUse = SortTimelineSlotList(TimelineLayout._slotsInUse);
            for (int i = 0; i < Info.Length; i++)
            {
                TimelineInfo timelineInfo = Info[i];
                Sprite enemy;
                Sprite[] intents;
                Color[] spriteColors;
                if (timelineInfo.timelineIcon == null)
                {
                    enemy = TimelineLayout._blindTimelineIcon;
                    intents = null;
                    spriteColors = null;
                }
                else
                {
                    enemy = timelineInfo.timelineIcon;
                    intents = TimelineLayout.IntentHandler.GenerateSpritesFromAbility(timelineInfo.ability, casterIsCharacter: false, out spriteColors);
                }
                TimelineSlotGroup timelineSlotGroup = TimelineLayout.PrepareUnusedSlot(enemy, intents, spriteColors);
                timelineSlotGroup.SetSlotScale(grow: false);
                timelineSlotGroup.SetActivation(enable: false);
                for (int s = 0; s < TimelineLayout._slotsInUse.Count; s++)
                {
                    if (UIInfos[i].timeSlotID == TimelineLayout._slotsInUse[s].slot.TimelineSlotID)
                    {
                        ShiftTimelineSlotsDown(TimelineLayout._slotsInUse, s);
                    }
                }
                timelineSlotGroup.UpdateSlotID(UIInfos[i].timeSlotID);
                //Debug.Log("set timelineslotID " + UIInfos[i].timeSlotID);
                timelineSlotGroup.SetSiblingIndex(UIInfos[i].timeSlotID + 1);
                //Debug.Log("set sibling index: " + (UIInfos[i].timeSlotID + 1).ToString());
                //Debug.Log("sibling index proper: " + timelineSlotGroup.slot.transform.GetSiblingIndex());
                //Debug.Log("total slots in use:" + TimelineLayout._slotsInUse.Count);
                NewSlots.Add(timelineSlotGroup);
                TimelineLayout._slotsInUse = SortTimelineSlotList(TimelineLayout._slotsInUse);
                //Debug.Log("new timelineslotID " + timelineSlotGroup.slot.TimelineSlotID);
                spriteColors = null;
            }
            for (int j = 0; j < NewSlots.Count; j++)
            {
                NewSlots[j].GenerateTweenScale(grow: true, TimelineLayout._timelineMoveTime);
                NewSlots[j].SetActivation(enable: true);
            }
            TimelineLayout.UpdateTimelineContentSize(TimelineLayout._slotsInUse.Count + 1);
            yield return TimelineLayout.UpdateTimelineBackgroundSize(TimelineLayout._slotsInUse.Count + 1);
        }

        public static void ShiftTimelineSlotsDown(List<TimelineSlotGroup> Slots, int StartIndex)
        {
            int shiftedDown = 0;
            for (int num = Slots.Count - 2; num > StartIndex - 1; num--)
            {
                Slots[num].UpdateSlotID(Slots[num].slot.TimelineSlotID + 1);
                Slots[num].SetSiblingIndex(Slots[num].slot.transform.GetSiblingIndex() + 1);
                shiftedDown++;
            }
            //Debug.Log("slots shifted down: " + shiftedDown);
        }

        public static List<TimelineSlotGroup> SortTimelineSlotList(List<TimelineSlotGroup> Slots)
        {
            TimelineSlotGroup[] array = new TimelineSlotGroup[Slots.Count];
            List<int> list = new List<int>();
            for (int i = 0; i < Slots.Count; i++)
            {
                if (!list.Contains(Slots[i].slot.TimelineSlotID))
                {
                    list.Add(Slots[i].slot.TimelineSlotID);
                    continue;
                }
                do
                {
                    Slots[i].slot.TimelineSlotID++;
                }
                while (list.Contains(Slots[i].slot.TimelineSlotID));
                list.Add(Slots[i].slot.TimelineSlotID);
            }
            for (int j = 0; j < Slots.Count; j++)
            {
                if (Slots[j] != null)
                {
                    array[Slots[j].slot.TimelineSlotID - 1] = Slots[j];
                }
            }
            return array.ToList();
        }
    }
    public class GilbertUpdateTimelineVisualsAction : CombatAction
    {
        public TurnUIInfo[] turnUIInfos;

        public GilbertUpdateTimelineVisualsAction(TurnUIInfo[] UIInfos)
        {
            turnUIInfos = UIInfos;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            yield return ExtraUtils.GiblertAddTimelineSlots(turnUIInfos);
        }
    }
    //OLD, UNTESTED
    public static class GilbStensionsTwo
    {
        public static List<T> Firsten<T>(this List<T> list, T add)
        {
            List<T> newer = new List<T>() { add };
            foreach (T og in list) newer.Add(og);
            return newer;
        }
        public static void MoveToFirst(this TimelineSlotGroup self)
        {
            //Debug.Log(self + " move to first");
            self.slot.transform.SetSiblingIndex(2);
            self.intent.transform.SetSiblingIndex(2);
        }
        public static TimelineSlotGroup PrepareFrontUnusedSlot(this TimelineZoneLayout self, Sprite enemy, Sprite[] intents, Color[] intentColors)
        {
            //Debug.Log(self + " prepare front unused slot");
            if (self._unusedSlots.Count <= 0)
            {
                self.GenerateUnusedSlot();
            }

            TimelineSlotGroup timelineSlotGroup = self._unusedSlots.Dequeue();
            timelineSlotGroup.MoveToFirst();
            timelineSlotGroup.SetInformation(self._slotsInUse.Count, enemy, true, intents, intentColors);
            timelineSlotGroup.SetActivation(enable: true);
            self._slotsInUse = self._slotsInUse.Firsten(timelineSlotGroup);
            //self._slotsInUse.Add(timelineSlotGroup);
            self._pointerRect.SetAsLastSibling();
            return timelineSlotGroup;
        }
        public static IEnumerator AddFrontTimelineSlots(this TimelineZoneLayout self, TimelineInfo[] newTurns)
        {
            int count = self._slotsInUse.Count;
            for (int i = 0; i < newTurns.Length; i++)
            {
                TimelineInfo timelineInfo = newTurns[i];
                Sprite enemy;
                Sprite[] intents;
                Color[] spriteColors;
                if (timelineInfo.timelineIcon == null)
                {
                    enemy = self._blindTimelineIcon;
                    intents = null;
                    spriteColors = null;
                }
                else
                {
                    enemy = timelineInfo.timelineIcon;
                    intents = self.IntentHandler.GenerateSpritesFromAbility(timelineInfo.ability, casterIsCharacter: false, out spriteColors);
                }

                TimelineSlotGroup timelineSlotGroup = self.PrepareFrontUnusedSlot(enemy, intents, spriteColors);
                timelineSlotGroup.SetSlotScale(grow: false);
                timelineSlotGroup.SetActivation(enable: false);
            }

            for (int j = count; j < self._slotsInUse.Count; j++)
            {
                self._slotsInUse[j].GenerateTweenScale(grow: true, self._timelineMoveTime);
                self._slotsInUse[j].SetActivation(enable: true);
            }

            self.UpdateTimelineContentSize(self._slotsInUse.Count + 1);
            yield return self.UpdateTimelineBackgroundSize(self._slotsInUse.Count + 1);
        }
        public static IEnumerator AddFrontTimelineSlots(this TimelineLayoutHandler_TurnBased self, TurnUIInfo[] newTurns, float timeUntilNextTurn)
        {
            TimelineInfo[] array = new TimelineInfo[newTurns.Length];
            for (int i = 0; i < newTurns.Length; i++)
            {
                TurnUIInfo turnUIInfo = newTurns[i];
                foreach (EnemyCombatUIInfo uiin in self.EnemiesInCombat.Values)
                {
                    foreach (List<int> dual in uiin.AbilityTimelineSlots)
                    {
                        List<int> newer = new List<int>(dual);
                        dual.Clear();
                        foreach (int inni in newer) dual.Add(inni + 1);
                    }
                }
                EnemyCombatUIInfo enemyCombatUIInfo = self.EnemiesInCombat[turnUIInfo.enemyID];
                enemyCombatUIInfo.AddTimelineFrontTurn(turnUIInfo);
                Sprite icon = (turnUIInfo.isSecret ? null : enemyCombatUIInfo.Portrait);
                AbilitySO ability = enemyCombatUIInfo.Abilities[turnUIInfo.abilitySlotID].ability;
                array[i] = new TimelineInfo(turnUIInfo, icon, ability);
            }

            List<TimelineInfo> gap = new List<TimelineInfo>(array);
            gap.AddRange(self.TimelineSlotInfo);
            self.TimelineSlotInfo.AddRange(gap);
            yield return self.TimelineLayout.AddTimelineSlots(array);
        }
        public static void AddTimelineFrontTurn(this EnemyCombatUIInfo self, TurnUIInfo turn)
        {
            //Debug.Log(self + " add tiemline front turn");
            if (!turn.isSecret && turn.abilitySlotID >= 0 && turn.abilitySlotID < self.AbilityTimelineSlots.Count)
            {
                self.AbilityTimelineSlots[turn.abilitySlotID].Add(0);//turn.timeSlotID
            }
        }
        public static IEnumerator AddFrontTimelineSlots(this CombatVisualizationController self, TurnUIInfo[] enemyTurns, float timeUntilNextTurn)
        {
            yield return (self._TimelineHandler as TimelineLayoutHandler_TurnBased).AddFrontTimelineSlots(enemyTurns, timeUntilNextTurn);
            if (!self._isInfoFromCharacter && self._unitInfoID != -1)
            {
                self.TryUpdateEnemyIDInformation(self._unitInfoID);
            }
        }
        public static void AddFrontExtraEnemyTurns(this Timeline_TurnBase self, List<EnemyCombat> units, List<int> abilitySlots)
        {
            //Debug.Log(self + " add front extra enemy turns");
            TurnUIInfo[] list = new TurnUIInfo[units.Count];
            for (int i = 0; i < units.Count; i++)
            {
                if (self.Enemies.Contains(units[i]))
                {
                    TurnInfo item = new TurnInfo(units[i], abilitySlots[i], player: false);
                    List<TurnInfo> gap = new List<TurnInfo>(self.Round);
                    self.Round.Clear();
                    for (int x = 0; x <= i; x++) self.Round.Add(gap[x]);
                    self.Round.Add(item);
                    for (int w = i + 1; w < gap.Count; w++) self.Round.Add(gap[w]);
                    list[i] = item.GenerateTurnUIInfo(1, self.IsConfused);//units.Count - (i + 1)
                }
            }
            //ReadOutRound(self.Round);
            CombatManager.Instance.AddUIAction(new AddedSlotsFrontTimelineUIAction(list.ToArray()));
        }
        public static void TryAddNewFrontExtraEnemyTurns(this Timeline_TurnBase self, ITurn unit, int turnsToAdd)
        {
            if (self.Enemies.Contains(unit))
            {
                List<TurnUIInfo> list = new List<TurnUIInfo>();
                for (int i = 0; i < turnsToAdd; i++)
                {
                    int singleAbilitySlotUsage = unit.GetSingleAbilitySlotUsage(-1);
                    TurnInfo item = new TurnInfo(unit, singleAbilitySlotUsage, player: false);
                    List<TurnInfo> gap = new List<TurnInfo>(self.Round);
                    self.Round.Clear();
                    for (int x = 0; x <= i; x++) self.Round.Add(gap[x]);
                    self.Round.Add(item);
                    for (int w = i + 1; w < gap.Count; w++) self.Round.Add(gap[w]);
                    list.Add(item.GenerateTurnUIInfo(self.Round.Count - 1, self.IsConfused));
                }

                unit.TurnsInTimeline += list.Count;
                CombatManager.Instance.AddUIAction(new AddedSlotsFrontTimelineUIAction(list.ToArray()));
            }
        }
    }
    public class AddedSlotsFrontTimelineUIAction : CombatAction
    {
        public TurnUIInfo[] _enemyTurns;

        public AddedSlotsFrontTimelineUIAction(TurnUIInfo[] enemyTurns)
        {
            _enemyTurns = enemyTurns;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            //Debug.Log("Added slots front timeline ui action");
            yield return stats.combatUI.AddFrontTimelineSlots(_enemyTurns, stats.timeline.TimeUntilNextTurn);
        }
    }
}
