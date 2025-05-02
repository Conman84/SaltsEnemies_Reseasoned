using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Mold
    {
        public static string FieldID => "Mold_ID";
        public static string Intent => "Field_Mold";
        public static MoldFE_SO Object;
        public static void Add()
        {
            SlotStatusEffectInfoSO MoldInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
            MoldInfo.icon = ResourceLoader.LoadSprite("idk.png");
            Debug.LogError("Mold.Add. put the right sprite here");
            MoldInfo._fieldName = "Mold";
            MoldInfo._description = "While in mold, on being directly damaged or healed consume 1 pigment of this unit's health color and reduce Mold by the amount damaged or healed.\nOn using an ability while in Mold, randomize the unit's health color.\nMold decreases by half on turn end.";
            MoldInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo._applied_SE_Event;
            MoldInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            MoldInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            Debug.LogError("Mold.Add. MAKE SURE THESE ARE PULLING FROM THE RIGHT ASSETBUDNLE");

            GameObject Fool = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/Moldy/SmokeChara.prefab").gameObject;
            GameObject FoolPart = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/Moldy/MoldChara.prefab").gameObject;
            FoolPart.transform.SetParent(Fool.transform);
            GameObject_CFE_Layout LayoutFool = Fool.AddComponent<GameObject_CFE_Layout>();
            LayoutFool.m_Front = new RectTransform[] { FoolPart.GetComponent<RectTransform>() };
            LayoutFool.m_Back = new RectTransform[] { Fool.GetComponent<RectTransform>() };
            LayoutFool.m_Objects = new GameObject[] { Fool, FoolPart };
            MoldInfo.m_CharacterLayoutTemplate = LayoutFool;

            GameObject Enemy = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/Moldy/MoldEnemy.prefab");
            GameObject_EFE_Layout LayoutEnemy = Enemy.AddComponent<GameObject_EFE_Layout>();
            LayoutEnemy.m_Objects = new GameObject[] { Enemy };
            MoldInfo.m_EnemyLayoutTemplate = LayoutEnemy;

            MoldFE_SO MoldSO = ScriptableObject.CreateInstance<MoldFE_SO>();
            MoldSO._FieldID = FieldID;
            MoldSO._EffectInfo = MoldInfo;
            Object = MoldSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(FieldID)) LoadedDBsHandler.StatusFieldDB.FieldEffects[FieldID] = MoldSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewFieldEffect(MoldSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("idk.png");
            Debug.LogError("Mold.Add. set the right sprite for the intent also");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }

    public class MoldFE_SO : FieldEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnSlotEffectorTriggerAttached(FieldEffect_Holder holder)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_03, TriggerCalls.OnTurnFinished.ToString(), holder.Effector);
        }
        public override void OnSlotEffectorTriggerDettached(FieldEffect_Holder holder)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_03, TriggerCalls.OnTurnFinished.ToString(), holder.Effector);
        }
        public override void OnTriggerAttached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnDirectHealed.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnDirectDamaged.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnAbilityUsed.ToString(), caller);
        }
        public override void OnTriggerDettached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnDirectHealed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnDirectDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnAbilityUsed.ToString(), caller);
        }
        public override void OnEventCall_01(FieldEffect_Holder holder, object sender, object args)
        {
            if (args is IntegerReference num) ReduceDurationbyAmount(holder, num.value);
            if (sender is IUnit caster)
            {
                CombatStats stats = CombatManager.Instance._stats;
                JumpAnimationInformation jumpInfo = stats.GenerateUnitJumpInformation(caster.ID, caster.IsUnitCharacter);
                string manaConsumedSound = stats.audioController.manaConsumedSound;
                stats.MainManaBar.ConsumeAmountMana(caster.HealthColor, 1, jumpInfo, manaConsumedSound);
            }
        }
        public override void OnEventCall_02(FieldEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                List<ManaColorSO> colors = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Grey };
                if (unit is EnemyCombat enemy && !colors.Contains(enemy.Enemy.healthColor)) colors.Add(enemy.Enemy.healthColor);
                else if (unit is CharacterCombat chara && !colors.Contains(chara.Character.healthColor)) colors.Add(chara.Character.healthColor);
                if (colors.Contains(unit.HealthColor)) colors.Remove(unit.HealthColor);
                unit.ChangeHealthColor(colors.GetRandom());
            }
        }
        public override void OnEventCall_03(FieldEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder);
        }
        public override void ReduceDuration(FieldEffect_Holder holder)
        {
            if (!CanReduceDuration) return;
            int contentMain = holder.m_ContentMain;
            holder.m_ContentMain = contentMain / 2;
            if (!TryRemoveFieldEffect(holder))
            {
                holder.Effector.FieldEffectValuesChanged(_FieldID, useSpecialSound: false, holder.m_ContentMain - contentMain);
            }
        }
        public void ReduceDurationbyAmount(FieldEffect_Holder holder, int amount)
        {
            int contentMain = holder.m_ContentMain;
            holder.m_ContentMain = contentMain - amount;
            if (!TryRemoveFieldEffect(holder))
            {
                holder.Effector.FieldEffectValuesChanged(_FieldID, useSpecialSound: false, holder.m_ContentMain - contentMain);
            }
        }
    }
    public class ApplyMoldFieldEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Field = Mold.Object;
            if (Mold.Object == null || Mold.Object.Equals(null)) Debug.LogError("CALL \"Mold.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
