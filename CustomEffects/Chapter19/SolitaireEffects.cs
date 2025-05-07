using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Yarn;

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
                DreamScanner = 0;
                Returning = false;
                MovedToGarden = false;
            }
            if (notifname == TriggerCalls.OnDamaged.ToString() && sender is EnemyCombat enemy && IsSolitaire(enemy)) DreamScanner++;
        }

        public static bool MovedToGarden;
        public static bool Returning;
        public static bool Moved;
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

            return true;
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
}
