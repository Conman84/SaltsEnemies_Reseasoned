using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Reflection;
using static SaltsEnemies_Reseasoned.SaltsReseasoned;

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

            //marmo
            PCall(MarmoSnaurceEncounters.Add);
            PCall(MarmoSurimiEncounters.Add);
            PCall(MarmoRomanticEncounters.Add);
            PCall(MarmoSurrogateEncounters.Add);
            PCall(MarmoErrantEncounters.Add);
            PCall(MarmoGungrotEncounters.Add);
            PCall(MarmoGitEncounters.Add);
            PCall(MarmoAttritionEncounters.Add);
            PCall(Marmo_Grey_Crossovers.Add);

            //eggkeeper
            PCall(MinichibisEggkeeperEncounters.Add);

            //Round
            PCall(RoundCrossovers.Shufflers_1_4);

            //HIF
            PCall(HIF_Crossovers.Add_1_4);


        }
    }
}
