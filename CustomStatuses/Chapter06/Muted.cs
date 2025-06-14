﻿using BrutalAPI;
using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tools;
using UnityEngine;

//call Muted.Add() in awake

namespace SaltEnemies_Reseasoned
{
    public static class Muted
    {
        public static string StatusID => "Muted_ID";
        public static string Intent => "Status_Muted";
        public static MutedSE_SO Object;
        public static void Add()
        {
            bool already = false;

            StatusEffectInfoSO LeftInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            LeftInfo.icon = ResourceLoader.LoadSprite("MutedIcon.png");
            LeftInfo._statusName = "Muted";
            LeftInfo._description = "This unit cannot use any ability other than \"Slap\". \nMuted decreases by 1 at the end of each turn.";
            LeftInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.DivineProtection_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            LeftInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.DivineProtection_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            LeftInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.DivineProtection_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            MutedSE_SO MutedSO = ScriptableObject.CreateInstance<MutedSE_SO>();
            MutedSO._StatusID = StatusID;
            MutedSO._EffectInfo = LeftInfo;
            Object = MutedSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID))
            {
                LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = MutedSO;
                already = true;
            }
            if (!LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(MutedSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("MutedIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            if (!LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);

            if (already) return;

            IDetour MutedCharactersIDetour = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.UseAbility), ~BindingFlags.Default), typeof(Muted).GetMethod(nameof(UseMutedAbilityChara), ~BindingFlags.Default));
            IDetour MutedEnemieIDetour = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.UseAbility), ~BindingFlags.Default), typeof(Muted).GetMethod(nameof(UseMutedAbilityEn), ~BindingFlags.Default));
        }
        public static void UseMutedAbilityChara(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            AbilitySO ability = self.CombatAbilities[abilityID].ability;
            if (self.ContainsStatusEffect(StatusID) && (ability._abilityName != "Slap" && ability.name != "Slap_A"))
            {
                try
                {
                    Vector3 loc = default(Vector3);
                    CombatStats stats = CombatManager.Instance._stats;
                    try
                    {
                        if (!self.IsUnitCharacter)
                        {
                            loc = stats.combatUI._characterZone._characters[self.FieldID].FieldEntity.Position;
                        }
                    }
                    catch { }
                    CombatManager.Instance.AddUIAction(new PlaySoundUIAction("event:/Hawthorne/Boowomp", loc));
                }
                catch { }
                StringReference args = new StringReference(ability.name);
                CombatManager.Instance.PostNotification(TriggerCalls.OnAbilityWillBeUsed.ToString(), self, args);
                CombatManager.Instance.AddRootAction(new StartAbilityCostAction(self.ID, filledCost));
                Debug.Log("is muted, used not slap");
                CombatManager.Instance.AddRootAction(new AddLuckyManaAction());
                CombatManager.Instance.AddRootAction(new EndAbilityAction(self.ID, self.IsUnitCharacter));
                self.CanUseAbilities = false;
                self.HasManuallyUsedAbilityThisTurn = true;
                self.UpdatePerformAbilityCounter();
                self.SetVolatileUpdateUIAction();
                return;
            }
            orig(self, abilityID, filledCost);
        }
        public static void UseMutedAbilityEn(Action<EnemyCombat, int> orig, EnemyCombat self, int abilitySlot)
        {
            if (abilitySlot >= self.Abilities.Count)
            {
                abilitySlot = self.Abilities.Count - 1;
            }
            AbilitySO ability = self.Abilities[abilitySlot].ability;
            if (self.ContainsStatusEffect(StatusID) && ability._abilityName != "Slap")
            {
                try
                {
                    Vector3 loc = default(Vector3);
                    CombatStats stats = CombatManager.Instance._stats;
                    try
                    {
                        if (!self.IsUnitCharacter)
                        {
                            loc = stats.combatUI._enemyZone._enemies[self.FieldID].FieldEntity.Position;
                        }
                    }
                    catch { }
                    CombatManager.Instance.AddUIAction(new PlaySoundUIAction("event:/Hawthorne/Boowomp", loc));
                }
                catch { }
                Debug.Log("is muted, used not slap");
                StringReference args = new StringReference(LoadedDBsHandler.AbilityDB._BasicSlapAbility.ability.name);
                CombatManager.Instance.PostNotification(TriggerCalls.OnAbilityWillBeUsed.ToString(), self, args);

                EffectInfo slap = Effects.GenerateEffect(ScriptableObject.CreateInstance<SlapEffect>(), 1, Targeting.Slot_SelfSlot);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { slap }, self));
                
                //CombatManager.Instance.AddRootAction(new EndAbilityAction(self.ID, self.IsUnitCharacter));
                
                return;
            }


            //camera exception
            if (self.UnitTypes.Contains("Camera"))
            {
                if (abilitySlot < 0 || abilitySlot >= self.Abilities.Count)
                {
                    Debug.LogError(self.Name + " cannot use ability in slot " + abilitySlot + ", it does not exist");
                    self.EndTurn();
                    return;
                }

                ability = self.Abilities[abilitySlot].ability;
                if (!self.CanUseAbility)
                {
                    Debug.LogError(self.Name + " cannot use " + ability.GetAbilityLocData().text + " probably due to stunned");
                    self.EndTurn();
                    return;
                }

                StringReference args = new StringReference(ability.name);
                CombatManager.Instance.PostNotification(TriggerCalls.OnAbilityWillBeUsed.ToString(), self, args);
                if (!DebugUtils.videoMode)
                {
                    CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(self.ID, self.IsUnitCharacter, ability.GetAbilityLocData().text));
                }

                CombatManager.Instance.AddRootAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, self));
                CombatManager.Instance.AddRootAction(new CameraCopyEffectAction(ability.effects, self));
                CombatManager.Instance.AddRootAction(new EndAbilityAction(self.ID, self.IsUnitCharacter));

                return;
            }

            orig(self, abilitySlot);
        }
    }
    public class MutedSE_SO : StatusEffect_SO
    {
        public ExtraAbilityInfo slapExtraAbil()
        {
            ExtraAbilityInfo slapAdd = new ExtraAbilityInfo();
            slapAdd.ability = LoadedAssetsHandler.GetCharacterAbility("Slap_A");
            slapAdd.cost = new ManaColorSO[1] { Pigments.Yellow };
            return slapAdd;
        }
        public override bool IsPositive => false;
        public string hasSlap => "HasSlap";

        public string addedSlap = "AddedSlap";
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (caller is CharacterCombat character)
            {
                //bool hasSlap = false;
                foreach (CombatAbility ability in character.CombatAbilities)
                {
                    if (ability.ability._abilityName == "Slap")
                    {
                        character.SimpleSetStoredValue(hasSlap, 1);
                    }
                }
                foreach (ExtraAbilityInfo ability in character.ExtraAbilities)
                {
                    if (ability.ability._abilityName == "Slap")
                    {
                        character.SimpleSetStoredValue(hasSlap, 1);
                    }
                }
                if (character.SimpleGetStoredValue(hasSlap) < 1)
                {
                    character.AddExtraAbility(slapExtraAbil());
                    //Debug.Log("added Slap");
                    character.SimpleSetStoredValue(addedSlap, 1);
                }
            }
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), caller);
            if (caller is CharacterCombat character && character.SimpleGetStoredValue(addedSlap) >= 1)
            {
                //Debug.Log("has receivd extra slap");
                foreach (ExtraAbilityInfo ability in character.ExtraAbilities)
                {
                    //Debug.Log("ability found");
                    if (ability.ability._abilityName == "Slap")
                    {
                        //Debug.Log("is slap");
                        character.TryRemoveExtraAbility(ability);
                        //Debug.Log("removed");
                        character.SimpleSetStoredValue(addedSlap, 0);
                        break;
                    }
                }
            }
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            this.ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class SlapEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
                return false;

            CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Slap"));
            AnimationVisualsEffect slapAnim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            slapAnim._visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
            slapAnim._animationTarget = Targeting.Slot_Front;
            EffectInfo anim = Effects.GenerateEffect(slapAnim, 1, Targeting.Slot_Front);
            DamageEffect slapDeath = ScriptableObject.CreateInstance<DamageEffect>();
            slapDeath._DeathTypeID = DeathType_GameIDs.Slap.ToString();
            EffectInfo slap = Effects.GenerateEffect(slapDeath, 1, Targeting.Slot_Front);
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { anim, slap }, caster));
            CombatManager.Instance.AddRootAction(new EndAbilityAction(caster.ID, caster.IsUnitCharacter));
            exitAmount++;
            return exitAmount > 0;
        }
    }
    public class ApplyMutedEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Muted.Object;
            if (Muted.Object == null || Muted.Object.Equals(null)) Debug.LogError("CALL \"Muted.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
