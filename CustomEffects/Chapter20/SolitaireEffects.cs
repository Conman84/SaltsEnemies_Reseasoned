using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Yarn;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.UI.CanvasScaler;

//solitaire's tp effect: longass attack anim
//tp garden effect
//remove decay
//kill solitaire
//spawn 2 tile group, 2+ enemy spaces condition
//spawn 1 tile group, not ==2 enemy spaces condition

namespace SaltsEnemies_Reseasoned
{
    public static class SolitaireHandler
    {
        public static List<string[]> TwoPlusGroup;
        public static List<string[]> TwoGroup;
        public static List<string[]> OneGroup;

        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck);
        }

        public static EnemyCombatBundle GetRandomGardenEncounter()
        {
            ZoneBGDataBaseSO garden = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
            EnemyEncounterSelectorSO selector = null;
            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0: 
                    selector = garden.EnemyEncounterData.m_EasySelector;
                    break;
                default:
                    selector = garden.EnemyEncounterData.m_MediumSelector;
                    break;
            }
            return selector.GetEnemyBundle();
        }

        public static string[] GetTwoGroup(bool multitiles = false)
        {
            if (multitiles)
            {

                if (TwoPlusGroup == null) GetTwoGroup();
                if (TwoPlusGroup.Count <= 0) GetTwoGroup();
                string[] ree = TwoPlusGroup.GetRandom();
                if (ree == null) return GetTwoGroup(multitiles);
                if (!AddTo.MultiENExistInternal(ree)) return GetTwoGroup(multitiles);
                return ree;
            }
            if (TwoGroup == null) return [];
            if (TwoGroup.Count <= 0) return [];
            string[] ret = TwoGroup.GetRandom();
            if (ret == null) return GetTwoGroup(multitiles);
            if (!AddTo.MultiENExistInternal(ret)) return GetTwoGroup(multitiles);
            return ret;
        }
        public static string[] GetOneGroup()
        {
            if (OneGroup == null) return [];
            if (OneGroup.Count <= 0) return [];
            string[] ret = OneGroup.GetRandom();
            if (ret == null) return GetOneGroup();
            if (!AddTo.MultiENExistInternal(ret)) return GetOneGroup();
            return ret;
        }


        public static bool IsSolitaire(EnemyCombat enemy)
        {
            if (!Check.EnemyExist("Solitaire_EN")) return false;
            if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Solitaire_EN") || enemy.Enemy.Equals(LoadedAssetsHandler.GetEnemy("Solitaire_EN"))) return true;
            return false;
        }
        public static bool IsSolitaireAndDead(EnemyCombat enemy)
        {
            if (IsSolitaire(enemy) && enemy.CurrentHealth <= 0) return true;
            return false;
        }

        public static int DreamScanner;
        public static void NotifCheck(string notifname, object sender, object args)
        {
            if (notifname == TriggerCalls.OnBeforeCombatStart.ToString())
            {
                DreamScanner = CombatManager.Instance._informationHolder.Run.inGameData.GetIntData("DreamScanner");
                Returning = false;
                MovedToGarden = false;
                Clear();
            }
            if (notifname == TriggerCalls.OnDamaged.ToString() && sender is EnemyCombat enemy && IsSolitaire(enemy))
            {
                DreamScanner = CombatManager.Instance._informationHolder.Run.inGameData.GetIntData("DreamScanner");
                DreamScanner++;
                CombatManager.Instance._informationHolder.Run.inGameData.SetIntData("DreamScanner", DreamScanner);
            }
            if (notifname == TriggerCalls.OnAbilityUsed.ToString() && sender is CharacterCombat chara)
            {
                int num = 0;
                foreach (ManaColorSO key in PigmentUsedCollector.lastUsed)
                {
                    num += GetBlocking(key);
                }
                if (num > 0) CombatManager.Instance.AddSubAction(new TriggerFromCurrentAction(chara, num));
            }
            if (notifname == TriggerCalls.OnGettingBoxed.ToString() && sender is EnemyCombat EN && IsSolitaire(EN)) RemoveFromCurrent(EN.ID);
        }

        public static bool MovedToGarden;
        public static bool Returning;
        public static bool Moved;

        //entropy shit
        public static void Clear()
        {
            CurrentBlocking = new Dictionary<ManaColorSO, List<int>>();
            FutureBlocking = new Dictionary<ManaColorSO, List<int>>();
        }

        public static Dictionary<ManaColorSO, List<int>> CurrentBlocking;
        public static Dictionary<ManaColorSO, List<int>> FutureBlocking;
        public static ManaColorSO PickRandomPigment()
        {
            ManaColorSO[] array = [Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple];
            return array.GetRandom();
        }
        public static void RemoveFromFuture(int ID)
        {
            foreach (ManaColorSO key in FutureBlocking.Keys)
            {
                if (FutureBlocking[key].Contains(ID)) FutureBlocking[key].Remove(ID);
            }
        }
        public static void RemoveFromCurrent(int ID)
        {
            foreach (ManaColorSO key in CurrentBlocking.Keys)
            {
                if (CurrentBlocking[key].Contains(ID)) CurrentBlocking[key].Remove(ID);
            }
        }
        public static void AddToCurrentFromFuture(int ID)
        {
            foreach (ManaColorSO key in FutureBlocking.Keys)
            {
                if (FutureBlocking[key].Contains(ID)) 
                {
                    if (CurrentBlocking.ContainsKey(key) && !CurrentBlocking[key].Contains(ID)) CurrentBlocking[key].Add(ID);
                    else CurrentBlocking.Add(key, new List<int>() { ID });
                }
            }
        }
        public static ManaColorSO AddRandomToFuture(int ID)
        {
            ManaColorSO key = PickRandomPigment();
            if (FutureBlocking.ContainsKey(key) && !FutureBlocking[key].Contains(ID)) FutureBlocking[key].Add(ID);
            else FutureBlocking.Add(key, new List<int>() { ID });
            return key;
        }
        public static ManaColorSO AddRandomToCurrent(int ID)
        {
            ManaColorSO key = PickRandomPigment();
            if (CurrentBlocking.ContainsKey(key) && !CurrentBlocking[key].Contains(ID)) CurrentBlocking[key].Add(ID);
            else CurrentBlocking.Add(key, new List<int>() { ID });
            return key;
        }
        public static bool GetFromFuture(int ID, out ManaColorSO ret)
        {
            ret = null;
            foreach (ManaColorSO key in FutureBlocking.Keys)
            {
                if (FutureBlocking[key].Contains(ID))
                {
                    ret = key;
                    return true;
                }
            }
            return false;
        }
        public static void AddToFuture(int ID, ManaColorSO key)
        {
            if (FutureBlocking.ContainsKey(key) && !FutureBlocking[key].Contains(ID)) FutureBlocking[key].Add(ID);
            else FutureBlocking.Add(key, new List<int>() { ID });
        }
        public static int GetBlocking(ManaColorSO key)
        {
            if (CurrentBlocking.ContainsKey(key)) return CurrentBlocking[key].Count;
            return 0;
        }
        public static bool HasBlocking(ManaColorSO key) => GetBlocking(key) > 0;
    }
    public class MoveToGardenEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            OverworldCombatSharedDataSO current = CombatManager.Instance._informationHolder.CombatData;
            if (current.enemyBundle.SpecialEnvironment != "") return false;

            //destroy old environment?
            //GameObject.Destroy(CombatManager.Instance._combatEnvHandler);
            CombatManager.Instance._combatEnvHandler.gameObject.SetActive(false);
            //CombatManager.Instance._combatEnvHandlr.

            //generate environment
            CombatManager.Instance.GenerateCombatEnvironment(LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03").CombatEnvironment, "");


            //ambiance
            if (!CombatManager.Instance._isGameRun)
            {
                if (!CombatManager.Instance._combatEnvHandler.HasExtraAmbience)
                {
                    CombatManager.Instance._soundManager.ForceSetAmbience(LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03").CombatAmbience);
                }
                else
                {
                    CombatManager.Instance._soundManager.StartExtraCombatAmbienceEvent(CombatManager.Instance._combatEnvHandler.ExtraAmbienceSound);
                }
            }
            else if (!CombatManager.Instance._combatEnvHandler.HasExtraAmbience)
            {
                CombatManager.Instance._soundManager.TrySetAmbienceState(LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03").CombatAmbience);
            }
            else
            {
                CombatManager.Instance._soundManager.TryStopAmbience();
                CombatManager.Instance._soundManager.StartExtraCombatAmbienceEvent(CombatManager.Instance._combatEnvHandler.ExtraAmbienceSound);
            }

            //environmenet notifs
            CombatManager.Instance._combatEnvHandler.SetUpNotifications();
            CombatManager.Instance._combatEnvHandler.InitializeExtraData(CombatManager.Instance._informationHolder.Game);

            SolitaireHandler.MovedToGarden = true;

            OdeInteraction.Flip();

            return true;
        }
    }
    public static class OdeInteraction
    {
        public static void Flip()
        {
            try
            {
                foreach (GameObject arena in OdeFieldHandler.Fields)
                {
                    if (arena == null || arena.Equals(null)) continue;
                    if (arena.activeSelf) arena.SetActive(false);
                    else arena.SetActive(true);
                }
                foreach (GameObject arena in OdeFieldHandler.Trees)
                {
                    if (arena == null || arena.Equals(null)) continue;
                    arena.SetActive(false);
                }
            }
            catch
            {

            }
        }
    }
    public class MoveBackToOriginalAreaAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            if (SolitaireHandler.MovedToGarden)
            {
                OverworldCombatSharedDataSO current = CombatManager.Instance._informationHolder.CombatData;
                CombatManager.Instance._combatEnvHandler.gameObject.SetActive(false);
                CombatManager.Instance.GenerateCombatEnvironment(current.combatEnvironmentPrefabName, current.enemyBundle.SpecialEnvironment);

                if (!CombatManager.Instance._isGameRun)
                {
                    if (!CombatManager.Instance._combatEnvHandler.HasExtraAmbience)
                    {
                        CombatManager.Instance._soundManager.ForceSetAmbience(current.combatAmbienceType);
                    }
                    else
                    {
                        CombatManager.Instance._soundManager.StartExtraCombatAmbienceEvent(CombatManager.Instance._combatEnvHandler.ExtraAmbienceSound);
                    }
                }
                else if (!CombatManager.Instance._combatEnvHandler.HasExtraAmbience)
                {
                    CombatManager.Instance._soundManager.TrySetAmbienceState(current.combatAmbienceType);
                }
                else
                {
                    CombatManager.Instance._soundManager.TryStopAmbience();
                    CombatManager.Instance._soundManager.StartExtraCombatAmbienceEvent(CombatManager.Instance._combatEnvHandler.ExtraAmbienceSound);
                }

                CombatManager.Instance._combatEnvHandler.SetUpNotifications();
                CombatManager.Instance._combatEnvHandler.InitializeExtraData(CombatManager.Instance._informationHolder.Game);

                SolitaireHandler.MovedToGarden = false;
                SolitaireHandler.Moved = false;
                SolitaireHandler.Returning = false;

                OdeInteraction.Flip();

            }
            yield return null;
        }
    }
    public class BoxAllEnemiesEffect : EffectSO
    {
        public static UnboxOnNoEnemies_SolitaireSpecial Unboxer;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Unboxer == null || Unboxer.Equals(null))
            {
                Unboxer = ScriptableObject.CreateInstance<UnboxOnNoEnemies_SolitaireSpecial>();
                Unboxer._unboxConditions = [TriggerCalls.TimelineEndReached, TriggerCalls.OnCombatEnd, TriggerCalls.OnFleetingEnd, TriggerCalls.OnDeath, TriggerCalls.OnAbilityUsed];
            }
            foreach (EnemyCombat enemy in new List<EnemyCombat>(stats.EnemiesOnField.Values))
            {
                if (!enemy.IsAlive) continue;
                if (SolitaireHandler.IsSolitaireAndDead(enemy)) continue;
                stats.TryBoxEnemy(enemy.ID, Unboxer, "");
                enemy.SimpleSetStoredValue(UnboxOnNoEnemies_SolitaireSpecial.Value, 1);
                SolitaireHandler.Moved = true;
            }
            return true;
        }
    }
    public class UnboxOnNoEnemies_SolitaireSpecial : UnboxUnitHandlerSO
    {
        public static string Value => "Solitaire_Boxing_A";
        public override bool CanBeUnboxed(CombatStats stats, BoxedUnit unit, object senderData)
        {
            if (senderData is IUnit iunit)
            {
                if (iunit.SimpleGetStoredValue("Dreamer_A") > 0) return false;
            }

            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.SimpleGetStoredValue(Value) > 0) continue;
                if (enemy.IsAlive) return false;
            }

            if (!SolitaireHandler.Returning && SolitaireHandler.Moved)
            {
                SolitaireHandler.Returning = true;
                SolitaireHandler.Moved = false;
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(CustomVisuals.GetVisuals("Salt/Curtains"), Slots.Self, unit.unit));
                CombatManager.Instance.AddUIAction(new MoveBackToOriginalAreaAction());
            }

            return true;
        }
        public override void ProcessUnbox(CombatStats stats, BoxedUnit unit, object senderData)
        {
            base.ProcessUnbox(stats, unit, senderData);
            unit.unit.SimpleSetStoredValue("Dreamer_A", 0);
            if (unit.unit is EnemyCombat enemy && SolitaireHandler.IsSolitaire(enemy))
            {
                enemy.UnforgetAbilities();
                CombatManager.Instance.AddRootAction(new UIActionAction(new FixHealthColorIfNotAction(enemy.ID, enemy.HealthColor)));
            }
            if (unit.unit is EnemyCombat EN && Check.EnemyExist("OdeToHumanity_EN") && EN.Enemy == LoadedAssetsHandler.GetEnemy("OdeToHumanity_EN"))
            {
                CombatManager.Instance.AddRootAction(new SpawnTreeAction(EN.ID));
            }
        }
    }
    public class TwoTileEnemySpacesEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int freeSpaces = 0;
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots)
            {
                if (!slot.HasUnit) freeSpaces++;
                else if (slot.Unit is EnemyCombat enemy && SolitaireHandler.IsSolitaireAndDead(enemy)) freeSpaces++;
                else freeSpaces = 0;
                if (freeSpaces >= 2) return true;
            }
            return freeSpaces >= 2;
        }
    }
    public class TwoEnemySpacesEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int freeSpaces = 0;
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots)
            {
                if (!slot.HasUnit) freeSpaces++;
                else if (slot.Unit is EnemyCombat enemy && SolitaireHandler.IsSolitaireAndDead(enemy)) freeSpaces++;
            }
            return freeSpaces >= 2;
        }
    }
    public class NotTwoEnemySpacesEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int freeSpaces = 0;
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots)
            {
                if (!slot.HasUnit) freeSpaces++;
                else if (slot.Unit is EnemyCombat enemy && SolitaireHandler.IsSolitaireAndDead(enemy)) freeSpaces++;
            }
            return freeSpaces != 2;
        }
    }
    public class SpawnEnemiesFromArrayEffect : SpawnEnemyAnywhereEffect
    {
        public string[] Names;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Names == null) return false;
            foreach (string name in Names)
            {
                enemy = LoadedAssetsHandler.GetEnemy(name);
                base.PerformEffect(stats, caster, targets, areTargetSlots, 1, out exitAmount);
            }
            return true;
        }
    }
    public class SolitaireSpawnGardenEnemiesEffect : SpawnEnemiesFromArrayEffect
    {
        public bool multis;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            if (entryVariable == 1) Names = SolitaireHandler.GetOneGroup();
            if (entryVariable == 2) Names = SolitaireHandler.GetTwoGroup(multis);
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
        public static SolitaireSpawnGardenEnemiesEffect Create(bool multitile)
        {
            SolitaireSpawnGardenEnemiesEffect ret = ScriptableObject.CreateInstance<SolitaireSpawnGardenEnemiesEffect>();
            ret.multis = multitile;
            return ret;
        }
    }
    public class SpawnEnemyCombatBundleEffect : EffectSO
    {
        public EnemyCombatBundle bundle;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (bundle == null) return false;
            foreach (EnemyBundleData enemy in bundle.Enemies)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy.enemy, enemy.combatSlot, false, trySpawnAnyways: false, ""));
            }
            return true;
        }
    }
    public class SpawnGardenEnemyBundleEffect : SpawnEnemyCombatBundleEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bundle = SolitaireHandler.GetRandomGardenEncounter();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class DreamScannerEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable * SolitaireHandler.DreamScanner, out exitAmount);
        }
    }
    public class LoadIntoFutureEffect : GenerateColorManaEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            ManaColorSO ret = null;
            if (!SolitaireHandler.GetFromFuture(caster.ID, out ret))
            {
                ret = SolitaireHandler.PickRandomPigment();
                SolitaireHandler.AddToFuture(caster.ID, ret);
            }
            mana = ret;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class LoadIntoPresentEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            ManaColorSO mana = null;
            SolitaireHandler.RemoveFromCurrent(caster.ID);
            if (SolitaireHandler.GetFromFuture(caster.ID, out mana)) SolitaireHandler.AddToCurrentFromFuture(caster.ID);
            else mana = SolitaireHandler.AddRandomToCurrent(caster.ID);
            SolitaireHandler.RemoveFromFuture(caster.ID);
            SolitaireHandler.AddRandomToFuture(caster.ID);

            if (mana == null || mana.Equals(null)) return false;

            if (mana.SharesPigmentColor(Pigments.Red)) CombatManager.Instance.AddUIAction(new LoadIntoPresentAction(caster.ID, Color.red));
            else if (mana.SharesPigmentColor(Pigments.Blue)) CombatManager.Instance.AddUIAction(new LoadIntoPresentAction(caster.ID, Color.blue));
            else if (mana.SharesPigmentColor(Pigments.Yellow)) CombatManager.Instance.AddUIAction(new LoadIntoPresentAction(caster.ID, Color.yellow));
            else if (mana.SharesPigmentColor(Pigments.Purple)) CombatManager.Instance.AddUIAction(new LoadIntoPresentAction(caster.ID, Color.magenta));

            return true;
        }
    }
    public class LoadIntoPresentAction : CombatAction
    {
        public int ID;
        public Color _color;

        public LoadIntoPresentAction(int id, Color color)
        {
            ID = id;
            _color = color;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (stats.combatUI._enemiesInCombat.TryGetValue(ID, out var value))
            {
                EnemyInFieldLayout layout = stats.combatUI._enemyZone._enemies[value.FieldID].FieldEntity;
                Transform head = layout.m_Data.m_Locator.transform.Find("Sprite").Find("Head");
                if (!head.Equals(null) && head != null)
                {
                    Transform light = head.Find("Colors");
                    if (!light.Equals(null) && light != null)
                    {
                        SpriteRenderer render = light.GetComponent<SpriteRenderer>();
                        render.color = _color;
                    }
                }
            }
            yield return null;
        }
    }
    public class TriggerFromCurrentAction : CombatAction
    {
        public IUnit caster;
        public int amount;
        public TriggerFromCurrentAction(IUnit unit, int num)
        {
            caster = unit;
            amount = num;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            List<CombatSlot> slots = new List<CombatSlot>();
            foreach (CombatSlot slot in caster.IsUnitCharacter ? stats.combatSlots.CharacterSlots : stats.combatSlots.EnemySlots)
            {
                if (slot.SlotID >= caster.SlotID && slot.SlotID < caster.SlotID + caster.Size) slots.Add(slot);
            }
            for (int i = 0; i < amount; i++)
            {
                switch(UnityEngine.Random.Range(0, 28))
                {
                    default: goto case 6;
                    case 0: caster.ApplyStatusEffect(StatusField.Frail, 1); break;
                    case 1: caster.ApplyStatusEffect(StatusField.Ruptured, 1); break;
                    case 2: caster.ApplyStatusEffect(StatusField.Focused, 1); break;
                    case 3: caster.ApplyStatusEffect(StatusField.OilSlicked, 1); break;
                    case 4: caster.ApplyStatusEffect(StatusField.Spotlight, 1); break;
                    case 5: caster.ApplyStatusEffect(StatusField.Linked, 1); break;
                    case 6: caster.ApplyStatusEffect(StatusField.Scars, 1); break;
                    case 7: caster.ApplyStatusEffect(StatusField.Gutted, 1); break;
                    case 8: caster.ApplyStatusEffect(StatusField.Stunned, 1); break;
                    case 9: foreach (CombatSlot slot in slots) slot.ApplyFieldEffect(StatusField.OnFire, 1, 0); break;
                    case 10: foreach (CombatSlot slot in slots) slot.ApplyFieldEffect(StatusField.Constricted, 1, 0); break;
                    case 11: foreach (CombatSlot slot in slots) slot.ApplyFieldEffect(StatusField.Shield, 1, 0); break;
                    case 12: caster.ApplyStatusEffect(StatusField.DivineProtection, 1); break;
                    case 13: caster.ApplyStatusEffect(StatusField.Cursed, 1); break;
                    case 14: caster.ApplyStatusEffect(Anesthetics.Object, 1); break;
                    case 15: caster.ApplyStatusEffect(Determined.Object, 1); break;
                    case 16: caster.ApplyStatusEffect(Inverted.Object, 1); break;
                    case 17: caster.ApplyStatusEffect(Left.Object, 1); break;
                    case 18: caster.ApplyStatusEffect(Pale.Object, 10); break;
                    case 19: caster.ApplyStatusEffect(Power.Object, 1); break;
                    case 20: caster.ApplyStatusEffect(Favor.Object, 1); break;
                    case 21: caster.ApplyStatusEffect(Muted.Object, 1); break;
                    case 22: foreach (CombatSlot slot in slots) slot.ApplyFieldEffect(Roots.Object, 1, 0); break;
                    case 23: caster.ApplyStatusEffect(Dodge.Object, 1); break;
                    case 24: caster.ApplyStatusEffect(Entropy.Object, 1); break;
                    case 25: caster.ApplyStatusEffect(Haste.Object, 1); break;
                    case 26: caster.ApplyStatusEffect(Acid.Object, 1); break;
                    case 27: if (!caster.ContainsStatusEffect(Inspiration.StatusID)) caster.SimpleSetStoredValue(Inspiration.Prevent, 1);  caster.ApplyStatusEffect(Inspiration.Object, 1); caster.SimpleSetStoredValue(Inspiration.Prevent, 0); break;
                    case 28: caster.ApplyStatusEffect(Terror.Object, 1); break;
                    case 29: caster.ApplyStatusEffect(Drowning.Object, 1); break;
                    case 30: foreach (CombatSlot slot in slots) slot.ApplyFieldEffect(Water.Object, 1, 0); break;
                    case 31: foreach (CombatSlot slot in slots) slot.ApplyFieldEffect(Slip.Object, 1, 0); break;
                    case 32: caster.ApplyStatusEffect(Pimples.Object, 1); break;
                    case 33: foreach (CombatSlot slot in slots) slot.ApplyFieldEffect(Mold.Object, 1, 0); break;
                }
            }
            yield return null;
        }
    }
    public class SolitaireExitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            SolitaireHandler.RemoveFromCurrent(caster.ID);
            exitAmount = 0;
            return true;
        }
    }
    public class SolitaireSpecialDecayCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (UnityEngine.Random.Range(0f, 1f) > 0.3f) return false;
            //note: change back to 0.4f
            return (effector as IUnit).SimpleGetStoredValue("Dreamer_A") <= 0;
        }
    }
    public class FixHealthColorIfNotAction : EnemyHealthColorChangeUIAction
    {
        public FixHealthColorIfNotAction(int id, ManaColorSO health) : base(id, health) { }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (stats.combatUI._enemiesInCombat.TryGetValue(_id, out var value) && value.HealthColor == _healthColor) yield break;
            else yield return base.Execute(stats);
        }
    }
}
