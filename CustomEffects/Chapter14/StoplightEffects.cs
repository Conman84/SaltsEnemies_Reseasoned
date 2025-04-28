using BrutalAPI;
using FMOD;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class TrainEffect : EffectSO
    {
        public static string Value => "Stoplight_A";
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int yeah = caster.SimpleGetStoredValue(Value);
            yeah += entryVariable;
            int run = 0;
            while (yeah < 0 || yeah > 2)
            {
                if (yeah > 2) yeah -= 3;
                if (yeah < 0) yeah += 3;
                run++;
                if (run > 1000)
                {
                    yeah = 0;
                    break;
                }
            }
            caster.SimpleSetStoredValue(Value, yeah);
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "light", yeah));
            exitAmount = yeah;
            return true;
        }
    }
    public class TrainCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.SimpleGetStoredValue(TrainEffect.Value) != 2;
        }
    }
    public class SecondTrainCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.SimpleGetStoredValue(TrainEffect.Value) == 2;
        }
    }
    public class InstantiateExtraAttackPassiveAbility : ExtraAttackPassiveAbility
    {
        public Dictionary<IUnit, ExtraAbilityInfo> units;
        public override void TriggerPassive(object sender, object args)
        {
            if (args is List<string> list && units != null)
            {
                try
                {
                    if (units.TryGetValue(sender as IUnit, out var val))
                    {
                        list.Add(val.ability?.name);
                    }
                }
                catch
                {
                    UnityEngine.Debug.LogError("failed to add extra abilitu lo");
                }
            }
        }
        public override void OnPassiveConnected(IUnit unit)
        {
            try
            {
                AbilitySO abil = ScriptableObject.Instantiate(_extraAbility.ability);
                abil.intents[0].targets = ScriptableObject.Instantiate(_extraAbility.ability.intents[0].targets);
                ExtraAbilityInfo add = new ExtraAbilityInfo()
                {
                    rarity = _extraAbility.rarity,
                    cost = _extraAbility.cost,
                    ability = abil
                };
                unit.AddExtraAbility(add);
                if (units == null) units = new Dictionary<IUnit, ExtraAbilityInfo>();
                units.Add(unit, add);
            }
            catch
            {
                UnityEngine.Debug.LogError("womp womp instantiateextraattackPA failed connect");
            }
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            try
            {
                if (units != null)
                {
                    if (units.TryGetValue(unit, out var add))
                    {
                        unit.TryRemoveExtraAbility(add);
                    }
                }
            }
            catch
            {
                UnityEngine.Debug.LogError("womp womp instantiateextraattackPA failed disconnec");
            }
        }
    }
    public class TrainSongEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (changeMusic != null)
            {
                try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("train thread failed to shut down."); }
            }
            changeMusic = new System.Threading.Thread(GO);
            changeMusic.Start();
            return true;
        }

        public static System.Threading.Thread changeMusic;
        public static void GO()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("train", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 15; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("train", i);
                System.Threading.Thread.Sleep(100);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
    }
    public class TrainSetterEffect : EffectSO
    {
        public static string Value => "Stoplight_A";
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.SimpleSetStoredValue(Value, entryVariable);
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "light", entryVariable));
            exitAmount = entryVariable;
            return true;
        }
    }
    public static class FallColor
    {
        public static string Intent => "AnimatedIntent_Identifier";
        public static void Setup()
        {
            Intents.CreateAndAddCustom_Basic_IntentToPool(Intent, ResourceLoader.LoadSprite("idk.png"), new Color(28f, 78f, 128f));
        }
    }
}
