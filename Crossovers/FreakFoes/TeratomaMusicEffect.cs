using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EntraStuff2
{
    public class SetMusicParameterByStringEffect : EffectSO
    {
        public static Dictionary<string, List<int>> Params;
        public string Parameter;

        public static void Trigger(string parameter, int amount, int caster)
        {
            if (Params == null) Params = new Dictionary<string, List<int>>();
            if (!Params.ContainsKey(parameter))
            {
                if (amount > 0) Params.Add(parameter, new List<int>() { caster });
            }
            else
            {
                if (amount > 0) Params[parameter].Add(caster);
                else Params[parameter].Remove(caster);
            }
            CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName(parameter, Params[parameter].Count > 0 ? 1 : 0);
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            Setup();
            Trigger(Parameter, entryVariable, caster.ID);
            exitAmount = 0; return true;
        }
        public static SetMusicParameterByStringEffect Create(string parameter)
        {
            SetMusicParameterByStringEffect ret = ScriptableObject.CreateInstance<SetMusicParameterByStringEffect>();
            ret.Parameter = parameter;
            return ret;
        }

        static bool _set;
        public static void Setup()
        {
            if (_set) return;
            _set = true;
            IDetour hook = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.Awake), ~System.Reflection.BindingFlags.Default), typeof(SetMusicParameterByStringEffect).GetMethod(nameof(ResetParams), ~System.Reflection.BindingFlags.Default));
        }
        public static void ResetParams(Action<CombatManager> orig, CombatManager self)
        {
            Params = new Dictionary<string, List<int>>();
            orig(self);
        }
    }
}
