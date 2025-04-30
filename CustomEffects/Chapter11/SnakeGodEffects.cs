using BrutalAPI;
using DG.Tweening;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using static UnityEngine.Random;

//call SnakeGodManager.Setup() in awake

namespace SaltEnemies_Reseasoned
{
    public class SnakeGodPassive : BasePassiveAbilitySO
    {
        public override bool DoesPassiveTrigger => true;
        public override bool IsPassiveImmediate => true;

        public override void TriggerPassive(object sender, object args)
        {
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            LastAttacker = -1;
            AllAttackers = new List<int>();
            unit.SimpleSetStoredValue(SnakeGodManager.Last, 0);
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            LastAttacker = -1;
            AllAttackers = new List<int>();
            unit.SimpleSetStoredValue(SnakeGodManager.Last, 0);
        }

        public int LastAttacker = -1;
        public List<int> AllAttackers;
    }
    public static class SnakeGodManager
    {
        public static DamageInfo Damage(Func<EnemyCombat, int, IUnit, string, int, bool, bool, bool, string, DamageInfo> orig, EnemyCombat self, int amount, IUnit killer, string deathType, int targetSlotOffset, bool addHealthMana, bool directDamage, bool ignoresShield, string specialDamage)
        {
            DamageInfo ret = orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
            if (ret.damageAmount > 0 && killer != null && killer.IsUnitCharacter)
            {
                foreach (BasePassiveAbilitySO passive in self.PassiveAbilities)
                {
                    if (passive is SnakeGodPassive snakey)
                    {
                        if (killer is CharacterCombat chara)
                        {
                            int id = chara.ID;
                            if (id == 0) id = -1;
                            snakey.LastAttacker = chara.ID;
                            self.SimpleSetStoredValue(Last, id);
                            if (!snakey.AllAttackers.Contains(chara.ID)) snakey.AllAttackers.Add(chara.ID);
                        }
                        if (killer != null)
                        {
                            killer.ApplyStatusEffect(StatusField.Scars, 1);
                        }
                    }
                }
            }
            return ret;
        }
        public static string Last = "SnakeGod_Last_PA";
        public static void Setup()
        {
            UnitStoreData_SnakeGodTargetSO target = ScriptableObject.CreateInstance<UnitStoreData_SnakeGodTargetSO>();
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Last))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Last] = target;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(target._UnitStoreDataID, target);
            
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.Damage), ~BindingFlags.Default), typeof(SnakeGodManager).GetMethod(nameof(Damage), ~BindingFlags.Default));
        }
    }
    public class UnitStoreData_SnakeGodTargetSO : UnitStoreData_BasicSO
    {
        public override bool TryGetUnitStoreDataToolTip(UnitStoreDataHolder holder, out string result)
        {
            result = GenerateString(holder.m_MainData);
            return result != "";
        }

        public string GenerateString(int value)
        {
            if (value == 0) return "";
            CharacterCombat chara = null;
            int check = value;
            if (check == -1) check = 0;
            foreach (CharacterCombat ch in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (ch.ID == check) chara = ch;
            }
            if (chara == null) return "";
            string str2 = "Eyes on: " + chara._currentName;
            string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.yellow) + ">";
            string str4 = "</color>";
            return str3 + str2 + str4;
        }
    }
    public class Targetting_BySnakeGod : BaseCombatTargettingSO
    {
        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => false;

        public bool GetAll;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            if (isCasterCharacter) return ret.ToArray();
            TargetSlotInfo self = slots.GetEnemyTargetSlot(casterSlotID, 0);
            if (!self.HasUnit) return ret.ToArray();
            TargetSlotInfo[] all = slots.GetAllUnitTargetSlots(true, false);
            foreach (BasePassiveAbilitySO passive in (self.Unit as IPassiveEffector).PassiveAbilities)
            {
                if (passive is SnakeGodPassive snakey)
                {
                    foreach (TargetSlotInfo target in all)
                    {
                        if (target.HasUnit)
                        {
                            if (GetAll)
                            {
                                if (snakey.AllAttackers.Contains(target.Unit.ID))
                                {
                                    ret.Add(target);
                                }
                            }
                            else
                            {
                                if (target.Unit.ID == snakey.LastAttacker)
                                {
                                    ret.Add(target);
                                }
                            }
                        }
                    }
                }
            }
            return ret.ToArray();
        }

        public static Targetting_BySnakeGod Create(bool getAll)
        {
            Targetting_BySnakeGod ret = ScriptableObject.CreateInstance<Targetting_BySnakeGod>();
            ret.GetAll = getAll;
            return ret;
        }
    }
    public class AbilitySelector_SnakeGod : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string eatTear = "Eat Tears idk i mightve removed this ability tbh idr";

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
            int pigs = 0;
            foreach (ManaBarSlot mana in CombatManager.Instance._stats.MainManaBar.ManaBarSlots)
            {
                if (!mana.IsEmpty && mana.ManaColor == Pigments.Blue) pigs++;
            }
            return pigs <= 2 && name == this.eatTear;
        }
    }
}
