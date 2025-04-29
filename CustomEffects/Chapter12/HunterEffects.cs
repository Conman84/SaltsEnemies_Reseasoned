using BrutalAPI;
using UnityEngine;
using System.Collections;

//nest rework: 2 damage front 3 times, thats it.

namespace SaltEnemies_Reseasoned
{
    public class TerrorDeathEffect : EffectSO
    {
        [Header("Visual")]
        [SerializeField]
        public AttackVisualsSO _visuals = LoadedAssetsHandler.GetEnemyAbility("Chomp_A").visuals;

        [SerializeField]
        public BaseCombatTargettingSO _animationTarget = Slots.Self;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ContainsStatusEffect(Terror.StatusID))
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Hunter", ResourceLoader.LoadSprite("hunterpassive.png")));
                    CombatManager.Instance.AddUIAction(new TerrorAction(_visuals, target, caster));
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class TerrorAction : CombatAction
    {
        public TargetSlotInfo _targetting;

        public AttackVisualsSO _visuals;

        public IUnit _caster;

        public TerrorAction(AttackVisualsSO visuals, TargetSlotInfo targetting, IUnit caster)
        {
            _visuals = visuals;
            _targetting = targetting;
            _caster = caster;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            yield return stats.combatUI.PlayAbilityAnimation(_visuals, new TargetSlotInfo[] { _targetting }, true);
            if (_targetting.HasUnit) _targetting.Unit.DirectDeath(_caster);
        }
    }
    public class HuntDownEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int rightMod = 1;
            int leftMod = 1;
            if (!caster.IsUnitCharacter)
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.SlotID == caster.SlotID + caster.Size) rightMod = enemy.Size;
                    if (enemy.SlotID == caster.SlotID - enemy.Size) leftMod = enemy.Size;
                }
            }
            TargetSlotInfo Left = null;
            TargetSlotInfo Right = null;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.SlotID == caster.SlotID - leftMod) Left = target;
                else if (target.SlotID == caster.SlotID + rightMod) Right = target;
            }
            bool Lefting = (Left != null && Left.HasUnit && Left.Unit.ContainsStatusEffect(Terror.StatusID));
            bool righting = (Right != null && Right.HasUnit && Right.Unit.ContainsStatusEffect(Terror.StatusID));
            if (Lefting && righting)
            {
                ScriptableObject.CreateInstance<SwapToSidesEffect>().PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else if (Lefting)
            {
                BasicEffects.GoLeft.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else if (righting)
            {
                BasicEffects.GoRight.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else
            {
                ScriptableObject.CreateInstance<SwapToSidesEffect>().PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int grag);
                return false;
            }
        }
    }
}
