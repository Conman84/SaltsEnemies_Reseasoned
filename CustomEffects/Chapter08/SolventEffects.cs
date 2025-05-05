using BrutalAPI;
using DG.Tweening;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using SaltsEnemies_Reseasoned;
using EnemyPack.Effects;

//To put it lightly, this is where it starts getting annoying

//Call AmbushManager.Setup() in awake
//Call ShieldPiercer.Setup() in awake
//Set Cowardice's m_PassiveID to "Salt_Coward_PA"
//for future, but make sure Butterfly's Ethereal m_PassiveID = "Salt_Ethereal_PA"
//for future, but make sure Skyloft's Flithering m_PassiveID = "Salt_Flithering_PA"
//for future, make sure Skyloft's Lazy m_PassiveID = "Salt_Lazy_PA". you should be a able to grab these out of flithering handler and ButterflyUnboxer
//ButterflyUnboxer.ButterflyPassive is Ethereal's ID
//FlitheringHandler.Flithering is Flithering
//ButterflyUnboxer.SkyloftPassive is Lazy

namespace SaltEnemies_Reseasoned
{
    public static class AmbushManager
    {
        public static int Patiently = 8086792;

        public static void PostNotif(IUnit unit)
        {
            foreach (TargetSlotInfo target in Targeting.Slot_Front.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter))
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.PostNotification(((TriggerCalls)Patiently).ToString(), target.Unit, null);
                }
            }
        }

        public static void EnemySwap(Action<EnemyCombat, int> orig, EnemyCombat self, int slotID)
        {
            orig(self, slotID);
            PostNotif(self);

        }
        public static void CharacterSwap(Action<CharacterCombat, int> orig, CharacterCombat self, int slotID)
        {
            orig(self, slotID);
            PostNotif(self);
        }

        public static void Setup()
        {
            IDetour EnemySwapTo = new Hook((MethodBase)typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.SwapTo), ~BindingFlags.Default), typeof(AmbushManager).GetMethod(nameof(EnemySwap), ~BindingFlags.Default));
            IDetour EnemySwappedTo = new Hook((MethodBase)typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.SwappedTo), ~BindingFlags.Default), typeof(AmbushManager).GetMethod(nameof(EnemySwap), ~BindingFlags.Default));
            IDetour CharaSwapTo = new Hook((MethodBase)typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.SwapTo), ~BindingFlags.Default), typeof(AmbushManager).GetMethod(nameof(CharacterSwap), ~BindingFlags.Default));
            IDetour CharaSwappedTo = new Hook((MethodBase)typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.SwappedTo), ~BindingFlags.Default), typeof(AmbushManager).GetMethod(nameof(CharacterSwap), ~BindingFlags.Default));
        }
    }
    public class CowardCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            CombatStats stats = CombatManager.Instance._stats;
            int amount = 0;
            if (effector.IsUnitCharacter)
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (chara.IsAlive && !chara.ContainsPassiveAbility("Salt_Coward_PA")) amount++;
                }
            }
            else
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.IsAlive && !enemy.ContainsPassiveAbility("Salt_Coward_PA"))
                    {
                        if (!enemy.ContainsPassiveAbility(FlitheringHandler.Flithering)) amount++;
                    }
                }
            }
            return amount <= 0;
        }
    }
    public class CowardEffect : EffectSO
    {
        public static FleeTargetEffect flee = CreateInstance<FleeTargetEffect>();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            FlitheringHandler.Run(stats);
            if (flee == null) flee = CreateInstance<FleeTargetEffect>();
            List<int> list = new List<int>();
            List<bool> list2 = new List<bool>();
            List<string> list3 = new List<string>();
            List<Sprite> list4 = new List<Sprite>();
            List<EnemyCombat> list5 = new List<EnemyCombat>();
            foreach (EnemyCombat value in stats.EnemiesOnField.Values)
            {
                if (value.IsAlive && value.ContainsPassiveAbility("Salt_Coward_PA"))
                {
                    list2.Add(value.IsUnitCharacter);
                    list.Add(value.ID);
                    list3.Add("Cowardice");
                    Debug.LogError("CowardEffect: MAKE SURE THIS IS THE RIGHT SPRITE FOR COWARDICE");
                    list4.Add(ResourceLoader.LoadSprite("Cowardice.png"));
                    list5.Add(value);
                }
            }
            if (list5.Count >= 0)
                CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(list.ToArray(), list2.ToArray(), list3.ToArray(), list4.ToArray()));
            exitAmount = 0;
            foreach (EnemyCombat enemy in list5)
            {
                enemy.UnitWillFlee();
                CombatManager.Instance.AddSubAction(new FleetingUnitAction(enemy.ID, enemy.IsUnitCharacter));
                exitAmount++;
            }
            return exitAmount > 0;
        }
    }
    public static class FlitheringHandler
    {
        public static string Flithering => "Salt_Flithering_PA";
        public static void Run(CombatStats stats)
        {
            try
            {
                bool yeah = stats.EnemiesOnField.Count > 0;
                int coward = 0;
                int wither = 0;
                List<EnemyCombat> list5 = new List<EnemyCombat>();
                List<int> list = new List<int>();
                List<bool> list2 = new List<bool>();
                List<string> list3 = new List<string>();
                List<Sprite> list4 = new List<Sprite>();
                foreach (EnemyCombat value in stats.EnemiesOnField.Values)
                {
                    if (value.IsAlive && value.CurrentHealth > 0)
                    {
                        if (value.TryGetPassiveAbility(Flithering, out var passi) && value.CanPassiveTrigger(Flithering))
                        {
                            list5.Add(value);
                            list2.Add(value.IsUnitCharacter);
                            list.Add(value.ID);
                            list3.Add(passi.GetPassiveLocData().text);
                            list4.Add(passi.passiveIcon);
                        }
                        else if (value.TryGetPassiveAbility("Salt_Coward_PA", out var passs) && value.CanPassiveTrigger("Salt_Coward_PA"))
                        {
                            coward++;
                            continue;
                        }
                        else if (value.TryGetPassiveAbility(PassiveType_GameIDs.Withering.ToString(), out var passive) && value.CanPassiveTrigger(PassiveType_GameIDs.Withering.ToString()))
                        {
                            wither++;
                            continue;
                        }
                        else
                        {
                            yeah = false;
                            break;
                        }
                    }
                }
                if (coward > 0 && wither > 0) yeah = false;
                if (yeah)
                {
                    CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(list.ToArray(), list2.ToArray(), list3.ToArray(), list4.ToArray()));
                    foreach (EnemyCombat enemy in list5)
                    {
                        CombatManager.Instance.PostNotification(TriggerCalls.OnFleeting.ToString(), enemy, false);
                        if (enemy.ContainsPassiveAbility(ButterflyUnboxer.ButterflyPassive) && enemy.CurrentHealth > 0)
                        {
                            UnityEngine.Debug.LogError("FlitheringHandler.Run make sure loading correct passive icon for Ethereal");
                            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(enemy.ID, enemy.IsUnitCharacter, "Ethereal", ResourceLoader.LoadSprite("Ethereal.png")));
                            stats.TryBoxEnemy(enemy.ID, ButterflyUnboxer.GetDefault(enemy.ID), CombatType_GameIDs.Exit_Obliterate.ToString());
                            ButterflyUnboxer.Boxeds.Add(enemy.ID);
                        }
                        else if (enemy.ContainsPassiveAbility(ButterflyUnboxer.SkyloftPassive) && enemy.CurrentHealth > 0)
                        {
                            Debug.LogError("FlitheringHandler.Run make sure loading correct passive icon for Lazy");
                            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(enemy.ID, enemy.IsUnitCharacter, "Lazy", ResourceLoader.LoadSprite("Lazy.png")));
                            stats.TryBoxEnemy(enemy.ID, ButterflyUnboxer.GetDefault(enemy.ID, true), CombatType_GameIDs.Exit_Fleeting.ToString());
                            ButterflyUnboxer.Boxeds.Add(enemy.ID);
                        }
                        else
                        {
                            enemy.FleeEnemy();
                            enemy.DisconnectPassives();
                            enemy.RemoveAllStatusEffects(showInfo: false);
                            enemy.FinalizationEnd(disconnectPassives: false);
                            CombatManager.Instance.AddUIAction(new EnemyFleetingUIAction(enemy.ID));
                            stats.RemoveEnemy(enemy.ID);
                            enemy.FinalizeFleeting();
                        }
                        //CombatManager.Instance.AddSubAction(new FleetingUnitAction(enemy.ID, enemy.IsUnitCharacter));
                    }
                }
            }
            catch
            {
                UnityEngine.Debug.LogError("Flithering fail");
            }
        }
        public static IEnumerator Execute(Func<CombatAction, CombatStats, IEnumerator> orig, CombatAction self, CombatStats stats)
        {
            if (self is EnemyWitheringAction)
            {
                Run(stats);
            }

            yield return orig(self, stats);
        }
        public static void Setup()
        {
            try
            {
                IDetour hook = new Hook(typeof(EnemyWitheringAction).GetMethod(nameof(EnemyWitheringAction.Execute), ~BindingFlags.Default), typeof(FlitheringHandler).GetMethod(nameof(Execute), ~BindingFlags.Default));
            }
            catch
            {
                UnityEngine.Debug.LogError("Flithering setup fail");
            }
        }
    }
    public class ButterflyUnboxer : UnboxUnitHandlerSO
    {
        public override bool CanBeUnboxed(CombatStats stats, BoxedUnit unit, object senderData)
        {
            //UnityEngine.Debug.Log("Checkig can unbox + " + ID);
            if (checkTicked)
            {
                if (!ticked)
                {
                    ticked = true;
                    return false;
                }
            }
            if (!unit.unit.IsUnitCharacter)
            {
                if (stats.EnemiesAlive)
                {
                    foreach (CombatSlot slot in stats.combatSlots._enemySlots)
                    {
                        if (!slot.HasUnit) return true;
                    }
                }
            }
            else
            {
                if (stats.CharactersAlive)
                {
                    foreach (CombatSlot slot in stats.combatSlots._characterSlots)
                    {
                        if (!slot.HasUnit) return true;
                    }
                }
            }
            return false;
        }
        public int ID;
        public bool ticked;
        public bool checkTicked;
        public static ButterflyUnboxer GetDefault(int id, bool ticking = false)
        {
            ButterflyUnboxer basic = ScriptableObject.CreateInstance<ButterflyUnboxer>();
            basic._unboxConditions = new TriggerCalls[] { (TriggerCalls)7106822 };
            basic.ID = id;
            basic.ticked = false;
            basic.checkTicked = ticking;
            return basic;
        }
        public static string ButterflyPassive => "Salt_Ethereal_PA";
        public static string SkyloftPassive => "Salt_Lazy_PA";
        public static IEnumerator Execute(Func<FleetingUnitAction, CombatStats, IEnumerator> orig, FleetingUnitAction self, CombatStats stats)
        {
            bool flag = false;
            if (self._isUnitCharacter)
            {
                CharacterCombat characterCombat = stats.TryGetCharacterOnField(self._unitID);
                if (characterCombat != null && characterCombat.CurrentHealth > 0)
                {
                    if (characterCombat != null && characterCombat.ContainsPassiveAbility(ButterflyPassive))
                    {
                        flag = true;
                        stats.TryBoxCharacter(self._unitID, ButterflyUnboxer.GetDefault(self._unitID), CombatType_GameIDs.Exit_Obliterate.ToString());
                    }
                    else if (characterCombat != null && characterCombat.ContainsPassiveAbility(SkyloftPassive))
                    {
                        flag = true;
                        stats.TryBoxCharacter(self._unitID, ButterflyUnboxer.GetDefault(self._unitID, true), CombatType_GameIDs.Exit_Fleeting.ToString());
                    }
                }
            }
            else
            {
                EnemyCombat enemyCombat = stats.TryGetEnemyOnField(self._unitID);
                if (enemyCombat != null && enemyCombat.CurrentHealth > 0)
                {
                    if (enemyCombat != null && enemyCombat.ContainsPassiveAbility(ButterflyPassive))
                    {
                        flag = true;
                        stats.TryBoxEnemy(self._unitID, ButterflyUnboxer.GetDefault(enemyCombat.ID), CombatType_GameIDs.Exit_Obliterate.ToString());
                        Boxeds.Add(enemyCombat.ID);
                    }
                    else if (enemyCombat != null && enemyCombat.ContainsPassiveAbility(SkyloftPassive))
                    {
                        flag = true;
                        stats.TryBoxEnemy(self._unitID, ButterflyUnboxer.GetDefault(enemyCombat.ID, true), CombatType_GameIDs.Exit_Fleeting.ToString());
                        Boxeds.Add(enemyCombat.ID);
                    }
                }
            }
            if (flag) yield return null;
            else yield return orig(self, stats);
        }
        public static List<int> Boxeds = new List<int>();
        public override void ProcessUnbox(CombatStats stats, BoxedUnit unit, object senderData)
        {
            base.ProcessUnbox(stats, unit, senderData);
            Boxeds.Remove(ID);
            AddTurnCasterToTimelineEffect blah = ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>();
            CombatManager.Instance.AddRootAction(new EffectAction(new EffectInfo[]
            {
                Effects.GenerateEffect(blah, 1, Targeting.Slot_SelfSlot)
            }, unit.unit));

        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(FleetingUnitAction).GetMethod(nameof(FleetingUnitAction.Execute), ~BindingFlags.Default), typeof(ButterflyUnboxer).GetMethod(nameof(Execute), ~BindingFlags.Default));
        }
        public static void EndCombatCheck()
        {
            CombatStats stats = CombatManager.Instance._stats;
            foreach (int iD in Boxeds)
            {
                try
                {
                    if (stats.BoxedEnemies.TryGetValue(iD, out var value))
                    {
                        IUnit unit = value.unit;
                        EnemyCombat enemyCombat = stats.Enemies[unit.ID];
                    }
                }
                catch
                {
                    UnityEngine.Debug.LogError("missing enemy from id: " + iD);
                }
            }
        }

    }
    public class IsFrontTargetCondition : EffectConditionSO
    {
        public bool returnTrue = false;

        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            TargetSlotInfo[] check = Targeting.Slot_Front.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter);
            foreach (TargetSlotInfo target in check)
            {
                if (target.HasUnit) return returnTrue;
            }
            return !returnTrue;
        }
        public static IsFrontTargetCondition Create(bool should)
        {
            IsFrontTargetCondition ret = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
            ret.returnTrue = should;
            return ret;
        }
    }
    public class CopyStatusOntoCasterEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool casterIncluded = false;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit == caster) casterIncluded = true;
            }
            if (casterIncluded)
            {
                foreach (IStatusEffect stat in new List<IStatusEffect>((caster as IStatusEffector).StatusEffects))
                {
                    if (stat is StatusEffect_Holder status)
                    {
                        int content = status.m_ContentMain;
                        int restrictor = status.Restrictor;
                        if (caster.ApplyStatusEffect(status._Status, content, restrictor))
                        {
                            exitAmount += content;
                            exitAmount += restrictor;
                        } 
                    }
                }
            }
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit != caster)
                {

                    foreach (IStatusEffect stat in new List<IStatusEffect>((target.Unit as IStatusEffector).StatusEffects))
                    {
                        if (stat is StatusEffect_Holder status)
                        {
                            int content = status.m_ContentMain;
                            int restrictor = status.Restrictor;
                            if (caster.ApplyStatusEffect(status._Status, content, restrictor))
                            {
                                exitAmount += content;
                                exitAmount += restrictor;
                            }
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class FakeOneFrailEffect : ApplyFrailEffect
    {
        public static bool FakeApplyStatusEffect(EnemyCombat enemy, StatusEffect_SO status, int amount, int restrictor = 0)
        {
            StatusFieldApplication statusFieldApplication = new StatusFieldApplication(status.StatusID, status.IsPositive, amount);
            CombatManager.Instance.PostNotification(TriggerCalls.CanApplyStatusEffect.ToString(), enemy, statusFieldApplication);
            if (!statusFieldApplication.canBeApplied)
            {
                return false;
            }

            bool flag = false;
            bool flag2 = true;
            int amount2 = 0;
            for (int i = 0; i < enemy.StatusEffects.Count; i++)
            {
                IStatusEffect statusEffect = enemy.StatusEffects[i];
                if (statusEffect.IsStatus(status.StatusID))
                {
                    flag2 = statusEffect.TryAddContent(amount, restrictor);
                    amount2 = statusEffect.StatusContent;
                    flag = true;
                    bool usesNumberOnUIPopUp = statusEffect.TryUseNumberOnPopUp && amount != 0;
                    CombatManager.Instance.AddUIAction(new EnemyStatusEffectUpdatedUIAction(enemy.ID, i, statusEffect.DisplayText, playUpdateSound: true, amount - 1, usesNumberOnUIPopUp));
                    break;
                }
            }

            if (!flag)
            {
                IStatusEffect statusEffect2 = status.GenerateHolder(amount, restrictor);
                enemy.StatusEffects.Add(statusEffect2);
                statusEffect2.OnTriggerAttached(enemy);
                amount2 = statusEffect2.StatusContent;
                bool usesNumberOnUIPopUp2 = statusEffect2.TryUseNumberOnPopUp && amount != 0;
                CombatManager.Instance.AddUIAction(new EnemyStatusEffectAppliedUIAction(enemy.ID, statusEffect2.EffectInfo, statusEffect2.DisplayText, amount - 1, usesNumberOnUIPopUp2));
                CombatManager.Instance.PostNotification(TriggerCalls.OnStatusEffectApplied.ToString(), enemy, statusFieldApplication);
            }

            if (flag2)
            {
                statusFieldApplication.amount = amount2;
                CombatManager.Instance.PostNotification(TriggerCalls.OnStatusEffectContentAdded.ToString(), enemy, statusFieldApplication);
            }

            return flag2;
        }
        public bool FakeApplyStatusEffect(CharacterCombat chara, StatusEffect_SO status, int amount, int restrictor = 0)
        {
            StatusFieldApplication statusFieldApplication = new StatusFieldApplication(status.StatusID, status.IsPositive, amount);
            CombatManager.Instance.PostNotification(TriggerCalls.CanApplyStatusEffect.ToString(), this, statusFieldApplication);
            if (!statusFieldApplication.canBeApplied)
            {
                return false;
            }

            bool flag = false;
            bool flag2 = true;
            int amount2 = 0;
            for (int i = 0; i < chara.StatusEffects.Count; i++)
            {
                IStatusEffect statusEffect = chara.StatusEffects[i];
                if (statusEffect.IsStatus(status.StatusID))
                {
                    flag2 = statusEffect.TryAddContent(amount, restrictor);
                    amount2 = statusEffect.StatusContent;
                    flag = true;
                    bool usesNumberOnUIPopUp = statusEffect.TryUseNumberOnPopUp && amount != 0;
                    CombatManager.Instance.AddUIAction(new CharacterStatusEffectUpdatedUIAction(chara.ID, i, statusEffect.DisplayText, playUpdateSound: true, amount - 1, usesNumberOnUIPopUp));
                    break;
                }
            }

            if (!flag)
            {
                IStatusEffect statusEffect2 = status.GenerateHolder(amount, restrictor);
                chara.StatusEffects.Add(statusEffect2);
                statusEffect2.OnTriggerAttached(chara);
                amount2 = statusEffect2.StatusContent;
                bool usesNumberOnUIPopUp2 = statusEffect2.TryUseNumberOnPopUp && amount != 0;
                CombatManager.Instance.AddUIAction(new CharacterStatusEffectAppliedUIAction(chara.ID, statusEffect2.EffectInfo, statusEffect2.DisplayText, amount - 1, usesNumberOnUIPopUp2));
                chara.SetVolatileUpdateUIAction();
                CombatManager.Instance.PostNotification(TriggerCalls.OnStatusEffectApplied.ToString(), chara, statusFieldApplication);
            }

            if (flag2)
            {
                statusFieldApplication.amount = amount2;
                CombatManager.Instance.PostNotification(TriggerCalls.OnStatusEffectContentAdded.ToString(), chara, statusFieldApplication);
            }

            return flag2;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            _Status = StatusField.Frail;

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
        public int FakeApplyStatusEffect(IUnit unit, int entryVariable)
        {
            int num = (_RandomBetweenPrevious ? UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1) : entryVariable);
            if (num < _Status.MinimumRequiredToApply)
            {
                return 0;
            }

            if (unit is CharacterCombat chara)
            {
                if (!FakeApplyStatusEffect(chara, _Status, num))
                {
                    return 0;
                }
            }
            else if (unit is EnemyCombat enemy)
            {
                if (!FakeApplyStatusEffect(enemy, _Status, num))
                {
                    return 0;
                }
            }


            return Mathf.Max(1, num);
        }
    }
    public class FakeOneRupturedEffect : ApplyRupturedEffect
    {
        public static bool FakeApplyStatusEffect(EnemyCombat enemy, StatusEffect_SO status, int amount, int restrictor = 0)
        {
            StatusFieldApplication statusFieldApplication = new StatusFieldApplication(status.StatusID, status.IsPositive, amount);
            CombatManager.Instance.PostNotification(TriggerCalls.CanApplyStatusEffect.ToString(), enemy, statusFieldApplication);
            if (!statusFieldApplication.canBeApplied)
            {
                return false;
            }

            bool flag = false;
            bool flag2 = true;
            int amount2 = 0;
            for (int i = 0; i < enemy.StatusEffects.Count; i++)
            {
                IStatusEffect statusEffect = enemy.StatusEffects[i];
                if (statusEffect.IsStatus(status.StatusID))
                {
                    flag2 = statusEffect.TryAddContent(amount, restrictor);
                    amount2 = statusEffect.StatusContent;
                    flag = true;
                    bool usesNumberOnUIPopUp = statusEffect.TryUseNumberOnPopUp && amount != 0;
                    CombatManager.Instance.AddUIAction(new EnemyStatusEffectUpdatedUIAction(enemy.ID, i, statusEffect.DisplayText, playUpdateSound: true, amount - 1, usesNumberOnUIPopUp));
                    break;
                }
            }

            if (!flag)
            {
                IStatusEffect statusEffect2 = status.GenerateHolder(amount, restrictor);
                enemy.StatusEffects.Add(statusEffect2);
                statusEffect2.OnTriggerAttached(enemy);
                amount2 = statusEffect2.StatusContent;
                bool usesNumberOnUIPopUp2 = statusEffect2.TryUseNumberOnPopUp && amount != 0;
                CombatManager.Instance.AddUIAction(new EnemyStatusEffectAppliedUIAction(enemy.ID, statusEffect2.EffectInfo, statusEffect2.DisplayText, amount - 1, usesNumberOnUIPopUp2));
                CombatManager.Instance.PostNotification(TriggerCalls.OnStatusEffectApplied.ToString(), enemy, statusFieldApplication);
            }

            if (flag2)
            {
                statusFieldApplication.amount = amount2;
                CombatManager.Instance.PostNotification(TriggerCalls.OnStatusEffectContentAdded.ToString(), enemy, statusFieldApplication);
            }

            return flag2;
        }
        public bool FakeApplyStatusEffect(CharacterCombat chara, StatusEffect_SO status, int amount, int restrictor = 0)
        {
            StatusFieldApplication statusFieldApplication = new StatusFieldApplication(status.StatusID, status.IsPositive, amount);
            CombatManager.Instance.PostNotification(TriggerCalls.CanApplyStatusEffect.ToString(), this, statusFieldApplication);
            if (!statusFieldApplication.canBeApplied)
            {
                return false;
            }

            bool flag = false;
            bool flag2 = true;
            int amount2 = 0;
            for (int i = 0; i < chara.StatusEffects.Count; i++)
            {
                IStatusEffect statusEffect = chara.StatusEffects[i];
                if (statusEffect.IsStatus(status.StatusID))
                {
                    flag2 = statusEffect.TryAddContent(amount, restrictor);
                    amount2 = statusEffect.StatusContent;
                    flag = true;
                    bool usesNumberOnUIPopUp = statusEffect.TryUseNumberOnPopUp && amount != 0;
                    CombatManager.Instance.AddUIAction(new CharacterStatusEffectUpdatedUIAction(chara.ID, i, statusEffect.DisplayText, playUpdateSound: true, amount - 1, usesNumberOnUIPopUp));
                    break;
                }
            }

            if (!flag)
            {
                IStatusEffect statusEffect2 = status.GenerateHolder(amount, restrictor);
                chara.StatusEffects.Add(statusEffect2);
                statusEffect2.OnTriggerAttached(chara);
                amount2 = statusEffect2.StatusContent;
                bool usesNumberOnUIPopUp2 = statusEffect2.TryUseNumberOnPopUp && amount != 0;
                CombatManager.Instance.AddUIAction(new CharacterStatusEffectAppliedUIAction(chara.ID, statusEffect2.EffectInfo, statusEffect2.DisplayText, amount - 1, usesNumberOnUIPopUp2));
                chara.SetVolatileUpdateUIAction();
                CombatManager.Instance.PostNotification(TriggerCalls.OnStatusEffectApplied.ToString(), chara, statusFieldApplication);
            }

            if (flag2)
            {
                statusFieldApplication.amount = amount2;
                CombatManager.Instance.PostNotification(TriggerCalls.OnStatusEffectContentAdded.ToString(), chara, statusFieldApplication);
            }

            return flag2;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            _Status = StatusField.Ruptured;

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
        public int FakeApplyStatusEffect(IUnit unit, int entryVariable)
        {
            int num = (_RandomBetweenPrevious ? UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1) : entryVariable);
            if (num < _Status.MinimumRequiredToApply)
            {
                return 0;
            }

            if (unit is CharacterCombat chara)
            {
                if (!FakeApplyStatusEffect(chara, _Status, num))
                {
                    return 0;
                }
            }
            else if (unit is EnemyCombat enemy)
            {
                if (!FakeApplyStatusEffect(enemy, _Status, num))
                {
                    return 0;
                }
            }


            return Mathf.Max(1, num);
        }
    }
    public static class ShieldPiercer
    {
        public static void ShowAbilityInfo(this AbilitySO abil)
        {
            Debug.Log(abil._abilityName);
            foreach (EffectInfo info in abil.effects)
            {
                Debug.Log(info.effect + " " + info.entryVariable);
            }
        }
        public static AbilitySO indulgence => LoadedAssetsHandler.GetEnemyAbility("Indulgence_A");
        static DamageEffect _ignore;
        public static DamageEffect Ignore
        {
            get
            {
                if (_ignore == null)
                {
                    _ignore = ScriptableObject.CreateInstance<DamageEffect>();
                    _ignore._ignoreShield = true;
                }
                return _ignore;
            }
        }
        static Ability _indluge;
        public static Ability Indulge
        {
            get
            {
                if (_indluge == null)
                {
                    _indluge = new Ability("Salt_Indulge_A")
                    {
                        Name = "Indulgence",
                        Description = "Deals a little Shield-Ignoring damage to the Left and Right enemies.",
                        Rarity = Rarity.CreateAndAddCustomRarityToPool("BasicRarity5", 5),
                        Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(BasicEffects.ShieldPierce, 2, Targeting.Slot_AllySides)
                        },
                        Visuals = LoadedAssetsHandler.GetEnemyAbility("Indulgence_A").visuals,
                        AnimationTarget = Targeting.Slot_AllySides
                    };
                    _indluge.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Damage_1_2.ToString() });
                }
                return _indluge;
            }
        }
        static Ability _agony;
        public static Ability Agony
        {
            get
            {
                if (_agony == null)
                {
                    _agony = new Ability("Salt_Agony_A")
                    {
                        Name = "Blissful Agony",
                        Description = "Clumsily deals a Little Shield-Ignoring damage to this enemy. Inflicts 1 Scar to this enemy.",
                        Rarity = Rarity.CreateAndAddCustomRarityToPool("BasicRarity5", 5),
                        Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(BasicEffects.ShieldPierce, 2, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Slot_SelfSlot)
                        },
                        Visuals = LoadedAssetsHandler.GetEnemyAbility("BlissfulAgony_A").visuals,
                        AnimationTarget = Targeting.Slot_SelfSlot
                    };
                    _agony.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Scars.ToString() });
                }
                return _agony;
            }
        }
        public static void ImagesPierce()
        {
            LoadedAssetsHandler.GetEnemy("InHisImage_EN").abilities[1] = new EnemyAbilityInfo() { ability = Indulge.GenerateEnemyAbility().ability, rarity = LoadedAssetsHandler.GetEnemy("InHisImage_EN").abilities[1].rarity };
            LoadedAssetsHandler.GetEnemy("InHerImage_EN").abilities[1] = LoadedAssetsHandler.GetEnemy("InHisImage_EN").abilities[1];
        }
        public static AbilitySO agony => LoadedAssetsHandler.GetEnemyAbility("BlissfulAgony_A");
        public static void ChoirsPierce()
        {
            LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[1] = new EnemyAbilityInfo() { ability = Agony.GenerateEnemyAbility().ability, rarity = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[1] .rarity };
        }
        public static void ScreamingPierce()
        {
            try
            {
                if (!Check.EnemyExist("ScreamingHomunculus_EN")) return;
                EnemySO enemy = LoadedAssetsHandler.GetEnemy("ScreamingHomunculus_EN");
                try
                {
                    DamageWeakestEffect weakest = ScriptableObject.CreateInstance<DamageWeakestEffect>();
                    weakest._ignoreShield = true;
                    enemy.abilities[0].ability.effects[0].effect = weakest;
                    enemy.abilities[0].ability._description = "Deal a Painful amount of Shield-ignoring damage to the enemy(s) with the lowest health.";
                }
                catch (Exception e)
                {
                    Debug.LogError("screaming homunculus ability 1 shield pierce failure");
                    Debug.LogError(e.Message);
                    Debug.LogError(e.StackTrace);
                }
                try
                {
                    DamageStrongestEffect weakest = ScriptableObject.CreateInstance<DamageStrongestEffect>();
                    weakest._ignoreShield = true;
                    enemy.abilities[1].ability.effects[0].effect = weakest;
                    enemy.abilities[1].ability._description = "Deal a Painful amount of Shield-ignoring damage to the enemy(s) with the highest health.";
                }
                catch (Exception e)
                {
                    Debug.LogError("screaming homunculus ability 2 shield pierce failure");
                    Debug.LogError(e.Message);
                    Debug.LogError(e.StackTrace);
                }
            }

            catch
            {
                Debug.LogWarning("ScreamingHomunculus Not Present, No Need for SheildPiercerHook on it");
            }
        }
        public static void FixNowak()
        {
            (LoadedAssetsHandler.GetCharacter("Nowak_CH").rankedData[0].rankAbilities[0].ability.effects[0].effect as DamageEffect)._ignoreShield = false;
        }
        public static void Add()
        {
            ImagesPierce();
            //ChoirsPierce();
            ScreamingPierce();
            FixNowak();
        }
        public static void Setup()
        {
            MainMenuException.AddAction(Add);
        }
    }
}

