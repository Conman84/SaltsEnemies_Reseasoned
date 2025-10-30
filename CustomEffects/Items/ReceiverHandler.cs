using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class PostFireEffect : DamageEffect
    {
        public static AnimationVisualsEffect Visuals
        {
            get
            {
                if (_visuals == null)
                {
                    _visuals = BasicEffects.GetVisuals("Salt/Cannon", false, TargettingSelf_NotSlot.Create());
                }
                return _visuals;
            }
        }
        static AnimationVisualsEffect _visuals;
        public static string PostFire => "PostFire_A";
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ID == caster.SimpleGetStoredValue(PostFire))
                {
                    Visuals.PerformEffect(stats, target.Unit, [], false, 1, out int exi);
                    //CombatManager.Instance.AddUIAction(new PlayAbilityAnimationNoCasterAction(CustomVisuals.GetVisuals("Salt/Cannon"), TargettingSelf_NotSlot.Create().GetTargets(stats.combatSlots, target.Unit.SlotID, target.Unit.IsUnitCharacter)));
                    return base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, UnityEngine.Random.Range(6, 10), out exitAmount);
                }
            }
            return false;
        }
        public static void SetPostFire(string name, object sender, object args)
        {
            if (name == AdvancedDamageTrigger.Dealt.ToString() && args is AdvancedDamageInfo info && sender is IUnit unit)
            {
                if (info.Target != null && info.Target.IsUnitCharacter != unit.IsUnitCharacter) unit.SimpleSetStoredValue(PostFire, info.Target.ID);
            }
            if (name == TriggerCalls.OnBeforeCombatStart.ToString() && sender is IUnit iunit) iunit.SimpleSetStoredValue(PostFire, -1);
        }
        public static void Setup() => NotificationHook.AddAction(SetPostFire);
    }
}
