using System;
using System.Collections;
using BrutalAPI;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Xml;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public static class CoinFlipInput
    {
        public static Button menuButton;
        static public TMP_FontAsset swordfont;
        static public ColorBlock colorblock;
        static public Vector2 resMod;
        static ColorBlock defButton;
        static ColorBlock unselectButton;
        public static void SetUpButtons()
        {
            GameObject headsButtonGO = new GameObject();
            Button headsButton = null;

            GameObject origGO = new GameObject();


            TextMeshProUGUI headsText = null;


            GameObject tailsButtonGO = new GameObject();
            Button tailsButton = null;
            TextMeshProUGUI tailsText = null;

            foreach (Button button in UnityEngine.Object.FindObjectsOfType(typeof(Button)))
            {
                //Debug.Log(button.gameObject.name);
                if (button.gameObject.name == "MenuButton")
                {
                    //Debug.Log(button.gameObject.GetType().ToString());
                    origGO = button.gameObject;
                    menuButton = button;
                    button.targetGraphic = origGO.GetComponentInChildren<TextMeshProUGUI>();
                    headsButtonGO = UnityEngine.Object.Instantiate(button.gameObject, button.gameObject.transform.parent.transform.parent);
                    tailsButtonGO = UnityEngine.Object.Instantiate(button.gameObject, button.gameObject.transform.parent.transform.parent);
                    //return;


                    headsButton = headsButtonGO.GetComponent<Button>();
                    headsText = headsButtonGO.GetComponentInChildren<TextMeshProUGUI>();
                    tailsButton = tailsButtonGO.GetComponent<Button>();
                    tailsText = tailsButtonGO.GetComponentInChildren<TextMeshProUGUI>();
                    swordfont = headsText.font;
                    colorblock = button.colors;
                    //Debug.Log("found source");
                    break;

                }
            }
            defButton = menuButton.colors;
            unselectButton = menuButton.colors;
            unselectButton.selectedColor = defButton.normalColor;
            if (headsButtonGO != null)
            {
                //Debug.Log("heads gameobject not null");
                headsButtonGO.transform.position += new Vector3(-0.5f, 1f, 0);
                Vector3 newScale = headsButtonGO.transform.localScale;
                newScale.y *= 2f;
                newScale.x *= 0.5f;
                headsButtonGO.transform.localScale = newScale;
                //Debug.Log(headsButtonGO.transform.position.x + " " + headsButtonGO.transform.position.y + " " + headsButtonGO.transform.position.z);
                headsButtonGO.name = "CoinHeadsButton";

            }
            if (tailsButtonGO != null)
            {
                //Debug.Log("heads gameobject not null");
                tailsButtonGO.transform.position += new Vector3(-1.5f, 1f, 0);
                Vector3 newScale = tailsButtonGO.transform.localScale;
                newScale.y *= 2f;
                newScale.x *= 0.5f;
                tailsButtonGO.transform.localScale = newScale;
                //Debug.Log(tailsButtonGO.transform.position.x + " " + tailsButtonGO.transform.position.y + " " + tailsButtonGO.transform.position.z);
                tailsButtonGO.name = "CoinTailsButton";

            }
            if (headsButton != null)
            {
                //Debug.Log("heads button not null");
                headsText.text = "H E A D S";
                headsText.autoSizeTextContainer = true;
                Vector3 newSize = headsText.bounds.size;
                newSize.x /= 5f;
                headsButton.targetGraphic = headsText;
                headsButton.transform.SetParent(headsButtonGO.transform);

                headsButton.onClick = new Button.ButtonClickedEvent();
                headsButton.onClick.AddListener(headsPicked);

                /*Vector3 newScale = buttontext.transform.localScale;
                newScale.y *= 0.5f;
                newScale.x *= 2f;
                buttontext.transform.localScale = newScale;*/

                /*Vector3 newPad = headsButton.targetGraphic.rectTransform.localScale;
                newPad.x /= 5f;
                headsButton.targetGraphic.rectTransform.localScale = newPad;*/

                headsText.characterWidthAdjustment *= 1000f;
                headsText.characterSpacing *= 500f;
                headsText.extraPadding = true;

                /*Vector4 newMargin = buttontext.margin;
                newMargin.x /= 5;
                newMargin.w /= 5;
                buttontext.margin = newMargin;*/


            }
            if (tailsButton != null)
            {
                //Debug.Log("heads button not null");
                tailsText.text = "T A I L S";
                tailsText.autoSizeTextContainer = true;
                Vector3 newSize = tailsText.bounds.size;
                newSize.x /= 5f;
                tailsButton.targetGraphic = tailsText;
                tailsButton.transform.SetParent(tailsButtonGO.transform);

                tailsButton.onClick = new Button.ButtonClickedEvent();
                tailsButton.onClick.AddListener(TailsPicked);

                /*Vector3 newScale = buttontext.transform.localScale;
                newScale.y *= 0.5f;
                newScale.x *= 2f;
                buttontext.transform.localScale = newScale;*/

                /*Vector3 newPad = headsButton.targetGraphic.rectTransform.localScale;
                newPad.x /= 5f;
                headsButton.targetGraphic.rectTransform.localScale = newPad;*/

                tailsText.characterWidthAdjustment *= 1000f;
                tailsText.characterSpacing *= 500f;
                tailsText.extraPadding = true;

                /*Vector4 newMargin = buttontext.margin;
                newMargin.x /= 5;
                newMargin.w /= 5;
                buttontext.margin = newMargin;*/


            }
            if (headsButtonGO != null)
            {
                headsButtonGO.SetActive(true);
                //Debug.Log("set active");
            }
            if (tailsButtonGO != null)
            {
                tailsButtonGO.SetActive(true);
                //Debug.Log("set active");
            }

        }

        public static bool inputRecieved = false;
        public static bool heads = false;
        //public static bool tails = false;
        public static bool HeadsFromResult()
        {
            if (UnityEngine.Random.Range(0, 100) < 50)
            {
                return false;
            }
            return true;
        }

        public static void headsPicked()
        {
            Debug.Log("heads");
            heads = true;
            //tails = false;
            inputRecieved = true;



            foreach (Button button in UnityEngine.Object.FindObjectsOfType(typeof(Button)))
            {
                if (button.gameObject.name == "CoinHeadsButton" || button.gameObject.name == "CoinTailsButton")
                {
                    //button.gameObject.transform.position += new Vector3(-0.1f, 0.1f, 0);
                    //return;
                    button.gameObject.SetActive(false);
                    UnityEngine.GameObject.Destroy(button.gameObject);
                    //Debug.Log("destroyed heads button ");
                }
            }
        }
        public static void TailsPicked()
        {

            heads = false;
            //tails = true;
            inputRecieved = true;
            Debug.Log("tails");


            foreach (Button button in UnityEngine.Object.FindObjectsOfType(typeof(Button)))
            {
                if (button.gameObject.name == "CoinHeadsButton" || button.gameObject.name == "CoinTailsButton")
                {
                    //button.gameObject.transform.position += new Vector3(-0.1f, 0.1f, 0);
                    //return;
                    button.gameObject.SetActive(false);
                    UnityEngine.GameObject.Destroy(button.gameObject);
                    //Debug.Log("destroyed heads button ");
                }
            }
        }
    }
    public class CoinFlipDeathEffect : EffectSO
    {
        [SerializeField]
        public bool TrueIfCorrect = false;

        public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            bool isTarget = false;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    isTarget = true;
                }
            }
            if (!isTarget)
            {
                exitAmount = 0;
                return false;
            }

            exitAmount = 0;

            CoinFlipInput.inputRecieved = false;
            CoinFlipInput.SetUpButtons();
            //while (!CoinFlipInput.inputRecieved)
            //{
            CombatManager.Instance.AddUIAction(new WaitForCoinUIAction(caster));
            //}
            return true;

        }
    }
    public class WaitForCoinUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public string _attackName;
        public int _miliseconds;
        public IUnit _caster;
        public EffectInfo _running;

        public WaitForCoinUIAction(IUnit caster)
        {
            _caster = caster;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            while (!CoinFlipInput.inputRecieved)
                yield return stats.combatUI.ShowAttackInformation(_id, _isUnitCharacter, "", "");
            Debug.Log("input recieved");
            AttackVisualsSO tailsAnim = ScriptableObject.CreateInstance<AttackVisualsSO>();
            //tailsAnim.audioReference = "event:/Combat/Attack/G1/ATK_FingerGuns";
            tailsAnim.animation = SaltsReseasoned.saltsAssetBundle.LoadAsset<AnimationClip>("Assets/Blunder/CoinFlipTailAnim.anim");
            tailsAnim.isAnimationFullScreen = true;
            AttackVisualsSO headsAnim = ScriptableObject.CreateInstance<AttackVisualsSO>();
            headsAnim.animation = SaltsReseasoned.saltsAssetBundle.LoadAsset<AnimationClip>("Assets/Blunder/CoinFlipHeadAnim.anim");
            headsAnim.isAnimationFullScreen = true;

            bool resultHeads = CoinFlipInput.HeadsFromResult();
            Debug.Log("heads: " + resultHeads);

            if (resultHeads)
                CombatManager.Instance.AddUIAction(new ForcePlayAbilityAnimationAction(headsAnim, Targeting.Slot_SelfSlot, _caster));
            else
                CombatManager.Instance.AddUIAction(new ForcePlayAbilityAnimationAction(tailsAnim, Targeting.Slot_SelfSlot, _caster));
            Debug.Log("Picked heads: " + CoinFlipInput.heads);
            if (resultHeads != CoinFlipInput.heads)
            {
                TargetSlotInfo target = CombatManager.Instance._stats.combatSlots.GetOpponentSlotTarget(_caster.SlotID, 0, false);
                if (target.HasUnit)
                {
                    target.Unit.DirectDeath(_caster, false);
                }
            }
        }


    }
    public class ForcePlayAbilityAnimationAction : CombatAction
    {
        public BaseCombatTargettingSO _targetting;

        public AttackVisualsSO _visuals;

        public IUnit _caster;

        public ForcePlayAbilityAnimationAction(AttackVisualsSO visuals, BaseCombatTargettingSO targetting, IUnit caster)
        {
            _visuals = visuals;
            _targetting = targetting;
            _caster = caster;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            TargetSlotInfo[] targets = null;
            bool areTargetSlots = true;
            if (_targetting != null)
            {
                targets = _targetting.GetTargets(stats.combatSlots, _caster.SlotID, _caster.IsUnitCharacter);
                areTargetSlots = _targetting.AreTargetSlots;
            }
            bool animsWasFalse = false;
            if (!stats.combatUI._animations.CanTriggerAnimations)
            {
                animsWasFalse = true;
                stats.combatUI._animations.CanTriggerAnimations = true;
            }
            yield return stats.combatUI.PlayAbilityAnimation(_visuals, targets, areTargetSlots);
            if (animsWasFalse)
            {
                stats.combatUI._animations.CanTriggerAnimations = false;
            }
        }
    }
    public static class SecondChance
    {
        public static Button menuButton;
        static public TMP_FontAsset swordfont;
        static public ColorBlock colorblock;
        static public Vector2 resMod;
        static ColorBlock defButton;
        static ColorBlock unselectButton;
        public const int baseCost = 1;
        public static int costMod = 0;
        public static void SetUpButtons()
        {
            GameObject yesButtonGO = new GameObject();
            Button yesButton = null;

            GameObject origGO = new GameObject();


            TextMeshProUGUI yesText = null;


            GameObject noButtonGO = new GameObject();
            Button noButton = null;
            TextMeshProUGUI noText = null;

            GameObject questionGO = new GameObject();
            Button questionButton = null;
            TextMeshProUGUI questionText = null;

            foreach (Button button in UnityEngine.Object.FindObjectsOfType(typeof(Button)))
            {
                //Debug.Log(button.gameObject.name);
                if (button.gameObject.name == "MenuButton")
                {
                    //Debug.Log(button.gameObject.GetType().ToString());
                    origGO = button.gameObject;
                    menuButton = button;
                    button.targetGraphic = origGO.GetComponentInChildren<TextMeshProUGUI>();
                    yesButtonGO = UnityEngine.Object.Instantiate(button.gameObject, button.gameObject.transform.parent.transform.parent);
                    noButtonGO = UnityEngine.Object.Instantiate(button.gameObject, button.gameObject.transform.parent.transform.parent);
                    questionGO = UnityEngine.Object.Instantiate(button.gameObject, button.gameObject.transform.parent.transform.parent);
                    //return;


                    yesButton = yesButtonGO.GetComponent<Button>();
                    yesText = yesButtonGO.GetComponentInChildren<TextMeshProUGUI>();
                    noButton = noButtonGO.GetComponent<Button>();
                    noText = noButtonGO.GetComponentInChildren<TextMeshProUGUI>();
                    questionButton = questionGO.GetComponent<Button>();
                    questionText = questionGO.GetComponentInChildren<TextMeshProUGUI>();
                    swordfont = yesText.font;
                    colorblock = button.colors;
                    //Debug.Log("found source");
                    break;

                }
            }
            defButton = menuButton.colors;
            unselectButton = menuButton.colors;
            unselectButton.selectedColor = defButton.normalColor;
            if (yesButtonGO != null)
            {
                //Debug.Log("heads gameobject not null");
                yesButtonGO.transform.position += new Vector3(-0.5f, 0.6f, 0);
                Vector3 newScale = yesButtonGO.transform.localScale;
                newScale.y *= 2f;
                newScale.x *= 0.5f;
                yesButtonGO.transform.localScale = newScale;
                //Debug.Log(headsButtonGO.transform.position.x + " " + headsButtonGO.transform.position.y + " " + headsButtonGO.transform.position.z);
                yesButtonGO.name = "YesRerollButton";

            }
            if (noButtonGO != null)
            {
                //Debug.Log("heads gameobject not null");
                noButtonGO.transform.position += new Vector3(-1.5f, 0.6f, 0);
                Vector3 newScale = noButtonGO.transform.localScale;
                newScale.y *= 2f;
                newScale.x *= 0.5f;
                noButtonGO.transform.localScale = newScale;
                //Debug.Log(tailsButtonGO.transform.position.x + " " + tailsButtonGO.transform.position.y + " " + tailsButtonGO.transform.position.z);
                noButtonGO.name = "NoRerollButton";

            }
            if (questionGO != null)
            {
                //Debug.Log("heads gameobject not null");
                questionGO.transform.position += new Vector3(-1f, 1.2f, 0);
                Vector3 newScale = questionGO.transform.localScale;
                newScale.y *= 2f;
                questionGO.transform.localScale = newScale;
                //Debug.Log(tailsButtonGO.transform.position.x + " " + tailsButtonGO.transform.position.y + " " + tailsButtonGO.transform.position.z);
                questionGO.name = "QuestionButton";

            }
            if (yesButton != null)
            {
                //Debug.Log("heads button not null");
                yesText.text = "Y  E  S";
                yesText.autoSizeTextContainer = true;
                Vector3 newSize = yesText.bounds.size;
                newSize.x /= 5f;
                yesButton.targetGraphic = yesText;
                yesButton.transform.SetParent(yesButtonGO.transform);

                yesButton.onClick = new Button.ButtonClickedEvent();
                yesButton.onClick.AddListener(yesChosen);

                /*Vector3 newScale = buttontext.transform.localScale;
                newScale.y *= 0.5f;
                newScale.x *= 2f;
                buttontext.transform.localScale = newScale;*/

                /*Vector3 newPad = headsButton.targetGraphic.rectTransform.localScale;
                newPad.x /= 5f;
                headsButton.targetGraphic.rectTransform.localScale = newPad;*/

                yesText.characterWidthAdjustment *= 1000f;
                yesText.characterSpacing *= 500f;
                yesText.extraPadding = true;

                /*Vector4 newMargin = buttontext.margin;
                newMargin.x /= 5;
                newMargin.w /= 5;
                buttontext.margin = newMargin;*/


            }
            if (noButton != null)
            {
                //Debug.Log("heads button not null");
                noText.text = "N  O";
                noText.autoSizeTextContainer = true;
                Vector3 newSize = noText.bounds.size;
                newSize.x /= 5f;
                noButton.targetGraphic = noText;
                noButton.transform.SetParent(noButtonGO.transform);

                noButton.onClick = new Button.ButtonClickedEvent();
                noButton.onClick.AddListener(noChosen);

                /*Vector3 newScale = buttontext.transform.localScale;
                newScale.y *= 0.5f;
                newScale.x *= 2f;
                buttontext.transform.localScale = newScale;*/

                /*Vector3 newPad = headsButton.targetGraphic.rectTransform.localScale;
                newPad.x /= 5f;
                headsButton.targetGraphic.rectTransform.localScale = newPad;*/

                noText.characterWidthAdjustment *= 1000f;
                noText.characterSpacing *= 500f;
                noText.extraPadding = true;

                /*Vector4 newMargin = buttontext.margin;
                newMargin.x /= 5;
                newMargin.w /= 5;
                buttontext.margin = newMargin;*/


            }
            if (questionButton != null)
            {
                //Debug.Log("heads button not null");
                int cost = baseCost + costMod;
                string Qtext = "Coin flip failed. Pay ";
                Qtext += cost.ToString();
                Qtext += " coins to try again?";
                questionText.text = Qtext;
                questionText.autoSizeTextContainer = true;
                questionButton.targetGraphic = questionText;
                questionButton.transform.SetParent(questionGO.transform);

                questionButton.onClick = new Button.ButtonClickedEvent();

                /*Vector3 newScale = buttontext.transform.localScale;
                newScale.y *= 0.5f;
                newScale.x *= 2f;
                buttontext.transform.localScale = newScale;*/

                /*Vector3 newPad = headsButton.targetGraphic.rectTransform.localScale;
                newPad.x /= 5f;
                headsButton.targetGraphic.rectTransform.localScale = newPad;*/

                //noText.characterWidthAdjustment *= 1000f;
                //noText.characterSpacing *= 500f;
                //noText.extraPadding = true;

                /*Vector4 newMargin = buttontext.margin;
                newMargin.x /= 5;
                newMargin.w /= 5;
                buttontext.margin = newMargin;*/


            }
            if (yesButtonGO != null)
            {
                yesButtonGO.SetActive(true);
                //Debug.Log("set active");
            }
            if (noButtonGO != null)
            {
                noButtonGO.SetActive(true);
                //Debug.Log("set active");
            }
            if (questionGO != null)
            {
                questionGO.SetActive(true);
                //Debug.Log("set active");
            }

        }

        public static bool inputRecieved = false;
        public static bool doReroll = false;
        //public static bool tails = false;
        public static bool HeadsFromResult()
        {
            if (UnityEngine.Random.Range(0, 100) < 50)
            {
                return false;
            }
            return true;
        }

        public static void yesChosen()
        {
            //Debug.Log("heads");
            doReroll = true;
            //tails = false;
            inputRecieved = true;



            foreach (Button button in UnityEngine.Object.FindObjectsOfType(typeof(Button)))
            {
                if (button.gameObject.name == "YesRerollButton" || button.gameObject.name == "NoRerollButton" || button.gameObject.name == "QuestionButton")
                {
                    //button.gameObject.transform.position += new Vector3(-0.1f, 0.1f, 0);
                    //return;
                    button.gameObject.SetActive(false);
                    UnityEngine.GameObject.Destroy(button.gameObject);
                    //Debug.Log("destroyed heads button ");
                }
            }
        }
        public static void noChosen()
        {

            doReroll = false;
            //tails = true;
            inputRecieved = true;
            //Debug.Log("tails");


            foreach (Button button in UnityEngine.Object.FindObjectsOfType(typeof(Button)))
            {
                if (button.gameObject.name == "YesRerollButton" || button.gameObject.name == "NoRerollButton" || button.gameObject.name == "QuestionButton")
                {
                    //button.gameObject.transform.position += new Vector3(-0.1f, 0.1f, 0);
                    //return;
                    button.gameObject.SetActive(false);
                    UnityEngine.GameObject.Destroy(button.gameObject);
                    //Debug.Log("destroyed heads button ");
                }
            }
        }
    }
    public class WaitForCoinWithRerollUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public string _attackName;
        public int _miliseconds;
        public IUnit _caster;
        public EffectInfo _running;

        public WaitForCoinWithRerollUIAction(IUnit caster)
        {
            _caster = caster;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            while (!CoinFlipInput.inputRecieved)
                yield return stats.combatUI.ShowAttackInformation(_id, _isUnitCharacter, "", "");
            AttackVisualsSO tailsAnim = ScriptableObject.CreateInstance<AttackVisualsSO>();
            //tailsAnim.audioReference = "event:/Combat/Attack/G1/ATK_FingerGuns";
            tailsAnim.animation = SaltsReseasoned.saltsAssetBundle.LoadAsset<AnimationClip>("Assets/Blunder/CoinFlipTailAnim.anim");
            tailsAnim.isAnimationFullScreen = true;
            AttackVisualsSO headsAnim = ScriptableObject.CreateInstance<AttackVisualsSO>();
            headsAnim.animation = SaltsReseasoned.saltsAssetBundle.LoadAsset<AnimationClip>("Assets/Blunder/CoinFlipHeadAnim.anim");
            headsAnim.isAnimationFullScreen = true;

            bool resultHeads = CoinFlipInput.HeadsFromResult();



            if (resultHeads)
                CombatManager.Instance.AddUIAction(new ForcePlayAbilityAnimationAction(headsAnim, Targeting.Slot_SelfSlot, _caster));
            else
                CombatManager.Instance.AddUIAction(new ForcePlayAbilityAnimationAction(tailsAnim, Targeting.Slot_SelfSlot, _caster));
            if (resultHeads != CoinFlipInput.heads)
            {
                int cost = (SecondChance.baseCost + SecondChance.costMod);
                if (stats.PlayerCurrency >= cost)
                {
                    CombatManager.Instance.AddUIAction(new ShowCombatCurrencyEffectUIAction(true));
                    CombatManager.Instance.AddUIAction(new WaitForSecondChanceUIAction(_caster));
                }
                else
                {
                    TargetSlotInfo kill = CombatManager.Instance._stats.combatSlots.GetOpponentSlotTarget(_caster.SlotID, 0, false);
                    if (kill.HasUnit)
                    {
                        kill.Unit.DirectDeath(_caster, false);
                    }
                }

            }
        }


    }
    public class WaitForSecondChanceUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public string _attackName;
        public int _miliseconds;
        public IUnit _caster;
        public EffectInfo _running;

        public WaitForSecondChanceUIAction(IUnit caster)
        {
            _caster = caster;
        }

        public override IEnumerator Execute(CombatStats stats)
        {

            SecondChance.inputRecieved = false;
            SecondChance.SetUpButtons();
            while (!SecondChance.inputRecieved)
                yield return stats.combatUI.ShowAttackInformation(_id, _isUnitCharacter, "", "");

            if (SecondChance.doReroll)
            {
                int cost = (SecondChance.baseCost + SecondChance.costMod);
                stats.TryLoseCurrency(cost, true);
                TargetSlotInfo target = CombatManager.Instance._stats.combatSlots.GetOpponentSlotTarget(_caster.SlotID, 0, false);
                if (target.HasUnit)
                {
                    CombatManager.Instance.AddUIAction(new PlayCurrencyEffectUIAction(target.Unit.ID, target.Unit.IsUnitCharacter, -cost, isMultiplier: false));
                }
                else
                {
                    CombatManager.Instance.AddUIAction(new PlayCurrencyEffectUIAction(_caster.ID, _caster.IsUnitCharacter, -cost, isMultiplier: false));
                }
                CombatManager.Instance.AddUIAction(new ShowCombatCurrencyEffectUIAction(false));
                CoinHunterCostHandler.increaseCostMod(10);
                SecondChance.costMod = CoinHunterCostHandler.Numbah;

                CoinFlipInput.inputRecieved = false;
                CoinFlipInput.SetUpButtons();
                CombatManager.Instance.AddUIAction(new WaitForCoinWithRerollUIAction(_caster));
            }
            else
            {
                TargetSlotInfo kill = CombatManager.Instance._stats.combatSlots.GetOpponentSlotTarget(_caster.SlotID, 0, false);
                if (kill.HasUnit)
                {
                    kill.Unit.DirectDeath(_caster, false);
                }
            }
        }


    }
    public static class CoinHunterCostHandler
    {

        public const string ModID = "SaltHawthorne";
        static string baseSave
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheTalia\\BrutalOrchestra\\";
            }
        }
        static string pathPlus
        {
            get
            {
                if (!Directory.Exists(baseSave + "Mods\\"))
                {
                    Directory.CreateDirectory(baseSave + "Mods\\");
                }
                return baseSave + "Mods\\";
            }
        }
        public static string SavePath
        {
            get
            {
                if (!Directory.Exists(pathPlus + ModID + "\\"))
                {
                    Directory.CreateDirectory(pathPlus + ModID + "\\");
                }
                return pathPlus + ModID + "\\";
            }
        }
        public static int Numbah = 0;
        public static void increaseCostMod(int newNum)
        {
            Numbah += newNum;
            Directory.CreateDirectory(SavePath);
            StreamWriter text = File.CreateText(SavePath + "Hawthorne.config");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<config Numbah = '" + Numbah.ToString() + "'> </config>");
            xmlDocument.Save((TextWriter)text);
            text.Close();
            text.Dispose();
        }
    }
    public class CoinFlipDeathWithRerollEffect : EffectSO
    {
        [SerializeField]
        public bool TrueIfCorrect = false;

        public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            bool isTarget = false;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    isTarget = true;
                }
            }
            if (!isTarget)
            {
                exitAmount = 0;
                return false;
            }

            exitAmount = 0;

            CoinFlipInput.inputRecieved = false;
            CoinFlipInput.SetUpButtons();
            //while (!CoinFlipInput.inputRecieved)
            //{
            CombatManager.Instance.AddUIAction(new WaitForCoinWithRerollUIAction(caster));
            //}
            return true;

        }
    }
}
