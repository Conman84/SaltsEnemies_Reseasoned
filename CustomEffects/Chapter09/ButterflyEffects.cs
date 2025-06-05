using BepInEx;
using BrutalAPI;
using FMOD;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using SaltsEnemies_Reseasoned;

/*I DID THIS ONE*/
//call DelayedAttackManager.Setup() in awake

//also, give them hemochromia as passives. hemochromia should be passive #1, ethereal passive #2  in that specific order

//also, for the ability Dissolver, new rework: Deal 5 damage to the Opposing party member and inflict 1 Acid on them. Move them to the Left or Right.
//use the ApplyAcidEffect. also, call Acid.Add() in awake

//for future, but when setting up miriam, make sure her UnitTypes = new List<string> { "FemaleID" }

namespace SaltEnemies_Reseasoned
{
    public class IsDieCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.CurrentHealth == 0;
        }
    }
    public class IfAliveCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                if (unit.CurrentHealth <= 0) return false;
                return unit.CurrentHealth > 0;
            }
            return false;
        }
    }
    public class IfAliveEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.CurrentHealth <= 0) return false;
            return caster.CurrentHealth > 0;
        }
    }
    public class ButterflyAction : CombatAction
    {

        public override IEnumerator Execute(CombatStats stats)
        {
            List<int> check = new List<int>(ButterflyUnboxer.Boxeds);
            foreach (int id in check)
            {
                stats.TryUnboxEnemyRandomPosition(id, null);
            }
            yield return null;
        }
    }
    public static class StatsExtensions
    {
        public static void TryUnboxEnemyRandomPosition(this CombatStats stats, int id, object senderData)
        {
            if (!stats.BoxedEnemies.TryGetValue(id, out var value) || !value.unboxHandler.CanBeUnboxed(stats, value, senderData))
            {
                return;
            }

            int firstEmptyEnemyFieldID = stats.GetFirstEmptyEnemyFieldID();
            if (firstEmptyEnemyFieldID != -1)
            {
                IUnit unit = value.unit;
                EnemyCombat enemyCombat = stats.Enemies[unit.ID];
                int slotID = enemyCombat.SlotID;
                int endSlot = slotID + enemyCombat.Size - 1;
                if (stats.combatSlots.IsEnemySpaceEmpty(slotID, endSlot))
                {
                    value.RemoveUnboxConnection();
                    enemyCombat.UnboxEnemy(firstEmptyEnemyFieldID);
                    stats.AddEnemyToField(enemyCombat.ID, firstEmptyEnemyFieldID);
                    stats.combatSlots.AddEnemyToSlot(enemyCombat, slotID);
                    stats.timeline.AddEnemyToTimeline(enemyCombat);
                    value.unboxHandler.ProcessUnbox(stats, value, senderData);
                    enemyCombat.DefaultPassiveAbilityInitialization();
                    CombatManager.Instance.AddUIAction(new UnboxEnemyUIAction(enemyCombat.ID));
                    enemyCombat.ConnectPassives();
                    enemyCombat.ReconnectAllStatusEffects();
                    CombatManager.Instance.AddUIAction(new EnemyPassiveAbilityChangeUIAction(enemyCombat.ID, enemyCombat.PassiveAbilities.ToArray()));
                    stats.BoxedEnemies.Remove(enemyCombat.ID);
                    return;
                }
                List<int> array = new List<int> { 0, 1, 2, 3, 4 };
                for (int i = 0; i < stats.combatSlots.EnemySlots.Length; i++)
                {
                    int pick = UnityEngine.Random.Range(0, array.Count);
                    slotID = array[pick];
                    endSlot = slotID + enemyCombat.Size - 1;
                    if (stats.combatSlots.IsEnemySpaceEmpty(slotID, endSlot))
                    {
                        value.RemoveUnboxConnection();
                        enemyCombat.UnboxEnemy(firstEmptyEnemyFieldID);
                        stats.AddEnemyToField(enemyCombat.ID, firstEmptyEnemyFieldID);
                        stats.combatSlots.AddEnemyToSlot(enemyCombat, slotID);
                        stats.timeline.AddEnemyToTimeline(enemyCombat);
                        value.unboxHandler.ProcessUnbox(stats, value, senderData);
                        enemyCombat.DefaultPassiveAbilityInitialization();
                        CombatManager.Instance.AddUIAction(new UnboxEnemyUIAction(enemyCombat.ID));
                        enemyCombat.ConnectPassives();
                        enemyCombat.ReconnectAllStatusEffects();
                        CombatManager.Instance.AddUIAction(new EnemyPassiveAbilityChangeUIAction(enemyCombat.ID, enemyCombat.PassiveAbilities.ToArray()));
                        stats.BoxedEnemies.Remove(enemyCombat.ID);
                        return;
                    }
                    array.RemoveAt(pick);

                }
            }
        }
    }
    public static class DelayedAttackManager
    {
        public static List<DelayedAttack> Attacks = new List<DelayedAttack>();
        public static AttackVisualsSO CrushAnim => CustomVisuals.GetVisuals("Salt/Cannon");
        public static TargetSlotInfo[] Targets(bool playerTurn)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (DelayedAttack attack in Attacks)
            {
                if (!targets.Contains(attack.Target) && (playerTurn == attack.caster.IsUnitCharacter || attack.caster == null)) targets.Add(attack.Target);
            }
            return targets.ToArray();
        }
        public static IUnit[] Attackers
        {
            get
            {
                List<IUnit> casters = new List<IUnit>();
                foreach (DelayedAttack attack in Attacks)
                {
                    if (attack.caster != null && !casters.Contains(attack.caster)) casters.Add(attack.caster);
                }
                return casters.ToArray();
            }
        }
        public static TargetSlotInfo[] TargetsForUnit(IUnit unit)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (DelayedAttack attack in Attacks)
            {
                if (!targets.Contains(attack.Target) && attack.caster != null && attack.caster == unit) targets.Add(attack.Target);
            }
            return targets.ToArray();
        }
        public static DelayedAttack[] AttacksForUnit(IUnit unit)
        {
            List<DelayedAttack> targets = new List<DelayedAttack>();
            foreach (DelayedAttack attack in Attacks)
            {
                if (attack.caster != null && attack.caster == unit) targets.Add(attack);
            }
            return targets.ToArray();
        }
        public static void CleanList(bool playerTurn)
        {
            List<DelayedAttack> ret = new List<DelayedAttack>();
            foreach (DelayedAttack attack in Attacks)
            {
                if (attack.caster != null && attack.caster.IsUnitCharacter != playerTurn) ret.Add(attack);
            }
            Attacks = ret;
        }
        public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            //NamelessHandler.CreateFile();
            NobodyMoveHandler.Clear();
            CombatManager.Instance.AddRootAction(new BadDogTurnStartAction());
            CombatManager.Instance.AddRootAction(new PerformDelayedAttacksAction(true));
            CombatManager.Instance.AddRootAction(new ButterflyAction());
            //CombatStarterPastCombatStart.Start();
            PigmentUsedCollector.ClearBlueUsers();
        }
        public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            CombatManager.Instance.AddRootAction(new PerformDelayedAttacksAction(false));
        }
        public static void FinalizeCombat(Action<CombatStats> orig, CombatStats self)
        {
            ButterflyUnboxer.EndCombatCheck();
            orig(self);
            Attacks.Clear();
            ThreadCleaner.CleanThreads();
            ButterflyUnboxer.Boxeds.Clear();
            BlackHoleEffect.Reset();
            SetMusicParameterByStringEffect.Params = new Dictionary<string, int>();
            AmalgaSongEffect.Reset();
            MonsterSongEffect.Reset();
            WednesdayEffect.Reset();
            SolitaireSongEffect.Reset();
            //WaterView.Reset();
            YNLHandler2.DoEffect();
        }

        public static void UIInitialization(Action<CombatStats> orig, CombatStats self)
        {
            //CombatStarterPastCombatStart.Reset();
            //WaterView.Reset();
            orig(self);
            Attacks.Clear();
            ButterflyUnboxer.Boxeds.Clear();
            BlackHoleEffect.Reset();
            SetMusicParameterByStringEffect.Params = new Dictionary<string, int>();
            AmalgaSongEffect.Reset();
            MonsterSongEffect.Reset();
            WednesdayEffect.Reset();
            SolitaireSongEffect.Reset();
        }

        public static void Setup()
        {
            AmbushManager.Setup();
            ThreadCleaner.Setup();
            IDetour CombatEnd = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.FinalizeCombat), ~BindingFlags.Default), typeof(DelayedAttackManager).GetMethod(nameof(FinalizeCombat), ~BindingFlags.Default));
            IDetour CombatStart = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.UIInitialization), ~BindingFlags.Default), typeof(DelayedAttackManager).GetMethod(nameof(UIInitialization), ~BindingFlags.Default));
            IDetour TurnStart = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~BindingFlags.Default), typeof(DelayedAttackManager).GetMethod(nameof(PlayerTurnStart), ~BindingFlags.Default));
            IDetour TurnEnd = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnEnd), ~BindingFlags.Default), typeof(DelayedAttackManager).GetMethod(nameof(PlayerTurnEnd), ~BindingFlags.Default));
            PigmentUsedCollector.Setup();
            FlitheringHandler.Setup();
            ButterflyUnboxer.Setup();
            NamelessHandler.Setup();
            YNLHandler2.Setup();
            FallImageryHandler.Setup();
        }

    }
    public class DelayedAttack
    {
        public int Damage;
        public TargetSlotInfo Target;
        public IUnit caster;

        public DelayedAttack(int damage, TargetSlotInfo target, IUnit caster)
        {
            Damage = damage;
            Target = target;
            this.caster = caster;
        }

        public void Add()
        {
            DelayedAttackManager.Attacks.Add(this);
        }

        public int Perform()
        {
            if (caster != null && caster.IsAlive)
            {
                if (Target.HasUnit)
                {
                    int amount = caster.WillApplyDamage(Damage, Target.Unit);
                    DamageInfo hit = Target.Unit.Damage(amount, caster, DeathType_GameIDs.Basic.ToString(), -1, true, true, false);
                    return hit.damageAmount;
                }

            }
            else
            {
                if (Target.HasUnit)
                {
                    Target.Unit.Damage(Damage, null, DeathType_GameIDs.Basic.ToString(), -1, true, true, false);
                    return 0;
                }
            }
            return 0;
        }
    }
    public class PlayAnimationAnywhereAction : CombatAction
    {
        public AttackVisualsSO _visuals;

        public TargetSlotInfo[] _targets;

        public PlayAnimationAnywhereAction(AttackVisualsSO visuals, TargetSlotInfo[] targets)
        {
            _visuals = visuals;
            _targets = targets;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (_targets.Length > 0)
                yield return stats.combatUI.PlayAbilityAnimation(_visuals, _targets, true);
        }
    }
    public class PerformDelayedAttacksAction : CombatAction
    {
        public PerformDelayedAttacksAction(bool playerTurn)
        {
            PlayerTurn = playerTurn;
        }

        public bool PlayerTurn;

        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance.AddSubAction(new PlayAnimationAnywhereAction(DelayedAttackManager.CrushAnim, DelayedAttackManager.Targets(PlayerTurn)));
            foreach (IUnit unit in DelayedAttackManager.Attackers)
            {
                if (PlayerTurn == unit.IsUnitCharacter)
                {
                    ReturnMultiTargets targets = ScriptableObject.CreateInstance<ReturnMultiTargets>();
                    targets.Targets = DelayedAttackManager.TargetsForUnit(unit);
                    PerformDelayedAttackEffect attack = ScriptableObject.CreateInstance<PerformDelayedAttackEffect>();
                    attack.Attacks = DelayedAttackManager.AttacksForUnit(unit);
                    EffectInfo effect = Effects.GenerateEffect(attack, 0, targets);
                    EffectInfo[] info = new EffectInfo[] { effect };
                    CombatManager.Instance.AddSubAction(new EffectAction(info, unit));
                }
            }
            CombatManager.Instance.AddSubAction(new PerformCasterlessDelayedAttacksAction(DelayedAttackManager.Attacks.ToArray()));
            DelayedAttackManager.CleanList(PlayerTurn);
            yield return null;
        }
    }
    public class PerformCasterlessDelayedAttacksAction : CombatAction
    {
        public PerformCasterlessDelayedAttacksAction(DelayedAttack[] attacks)
        {
            List<DelayedAttack> ret = new List<DelayedAttack>();
            foreach (DelayedAttack hit in attacks)
            {
                if (hit.caster == null) ret.Add(hit);
            }
            Attacks = ret.ToArray();
        }
        public DelayedAttack[] Attacks;

        public override IEnumerator Execute(CombatStats stats)
        {
            foreach (DelayedAttack hit in Attacks) hit.Perform();
            yield return null;
        }
    }
    public class ReturnSingleTarget : BaseCombatTargettingSO
    {
        public TargetSlotInfo Target;

        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            return new TargetSlotInfo[] { Target };
        }
    }
    public class ReturnMultiTargets : BaseCombatTargettingSO
    {
        public TargetSlotInfo[] Targets;

        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            return Targets;
        }
    }
    public class PerformDelayedAttackEffect : EffectSO
    {
        public DelayedAttack[] Attacks;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (DelayedAttack attack in Attacks)
            {
                exitAmount += attack.Perform();
            }
            if (exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }
    public class AddDelayedAttackEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                new DelayedAttack(entryVariable, target, caster).Add();
                exitAmount += entryVariable;
            }
            return exitAmount > 0;
        }
    }
    public static class ThreadCleaner
    {
        public static void CleanThreads()
        {
            if (ClockTowerManager.timer != null) ClockTowerManager.timer.Abort();
            CrackingHandler.Clear();
            FallImageryHandler.Clear();
        }

        public static void OnMainMenuPressed(Action<PauseUIHandler> orig, PauseUIHandler self)
        {
            CleanThreads();
            orig(self);
        }

        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(PauseUIHandler).GetMethod(nameof(PauseUIHandler.OnExitGamePressed), ~BindingFlags.Default), typeof(ThreadCleaner).GetMethod(nameof(OnMainMenuPressed), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(PauseUIHandler).GetMethod(nameof(PauseUIHandler.OnMainMenuPressed), ~BindingFlags.Default), typeof(ThreadCleaner).GetMethod(nameof(OnMainMenuPressed), ~BindingFlags.Default));
        }
    }
    public static class NamelessHandler
    {
        public static string RootPath => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string PluginPath => Paths.PluginPath;
        public static void CreateFile()
        {
            try
            {
                if (!FileExists)
                {
                    if (!Directory.Exists(RootPath + "/Nameless/"))
                    {
                        Directory.CreateDirectory(RootPath + "/Nameless/");
                    }
                    if (!File.Exists(RootPath + "/Nameless/Nameless.txt"))
                    {
                        File.WriteAllText(RootPath + "/Nameless/Nameless.txt", "This file is necessary to allow the enemy \"Nameless\" to perform the ability \"" + "The Volume of a Beating Heart" + "\".");
                        FileGenerates = true;
                    }
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("Nameless FILE CREATION FAILED; " + ex);
                try
                {
                    if (!FileExists)
                    {
                        if (!Directory.Exists(PluginPath + "/Nameless/"))
                        {
                            Directory.CreateDirectory(PluginPath + "/Nameless/");
                        }
                        if (!File.Exists(PluginPath + "/Nameless/Nameless.txt"))
                        {
                            File.WriteAllText(PluginPath + "/Nameless/Nameless.txt", "This file is necessary to allow the enemy \"Nameless\" to perform the ability \"" + "The Volume of a Beating Heart" + "\".");
                            FileGenerates = true;
                        }
                    }
                }
                catch (Exception e2x)
                {
                    UnityEngine.Debug.LogError("Nameless FILE CREATION FAILED TWICE; " + e2x);
                    FileGenerates = false;
                }
            }
        }
        public static bool FileGenerates;
        public static bool FileExists
        {
            get
            {
                if (Directory.Exists(RootPath + "/Nameless/") && File.Exists(RootPath + "/Nameless/Nameless.txt"))
                {
                    return true;
                }
                else if (Directory.Exists(PluginPath + "/Nameless/"))
                {
                    return File.Exists(PluginPath + "/Nameless/Nameless.txt");
                }
                return false;
            }
        }
        public static string FileAbility
        {
            get
            {
                return "The Volume of a Beating Heart";
            }
        }
        public static void ShowcaseTimelineTooltip(Action<CombatVisualizationController, int> orig, CombatVisualizationController self, int timelineID)
        {
            if (timelineID < 0 || timelineID >= self._TimelineHandler.TimelineSlotInfo.Count)
            {
                orig(self, timelineID);
                return;
            }

            TimelineInfo timelineInfo = self._TimelineHandler.TimelineSlotInfo[timelineID];
            string header = "?";
            string content = "";
            if (!timelineInfo.isSecret)
            {
                int enemyID = timelineInfo.enemyID;
                if (self._enemiesInCombat.TryGetValue(enemyID, out var value))
                {
                    AbilitySO abilityBySlotID = value.GetAbilityBySlotID(timelineInfo.abilitySlotID);
                    if (!(abilityBySlotID == null) && !abilityBySlotID.Equals(null))
                    {
                        if (abilityBySlotID._abilityName == FileAbility)
                        {
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = abilityLocData.description;
                            if (FileExists) content = "Apply 50 Pale to all party members.";
                            else content = "This ability is unable to be performed due to lacking file information.";
                            self._tooltip.DelayShow(content, header, "");
                            return;
                        }
                        if (abilityBySlotID.name == "Salt_Count_A")
                        {
                            IReadOnlyDictionary<string, UnitStoreDataHolder> readOnlyDictionary = value.StoredValues;
                            string extraContent = "";
                            if (readOnlyDictionary.TryGetValue(CrowIntents.Count, out var value3))
                            {
                                if (value3.TryGetUnitStoreDataToolTip(out string ret))
                                    extraContent = ret;
                            }
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = abilityLocData.description;
                            self._tooltip.DelayShow(content, header, extraContent);
                            return;
                        }
                        if (abilityBySlotID.name == "Salt_Wait_A")
                        {
                            IReadOnlyDictionary<string, UnitStoreDataHolder> readOnlyDictionary = value.StoredValues;
                            string extraContent = "";
                            if (readOnlyDictionary.TryGetValue(CrowIntents.Wait, out var value3))
                            {
                                if (value3.TryGetUnitStoreDataToolTip(out string ret))
                                    extraContent = ret;
                            }
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = abilityLocData.description;
                            self._tooltip.DelayShow(content, header, extraContent);
                            return;
                        }
                        if (abilityBySlotID.name == "Freud_Unlocking_A")
                        {
                            IReadOnlyDictionary<string, UnitStoreDataHolder> readOnlyDictionary = value.StoredValues;
                            string extraContent = "";
                            if (readOnlyDictionary.TryGetValue(UnlockingEffectCondition.value, out var value3))
                            {
                                if (value3.TryGetUnitStoreDataToolTip(out string ret))
                                    extraContent = ret;
                            }
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = abilityLocData.description;
                            self._tooltip.DelayShow(content, header, extraContent);
                            return;
                        }
                    }
                }
            }
            orig(self, timelineID);

        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(CombatVisualizationController).GetMethod(nameof(CombatVisualizationController.ShowcaseTimelineTooltip), ~BindingFlags.Default), typeof(NamelessHandler).GetMethod(nameof(ShowcaseTimelineTooltip), ~BindingFlags.Default));
        }
    }
    public class Targetting_By_NamelessFile : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO source;
        public override bool AreTargetAllies => source.AreTargetAllies;
        public override bool AreTargetSlots => source.AreTargetSlots;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (NamelessHandler.FileExists) return source.GetTargets(slots, casterSlotID, isCasterCharacter);
            else return new TargetSlotInfo[0];
        }
        public static Targetting_By_NamelessFile Create(BaseCombatTargettingSO orig)
        {
            Targetting_By_NamelessFile ret = ScriptableObject.CreateInstance<Targetting_By_NamelessFile>();
            ret.source = orig;
            return ret;
        }
    }
    public static class NobodyMoveHandler
    {
        public static List<int> Chara;
        public static List<int> Enemy;
        public static void Clear()
        {
            Setup();
        }
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (Enemy == null) Enemy = new List<int>();
            if (Chara == null) Chara = new List<int>();
            if (notificationName == TriggerCalls.OnMoved.ToString() && sender is IUnit unit)
            {
                if (unit.IsUnitCharacter) Chara.Add(unit.SlotID);
                else Enemy.Add(unit.SlotID);
            }
        }
        public static void Setup()
        {
            Chara = new List<int>();
            Enemy = new List<int>();
        }
    }
    public class Targetting_By_Moved : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.IsTargetCharacterSlot && NobodyMoveHandler.Chara.Contains(target.SlotID)) ret.Add(target);
                else if (!target.IsTargetCharacterSlot && NobodyMoveHandler.Enemy.Contains(target.SlotID)) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static Targetting_By_Moved Create(bool getAlly)
        {
            Targetting_By_Moved ret = ScriptableObject.CreateInstance<Targetting_By_Moved>();
            ret.getAllUnitSlots = false;
            ret.getAllies = getAlly;
            return ret;
        }
    }
    public class BadDogTurnStartAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            BadDogHandler.TurnStartFunction();
            yield return null;
        }
    }
    public static class BadDogHandler
    {
        public static int GetLastAbilityIDFromNameUsingAbilityName(this EnemyCombat enemy, string abilityName)
        {
            for (int num = enemy.Abilities.Count - 1; num >= 0; num--)
            {
                if (enemy.Abilities[num].ability._abilityName == abilityName)
                {
                    return num;
                }
            }

            return -1;
        }
        public static string Turns => "BadDog_Internal_Turns_PA";
        public static bool HasBadDog(this IPassiveEffector unit)
        {
            foreach (BasePassiveAbilitySO passive in unit.PassiveAbilities) if (passive is BadDogPassiveAbility dog) { return true; }
            return false;
        }
        public static bool IsFacing(this IUnit unit)
        {
            foreach (CombatSlot slot in unit.IsUnitCharacter ? CombatManager.Instance._stats.combatSlots.EnemySlots : CombatManager.Instance._stats.combatSlots.CharacterSlots)
            {
                if (slot.SlotID >= unit.SlotID && slot.SlotID < unit.SlotID + unit.Size) if (slot.HasUnit) return true;
            }
            return false;
        }
        public static Dictionary<int, string[]> Actions;
        public static void TurnStartFunction()
        {
            Actions = new Dictionary<int, string[]>();
            Actions.Clear();
            CombatStats stats = CombatManager.Instance._stats;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                enemy.SimpleSetStoredValue(Turns, 0);
                if (enemy.HasBadDog() && enemy.IsFacing())
                {
                    List<string> turns = Actions.Keys.Contains(enemy.ID) ? new List<string>(Actions[enemy.ID]) : new List<string>();
                    int amount = 0;
                    foreach (TurnInfo turn in stats.timeline.Round)
                    {
                        if (!turn.isPlayer && (turn.turnUnit == enemy || (turn.turnUnit.ID == enemy.ID && turn.turnUnit.SlotID == enemy.SlotID)))
                        {
                            if (turn.abilitySlot < enemy.AbilityCount)
                            {
                                amount++;
                                turns.Add(enemy.Abilities[turn.abilitySlot].ability._abilityName);
                            }
                            else
                            {
                                amount++;
                                turns.Add("");
                            }
                        }
                    }
                    stats.timeline.TryRemoveAllNextEnemyTurns(enemy);
                    enemy.SimpleSetStoredValue(Turns, amount);
                    if (Actions.Keys.Contains(enemy.ID)) Actions[enemy.ID] = turns.ToArray();
                    else Actions.Add(enemy.ID, turns.ToArray());
                }
            }
        }
        public static void RunCheckFunction(bool skipRoot = false)
        {
            CombatStats stats = CombatManager.Instance._stats;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.HasBadDog())
                {
                    if (enemy.IsFacing())
                    {
                        List<string> turns = Actions.Keys.Contains(enemy.ID) ? new List<string>(Actions[enemy.ID]) : new List<string>();
                        int amount = 0;
                        foreach (TurnInfo turn in stats.timeline.Round)
                        {
                            if (!turn.isPlayer && (turn.turnUnit == enemy || (turn.turnUnit.ID == enemy.ID && turn.turnUnit.SlotID == enemy.SlotID)))
                            {
                                if (turn.abilitySlot < enemy.AbilityCount)
                                {
                                    amount++;
                                    turns.Add(enemy.Abilities[turn.abilitySlot].ability._abilityName);
                                }
                                else
                                {
                                    amount++;
                                    turns.Add("");
                                }
                            }
                        }
                        stats.timeline.TryRemoveAllNextEnemyTurns(enemy);
                        if (Actions.Keys.Contains(enemy.ID)) Actions[enemy.ID] = turns.ToArray();
                        else Actions.Add(enemy.ID, turns.ToArray());
                        enemy.SimpleSetStoredValue(Turns, enemy.SimpleGetStoredValue(Turns) + amount);
                    }
                    else if (enemy.SimpleGetStoredValue(Turns) > 0)
                    {
                        int num = enemy.SimpleGetStoredValue(Turns);
                        List<EnemyCombat> en = new List<EnemyCombat>();
                        List<int> turns = new List<int>();

                        if (!Actions.Keys.Contains(enemy.ID))
                        {
                            try
                            {
                                Try.AddNewFrontExtraEnemyTurns(enemy, num); 
                                enemy.SimpleSetStoredValue(Turns, 0);
                            }
                            catch
                            {
                                UnityEngine.Debug.LogError("adding front enemy turns failed, adding normally ");
                                stats.timeline.TryAddNewExtraEnemyTurns(enemy, num);
                                enemy.SimpleSetStoredValue(Turns, 0);
                            }
                        }
                        else
                        {
                            string[] array = Actions[enemy.ID];
                            //array.Reverse();
                            foreach (string name in array)
                            {
                                en.Add(enemy);
                                int add = enemy.GetLastAbilityIDFromNameUsingAbilityName(name);
                                if (add < 0) add = enemy.GetSingleAbilitySlotUsage(add);
                                turns.Add(add);
                            }
                            if (en.Count < num)
                            {
                                for (int i = en.Count; i < num && en.Count < num; i++)
                                {
                                    en.Add(enemy);
                                    turns.Add(enemy.GetSingleAbilitySlotUsage(-1));
                                }
                            }
                            List<int> newer = new List<int>(turns);
                            //for (int i = 0; i < turns.Count; i++) newer.Add(turns[i]);
                            try
                            {
                                Try.AddNewFrontEnemyTurns(en, newer);
                                enemy.SimpleSetStoredValue(Turns, 0);
                                Actions[enemy.ID] = new string[0];
                            }
                            catch
                            {
                                UnityEngine.Debug.LogError("adding front enemy turns failed, adding normally ");
                                stats.timeline.AddExtraEnemyTurns(en, turns);
                                enemy.SimpleSetStoredValue(Turns, 0);
                                Actions[enemy.ID] = new string[0];
                            }
                        }
                    }
                }
            }
            if (!skipRoot) CombatManager.Instance.AddRootAction(new MawCheckAction());
        }
        public static bool IsPlayerTurn() => CombatManager.Instance._stats.IsPlayerTurn;
    }
    public class BadDogPassiveAbility : PerformEffectPassiveAbility
    {

    }
    public static class PigmentUsedCollector
    {
        public static List<ManaColorSO> lastUsed;
        public static int ID;
        public static List<int> UsedBlue;
        public static List<int> UsedYellow;
        public static string RedUsed => "RedUsed_A";

        public static Dictionary<ManaColorSO, List<int>> PigmentsUsed;
        public static void UseAbility(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            if (lastUsed == null)
                lastUsed = new List<ManaColorSO>();
            if (PigmentsUsed == null)
                PigmentsUsed = new Dictionary<ManaColorSO, List<int>>();
            lastUsed.Clear();
            ID = self.ID;
            foreach (FilledManaCost filledManaCost in filledCost)
            {
                lastUsed.Add(filledManaCost.Mana);
                //if (filledManaCost.Mana.SharesPigmentColor(Pigments.Red)) self.SimpleSetStoredValue(RedUsed, self.SimpleGetStoredValue(RedUsed) + 1);
                if (PigmentsUsed.Keys.Contains(filledManaCost.Mana))
                {
                    if (!PigmentsUsed[filledManaCost.Mana].Contains(self.ID)) PigmentsUsed[filledManaCost.Mana].Add(self.ID);
                }
                else
                {
                    PigmentsUsed.Add(filledManaCost.Mana, new List<int>() { self.ID });
                }
            }
            if (lastUsed.Contains(Pigments.Blue))
            {
                if (UsedBlue == null) UsedBlue = new List<int>();
                UsedBlue.Add(self.ID);
            }
            if (lastUsed.Contains(Pigments.Yellow))
            {
                if (UsedYellow == null) UsedYellow = new List<int>();
                UsedYellow.Add(self.ID);
            }
            orig(self, abilityID, filledCost);
        }
        public static void FinalizeAbilityActions(Action<CharacterCombat> orig, CharacterCombat self)
        {
            orig(self);
            ID = -1;
            lastUsed.Clear();
        }
        public static void ClearBlueUsers()
        {
            PigmentsUsed = new Dictionary<ManaColorSO, List<int>>();
            if (UsedYellow != null) UsedYellow.Clear();
            if (UsedBlue == null) return;
            UsedBlue.Clear();
        }
        public static void Setup()
        {
            IDetour idetour1 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.UseAbility), ~BindingFlags.Default), typeof(PigmentUsedCollector).GetMethod(nameof(UseAbility), ~BindingFlags.Default));
            IDetour idetour2 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.FinalizeAbilityActions), ~BindingFlags.Default), typeof(PigmentUsedCollector).GetMethod(nameof(FinalizeAbilityActions), ~BindingFlags.Default));
            PigmentsUsed = new Dictionary<ManaColorSO, List<int>>();
        }
        public static bool UsedBy(this ManaColorSO self, int id)
        {
            if (PigmentsUsed == null) return false;
            foreach (ManaColorSO key in PigmentsUsed.Keys)
            {
                if (key.SharesPigmentColor(self)) return PigmentsUsed[key].Contains(id);
            }
            return false;
        }
    }
    public class BlackHoleEffect : EffectSO
    {
        public static int Amount = 0;
        public static void Reset() => Amount = 0;
        public bool Add = true;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool GOING = Amount > 0;
            if (Add) Amount++;
            else Amount--;
            if ((Amount > 0) == GOING) return Amount > 0;
            if (Amount > 0)
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("black star thread failed to shut down."); }
                }
                changeMusic = new System.Threading.Thread(GO);
                changeMusic.Start();
            }
            else
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("black star thread failed to shut down."); }
                }
                changeMusic = new System.Threading.Thread(STOP);
                changeMusic.Start();
            }
            return Amount > 0;
        }

        public static System.Threading.Thread changeMusic;
        public static void GO()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("BlackHole", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 100 && Amount > 0; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("BlackHole", i);
                System.Threading.Thread.Sleep(20);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
        public static void STOP()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("BlackHole", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i >= 0 && Amount <= 0; i--)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("BlackHole", i);
                System.Threading.Thread.Sleep(20);
                //if (i < 5) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
    }
    public static class YNLHandler2
    {
        public static OverworldManagerBG o;
        public static CombatManager c;
        public static List<int> Transforms = new List<int>();
        public static void Reset() => Transforms = new List<int>();
        public static bool DoPerm => true;
        public static void Grody() => MainMenuing = false;
        public static void DoEffect()
        {
            //Debug.Log("trying to do effect");
            //return;
            if (MainMenuing) return;
            if (CombatManager._instance == null) return;
            if (!DoPerm) return;
            CombatStats stats = CombatManager.Instance._stats;
            foreach (int id in Transforms)
            {
                if (stats.Characters.TryGetValue(id, out CharacterCombat chara))
                {
                    if (stats.InfoHolder.CombatData.CharactersData.Length > chara.ID)
                    {
                        CharacterInGameData old = stats.InfoHolder.CombatData.CharactersData[chara.ID];
                        CharacterInGameData newer = new CharacterInGameData(old.IsMainCharacter ? old.Character : chara.Character, old.CharacterSlot, chara.Rank, chara.UsedAbilities, old.IsMainCharacter);
                        newer.SetCurrentHealth(old.CurrentHealth);
                        //newer.WearableModifiers = old.WearableModifiers;
                        stats.InfoHolder.CombatData.CharactersData[chara.ID] = newer;
                        for (int i = 0; i < stats.InfoHolder.Run.playerData._characterList.Length; i++)
                        {
                            if (stats.InfoHolder.Run.playerData._characterList[i] == old)
                            {
                                stats.InfoHolder.Run.playerData._characterList[i] = newer;
                                newer.SetPartySlot(old.PartySlot);
                                newer.SetAttachedItem(old.AttachedItem, old.ItemSlot);
                                old.SetAttachedItem(null, -1);
                            }
                        }
                    }
                }
            }
        }
        public static bool MainMenuing = false;
        public static void OnMainMenuPressed(Action<PauseUIHandler> orig, PauseUIHandler self)
        {
            MainMenuing = true;
            orig(self);
        }
        public static void TransformCharacter(Action<CharacterInFieldLayout, Sprite, Sprite, RuntimeAnimatorController> orig, CharacterInFieldLayout self, Sprite frontSprite, Sprite backSprite, RuntimeAnimatorController character)
        {
            if (self._animator.runtimeAnimatorController != null && self._animator.runtimeAnimatorController == self._baseAnimatorTemplate && (character == null || character == self._baseAnimatorTemplate))
            {
                orig(self, frontSprite, backSprite, character);
                return;
            }
            self.gameObject.SetActive(false);
            if (character != null)
            {
                self._animator.runtimeAnimatorController = character;
            }
            else
            {
                self._animator.runtimeAnimatorController = self._baseAnimatorTemplate;
            }
            self.gameObject.SetActive(true);
            try
            {
                self.StartCombatAnimations();
            }
            catch
            {
                UnityEngine.Debug.LogError("transform restart: ITS FUCKED");
            }

            self.CharacterSprite = frontSprite;
            self.CharacterBackSprite = backSprite;
            self._renderer.sprite = (self.LookingAtPlayer ? self.CharacterSprite : self.CharacterBackSprite);
            self.ResetTransforms();
        }

        public static bool Set = false;
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(PauseUIHandler).GetMethod(nameof(PauseUIHandler.OnMainMenuPressed), ~BindingFlags.Default), typeof(YNLHandler2).GetMethod(nameof(OnMainMenuPressed), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(CharacterInFieldLayout).GetMethod(nameof(CharacterInFieldLayout.TransformCharacter), ~BindingFlags.Default), typeof(YNLHandler2).GetMethod(nameof(TransformCharacter), ~BindingFlags.Default));
        }
    }
    public class SpawnSelfEnemyAnywhereEffect : EffectSO
    {
        public bool givesExperience;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!(caster is EnemyCombat)) return false;
            EnemySO enemy = (caster as EnemyCombat).Enemy;

            for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnType));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
    public static class FallImageryHandler
    {
        static IntentInfoDamage d;
        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(TimelineIntentListLayout).GetMethod(nameof(TimelineIntentListLayout.SetInformation), ~BindingFlags.Default), typeof(FallImageryHandler).GetMethod(nameof(SetInformation), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(TargetIntentListLayout).GetMethod(nameof(TargetIntentListLayout.AddInformation), ~BindingFlags.Default), typeof(FallImageryHandler).GetMethod(nameof(AddInformation), ~BindingFlags.Default));
            try
            {
                TrainHandler.Setup();
            }
            catch
            {
                UnityEngine.Debug.LogError("TRAIN HANDLER FUCKING BROKE");
            }
        }

        public static void SetInformation(Action<TimelineIntentListLayout, Sprite[], Color[]> orig, TimelineIntentListLayout self, Sprite[] icons, Color[] colors)
        {
            try
            {
                if (colors == null || icons == null)
                {
                    orig(self, icons, colors);
                    return;
                }
                if (colors.Contains(FallColor._color))
                {
                    List<Sprite> animateSprites = new List<Sprite>();
                    List<Color> animateColors = new List<Color>();
                    bool animateThese = false;
                    int upTo = colors.Length;
                    for (int checkColor = 0; checkColor < colors.Length; checkColor++)
                    {
                        if (animateThese)
                        {
                            animateSprites.Add(icons[checkColor]);
                            animateColors.Add(colors[checkColor]);
                        }
                        if (colors[checkColor] == FallColor._color || colors[checkColor].Equals(FallColor._color))
                        {
                            animateThese = true;
                            upTo = checkColor;
                        }
                    }
                    while (self._intents.Count <= upTo) self.GenerateNewIntent();
                    for (int index = 0; index < self._intents.Count; ++index)
                    {
                        if (index < upTo)
                        {
                            self._intents[index].SetInformation(icons[index], colors[index]);
                            self._intents[index].SetActivation(true);
                        }
                        else if (index > upTo)
                        {
                            self._intents[index].SetActivation(false);
                        }
                        else 
                        {
                            self._intents[index].SetInformation(icons[icons.Length - 1], colors[colors.Length - 1]);
                            self._intents[index].SetActivation(true);
                            IntentLayoutAnimator grah = self._intents[index].gameObject.AddComponent<IntentLayoutAnimator>();
                            grah.animate = self._intents[index];
                            grah.icons = animateSprites.ToArray();
                            grah.colors = animateColors.ToArray();
                            grah.IsActive = true;
                            grah.limit = 0.1f;
                        }
                    }
                }
                else if (colors.Contains(FallColor._color2))
                {
                    List<Sprite> animateSprites = new List<Sprite>();
                    List<Color> animateColors = new List<Color>();
                    bool animateThese = false;
                    int upTo = colors.Length;
                    for (int checkColor = 0; checkColor < colors.Length; checkColor++)
                    {
                        if (animateThese)
                        {
                            animateSprites.Add(icons[checkColor]);
                            animateColors.Add(colors[checkColor]);
                        }
                        if (colors[checkColor] == FallColor._color2 || colors[checkColor].Equals(FallColor._color2))
                        {
                            animateThese = true;
                            upTo = checkColor;
                        }
                    }
                    while (self._intents.Count <= upTo) self.GenerateNewIntent();
                    for (int index = 0; index < self._intents.Count; ++index)
                    {
                        if (index < upTo)
                        {
                            self._intents[index].SetInformation(icons[index], colors[index]);
                            self._intents[index].SetActivation(true);
                        }
                        else if (index > upTo)
                        {
                            self._intents[index].SetActivation(false);
                        }
                        else
                        {
                            self._intents[index].SetInformation(icons[icons.Length - 1], colors[colors.Length - 1]);
                            self._intents[index].SetActivation(true);
                            IntentLayoutAnimator grah = self._intents[index].gameObject.AddComponent<IntentLayoutAnimator>();
                            grah.animate = self._intents[index];
                            grah.icons = animateSprites.ToArray();
                            grah.colors = animateColors.ToArray();
                            grah.IsActive = true;
                            grah.limit = 0.5f;
                        }
                    }
                }
                else if (colors.Contains(FallColor._color3))
                {
                    List<Sprite> animateSprites = new List<Sprite>();
                    List<Color> animateColors = new List<Color>();
                    bool animateThese = false;
                    int upTo = colors.Length;
                    for (int checkColor = 0; checkColor < colors.Length; checkColor++)
                    {
                        if (animateThese)
                        {
                            animateSprites.Add(icons[checkColor]);
                            animateColors.Add(colors[checkColor]);
                        }
                        if (colors[checkColor] == FallColor._color3 || colors[checkColor].Equals(FallColor._color3))
                        {
                            animateThese = true;
                            upTo = checkColor;
                        }
                    }
                    while (self._intents.Count <= upTo) self.GenerateNewIntent();
                    for (int index = 0; index < self._intents.Count; ++index)
                    {
                        if (index < upTo)
                        {
                            self._intents[index].SetInformation(icons[index], colors[index]);
                            self._intents[index].SetActivation(true);
                        }
                        else if (index > upTo)
                        {
                            self._intents[index].SetActivation(false);
                        }
                        else
                        {
                            self._intents[index].SetInformation(icons[icons.Length - 1], colors[colors.Length - 1]);
                            self._intents[index].SetActivation(true);
                            IntentLayoutAnimator grah = self._intents[index].gameObject.AddComponent<IntentLayoutAnimator>();
                            grah.animate = self._intents[index];
                            grah.icons = animateSprites.ToArray();
                            grah.colors = animateColors.ToArray();
                            grah.IsActive = true;
                            grah.limit = 1f;
                        }
                    }
                }
                else if (colors.Contains(FallColor._color4))
                {
                    List<Sprite> animateSprites = new List<Sprite>();
                    List<Color> animateColors = new List<Color>();
                    bool animateThese = false;
                    int upTo = colors.Length;
                    for (int checkColor = 0; checkColor < colors.Length; checkColor++)
                    {
                        if (animateThese)
                        {
                            animateSprites.Add(icons[checkColor]);
                            animateColors.Add(colors[checkColor]);
                        }
                        if (colors[checkColor] == FallColor._color2 || colors[checkColor].Equals(FallColor._color2))
                        {
                            animateThese = true;
                            upTo = checkColor;
                        }
                    }
                    while (self._intents.Count <= upTo) self.GenerateNewIntent();
                    for (int index = 0; index < self._intents.Count; ++index)
                    {
                        if (index < upTo)
                        {
                            self._intents[index].SetInformation(icons[index], colors[index]);
                            self._intents[index].SetActivation(true);
                        }
                        else if (index > upTo)
                        {
                            self._intents[index].SetActivation(false);
                        }
                        else
                        {
                            self._intents[index].SetInformation(icons[icons.Length - 1], colors[colors.Length - 1]);
                            self._intents[index].SetActivation(true);
                            IntentLayoutSelective_BySolitaire grah = self._intents[index].gameObject.AddComponent<IntentLayoutSelective_BySolitaire>();
                            grah.animate = self._intents[index];
                            grah.icons = animateSprites.ToArray();
                            grah.colors = animateColors.ToArray();
                            grah.IsActive = true;
                            grah.limit = 0.5f;
                        }
                    }
                }
                else
                {
                    orig(self, icons, colors);
                    foreach (TimelineIntentLayout lay in self._intents)
                    {
                        IntentLayoutAnimator[] array = lay.gameObject.GetComponents<IntentLayoutAnimator>();
                        foreach (IntentLayoutAnimator ain in array)
                        {
                            ain.enabled = false;
                            ain.IsActive = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogWarning("FallImageryHandler");
                UnityEngine.Debug.LogWarning(ex.ToString());
            }
        }
        public static void AddInformation(Action<TargetIntentListLayout, Sprite[], Color[]> orig, TargetIntentListLayout self, Sprite[] icons, Color[] colors)
        {
            if (colors.Contains(FallColor._color))
            {
                if (self._unusedIntents.Count <= 0)
                    self.GenerateUnusedIntent();
                TargetIntentLayout targetIntentLayout = self._unusedIntents.Dequeue();
                targetIntentLayout.MoveToLast();
                targetIntentLayout.SetInformation(icons[icons.Length - 1], colors[colors.Length - 1]);
                targetIntentLayout.SetActivation(true);
                self._intentsInUse.Add(targetIntentLayout);
                foreach (IntentLayoutAnimator old in targetIntentLayout.gameObject.GetComponents<IntentLayoutAnimator>())
                {
                    old.IsActive = false;
                }

                List<Sprite> animateSprites = new List<Sprite>();
                List<Color> animateColors = new List<Color>();
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i] == FallColor._color || colors[i].Equals(FallColor._color)) continue;
                    animateSprites.Add(icons[i]);
                    animateColors.Add(colors[i]);
                }

                IntentLayoutAnimator grah = targetIntentLayout.gameObject.AddComponent<IntentLayoutAnimator>();
                grah.mutilate = targetIntentLayout;
                grah.icons = animateSprites.ToArray();
                grah.colors = animateColors.ToArray();
                grah.IsActive = true;
                grah.limit = 0.1f;
                //Debug.Log("TARGET INTENT ");
                //new IntentLayoutAnimator(targetIntentLayout, icons, colors);
            }
            else if (colors.Contains(FallColor._color2))
            {
                if (self._unusedIntents.Count <= 0)
                    self.GenerateUnusedIntent();
                TargetIntentLayout targetIntentLayout = self._unusedIntents.Dequeue();
                targetIntentLayout.MoveToLast();
                targetIntentLayout.SetInformation(icons[icons.Length - 1], colors[colors.Length - 1]);
                targetIntentLayout.SetActivation(true);
                self._intentsInUse.Add(targetIntentLayout);
                foreach (IntentLayoutAnimator old in targetIntentLayout.gameObject.GetComponents<IntentLayoutAnimator>())
                {
                    old.IsActive = false;
                }

                List<Sprite> animateSprites = new List<Sprite>();
                List<Color> animateColors = new List<Color>();
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i] == FallColor._color2 || colors[i].Equals(FallColor._color2)) continue;
                    animateSprites.Add(icons[i]);
                    animateColors.Add(colors[i]);
                }

                IntentLayoutAnimator grah = targetIntentLayout.gameObject.AddComponent<IntentLayoutAnimator>();
                grah.mutilate = targetIntentLayout;
                grah.icons = animateSprites.ToArray();
                grah.colors = animateColors.ToArray();
                grah.IsActive = true;
                grah.limit = 0.5f;
                //Debug.Log("TARGET INTENT ");
                //new IntentLayoutAnimator(targetIntentLayout, icons, colors);
            }
            else if (colors.Contains(FallColor._color3))
            {
                if (self._unusedIntents.Count <= 0)
                    self.GenerateUnusedIntent();
                TargetIntentLayout targetIntentLayout = self._unusedIntents.Dequeue();
                targetIntentLayout.MoveToLast();
                targetIntentLayout.SetInformation(icons[icons.Length - 1], colors[colors.Length - 1]);
                targetIntentLayout.SetActivation(true);
                self._intentsInUse.Add(targetIntentLayout);
                foreach (IntentLayoutAnimator old in targetIntentLayout.gameObject.GetComponents<IntentLayoutAnimator>())
                {
                    old.IsActive = false;
                }

                List<Sprite> animateSprites = new List<Sprite>();
                List<Color> animateColors = new List<Color>();
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i] == FallColor._color3 || colors[i].Equals(FallColor._color3)) continue;
                    animateSprites.Add(icons[i]);
                    animateColors.Add(colors[i]);
                }

                IntentLayoutAnimator grah = targetIntentLayout.gameObject.AddComponent<IntentLayoutAnimator>();
                grah.mutilate = targetIntentLayout;
                grah.icons = animateSprites.ToArray();
                grah.colors = animateColors.ToArray();
                grah.IsActive = true;
                grah.limit = 1f;
                //Debug.Log("TARGET INTENT ");
                //new IntentLayoutAnimator(targetIntentLayout, icons, colors);
            }
            else if (colors.Contains(FallColor._color4))
            {
                if (self._unusedIntents.Count <= 0)
                    self.GenerateUnusedIntent();
                TargetIntentLayout targetIntentLayout = self._unusedIntents.Dequeue();
                targetIntentLayout.MoveToLast();
                targetIntentLayout.SetInformation(icons[icons.Length - 1], colors[colors.Length - 1]);
                targetIntentLayout.SetActivation(true);
                self._intentsInUse.Add(targetIntentLayout);
                foreach (IntentLayoutAnimator old in targetIntentLayout.gameObject.GetComponents<IntentLayoutAnimator>())
                {
                    old.IsActive = false;
                }

                List<Sprite> animateSprites = new List<Sprite>();
                List<Color> animateColors = new List<Color>();
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i] == FallColor._color2 || colors[i].Equals(FallColor._color2)) continue;
                    animateSprites.Add(icons[i]);
                    animateColors.Add(colors[i]);
                }

                IntentLayoutSelective_BySolitaire grah = targetIntentLayout.gameObject.AddComponent<IntentLayoutSelective_BySolitaire>();
                grah.mutilate = targetIntentLayout;
                grah.icons = animateSprites.ToArray();
                grah.colors = animateColors.ToArray();
                grah.IsActive = true;
                grah.limit = 0.5f;
                //Debug.Log("TARGET INTENT ");
                //new IntentLayoutAnimator(targetIntentLayout, icons, colors);
            }
            else
            {
                orig(self, icons, colors);
                foreach (TargetIntentLayout lay in self._intentsInUse)
                {
                    IntentLayoutAnimator[] array = lay.gameObject.GetComponents<IntentLayoutAnimator>();
                    foreach (IntentLayoutAnimator ain in array)
                    {
                        ain.enabled = false;
                        ain.IsActive = false;
                    }
                }
            }
        }

        public static List<IntentLayoutAnimator> fullSet = new List<IntentLayoutAnimator>();
        public static void Clear()
        {
            foreach (IntentLayoutAnimator animator in fullSet)
            {
                if (animator.thread != null) animator.thread.Abort();
                animator.IsActive = false;
            }
            fullSet.Clear();
        }

        public class IntentLayoutAnimator : MonoBehaviour
        {
            public TimelineIntentLayout animate;
            public TargetIntentLayout mutilate;

            public Sprite[] icons;
            public Color[] colors;

            public System.Threading.Thread thread;
            /*
            public IntentLayoutAnimator(TimelineIntentLayout target, Sprite[] Icons, Color[] Colors)
            {
                if (DoDebugs.MiscInfo) Debug.Log("timeline");
                animate = target;
                icons = Icons;
                colors = Colors;
                Thread newThread = new Thread(Animate);
                newThread.Start();
                thread = newThread;
                fullSet.Add(this);
            }
            public IntentLayoutAnimator(TargetIntentLayout target, Sprite[] Icons, Color[] Colors)
            {
                if (DoDebugs.MiscInfo) Debug.Log("target");
                mutilate = target;
                icons = Icons;
                colors = Colors;
                Thread newThread = new Thread(Mutilate);
                newThread.Start();
                thread = newThread;
                fullSet.Add(this);
            }
            */
            int currentSprite = -1;
            public bool IsActive = true;
            public void Animate()
            {
                while (animate != null && !animate.Equals(null) && animate.isActiveAndEnabled)
                {
                    try
                    {
                        IsActive = true;
                        System.Threading.Thread.Sleep(100);
                        int cap = Math.Min(icons.Length, colors.Length);
                        int index = UnityEngine.Random.Range(0, cap);
                        while (colors[index] == new Color(28f, 78f, 128f) || index == currentSprite) index = UnityEngine.Random.Range(0, cap);
                        animate.SetInformation(icons[index], colors[index]);
                        currentSprite = index;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                fullSet.Remove(this);
                IsActive = false;
            }
            public void Mutilate()
            {
                while (mutilate != null && !mutilate.Equals(null) && mutilate.isActiveAndEnabled)
                {
                    try
                    {
                        IsActive = true;
                        System.Threading.Thread.Sleep(100);
                        int cap = Math.Min(icons.Length, colors.Length);
                        int index = UnityEngine.Random.Range(0, cap);
                        while (colors[index] == new Color(28f, 78f, 128f) || index == currentSprite) index = UnityEngine.Random.Range(0, cap);
                        mutilate.SetInformation(icons[index], colors[index]);
                        currentSprite = index;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                fullSet.Remove(this);
                IsActive = false;
            }
            public float limit = 20f;
            public float time = 0f;
            public void Update()
            {
                //Debug.Log("Statr");
                if (!IsActive) return;
                //Debug.Log("Actiev");
                if (!RunFirstCheck || RedColor == null || PurpleColor == null || EnemyDamage == null || EnemyDamage.Length <= 0 || CharacterDamage == null || CharacterDamage.Length <= 0)
                {
                    CheckIsTrain(-1);
                    //Debug.Log("original trai check " + this);
                }
                try
                {
                    if (!fullSet.Contains(this))
                    {
                        fullSet.Add(this);
                        //Debug.Log("fullset addd " + fullSet.Count);
                        //Debug.Log(animate);
                        //Debug.Log(mutilate);
                    }
                }
                catch
                {
                    UnityEngine.Debug.LogError("failed to add self to fullset");
                    UnityEngine.Debug.LogError(this);
                }
                //if (mutilate != null && !mutilate.Equals(null) && mutilate.isActiveAndEnabled) { }
                //else if (animate != null && !animate.Equals(null) && animate.isActiveAndEnabled) { }
                //else { this.enabled = false; IsActive = false; }
                time += Time.deltaTime;
                if (time >= limit)
                {
                    try
                    {
                        Sprite[] icons = this.icons;
                        Color[] colors = this.colors;
                        if (ForceTrainColors)
                        {
                            if (HitAllies)
                            {
                                icons = EnemyDamage;
                                colors = new Color[icons.Length];
                                for (int i = 0; i < colors.Length; i++) colors[i] = RedColor;
                                //Debug.Log("enemy color");
                            }
                            else
                            {
                                icons = CharacterDamage;
                                colors = new Color[icons.Length];
                                for (int i = 0; i < colors.Length; i++) colors[i] = PurpleColor;
                                //Debug.Log("chara color");
                            }
                        }
                        time = 0f;
                        if (animate != null && !animate.Equals(null) && animate.isActiveAndEnabled)
                        {
                            int cap = Math.Min(icons.Length, colors.Length);
                            int index = UnityEngine.Random.Range(0, cap);
                            if (cap > 2 || (cap > 1 && ForceTrainColors))
                                while (colors[index] == new Color(28f, 78f, 128f) || index == currentSprite) index = UnityEngine.Random.Range(0, cap);
                            animate.SetInformation(icons[index], colors[index]);
                            currentSprite = index;
                            //Debug.Log("timeline");
                        }
                        if (mutilate != null && !mutilate.Equals(null) && mutilate.isActiveAndEnabled)
                        {
                            int cap = Math.Min(this.icons.Length, this.colors.Length);
                            int index = UnityEngine.Random.Range(0, cap);
                            if (cap > 2 || (cap > 1 && ForceTrainColors))
                                while (this.colors[index] == new Color(28f, 78f, 128f) || index == currentSprite) index = UnityEngine.Random.Range(0, cap);
                            mutilate.SetInformation(this.icons[index], this.colors[index]);
                            currentSprite = index;
                            //Debug.Log("target");
                        }
                    }
                    catch
                    {
                        UnityEngine.Debug.LogError("intent icon sprite changer FUCKING BROKE");
                    }
                }
            }

            public bool ForceTrainColors;
            public bool HitAllies;
            public static Color RedColor;
            public static Color PurpleColor;
            public static Sprite[] EnemyDamage;
            public static Sprite[] CharacterDamage;
            public bool RunFirstCheck = false;
            public void CheckIsTrain(int numb)
            {
                RunFirstCheck = true;
                //Debug.Log("checking");
                try
                {
                    if (animate != null)
                    {
                        //Debug.Log(animate);
                        TrainHandler.TimelineIntentIDHolder yeah = animate.gameObject.GetComponent<TrainHandler.TimelineIntentIDHolder>();
                        if (yeah != null)
                        {
                            //Debug.Log("we got timeline ID " + yeah.ID);
                            int timeline = yeah.ID;
                            if (timeline < CombatManager.Instance._stats.combatUI._TimelineHandler.TimelineSlotInfo.Count)
                            {
                                TimelineInfo boo = CombatManager.Instance._stats.combatUI._TimelineHandler.TimelineSlotInfo[timeline];
                                if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(boo.enemyID, out EnemyCombatUIInfo value))
                                {
                                    //Debug.Log("rea");
                                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                                    {
                                        if (enemy.ID == value.ID)
                                        {
                                            //Debug.Log("found the enemy " + enemy.ID);
                                            ForceTrainColors = enemy.ContainsPassiveAbility(TrainHandler.Practical);
                                            HitAllies = numb > -1 ? numb == 0 : enemy.SimpleGetStoredValue(TrainHandler.HitParty) == 0;
                                            //Debug.Log("all good; timelineposition: " + yeah.ID + "; enemy's ID: " + value.ID + "; enemy slot: " + enemy.SlotID + "; is train: " + ForceTrainColors + "; hit enemies: " + HitAllies);
                                            //Debug.Log("force train " + ForceTrainColors);
                                            //Debug.Log("hit ally" + HitAllies);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    ForceTrainColors = false;
                                    //Debug.Log("DIDNT get enemy");
                                    RunFirstCheck = true;
                                    //return;
                                }
                            }
                            else
                            {
                                //Debug.LogError("out of range!");
                                ForceTrainColors = false;
                                RunFirstCheck = true;
                            }
                        }
                        else
                        {
                            ForceTrainColors = false;
                            RunFirstCheck = true;
                            //Debug.Log("timeline intent id holder null");
                            //return;
                        }
                    }
                    else
                    {
                        ForceTrainColors = false;
                        RunFirstCheck = true;
                        //Debug.Log("animate null");
                        //return;
                    }
                }
                catch (Exception ex)
                {
                    ForceTrainColors = false;
                    UnityEngine.Debug.LogError("train handler broke");
                    UnityEngine.Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                }
                try
                {
                    if (RedColor == null || PurpleColor == null || EnemyDamage == null || EnemyDamage.Length <= 0 || CharacterDamage == null || CharacterDamage.Length <= 0)
                    {
                        IntentInfoDamage one = Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_1_2) as IntentInfoDamage;
                        IntentInfoDamage three = Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_3_6) as IntentInfoDamage;
                        IntentInfoDamage seven = Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_7_10) as IntentInfoDamage;
                        IntentInfoDamage eleven = Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_11_15) as IntentInfoDamage;
                        IntentInfoDamage sixteen = Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_16_20) as IntentInfoDamage;
                        IntentInfoDamage twentyone = Intents.GetInGame_IntentInfo(IntentType_GameIDs.Damage_21) as IntentInfoDamage;
                        RedColor = one.GetColor(false);
                        PurpleColor = one.GetColor(true);
                        EnemyDamage = new Sprite[]
                        {
                        one.GetSprite(false),
                        three.GetSprite(false),
                        seven.GetSprite(false),
                        eleven.GetSprite(false),
                        sixteen.GetSprite(false),
                        twentyone.GetSprite(false),
                        };
                        CharacterDamage = new Sprite[]
                        {
                        one.GetSprite(true),
                        three.GetSprite(true),
                        seven.GetSprite(true),
                        eleven.GetSprite(true),
                        sixteen.GetSprite(true),
                        twentyone.GetSprite(true),
                        };
                        //Debug.Log("GOT COLORS AND SHIT YEAHHH");
                    }
                }
                catch (Exception ex)
                {
                    ForceTrainColors = false;
                    UnityEngine.Debug.LogError("get colors for train handler broke");
                    UnityEngine.Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                }
                try
                {
                    if (HitAllies && (EnemyDamage == null || EnemyDamage.Length <= 0)) ForceTrainColors = false;
                    if (!HitAllies && (CharacterDamage == null || CharacterDamage.Length <= 0)) ForceTrainColors = false;
                }
                catch
                {
                    UnityEngine.Debug.LogError("BACKUPS FUCKING BROKE!");
                    ForceTrainColors = false;
                }
                RunFirstCheck = true;
                //Debug.Log("force train colors " + ForceTrainColors);
                //Debug.Log("run first check " + RunFirstCheck);
            }
        }
        public class IntentLayoutSelective_BySolitaire : MonoBehaviour
        {
            public TimelineIntentLayout animate;
            public TargetIntentLayout mutilate;

            public Sprite[] icons;
            public Color[] colors;

            public bool IsActive = true;
            public float limit = 20f;
            public float time = 0f;
            public void Update()
            {
                if (!IsActive) return;
                time += Time.deltaTime;
                if (time >= limit)
                {
                    try
                    {
                        Sprite[] icons = this.icons;
                        Color[] colors = this.colors;
                        int index = SolitaireHandler.DreamScanner;
                        if (index > icons.Length) index = icons.Length - 1;
                        if (index > colors.Length) index = colors.Length - 1;
                        time = 0f;
                        if (animate != null && !animate.Equals(null) && animate.isActiveAndEnabled)
                        {
                            animate.SetInformation(icons[index], colors[index]);
                            //Debug.Log("timeline");
                        }
                        if (mutilate != null && !mutilate.Equals(null) && mutilate.isActiveAndEnabled)
                        {
                            mutilate.SetInformation(icons[index], colors[index]);
                        }
                    }
                    catch
                    {
                        UnityEngine.Debug.LogError("intent icon sprite changer FUCKING BROKE");
                    }
                }
            }
        }
    }
    public static class TrainHandler
    {
        public static string Practical => "Train_Practical_PA";
        public static string HitParty => "Train_HittingParty";

        public static void UpdateSlotID(Action<TimelineSlotGroup, int> orig, TimelineSlotGroup self, int timelineSlotID)
        {
            TimelineIntentIDHolder yeah = self.intent.gameObject.GetComponent<TimelineIntentIDHolder>();
            if (yeah != null) yeah.ID = timelineSlotID;
            else
            {
                yeah = self.intent.gameObject.AddComponent<TimelineIntentIDHolder>();
                yeah.ID = timelineSlotID;
            }
            if (self.intent._intents.Count <= 0) self.intent.GenerateNewIntent();
            foreach (TimelineIntentLayout lay in self.intent._intents)
            {
                TimelineIntentIDHolder ee = lay.gameObject.GetComponent<TimelineIntentIDHolder>();
                if (ee != null) ee.ID = timelineSlotID;
                else
                {
                    ee = lay.gameObject.AddComponent<TimelineIntentIDHolder>();
                    ee.ID = timelineSlotID;
                }
                //if (lay.GetComponent<FallImageryHandler.IntentLayoutAnimator>() != null)
                //{
                //lay.GetComponent<FallImageryHandler.IntentLayoutAnimator>().CheckIsTrain(-1);
                //}
            }
            orig(self, timelineSlotID);
        }
        public static void SetInformation(Action<TimelineSlotGroup, int, Sprite, bool, Sprite[], Color[]> orig, TimelineSlotGroup self, int timelineSlotID, Sprite enemy, bool raycastable, Sprite[] intents, Color[] intentColors)
        {
            TimelineIntentIDHolder yeah = self.intent.gameObject.GetComponent<TimelineIntentIDHolder>();
            if (yeah != null) yeah.ID = timelineSlotID;
            else
            {
                yeah = self.intent.gameObject.AddComponent<TimelineIntentIDHolder>();
                yeah.ID = timelineSlotID;
            }
            if (self.intent._intents.Count <= 0) self.intent.GenerateNewIntent();
            foreach (TimelineIntentLayout lay in self.intent._intents)
            {
                TimelineIntentIDHolder ee = lay.gameObject.GetComponent<TimelineIntentIDHolder>();
                if (ee != null) ee.ID = timelineSlotID;
                else
                {
                    ee = lay.gameObject.AddComponent<TimelineIntentIDHolder>();
                    ee.ID = timelineSlotID;
                }
            }
            //Debug.Log("WOWOWOWOW" + yeah + " numbah: " + timelineSlotID);
            orig(self, timelineSlotID, enemy, raycastable, intents, intentColors);
        }
        public static IEnumerator PopulateTimeline(Func<TimelineZoneLayout, TimelineInfo[], IEnumerator> orig, TimelineZoneLayout self, TimelineInfo[] timeline)
        {
            FallImageryHandler.Clear();
            TrainTargetting.Flip();
            yield return orig(self, timeline);
        }
        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(TimelineSlotGroup).GetMethod(nameof(TimelineSlotGroup.SetInformation), ~BindingFlags.Default), typeof(TrainHandler).GetMethod(nameof(SetInformation), ~BindingFlags.Default));
            IDetour hook3 = new Hook(typeof(TimelineSlotGroup).GetMethod(nameof(TimelineSlotGroup.UpdateSlotID), ~BindingFlags.Default), typeof(TrainHandler).GetMethod(nameof(UpdateSlotID), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(TimelineZoneLayout).GetMethod(nameof(TimelineZoneLayout.PopulateTimeline), ~BindingFlags.Default), typeof(TrainHandler).GetMethod(nameof(PopulateTimeline), ~BindingFlags.Default));
        }
        public class TimelineIntentIDHolder : MonoBehaviour
        {
            public int ID;
        }
        public static void SwitchTrainTargetting(object sender)
        {
            try
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy == sender) continue;
                    if (enemy.ContainsPassiveAbility(Practical) && UnityEngine.Random.Range(0, 100) < 75)
                    {
                        if (enemy.SimpleGetStoredValue(HitParty) > 0)
                        {
                            if (UnityEngine.Random.Range(0, 100) < 50)
                            {
                                enemy.SimpleSetStoredValue(HitParty, 0);
                                CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(enemy.ID, enemy.IsUnitCharacter, "party", 0));
                                ChangeIntents(enemy, 0);
                            }
                        }
                        else
                        {
                            enemy.SimpleSetStoredValue(HitParty, 1);
                            CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(enemy.ID, enemy.IsUnitCharacter, "party", 0));
                            ChangeIntents(enemy, 1);
                        }
                    }
                }
            }
            catch
            {
                UnityEngine.Debug.LogError("probably not in combat - train handler");
            }
            try
            {
                TrainTargetting.Flip();
            }
            catch
            {
                UnityEngine.Debug.LogError("train targetting flip fail");
            }
        }
        public static void ChangeIntents(EnemyCombat self, int num)
        {
            foreach (FallImageryHandler.IntentLayoutAnimator anim in FallImageryHandler.fullSet)
            {
                try
                {
                    if (anim != null && !anim.Equals(null) && anim.IsActive && anim.enabled)
                    {
                        if (anim.animate != null)
                        {
                            TrainHandler.TimelineIntentIDHolder yeah = anim.animate.gameObject.GetComponent<TrainHandler.TimelineIntentIDHolder>();
                            if (yeah != null)
                            {
                                int timeline = yeah.ID;
                                TimelineInfo boo = CombatManager.Instance._stats.combatUI._TimelineHandler.TimelineSlotInfo[timeline];
                                if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(boo.enemyID, out EnemyCombatUIInfo value))
                                {
                                    if (self.ID == value.ID)
                                    {
                                        CombatManager.Instance.AddUIAction(new TrainIntentsUpdateUIAction(anim, num));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    UnityEngine.Debug.LogError("i think the animatorinator is null");
                }
            }
            CheckAll();
        }
        public static void CheckAll()
        {
            try
            {
                if (CombatManager._instance != null && CombatManager.Instance._stats.InCombat) CombatManager.Instance.AddRootAction(new SubActionAction(new UIActionAction(new TrainIntentsAllUpdateUIAction())));
            }
            catch
            {
                UnityEngine.Debug.LogError("not in combat probs");
            }
        }
    }
    public class UIActionAction : CombatAction
    {
        public CombatAction run;
        public UIActionAction(CombatAction y)
        {
            run = y;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance.AddUIAction(run);
            yield return null;
        }
    }
    public class TrainTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO source = Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true);
        public static Targetting_ByUnit_Side side;
        public bool GetAll;
        public bool flipple;
        public static void Flip()
        {
            foreach (TrainTargetting t in Resources.FindObjectsOfTypeAll<TrainTargetting>()) t.flipple = !t.flipple;
        }
        public override bool AreTargetAllies
        {
            get
            {
                if (source == null)
                {
                    return false;
                }
                return flipple ? !source.AreTargetAllies : source.AreTargetAllies;
            }
        }
        public override bool AreTargetSlots
        {
            get
            {
                if (source == null) return false;
                return source.AreTargetSlots;
            }
        }
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (side == null)
            {
                side = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                side.getAllUnitSlots = false;
            }
            bool found = false;
            bool getparty = false;
            if (isCasterCharacter)
            {
                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    if (chara.SlotID == casterSlotID)
                    {
                        getparty = chara.SimpleGetStoredValue(TrainHandler.HitParty) > 0;
                        found = true;
                        //Debug.Log("FOUND US; found " + found + " || getparty " + getparty);
                        break;
                    }
                }
            }
            else
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.SlotID == casterSlotID)
                    {
                        getparty = enemy.SimpleGetStoredValue(TrainHandler.HitParty) > 0;
                        found = true;
                        //Debug.Log("FOUND US; found " + found + " || getparty " + getparty);
                        break;
                    }
                }
            }
            if (!found) return new TargetSlotInfo[0];
            if (GetAll)
            {
                if (getparty == isCasterCharacter)
                {
                    //Debug.Log("self");
                    source = Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true);
                    flipple = false;
                    return source.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                else
                {
                    //Debug.Log("front");
                    source = Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false);
                    flipple = false;
                    return source.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                //Debug.Log("all");
                source = side;
                side.getAllies = getparty == isCasterCharacter;
                return source.GetTargets(slots, casterSlotID, isCasterCharacter);
            }
            else
            {
                if (getparty == isCasterCharacter)
                {
                    //Debug.Log("self");
                    source = Targeting.Slot_SelfSlot;
                    flipple = false;
                    return Targeting.Slot_SelfSlot.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                else
                {
                    //Debug.Log("front");
                    source = Targeting.Slot_Front;
                    flipple = false;
                    return Targeting.Slot_Front.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
            }
        }
        public static TrainTargetting Create(bool GetAll)
        {
            TrainTargetting ret = ScriptableObject.CreateInstance<TrainTargetting>();
            ret.GetAll = GetAll;
            return ret;
        }
    }
    public class TrainIntentsUpdateUIAction : CombatAction
    {
        public FallImageryHandler.IntentLayoutAnimator Anim;
        public int Num;
        public TrainIntentsUpdateUIAction(FallImageryHandler.IntentLayoutAnimator anim, int num)
        {
            Anim = anim;
            Num = num;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            try
            {
                Anim.CheckIsTrain(Num);
            }
            catch
            {
                UnityEngine.Debug.LogError("fialed tainr che");
            }
            yield return null;
        }
    }
    public class TrainIntentsAllUpdateUIAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            try
            {
                foreach (FallImageryHandler.IntentLayoutAnimator anim in FallImageryHandler.fullSet)
                {
                    try
                    {
                        if (anim != null && !anim.Equals(null) && anim.IsActive && anim.enabled)
                        {
                            anim.CheckIsTrain(-1);
                        }
                    }
                    catch
                    {
                        UnityEngine.Debug.LogError("one failed");
                    }
                }
            }
            catch
            {
                UnityEngine.Debug.LogError("fialed tainr che");
            }
            yield return null;
        }
    }
}
