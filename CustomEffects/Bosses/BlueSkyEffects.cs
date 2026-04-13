using BrutalAPI;
using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tools;
using UnityEngine;
using Yarn;
using static UnityEngine.GraphicsBuffer;

namespace SaltsEnemies_Reseasoned
{
    public class TargetForceFirstActionEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (!target.HasUnit) continue;

                if (target.Unit is EnemyCombat enemy)
                {
                    if (enemy.TurnsInTimeline <= 0) continue;

                    for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
                    {
                        if (stats.timeline.Round[i].isPlayer) continue;

                        if (stats.timeline.Round[i].turnUnit == enemy)
                        {
                            enemy.SimpleSetStoredValue("BlueSky_ForcedTurn_A", 1);
                            EnemyPerformAbility(enemy, stats.timeline.Round[i].abilitySlot);

                            stats.timeline.Round.RemoveAt(i);
                            enemy.TurnsInTimeline--;

                            CombatManager.Instance.AddUIAction(new RemoveSlotTimelineUIAction([i]));
                            CombatManager.Instance.AddUIAction(new UpdateTimelinePointerUIAction(stats.timeline.CurrentTurn));

                            exitAmount++;

                            break;
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
        public void EnemyPerformAbility(EnemyCombat self, int abilitySlot)
        {
            self.TriggerNotification(TriggerCalls.OnTurnStart.ToString(), null);

            if (abilitySlot < 0 || abilitySlot >= self.Abilities.Count)
            {
                Debug.LogError(self.Name + " cannot use ability in slot " + abilitySlot + ", it does not exist");
                CombatManager.Instance.AddRootAction(new EnemyTurnEndAction(self.ID));
                return;
            }

            AbilitySO ability = self.Abilities[abilitySlot].ability;
            if (!self.CanUseAbility)
            {
                Debug.LogError(self.Name + " cannot use " + ability.GetAbilityLocData().text + " probably due to stunned");
                CombatManager.Instance.AddRootAction(new EnemyTurnEndAction(self.ID));
                return;
            }

            if (self.ContainsStatusEffect("Muted_ID"))
            {
                Debug.Log("is muted");
                if (!ability._abilityName.ToLower().Contains("slap"))
                {
                    Debug.Log("used not slap");
                    ability = LoadedAssetsHandler.GetCharacterAbility("Slap_A");

                    Vector3 loc = default(Vector3);
                    CombatStats stats = CombatManager.Instance._stats;
                    try
                    {
                        if (!self.IsUnitCharacter)
                        {
                            loc = stats.combatUI._enemyZone._enemies[self.FieldID].FieldEntity.Position;
                        }
                    }
                    catch { }

                    CombatManager.Instance.AddRootAction(new UIActionAction(new PlaySoundUIAction("event:/Hawthorne/Boowomp", loc)));
                }
            }

            StringReference args = new StringReference(ability.name);
            CombatManager.Instance.PostNotification(TriggerCalls.OnAbilityWillBeUsed.ToString(), self, args);

            if (!DebugUtils.videoMode)
            {
                CombatManager.Instance.AddRootAction(new UIActionAction(new ShowAttackInformationUIAction(self.ID, self.IsUnitCharacter, ability.GetAbilityLocData().text)));
            }
            CombatManager.Instance.AddRootAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, self));
            CombatManager.Instance.AddRootAction(new EffectAction(ability.effects, self));
            CombatManager.Instance.AddRootAction(new CustomEndAbilityAction(self.ID, self.IsUnitCharacter, ability));
            CombatManager.Instance.AddRootAction(new ForceTurnCleanupAction(self));
        }
    }

    public class CustomEndAbilityAction : CombatAction
    {
        public int _unitID;

        public bool _isUnitCharacter;

        public AbilitySO _ability;

