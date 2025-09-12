using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Green
    {
        public static string FieldID => "GreenLight_ID";
        public static string Intent => "Field_GreenLight";
        public static FieldEffect_SO Object;
        public static void Add()
        {
            SlotStatusEffectInfoSO GreenInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
            GreenInfo.icon = ResourceLoader.LoadSprite("GreenLight.png");
            GreenInfo._fieldName = "Green Lights";
            GreenInfo._description = "Deal and take double direct damage.";
            GreenInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo._applied_SE_Event;
            GreenInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            GreenInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            GameObject Fool = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Lights/GreenLight_Fool.prefab");
            GameObject_CFE_Layout LayoutFool = Fool.AddComponent<GameObject_CFE_Layout>();
            LayoutFool.m_Front = new RectTransform[] { Fool.GetComponent<RectTransform>() };
            LayoutFool.m_Objects = new GameObject[] { Fool };
            GreenInfo.m_CharacterLayoutTemplate = LayoutFool;
            GameObject Enemy = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Lights/GreenLight_Enemy.prefab");
            GameObject_EFE_Layout LayoutEnemy = Enemy.AddComponent<GameObject_EFE_Layout>();
            LayoutEnemy.m_Objects = new GameObject[] { Enemy };
            GreenInfo.m_EnemyLayoutTemplate = LayoutEnemy;

            GreenLightFE_SO GreenSO = ScriptableObject.CreateInstance<GreenLightFE_SO>();
            GreenSO._FieldID = FieldID;
            GreenSO._EffectInfo = GreenInfo;
            Object = GreenSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(FieldID)) LoadedDBsHandler.StatusFieldDB.FieldEffects[FieldID] = GreenSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewFieldEffect(GreenSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("GreenLight.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class GreenLightFE_SO : FieldEffect_SO
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
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnWillApplyDamage.ToString(), caller);
        }
        public override void OnTriggerDettached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnWillApplyDamage.ToString(), caller);
        }
        public override void OnEventCall_01(FieldEffect_Holder holder, object sender, object args)
        {
            DamageReceivedValueChangeException ex = args as DamageReceivedValueChangeException;
            if (ex.directDamage)
            {
                ex.AddModifier(new GreenLightReceivedMultiplyIntValueModifier(2, this));
            }
        }
        public override void OnEventCall_02(FieldEffect_Holder holder, object sender, object args)
        {
            (args as DamageDealtValueChangeException).AddModifier(new MultiplyIntValueModifier(dmgDealt: true, 2));
            string effectSound = (((StatusField.Spotlight as SpotlightSE_SO).EffectInfo != null) ? (StatusField.Spotlight as SpotlightSE_SO).EffectInfo.SpecialSoundEvent02 : "");
            CombatManager.Instance.AddUIAction(new PlayStatusEffectSoundAndWaitUIAction(effectSound, (StatusField.Spotlight as SpotlightSE_SO)._PostSoundDelay));
        }
        public void ProcessBeingDamagedSounds()
        {
            string effectSound = (((StatusField.Spotlight as SpotlightSE_SO).EffectInfo != null) ? (StatusField.Spotlight as SpotlightSE_SO).EffectInfo.SpecialSoundEvent01 : "");
            CombatManager.Instance.AddUIAction(new PlayStatusEffectSoundAndWaitUIAction(effectSound, (StatusField.Spotlight as SpotlightSE_SO)._PostSoundDelay));
        }
    }

    public class GreenLightReceivedMultiplyIntValueModifier : IntValueModifier
    {
        public readonly int toMultiply;

        public readonly GreenLightFE_SO spotLightSE;

        public GreenLightReceivedMultiplyIntValueModifier(int toMultiply, GreenLightFE_SO spotLightSE)
            : base(72)
        {
            this.toMultiply = toMultiply;
            this.spotLightSE = spotLightSE;
        }

        public override int Modify(int value)
        {
            if (value != 0)
            {
                spotLightSE?.ProcessBeingDamagedSounds();
            }

            return value * toMultiply;
        }
    }
}
