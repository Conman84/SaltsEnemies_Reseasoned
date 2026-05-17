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

namespace SaltsEnemies_Reseasoned
{
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
}
