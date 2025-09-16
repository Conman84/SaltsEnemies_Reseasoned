using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class FeatherGunCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException hitting)
            {
                (effector as IUnit).ShowItem();
                if (hitting.opponentUnitType != null && hitting.opponentUnitType.Contains("Bird")) hitting.AddModifier(new FloatMod(2.0f, true));
                else hitting.AddModifier(new FloatModMin1(1.15f, false));
            }
            return false;
        }

        public static void AddTypes()
        {
            LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("Revola_EN").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("Scrungie_EN").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("Charcarrion_Corpse_BOSS").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").unitTypes.Add("Bird");
            LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").unitTypes.Add("Bird");
        }
    }
}
