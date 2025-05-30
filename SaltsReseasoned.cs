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
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;
using System.Net.Sockets;
using static SaltsEnemies_Reseasoned.Orph.H;
using Mono.Cecil.Cil;
using static SaltsEnemies_Reseasoned.Orph;
using static UnityEngine.EventSystems.EventTrigger;

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
            Solvent.Add();
            WindSong.Add();
            Sigil.Add();
            SemiRealisticTank.Add();
            TheEndOfTime.Add();

            //my enemenemenies
            //CH9 enemies
            PCall(Grandfather.Add);
            PCall(Butterfly.Add);
            PCall(StalwartTortoise.Add);
            PCall(GreyFlower.Add);

            //CH10 Enemies
            PCall(MiniReaper.Add);
            Medamaude.Add();
            PCall(Miriam.Add);
            PCall(Shua.Add);
            PCall(Merced.Add);
            PCall(Skyloft.Add);

            //CH11 Enemies
            PCall(GlassFigurine.Add);
            PCall(Tripod.Add);
            PCall(Rabies.Add);
            PCall(Nameless.Add);
            PCall(Damocles.Add);
            PCall(Kyotlokutla.Add);

            //CH12 Enemies
            PCall(LittleBeak.Add);
            PCall(Hunter.Add);
            PCall(Firebird.Add);
            PCall(Warbird.Add);

            if (DebugVer)
            {
                //CH13 Enemies
                PCall(BlackStar.Add);
                PCall(Singularity.Add);
                PCall(Windle.Add);
                PCall(Indicator.Add);
                PCall(Maw.Add);

                //CH14 Enemies
                PCall(AbyssAngel.Add);
                PCall(YNL.Add);
                PCall(Arceles.Add);
                PCall(MidnightTrafficLight.Add);
                PCall(Pinano.Add);
                PCall(Minana.Add);
                PCall(Children.Add);

                //CH15 Enemies
                PCall(YellowBot.Add);
                PCall(RedBot.Add);
                PCall(BlueBot.Add);
                PCall(PurpleBot.Add);
                PCall(GreyBot.Add);
                PCall(GlassedSun.Add);

                //CH16 Enemies
                PCall(Crystal.Add);
                PCall(Candy.Add);
                PCall(Dragon.Add);
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
                PCall(Wednesday.Add);
                PCall(Starless.Add);
                PCall(Eyeless.Add);
                PCall(Yang.Add);
                PCall(Yin.Add);
                PCall(Pawn.Add);

                //CH20 Enemies
                PCall(TwoThousandNine.Add);
                PCall(Chiito.Add);
                PCall(Solitaire.Add);
                PCall(Foxtrot.Add);

                //CH21 Enemies
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

            //moving the passives glossary here.

            //CH1
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Freakout.png"), "Freak Out", "Upon receiving any damage, apply 0-1 Power to all allies.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Anesthetics.png"), "Numb", "Apply a certain amount of Anesthetics to this enemy at the start of each turn.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Jumpy.png"), "Jumpy", "Upon being damaged, move to a random position. Upon performing an ability, move to a random position.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Lightweight.png"), "Lightweight", "Upon moving, 50% chance to move Left or Right.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Unmasking.png"), "Unmasking", "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this unit.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Desperate.png"), "Desperate", "On taking any damage, 33% chance to apply a certain amount of Determined to self.");

            //CH2
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Fishing.png"), "Fishing", "Upon taking direct damage, spawn a \"Fish.\" The weight of the fish spawned increases upon taking more damage.");
            
            //CH3
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("DontTouchMe.png"), "Don't Touch Me", "Upon being clicked, gain an additional action on the timeline.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("StarPassive.png"), "Illusory", "This unit is immune to both direct and indirect damage.");
            
            //CH4
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Revenge.png"), "Revenge", "On taking direct damage, give this unit another action.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("PickPocket.png"), "Pick-Pocket", "On Fleeing, steal a certain amount of coins.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("DivineSacrifice.png"), "Substitute", "Permanently applies Divine Sacrifice to this unit.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("InspirationIcon.png"), "Inspired", "This unit is Inspired.");

            //CH6
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("IllusionPassive.png"), "Delirium", "This unit has an Offense and a Supportive State and randomly picks between the two on entering battle.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("splatter.png"), "Splatter", "On death, produce 4 Pigment of this unit's health color.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Overgrowth.png"), "Overgrowth", "On taking direct damage, inflict 3 Roots on the Opposing position.");

            //CH7
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("saltwater.png"), "Salinity", "On receiving direct damage, produce a certain amount of Blue Pigment.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Joeverflow.png"), "Asphyxiation", "Overflow under a certain amount will not trigger.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("NoMenu.png"), "Locked In", "The pause menu can no longer be accessed.");

            //CH8
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("survival.png"), "Survival Instinct", "On death, instantly kill the lowest health opponent.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("intimidated.png"), "Intimidated", "When an opponent moves in front of this enemy, reroll one of this unit's actions.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("CodaIcon.png"), "Coda", "On death, apply 3 Dodge, 3 Haste, and 3 Power to all allies.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("sigilPassive.png"), "Sigil", "At the start of each turn, reset this unit's Sigil.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("WarningPassive.png"), "Warning", "On taking any damage, inflict 1 Frail, Ruptured, Acid, or Muted on all opponents.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("ParanoidSpeed.png"), "Acceleration", "If the opponent's portion of the turn takes longer than 60 seconds, apply 6 Entropy to all opponents.");

            //CH9
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Ethereal.png"), "Ethereal", "On taking any damage, instantly flee. When fleeing, this unit will return at the end of the timeline if combat hasn't ended.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Hemochromia.png"), "Heterochromia", "Upon receiving any kind of damage, randomize this unit's health colour.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("DisabledIcon.png"), "Disabled", "On receiving any damage over a certain amount, cancel one of this unit's actions.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("enrupture"), "Enruptured", "Permenantly inflicts Ruptured on this unit.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("heavily_armored"), "Heavily Armored", "If this unit's positions have no Shield, apply a certain amount of Shield there.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("algophobia"), "Algophobia", "Taking a certain amount of damage or more in one turn will make this unit instantly flee.");

            //CH10
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("MissFaced.png"), "Miss-Faced", "On being direct damaged and at the end of each round, this unit's health color changes between Red and Blue.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("WellPreservedPassive.png"), "Well-Preserved", "This unit is immune to indirect damage and damage from its allies.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Incomprehensible.png"), "Incomprehensible", "When an opponent moves in front of this unit, inflict 1 Muted on them.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Dodge.png"), "Evasive", "Permenantly applies Dodge to this unit.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Lazy.png"), "Lazy", "When fleeing, this enemy will return after a certain amount of rounds if combat hasn't ended.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("FlitheringIcon.png"), "Flithering", "On any ally dying, if there are no other allies without \"Withering\" or \"Flithering\" as passives, instantly flee.\nAt the start and end of the enemies' turn, if there are no other allies without \"Cowardice\" or \"Flithering\" as passives, instantly flee.");

            //CH11
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("DamoclesPassive.png"), "Closure", "On taking any amount of damage, there is a 50% chance that this unit instantly dies then deals the amount of damage taken to the Opposing unit.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("DisorientingPassive.png"), "Disorienting", "On taking direct damage, randomize all party member ability costs.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("HateYou.png"), "Vindictive", "This unit remembers its oppressors. On taking direct damage, inflict 1 Scar on the attacker.");

            //CH12
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("panic.png"), "Nervous", "On moving, gain another action.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("hunterpassive.png"), "Horrifying", "At the end of each round, if the Opposing unit has Terror instantly kill them.\nOn being directly damaged, inflict Terror on the Opposing unit.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("CombativePassive.png"), "Combative", " This unit will flee after a set amount of turns.\nOn dealing or receiving damage, reset this unit's Fleeting counter.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("burningIcon.png"), "Burning", "On receiving direct damage, inflict a certain amount of Fire on this position and the Opposing position.");
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("rejuvination.png"), "Rejuvination", "On death, if this enemy is above a certain amount of maximum health, Resurrect it at half its maximum health.");

            //CH19
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("BacklashPassive.png"), "Backlash", "On taking direct damage, apply Shield to this unit's position for the amount of damage taken.");

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
