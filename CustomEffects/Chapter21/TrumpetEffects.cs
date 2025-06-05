using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class AnnouncementPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Announcement (" + entryVariable.ToString() + ")", ResourceLoader.LoadSprite("AnnoucementPassive.png")));
            exitAmount = 0;
            return true;
        }
    }
}
