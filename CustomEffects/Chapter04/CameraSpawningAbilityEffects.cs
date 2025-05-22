using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class Test
    {
        CopyAndSpawnRandomCharacterAnywhereEffect random;
        CopyAndSpawnCustomCharacterAnywhereEffect custom;
        CopyCasterAndSpawnCharacterAnywhereEffect caster;
        ResurrectEffect revive;
    }

    public class CameraCopyEffectAction : EffectAction
    {
        public CameraCopyEffectAction(EffectInfo[] effects, IUnit caster, int startResult = 0) : base(new EffectInfo[effects.Length], caster, startResult)
        {
            //set effects
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            try
            {
                return base.Execute(stats);
            }
            catch (Exception ex)
            {
                Debug.LogWarning("Something has gone horribly wrong but its trying it's best!");
                Debug.LogWarning(ex.ToString());
                return new ShowAttackInformationUIAction(_caster.ID, _caster.IsUnitCharacter, "Something has gone horribly wrong but it's trying it's best!").Execute(stats);
            }
        }
    }
}
