﻿using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class RightMostCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return effector.SlotID == 5 - (effector as IUnit).Size;
        }
    }
    public class LeftMostCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return effector.SlotID == 0;
        }
    }
    public class HasUnitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets) if (target.HasUnit) exitAmount++;
            return exitAmount > 0;
        }
    }
    public class MoveCasterByLastExitEffect : SwapToOneSideEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = PreviousExitValue;
            for (int i = 0; i < exitAmount; i++) base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, entryVariable, out exitAmount);
            return exitAmount > 0;
        }
    }
    public class KillIfBelowPercentEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    float calc = (float)target.Unit.CurrentHealth / target.Unit.MaximumHealth;
                    if (calc * 100 < entryVariable)
                    {
                        exitAmount++;
                        target.Unit.DirectDeath(caster);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class FixCasterTimelineIntentsEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter || !caster.IsAlive) return false;
            if (stats.timeline.IsConfused) return false;
            CombatManager.Instance.AddUIAction(new FixCasterTImelineIntentsUIAction(caster));
            return true;
        }
    }
    public class FixCasterTImelineIntentsUIAction : CombatAction
    {
        public IUnit caster;
        public FixCasterTImelineIntentsUIAction(IUnit _caster)
        {
            caster = _caster;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            for (int i = 0; i < stats.combatUI._TimelineHandler.TimelineSlotInfo.Count; i++)
            {
                TimelineInfo timeline = stats.combatUI._TimelineHandler.TimelineSlotInfo[i];
                if (timeline.isSecret) continue;
                if (timeline.enemyID == caster.ID)
                {
                    timeline.timelineIcon = (caster as EnemyCombat).Enemy.enemySprite;
                    foreach (TimelineSlotGroup slotgroup in stats.combatUI._timeline._slotsInUse)
                    {
                        if (slotgroup.slot.TimelineSlotID == i)
                        {
                            if (slotgroup.slot.TimelineSlotID <= stats.timeline.CurrentTurn) break;

                            Sprite[] intents = null;
                            Color[] spriteColors = null;
                            bool cansee = timeline.timelineIcon != null && !timeline.timelineIcon.Equals(null);
                            if (cansee) intents = stats.combatUI._timeline.IntentHandler.GenerateSpritesFromAbility(timeline.ability, casterIsCharacter: false, out spriteColors);
                            slotgroup.SetInformation(slotgroup.slot.TimelineSlotID, cansee ? timeline.timelineIcon : stats.combatUI._timeline._blindTimelineIcon, true, intents, spriteColors);
                        }
                    }
                }
            }
            yield return null;
        }

    }
    public class CasterTransformByStringEffect : CasterTransformationEffect
    {
        public string enemy;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (!caster.IsUnitCharacter) _enemyTransformation = LoadedAssetsHandler.GetEnemy(enemy);
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class StarlessPassiveAbility : PerformEffectPassiveAbility
    {
        public static TriggerCalls Call => (TriggerCalls)38431355;
        public override bool IsPassiveImmediate => true;
        public override void TriggerPassive(object sender, object args)
        {
            if (!(args is TurnFinishedReference))
            {
                CombatManager.Instance.AddRootAction(new EffectAction(new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                }, sender as IUnit));
                return;
            }
            IUnit caster = sender as IUnit;
            CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(effects, caster));
        }
        public override void OnPassiveConnected(IUnit unit)
        {
            base.OnPassiveConnected(unit);
            if (unit.SlotID + unit.Size < 5) return;
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[]
            {
                Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
            }, unit));
        }
        public static void NotifCheck(string call, object sender, object args)
        {
            if (call == TriggerCalls.TimelineEndReached.ToString() && sender == null)
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values) CombatManager.Instance.PostNotification(Call.ToString(), enemy, new TurnFinishedReference(false));
            }
        }
        static bool Set;
        public static void Setup()
        {
            if (Set) return;
            Set = true;
            NotificationHook.AddAction(NotifCheck);
        }
    }
    public class StarlessPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "All-Seeing", ResourceLoader.LoadSprite("AllSeeingPassive.png")));
            exitAmount = 0;
            return true;
        }
    }
    public class SetMusicParameterByStringEffect : EffectSO
    {
        public static Dictionary<string, int> Params;
        public string Parameter;

        public static void Trigger(string parameter, int amount)
        {
            if (Params == null) Params = new Dictionary<string, int>();
            if (!Params.ContainsKey(parameter)) Params.Add(parameter, amount);
            else Params[parameter] += amount;
            CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName(parameter, Params[parameter] > 0 ? 1 : 0);
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            Trigger(Parameter, entryVariable);
            exitAmount = 0; return true;
        }
        public static SetMusicParameterByStringEffect Create(string parameter)
        {
            SetMusicParameterByStringEffect ret = ScriptableObject.CreateInstance<SetMusicParameterByStringEffect>();
            ret.Parameter = parameter;
            return ret;
        }
    }
    public class AbilitySelector_Starless : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string _stagger = "";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int num = 0;
            int num2 = 0;
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            bool hasntLeft = !unit.ContainsStatusEffect(Left.StatusID);
            for (int i = 0; i < abilities.Count; i++)
            {
                if (ShouldBeIgnored(abilities[i], hasntLeft))
                {
                    num2 += abilities[i].rarity.rarityValue;
                    list2.Add(i);
                }
                else
                {
                    num += abilities[i].rarity.rarityValue;
                    list.Add(i);
                }
            }

            int num3 = UnityEngine.Random.Range(0, num);
            num = 0;
            foreach (int item in list)
            {
                num += abilities[item].rarity.rarityValue;
                if (num3 < num)
                {
                    return item;
                }
            }

            num3 = UnityEngine.Random.Range(0, num2);
            num2 = 0;
            foreach (int item2 in list2)
            {
                num2 += abilities[item2].rarity.rarityValue;
                if (num3 < num2)
                {
                    return item2;
                }
            }

            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, bool hasntLeft)
        {
            string text = ability.ability.name;
            if (hasntLeft || text != _stagger)
            {
                return false;
            }

            //Debug.Log("starless: should be ignored");
            return true;
        }
    }
    public class AbilitySelector_Eyeless : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string _killAbility = "";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int num = 0;
            int num2 = 0;
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < abilities.Count; i++)
            {
                if (ShouldBeIgnored(abilities[i]))
                {
                    num2 += abilities[i].rarity.rarityValue;
                    list2.Add(i);
                }
                else
                {
                    num += abilities[i].rarity.rarityValue;
                    list.Add(i);
                }
            }

            int num3 = UnityEngine.Random.Range(0, num);
            num = 0;
            foreach (int item in list)
            {
                num += abilities[item].rarity.rarityValue;
                if (num3 < num)
                {
                    return item;
                }
            }

            num3 = UnityEngine.Random.Range(0, num2);
            num2 = 0;
            foreach (int item2 in list2)
            {
                num2 += abilities[item2].rarity.rarityValue;
                if (num3 < num2)
                {
                    return item2;
                }
            }

            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability)
        {
            if (ability.ability.name != _killAbility)
            {
                return false;
            }

            foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if ((float)chara.CurrentHealth / (float)chara.MaximumHealth < 0.5f) return false;
            }
            //Debug.Log("eyeless: should be ignored");
            return true;
        }
    }
    public class EyelessEnterEffect : SwapToOneSideEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.SlotID > 0) return false;
            for (int i = 0; i < 5; i++)
            {
                _swapRight = true;
                if (base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, entryVariable, out int exi)) exitAmount++;
            }
            return exitAmount > 0;
        }
    }
}
