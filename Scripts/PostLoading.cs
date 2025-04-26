using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Reflection;

namespace SaltEnemies_Reseasoned
{
    public static class PostLoading
    {
        public static void Setup()
        {
            IDetour addThingsToSepulchreAndBronzoIDetour = (IDetour)new Hook((MethodBase)typeof(MainMenuController).GetMethod(nameof(MainMenuController.FinalizeMainMenuSounds), ~BindingFlags.Default), typeof(PostLoading).GetMethod(nameof(ProcessGameStart), ~BindingFlags.Default));
        }

        static bool Called;
        public static void ProcessGameStart(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            if (Called) return;
            Called = true;

            SaltDeadPixelEncounters.Add();
            SaltCrowEncounters.Add();
            SaltFreudEncounters.Add();
            SaltRusticJumbleGutsEncounters.Add();
            SaltMortalSpoggleEncounters.Add();
            SaltMechanicalLensEncounters.Add();

            //Crossovers
            SaltsReseasoned.PCall(MarmoSnaurceEncounters.Add);
            SaltsReseasoned.PCall(MarmoSurimiEncounters.Add);
            SaltsReseasoned.PCall(MarmoRomanticEncounters.Add);
            SaltsReseasoned.PCall(MarmoSurrogateEncounters.Add);
            SaltsReseasoned.PCall(MarmoErrantEncounters.Add);
            SaltsReseasoned.PCall(MarmoGungrotEncounters.Add);
            SaltsReseasoned.PCall(MarmoGitEncounters.Add);
            SaltsReseasoned.PCall(MarmoAttritionEncounters.Add);
            SaltsReseasoned.PCall(MinichibisEggkeeperEncounters.Add);
        }
    }
}
