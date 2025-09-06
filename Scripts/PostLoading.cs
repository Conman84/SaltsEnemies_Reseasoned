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
            PCall(Marmo17_18.AddShore);
            PCall(Marmo17_18.AddOrpheum);
            PCall(Marmo17_18.AddGarden);
            PCall(Marmo_Chapter_19.OrpheumCrossovers);
            PCall(Marmo_Chapter_19.GardenCross);
            PCall(Marmo_Crossovers_20.Add20Orph);
            PCall(Marmo_Crossovers_20.Add20Shore);
            PCall(MarmoCrossovers21.AddOrph);
            PCall(MarmoCrossovers21.AddShore);
            
            if (DebugVer)
            {
                PCall(MarmoCrossover_W_B_V.Add_Orph);
                PCall(MarmoCrossover_W_B_V.Add_Garden);
            }

            //eggkeeper
            PCall(MinichibisEggkeeperEncounters.Add);
            PCall(EggKeeper_9_10_Crossover.Add);
            PCall(EggKeeperCrossover_11_12.Add);
            PCall(EggKeeper_13_14_Crossovers.Add);
            PCall(EggKeeper_15_16_Crossovers.Add);
            PCall(EggKeeper_17_18Crossovers.Add);
            PCall(EggKeeper_19_21.Crossover);

            //marmo & eggkeeper massive lump
            PCall(Crossovers_Marmo_EggKeeper_6_7_8.Add);

            if (DebugVer)
            {
                
            }

            //Round
            PCall(RoundCrossovers.Shufflers_1_4);
            PCall(RoundCrossovers.Shufflers_5_10);
            PCall(RoundCrossovers.Shufflers_11_14);
            PCall(RoundCrossovers.Shufflers_15_18);
            PCall(RoundCrossovers.Shufflers_19_21);

            //HIF
            PCall(HIF_Crossovers.Add_1_4);
            PCall(HIF_5_10_Crossover.TheGarden);
            PCall(HIF_11_12_Crossovers.TheGarden);
            PCall(HIF_Cross_13_14.NoseStoneStuff);
            PCall(HIF_15_16.CrossoversGarden);
            PCall(HIF_17_18_Crossover.AddGarden);
            PCall(Nosestone_CH19_Crossover.Add_Garden);
            PCall(HIF_5_10_Crossover.FarShore);
            PCall(HIF_5_10_Crossover.Orpheum);
            PCall(HIF_11_12_Crossovers.FarShore);
            PCall(HIF_11_12_Crossovers.Orpheum);
            PCall(HIF_Cross_13_14.EverythingElse);
            PCall(HIF_15_16.CrossoversOrph);
            PCall(HIF_15_16.CrossoversGarden);
            PCall(HIF_17_18_Crossover.AddShore);
            PCall(HIF_17_18_Crossover.AddOrph);

            //giltch freakazoids
            PCall(GlitchCrossovers_1_4.Add);
            PCall(GlitchCrossover_6_8.Add);
            PCall(GlitchCrossovers_9_12.Add);
            PCall(Glitch_Crossovers_13_16.Add_13_14);
            PCall(Glitch_Crossovers_13_16.Add_15_16);
            PCall(Glitch_Cross_17_18.Add);
            PCall(GlitchCrossover19_21.Add);

            //colophon
            PCall(Colophon_1_5.Crossovers);
            PCall(Colophon_6_10_Cross.Ad);
            PCall(Colophon11_15.AddCrossovers);
            PCall(Colophon16_18.Add);
            PCall(Colophon_19Crossover.Add);
            PCall(Colophon_20_crossover.Add);
            PCall(Colophon21Crossover.Add);

            //undivine
            PCall(UndivineCrossovers.Add1_4);
            PCall(UndivineCrossovers.Add6_8);
            PCall(UndivineCrossovers.Add9_12);
            PCall(UndivineCrossovers.Add13_16);
            PCall(UndivineCrossovers.Add17_18);
            PCall(UndivineCrossovers.Add19_21);
            PCall(Undivine_Clergy_Crossovers.Add);
            PCall(Undivine_Sonoduct_Crossover.Add);

            //psi's
            PCall(Psi_CH1_4_Crossover.Add);
            PCall(Psi_CH_5_10_Hahaha.Add);
            PCall(Psi_Crossovers_CH_11_14.Add);
            PCall(Psi_CH_15_18_Crossover.Add);
            PCall(Psi_19_21_Crosssover.Add);
        }
    }
}
