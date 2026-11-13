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
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Announcement", ResourceLoader.LoadSprite("AnnouncementPassive.png")));
            exitAmount = 0;
            return true;
        }
    }

    public class SlewStatusEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo slot in targets)
            {
                if (slot.HasUnit)
                {
                    IUnit target = slot.Unit;
                    target.ApplyStatusEffect(StatusField.Cursed, 1);
                    target.ApplyStatusEffect(StatusField.Scars, 1);
                    target.ApplyStatusEffect(StatusField.Ruptured, 2);
                    target.ApplyStatusEffect(Acid.Object, 1);
                    target.ApplyStatusEffect(Entropy.Object, 3);
                    target.ApplyStatusEffect(StatusField.Frail, 2);
                    target.ApplyStatusEffect(Pimples.Object, 2);
                    target.ApplyStatusEffect(StatusField.OilSlicked, 3);
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
}
