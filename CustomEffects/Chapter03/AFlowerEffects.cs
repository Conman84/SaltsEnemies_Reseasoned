using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class IfConstrictingAnimationVisualsEffect : EffectSO
    {
        [Header("Visual")]
        [SerializeField]
        public AttackVisualsSO _visuals;

        [SerializeField]
        public BaseCombatTargettingSO _animationTarget;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (!(stats.combatSlots.UnitInSlotContainsFieldEffect(caster.SlotID, true, StatusField_GameIDs.Constricted_ID.ToString())))
            {
                exitAmount = 0;
                return false;
            }
            CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(_visuals, _animationTarget, caster));
            exitAmount = 0;
            return true;
        }
    }
    public class DamageIfConstrictedEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (stats.combatSlots.UnitInSlotContainsFieldEffect(target.SlotID, target.IsTargetCharacterSlot, StatusField_GameIDs.Constricted_ID.ToString()))
                    if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exited)) exitAmount += exited;
            }

            return exitAmount > 0;
        }
    }
    public class ResetFleetingEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            caster.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.FleetingPA.ToString(), 0);
            caster.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.FleetingPA_IgnoreFirstTurn.ToString(), 0);
            exitAmount = 0;
            return true;
        }
    }
    public class IfTargetApplyConstrictedSlotEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            _Field = StatusField.Constricted;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                    if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exited)) exitAmount += exited;
            }

            return exitAmount > 0;
        }
    }

    public static class AnglerHandler
    {
        public static bool Awaken;
        public static string value => "SaltEnemies_Angler_Music";
        public static void Check()
        {
            bool newAwake = false;
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots)
            {
                if (slot.HasUnit && slot.Unit.CurrentHealth > 0 && slot.Unit is EnemyCombat enemy && enemy.Enemy == LoadedAssetsHandler.GetEnemy("AFlower_EN"))
                {
                    bool Personal = false;
                    foreach (CombatSlot plot in CombatManager.Instance._stats.combatSlots.CharacterSlots)
                    {
                        if (plot.SlotID == slot.SlotID)
                        {
                            if (plot.ContainsFieldEffect(StatusField_GameIDs.Constricted_ID.ToString()) && plot.HasUnit && plot.Unit.CurrentHealth > 0)
                            {
                                newAwake = true;
                                Personal = true;
                            }
                            break;
                        }
                    }
                    if (Personal)
                    {
                        if (enemy.SimpleGetStoredValue(value) == 0)
                        {
                            CombatManager.Instance._stats.combatUI.TrySetEnemyAnimatorParameter(enemy.ID, "HasFacing", 1);
                            TrySpawnSandEffect(CombatManager.Instance._stats.combatUI, enemy.ID);
                        }
                        enemy.SimpleSetStoredValue(value, 1);
                    }
                    else
                    {
                        if (enemy.SimpleGetStoredValue(value) != 0)
                        {
                            CombatManager.Instance._stats.combatUI.TrySetEnemyAnimatorParameter(enemy.ID, "HasFacing", 0);
                            TrySpawnSandEffect(CombatManager.Instance._stats.combatUI, enemy.ID);
                        }
                        enemy.SimpleSetStoredValue(value, 0);
                    }
                }
            }
            if (newAwake != Awaken)
            {
                Awaken = newAwake;
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("HasFront", Awaken ? 1 : 0);
            }
        }
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (notificationName == TriggerCalls.OnMoved.ToString() || notificationName == TriggerCalls.OnDeath.ToString() || notificationName == TriggerCalls.OnFleetingEnd.ToString() || notificationName == TriggerCalls.OnFieldEffectApplied.ToString()) Check();
        }
        public static void TrySpawnSandEffect(CombatVisualizationController UI, int id)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID);
            }
        }
        public static void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity);
        }
        public static void SpawnEffect(EnemyInFieldLayout field)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(Sand, field.transform.position, field.transform.rotation);
        }
        static ParticleSystem _sand;
        public static ParticleSystem Sand
        {
            get
            {
                if (_sand == null)
                {
                    //Debug.LogError("AnglerHandler: make sure this is getting the right assetbundle");
                    _sand = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/Senis3/0FuckFolder/Sand.prefab").GetComponent<ParticleSystem>();
                }
                return _sand;
            }
        }
        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck, true);
        }
    }
    public class ChangeAnglerMusicUIAction : CombatAction
    {
        public bool Awake;
        public ChangeAnglerMusicUIAction(bool awake)
        {
            Awake = awake;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("HasFront", Awake ? 1 : 0);
            yield return null;
        }
    }
    public class SetAnglerAnimationParameterUIAction : CombatAction
    {
        public int _id;

        public bool _isCharacter;

        public string _parameterName;

        public int _parameterValue;

        public SetAnglerAnimationParameterUIAction(int id, bool isCharacter, string parameterName, int parameterValue)
        {
            _id = id;
            _isCharacter = isCharacter;
            _parameterName = parameterName;
            _parameterValue = parameterValue;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (_isCharacter)
            {
                stats.combatUI.TrySetCharacterAnimatorParameter(_id, _parameterName, _parameterValue);
            }
            else
            {
                stats.combatUI.TrySetEnemyAnimatorParameter(_id, _parameterName, _parameterValue);
                AnglerHandler.TrySpawnSandEffect(stats.combatUI, _id);
            }

            yield break;
        }
    }
    public class AnglerCheckEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            AnglerHandler.Check();
            return true;
        }
    }
}
