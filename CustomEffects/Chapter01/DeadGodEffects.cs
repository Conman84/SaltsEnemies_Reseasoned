using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class UnmaskPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 1;
        [SerializeField]
        public int _floorVal = 10;


        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;

            if (args is IntegerReference HitBy && HitBy.value >= _floorVal)
            {
                IPassiveEffector passiveEffector = sender as IPassiveEffector;
                if (unit.ContainsPassiveAbility(Passives.Confusion.m_PassiveID) || unit.ContainsPassiveAbility(Passives.Obscure.m_PassiveID))
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, GetPassiveLocData().text, this.passiveIcon));
                RemovePassiveEffect unmask = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                unmask.m_PassiveID = Passives.Obscure.m_PassiveID;
                RemovePassiveEffect unmask2 = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                unmask2.m_PassiveID = Passives.Confusion.m_PassiveID;
                EffectInfo e1 = Effects.GenerateEffect(unmask, 1, Targeting.Slot_SelfAll);
                EffectInfo e2 = Effects.GenerateEffect(unmask2, 1, Targeting.Slot_SelfAll);

                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { e1, e2 }, unit));
            }
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class PerformEffectImmediatePassiveAbility : BasePassiveAbilitySO
    {
        [Header("Passive Effects")]
        public EffectInfo[] effects;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            CombatManager.Instance.AddPrioritySubAction(new EffectAction(effects, caster));
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class SwapRandomZoneEffectHideIntent : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo move = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 6, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
            CombatManager.Instance.AddPrioritySubAction(new EffectAction(new EffectInfo[] { move }, caster));
            exitAmount = 0;
            return true;
        }
    }
    public class ApplyFireSlotEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Field = StatusField.OnFire;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class CustomApplyFireSlotEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }
            for (int i = 0; i < targets.Length; i++)
            {
                entryVariable = UnityEngine.Random.Range(1, 4);
                if (UnityEngine.Random.Range(0, 100) < 5)
                    entryVariable = UnityEngine.Random.Range(4, 10);
                if (targets[i].HasUnit)
                {
                    if (targets[i].Unit is CharacterCombat character)
                    {
                        if (character._currentName == "Cranes")
                        {
                            entryVariable = 10;
                        }
                    }
                }
                AnimationVisualsEffect animYAY = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animYAY._animationTarget = Targeting.Slot_SelfAll;
                animYAY._visuals = ((AnimationVisualsEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("DemonCore_SW")).effects[0].effect)._visuals;
                AnimationVisualsEffect animBOO = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animBOO._animationTarget = Targeting.Slot_SelfAll;
                animBOO._visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals; ;
                EffectInfo fire = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), entryVariable, Targeting.Slot_Front);
                EffectInfo selfFire = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Targeting.Slot_SelfAll);
                EffectInfo animIS = Effects.GenerateEffect(animBOO, 1, Targeting.Slot_SelfAll);
                if (entryVariable > 3)
                    animIS.effect = animYAY;
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { animIS, fire, selfFire }, caster));
                exitAmount += entryVariable;
            }

            return exitAmount > 0;
        }
    }
    public class CustomAddTurnToTimelineEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter || entryVariable <= 0)
            {
                return false;
            }

            AnimationVisualsEffect animBOO = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animBOO._animationTarget = Targeting.Slot_SelfAll;
            animBOO._visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals;
            AnimationVisualsEffect animYAY = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animYAY._animationTarget = Targeting.Slot_SelfAll;
            animYAY._visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;
            EffectInfo addTurn = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfAll);
            EffectInfo animIS = Effects.GenerateEffect(animYAY, 1, Targeting.Slot_SelfAll);
            EffectInfo animNOT = Effects.GenerateEffect(animBOO, 1, Targeting.Slot_SelfAll);

            if (UnityEngine.Random.Range(0, 100) < 69)
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(new EffectInfo[] { animIS, addTurn }, caster));
            else
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(new EffectInfo[] { animNOT }, caster));

            return true;
        }
    }
}