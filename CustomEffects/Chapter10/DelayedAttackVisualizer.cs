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
        public static On_Off_CFE_Layout FoolLayout;
        public static On_Off_EFE_Layout EnemyLayout;
        public static void Add()
        {
            GameObject Fool = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/DelayFool.prefab");
            GameObject FoolPart = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/DelayVanish_Fool.prefab");
            FoolPart.transform.SetParent(Fool.transform);
            FoolLayout = Fool.AddComponent<On_Off_CFE_Layout>();
            FoolLayout.name = "DelayedAttack_Fool";
            FoolLayout.m_Back = new RectTransform[] { Fool.GetComponent<RectTransform>(), FoolPart.GetComponent<RectTransform>() };
            FoolLayout.m_Objects = new GameObject[] { Fool };
            FoolLayout.m_Offs = [FoolPart];

            GameObject Enemy = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/DelayEnemy.prefab");
            GameObject EnemyPart = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/DelayVanish_Enemy.prefab");
            EnemyPart.transform.SetParent(Enemy.transform);
            EnemyLayout = Enemy.AddComponent<On_Off_EFE_Layout>();
            EnemyLayout.name = "DelayedAttack_Enemy";
            EnemyLayout.m_Objects = new GameObject[] { Enemy };
            EnemyLayout.m_Offs = [EnemyPart];

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
        public bool[] fools;
        public bool[] enemies;
        public UpdatedDelayAttackVisualsAction()
        {
            fools = DelayedAttackVisualizer.FoolAttacks;
            enemies = DelayedAttackVisualizer.EnemyAttacks;
        }
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
                    DelayedAttackVisualizer.LayoutFools[_slotId] = layout_fool;
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
                    DelayedAttackVisualizer.LayoutEnemies[_slotId] = layout_enemy;
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
            UpdateFoolLayout(stats, fools);
            UpdateEnemyLayout(stats, enemies);

            yield break;
        }
    }

    public class On_Off_CFE_Layout : GameObject_CFE_Layout
    {
        public GameObject[] m_Offs;

        public override void DisableLayout()
        {
            base.DisableLayout();
            GameObject[] objects = m_Offs;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(value: true);
            }
        }

        public override void EnableLayout(bool hasUnit)
        {
            base.EnableLayout(hasUnit);
            GameObject[] objects = m_Offs;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(value: false);
            }
        }
    }
    public class On_Off_EFE_Layout : GameObject_EFE_Layout
    {
        public GameObject[] m_Offs;

        public override void DisableLayout()
        {
            base.DisableLayout();
            GameObject[] objects = m_Offs;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(value: true);
            }
        }

        public override void EnableLayout()
        {
            base.EnableLayout();
            GameObject[] objects = m_Offs;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(value: false);
            }
        }
    }
}
