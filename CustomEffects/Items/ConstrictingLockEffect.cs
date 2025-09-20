using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static UnityEngine.UI.CanvasScaler;

namespace SaltsEnemies_Reseasoned
{
    public class ConstrictingLockEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.ContainsPassiveAbility(Passives.Constricting.m_PassiveID)) CombatManager.Instance.AddSubAction(new ConstrictedDisconnectedAction(StatusField_GameIDs.Constricted_ID.ToString(), enemy.SlotID, enemy.IsUnitCharacter, enemy.Size));
            }
            foreach (CharacterCombat chara in stats.CharactersOnField.Values)
            {
                if (chara.ContainsPassiveAbility(Passives.Constricting.m_PassiveID)) CombatManager.Instance.AddSubAction(new ConstrictedDisconnectedAction(StatusField_GameIDs.Constricted_ID.ToString(), chara.SlotID, chara.IsUnitCharacter, chara.Size));
            }
            exitAmount = 0;
            return true;
        }
    }
}
