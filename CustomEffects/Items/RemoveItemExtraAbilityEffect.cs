using System;
using System.Collections.Generic;
using System.Text;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public class CasterRemoveItemExtraAbilityEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is CharacterCombat chara)
            {
                if (chara.CharacterWearableModifiers.ExtraAbilityModifier == null) return false;

                for (int num2 = chara.CombatAbilities.Count - 1; num2 >= 0; num2--)
                {
                    if (!(chara.CombatAbilities[num2].ability != chara.CharacterWearableModifiers.ExtraAbilityModifier.ability))
                    {
                        chara.CombatAbilities.RemoveAt(num2);
                        CombatManager.Instance.AddUIAction(new CharacterRemoveAttackUIAction(chara.ID, num2));
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
