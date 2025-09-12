using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Blue
    {
        public static string FieldID => "BlueLight_ID";
        public static string Intent => "Field_BlueLight";
        public static FieldEffect_SO Object;
        public static void Add()
        {
            SlotStatusEffectInfoSO BlueInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
            BlueInfo.icon = ResourceLoader.LoadSprite("BlueLight.png");
            BlueInfo._fieldName = "Blue Lights";
            BlueInfo._description = "On moving into Blue Lights, randomize all pigment in the tray.";
            BlueInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo._applied_SE_Event;
            BlueInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            BlueInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            GameObject Fool = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Lights/BlueLight_Fool.prefab");
            GameObject_CFE_Layout LayoutFool = Fool.AddComponent<GameObject_CFE_Layout>();
            LayoutFool.m_Back = new RectTransform[] { Fool.GetComponent<RectTransform>() };
            LayoutFool.m_Objects = new GameObject[] { Fool };
            BlueInfo.m_CharacterLayoutTemplate = LayoutFool;
            GameObject Enemy = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Lights/BlueLight_Enemy.prefab");
            GameObject_EFE_Layout LayoutEnemy = Enemy.AddComponent<GameObject_EFE_Layout>();
            LayoutEnemy.m_Objects = new GameObject[] { Enemy };
            BlueInfo.m_EnemyLayoutTemplate = LayoutEnemy;

            BlueLightFE_SO BlueSO = ScriptableObject.CreateInstance<BlueLightFE_SO>();
            BlueSO._FieldID = FieldID;
            BlueSO._EffectInfo = BlueInfo;
            Object = BlueSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(FieldID)) LoadedDBsHandler.StatusFieldDB.FieldEffects[FieldID] = BlueSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewFieldEffect(BlueSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("BlueLight.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class BlueLightFE_SO : FieldEffect_SO
    {
        public override string DisplayText(FieldEffect_Holder holder)
        {
            string text = "";
            if (holder.Restrictor > 0)
            {
                text = text + "(" + holder.Restrictor + ")";
            }

            return text;
        }
        public override bool TryAddContent(FieldEffect_Holder holder, int content, int restrictor)
        {
            return false;
        }
        public override bool TryIncreaseContent(FieldEffect_Holder holder, int amount)
        {
            return false;
        }
        public override int JustRemoveAllContent(FieldEffect_Holder holder)
        {
            return 0;
        }
        public override void DettachRestrictor(FieldEffect_Holder holder)
        {
        }
        public override bool TryRemoveFieldEffect(FieldEffect_Holder holder)
        {
            return false;
        }
        public override bool IsPositive => true;
        public override void OnSlotEffectorTriggerAttached(FieldEffect_Holder holder)
        {
        }
        public override void OnSlotEffectorTriggerDettached(FieldEffect_Holder holder)
        {
        }

        public override void OnTriggerAttached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnMoved.ToString(), caller);
        }
        public override void OnTriggerDettached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnMoved.ToString(), caller);
        }
        public override void OnEventCall_02(FieldEffect_Holder holder, object sender, object args)
        {
            RandomizeAllManaEffect random = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
            random.manaRandomOptions = [Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Grey];
            CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction([Effects.GenerateEffect(random)], sender as IUnit));
        }
    }
}
