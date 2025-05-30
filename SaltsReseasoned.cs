using BepInEx;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using UnityEngine;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.Chapter1.LostSheep;
using Unity.Mathematics;
using UnityEngine.InputSystem.HID;

namespace SaltsEnemies_Reseasoned
{

    [BepInPlugin("000.saltenemies", "Salt Enemies (TM) Reseasoned", "0.3.0")]
    [BepInDependency("BrutalOrchestra.BrutalAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class SaltsReseasoned : BaseUnityPlugin
    {
        public static int trolling = UnityEngine.Random.Range(0, 100);
        public static int silly = UnityEngine.Random.Range(0, 100);
        public static int rando => UnityEngine.Random.Range(0, 100);

        public static AssetBundle saltsAssetBundle;
        public static AssetBundle Group4;
        public static AssetBundle Meow;

        //change this to false when pushing public version
        public static bool DebugVer = true;

        public void Awake()
        {
            Logger.LogInfo("they salt on my enemies till i season?");

            SaltsReseasoned.saltsAssetBundle = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("hawthorne"));//changed because i think repeatedly renaming it is a waste
            SaltsReseasoned.Group4 = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("group4"));
            SaltsReseasoned.Meow = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("meowy"));

            //Setup
            #region Setup
            //PCall(ResourceLoaderHook.Setup);
            CustomVisuals.Setup();
            FleetingValue.Setup();
            AnglerHandler.Setup();
            AttackSlotsErrorHook.Setup();
            MainMenuException.Setup();
            NotificationHook.Setup();
            CrowIntents.Add();
            EnemyRefresher.Setup();
            CameraEffects.Setup();
            ModCamera.Setup();
            SaltPassivesCamera.Setup();
            PostLoading.Setup();
            ShinyHandler.Setup();
            HooksGeneral.Setup();
            PCall(FallColor.Setup);
            PCall(GibsFix.Setup);
            PCall(ShuaHandler.Setup);
            StarlessPassiveAbility.Setup();
            TurnStarter.Setup();
            GlassedSunHandler.Setup();
            PCall(AuthorHandler.Setup);
            //PCall(ShieldPiercer.Setup);
            #endregion

            //Add To Glossary
            #region Adding to Glossary
            LoadedDBsHandler.StatusFieldDB.TryGetStatusEffect("Stunned_ID", out StatusEffect_SO Stunned);
            if (!LoadedDBsHandler.GlossaryDB._StatusInfos.Contains(Stunned.EffectInfo))
            {
                LoadedDBsHandler.GlossaryDB.AddNewStatusID(Stunned.EffectInfo);
            }
            #endregion

            //Statuses
            Anesthetics.Add();
            Inverted.Add();
            Left.Add();
            Pale.Add();
            Power.Add();
            Determined.Add();
            DivineSacrifice.Add();
            PCall(Inspiration.Add);
            Favor.Add();
            Muted.Add();
            Roots.Add();
            Photo.Add();
            Dodge.Add();
            Entropy.Add();
            Haste.Add();
            //Hollow.Add();
            Acid.Add();
            if (DebugVer)
            {
                Drowning.Add();
                Water.Add();
                PCall(Terror.Add);
                PCall(Slip.Add);
                PCall(Mold.Add);
                Pimples.Add();
            }

            //CH1 Enemies
            LostSheep.Add();
            Enigma.Add();
            DeadPixel.Add();
            LittleAngel.Add();
            DeadGod.Add();

            //CH2 Enemies
            ManFish.Add();
            Satyr.Add();
            Denial.Add();
            Derogatory.Add();
            Something.Add();

            //CH3 Enemies
            AFlower.Add();
            StarGazer.Add();
            Freud.Add();
            Crow.Add();

            //CH4 Enemies
            MechanicalLens.Add(); //ADD MOD EFFECTS
            RusticJumbleGuts.Add();
            MortalSpoggle.Add();
            CoinHunter.Add();

            //CH6 Enemies
            Delusion.Add();
            FakeAngel.Add();
            RBYPFlowers.Add();

            //CH7 Enemies
            PCall(Deep.Add);
            PCall(War.Add);
            PCall(Postmodern.Add);

            //CH8 Enemies
            Sigil.Add();
            Solvent.Add();
            WindSong.Add();
            TheEndOfTime.Add();
            SemiRealisticTank.Add();

            if (DebugVer)
            {
                //CH9 enemies
                PCall(Butterfly.Add);
                PCall(Grandfather.Add);
                PCall(StalwartTortoise.Add);
                PCall(GreyFlower.Add);

                //CH10 Enemies
                Medamaude.Add();
                PCall(Skyloft.Add);
                PCall(MiniReaper.Add);
                PCall(Shua.Add);
                PCall(Merced.Add);
                PCall(Miriam.Add);

                //CH11 Enemies
                PCall(GlassFigurine.Add);
                PCall(Tripod.Add);
                PCall(Rabies.Add);
                PCall(Nameless.Add);
                PCall(Damocles.Add);
                PCall(Kyotlokutla.Add);

                //CH12 Enemies
                PCall(Warbird.Add);
                PCall(LittleBeak.Add);
                PCall(Hunter.Add);
                PCall(Firebird.Add);

                //CH13 Enemies
                PCall(Maw.Add);
                PCall(BlackStar.Add);
                PCall(Singularity.Add);
                PCall(Windle.Add);
                PCall(Indicator.Add);

                //CH14 Enemies
                PCall(MidnightTrafficLight.Add);
                PCall(Pinano.Add);
                PCall(Minana.Add);
                PCall(AbyssAngel.Add);
                PCall(Arceles.Add);
                PCall(YNL.Add);
                PCall(Children.Add);

                //CH15 Enemies
                PCall(YellowBot.Add);
                PCall(GreyBot.Add);
                PCall(RedBot.Add);
                PCall(BlueBot.Add);
                PCall(PurpleBot.Add);
                PCall(GlassedSun.Add);

                //CH16 Enemies
                PCall(Dragon.Add);
                PCall(Crystal.Add);
                PCall(Candy.Add);
                PCall(OdeToHumanity.Add);
                PCall(TortureMeNot.Add);

                //CH17 Enemies
                PCall(Ufo.Add);
                PCall(YellowAngel.Add);
                PCall(NobodyGrave.Add);
                PCall(Defender.Add);
                PCall(Evileye.Add);
                PCall(EvilDog.Add);

                //CH18 Enemies
                PCall(Shooter.Add);
                PCall(SkeletonHead.Add);
                PCall(Sinker.Add);
                PCall(PersonalAngel.Add);
                PCall(Complimentary.Add);

                //CH19 Enemies
                PCall(Starless.Add);
                PCall(Eyeless.Add);
                PCall(Pawn.Add);
                PCall(Wednesday.Add);
                PCall(Yang.Add);
                PCall(Yin.Add);
                PCall(Solitaire.Add);
                PCall(TwoThousandNine.Add);
                PCall(Chiito.Add);
                PCall(Foxtrot.Add);
                PCall(Author.Add);
                PCall(Monster.Add);
                PCall(Wall.Add);
            }

            //CH1 Encounters
            LostSheepEncounters.Add();
            EnigmaEncounters.Add();
            DeadPixelEncounters.Add();
            LittleAngelEncounters.Add();
            DeadGodEncounter.Add();

            //CH2 Encounters
            ManFishEncounters.Add();
            SatyrEncounters.Add();
            SomethingEncounters.Add();

            //CH3 Encounters
            AFlowerEncounters.Add();
            StarGazerEncounters.Add();
            FreudEncounters.Add();
            CrowEncounters.Add();

            //CH4 Encounters
            MechanicalLensEncounters.Add();
            MortalSpoggleEncounters.Add();
            RusticJumbleGutsEncounter.Add();

            //CH6 Encounters
            DelusionEncounters.Add();
            BlueFlowerEncounters.Add();
            RedFlowerEncounters.Add();
            YellowFlowerEncounters.Add();
            PurpleFlowerEncounters.Add();

            //CH7 Encounters
            TheDeepEncounter.Add();

            //CH8 Encounters
            SigilEncounters.Add();
            TheEndOfTimeEncounters.Add();
            SemiRealisticTankEncounters.Add();
            SolventEncounters.Add();
            WindSongEncounters.Add();

            //I think the next update should be chapters 9-12. ive made changes to reflect as much.
            //CH9 Encounters
            PCall(GrandfatherEncounters.Add);
            PCall(GreyFlowerEncounters.Add);
            PCall(StalwartTortoiseEncounters.Add);
            PCall(SpectreWitchFamiliarEncounters.Add);

            //CH10 Encounters
            PCall(MiniReaperEncounters.Add);
            PCall(MedamaudeEncounters.Add);
            PCall(MercedEncounters.Add);
            PCall(SkyloftEncounters.Add);
            PCall(MiriamEncounters.Add);
            PCall(ShuaEncounters.Add);

            //CH11 Encounters
            PCall(TripodEncounters.Add);
            PCall(GlassFigurineEncounters.Add);
            PCall(RabiesEncounters.Add);
            PCall(KyotlokutlaEncounters.Add);

            //CH12 Encounters
            PCall(LittleBeakEncounters.Add);
            PCall(HunterEncounters.Add);
            PCall(FirebirdEncounters.Add);
            PCall(WarbirdEncounters.Add);

            if (DebugVer)
            {
                //CH13 Encounters
                PCall(WindleEncounters.Add);
                PCall(BlackStarEncounters.Add);
                PCall(IndicatorEncounters.Add);
                PCall(MawEncounters.Add);
            }

            Logger.LogInfo("Seasons greasons");
        }

        public static void PCall(Action call)
        {
            try { call(); }
            catch (Exception ex)
            {
                try
                {
                    Debug.LogError(call.GetMethodInfo().Name + " FUCKING FAILED TO GET ADDED");
                }
                catch
                {
                    Debug.LogError("some fucking function failed to get added");
                }

                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
        }
        public static void PCall(Action<int> call, int var)
        {
            try { call(var); }
            catch (Exception ex)
            {
                try
                {
                    Debug.LogError(call.GetMethodInfo().Name + " FUCKING FAILED TO GET ADDED");
                }
                catch
                {
                    Debug.LogError("some fucking function failed to get added");
                }

                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
        }
    }
}
