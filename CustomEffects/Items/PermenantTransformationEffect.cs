using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{

    public class PermenantTransformationEffect : EffectSO
    {
        public static CharacterSO getRandom()
        {
            CharacterSO ret = new List<CharacterSO>(LoadedAssetsHandler.LoadedCharacters.Values).GetRandom();
            for (int i = 0; i < 144; i++)
            {
                if (ret == null || ret.Equals(null)) ret = new List<CharacterSO>(LoadedAssetsHandler.LoadedCharacters.Values).GetRandom();
                else break;
            }
            return ret;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit is CharacterCombat chara)
                {
                    CharacterSO c = getRandom();
                    for (int i = 0; i < 144 && (!c.HasRankedData || c.rankedData.Count <= chara.Rank); i++) c = getRandom();
                    if (stats.TryTransformCharacter(chara.ID, c, false, false, false)) exitAmount++;
                    YNLHandler2.Transforms.Add(chara.ID);
                }
            }
            return exitAmount > 0;
        }
    }
}
