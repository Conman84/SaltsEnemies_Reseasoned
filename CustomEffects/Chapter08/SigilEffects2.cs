using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class AddPassiveCopyEffect : AddPassiveEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _passiveToAdd = ScriptableObject.Instantiate(_passiveToAdd);
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class CasterSetSigilPassiveEffect : EffectSO
    {
        public static Sprite Blue;
        public static Sprite Red;
        public static Sprite Green;
        public static Sprite Purple;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (Blue == null || Blue.Equals(null)) Blue = ResourceLoader.LoadSprite("sigilPassive.png");
            if (Red == null || Red.Equals(null)) Red = ResourceLoader.LoadSprite("SigilP_Red.png");
            if (Green == null || Green.Equals(null)) Green = ResourceLoader.LoadSprite("SigilP_Green.png");
            if (Purple == null || Purple.Equals(null)) Purple = ResourceLoader.LoadSprite("SigilP_Purple.png");
            exitAmount = 0;
            BasePassiveAbilitySO passive;
            if (caster is EnemyCombat enemy && enemy.TryGetPassiveAbility(SigilManager.Sigil, out passive))
            {
                switch (entryVariable)
                {
                    case 1:
                        passive._enemyDescription = "All enemies will move Left or Right on receiving direct damage or on performing an ability.\nAt the start of each turn, reset this enemy's Sigil.";
                        passive._characterDescription = "All party members will move Left or Right on receiving direct damage or on performing an ability.\nAt the start of each turn, reset this party member's Sigil.";
                        passive.passiveIcon = Blue;
                        break;
                    case 2:
                        passive._enemyDescription = "All enemies will deal a third of this enemy's current health as additional damage.\nAt the start of each turn, reset this enemy's Sigil.";
                        passive._characterDescription = "All party members will deal a third of this party member's current health as additional damage.\nAt the start of each turn, reset this party member's Sigil.";
                        passive.passiveIcon = Red;
                        break;
                    case 3:
                        passive._enemyDescription = "This enemy is immune to damage.\nAll enemies will produce 1 additional pigment of their health color when damaged.\nAt the start of each turn, reset this enemy's Sigil.";
                        passive._characterDescription = "This party member is immune to damage.\nAll party members will produce 1 additional pigment of their health color when damaged.\nAt the start of each turn, reset this party member's Sigil.";
                        passive.passiveIcon = Green;
                        break;
                    default:
                        passive._enemyDescription = "At the start of each turn, reset this enemy's Sigil.";
                        passive._characterDescription = "At the start of each turn, reset this party member's Sigil.";
                        passive.passiveIcon = Purple;
                        break;
                }
                return true;
            }
            else if (caster is CharacterCombat chara && chara.TryGetPassiveAbility(SigilManager.Sigil, out passive))
            {
                switch (entryVariable)
                {
                    case 1:
                        passive._enemyDescription = "All enemies will move Left or Right on receiving direct damage or on performing an ability.\nAt the start of each turn, reset this enemy's Sigil.";
                        passive._characterDescription = "All party members will move Left or Right on receiving direct damage or on performing an ability.\nAt the start of each turn, reset this party member's Sigil.";
                        passive.passiveIcon = Blue;
                        break;
                    case 2:
                        passive._enemyDescription = "All enemies will deal a third of this enemy's current health as additional damage.\nAt the start of each turn, reset this enemy's Sigil.";
                        passive._characterDescription = "All party members will deal a third of this party member's current health as additional damage.\nAt the start of each turn, reset this party member's Sigil.";
                        passive.passiveIcon = Red;
                        break;
                    case 3:
                        passive._enemyDescription = "This enemy is immune to damage.\nAt the start of each turn, reset this enemy's Sigil.";
                        passive._characterDescription = "This party member is immune to damage.\nAt the start of each turn, reset this party member's Sigil.";
                        passive.passiveIcon = Green;
                        break;
                    default:
                        passive._enemyDescription = "At the start of each turn, reset this enemy's Sigil.";
                        passive._characterDescription = "At the start of each turn, reset this party member's Sigil.";
                        passive.passiveIcon = Purple;
                        break;
                }
                return true;
            }
            return false;
        }
    }
    public class SigilSwapSideAction : CombatAction
    {
        public IUnit target;
        public IUnit sigil;
        public SigilSwapSideAction(IUnit target, IUnit sigil)
        {
            this.target = target;
            this.sigil = sigil;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (target == null || target.Equals(null)) yield break;
            if (target.CurrentHealth <= 0) yield break;

            if (sigil != null && !sigil.Equals(null))
            {
                BasePassiveAbilitySO passive = SigilManager.GetSigilPassive(sigil as IPassiveEffector);
                if (passive != null && !passive.Equals(null))
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(sigil.ID, sigil.IsUnitCharacter, passive._passiveName, passive.passiveIcon));
                }
            }

            ScriptableObject.CreateInstance<SwapToSidesEffect>().PerformEffect(stats, target, Targeting.Slot_SelfSlot.GetTargets(stats.combatSlots, target.SlotID, target.IsUnitCharacter), Targeting.Slot_SelfSlot.AreTargetSlots, 1, out int exi);

            yield return null;
        }
    }
}
