using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class DoubleExtraAttackPassiveAbility : ExtraAttackPassiveAbility
    {
        [Header("ExtraAttack Data")]
        [SerializeField]
        public ExtraAbilityInfo _secondExtraAbility;
        public static string value => "21007348";

        public override void TriggerPassive(object sender, object args)
        {
            if (args is List<string> list && sender is IUnit unit && unit.SimpleGetStoredValue(value) > 0)
            {
                list.Add(_secondExtraAbility.ability?.name);
                unit.SimpleSetStoredValue(value, 0);
            }
            base.TriggerPassive(sender, args);
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            base.OnPassiveConnected(unit);
            unit.AddExtraAbility(_secondExtraAbility);
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            base.OnPassiveDisconnected(unit);
            unit.TryRemoveExtraAbility(_secondExtraAbility);
        }
    }
    public class AbilitySelector_YNL : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string Replace = "Replacement";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return CombatManager.Instance._stats.TurnsPassed < 1 && (name == this.Replace);
        }
    }
    public class IsUnitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets) if (target.HasUnit) exitAmount++;
            return exitAmount > 0;
        }
    }
    public static class ShockTherapyHandler
    {
        public static void TransformCharacterLowerLevel(this CharacterCombat self, CharacterSO character, bool fullyHeal, bool maintainMaxHealth, bool currentToMaxHealth)
        {
            self.RemoveAndDisconnectAllPassiveAbilities();
            self.Character = character;
            self.Name = self.Character.GetName();
            if (self.Rank > 0) self.Rank--;
            self.ClampedRank = self.Character.ClampRank(self.Rank + self.CharacterWearableModifiers.RankModifier);
            self.CurrencyMultiplier = self.CharacterWearableModifiers.CurrencyMultiplierModifier;
            if (!maintainMaxHealth)
            {
                self.MaximumHealth = self.Character.GetMaxHealth(self.ClampedRank);
            }

            if (currentToMaxHealth)
            {
                self.MaximumHealth = Mathf.Max(self.CurrentHealth, 1);
            }

            self.MaximumHealth = Mathf.Max(1, self.CharacterWearableModifiers.MaximumHealthModifier + self.MaximumHealth);
            self.HealthColor = (self.CharacterWearableModifiers.HasHealthColorModifier ? self.CharacterWearableModifiers.HealthColorModifier : self.Character.healthColor);
            self.CurrentHealth = (fullyHeal ? self.MaximumHealth : Mathf.Min(self.CurrentHealth, self.MaximumHealth));
            self.SetUpDefaultAbilities(updateUI: true);
            self.UnitTypes = self.Character.unitTypes.ToArray();
            self.Size = 1;
            self.DefaultPassiveAbilityInitialization();
        }
        public static bool TryTransformCharacterLowerLevel(this CombatStats self, int id, CharacterSO transformation, bool fullyHeal, bool maintainMaxHealth, bool currentToMaxHealth)
        {
            if (transformation == null || transformation.Equals(null))
            {
                return false;
            }

            if (!self.Characters.ContainsKey(id))
            {
                return false;
            }

            CharacterCombat characterCombat = self.Characters[id];
            if (!characterCombat.IsAlive)
            {
                return false;
            }

            characterCombat.TransformCharacterLowerLevel(transformation, fullyHeal, maintainMaxHealth, currentToMaxHealth);
            CombatManager.Instance.AddUIAction(new CharacterTransformUIAction(characterCombat, characterCombat.HealthColor, characterCombat.CurrentHealth, characterCombat.MaximumHealth));
            characterCombat.ConnectPassives();
            return true;
        }
    }
    public class ShockTherapyEffect : DamageEffect
    {
        public static string HasTransformed => "ShockTherapy_HasTransformed_A";
        public static CharacterSO getRandom()
        {
            CharacterSO ret = new List<CharacterSO>(LoadedAssetsHandler.LoadedCharacters.Values).GetRandom();
            for (int i = 0; i < 144; i++)
            {
                if (ret == null || ret.Equals(null)) ret = new List<CharacterSO>(LoadedAssetsHandler.LoadedCharacters.Values).GetRandom();
                else break;
            }
            return ret;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit is CharacterCombat chara)
                {
                    if (chara.SimpleGetStoredValue(HasTransformed) > 0)
                    {
                        CharacterSO c = getRandom();
                        for (int i = 0; i < 144 && (!c.HasRankedData || c.rankedData.Count < chara.Rank); i++) c = getRandom();
                        if (stats.TryTransformCharacterLowerLevel(chara.ID, c, false, false, false)) exitAmount++;
                        base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exi);
                    }
                    else
                    {
                        CharacterSO c = getRandom();
                        for (int i = 0; i < 144 && (!c.HasRankedData || c.rankedData.Count <= chara.Rank); i++) c = getRandom();
                        if (stats.TryTransformCharacter(chara.ID, c, false, false, false)) exitAmount++;
                        chara.SimpleSetStoredValue(HasTransformed, 1);
                    }
                    if (YNLHandler2.DoPerm)
                    {
                        YNLHandler2.Transforms.Add(chara.ID);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class LobotomySongEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (changeMusic != null)
            {
                try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("lobotomy song thread failed to shut down."); }
            }
            changeMusic = new System.Threading.Thread(GO);
            changeMusic.Start();
            return true;
        }

        public static System.Threading.Thread changeMusic;
        public static void GO()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("Lobotomized", out float num) == FMOD.RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 100; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Lobotomized", i);
                System.Threading.Thread.Sleep(50);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
    }
    public class RemoveAllStatusEffectsByAmountEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    if (targets[i].Unit is IStatusEffector effector)
                    {
                        exitAmount += effector.StatusEffects.Count;
                        targets[i].Unit.TryRemoveAllStatusEffects();
                    }
                    else exitAmount += targets[i].Unit.TryRemoveAllStatusEffects();
                }
            }

            return exitAmount > 0;
        }
    }
    public class ProcedureEffect : GenerateColorManaEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    mana = target.Unit.HealthColor;
                    if (base.PerformEffect(stats, caster, targets, areTargetSlots, target.Unit.CurrentHealth, out int exi))
                        exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
}
