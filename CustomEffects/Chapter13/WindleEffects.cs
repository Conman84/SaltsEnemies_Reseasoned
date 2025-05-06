using System;
using System.Collections.Generic;
using System.Text;
using Tools;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect : EffectSO
    {
        [Header("Rank Data")]
        [CharacterRef]
        [SerializeField]
        public string _characterCopy = "";

        [SerializeField]
        public int _rank;

        [SerializeField]
        public NameAdditionLocID _nameAddition;

        [SerializeField]
        public bool _permanentSpawn;

        [SerializeField]
        public bool _usePreviousAsHealth;

        [SerializeField]
        public WearableStaticModifierSetterSO[] _extraModifiers;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CharacterSO charcater = LoadedAssetsHandler.GetCharacter(_characterCopy);
            if (charcater == null || charcater.Equals(null))
            {
                return false;
            }

            int currentHealth = caster.CurrentHealth;
            int[] abilitiesUsed = charcater.GenerateAbilities();
            WearableStaticModifiers modifiers = new WearableStaticModifiers();
            HealthColorChange_Wearable_SMS yes = ScriptableObject.CreateInstance<HealthColorChange_Wearable_SMS>();
            yes._healthColor = caster.HealthColor;
            MaxHealthChange_Wearable_SMS ha = ScriptableObject.CreateInstance<MaxHealthChange_Wearable_SMS>();
            ha.maxHealthChange = caster.MaximumHealth - charcater.GetMaxHealth(_rank);
            WearableStaticModifierSetterSO[] extraModifiers = new WearableStaticModifierSetterSO[] { yes, ha };
            for (int i = 0; i < extraModifiers.Length; i++)
            {
                extraModifiers[i].OnAttachedToCharacter(modifiers, charcater, _rank);
            }

            string nameAdditionData = LocUtils.GameLoc.GetNameAdditionData(_nameAddition);
            for (int j = 0; j < entryVariable; j++)
            {
                CombatManager.Instance.AddSubAction(new SpawnCharacterAction(charcater, caster.SlotID, trySpawnAnyways: true, nameAdditionData, _permanentSpawn, _rank, abilitiesUsed, currentHealth, modifiers));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
    public class HasSpaceCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return CombatManager.Instance._stats.CharactersOnField.Values.Count < 5;
        }
    }
}
