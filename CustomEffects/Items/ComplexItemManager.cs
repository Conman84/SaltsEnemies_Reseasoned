using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class AdvancedDamageTrigger
    {
        public static TriggerCalls Dealt => (TriggerCalls)3917894;
        public static TriggerCalls Received => (TriggerCalls)2329951;

        public static void PostTrigger(AdvancedDamageTempInfo info, object sender, object args)
        {
            if (sender is IUnit target && args is IntegerReference reference)
            {
                AdvancedDamageInfo ret = new AdvancedDamageInfo(reference.value, target, info.Direct, info.Attacker, info.Type);

                CombatManager.Instance.PostNotification(Received.ToString(), target, ret);

                if (info.Attacker != null) CombatManager.Instance.PostNotification(Dealt.ToString(), info.Attacker, ret);
            }
        }
        public static void PostTrigger(bool direct, object sender, object args)
        {
            if (sender is IUnit target && args is IntegerReference reference)
            {
                AdvancedDamageInfo ret = new AdvancedDamageInfo(reference.value, target, direct, null, "");

                CombatManager.Instance.PostNotification(Received.ToString(), target, ret);
            }
        }
    }

    public class AdvancedDamageInfo : IntegerReference
    {
        public readonly string Type;
        public readonly bool Direct;

        public readonly IUnit Killer;
        public readonly IUnit Target;

        public AdvancedDamageInfo(int amount, IUnit target, bool direct, IUnit killer, string type) : base(amount)
        {
            Type = type;
            Direct = direct;
            Killer = killer;
            Target = target;
        }
    }
    public static class CascadingDamageItemHandler
    {
        public static TriggerCalls Call => (TriggerCalls)94727170;
        public static List<AdvancedDamageTempInfo> InfoList;
        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck);
        }
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnBeingDamaged.ToString())
            {
                if (InfoList == null) InfoList = new List<AdvancedDamageTempInfo>();

                if (args is DamageReceivedValueChangeException reference)
                {
                    for (int i = InfoList.Count - 1; i >= 0; i--)
                        if (InfoList[i].Target == sender) InfoList.RemoveAt(i);

                    InfoList.Add(new AdvancedDamageTempInfo(reference.possibleSourceUnit, reference.damagedUnit, reference.directDamage, reference.damageTypeID));
                }
            }

            if (name == TriggerCalls.OnDirectDamaged.ToString())
            {
                if (InfoList == null) InfoList = new List<AdvancedDamageTempInfo>();

                for (int i = 0; i < InfoList.Count; i++)
                {
                    if (InfoList[i].Target == sender && InfoList[i].Direct)
                    {
                        AdvancedDamageTempInfo info = InfoList[i];
                        InfoList.RemoveAt(i);
                        AdvancedDamageTrigger.PostTrigger(info, sender, args);

                        if (info.Attacker == null) return;

                        CascadeSpecialBooleanReference check = new CascadeSpecialBooleanReference(false, info);
                        CombatManager.Instance.PostNotification(Call.ToString(), info.Attacker, check);
                        if (!check.value) return;

                        if (args is IntegerReference reference)
                        {
                            RunCascade(sender as IUnit, reference.value);
                        }

                        return;
                    }
                }
                AdvancedDamageTrigger.PostTrigger(true, sender, args);
            }
            if (name == TriggerCalls.OnIndirectDamaged.ToString())
            {
                if (InfoList == null) InfoList = new List<AdvancedDamageTempInfo>();

                for (int i = 0; i < InfoList.Count; i++)
                {
                    if (InfoList[i].Target == sender && !InfoList[i].Direct)
                    {
                        AdvancedDamageTempInfo info = InfoList[i];
                        InfoList.RemoveAt(i);
                        AdvancedDamageTrigger.PostTrigger(info, sender, args);

                        if (info.Attacker == null) return;

                        CascadeSpecialBooleanReference check = new CascadeSpecialBooleanReference(false, info);
                        CombatManager.Instance.PostNotification(Call.ToString(), info.Attacker, check);
                        if (!check.value) return;

                        if (args is IntegerReference reference)
                        {
                            RunCascade(sender as IUnit, reference.value);
                        }

                        return;
                    }
                }
                AdvancedDamageTrigger.PostTrigger(false, sender, args);
            }
        }

        public static void RunCascade(IUnit origin, int start)
        {
            SlotsCombat slots = CombatManager.Instance._stats.combatSlots;

            int left = origin.SlotID - 1;
            int right = origin.SlotID + origin.Size;

            for (int current = (int)Math.Floor((float)start / 2); current > 0; current = (int)Math.Floor((float)current / 2))
            {
                if (left >= 0 && left < 5)
                {
                    if (origin.IsUnitCharacter)
                    {
                        if (slots.CharacterSlots[left].HasUnit)
                        {
                            slots.CharacterSlots[left].Unit.Damage(current, null, "Basic", slots.CharacterSlots[left].SlotID - slots.CharacterSlots[left].Unit.SlotID, false, false, true);
                            left--;
                        }
                        else left = -1;
                    }
                    else
                    {
                        if (slots.EnemySlots[left].HasUnit)
                        {
                            slots.EnemySlots[left].Unit.Damage(current, null, "Basic", slots.EnemySlots[left].SlotID - slots.EnemySlots[left].Unit.SlotID, false, false, true);
                            left--;
                        }
                        else left = -1;
                    }
                }
                if (right >= 0 && right < 5)
                {
                    if (origin.IsUnitCharacter)
                    {
                        if (slots.CharacterSlots[right].HasUnit)
                        {
                            slots.CharacterSlots[right].Unit.Damage(current, null, "Basic", slots.CharacterSlots[right].SlotID - slots.CharacterSlots[right].Unit.SlotID, false, false, true);
                            right++;
                        }
                        else right = -1;
                    }
                    else
                    {
                        if (slots.EnemySlots[right].HasUnit)
                        {
                            slots.EnemySlots[right].Unit.Damage(current, null, "Basic", slots.EnemySlots[right].SlotID - slots.EnemySlots[right].Unit.SlotID, false, false, true);
                            right++;
                        }
                        else right = -1;
                    }
                }

                if ((left < 0 || left >= 5) && (right < 0 || right >= 5)) break;
            }
        }
    }

    public struct AdvancedDamageTempInfo
    {
        public IUnit Attacker;
        public IUnit Target;
        public bool Direct;
        public string Type;
        public AdvancedDamageTempInfo(IUnit attacker, IUnit target, bool direct, string type = "")
        {
            Attacker = attacker;
            Target = target;
            Direct = direct;
            Type = type;
        }
    }
    public class CascadeSpecialBooleanReference : BooleanReference
    {
        public AdvancedDamageTempInfo Info;
        public CascadeSpecialBooleanReference(bool entryValue, AdvancedDamageTempInfo info) : base(entryValue)
        {
            Info = info;
        }
    }

    public class DamageTargetEffectsCondition : EffectorConditionSO
    {
        public EffectInfo[] Effects;
        public bool ShowItem;

        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is AdvancedDamageInfo info)
            {
                CombatManager.Instance.AddSubAction(new DamageTargetEffectsConditionAction(info.Target, effector as IUnit, Effects, ShowItem));
            }
            return true;
        }

        public static DamageTargetEffectsCondition Create(EffectInfo[] effects, bool showitem)
        {
            DamageTargetEffectsCondition ret = ScriptableObject.CreateInstance<DamageTargetEffectsCondition>();
            ret.Effects = effects;
            ret.ShowItem = showitem;
            return ret;
        }
    }

    public class DamageTargetEffectsConditionAction : CombatAction
    {
        public IUnit Caster;
        public IUnit Target;
        public bool ShowItem;
        public EffectInfo[] Effects;
        public DamageTargetEffectsConditionAction(IUnit target, IUnit caster, EffectInfo[] effects, bool showItem = false)
        {
            Caster = caster;
            Target = target;
            Effects = effects != null ? effects : [];
            ShowItem = showItem;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (ShowItem && Caster != null) Caster.ShowItem();
            return new EffectAction(Effects, Target).Execute(stats);
        }
    }
}
