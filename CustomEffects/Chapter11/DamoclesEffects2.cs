using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


//damocles moveset

//Dangle: 2-3 frail & 4-6 scars self
//Pasts: 2 damage to all enemies at full health
//Futures: 5 delayed attack damage. move L/R
//Fall: the gimmick.

//formless, withering, string snaps, decay (2x self)

//resprite passive
//new design: make it something like the old starless design with the moon cradle and the hands and whatnot



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
    public class SpawnEnemyInSlotFromEntryStringNameHalfMaxEffect : EffectSO
    {
        public string en;

        public bool givesExperience;

        public bool trySpawnAnywhereIfFail;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Check.EnemyExist(en)) return false;
            EnemySO enemy = LoadedAssetsHandler.GetEnemy(en);
            for (int num = targets.Length - 1; num >= 0; num--)
            {
                int preferredSlot = entryVariable + targets[num].SlotID;
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, preferredSlot, givesExperience, trySpawnAnywhereIfFail, _spawnType, Math.Max(1, (int)Math.Ceiling((float)caster.MaximumHealth / 2))));
            }

            exitAmount = targets.Length;
            return true;
        }
    }
    public class SpawnSelfEnemyAnywhereHalfMaxEffect : EffectSO
    {
        public bool givesExperience;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!(caster is EnemyCombat)) return false;
            EnemySO enemy = (caster as EnemyCombat).Enemy;

            for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnType, Math.Max(1, (int)Math.Ceiling((float)caster.MaximumHealth / 2))));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
    public class Above1MaxHealthCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return effector.MaximumHealth > 1;
        }
    }
}
