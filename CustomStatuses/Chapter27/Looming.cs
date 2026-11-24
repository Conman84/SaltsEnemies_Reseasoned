using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Looming
    {
        public static string FieldID => "Looming_ID";
        public static string Intent => "Field_Looming";
        //public static string Rem_Intent => "Rem_Field_Looming";
        public static string Trigger => "TriggerCalls_Looming";
        public static LoomingFE_SO CharaObject;
        public static LoomingFE_SO EnemyObject;
        public static void Add()
        {
            SlotStatusEffectInfoSO LoomingInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
            LoomingInfo.icon = ResourceLoader.LoadSprite("SlipIcon.png");
            LoomingInfo._fieldName = "Looming";
            LoomingInfo._description = "Looming increases by 1 on turn end, and by 2 if the position is unoccupied.\nLooming reduces by 1 on anything being directly damaged while in Looming, and when a party member manually performs an ability while in Looming.\nIf Looming reaches 10 or higher, summon a Seventh Sin and remove Looming from this position.";
            LoomingInfo._applied_SE_Event = "event:/Hawthorne/Misc2/ApplyTerror";//change to unique when possible
            LoomingInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.OilSlicked_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            LoomingInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.OilSlicked_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            LoadedDBsHandler.GlossaryDB.AddNewFieldID(LoomingInfo);

            GameObject Fool = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/SlipChara2.prefab").gameObject;
            GameObject FoolPart = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/SlipChara3.prefab").gameObject;
            FoolPart.transform.SetParent(Fool.transform);
            GameObject_CFE_Layout LayoutFool = Fool.AddComponent<GameObject_CFE_Layout>();
            LayoutFool.m_Swap = new RectTransform[] { FoolPart.GetComponent<RectTransform>() };
            LayoutFool.m_Back = new RectTransform[] { Fool.GetComponent<RectTransform>() };
            LayoutFool.m_Objects = new GameObject[] { Fool, FoolPart };
            LoomingInfo.m_CharacterLayoutTemplate = LayoutFool;

            GameObject Enemy = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/SlipEnemy.prefab");
            GameObject_EFE_Layout LayoutEnemy = Enemy.AddComponent<GameObject_EFE_Layout>();
            LayoutEnemy.m_Objects = new GameObject[] { Enemy };
            LoomingInfo.m_EnemyLayoutTemplate = LayoutEnemy;

            LoomingFE_SO LoomingChara = ScriptableObject.CreateInstance<LoomingFE_SO>();
            LoomingChara._FieldID = FieldID;
            LoomingChara._EffectInfo = LoomingInfo;
            LoomingChara.isCharaSide = true;
            CharaObject = LoomingChara;

            LoomingFE_SO LoomingEnemy = ScriptableObject.CreateInstance<LoomingFE_SO>();
            LoomingEnemy._FieldID = FieldID;
            LoomingEnemy._EffectInfo = LoomingInfo;
            LoomingEnemy.isCharaSide = false;
            EnemyObject = LoomingEnemy;

            //Object = SlipSO;
            //if (LoadedDBsHandler.GlossaryDB.FieldInfos.;

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("SlipIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);


            /*
            IntentInfoBasic reminfo = new IntentInfoBasic();
            reminfo._color = Intents.GetInGame_IntentInfo(IntentType_GameIDs.Rem_Field_Shield)._color;
            reminfo._sprite = ResourceLoader.LoadSprite("SlipIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Rem_Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Rem_Intent] = reminfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Rem_Intent, reminfo);*/
        }
    }


    public class LoomingFE_SO : FieldEffect_SO
    {
        public bool isCharaSide;
        public override bool IsPositive => !isCharaSide;
        public override void OnSlotEffectorTriggerAttached(FieldEffect_Holder holder)
        {
            if (holder.Effector is CombatSlot slot && slot.HasUnit) Roots.IgnoreSet[holder.SlotID] = true;
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_03, TriggerCalls.OnTurnFinished.ToString(), holder.Effector);
        }
        public override void OnSlotEffectorTriggerDettached(FieldEffect_Holder holder)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_03, TriggerCalls.OnTurnFinished.ToString(), holder.Effector);
        }
        public override void OnTriggerAttached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, Roots.SubTrigger, caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, Roots.Trigger, caller);
            if (Roots.IgnoreSet[holder.SlotID])
            {
                Roots.IgnoreSet[holder.SlotID] = false;
                return;
            }
            CombatManager.Instance.AddSubAction(new PerformSlotStatusEffectAction(holder, caller, null, true));
        }
        public override void OnTriggerDettached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, Roots.SubTrigger, caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, Roots.Trigger, caller);
        }
        public override void OnEventCall_01(FieldEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                CombatManager.Instance.AddSubAction(new RootsDamageAction(UnityEngine.Random.Range(2, 4), unit, holder.SlotID));
            }
        }
        public override void OnEventCall_02(FieldEffect_Holder holder, object sender, object args)
        {
            if (args is int slot && slot == holder.SlotID)
                ReduceDuration(holder);
        }
        public override void OnEventCall_03(FieldEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder);
        }
        public override void OnSubActionTrigger(FieldEffect_Holder holder, object sender, object args, bool stateCheck)
        {
            ForceReduceDuration(holder);
        }
        public void ForceReduceDuration(FieldEffect_Holder holder)
        {
            int contentMain = holder.m_ContentMain;
            holder.m_ContentMain = Mathf.Max(0, contentMain - 1);
            if (!TryRemoveFieldEffect(holder) && contentMain != holder.m_ContentMain)
            {
                holder.Effector.FieldEffectValuesChanged(_FieldID, useSpecialSound: false, holder.m_ContentMain - contentMain);
            }
        }
    }

    public class ApplyLoomingSlotEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            List<TargetSlotInfo> chara = [];
            List<TargetSlotInfo> enem = [];
            foreach (TargetSlotInfo target in targets)
            {
                if (target.IsTargetCharacterSlot) chara.Add(target);
                else enem.Add(target);
            }

            _Field = Looming.CharaObject;
            base.PerformEffect(stats, caster, chara.ToArray(), areTargetSlots, entryVariable, out int num);
            exitAmount += num;

            _Field = Looming.EnemyObject;
            base.PerformEffect(stats, caster, enem.ToArray(), areTargetSlots, entryVariable, out int exi);
            exitAmount += exi;

            return exitAmount > 0;
        }
    }
}
