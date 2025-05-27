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

            //glassed sun setup
            if (DebugVer) PCall(GlassedSunEffect.Instance.Setup);

            SaltDeadPixelEncounters.Add();
            PCall(SaltCrowEncounters.Add);
            SaltFreudEncounters.Add();
            SaltRusticJumbleGutsEncounters.Add();
            SaltMortalSpoggleEncounters.Add();
            SaltMechanicalLensEncounters.Add();
            
            if (DebugVer)
            {
                PCall(GrandfatherEncounters.Post);
                PCall(GreyFlowerEncounters.Post);
                PCall(SpectreWitchFamiliarEncounters.Post);
                PCall(MiniReaperEncounters.Post);
                PCall(MedamaudeEncounters.Post);
            }

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

            //marmo & eggkeeper massive lump
            PCall(Crossovers_Marmo_EggKeeper_6_7_8.Add);

            if (DebugVer)
            {
                
            }

            //Round
            PCall(RoundCrossovers.Shufflers_1_4);

            //HIF
            PCall(HIF_Crossovers.Add_1_4);

            //giltch freakazoids
            PCall(GlitchCrossovers_1_4.Add);
        }
    }
}
