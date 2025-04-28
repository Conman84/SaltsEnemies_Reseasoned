using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class OnPissPassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => false;

        public override void TriggerPassive(object sender, object args)
        {
            Debug.Log("NOTHING!!!!!!!!!!!!!!");

        }
        public override void OnPassiveConnected(IUnit unit)
        {
            if (DivineSacrifice.Object == null || DivineSacrifice.Object.Equals(null)) DivineSacrifice.Add();
            CombatManager.Instance.AddSubAction(new SERestrictorPassiveConnectedAction(unit.ID, unit.IsUnitCharacter, _passiveName, passiveIcon, m_PassiveID, DivineSacrifice.Object));
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            if (DivineSacrifice.Object == null || DivineSacrifice.Object.Equals(null)) DivineSacrifice.Add();
            CombatManager.Instance.AddSubAction(new SERestrictorPassiveDisconnectedAction(unit.ID, unit.IsUnitCharacter, m_PassiveID, DivineSacrifice.Object));
        }
    }
    public class DPLowestThreeEffect : EffectSO
    {
        public override bool PerformEffect(
        CombatStats stats,
        IUnit caster,
        TargetSlotInfo[] targets,
        bool areTargetSlots,
        int entryVariable,
        out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive && target.Unit != caster)
                {
                    if (num < 0)
                    {
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth < num)
                    {
                        targetSlotInfoList.Clear();
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth == num)
                        targetSlotInfoList.Add(target);
                }
            }

            List<TargetSlotInfo> targetSlotInfoListAgain = new List<TargetSlotInfo>();
            int numbah = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive && target.Unit != caster)
                {
                    if (numbah < 0)
                    {
                        if (target.Unit.CurrentHealth > num)
                        {
                            targetSlotInfoListAgain.Add(target);
                            numbah = target.Unit.CurrentHealth;
                        }
                    }
                    else if (target.Unit.CurrentHealth < numbah)
                    {
                        if (target.Unit.CurrentHealth > num)
                        {
                            targetSlotInfoListAgain.Clear();
                            targetSlotInfoListAgain.Add(target);
                            numbah = target.Unit.CurrentHealth;
                        }
                    }
                    else if (target.Unit.CurrentHealth == numbah)
                        if (target.Unit.CurrentHealth > num)
                        {
                            targetSlotInfoListAgain.Add(target);
                        }
                }
            }

            List<TargetSlotInfo> targetSlotInfoList3 = new List<TargetSlotInfo>();
            int numbaj = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive && target.Unit != caster)
                {
                    if (numbaj < 0)
                    {
                        if (target.Unit.CurrentHealth > numbah)
                        {
                            targetSlotInfoList3.Add(target);
                            numbaj = target.Unit.CurrentHealth;
                        }
                    }
                    else if (target.Unit.CurrentHealth < numbaj)
                    {
                        if (target.Unit.CurrentHealth > numbah)
                        {
                            targetSlotInfoList3.Clear();
                            targetSlotInfoList3.Add(target);
                            numbah = target.Unit.CurrentHealth;
                        }
                    }
                    else if (target.Unit.CurrentHealth == numbaj)
                        if (target.Unit.CurrentHealth > numbah)
                        {
                            targetSlotInfoList3.Add(target);
                        }
                }
            }


            foreach (TargetSlotInfo target in targetSlotInfoList)
            {
                GenericTargetting_BySlot_Index slotTarget = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                slotTarget.slotPointerDirections = new int[1] { target.Unit.SlotID };
                slotTarget.getAllies = !(target.Unit.IsUnitCharacter);
                EffectInfo entering = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, slotTarget);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { entering }, caster));
            }
            foreach (TargetSlotInfo target in targetSlotInfoListAgain)
            {
                GenericTargetting_BySlot_Index slotTarget = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                slotTarget.slotPointerDirections = new int[1] { target.Unit.SlotID };
                slotTarget.getAllies = !(target.Unit.IsUnitCharacter);
                EffectInfo entering = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 2, slotTarget);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { entering }, caster));
            }
            foreach (TargetSlotInfo target in targetSlotInfoList3)
            {
                GenericTargetting_BySlot_Index slotTarget = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                slotTarget.slotPointerDirections = new int[1] { target.Unit.SlotID };
                slotTarget.getAllies = !(target.Unit.IsUnitCharacter);
                EffectInfo entering = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 1, slotTarget);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { entering }, caster));
            }

            return exitAmount > 0;
        }
    }
}
