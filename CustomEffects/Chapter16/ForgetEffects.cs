using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltEnemies_Reseasoned
{
    public class SpawnEnemyFromAreaEffect : SpawnEnemyInSlotFromEntryEffect
    {
        public static EnemyCombatBundle GetRandomBundle()
        {
            ZoneBGDataBaseSO garden = CombatManager.Instance._informationHolder.Run.CurrentZoneDB as ZoneBGDataBaseSO;
            EnemyEncounterSelectorSO selector = null;
            switch (UnityEngine.Random.Range(0, 3))
            {
                case 0:
                    selector = garden.EnemyEncounterData.m_EasySelector;
                    break;
                case 2:
                    selector = garden.EnemyEncounterData.m_HardSelector;
                    break;
                default:
                    selector = garden.EnemyEncounterData.m_MediumSelector;
                    break;
            }
            return selector.GetEnemyBundle();
        }
        public static EnemySO GetRandomEnemy()
        {
            EnemyCombatBundle bundle = GetRandomBundle();
            List<EnemySO> lists = new List<EnemySO>();
            foreach (EnemyBundleData data in bundle.Enemies)
            {
                bool skip = false;
                foreach (BasePassiveAbilitySO passive in data.enemy.passiveAbilities)
                {
                    if (passive.m_PassiveID == "Forgetting_PA")
                    {
                        skip = true;
                        break;
                    }
                }
                if (skip) continue;
                if (data.enemy.size == 1) lists.Add(data.enemy);
            };
            if (lists.Count <= 0) return GetRandomEnemy();
            EnemySO ret = lists.GetRandom();
            if (ret == null) return GetRandomEnemy();
            return ret;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            _spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            foreach (TargetSlotInfo target in targets)
            {
                enemy = GetRandomEnemy();
                base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out exitAmount);
            }
            return true;
        }
    }
    public class IsntWitheringDeathCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DeathReference reffe && reffe.witheringDeath == false) return true;
            return false;
        }
    }
    public class ForgettingEffectCondition : EffectConditionSO
    {
        public static int Selector;
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.SlotID != 0) return false;
            if (CombatManager.Instance._stats.TurnsPassed > 1) return false;
            int counting = 0;
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                if (!enemy.ContainsPassiveAbility("Forgetting_PA")) return false;
                counting++;
            }
            if (counting < 5) return false;
            int max = 3;
            if (AddTo.MultiENExistInternal(["FakeAngel_EN", "Clione_EN", "YellowAngel_EN", "LittleAngel_EN", "PersonalAngel_EN"])) max = 4;
            Selector = UnityEngine.Random.Range(0, max);
            return true;
        }
    }
    public class ForgettingConnectionEffect : EffectSO
    {
        public static int Selector => ForgettingEffectCondition.Selector;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<int> nums = new List<int>();
            List<Sprite> sprites = new List<Sprite>();
            Sprite sprite = ResourceLoader.LoadSprite("ForgettingPassive.png");
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                nums.Add(enemy.ID);
                enemy.TryRemovePassiveAbility("Forgetting_PA");
                enemy.TryRemovePassiveAbility(PassiveType_GameIDs.Withering.ToString());
                sprites.Add(sprite);
            }
            CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(nums.ToArray(), [false, false, false, false, false], ["Forgetting", "Forgetting", "Forgetting", "Forgetting", "Forgetting"], sprites.ToArray()));

            foreach (EnemyCombat enemy in new List<EnemyCombat>(stats.EnemiesOnField.Values)) enemy.DirectDeath(null);

            string[] spawning = [];
            switch (Selector)
            {
                case 1: spawning = ["RedBot_EN", "BlueBot_EN", "PurpleBot_EN", "YellowBot_EN", "GreyBot_EN"]; break;
                case 2: spawning = ["Firebird_EN", "TheCrow_EN", "Hunter_EN", "LittleBeak_EN", "Warbird_EN"]; break;
                case 3: spawning = ["FakeAngel_EN", "Clione_EN", "YellowAngel_EN", "LittleAngel_EN", "PersonalAngel_EN"]; break;
                default: spawning = ["RedFlower_EN", "BlueFlower_EN", "YellowFlower_EN", "PurpleFlower_EN", "GreyFlower_EN"]; break;
            }

            foreach (string name in spawning)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy(name), -1, false, true, CombatType_GameIDs.Spawn_Basic.ToString()));
            }

            return true;
        }
    }
}
