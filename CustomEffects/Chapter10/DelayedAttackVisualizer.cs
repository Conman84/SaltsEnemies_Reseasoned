using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Yarn;

namespace SaltsEnemies_Reseasoned
{
    public static class DelayedAttackVisualizer
    {
        public static GameObject_CFE_Layout FoolLayout;
        public static GameObject_EFE_Layout EnemyLayout;
        public static void Add()
        {
            GameObject Fool = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/DelayFool.prefab").gameObject;
            FoolLayout = Fool.AddComponent<GameObject_CFE_Layout>();
            FoolLayout.name = "DelayedAttack_Fool";
            FoolLayout.m_Back = new RectTransform[] { Fool.GetComponent<RectTransform>() };
            FoolLayout.m_Objects = new GameObject[] { Fool };

            GameObject Enemy = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/DelayEnemy.prefab");
            EnemyLayout = Enemy.AddComponent<GameObject_EFE_Layout>();
            EnemyLayout.name = "DelayedAttack_Enemy";
            EnemyLayout.m_Objects = new GameObject[] { Enemy };

            ResetArrays();
            ResetObjects();

            NotificationHook.AddAction(NotifCheck);
        }

        public static bool[] FoolAttacks;
        public static bool[] EnemyAttacks;

        public static CharacterFieldEffectLayout[] LayoutFools;
        public static EnemyFieldEffectLayout[] LayoutEnemies;
        public static void ResetArrays()
        {
            FoolAttacks = [false, false, false, false, false];
            EnemyAttacks = [false, false, false, false, false];
        }
        public static void ResetObjects()
        {
            LayoutFools = new CharacterFieldEffectLayout[5];
            LayoutEnemies = new EnemyFieldEffectLayout[5];
        }

        public static void UpdateVisuals()
        {
            ResetArrays();

            foreach (DelayedAttack attack in DelayedAttackManager.Attacks)
            {
                if (attack.caster != null && !attack.caster.IsUnitCharacter && (!attack.caster.IsAlive || attack.caster.HasFled)) continue;

                if (attack.Target.IsTargetCharacterSlot) FoolAttacks[attack.Target.SlotID] = true;
                else EnemyAttacks[attack.Target.SlotID] = true;
            }

            CombatManager.Instance.AddUIAction(new UpdatedDelayAttackVisualsAction());
        }

        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnDeath.ToString() || name == TriggerCalls.OnFleetingEnd.ToString())
                UpdateVisuals();
            if (name == TriggerCalls.OnBeforeCombatStart.ToString())
                ResetObjects();
        }
    }

    public class UpdatedDelayAttackVisualsAction : CombatAction
    {
        public static void UpdateFoolLayout(CombatStats stats, bool[] values)
        {
            for (int _slotId = 0; _slotId < values.Length; _slotId++)
            {
                CharacterSlotLayout slot = stats.combatUI._characterZone._slots[stats.combatUI._characterSlots[_slotId].SlotID];

                CharacterFieldEffectLayout layout_fool = DelayedAttackVisualizer.LayoutFools[_slotId];

                if (layout_fool == null)
                {
                    layout_fool = UnityEngine.Object.Instantiate(DelayedAttackVisualizer.FoolLayout, slot.transform);
                    layout_fool.InitializeLayout(slot._frontFieldEffectHolder, slot._backHolder, slot._swapHolder);
                }

                if (values[_slotId])
                {
                    layout_fool.AccessLayout(slot._hasUnit);
                }

                layout_fool.EndAccessLayout();
            }
        }
        public static void UpdateEnemyLayout(CombatStats stats, bool[] values)
        {
            for (int _slotId = 0; _slotId < values.Length; _slotId++)
            {
                EnemySlotLayout slot = stats.combatUI._enemyZone._slots[stats.combatUI._enemySlots[_slotId].SlotID];

                EnemyFieldEffectLayout layout_enemy = DelayedAttackVisualizer.LayoutEnemies[_slotId];
                
                if (layout_enemy == null)
                {
                    layout_enemy = UnityEngine.Object.Instantiate(DelayedAttackVisualizer.EnemyLayout, slot.transform);
                    layout_enemy.transform.localPosition = Vector3.zero;
                }

                if (values[_slotId])
                {
                    layout_enemy.AccessLayout();
                }

                layout_enemy.EndAccessLayout();
            }
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            UpdateFoolLayout(stats, DelayedAttackVisualizer.FoolAttacks);
            UpdateEnemyLayout(stats, DelayedAttackVisualizer.EnemyAttacks);

            yield break;
        }
    }
}
