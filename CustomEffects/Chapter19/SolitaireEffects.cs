using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

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

            //TWO GROUP
            TwoGroup = new List<string[]>();
            TwoGroup.Add(["InHisImage_EN", "InHisImage_EN"]);
            TwoGroup.Add(["InHerImage_EN", "InHerImage_EN"]);
            TwoGroup.Add(["SkinningHomunculus_EN", "SkinningHomunculus_EN"]);
            TwoGroup.Add(["GigglingMinister_EN", "GigglingMinister_EN"]);
            TwoGroup.Add(["ChoirBoy_EN", "ChoirBoy_EN"]);
            TwoGroup.Add(["Yang_EN", "Yang_EN"]);

            TwoGroup.Add(["Attrition_EN", "Attrition_EN"]);

            TwoPlusGroup = new List<string[]>(TwoGroup);
            TwoPlusGroup.Add(["RealisticTank_EN"]);

            //ONE GROUP
            OneGroup = new List<string[]>();
            OneGroup.Add(["ChoirBoy_EN"]);
            OneGroup.Add(["GigglingMinister_EN"]);
            OneGroup.Add(["NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN"]);
            OneGroup.Add(["ShiveringHomunculus_EN", "ShiveringHomunculus_EN", "ShiveringHomunculus_EN"]);
            OneGroup.Add(["LittleAngel_EN"]);
            OneGroup.Add(["Satyr_EN"]);
            OneGroup.Add(["ClockTower_EN"]);
            OneGroup.Add(["BlueFlower_EN", "RedFlower_EN"]);
            OneGroup.Add(["RedFlower_EN", "BlueFlower_EN"]);
            OneGroup.Add(["MortalSpoggle_EN"]);
            OneGroup.Add(["RusticJumbleguts_EN"]);
            OneGroup.Add(["StarGazer_EN", "StarGazer_EN", "StarGazer_EN", "StarGazer_EN", "StarGazer_EN"]);
            OneGroup.Add(["Grandfather_EN"]);
            OneGroup.Add(["GreyFlower_EN"]);
            OneGroup.Add(["EyePalm_EN", "EyePalm_EN", "EyePalm_EN"]);
            OneGroup.Add(["Merced_EN"]);
            OneGroup.Add(["MiniReaper_EN"]);
            OneGroup.Add(["Shua_EN"]);
            OneGroup.Add(["GlassFigurine_EN"]);
            OneGroup.Add(["Damocles_EN", "Damocles_EN", "Damocles_EN", "Damocles_EN", "Damocles_EN"]);
            OneGroup.Add(["GreyBot_EN"]);
            OneGroup.Add(["BlackStar_EN", "BlackStar_EN"]);
            //children
            OneGroup.Add(["Indicator_EN"]);
            OneGroup.Add(["YNL_EN"]);
            OneGroup.Add(["Stoplight_EN"]);
            OneGroup.Add(["OdeToHumanity_EN"]);
            OneGroup.Add(["GlassedSun_EN"]);
            OneGroup.Add(["PersonalAngel_EN"]);
            //evildog
            OneGroup.Add(["Complimentary_EN"]);
            OneGroup.Add(["PawnA_EN", "PawnA_EN", "PawnA_EN", "PawnA_EN", "PawnA_EN"]);
            OneGroup.Add(["Hunter_EN"]);
            OneGroup.Add(["Firebird_EN"]);
            OneGroup.Add(["Yang_EN"]);
            OneGroup.Add(["Starless_EN"]);
            OneGroup.Add(["Eyeless_EN", "Starless_EN"]);

            OneGroup.Add(["Romantic_EN", "Romantic_EN"]);
            OneGroup.Add(["Git_EN"]);
            OneGroup.Add(["Attrition_EN"]);

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
            if (notifname == TriggerCalls.OnBeforeCombatStart.ToString()) DreamScanner = 0;
            if (notifname == TriggerCalls.OnDamaged.ToString() && sender is EnemyCombat enemy && IsSolitaire(enemy)) DreamScanner++;
        }
    }
    public class MoveToGardenEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

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
    public class DreamScannerEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable * SolitaireHandler.DreamScanner, out exitAmount);
        }
    }
}
