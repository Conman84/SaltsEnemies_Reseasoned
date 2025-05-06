using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class Slots
    {
        public static BaseCombatTargettingSO Self => Targeting.Slot_SelfSlot;
        public static BaseCombatTargettingSO SelfSlots => Targeting.Slot_SelfAll;
        public static BaseCombatTargettingSO Front => Targeting.Slot_Front;
        public static BaseCombatTargettingSO Sides => Targeting.Slot_AllySides;
        public static BaseCombatTargettingSO Left => Targeting.Slot_OpponentLeft;
        public static BaseCombatTargettingSO Right => Targeting.Slot_OpponentRight;
        public static BaseCombatTargettingSO LeftRight => Targeting.Slot_OpponentSides;
        public static BaseCombatTargettingSO FrontLeftRight => Targeting.Slot_FrontAndSides;
        public static BaseCombatTargettingSO SlotTarget(int[] ints, bool allies, bool getAllSelf = false) => Targeting.GenerateSlotTarget(ints, allies, getAllSelf);
    }
}
