using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tools;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace SaltsEnemies_Reseasoned
{
    public class TargetForceFirstCasterActionEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            int targetcount = 0;
            foreach (TargetSlotInfo t in targets) if (t.HasUnit) targetcount++;
            if (targetcount <= 0) return false;


            if (caster is EnemyCombat enemy)
            {
                if (enemy.TurnsInTimeline <= 0) return false;

                for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
                {
                    if (stats.timeline.Round[i].isPlayer) continue;

                    if (stats.timeline.Round[i].turnUnit == enemy)
                    {
                        if (stats.timeline.Round[i].abilitySlot < 0 || stats.timeline.Round[i].abilitySlot >= enemy.Abilities.Count) continue;

                        AbilitySO ability = enemy.Abilities[stats.timeline.Round[i].abilitySlot].ability;

                        foreach (TargetSlotInfo target in targets)
                        {
                            if (target.HasUnit && target.Unit is CharacterCombat chara)
                            {
                                if (CharacterPerformAbility(chara, ability)) exitAmount++;
                            }
                            else if (target.HasUnit && target.Unit is EnemyCombat enem2)
                            {
                                if (EnemyPerformAbility(enem2, ability)) exitAmount++;
                            }
                        }

                        break;
                    }
                }
            }

            return exitAmount > 0;
        }
        public virtual bool EnemyPerformAbility(EnemyCombat self, AbilitySO ability)
        {
            CombatManager.Instance.AddSubAction(new ShowAttackInformationUIAction(self.ID, self.IsUnitCharacter, ability.GetAbilityLocData().text));
            CombatManager.Instance.AddSubAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, self));
            CombatManager.Instance.AddSubAction(new EffectAction(ability.effects, self));
            self.SetVolatileUpdateUIAction();
            return true;
        }
        public virtual bool CharacterPerformAbility(CharacterCombat self, AbilitySO ability)
        {
            CombatManager.Instance.AddSubAction(new ShowAttackInformationUIAction(self.ID, self.IsUnitCharacter, ability.GetAbilityLocData().text));
            CombatManager.Instance.AddSubAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, self));
            CombatManager.Instance.AddSubAction(new EffectAction(ability.effects, self));
            self.SetVolatileUpdateUIAction();
            return true;
        }
    }
    public class RemoveFirstCasterActionEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            if (caster is EnemyCombat enemy)
            {
                if (enemy.TurnsInTimeline <= 0) return false;

                for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
                {
                    if (stats.timeline.Round[i].isPlayer) continue;

                    if (stats.timeline.Round[i].turnUnit == enemy)
                    {
                        stats.timeline.Round.RemoveAt(i);
                        enemy.TurnsInTimeline--;

                        CombatManager.Instance.AddUIAction(new RemoveSlotTimelineUIAction([i]));
                        CombatManager.Instance.AddUIAction(new UpdateTimelinePointerUIAction(stats.timeline.CurrentTurn));

                        exitAmount++;

                        entryVariable -= 1;
                        if (entryVariable <= 0) break;
                    }
                }
            }

            return exitAmount > 0;
        }
    }

    public class ComissionerEffect : TargetForceFirstCasterActionEffect
    {
        public EffectInfo[] CasterEffects;
        public IUnit caster;
        public class UseAbilityAction : CombatAction
        {
            public IUnit target;
            public AbilitySO ability;

            public IUnit caster;
            public EffectInfo[] effects;
            public UseAbilityAction(IUnit unit, AbilitySO ability, IUnit caster, EffectInfo[] effects)
            {
                this.target = unit;
                this.ability = ability;
                this.caster = caster;
                this.effects = effects;
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                //EnemyCombat.UseAbility
                CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(target.ID, target.IsUnitCharacter, ability.GetAbilityLocData().text));
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, target));
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(ability.effects, target));
                target.SetVolatileUpdateUIAction();

                if (caster != null) CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(effects, caster));
                
                yield return null;
            }
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            this.caster = caster;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
        public override bool EnemyPerformAbility(EnemyCombat self, AbilitySO ability)
        {
            CombatManager.Instance.AddPrioritySubAction(new UseAbilityAction(self, ability, caster, CasterEffects));
            caster = null;
            return true;
        }
        public override bool CharacterPerformAbility(CharacterCombat self, AbilitySO ability)
        {
            CombatManager.Instance.AddPrioritySubAction(new UseAbilityAction(self, ability, caster, CasterEffects));
            caster = null;
            return true;
        }

        public static ComissionerEffect Create(EffectInfo[] effects)
        {
            ComissionerEffect ret = ScriptableObject.CreateInstance<ComissionerEffect>();
            ret.CasterEffects = effects;
            return ret;
        }
    }

    public class AnimationVisualsByTargetEffect : EffectSO
    {
        [Header("Visual")]
        public AttackVisualsSO _visuals;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new PlayAnimationAnywhereAction(_visuals, targets));
            exitAmount = 0;
            return true;
        }
    }
}
