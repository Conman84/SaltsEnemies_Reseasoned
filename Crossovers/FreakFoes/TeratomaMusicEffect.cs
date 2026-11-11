using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EntraStuff2
{
    public static class Example
    {
        public static void AddEnemy()
        {
            Enemy test = new Enemy("Test", "Test_EN");

            SetMusicParameterByStringEffect teratoma_music = SetMusicParameterByStringEffect.Create("Teeth");//MUST BE THIS PARAMETER

            Ability ab1 = new Ability("Test_Ability_1_A");
            ab1.Effects = [
                //ability does some various things
                //contains an AddTeethEffect HERE
                //run a checkteethamountconditioneffect (NEW ONE, to account for new tooth added)
                Effects.GenerateEffect(teratoma_music, 1, null)//conditions DidThat(true)
                ];
            //using "1" as the entryvariable for the music effect means ADD THE LAYER.
            //using "0" as the entryvariable for the music means REMOVE THE LAYER : the effect has built in logic to only remove the layer if no other things are adding it.

            //set combatexiteffects (i.e. on die or on flee)

            test.CombatExitEffects = [Effects.GenerateEffect(teratoma_music, 0, null)];
            //you dont need to do a check has teeth amount before removing the layer on death
            //the effect has logic built in to only decrease the layer if this is one of the enemies actually increasing it.
        }
    }

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
                if (amount > 0)
                {
                    if (!Params[parameter].Contains(caster)) Params[parameter].Add(caster);
                }
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
