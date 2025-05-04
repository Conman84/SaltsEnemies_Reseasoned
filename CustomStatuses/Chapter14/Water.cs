using BrutalAPI;
using FMODUnity;
using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Water
    {
        public static string FieldID => "Water_ID";
        public static string Intent => "Field_Water";
        public static string Rem_Intent => "Rem_Field_Water";
        public static bool InWater(CombatStats stats, IUnit unit)
        {
            bool flag = false;
            for (int slotId = unit.SlotID; slotId < unit.SlotID + unit.Size; ++slotId)
            {
                if (stats.combatSlots.UnitInSlotContainsFieldEffect(slotId, unit.IsUnitCharacter, FieldID))
                    flag = true;
            }
            return flag;
        }
        public static WaterFE_SO Object;
        public static bool[] IgnoreSet;

        public static bool[] HasWaterFool;
        public static bool[] HasWaterEnemy;

        public static void Clear()
        {
            IgnoreSet = new bool[5];
            HasWaterFool = new bool[5];
            HasWaterEnemy = new bool[5];
        }
        public static void Add()
        {
            Clear();

            SlotStatusEffectInfoSO WaterInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
            WaterInfo.icon = ResourceLoader.LoadSprite("DeepFieldIcon.png");
            WaterInfo._fieldName = "Deep Water";
            WaterInfo._description = "On moving into Deep Water, inflict 1 Drowning on this unit. Double all Drowning on this unit at the end of each round. \nDecreases by 1 at the end of each turn.";
            WaterInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.OilSlicked_ID.ToString()]._EffectInfo._applied_SE_Event;
            WaterInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.OilSlicked_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            WaterInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.OilSlicked_ID.ToString()]._EffectInfo.UpdatedSoundEvent;
            
            GameObject Fool = SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/Water/Test.prefab").gameObject;
            GameObject[] FoolParts = new GameObject[]
            {
                SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/Water/FishFoolBack.prefab").gameObject,
                SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/Water/FishFoolJelly.prefab").gameObject,
                SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/Water/FishFoolFront.prefab").gameObject,
                SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/Water/FishFoolWater.prefab").gameObject
            };
            foreach (GameObject child in FoolParts) child.transform.SetParent(Fool.transform);
            Animator_CFE_Layout LayoutFool = Fool.AddComponent<Water_CFE_Layout>();
            LayoutFool.m_Front = new RectTransform[] { FoolParts[2].GetComponent<RectTransform>(), FoolParts[3].GetComponent<RectTransform>() };
            LayoutFool.m_Back = new RectTransform[] { FoolParts[0].GetComponent<RectTransform>(), FoolParts[1].GetComponent<RectTransform>() };
            LayoutFool.m_Animators = new Animator[] { FoolParts[0].GetComponent<Animator>(), FoolParts[1].GetComponent<Animator>(), FoolParts[2].GetComponent<Animator>(), FoolParts[3].GetComponent<Animator>() };
            WaterInfo.m_CharacterLayoutTemplate = LayoutFool;

            GameObject Enemy = SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/Water/FishEnemy.prefab");
            Particle_EFE_Layout LayoutEnemy = Enemy.AddComponent<Water_EFE_Layout>();
            LayoutEnemy.m_FieldParticles = new ParticleSystem[] 
            { 
                Enemy.transform.GetChild(0).GetComponent<ParticleSystem>(), 
                Enemy.transform.GetChild(1).GetComponent<ParticleSystem>(), 
                Enemy.transform.GetChild(2).GetComponent<ParticleSystem>(), 
                Enemy.transform.GetChild(3).GetComponent<ParticleSystem>(),
                Enemy.transform.GetChild(4).GetComponent<ParticleSystem>(),
                Enemy.transform.GetChild(5).GetComponent<ParticleSystem>(),
            };
            WaterInfo.m_EnemyLayoutTemplate = LayoutEnemy;

            WaterFE_SO WaterSO = ScriptableObject.CreateInstance<WaterFE_SO>();
            WaterSO._FieldID = FieldID;
            WaterSO._EffectInfo = WaterInfo;
            Object = WaterSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(FieldID)) LoadedDBsHandler.StatusFieldDB.FieldEffects[FieldID] = WaterSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewFieldEffect(WaterSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("DeepFieldIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);

            IntentInfoBasic reminfo = new IntentInfoBasic();
            reminfo._color = Intents.GetInGame_IntentInfo(IntentType_GameIDs.Rem_Field_Shield)._color;
            reminfo._sprite = ResourceLoader.LoadSprite("DeepFieldIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Rem_Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Rem_Intent] = reminfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Rem_Intent, reminfo);

            IDetour hook0 = new Hook(typeof(CharacterSlotsHaveSwappedUIAction).GetMethod(nameof(CharacterSlotsHaveSwappedUIAction.Execute), ~BindingFlags.Default), typeof(Water).GetMethod(nameof(Water.Execute), ~BindingFlags.Default));
            IDetour hook1 = new Hook(typeof(EnemySlotsHaveSwappedUIAction).GetMethod(nameof(EnemySlotsHaveSwappedUIAction.Execute), ~BindingFlags.Default), typeof(Water).GetMethod(nameof(Water.Execute), ~BindingFlags.Default));
            //IDetour hook2 = new Hook(typeof(CharacterFieldEffectLayout).GetMethod(nameof(CharacterFieldEffectLayout.InitializeLayout), ~BindingFlags.Default), typeof(Water).GetMethod(nameof(Water.InitializeLayout), ~BindingFlags.Default));
        }
        public static IEnumerator Execute(Func<CombatAction, CombatStats, IEnumerator> orig, CombatAction self, CombatStats stats)
        {
            yield return orig(self, stats);

            try
            {
                if (self is CharacterSlotsHaveSwappedUIAction ch)
                {
                    foreach (int i in ch._newSlotIDs)
                    {
                        if (HasWaterFool == null || HasWaterFool.Length <= i) HasWaterFool = new bool[5];
                        foreach (CharacterSlotLayout slot in stats.combatUI._characterZone._slots)
                        {
                            if (slot.SlotID == i && slot._hasUnit && HasWaterFool[slot.SlotID])
                            {
                                RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/Water");
                            }
                        }
                    }
                }
                else if (self is EnemySlotsHaveSwappedUIAction en)
                {
                    foreach (int i in en._newSlotIDs)
                    {
                        if (HasWaterEnemy == null || HasWaterEnemy.Length <= i) HasWaterEnemy = new bool[5];
                        foreach (EnemySlotLayout slot in stats.combatUI._enemyZone._slots)
                        {
                            bool HasUnit = false;
                            int Size = 1;
                            foreach (EnemyCombatUIInfo enUI in stats.combatUI._enemiesInCombat.Values)
                            {
                                if (enUI.SlotID <= slot.SlotID && slot.SlotID < enUI.SlotID + enUI.EnemyBase.size)
                                {
                                    HasUnit = true;
                                    Size = enUI.EnemyBase.size;
                                }
                            }
                            if (slot.SlotID == i && HasUnit)
                            {
                                if (HasWaterEnemy[slot.SlotID])
                                {
                                    RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/Water");
                                }
                                else if (Size > 1)
                                {
                                    for (int p = slot.SlotID; p < slot.SlotID + Size; p++)
                                    {
                                        if (HasWaterEnemy == null || HasWaterEnemy.Length <= p) HasWaterEnemy = new bool[5];
                                        bool Found = false;
                                        foreach (EnemySlotLayout plot in stats.combatUI._enemyZone._slots)
                                        {
                                            bool isUnited = false;
                                            foreach (EnemyCombatUIInfo enUI in stats.combatUI._enemiesInCombat.Values)
                                            {
                                                if (enUI.SlotID <= plot.SlotID && plot.SlotID < enUI.SlotID + enUI.EnemyBase.size)
                                                {
                                                    isUnited = true;
                                                }
                                            }
                                            if (plot.SlotID == p && isUnited && HasWaterEnemy[plot.SlotID])
                                            {
                                                RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/Water");
                                                Found = true;
                                                break;
                                            }
                                        }
                                        if (Found) break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Debug.LogError("failed to play water sound.");
            }
        }
        public static void InitializeLayout(Action<CharacterFieldEffectLayout, RectTransform, RectTransform, RectTransform> orig, CharacterFieldEffectLayout self, RectTransform frontHolder, RectTransform backHolder, RectTransform swapHolder)
        {
            if (self is Water_CFE_Layout water)
            {
                water.Parent = self.transform.GetComponentInParent<CharacterSlotLayout>();
                Debug.Log(water.Parent);
            }
            orig(self, frontHolder, backHolder, swapHolder);
        }
    }
    public class WaterFE_SO : FieldEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnSlotEffectorTriggerAttached(FieldEffect_Holder holder)
        {
            if (holder.Effector is CombatSlot slot && slot.HasUnit) Water.IgnoreSet[holder.SlotID] = true;
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), holder.Effector);
        }
        public override void OnSlotEffectorTriggerDettached(FieldEffect_Holder holder)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), holder.Effector);
        }
        public override void OnTriggerAttached(FieldEffect_Holder holder, IUnit caller)
        {
            if (Water.IgnoreSet[holder.SlotID])
            {
                Water.IgnoreSet[holder.SlotID] = false;
                return;
            }
            CombatManager.Instance.AddSubAction(new PerformSlotStatusEffectAction(holder, caller, null, true));
        }
        public override void OnTriggerDettached(FieldEffect_Holder holder, IUnit caller)
        {
        }
        public override void OnEventCall_01(FieldEffect_Holder holder, object sender, object args)
        {
            if (sender is CombatSlot slot && slot.HasUnit && slot.Unit is IUnit unit && unit.ContainsStatusEffect(Drowning.StatusID))
            {
                if (Drowning.Object == null || Drowning.Object.Equals(null)) Drowning.Add();
                unit.ApplyStatusEffect(Drowning.Object, unit.GetStatusAmount(Drowning.StatusID, true));
            }
            ReduceDuration(holder);
        }
        public override void OnSubActionTrigger(FieldEffect_Holder holder, object sender, object args, bool stateCheck)
        {
            base.OnSubActionTrigger(holder, sender, args, stateCheck);
            if (Drowning.Object == null || Drowning.Object.Equals(null)) Drowning.Add();
            if (sender is IUnit unit) unit.ApplyStatusEffect(Drowning.Object, 1);
        }
    }

    public class Water_EFE_Layout : Particle_EFE_Layout
    {
        public override void EnableLayout()
        {
            base.EnableLayout();
            Water.HasWaterEnemy[transform.parent.GetComponent<EnemySlotLayout>().SlotID] = true;
        }
        public override void DisableLayout()
        {
            base.DisableLayout();
            Water.HasWaterEnemy[transform.parent.GetComponent<EnemySlotLayout>().SlotID] = false;
        }
    }
    public class Water_CFE_Layout : Animator_CFE_Layout
    {
        public CharacterSlotLayout Parent;
        public override void EnableLayout(bool hasUnit)
        {
            base.EnableLayout(hasUnit);
            if (Parent == null || Parent.Equals(null))
            {
                foreach (CharacterSlotLayout layout in CombatManager.Instance._stats.combatUI._characterZone._slots)
                {
                    if (layout._FieldInstances.Values.Contains(this)) Parent = layout;
                }
            }
            Water.HasWaterFool[Parent.SlotID] = true;
        }
        public override void DisableLayout()
        {
            base.DisableLayout();
            if (Parent == null || Parent.Equals(null))
            {
                foreach (CharacterSlotLayout layout in CombatManager.Instance._stats.combatUI._characterZone._slots)
                {
                    if (layout._FieldInstances.Values.Contains(this)) Parent = layout;
                }
            }
            Water.HasWaterFool[Parent.SlotID] = false;
        }

    }
    public class ApplyWaterSlotEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Field = Water.Object;
            if (Water.Object == null || Water.Object.Equals(null)) Water.Add();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }

    public static class StatusExtensions
    {
        public static StatusEffect_Holder GetStatus(this IUnit self, string id)
        {
            if (!self.ContainsStatusEffect(id)) return null;
            foreach (IStatusEffect holder in (self as IStatusEffector).StatusEffects)
            {
                if (holder.StatusID == id && holder is StatusEffect_Holder ret) return ret;
            }
            return null;
        }
        public static int GetStatusAmount(this IUnit self, string id, bool includeRestrictor = false)
        {
            if (!self.ContainsStatusEffect(id)) return 0;
            foreach (IStatusEffect holder in (self as IStatusEffector).StatusEffects)
            {
                if (holder.StatusID == id) return includeRestrictor ? holder.StatusContent + holder.Restrictor : holder.StatusContent;
            }
            return 0;
        }
    }
}
