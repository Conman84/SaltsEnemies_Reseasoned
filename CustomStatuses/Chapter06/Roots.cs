using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;

//call Roots.Add() and Photo.Add() in awake

namespace SaltEnemies_Reseasoned
{
    public static class Roots
    {
        public static string FieldID => "Roots_ID";
        public static string DamageType => "Dmg_Roots";
        public static string Trigger => "TriggerCalls_Roots";
        public static string Intent => "Field_Roots";
        public static RootsFE_SO Object;
        public static bool[] IgnoreSet;
        public static void Add()
        {
            IgnoreSet = new bool[5];

            TMP_ColorGradient RootsGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
            Color32 rootsColor = new Color32(70, 172, 0, 255);
            RootsGradient.bottomLeft = rootsColor;
            RootsGradient.bottomRight = rootsColor;
            RootsGradient.topLeft = rootsColor;
            RootsGradient.topRight = rootsColor;
            if (LoadedDBsHandler.CombatDB.m_TxtColorPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_TxtColorPool[DamageType] = RootsGradient;
            else LoadedDBsHandler.CombatDB.AddNewTextColor(DamageType, RootsGradient);

            if (LoadedDBsHandler.CombatDB.m_SoundPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_SoundPool[DamageType] = LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Dmg_Ruptured.ToString()];
            else LoadedDBsHandler.CombatDB.AddNewSound(DamageType, LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Dmg_Ruptured.ToString()]);

            SlotStatusEffectInfoSO RootsInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
            RootsInfo.icon = ResourceLoader.LoadSprite("RootsIcon.png");
            RootsInfo._fieldName = "Roots";
            RootsInfo._description = "On using an ability in Roots, take 2-3 indirect damage and heal all units with Photosynthesis for the amount of damage taken.\nRoots decreases on moving into Roots, on turn end, and on activation.";
            RootsInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo._applied_SE_Event;
            RootsInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            RootsInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo.UpdatedSoundEvent;
            GameObject Fool = SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/Roots/RootsCharacter.prefab");
            GameObject_CFE_Layout LayoutFool = Fool.AddComponent<GameObject_CFE_Layout>();
            LayoutFool.m_Front = new RectTransform[] { Fool.GetComponent<RectTransform>() };
            LayoutFool.m_Objects = new GameObject[] { Fool };
            RootsInfo.m_CharacterLayoutTemplate = LayoutFool;
            GameObject Enemy = SaltsReseasoned.Group4.LoadAsset<GameObject>("Assets/Roots/RootsEnemy.prefab");
            GameObject_EFE_Layout LayoutEnemy = Enemy.AddComponent<GameObject_EFE_Layout>();
            LayoutEnemy.m_Objects = new GameObject[] { Enemy };
            RootsInfo.m_EnemyLayoutTemplate = LayoutEnemy;

            RootsFE_SO RootsSO = ScriptableObject.CreateInstance<RootsFE_SO>();
            RootsSO._FieldID = FieldID;
            RootsSO._EffectInfo = RootsInfo;
            Object = RootsSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(FieldID)) LoadedDBsHandler.StatusFieldDB.FieldEffects[FieldID] = RootsSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewFieldEffect(RootsSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("RootsIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
        public static void Clear() => IgnoreSet = new bool[5];
    }
    public class RootsFE_SO : FieldEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnSlotEffectorTriggerAttached(FieldEffect_Holder holder)
        {
            if (holder.Effector is CombatSlot slot && slot.HasUnit) Roots.IgnoreSet[holder.SlotID] = true;
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnFinished.ToString(), holder.Effector);
        }
        public override void OnSlotEffectorTriggerDettached(FieldEffect_Holder holder)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnFinished.ToString(), holder.Effector);
        }
        public override void OnTriggerAttached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
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
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, Roots.Trigger, caller);
        }
        public override void OnEventCall_01(FieldEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                CombatManager.Instance.AddSubAction(new RootsDamageAction(UnityEngine.Random.Range(2, 4), unit));
            }
        }
        public override void OnEventCall_02(FieldEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder);
        }
        public override void OnSubActionTrigger(FieldEffect_Holder holder, object sender, object args, bool stateCheck)
        {
            ReduceDuration(holder);
        }
    }
    public class RootsDamageAction : CombatAction
    {
        public int Amount;
        public IUnit Target;
        public RootsDamageAction(int amount, IUnit target)
        {
            Amount = amount;
            Target = target;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            int gruh = Target.Damage(UnityEngine.Random.Range(2, 4), null, DeathType_GameIDs.Basic.ToString(), -1, false, false, true, Roots.DamageType).damageAmount;
            CombatManager.Instance.AddSubAction(new RootsHealAction(gruh));
            CombatManager.Instance.PostNotification(Roots.Trigger, Target, null);
            yield return null;
        }
    }
    public class RootsHealAction : CombatAction
    {
        public int Amount;
        public RootsHealAction(int amount)
        {
            Amount = amount;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            foreach (CharacterCombat chara in stats.CharactersOnField.Values)
            {
                if (chara.ContainsStatusEffect(Photo.StatusID)) chara.Heal(Amount, null, true, CombatType_GameIDs.Heal_Linked.ToString());
            }
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.ContainsStatusEffect(Photo.StatusID)) enemy.Heal(Amount, null, true, CombatType_GameIDs.Heal_Linked.ToString());
            }
            yield return null;
        }
    }
    public class ApplyRootsSlotEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Field = Roots.Object;
            if (Roots.Object == null || Roots.Object.Equals(null)) Debug.LogError("CALL \"Roots.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class DistributeRootsEffect : EffectSO
    {
        static ApplyRootsSlotEffect effect;
        public static ApplyRootsSlotEffect Effect
        {
            get
            {
                if (effect == null)
                {
                    effect = ScriptableObject.CreateInstance<ApplyRootsSlotEffect>();
                }
                return effect;
            }
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int exit = 2 * base.PreviousExitValue;
            exitAmount = 0;
            float divide = targets.Length;
            int slots = (int)divide;
            float gap = exit;
            gap /= divide;
            int max = (int)Math.Ceiling(gap);
            int min = (int)Math.Floor(gap);
            foreach (TargetSlotInfo target in targets)
            {
                int amount = UnityEngine.Random.Range(min, max + 1);
                int final = Math.Min(amount, exit);
                Effect.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, final, out int ret);
                exit -= ret;
                exitAmount += ret;
                slots--;
                if (slots <= 0) break;
                divide = slots;
                gap = exit;
                gap /= divide;
                max = (int)Math.Ceiling(gap);
                min = (int)Math.Floor(gap);
            }
            return exitAmount > 0;
        }
    }
    public class IfRootsDamageEffect : EffectSO
    {
        static DamageEffect effect;
        public static DamageEffect Effect
        {
            get
            {
                if (effect == null)
                {
                    effect = ScriptableObject.CreateInstance<DamageEffect>();
                }
                return effect;
            }
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (stats.combatSlots.UnitInSlotContainsFieldEffect(target.SlotID, target.IsTargetCharacterSlot, Roots.FieldID))
                {
                    Effect.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exit);
                    exitAmount += exit;
                }
            }
            return exitAmount > 0;
        }
    }
    public static class Photo
    {
        public static string StatusID => "Photo_ID";
        public static string Intent => "Status_Photo";
        public static PhotoSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO PhotoInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            PhotoInfo.icon = ResourceLoader.LoadSprite("PhotoIcon.png");
            PhotoInfo._statusName = "Photosynthesis";
            PhotoInfo._description = "Multiply all healing received by the amount of Photosynthesis.";
            PhotoInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            PhotoInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            PhotoInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            PhotoSE_SO PhotoSO = ScriptableObject.CreateInstance<PhotoSE_SO>();
            PhotoSO._StatusID = StatusID;
            PhotoSO._EffectInfo = PhotoInfo;
            Object = PhotoSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = PhotoSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(PhotoSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("PhotoIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class PhotoSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingHealed.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingHealed.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            int Amount = holder.m_ContentMain + holder.Restrictor;
            if (args is HealingReceivedValueChangeException healIt && healIt.amount > 0)
            {
                healIt.AddModifier(new MultiplyIntValueModifier(false, Amount));
            }
        }
    }
    public class ApplyPhotoSynthesisEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Photo.Object;
            if (Photo.Object == null || Photo.Object.Equals(null)) Debug.LogError("CALL \"Photo.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
