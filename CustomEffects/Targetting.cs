using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Targetting
    {
        public static Targetting_ByUnit_Side AllEnemy
        {
            get
            {
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = false;
                allEnemy.getAllUnitSlots = false;
                return allEnemy;
            }
        }
        public static Targetting_ByUnit_Side AllAlly
        {
            get
            {
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = true;
                allEnemy.getAllUnitSlots = false;
                return allEnemy;
            }
        }
        public static Targetting_ByUnit_Side AllOtherAlly
        {
            get
            {
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = true;
                allEnemy.ignoreCastSlot = true;
                allEnemy.getAllUnitSlots = false;
                return allEnemy;
            }
        }
        public static TargettingByHealthUnits HighestEnemy
        {
            get
            {
                TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                highest.Lowest = false;
                highest.getAllies = false;
                return highest;
            }
        }
        public static TargettingByHealthUnits LowestEnemy
        {
            get
            {
                TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                highest.Lowest = true;
                highest.getAllies = false;
                return highest;
            }
        }
        public static TargettingByHealthUnits LowestOtherAlly
        {
            get
            {
                TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                highest.Lowest = true;
                highest.getAllies = true;
                highest.ignoreCastSlot = true;
                return highest;
            }
        }
        public static TargettingByHealthUnits LowestAlly
        {
            get
            {
                TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                highest.Lowest = true;
                highest.getAllies = true;
                highest.ignoreCastSlot = false;
                return highest;
            }
        }
        public static Targetting_BySlot_Index AllSelfSlots
        {
            get
            {
                Targetting_BySlot_Index instance2 = ScriptableObject.CreateInstance<Targetting_BySlot_Index>();
                instance2.getAllies = true;
                instance2.allSelfSlots = true;
                instance2.slotPointerDirections = new int[1];
                return instance2;
            }
        }
        public static TargettingByHealthUnits HighestAlly
        {
            get
            {
                TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                highest.Lowest = false;
                highest.getAllies = true;
                return highest;
            }
        }

        public static BaseCombatTargettingSO Closer(bool near, bool allies)
        {
            if (near)
            {
                TargettingClosestUnits closestAlly = ScriptableObject.CreateInstance<TargettingClosestUnits>();
                closestAlly.getAllies = allies;
                return closestAlly;
            }
            else
            {
                TargettingFarthestUnits closestAlly = ScriptableObject.CreateInstance<TargettingFarthestUnits>();
                closestAlly.getAllies = allies;
                return closestAlly;
            }
        }
        public static TargettingRandomUnit Random(bool getAlly)
        {
            TargettingRandomUnit ret = ScriptableObject.CreateInstance<TargettingRandomUnit>();
            ret.getAllies = getAlly;
            return ret;
        }
        public static Targetting_ByUnit_SideColor GetColors(ManaColorSO color, bool getAlly)
        {
            Targetting_ByUnit_SideColor ret = ScriptableObject.CreateInstance<Targetting_ByUnit_SideColor>();
            ret.getAllies = getAlly;
            ret.getAllUnitSlots = false;
            ret.Color = color;
            return ret;
        }
        public static ReverseTargetting Reverse(BaseCombatTargettingSO source)
        {
            ReverseTargetting ret = ScriptableObject.CreateInstance<ReverseTargetting>();
            ret.source = source;
            return ret;
        }
        public static BaseCombatTargettingSO Everything(bool allies)
        {
            return Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, allies);
        }
    }
    public class TargettingByHealthUnits : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = false;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public bool Lowest;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            List<CombatSlot> opinion = new List<CombatSlot>();
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.Unit.SlotID))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            foreach (CombatSlot slot in opinion)
            {
                targets.Add(slot.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    public class TargettingClosestUnits : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            CombatSlot greaterest = null;
            CombatSlot lesserest = null;
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            if (greaterest != null)
            {
                targets.Add(greaterest.TargetSlotInformation);
            }
            if (lesserest != null)
            {
                targets.Add(lesserest.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    public class TargettingFarthestUnits : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            CombatSlot greaterest = null;
            CombatSlot lesserest = null;
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID > greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID < lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            if (greaterest != null)
            {
                targets.Add(greaterest.TargetSlotInformation);
            }
            if (lesserest != null)
            {
                targets.Add(lesserest.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    public class TargettingRandomUnit : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = false;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
        {
            foreach (TargetSlotInfo targe in targets)
            {
                if (targe.Unit == target.Unit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCastSlot(int caster, TargetSlotInfo target)
        {
            if (!ignoreCastSlot) { return false; }
            else if (caster != target.SlotID) { return false; }
            else return true;
        }

        public static TargetSlotInfo LastRandom = null;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            if ((getAllies && isCasterCharacter) || (!getAllies && !isCasterCharacter))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ))
                    {
                        targets.Add(targ);
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ))
                    {
                        targets.Add(targ);
                    }
                }
            }
            if (targets.Count <= 0)
            {
                LastRandom = null;
                return new TargetSlotInfo[0];
            }
            TargetSlotInfo goy = targets[UnityEngine.Random.Range(0, targets.Count)];
            LastRandom = goy;
            return new TargetSlotInfo[] { goy };
        }
    }
    public class TargettingLastRandomUnit : BaseCombatTargettingSO
    {
        public bool IsTargetAlly(bool isCasterChara)
        {
            if (TargettingRandomUnit.LastRandom == null) return false;
            if (isCasterChara == TargettingRandomUnit.LastRandom.IsTargetCharacterSlot)
            {
                LastCheckedIsAlly = true;
                return true;
            }
            else
            {
                LastCheckedIsAlly = false;
                return false;
            }
        }

        public bool LastCheckedIsAlly = false;

        public override bool AreTargetAllies => LastCheckedIsAlly;

        public override bool AreTargetSlots => false;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            IsTargetAlly(isCasterCharacter);
            if (TargettingRandomUnit.LastRandom == null) return new TargetSlotInfo[0];
            return new TargetSlotInfo[] { TargettingRandomUnit.LastRandom };
        }
    }
    public class TargettingUnitsWithStatusEffectSide : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = false;

        public string targetStatus;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
        {
            foreach (TargetSlotInfo targe in targets)
            {
                if (targe.Unit == target.Unit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCastSlot(int caster, TargetSlotInfo target)
        {
            if (!ignoreCastSlot) { return false; }
            else if (caster != target.SlotID) { return false; }
            else return true;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            if ((getAllies && isCasterCharacter) || (!getAllies && !isCasterCharacter))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ) && targ.Unit.ContainsStatusEffect(targetStatus))
                    {
                        targets.Add(targ);
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ) && targ.Unit.ContainsStatusEffect(targetStatus))
                    {
                        targets.Add(targ);
                    }
                }
            }
            return targets.ToArray();
        }
    }
    public class TargettingUnitsWithStatusEffectAll : BaseCombatTargettingSO
    {
        public bool ignoreCastSlot = false;

        public string targetStatus;

        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => false;

        public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
        {
            foreach (TargetSlotInfo targe in targets)
            {
                if (targe.Unit == target.Unit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCastSlot(int caster, TargetSlotInfo target)
        {
            if (!ignoreCastSlot) { return false; }
            else if (caster != target.SlotID) { return false; }
            else return true;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (CombatSlot slot in slots.CharacterSlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ) && targ.Unit.ContainsStatusEffect(targetStatus))
                {
                    targets.Add(targ);
                }
            }
            foreach (CombatSlot slot in slots.EnemySlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ) && targ.Unit.ContainsStatusEffect(targetStatus))
                {
                    targets.Add(targ);
                }
            }
            return targets.ToArray();
        }
    }
    public class TargettingAllUnits : BaseCombatTargettingSO
    {
        public bool ignoreCastSlot = false;

        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => false;

        public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
        {
            foreach (TargetSlotInfo targe in targets)
            {
                if (targe.Unit == target.Unit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCastSlot(int caster, TargetSlotInfo target)
        {
            if (!ignoreCastSlot) { return false; }
            else if (caster != target.SlotID) { return false; }
            else return true;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (CombatSlot slot in slots.CharacterSlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ))
                {
                    targets.Add(targ);
                }
            }
            foreach (CombatSlot slot in slots.EnemySlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ))
                {
                    targets.Add(targ);
                }
            }
            return targets.ToArray();
        }
    }
    public class TargettingAllSlots : BaseCombatTargettingSO
    {
        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => false;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (CombatSlot slot in slots.CharacterSlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null)
                {
                    targets.Add(targ);
                }
            }
            foreach (CombatSlot slot in slots.EnemySlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null)
                {
                    targets.Add(targ);
                }
            }
            return targets.ToArray();
        }
    }
    public class TargettingWeakestUnit : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public bool IsSelfAllowed(TargetSlotInfo target, int casterID)
        {
            if (!ignoreCastSlot) return true;
            else if (!getAllies) return true;
            else if (target.SlotID == casterID) return false;
            else return true;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo weakest = null;
            if ((getAllies && isCasterCharacter) || (!getAllies && !isCasterCharacter))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && IsSelfAllowed(targ, casterSlotID))
                    {
                        if (weakest == null)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth > targ.Unit.CurrentHealth)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth == targ.Unit.CurrentHealth && UnityEngine.Random.Range(0, 100) < 50)
                        {
                            weakest = targ;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && IsSelfAllowed(targ, casterSlotID))
                    {
                        if (weakest == null)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth > targ.Unit.CurrentHealth)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth == targ.Unit.CurrentHealth && UnityEngine.Random.Range(0, 100) < 50)
                        {
                            weakest = targ;
                        }
                    }
                }
            }
            if (weakest == null) return new TargetSlotInfo[0];
            return new TargetSlotInfo[] { weakest };
        }
    }
    public class TargettingWeakestNotLostSheep : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public bool IsSelfAllowed(TargetSlotInfo target, int casterID)
        {
            if (!ignoreCastSlot) return true;
            else if (!getAllies) return true;
            else if (target.SlotID == casterID) return false;
            else return true;
        }

        static EnemySO LostSheep;
        static bool LostSheepExist;
        static bool LostSheepChecked = false;
        public static bool IsLostSheep(TargetSlotInfo targ)
        {
            if (!LostSheepChecked) LostSheepExist = Check.EnemyExist("LostSheep_EN");
            if (!LostSheepExist) return false;
            if (LostSheep == null || LostSheep.Equals(null)) LostSheep = LoadedAssetsHandler.GetEnemy("LostSheep_EN");
            if (targ.HasUnit)
            {
                if (targ.Unit is EnemyCombat enemy)
                {
                    if (enemy.Enemy == LostSheep) return true;
                }
            }
            return false;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo weakest = null;
            if ((getAllies && isCasterCharacter) || (!getAllies && !isCasterCharacter))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && IsSelfAllowed(targ, casterSlotID))
                    {
                        if (weakest == null)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth > targ.Unit.CurrentHealth)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth == targ.Unit.CurrentHealth && UnityEngine.Random.Range(0, 100) < 50)
                        {
                            weakest = targ;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && IsSelfAllowed(targ, casterSlotID) && !IsLostSheep(targ))
                    {
                        if (weakest == null)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth > targ.Unit.CurrentHealth)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth == targ.Unit.CurrentHealth && UnityEngine.Random.Range(0, 100) < 50)
                        {
                            weakest = targ;
                        }
                    }
                }
            }
            if (weakest == null) return new TargetSlotInfo[0];
            return new TargetSlotInfo[] { weakest };
        }
    }
    public class TargettingClosestNotLostSheep : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        static EnemySO LostSheep;
        static bool LostSheepExist;
        static bool LostSheepChecked = false;
        public static bool IsLostSheep(CombatSlot targ)
        {
            if (!LostSheepChecked) LostSheepExist = Check.EnemyExist("LostSheep_EN");
            if (!LostSheepExist) return false;
            if (LostSheep == null || LostSheep.Equals(null)) LostSheep = LoadedAssetsHandler.GetEnemy("LostSheep_EN");
            if (targ.HasUnit)
            {
                if (targ.Unit is EnemyCombat enemy)
                {
                    if (enemy.Enemy == LostSheep) return true;
                }
            }
            return false;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            CombatSlot greaterest = null;
            CombatSlot lesserest = null;
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID) && !IsLostSheep(slot))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID) && !IsLostSheep(slot))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            if (greaterest != null)
            {
                targets.Add(greaterest.TargetSlotInformation);
            }
            if (lesserest != null)
            {
                targets.Add(lesserest.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    public class UnitSideNotLostSheep : Targetting_ByUnit_Side
    {
        static EnemySO LostSheep;
        static bool LostSheepExist;
        static bool LostSheepChecked = false;
        public static bool IsLostSheep(TargetSlotInfo targ)
        {
            if (!LostSheepChecked) LostSheepExist = Check.EnemyExist("LostSheep_EN");
            if (!LostSheepExist) return false;
            if (LostSheep == null || LostSheep.Equals(null)) LostSheep = LoadedAssetsHandler.GetEnemy("LostSheep_EN");
            if (targ.HasUnit)
            {
                if (targ.Unit is EnemyCombat enemy)
                {
                    if (enemy.Enemy == LostSheep) return true;
                }
            }
            return false;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (!IsLostSheep(target)) ret.Add(target);
            }
            return ret.ToArray();
        }
    }
    public class TargettingByFacingTarget : BaseCombatTargettingSO
    {
        public bool GetAllies = false;
        public bool FacingUnit = false;
        public override bool AreTargetAllies => GetAllies;
        public override bool AreTargetSlots => true;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            if ((isCasterCharacter && AreTargetAllies) || ((!isCasterCharacter && !AreTargetAllies)))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    foreach (CombatSlot opposer in slots.EnemySlots)
                    {
                        if (opposer.SlotID == slot.SlotID)
                        {
                            if (FacingUnit && opposer.HasUnit)
                            {
                                ret.Add(slot.TargetSlotInformation);
                            }
                            else if (!FacingUnit && !opposer.HasUnit)
                            {
                                ret.Add(slot.TargetSlotInformation);
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    foreach (CombatSlot opposer in slots.CharacterSlots)
                    {
                        if (opposer.SlotID == slot.SlotID)
                        {
                            if (FacingUnit && opposer.HasUnit)
                            {
                                ret.Add(slot.TargetSlotInformation);
                            }
                            else if (!FacingUnit && !opposer.HasUnit)
                            {
                                ret.Add(slot.TargetSlotInformation);
                            }
                            break;
                        }
                    }
                }
            }
            return ret.ToArray();
        }
    }
    public class ReverseTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO source;
        public override bool AreTargetAllies => !source.AreTargetAllies;
        public override bool AreTargetSlots => true;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] orig = source.GetTargets(slots, casterSlotID, isCasterCharacter);
            if (orig.Length <= 0) return new TargetSlotInfo[0];
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in orig)
            {
                if (target.HasUnit)
                {
                    if (target.SlotID != target.Unit.SlotID) continue;
                }
                foreach (TargetSlotInfo add in Targeting.Slot_Front.GetTargets(slots, target.SlotID, target.IsTargetCharacterSlot))
                {
                    ret.Add(add);
                }
            }
            return ret.ToArray();
        }
    }
    public class Targetting_ByUnit_SideColor : Targetting_ByUnit_Side
    {
        public ManaColorSO Color;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => getAllUnitSlots;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.HealthColor == Color) ret.Add(target);
            }
            return ret.ToArray();
        }
    }
    public class Targetting_ByUnit_Side_FullHealth : Targetting_ByUnit_Side
    {
        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => getAllUnitSlots;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.CurrentHealth >= target.Unit.MaximumHealth) ret.Add(target);
            }
            return ret.ToArray();
        }

        public static Targetting_ByUnit_Side_FullHealth Create(bool allies)
        {
            Targetting_ByUnit_Side_FullHealth ret = ScriptableObject.CreateInstance<Targetting_ByUnit_Side_FullHealth>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = false;
            return ret;
        }
    }

    public class DoubleTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO firstTargetting;
        public BaseCombatTargettingSO secondTargetting;

        public override bool AreTargetAllies => false;
        public override bool AreTargetSlots => false;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();

            if (firstTargetting != null)
            {
                foreach (TargetSlotInfo target in firstTargetting.GetTargets(slots, casterSlotID, isCasterCharacter))
                    list.Add(target);
            }

            if (secondTargetting != null)
            {
                foreach (TargetSlotInfo target in secondTargetting.GetTargets(slots, casterSlotID, isCasterCharacter))
                    list.Add(target);
            }

            return list.ToArray();
        }
    }
    public class EmptyTargetting : BaseCombatTargettingSO
    {
        public bool GetAllies;
        public override bool AreTargetSlots => false;
        public override bool AreTargetAllies => GetAllies;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            return new TargetSlotInfo[0];
        }
        public static EmptyTargetting Create(bool allies)
        {
            EmptyTargetting ret = ScriptableObject.CreateInstance<EmptyTargetting>();
            ret.GetAllies = allies;
            return ret;
        }
    }
}
