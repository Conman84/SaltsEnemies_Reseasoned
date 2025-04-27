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

    [BepInPlugin("millieamp.reseasoned", "Salt Enemies (TM) Reseasoned", "0.1.3")]
    [BepInDependency("BrutalOrchestra.BrutalAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class SaltsReseasoned : BaseUnityPlugin
    {
        public static int trolling = UnityEngine.Random.Range(0, 100);
        public static int silly = UnityEngine.Random.Range(0, 100);
        public static int rando => UnityEngine.Random.Range(0, 100);

        public static AssetBundle saltsAssetBundle;
        public static AssetBundle Group4;
        public static AssetBundle Meow;

        public void Awake()
        {
            Logger.LogInfo("they salt on my enemies till i season?");

            SaltsReseasoned.saltsAssetBundle = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("hawthorne"));//changed because i think repeatedly renaming it is a waste
            SaltsReseasoned.Group4 = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("group4"));
            SaltsReseasoned.Meow = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("meowy"));

            //Setup
            #region Setup
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
            Favor.Add();
            Muted.Add();
            Roots.Add();
            Photo.Add();
            Dodge.Add();
            Entropy.Add();
            Haste.Add();
            Hollow.Add();
            Acid.Add();

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
