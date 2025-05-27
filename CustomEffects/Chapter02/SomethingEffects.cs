using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using BrutalAPI;

namespace SaltEnemies_Reseasoned
{
    public class WasteTimeEffect : EffectSO
    {
        [SerializeField]
        public string[] _text = new string[1] { "..." };

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            for (int i = 0; i < entryVariable && i < _text.Length; i++)
            {
                CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                exitAmount++;
            }

            return exitAmount > 0;
        }
    }
    public class LyingDamageEffect : EffectSO
    {
        [SerializeField]
        public string _deathType = DeathType_GameIDs.Basic.ToString();

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int picking = UnityEngine.Random.Range(0, 3);
            int hitWith = 0;
            if (picking == 0)
                hitWith = 1;
            if (picking == 1)
                hitWith = 2;
            if (picking == 2)
                hitWith = 7;

            EffectInfo thisEffect = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), hitWith, Targeting.Slot_Front);
            DamageEffect previousExit = ScriptableObject.CreateInstance<DamageEffect>();
            previousExit._usePreviousExitValue = true;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            EffectInfo selfHit = Effects.GenerateEffect(previousExit, 1, Targeting.Slot_SelfAll, didThat);
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { thisEffect, selfHit }, caster));
            exitAmount = hitWith;
            return true;
        }
    }
    public class RandomAnimEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            int picking = UnityEngine.Random.Range(0, 15);
            if (picking == 0)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[3].ability.visuals;
                anim._animationTarget = Targeting.Slot_SelfAll;
            }
            if (picking == 1)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
                anim._animationTarget = Targeting.Slot_FrontAndSides;
            }
            if (picking == 2)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
                anim._animationTarget = Targeting.Slot_FrontAndSides;
            }
            if (picking == 3)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("Ouroborus_Tail_BOSS").abilities[0].ability.visuals;
                anim._animationTarget = Targeting.Slot_Front;
            }
            if (picking == 4)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
                anim._animationTarget = Targeting.Slot_FrontAndSides;
            }
            if (picking == 5)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("RingABell_A").visuals;
                anim._animationTarget = Targeting.Slot_Front;
            }
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            if (picking == 6)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.visuals;
                anim._animationTarget = allAlly;
            }
            if (picking == 7)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
                anim._animationTarget = Targeting.Slot_Front;
            }
            if (picking == 8)
            {
                anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Conversion_1_A").visuals;
                anim._animationTarget = Targeting.Slot_SelfAll;
            }
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;
            if (picking == 9)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
                anim._animationTarget = allEnemy;
            }
            if (picking == 10)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("SmoothSkin_BOSS").abilities[0].ability.visuals;
                anim._animationTarget = Targeting.Slot_Front;
            }
            if (picking == 11)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Crescendo_A").visuals;
                anim._animationTarget = Targeting.Slot_Front;
            }
            if (picking == 12)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("FallingSkies_A").visuals;
                anim._animationTarget = allEnemy;
            }
            if (picking == 13)
            {
                anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals;
                anim._animationTarget = Targeting.Slot_Front;
            }
            if (picking == 14)
            {
                anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Takedown_1_A").visuals;
                anim._animationTarget = Targeting.Slot_Front;
            }
            EffectInfo animYay = Effects.GenerateEffect(anim, 1, Targeting.Slot_SelfAll);

            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { animYay }, caster));
            exitAmount = 0;
            return true;
        }
    }
    public class WasteTimeUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public string _attackName;
        //public int _miliseconds;

        public WasteTimeUIAction(int id, bool isUnitCharacter, string attackName/*, int miliseconds*/)
        {
            _id = id;
            _isUnitCharacter = isUnitCharacter;
            _attackName = attackName;
            //_miliseconds = miliseconds;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            yield return stats.combatUI.ShowAttackInformation(_id, _isUnitCharacter, "", "");
        }


    }
    public class AnimationsOnEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return CombatManager.Instance._stats.combatUI._animations.CanTriggerAnimations;
        }
    }
    public class AnimationsOffEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return !CombatManager.Instance._stats.combatUI._animations.CanTriggerAnimations;
        }
    }
    public class RemoveWitheringFromDerogatoriesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            Ability interrupt = new Ability("Derogatory_Interrupt_A");
            interrupt.Name = "Interrupt";
            interrupt.Description = "Move Left or Right. If the Opposing party member is Muted, deal a Painful amount of damage to them.";
            interrupt.Rarity = Rarity.CreateAndAddCustomRarityToPool("Derogatory_5", 5);
            interrupt.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HasMutedEffect>(), 5, Targeting.Slot_Front),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Parry_1_A", true, Targeting.Slot_Front), 1, Targeting.Slot_SelfSlot, BasicEffects.DidThat(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageIfMutedEffect>(), 5, Targeting.Slot_Front),
            };
            interrupt.AnimationTarget = Targeting.Slot_Front;
            interrupt.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            interrupt.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ExtraAbilityInfo interrupt_a = new ExtraAbilityInfo();
            interrupt_a.ability = interrupt.GenerateEnemyAbility().ability;
            interrupt_a.rarity = interrupt.Rarity;

            exitAmount = 0;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Derogatory_EN"))
                {
                    if (enemy.TryRemovePassiveAbility(PassiveType_GameIDs.Withering.ToString()))
                    {
                        exitAmount++;
                        enemy.AddExtraAbility(interrupt_a);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class DamageIfStunnedEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit & target.Unit.ContainsStatusEffect(StatusField_GameIDs.Stunned_ID.ToString())) ret.Add(target);
            }
            return base.PerformEffect(stats, caster, ret.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class HasStunnedEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit & target.Unit.ContainsStatusEffect(StatusField_GameIDs.Stunned_ID.ToString())) exitAmount++;
            }
            return exitAmount > 0;
        }
    }
    public class HasMutedEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ContainsStatusEffect(Muted.StatusID)) exitAmount++;
            }
            return exitAmount > 0;
        }
    }
    public class DamageIfMutedEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit & target.Unit.ContainsStatusEffect(Muted.StatusID)) ret.Add(target);
            }
            return base.PerformEffect(stats, caster, ret.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
}