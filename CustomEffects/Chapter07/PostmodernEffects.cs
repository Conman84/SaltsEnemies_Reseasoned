using BrutalAPI;
using MonoMod.RuntimeDetour;
using System.Linq;
using System.Reflection;
using UnityEngine;
using System.Threading;
using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using Yarn.Unity;
using UnityEngine.SceneManagement;
using SaltsEnemies_Reseasoned;

/*I DO ALL THESE*/
//call NoiseHandler.Setup() in awake
//call PostmodernHandler.Setup() in awake
//The postmodern handler's code *seems* to work? if it doesnt oh fuckin well but if it does you wont need to set up an encounter for postmodern, and just do a 1-1 port of her

/*I DO THIS*/
//when setting up postmodern, do UnitTypes = new List<string> { "FemaleID" }

namespace SaltEnemies_Reseasoned
{
    public static class NoiseHandler
    {
        public static string Noise = "Postmodern_Noise";
        public static void Setup()
        {
            UnitStoreData_ModIntSO value_count = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            value_count.m_Text = "Noise +{0}";
            value_count._UnitStoreDataID = Noise;
            value_count.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
            value_count.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Noise))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Noise] = value_count;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_count._UnitStoreDataID, value_count);
        }
    }
    public class TargetStoredValueChangeEffect : EffectSO
    {
        [SerializeField]
        public bool _increase = true;

        [SerializeField]
        public int _minimumValue = 1;

        [SerializeField]
        public string _valueName = NoiseHandler.Noise;

        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int gap = target.Unit.SimpleGetStoredValue(_valueName);
                    int amount = entryVariable;
                    if (_randomBetweenPrevious)
                    {
                        amount = UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1);
                    }

                    gap += (_increase ? amount : (-amount));
                    gap = Mathf.Max(_minimumValue, gap);
                    target.Unit.SimpleSetStoredValue(_valueName, gap);
                    exitAmount += amount;
                }
            }
            return exitAmount > 0;
        }
    }
    public class TargetSetValueChangeEffect : EffectSO
    {
        [SerializeField]
        public bool _increase = true;

        [SerializeField]
        public string _valueName = NoiseHandler.Noise;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    target.Unit.SimpleSetStoredValue(_valueName, entryVariable);
                    exitAmount += target.Unit.SimpleGetStoredValue(_valueName);
                }
            }
            return exitAmount > 0;
        }
    }
    public class PostModernPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 999;

        public bool DoScreenFuck = true;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            if (args is DamageReceivedValueChangeException valueChangeException && valueChangeException.amount > 0 && args is DamageReceivedValueChangeException && !(args as DamageReceivedValueChangeException).Equals((object)null))
            {
                (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new PostmodernValueModifier(this._modifyVal, DoScreenFuck));
                CombatManager.Instance.AddUIAction((CombatAction)new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
            }
            if (!(args is CanHealReference canHealReference))
                return;
            CombatManager.Instance.AddUIAction((CombatAction)new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
            canHealReference.value = false;
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class PostmodernValueModifier : IntValueModifier
    {
        public readonly int FVAL;
        public readonly bool Fuck;

        public PostmodernValueModifier(int exitVal, bool DoScreenFuck = true)
          : base(15)
        {
            this.FVAL = exitVal;
            Fuck = DoScreenFuck;
        }

        public override int Modify(int value)
        {
            if (value > 0 && value != this.FVAL)
            {
                value = this.FVAL;
                if (!Fuck) return value;
                EffectInfo doIt = Effects.GenerateEffect(ScriptableObject.CreateInstance<MurderScreenResolutionEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(33));
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { doIt }, CombatManager.Instance._stats.CharactersOnField.First().Value));

            }
            return value;
        }
    }
    public static class RealScreen
    {
        public static int realWidth = 0;
        public static int realHeight = 0;
        public static bool realIsFullscreen = false;
        public static int realRefreshRate = 0;
        public static int audioBitRate = 0;
        public static bool realWasSet = false;
        public static bool isCrushed = false;
        public static bool isDoubleCrushed = false;
        public static bool isTripleCrushed = false;
        public static void Set()
        {
            if (!realWasSet)
            { realWidth = Screen.width; realHeight = Screen.height; realIsFullscreen = Screen.fullScreen; realWasSet = true; }

        }
        public static void AudioRate()
        {
            //audioBitRate = AudioSettings.outputSampleRate;
        }
    }
    public class MurderScreenResolutionEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            exitAmount = 0;
            if (!RealScreen.isCrushed)
            {
                RealScreen.Set();
                Screen.SetResolution(RealScreen.realWidth / 3, RealScreen.realHeight / 3, true, 6);
                RealScreen.isCrushed = true;
                //RealScreen.AudioRate();
                //AudioSettings.outputSampleRate = 5;
            }
            else if (!RealScreen.isDoubleCrushed)
            {
                Screen.SetResolution(RealScreen.realWidth / 5, RealScreen.realHeight / 5, true, 2);
                RealScreen.isDoubleCrushed = true;
            }
            else if (!RealScreen.isTripleCrushed)
            {
                Screen.SetResolution(RealScreen.realWidth / 8, RealScreen.realHeight / 8, true, 1);
                RealScreen.isTripleCrushed = true;
            }
            else
            {
                Screen.SetResolution(RealScreen.realWidth / 11, RealScreen.realHeight / 11, false, 1);
                Thread.Sleep(100);
                Screen.SetResolution(RealScreen.realWidth / 11, RealScreen.realHeight / 11, true, 1);
            }

            return exitAmount > 0;
        }
    }
    public class UnMurderScreenResolutionEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            exitAmount = 0;

            if (RealScreen.isCrushed)
            {
                Screen.SetResolution(RealScreen.realWidth, RealScreen.realHeight, RealScreen.realIsFullscreen, RealScreen.realRefreshRate);
                //AudioSettings.outputSampleRate = RealScreen.audioBitRate;
                RealScreen.isCrushed = false;
                RealScreen.isDoubleCrushed = false;
                RealScreen.isTripleCrushed = false;
            }
            return exitAmount > 0;
        }
    }
    public class LockedInPassiveAbility : BasePassiveAbilitySO
    {
        public override bool DoesPassiveTrigger => false;
        public override bool IsPassiveImmediate => false;

        public override void TriggerPassive(object sender, object args)
        {
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            LockedInHandler.Setup();
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public static class LockedInHandler
    {
        public const string Boowomp = "event:/Hawthorne/Boowomp";
        public static bool IsLocked()
        {
            try
            {
                if (CombatManager._instance == null) return false;
                if (CombatManager.Instance._stats == null) return false;
                if (!CombatManager.Instance._stats.InCombat) return false;
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    foreach (BasePassiveAbilitySO passive in enemy.PassiveAbilities) if (passive is LockedInPassiveAbility) return true;
                }
                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    foreach (BasePassiveAbilitySO passive in chara.PassiveAbilities) if (passive is LockedInPassiveAbility) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("the locked in handler is fucking up again!!");
                return true;
            }
        }
        public static void OpenPauseMenu(Action<PauseUIHandler> orig, PauseUIHandler self)
        {
            try
            {
                if (IsLocked())
                { if (Boowomp != "") RuntimeManager.PlayOneShot(Boowomp, default(Vector3)); }
                else orig(self);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("the locked in handler is *reaally* fucking up now.");
                try
                {
                    orig(self);
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogError("Ok what the fuck");
                }
            }
        }
        static bool Set;
        public static void Setup()
        {
            if (Set) return;
            Set = true;
            IDetour lockin = new Hook(typeof(PauseUIHandler).GetMethod(nameof(PauseUIHandler.OpenPauseMenu), ~BindingFlags.Default), typeof(LockedInHandler).GetMethod(nameof(OpenPauseMenu), ~BindingFlags.Default));
        }
    }
    public static class PostmodernHandler
    {
        public static OverworldManagerBG world;
        public static void Awake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
            world = self;
        }
        public static void Setup()
        {
            IDetour awakening = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.Awake), ~BindingFlags.Default), typeof(PostmodernHandler).GetMethod(nameof(Awake), ~BindingFlags.Default));
            IDetour diologo = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.InitializeDialogueFunctions), ~BindingFlags.Default), typeof(PostmodernHandler).GetMethod(nameof(InitializeDialogueFunctions), ~BindingFlags.Default));
            IDetour hook = new Hook(typeof(InGameDataSO).GetMethod(nameof(InGameDataSO.DidCompleteQuest), ~BindingFlags.Default), typeof(PostmodernHandler).GetMethod(nameof(DidCompleteQuest), ~BindingFlags.Default));
            Add();
            Hacks.Setup();
            postmodernevent();
        }

        public static void InitializeDialogueFunctions(Action<OverworldManagerBG, DialogueRunner> orig, OverworldManagerBG self, DialogueRunner dialogueRunner)
        {
            orig(self, dialogueRunner);
            dialogueRunner.AddCommandHandler("SaltPostmodernity", TriggerPostmodern);
        }

        public static void TriggerPostmodern(string[] info)
        {
            world.StartCoroutine(HandlePrePostmodernEvent(world));
        }


        public static IEnumerator HandlePrePostmodernEvent(OverworldManagerBG self)
        {
            RunDataSO run = self._informationHolder.Run;
            BaseRoomHandler currentRoomInstance = run.GetCurrentRoomInstance();
            if (currentRoomInstance != null)
            {
                currentRoomInstance.LockRoom();
            }

            EnemyCombatBundle enemyBundle = PostmodernEvent;
            if (enemyBundle.PreCombatDialogueReference != "")
            {
                self.StartDialog(enemyBundle.PreCombatDialogueReference);
                while (self._inDialogue)
                {
                    yield return null;
                }
            }

            self._inputManager.SetEscapeToggle(enabled: false);
            self.SaveProgress(false);
            run.zoneLoadingType = ZoneLoadingType.Combat;
            ZoneDataBaseSO currentZoneDB = self._informationHolder.Run.CurrentZoneDB;
            OverworldCombatSharedDataSO combatData = self._informationHolder.CombatData;
            combatData.playerCurrency = run.playerData.PlayerCurrency;
            combatData.owSceneName = SceneManager.GetActiveScene().name;
            combatData.combatAmbienceType = currentZoneDB.CombatAmbience;
            combatData.combatEnvironmentPrefabName = currentZoneDB.CombatEnvironment;
            combatData.enemyBundle = enemyBundle;
            combatData.CharactersData = run.playerData.CharactersInParty;
            combatData.SetUpRunDataForCombat(shouldSaveRunInCombat: true);
            yield return self.LoadCombatScene();
        }

        static EnemySO Postmodern => LoadedAssetsHandler.GetEnemy("Postmodern_EN");
        static EnemySO War => LoadedAssetsHandler.GetEnemy("War_EN");
        static string Music => "event:/Hawthorne/PostmodernTheme";
        static string Roar => "event:/Hawthorne/HissingNoise";

        public static EnemyCombatBundle PostmodernEvent
        {
            get
            {
                EnemyBundleData[] list = new EnemyBundleData[]
                {
                    new EnemyBundleData(Postmodern, 1),
                    new EnemyBundleData(War, 3)
                };
                RoarData roar = new RoarData(Roar);
                EnemyCombatBundle ret = new EnemyCombatBundle(list, "", Music, roar, BossType_GameIDs.None.ToString(), BundleDifficulty.Boss, "", RoomPrefab, Sign);
                return ret;
            }
        }

        public static string RoomPrefab = "PostmodernRoom";
        public static string Encounter = "PostmodernEncounter";
        public static string Dialogue = "PostmodernConvo";
        public static string Finish = "PostmodernFinish";
        public static string Speaker = "Postmodern" + PathUtils.speakerDataSuffix;

        public static string Sign = "Postmodern_1999";
        public static string Entity = "Postmodern_1999";
        public static string Quest = "Postmodern_1999";

        public static Sprite World => ResourceLoader.LoadSprite("PostmodernWorld.png", new Vector2(0.5f, 0), 100);
        public static Sprite WNPivot => ResourceLoader.LoadSprite("PostmodernWorld.png", ppu: 100);
        public static Sprite Front => ResourceLoader.LoadSprite("PostmodernFace.png", ppu: 100);
        public static YarnProgram Script
        {
            get
            {
                if (scriptMinor == null)
                {
                    YarnProgram y = SaltsReseasoned.Group4.LoadAsset<YarnProgram>("assets/group4/Postmodern/postmodern.yarn");
                    scriptMinor = y;
                }
                return scriptMinor;
            }
        }
        static YarnProgram scriptMinor;
        public static Material SpriteMat
        {
            get
            {
                BasicEncounterSO jesus = LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour");

                NPCRoomHandler hJesus = LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, jesus.encounterRoom) as NPCRoomHandler;

                BasicRoomItem hje = hJesus._npcSelectable as BasicRoomItem;

                return hje._renderers[0].material;
            }
        }

        public static DialogueSO AfterCombat;

        public static void postmodernevent()
        {
            //if (LetsYouIgnoreMissingEnemiesHook.IsDisabled("Postmodern_EN")) return;
            NPCRoomHandler room = SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Postmodern/PostmodernRoom.prefab").AddComponent<NPCRoomHandler>();

            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };

            room._npcSelectable._renderers[0].material = SpriteMat;

            LoadedAssetsHandler.TryAddExternalOWRoom(RoomPrefab, room);
            //if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + RoomPrefab)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + RoomPrefab, room);
            //else LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + RoomPrefab] = room;

            YarnProgram prog = Script;
            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = Dialogue;
            log.dialog = prog;
            log.startNode = "Salt.Postmodern.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(Dialogue)) LoadedAssetsHandler.LoadedDialogues.Add(Dialogue, log);
            else LoadedAssetsHandler.LoadedDialogues[Dialogue] = log;

            DialogueSO dies = ScriptableObject.CreateInstance<DialogueSO>();
            dies.name = Finish;
            dies.dialog = prog;
            dies.startNode = "Salt.Postmodern.end";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(Finish)) LoadedAssetsHandler.LoadedDialogues.Add(Finish, dies);
            else LoadedAssetsHandler.LoadedDialogues[Finish] = dies;
            AfterCombat = dies;


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.m_QuestName = Quest;
            ret.name = Encounter;
            ret._dialogue = Dialogue;
            ret.encounterRoom = RoomPrefab;
            ret.signID = Sign;
            ret.encounterEntityIDs = new string[] { Entity };
            ret.m_QuestsCompletedNeeded = new string[0];
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(Encounter)) LoadedAssetsHandler.LoadedBasicEncounters.Add(Encounter, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[Encounter] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 15;
            card._usePercentage = true;

            //RunDataSO.PopulateRoomInstance

            /*if (!gardE._FlavourPool.Contains(encounterName))
            {
                List<string> oldEF = new List<string>(gardE._FlavourPool);
                oldEF.Add(encounterName);
                gardE._FlavourPool = oldEF.ToArray();

                //List<CardTypeInfo> oldEC = new List<CardTypeInfo>(gardE._deckInfo._possibleCards);
                //oldEC.Add(card);
                //gardE._deckInfo._possibleCards = oldEC.ToArray();
            }*/

            if (!gardH._FlavourPool.Contains(Encounter))
            {
                gardH._FlavourPool.Add(Encounter);
                List<CardTypeInfo> oldHC = new List<CardTypeInfo>(gardH._deckInfo._possibleCards);
                oldHC.Add(card);
                gardH._deckInfo._possibleCards = oldHC.ToArray();
            }


            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = Speaker;
            test.name = Speaker;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Hawthorne/HissingNoise";
            testBund.portrait = Front;
            testBund.bundleTextColor = Color.white;


            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(Speaker)) LoadedAssetsHandler.LoadedSpeakers.Add(Speaker, test);
            else LoadedAssetsHandler.LoadedSpeakers[Speaker] = test;

        }
        public static void Add()
        {
            Portals.AddPortalSign(Sign, WNPivot, Portals.NPCIDColor);
        }

        public static bool DidCompleteQuest(Func<InGameDataSO, string, bool> orig, InGameDataSO self, string questName)
        {
            if (questName == Quest)
            {
                return (UnityEngine.Random.Range(0, 100) < 75);
            }
            return orig(self, questName);
        }

    }
    public static class Hacks
    {
        public static void Setup()
        {
            //DONT NEED???
            //IDetour hook = new Hook(typeof(RunDataSO).GetMethod(nameof(RunDataSO.PopulateRoomInstance), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(PopulateRoomInstance), ~BindingFlags.Default));
            IDetour cont = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.LoadOldRun), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(LoadOldRun), ~BindingFlags.Default));
            IDetour emba = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(LoadOldRun), ~BindingFlags.Default));
            //ScreenShake.Setup();
        }
        public static void LoadOldRun(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            PostmodernHandler.postmodernevent();
        }
    }
}
