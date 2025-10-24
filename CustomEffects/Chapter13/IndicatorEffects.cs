using BrutalAPI;
using DG.Tweening;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tools;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.UI.CanvasScaler;

namespace SaltEnemies_Reseasoned
{
    public class LinkedDamageEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.ContainsStatusEffect(StatusField_GameIDs.Linked_ID.ToString())) caster.Damage(entryVariable, null, DeathType_GameIDs.Linked.ToString(), -1, false, false, true, CombatType_GameIDs.Dmg_Linked.ToString());
            CombatManager.Instance.AddSubAction(new PerformLinkedEffectAction(caster, new IntegerReference(entryVariable), true, StatusField.Linked.StatusID, LoadedDBsHandler.CombatDB.TryGetSoundEventName(CombatType_GameIDs.Dmg_Linked.ToString())));
            return true;
        }
    }
    public class EmptyEnemySpaceNoWitheringEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.ContainsPassiveAbility(PassiveType_GameIDs.Withering.ToString())) return false;
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots) if (!slot.HasUnit) return true;
            return false;
        }
    }
    public class SwapToRandomZoneFoolEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int num = UnityEngine.Random.Range(0, 5);
                    if (num == targetSlotInfo.SlotID)
                    {
                        if (num <= 0) num++;
                        else if (num >= 4) num--;
                        else if (UnityEngine.Random.Range(0f, 1f) < 0.5f) num++;
                        else num--;
                    }
                    stats.combatSlots.SwapCharacters(targetSlotInfo.SlotID, num, isMandatory: true);
                }
            }
            return exitAmount > 0;
        }
    }
    public class SpasmEffect : AddTurnTargetToTimelineEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            List<EnemyCombat> enemies = new List<EnemyCombat>();
            List<int> abilities = new List<int>();

            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                int num = 1;
                //if (UnityEngine.Random.Range(0f, 1f) < 0.25f) num++;

                for (int i = 0; i < num; i++)
                {
                    enemies.Add(enemy);
                    abilities.Add(enemy.GetSingleAbilitySlotUsage(-1));
                }
            }

            stats.timeline.AddExtraEnemyTurns(enemies, abilities);

            exitAmount = abilities.Count;

            return exitAmount > 0;
        }
    }
    public class LivingTargetForceFirstActionEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (!target.HasUnit) continue;

                if (!Passives.Slippery.conditions[0].MeetCondition(target.Unit as IEffectorChecks, null)) continue;

                if (target.Unit is EnemyCombat enemy)
                {
                    if (enemy.TurnsInTimeline <= 0) continue;

                    for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
                    {
                        if (stats.timeline.Round[i].isPlayer) continue;

                        if (stats.timeline.Round[i].turnUnit == enemy)
                        {
                            enemy.SimpleSetStoredValue("BlueSky_ForcedTurn_A", 1);

                            CombatManager.Instance.AddRootAction(new EnemyCombatRemoveFirstTurnAction(enemy));

                            EnemyPerformAbility(enemy, stats.timeline.Round[i].abilitySlot);

                            //stats.timeline.Round.RemoveAt(i);
                            //enemy.TurnsInTimeline--;

                            //CombatManager.Instance.AddUIAction(new RemoveSlotTimelineUIAction([i]));
                            //CombatManager.Instance.AddUIAction(new UpdateTimelinePointerUIAction(stats.timeline.CurrentTurn));

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
            CombatManager.Instance.AddRootAction(new CustomEndAbilityAction(self.ID, self.IsUnitCharacter));
            CombatManager.Instance.AddRootAction(new ForceTurnCleanupAction(self));
        }
    }
    public class EnemyCombatRemoveFirstTurnAction : CombatAction
    {
        public EnemyCombat Enemy;
        public EnemyCombatRemoveFirstTurnAction(EnemyCombat enemy)
        {
            Enemy = enemy;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (Enemy.TurnsInTimeline <= 0) yield break;

            for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
            {
                if (stats.timeline.Round[i].isPlayer) continue;

                if (stats.timeline.Round[i].turnUnit == Enemy)
                {
                    stats.timeline.Round.RemoveAt(i);
                    Enemy.TurnsInTimeline--;

                    CombatManager.Instance.AddUIAction(new RemoveSlotTimelineUIAction([i]));
                    CombatManager.Instance.AddUIAction(new UpdateTimelinePointerUIAction(stats.timeline.CurrentTurn));

                    break;
                }
            }

            yield return null;
        }
    }
    public class EnemyHighlightAction : CombatAction
    {
        public EnemyCombat Enemy;
        public bool On;
        public EnemyHighlightAction(EnemyCombat enemy, bool on)
        {
            Enemy = enemy;
            On = on;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (CombatManager.Instance._combatUI._enemiesInCombat.TryGetValue(Enemy.ID, out var value))
            {
                if (CombatManager.Instance._combatUI._enemyZone._enemies.Length > value.FieldID)
                {
                    EnemyInFieldLayout field = CombatManager.Instance._combatUI._enemyZone._enemies[value.FieldID].FieldEntity;
                }
            }
            yield return null;
        }
    }
}
