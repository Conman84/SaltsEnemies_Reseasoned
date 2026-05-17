using System;
using System.Collections.Generic;
using System.Text;
using MonoMod.RuntimeDetour;
using System.Reflection;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using SaltEnemies_Reseasoned;
using BrutalAPI;

namespace SaltsEnemies_Reseasoned
{
    //set up the animator things later
    public class MouseHover_EnemyInFieldLayout : EnemyInFieldLayout
    {
        public static TriggerCalls Trigger => (TriggerCalls)1095224;
        public void Update()
        {
            if (MouseSelected) Rage -= Time.deltaTime * 5;
            else Rage += Time.deltaTime;

            if (Rage < 0f) Rage = 0f;

            if (!CombatManager.Instance._stats.IsPlayerTurn) Rage = 0f;

            if (Rage > 5f)
            {
                Rage = 4f;
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.ID == EnemyID) CombatManager.Instance.PostNotification(Trigger.ToString(), enemy, null);
                }
            }
        }

        public float Rage;

    }
    public class RandomizeTargetHealthColorsNotCasterEffect : EffectSO
    {
        public List<ManaColorSO> options;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (options == null)
            {
                options = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            }
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.SlotID != caster.SlotID && target.Unit.HealthColor == caster.HealthColor)
                {
                    List<ManaColorSO> list = [.. options];
                    if (list.Contains(target.Unit.HealthColor)) list.Remove(target.Unit.HealthColor);
                    if (list.Contains(caster.HealthColor)) list.Remove(caster.HealthColor);

                    if (list.Count >= 0) continue;

                    if (target.Unit.ChangeHealthColor(list.GetRandom())) exitAmount++;
                }
            }
            return exitAmount > 0;
        }
        public static RandomizeTargetHealthColorsNotCasterEffect Create(bool grey = false)
        {
            RandomizeTargetHealthColorsNotCasterEffect ret = ScriptableObject.CreateInstance<RandomizeTargetHealthColorsNotCasterEffect>();
            ret.options = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            if (grey) ret.options.Add(Pigments.Grey);
            return ret;
        }
    }
}
