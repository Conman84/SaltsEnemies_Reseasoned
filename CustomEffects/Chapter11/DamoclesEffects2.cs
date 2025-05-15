using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class PastHandler
    {
        public static int[] Current_Party;
        public static int[] Last_Party;
        public static int[] Current_Enemy;
        public static int[] Last_Enemy;

        public static void Setup()
        {
            Reset();
            TurnStarter.AddInitialize(Reset);
            TurnStarter.AddAction(PlayerTurnStart, true);
            TurnStarter.AddAction(PlayerTurnEnd, false);
        }

        public static void Reset()
        {
            Current_Party = [-1, -1, -1, -1, -1];
            Last_Party = [-1, -1, -1, -1, -1];
            Current_Enemy = [-1, -1, -1, -1, -1];
            Last_Enemy = [-1, -1, -1, -1, -1];
        }

        public static void PlayerTurnEnd()
        {
            Last_Party = Current_Party;
            Current_Party = [-1, -1, -1, -1, -1];
            for (int i = 0; i < CombatManager.Instance._stats.combatSlots.CharacterSlots.Length && i < 5; i++)
            {
                CombatSlot slot = CombatManager.Instance._stats.combatSlots.CharacterSlots[i];
                if (slot.HasUnit) Current_Party[i] = slot.Unit.ID;
            }
        }
        public static void PlayerTurnStart()
        {
            Last_Enemy = Current_Enemy;
            Current_Enemy = [-1, -1, -1, -1, -1];
            for (int i = 0; i < CombatManager.Instance._stats.combatSlots.EnemySlots.Length && i < 5; i++)
            {
                CombatSlot slot = CombatManager.Instance._stats.combatSlots.EnemySlots[i];
                if (slot.HasUnit) Current_Enemy[i] = slot.Unit.ID;
            }
        }
    }
}
