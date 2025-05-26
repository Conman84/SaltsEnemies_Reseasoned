using System.Collections.Generic;
using FMOD;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class AbilitySelector_Wednesday : BaseAbilitySelectorSO
    {
        [Header("Come Home Data")]
        [SerializeField]
        public int _useAfterSelections = 1;

        [SerializeField]
        public string _lockedAbility = "";

        public string Value => "WednesdayAbilities_A";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int num = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < abilities.Count; i++)
            {
                if (!ShouldBeIgnored(abilities[i], unit))
                {
                    num += abilities[i].rarity.rarityValue;
                    list.Add(i);
                }
            }

            if (list.Count <= 0)
            {
                return -1;
            }

            int num2 = Random.Range(0, num);
            num = 0;
            foreach (int item in list)
            {
                num += abilities[item].rarity.rarityValue;
                if (num2 < num)
                {
                    unit.SimpleSetStoredValue(Value, unit.SimpleGetStoredValue(Value) + 1);
                    return item;
                }
            }

            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            if (ability.ability.name != _lockedAbility)
            {
                return false;
            }

            int num = unit.SimpleGetStoredValue(Value);

            return num < _useAfterSelections;
        }
        public static AbilitySelector_Wednesday Create(string ability, int turns = 1)
        {
            AbilitySelector_Wednesday ret = ScriptableObject.CreateInstance<AbilitySelector_Wednesday>();
            ret._lockedAbility = ability;
            ret._useAfterSelections = turns;
            return ret;
        }
    }
    public class WednesdayEffect : EffectSO
    {
        public static int Amount = 0;
        public static void Reset() => Amount = 0;
        public bool Add = true;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            return Trigger(Add);
        }

        public static bool Trigger(bool Add)
        {
            bool GOING = Amount > 0;
            if (Add) Amount++;
            else Amount--;
            if ((Amount > 0) == GOING) return Amount > 0;
            if (Amount > 0)
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("wednesday thread failed to shut down."); }
                }
                changeMusic = new System.Threading.Thread(GO);
                changeMusic.Start();
            }
            else
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("wednesday thread failed to shut down."); }
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
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("Phone", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 100 && Amount > 0; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Phone", i);
                System.Threading.Thread.Sleep(20);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
        public static void STOP()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("Phone", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i >= 0 && Amount <= 0; i--)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Phone", i);
                System.Threading.Thread.Sleep(20);
                //if (i < 5) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }

        public static WednesdayEffect Create(bool Add)
        {
            WednesdayEffect ret = ScriptableObject.CreateInstance<WednesdayEffect>();
            ret.Add = Add;
            return ret;
        }
    }
    public class OnlyTriggerIfOnceCondition : EffectConditionSO
    {
        public static string Value => "TriggerOnlyOnceEffectConditionSO";
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.SimpleGetStoredValue(Value) > 0)
            {
                return true;
            }
            return false;
        }
    }
    public class CallEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            List<EnemyCombat> enemies = new List<EnemyCombat>();
            List<int> abilities = new List<int>();

            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                int num = 1;

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
