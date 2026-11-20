using System;
using Tools;

namespace YourNamespace
{

    public class CasterSplitInTwoBasicEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            bool filled = true;
            for (int i = 0; i < 5; i++)
            {
                if (caster.IsUnitCharacter ? stats.combatSlots.CharacterSlots[i].HasUnit : stats.combatSlots.EnemySlots[i].HasUnit) continue;
                filled = false;
            }
            if (filled) return false;

            int half = (int)Math.Ceiling((float)caster.CurrentHealth / 2f);
            int spawn_at = caster.CurrentHealth - half;
            if (spawn_at <= 0) return false;

            caster.SetHealthTo(half);

            if (caster is CharacterCombat chara)
            {
                CharacterSO character = chara.Character;
                if (character == null || character.Equals(null))
                {
                    return false;
                }

                int currentHealth = spawn_at;
                int[] usedAbilities = character.GenerateAbilities();
                WearableStaticModifiers modifiers = new WearableStaticModifiers();
                WearableStaticModifierSetterSO[] extraModifiers = [];
                for (int i = 0; i < extraModifiers.Length; i++)
                {
                    extraModifiers[i].OnAttachedToCharacter(modifiers, character, chara.Rank);
                }

                string nameAdditionData = LocUtils.GameLoc.GetNameAdditionData(NameAdditionLocID.NameAdditionNone);
                for (int j = 0; j < entryVariable; j++)
                {
                    CombatManager.Instance.AddSubAction(new SpawnCharacterAction(character, -1, trySpawnAnyways: false, nameAdditionData, true, chara.Rank, usedAbilities, currentHealth, modifiers));
                }

                return true;
            }
            else if (caster is EnemyCombat enemy)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy.Enemy, -1, false, trySpawnAnyways: false, CombatType_GameIDs.Spawn_Basic.ToString(), spawn_at));

                return true;
            }

            return false;
        }
    }
}
