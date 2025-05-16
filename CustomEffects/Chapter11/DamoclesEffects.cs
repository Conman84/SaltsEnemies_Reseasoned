using BrutalAPI;
using UnityEngine;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public class DamoclesCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (UnityEngine.Random.Range(0, 100) > 50) return false;
            if (args is IntegerReference skinteger && skinteger.value > 0 && effector is IUnit unit)
            {
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(effector.ID, effector.IsUnitCharacter, "Closure", ResourceLoader.LoadSprite("DamoclesPassive.png")));
                unit.DirectDeath(null);
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals, Slots.Front, unit));
                TargetSlotInfo[] targets = Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter);
                int total = 0;
                foreach (TargetSlotInfo target in targets)
                {
                    if (target.HasUnit)
                    {
                        int amount = unit.WillApplyDamage(skinteger.value, target.Unit);
                        total += target.Unit.Damage(amount, unit, DeathType_GameIDs.Basic.ToString(), -1, true, true, false).damageAmount;
                    }
                }
                if (total > 0) unit.DidApplyDamage(total);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnCasterGibsEffect>(), 1, Slots.Self)
                }, unit));
                return false;
            }
            return false;
        }
    }
}
