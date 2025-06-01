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
            PCall(GlassedSunEffect.Instance.Setup);

            SaltDeadPixelEncounters.Add();
            PCall(SaltCrowEncounters.Add);
            SaltFreudEncounters.Add();
            SaltRusticJumbleGutsEncounters.Add();
            SaltMortalSpoggleEncounters.Add();
            SaltMechanicalLensEncounters.Add();

            //I think the next update should be chapters 9-12. ive made changes to reflect as much.
            PCall(GrandfatherEncounters.Post);
            PCall(GreyFlowerEncounters.Post);
            PCall(SpectreWitchFamiliarEncounters.Post);
            PCall(MiniReaperEncounters.Post);
            PCall(MedamaudeEncounters.Post);
            PCall(MercedEncounters.Post);
            PCall(SkyloftEncounters.Post);
            PCall(ShuaEncounters.Post);

            PCall(NamelessEncounters.Post);
            PCall(DamoclesEncounters.Post);
            PCall(GlassFigurineEncounters.Post);
            PCall(RabiesEncounters.Post);
            PCall(LittleBeakEncounters.Post);
            PCall(HunterEncounters.Post);
            PCall(FirebirdEncounters.Post);
            PCall(WarbirdEncounters.Post);

            PCall(WindleEncounters.Post);
            PCall(BlackStarEncounters.Post);
            PCall(IndicatorEncounters.Post);
            PCall(MawEncounters.Post);
            PCall(AbyssAngelEncounters.Post);
            PCall(YourNewLifeEncounters.Post);
            PCall(MidnightTrafficLightEncounters.Post);
            PCall(ArcelesEncounters.Post);
            PCall(ChildrenEncounters.Post);
            PCall(PinanoEncounters.Post);

            PCall(RedBotEncounters.Post);
            PCall(YellowBotEncounters.Post);
            PCall(BlueBotEncounters.Post);
            PCall(PurpleBotEncounters.Post);
            PCall(GreyBotEncounters.Post);
            PCall(GlassedSunEncounters.Post);
            PCall(CrystallineCorpseEaterEncounters.Post);
            PCall(TortureMeNotEncounters.Post);
            PCall(DragonEncounters.Post);
            PCall(OdeToHumanityEncounters.Post);

            if (DebugVer)
            {
                PCall(NobodyGraveEncounters.Post);
                PCall(ToyUfoEncounters.Post);
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
