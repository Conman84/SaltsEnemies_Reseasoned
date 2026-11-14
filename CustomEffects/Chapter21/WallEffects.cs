using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class WallConnectionEffect : EffectSO
    {
        public bool Connect;

        public static void RunEffect(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            if (caster.IsUnitCharacter || !caster.IsAlive) return;
            ManaColorSO mana = caster.HealthColor;
            CombatManager.Instance._stats.TryTransformEnemy(caster.ID, LoadedAssetsHandler.GetEnemy("Wall_2_EN"), false, false, true, false);
            if (caster.HealthColor != mana)
            {
                bool had = caster.TryRemovePassiveAbility(PassiveType_GameIDs.Pure.ToString());
                caster.ChangeHealthColor(mana);
                if (had) caster.AddPassiveAbility(Passives.Pure);
            }
            //if (CombatManager.Instance._stats.timeline.IsConfused) return;
            //CombatManager.Instance.AddUIAction(new FixCasterTImelineIntentsUIAction(caster));
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Connect) CombatManager.Instance.AddObserver(RunEffect, TriggerCalls.OnDamaged.ToString(), caster);
            else CombatManager.Instance.RemoveObserver(RunEffect, TriggerCalls.OnDamaged.ToString(), caster);
            return true;
        }

        public static WallConnectionEffect Create(bool connect)
        {
            WallConnectionEffect ret = ScriptableObject.CreateInstance<WallConnectionEffect>();
            ret.Connect = connect;
            return ret;
        }
    }
    public class WallDebuggerEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            Debug.Log("CASTER: " + caster.ID.ToString() + " ; " + caster.Name + " ; Field: " + caster.FieldID);

            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                Debug.Log("enemy: " + enemy.ID.ToString() + " ; " + enemy.Name + " ; Field: " + enemy.FieldID);

            foreach (EnemyCombatUIInfo info in stats.combatUI._enemiesInCombat.Values)
                Debug.Log("enemyUI: " + info.ID.ToString() + " ; " + info.Name + " ; Field: " + info.FieldID + " ; in slot: " + info.SlotID);

            for (int i = 0; i < stats.combatUI._enemyZone._enemies.Length; i++)
                if (stats.combatUI._enemyZone._enemies[i] != null && !stats.combatUI._enemyZone._enemies[i].Equals(null))
                {
                    if (stats.combatUI._enemyZone._enemies[i].FieldEntity != null && !stats.combatUI._enemyZone._enemies[i].FieldEntity.Equals(null))
                    {
                        Debug.Log("enemy layout fieldID: " + i.ToString() + " ; enemy layout enemyID: " + stats.combatUI._enemyZone._enemies[i].FieldEntity.EnemyID.ToString());
                    }
                    else
                        Debug.Log("null enemyfieldlayout for FieldID: " + i.ToString());
                }
                else
                    Debug.Log("null enemyinfolayout for FieldID: " + i.ToString());

            return true;
        }
    }
    public class IsOnlyEnemyEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return CombatManager.Instance._stats.EnemiesOnField.Count > 1;
        }
    }

    public class WallAwakenCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (UnityEngine.Random.Range(0, 100) < 8) return true;

            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                if (enemy.EntityID != "Wall_EN" && enemy.EntityID != "33_EN")
                {
                    if (enemy.ContainsPassiveAbility(PassiveType_GameIDs.Withering.ToString()) || enemy.ContainsPassiveAbility(PassiveType_GameIDs.Infantile.ToString()) || enemy.CurrentHealth <= 6 && UnityEngine.Random.Range(0, 100) < 67) continue;

                    return false;
                }
            }

            if (caster.EntityID == "33_EN") return UnityEngine.Random.Range(0, 100) < 35;

            return UnityEngine.Random.Range(0, 100) < 60;
        }
    }
}