namespace EnemyPack.Effects
{
    public class DamageWeakestEffect : EffectSO
    {
        [SerializeField]
        public bool _directHeal = true;
        [SerializeField]
        public bool _checkCanHeal = true;
        public string _deathType = DeathType_GameIDs.Basic.ToString();
        public bool _ignoreShield = false;
        public bool _returnKillAsSuccess;
        public bool _indirect = false;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            bool flag = false;
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive)
                {
                    if (num < 0)
                    {
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth < num)
                    {
                        targetSlotInfoList.Clear();
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth == num)
                        targetSlotInfoList.Add(target);
                }
            }
            foreach (TargetSlotInfo targetSlotInfo in targetSlotInfoList)
            {
                int targetSlotOffset = areTargetSlots ? targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID : -1;
                int amount1 = entryVariable;
                DamageInfo damageInfo;
                if (this._indirect)
                {
                    damageInfo = targetSlotInfo.Unit.Damage(amount1, (IUnit)null, this._deathType, targetSlotOffset, false, false, true);
                }
                else
                {
                    int amount2 = caster.WillApplyDamage(amount1, targetSlotInfo.Unit);
                    damageInfo = targetSlotInfo.Unit.Damage(amount2, caster, this._deathType, targetSlotOffset, ignoresShield: this._ignoreShield);
                }
                flag |= damageInfo.beenKilled;
                exitAmount += damageInfo.damageAmount;
            }
            if (!this._indirect && exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
        }
    }
    public class DamageStrongestEffect : EffectSO
    {
        [SerializeField]
        public bool _directHeal = true;
        [SerializeField]
        public bool _checkCanHeal = true;
        public string _deathType = DeathType_GameIDs.Basic.ToString();
        public bool _ignoreShield = false;
        public bool _indirect = false;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive)
                {
                    if (num < 0)
                    {
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth > num)
                    {
                        targetSlotInfoList.Clear();
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth == num)
                        targetSlotInfoList.Add(target);
                }
            }
            foreach (TargetSlotInfo targetSlotInfo in targetSlotInfoList)
            {
                int targetSlotOffset = areTargetSlots ? targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID : -1;
                int amount1 = entryVariable;
                DamageInfo damageInfo;
                if (this._indirect)
                {
                    damageInfo = targetSlotInfo.Unit.Damage(amount1, (IUnit)null, this._deathType, targetSlotOffset, false, false, true);
                }
                else
                {
                    int amount2 = caster.WillApplyDamage(amount1, targetSlotInfo.Unit);
                    damageInfo = targetSlotInfo.Unit.Damage(amount2, caster, this._deathType, targetSlotOffset, ignoresShield: this._ignoreShield);
                }
                exitAmount += damageInfo.damageAmount;
            }
            if (!this._indirect && exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }
}