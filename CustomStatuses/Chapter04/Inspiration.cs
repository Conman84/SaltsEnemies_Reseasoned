using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Inspiration
    {
        public static string StatusID => "Inspiration_ID";
        public static string Intent => "Status_Inspiration";
        public static InspirationSE_SO Object;
        public static string Multiattack => "Inspiration_Multiattack_SO";
        public static string Prevent => "Inspiration_SO";
        public static string Passive => "Inspiration_PA";
        public static BasePassiveAbilitySO Inspired;
    }

    public class InspirationSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
            if (caller is IUnit unit)
            {
                if (unit.IsUnitCharacter) CombatManager.Instance.AddRootAction(new PartyMemberInspirationApplicationAction(unit));
                else CombatManager.Instance._stats.timeline.TryAddNewExtraEnemyTurns(unit as EnemyCombat, 1);
            }
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
        }
        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit && unit.IsUnitCharacter && unit.SimpleGetStoredValue(Inspiration.Multiattack) > 0)
            {
                if (unit.RefreshAbilityUse())
                {
                    unit.SimpleSetStoredValue(Inspiration.Multiattack, unit.SimpleGetStoredValue(Inspiration.Multiattack) - 1);
                }
            }
        }
        public override bool TryUseNumberOnPopUp => false;
        public override int MinimumRequiredToApply => 0;
        public override StatusEffect_Holder GenerateHolder(int content, int restrictor)
        {
            return new StatusEffect_Holder(this);
        }
        public override int GetStatusContent(StatusEffect_Holder holder)
        {
            return 1;
        }
        public override bool CanBeRemoved(StatusEffect_Holder holder)
        {
            return true;
        }
        public override string DisplayText(StatusEffect_Holder holder)
        {
            string text = "";
            if (holder.Restrictor > 0)
            {
                text = text + "(" + holder.Restrictor + ")";
            }

            return text;
        }
        public override bool TryAddContent(StatusEffect_Holder holder, int content, int restrictor)
        {
            return false;
        }
        public override bool TryIncreaseContent(StatusEffect_Holder holder, int amount)
        {
            return false;
        }
        public override int JustRemoveAllContent(StatusEffect_Holder holder)
        {
            return 0;
        }
    }

    public class RemoveInspirationAction : CombatAction
    {
        public static List<int> Charas;
        public static List<int> Enemies;
        public int ID;
        public bool IsChara;
        public bool Skip;

        public RemoveInspirationAction(int id, bool ischara)
        {
            ID = id;
            IsChara = ischara;
            if (IsChara)
            {
                if (Charas == null) Charas = new List<int>();
                if (Charas.Contains(ID)) Skip = true;
                else Charas.Add(ID);
            }
            else
            {
                if (Enemies == null) Enemies = new List<int>();
                if (Enemies.Contains(ID)) Skip = true;
                else Enemies.Add(ID);
            }
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (Skip) yield break;
            else
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (Charas.Contains(chara.ID))
                    {
                        chara.RemoveStatusEffect(Inspiration.StatusID);
                        if (chara.UnitTypes.Contains(Inspiration.Passive)) chara.TryRemovePassiveAbility(Inspiration.Passive);
                    }
                }
                Charas.Clear();
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (Enemies.Contains(enemy.ID))
                    {
                        enemy.RemoveStatusEffect(Inspiration.StatusID);
                        if (enemy.UnitTypes.Contains(Inspiration.Passive)) enemy.TryRemovePassiveAbility(Inspiration.Passive);
                    }
                }
                Enemies.Clear();
            }
        }
    }
    public class ApplyInspirationAction : CombatAction
    {
        public static List<int> Charas;
        public static List<int> Enemies;
        public int ID;
        public bool IsChara;
        public bool Skip;

        public ApplyInspirationAction(int id, bool ischara)
        {
            ID = id;
            IsChara = ischara;
            if (IsChara)
            {
                if (Charas == null) Charas = new List<int>();
                if (Charas.Contains(ID)) Skip = true;
                else Charas.Add(ID);
            }
            else
            {
                if (Enemies == null) Enemies = new List<int>();
                if (Enemies.Contains(ID)) Skip = true;
                else Enemies.Add(ID);
            }
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (Skip) yield break;
            if (Inspiration.Object == null || Inspiration.Object.Equals(null)) Debug.LogError("inspiration null");
            else
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (Charas.Contains(chara.ID))
                    {
                        chara.ApplyStatusEffect(Inspiration.Object, 1);
                        if (chara.UnitTypes.Contains(Inspiration.Passive)) if (Inspiration.Inspired != null && !Inspiration.Inspired.Equals(null)) chara.AddPassiveAbility(Inspiration.Inspired);
                    }
                }
                Charas.Clear();
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (Enemies.Contains(enemy.ID))
                    {
                        enemy.ApplyStatusEffect(Inspiration.Object, 1);
                        if (enemy.UnitTypes.Contains(Inspiration.Passive)) if (Inspiration.Inspired != null && !Inspiration.Inspired.Equals(null)) enemy.AddPassiveAbility(Inspiration.Inspired);
                    }
                }
                Enemies.Clear();
            }
        }
    }
    public class PartyMemberInspirationApplicationAction : CombatAction
    {
        public IUnit unit;
        public PartyMemberInspirationApplicationAction(IUnit unit)
        {
            this.unit = unit;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (!stats.IsPlayerTurn)
            {
                unit.SimpleSetStoredValue(Inspiration.Multiattack, unit.SimpleGetStoredValue(Inspiration.Multiattack) + 1);
            }
            else
            {
                if (!unit.RefreshAbilityUse())
                {
                    unit.SimpleSetStoredValue(Inspiration.Multiattack, unit.SimpleGetStoredValue(Inspiration.Multiattack) + 1);
                }
            }
            yield return null;
        }
    }
}
