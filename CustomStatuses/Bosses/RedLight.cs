using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Red
    {
        public static string FieldID => "RedLight_ID";
        public static string Intent => "Field_RedLight";
        public static FieldEffect_SO Object;
        public static void Add()
        {
            SlotStatusEffectInfoSO RedInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
            RedInfo.icon = ResourceLoader.LoadSprite("RedLight.png");
            RedInfo._fieldName = "Red Lights";
            RedInfo._description = "On using an ability, move Left or Right.";
            RedInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo._applied_SE_Event;
            RedInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            RedInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Spotlight_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            GameObject Fool = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Lights/RedLight_Fool.prefab");
            GameObject_CFE_Layout LayoutFool = Fool.AddComponent<GameObject_CFE_Layout>();
            LayoutFool.m_Front = new RectTransform[] { Fool.GetComponent<RectTransform>() };
            LayoutFool.m_Objects = new GameObject[] { Fool };
            RedInfo.m_CharacterLayoutTemplate = LayoutFool;
            GameObject Enemy = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Lights/RedLight_Enemy.prefab");
            GameObject_EFE_Layout LayoutEnemy = Enemy.AddComponent<GameObject_EFE_Layout>();
            LayoutEnemy.m_Objects = new GameObject[] { Enemy };
            RedInfo.m_EnemyLayoutTemplate = LayoutEnemy;

            RedLightFE_SO RedSO = ScriptableObject.CreateInstance<RedLightFE_SO>();
            RedSO._FieldID = FieldID;
            RedSO._EffectInfo = RedInfo;
            Object = RedSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(FieldID)) LoadedDBsHandler.StatusFieldDB.FieldEffects[FieldID] = RedSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewFieldEffect(RedSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("RedLight.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class RedLightFE_SO : FieldEffect_SO
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
            //CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnAbilityUsed.ToString(), caller);
        }
        public override void OnTriggerDettached(FieldEffect_Holder holder, IUnit caller)
        {
            //CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnAbilityUsed.ToString(), caller);
        }
        public override void OnEventCall_01(FieldEffect_Holder holder, object sender, object args)
        {
            DamageReceivedValueChangeException ex = args as DamageReceivedValueChangeException;
            if (ex.directDamage)
            {
                ex.AddModifier(new RedLightReceivedDivideIntValueModifier(2, this));
            }
        }
        public override void OnEventCall_02(FieldEffect_Holder holder, object sender, object args)
        {
            ScriptableObject.CreateInstance<SwapToSidesEffect>().PerformEffect(CombatManager.Instance._stats, sender as IUnit, Targeting.Slot_SelfSlot.GetTargets(CombatManager.Instance._stats.combatSlots, (sender as IUnit).SlotID, (sender as IUnit).IsUnitCharacter), true, 1, out int num);
        }
        public void ProcessBeingDamagedSounds()
        {
            string effectSound = (((StatusField.Spotlight as SpotlightSE_SO).EffectInfo != null) ? (StatusField.Spotlight as SpotlightSE_SO).EffectInfo.SpecialSoundEvent01 : "");
            CombatManager.Instance.AddUIAction(new PlayStatusEffectSoundAndWaitUIAction(effectSound, (StatusField.Spotlight as SpotlightSE_SO)._PostSoundDelay));
        }
    }

    public class RedLightReceivedDivideIntValueModifier : IntValueModifier
    {
        public readonly int toMultiply;

        public readonly RedLightFE_SO spotLightSE;

        public RedLightReceivedDivideIntValueModifier(int toMultiply, RedLightFE_SO spotLightSE)
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

            return (int)Math.Round((float)value / toMultiply);
        }
    }
}
