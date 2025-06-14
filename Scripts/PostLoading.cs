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

            PCall(NobodyGraveEncounters.Post);
            PCall(ToyUfoEncounters.Post);
            PCall(EvileyeEncounters.Post);
            PCall(YellowAngelEncounters.Post);
            PCall(ChienTindalouEncounters.Post);
            PCall(SinkerEncounters.Post);
            PCall(SkeletonShooterEncounters.Post);
            PCall(ComplimentaryEncounters.Post);
            PCall(PersonalAngelEncounters.Post);

            PCall(WednesdayEncounters.Post);
            PCall(StarlessEncounters.Post);
            PCall(PawnAEncounters.Post);
            PCall(YangEncounters.Post);
            PCall(TwoThousandNineEncounters.Post);
            PCall(ChiitoEncounters.Post);
            PCall(SolitaireEncounters.Post);
            PCall(FoxtrotEncounters.Post);
            PCall(AuthorEncounters.Post);
            PCall(WallEncounters.Post);
            PCall(DeadOrAliveEncounters.Post);
            PCall(WaltzEncounters.Post);
            PCall(VoiceTrumpetEncounters.Post);

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
            PCall(MarmoCrossover_9_10.Add);
            PCall(MarmoCrossover_11_12.Add);
            PCall(MarmoCrossovers13_14.Add);
            PCall(Marmo_15_16_Crossovers.Add);

            //eggkeeper
            PCall(MinichibisEggkeeperEncounters.Add);
            PCall(EggKeeper_9_10_Crossover.Add);
            PCall(EggKeeperCrossover_11_12.Add);
            PCall(EggKeeper_13_14_Crossovers.Add);
            PCall(EggKeeper_15_16_Crossovers.Add);

            //marmo & eggkeeper massive lump
            PCall(Crossovers_Marmo_EggKeeper_6_7_8.Add);

            if (DebugVer)
            {
                
            }

            //Round
            PCall(RoundCrossovers.Shufflers_1_4);
            PCall(RoundCrossovers.Shufflers_5_10);

            //HIF
            PCall(HIF_Crossovers.Add_1_4);
            PCall(HIF_5_10_Crossover.TheGarden);

            //giltch freakazoids
            PCall(GlitchCrossovers_1_4.Add);

            //colophon
            PCall(Colophon_1_5.Crossovers);
        }
    }
}
