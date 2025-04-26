using FMODUnity;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class BasicEffects
    {
        public static DamageEffect Indirect
        {
            get
            {
                DamageEffect ret = ScriptableObject.CreateInstance<DamageEffect>();
                ret._indirect = true;
                return ret;
            }
        }
        public static DamageEffect ShieldPierce
        {
            get
            {
                DamageEffect ret = ScriptableObject.CreateInstance<DamageEffect>();
                ret._ignoreShield = true;
                return ret;
            }
        }
        public static DamageEffect ExitDamage
        {
            get
            {
                DamageEffect ret = ScriptableObject.CreateInstance<DamageEffect>();
                ret._usePreviousExitValue = true;
                return ret;
            }
        }
        public static HealEffect ExitHeal
        {
            get
            {
                HealEffect ret = ScriptableObject.CreateInstance<HealEffect>();
                ret.usePreviousExitValue = true;
                return ret;
            }
        }
        public static SwapToOneSideEffect GoLeft
        {
            get
            {
                SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goLeft._swapRight = false;
                return goLeft;
            }
        }
        public static SwapToOneSideEffect GoRight
        {
            get
            {
                SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goLeft._swapRight = true;
                return goLeft;
            }
        }
        public static ExtraVariableForNextEffect Empty
        {
            get
            {
                return ScriptableObject.CreateInstance<ExtraVariableForNextEffect>();
            }
        }
        public static AnimationVisualsEffect GetVisuals(string name, bool characterAbil, BaseCombatTargettingSO target)
        {
            AnimationVisualsEffect ret = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            ret._animationTarget = target;
            if (CustomVisuals.Visuals != null && CustomVisuals.Visuals.ContainsKey(name))
            {
                ret._visuals = CustomVisuals.GetVisuals(name);
                return ret;
            }
            if (characterAbil) ret._visuals = LoadedAssetsHandler.GetCharacterAbility(name).visuals;
            else ret._visuals = LoadedAssetsHandler.GetEnemyAbility(name).visuals;
            return ret;
        }
        public static PlaySoundEffect PlaySound(string sound)
        {
            PlaySoundEffect ret = ScriptableObject.CreateInstance<PlaySoundEffect>();
            ret.Audio = sound;
            return ret;
        }
        public static PreviousEffectCondition DidThat(bool didit, int prev = 1)
        {
            PreviousEffectCondition ret = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            ret.previousAmount = prev;
            ret.wasSuccessful = didit;
            return ret;
        }
        public static DirectDeathEffect Die(bool obliterate = false)
        {
            DirectDeathEffect ret = ScriptableObject.CreateInstance<DirectDeathEffect>();
            ret._obliterationDeath = obliterate;
            return ret;
        }
        public static CasterStoredValueChangeEffect ChangeValue(string value, bool increase)
        {
            CasterStoredValueChangeEffect ret = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            ret.m_unitStoredDataID = value;
            ret._increase = increase;
            ret._minimumValue = 0;
            return ret;
        }
        public static GenerateColorManaEffect GenPigment(ManaColorSO color)
        {
            GenerateColorManaEffect ret = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            ret.mana = color;
            return ret;
        }
        public static ConsumeAllColorManaEffect RemPigment(ManaColorSO color)
        {
            ConsumeAllColorManaEffect ret = ScriptableObject.CreateInstance<ConsumeAllColorManaEffect>();
            ret._consumeMana = color;
            return ret;
        }
        public static AddPassiveEffect AddPassive(BasePassiveAbilitySO passive)
        {
            AddPassiveEffect ret = ScriptableObject.CreateInstance<AddPassiveEffect>();
            ret._passiveToAdd = passive;
            return ret;
        }
        public static CasterStoredValueSetEffect SetStoreValue(string value)
        {
            CasterStoredValueSetEffect ret = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            ret._valueName = value;
            return ret;
        }
    }
    public class PlaySoundEffect : EffectSO
    {
        public string Audio;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            Vector3 loc = default(Vector3);
            try
            {
                if (!caster.IsUnitCharacter)
                {
                    loc = stats.combatUI._enemyZone._enemies[caster.FieldID].FieldEntity.Position;
                }
            }
            catch { }
            //RuntimeManager.PlayOneShot(Audio, loc);
            CombatManager.Instance.AddUIAction(new PlaySoundUIAction(Audio, loc));

            return true;
        }
    }
    public class PlaySoundUIAction : CombatAction
    {
        public string Audio;
        public Vector3 Location;
        public PlaySoundUIAction(string audio, Vector3 loc)
        {
            Audio = audio;
            Location = loc;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            RuntimeManager.PlayOneShot(Audio, Location);
            yield return null;
        }
    }
    public class CasterStoredValueSetEffect : EffectSO
    {
        [SerializeField]
        public string _valueName = UnitStoredValueNames_GameIDs.PunchA.ToString();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            caster.TryGetStoredData(_valueName, out var holder);
            exitAmount = entryVariable;
            holder.m_MainData = exitAmount;
            return true;
        }
    }
}