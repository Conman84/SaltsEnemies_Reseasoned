using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class AnyOtherAllyDamagedHandler
    {
        public static TriggerCalls Trigger => (TriggerCalls)2479448;
        public static void Setup() => NotificationHook.AddAction(NotifCheck);
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnDirectDamaged.ToString() && sender is IUnit unit)
            {
                if (unit.IsUnitCharacter)
                {
                    foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                    {
                        if (chara.ID != unit.ID) chara.TriggerNotification(Trigger.ToString(), args);
                    }
                }
                else
                {
                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                    {
                        if (enemy.ID != unit.ID) enemy.TriggerNotification(Trigger.ToString(), args);
                    }
                }
            }
        }
    }

    public class VivariumConnectionEffect : EffectSO
    {
        public bool Connect;

        public void Function(object sender, object args)
        {
            //Debug.Log("hi");
            CombatManager.Instance.AddRootAction(new VivAction(sender as IUnit));
        }
        public class VivAction : CombatAction
        {
            public IUnit sender;
            public VivAction(IUnit sender)
            {
                this.sender = sender;
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                if (sender is EnemyCombat enemy)
                {
                    if (CombatManager.Instance._stats.IsPlayerTurn && enemy.TurnsInTimeline > 0)
                    {
                        CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(enemy.ID, enemy.IsUnitCharacter, "Active", 1));
                        yield break;
                    }

                    for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
                    {
                        if (stats.timeline.Round[i].isPlayer) continue;

                        if (stats.timeline.Round[i].turnUnit == enemy)
                        {
                            CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(enemy.ID, enemy.IsUnitCharacter, "Active", 1));
                            yield break;
                        }
                    }

                    CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(enemy.ID, enemy.IsUnitCharacter, "Active", 0));
                }
            }
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Connect)
            {
                CombatManager.Instance.AddObserver(Function, TriggerCalls.OnAbilityUsed.ToString(), caster);
                CombatManager.Instance.AddObserver(Function, TriggerCalls.OnRoundFinished.ToString(), caster);
                CombatManager.Instance.AddObserver(Function, TriggerCalls.OnPlayerTurnEnd_ForEnemy.ToString(), caster);
                CombatManager.Instance.AddObserver(Function, TriggerCalls.OnDamaged.ToString(), caster);
            }
            else
            {
                CombatManager.Instance.RemoveObserver(Function, TriggerCalls.OnAbilityUsed.ToString(), caster);
                CombatManager.Instance.RemoveObserver(Function, TriggerCalls.OnRoundFinished.ToString(), caster);
                CombatManager.Instance.RemoveObserver(Function, TriggerCalls.OnPlayerTurnEnd_ForEnemy.ToString(), caster);
                CombatManager.Instance.RemoveObserver(Function, TriggerCalls.OnDamaged.ToString(), caster);
            }
            return true;
        }

        public static VivariumConnectionEffect Create(bool connection)
        {
            VivariumConnectionEffect ret = ScriptableObject.CreateInstance<VivariumConnectionEffect>();
            ret.Connect = connection;
            return ret;
        }
    }

    public class ApplyDivineProtectionIfNoneEffect : ApplyDivineProtectionEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> pass = [];
            foreach (TargetSlotInfo target in targets)
            {
                if (!target.HasUnit || target.Unit.ContainsStatusEffect(StatusField_GameIDs.DivineProtection_ID.ToString())) continue;
                pass.Add(target);
            }

            base.PerformEffect(stats, caster, pass.ToArray(), areTargetSlots, entryVariable, out exitAmount);

            return pass.Count > 0;
        }
    }
    public class TargettingByHealthUnitsStatus : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = false;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public bool Lowest;

        public string Status;
        public bool shouldHave;

        public bool _randomOne;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            List<CombatSlot> opinion = new List<CombatSlot>();
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (slot.Unit.ContainsStatusEffect(Status) != shouldHave) continue;

                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.Unit.SlotID))
                    {
                        if (slot.Unit.ContainsStatusEffect(Status) != shouldHave) continue;

                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            foreach (CombatSlot slot in opinion)
            {
                targets.Add(slot.TargetSlotInformation);
            }

            if (_randomOne && targets.Count > 0) return [targets.GetRandom()];
            return targets.ToArray();
        }
    }

    public class DivineProtectAndExhaustEffectHardCoded : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    target.Unit.ApplyStatusEffect(StatusField.DivineProtection, entryVariable);
                    target.Unit.ExhaustAbilityUse();
                }

            }
            return true;
        }
    }
}