        public CustomEndAbilityAction(int unitID, bool isUnitCharacter, AbilitySO ability)
        {
            _unitID = unitID;
            _isUnitCharacter = isUnitCharacter;
            _ability = ability;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (_isUnitCharacter)
            {
                CharacterCombat characterCombat = stats.TryGetCharacterOnField(_unitID);
                if (characterCombat != null)
                {
                    if (characterCombat.IsAlive)
                    {
                        characterCombat.AbilityHasFinished();
                    }

                    characterCombat.FinalizeAbilityActions();
                }
            }
            else
            {
                EnemyCombat enemyCombat = stats.TryGetEnemyOnField(_unitID);
                if (enemyCombat != null && enemyCombat.IsAlive)
                {
                    CombatManager.Instance.PostNotification(TriggerCalls.OnAbilityUsed.ToString(), enemyCombat, null);
                    CombatManager.Instance.AddRootAction(new EnemyTurnEndAction(enemyCombat.ID));
                }
            }

            foreach (CharacterCombat value in stats.CharactersOnField.Values)
            {
                Help.AnyAbilityHasFinished(value, _unitID, _isUnitCharacter, _ability);
            }

            foreach (EnemyCombat value2 in stats.EnemiesOnField.Values)
            {
                Help.AnyAbilityHasFinished(value2, _unitID, _isUnitCharacter, _ability);
            }

            yield return null;
        }
    }
    public class ForceTurnCleanupAction : CombatAction
    {
        public IUnit Unit;
        public ForceTurnCleanupAction(IUnit unit)
        {
            Unit = unit;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (Unit == null) yield break;
            Unit.SimpleSetStoredValue("BlueSky_ForcedTurn_A", 0);
            yield return null;
        }
    }

    public static class ForcedTurnHandler
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyDeathAction).GetMethod(nameof(EnemyDeathAction.Execute), ~BindingFlags.Default), typeof(ForcedTurnHandler).GetMethod(nameof(EnemyDeathAction_Execute), ~BindingFlags.Default));
        }
        public static IEnumerator EnemyDeathAction_Execute(Func<EnemyDeathAction, CombatStats, IEnumerator> orig, EnemyDeathAction self, CombatStats stats)
        {
            EnemyCombat enemy = stats.TryGetEnemyOnField(self._enemyID);
            if (enemy != null && enemy.SimpleGetStoredValue("BlueSky_ForcedTurn_A") > 0)
            {
                enemy.SimpleSetStoredValue("BlueSky_ForcedTurn_A", 0);
                CombatManager.Instance.AddRootAction(self);
                yield return null;
            }
            else yield return orig(self, stats);
        }
    }

    public class ChangeTargetHealthColorEffect : EffectSO
    {
        public ManaColorSO mana;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && !target.Unit.HealthColor.SharesPigmentColor(mana))
                {
                    if (target.Unit.ChangeHealthColor(mana)) exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class TargetIsHealthColorEffect : EffectSO
    {
        public ManaColorSO mana;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.HealthColor.SharesPigmentColor(mana)) exitAmount++;
            }
            return exitAmount > 0;
        }
    }
    public class IsTargetIsHealthColorEffect : EffectSO
    {
        public ManaColorSO mana;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.HealthColor.SharesPigmentColor(mana)) exitAmount++;
                else if (!target.HasUnit) exitAmount++;
            }
            return exitAmount > 0;
        }
    }
    public class RandomizeTargetHealthColorNormalEffect : EffectSO
    {
        public ManaColorSO[] mana;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.ChangeHealthColor(mana.GetRandom())) exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class RedSkyDecayCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                int amount = 0;
                foreach (IStatusEffect status in (unit as IStatusEffector).StatusEffects)
                {
                    if (status.StatusID == Power.StatusID) amount = status.StatusContent;
                }
                SpawnEnemyWithPowerEffect e = SpawnEnemyWithPowerEffect.Create("RedSky_BOSS", amount, true);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowDecayInfoEffect>(), 1, Slots.Self), Effects.GenerateEffect(e, 0, Slots.Self) }, unit));
                return false;
            }
            return true;
        }
    }

    public class HasTurnsCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is EnemyCombat enemy)
            {
                if (CombatManager.Instance._stats.IsPlayerTurn) return enemy.TurnsInTimeline > 0;

                CombatStats stats = CombatManager.Instance._stats;
                for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
                {
                    if (stats.timeline.Round[i].isPlayer) continue;

                    if (stats.timeline.Round[i].turnUnit == enemy)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
