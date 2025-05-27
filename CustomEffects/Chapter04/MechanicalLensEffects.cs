using BrutalAPI;
using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using UnityEngine;

//Call EnemyRefresher.Setup(); in awake
//Call ModCamera.Setup(); in awake

namespace SaltEnemies_Reseasoned
{
    public static class CameraEffects
    {
        public static BasePassiveAbilitySO _defaultPassive;
        public static BasePassiveAbilitySO DefaultPassive
        {
            get
            {
                if (_defaultPassive == null)
                {
                    _defaultPassive = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    _defaultPassive.m_PassiveID = "DEFAULT_FUCKING_PASSIVE";
                    _defaultPassive._enemyDescription = "nothing.";
                }
                return _defaultPassive;
            }
        }
        public class PassiveHolder
        {
            public List<string> types;
            CharacterCombat chara;
            public PassiveHolder(BasePassiveAbilitySO[] passi, CharacterCombat chara = null)
            {
                this.types = new List<string>();
                foreach (BasePassiveAbilitySO pas in passi) types.Add(pas.m_PassiveID);
                if (chara != null) this.chara = chara;
            }
            public bool ContainsPassiveAbility(string ty) => types.Contains(ty);

            public bool ContainsPassiveAbility(string ty, out BasePassiveAbilitySO passive)
            {
                bool ret = types.Contains(ty);
                passive = null;
                try
                {
                    if (ret)
                    {
                        foreach (BasePassiveAbilitySO passi in chara.PassiveAbilities) if (passi.m_PassiveID == ty)
                            {
                                passive = passi;
                                return ret;
                            }
                    }
                    return ret;
                }
                catch (Exception ex)
                {
                    Debug.LogError("probably doesnt contain passive ability");
                    Debug.LogError(ex.ToString());
                    return false;
                }
            }
            public void Add(string ty) => types.Add(ty);
            public PassiveHolder randomOne()
            {
                if (types.Count <= 0) return this;
                string t = types[UnityEngine.Random.Range(0, types.Count)];
                types = new List<string>() { t };
                return this;
            }
            public PassiveHolder reduce(EnemyCombat to)
            {
                List<string> lit = new List<string>();
                foreach (string ty in types) if (!to.ContainsPassiveAbility(ty)) lit.Add(ty);
                types = lit;
                return this;
            }
        }
        public static void Ooga()
        {
            UnityEngine.Debug.Log("Booga");
        }
        public static string FavoritePictureIntent => "Misc_Picture";
        public static void Setup()
        {
            IDetour IDetourThingy = new Hook(typeof(EnemyCombatUIInfo).GetMethod(nameof(EnemyCombatUIInfo.RemoveAttack), ~BindingFlags.Default), typeof(CameraEffects).GetMethod(nameof(RemoveAttack), ~BindingFlags.Default));
            Intents.CreateAndAddCustom_Basic_IntentToPool(FavoritePictureIntent, ResourceLoader.LoadSprite("FavoritePicture.png"), Color.white);
        }
        public static List<Action<PassiveHolder, CharacterCombat, EnemyCombat>> OtherChecks;
        public static Dictionary<string, BasePassiveAbilitySO> DefaultPassiveAdding;
        public static void AddPassive(Action<PassiveHolder, CharacterCombat, EnemyCombat> passive)
        {
            if (OtherChecks == null) OtherChecks = new List<Action<PassiveHolder, CharacterCombat, EnemyCombat>>();
            OtherChecks.Add(passive);
        }
        public static void AddPassive(string id, BasePassiveAbilitySO passive = null, string enemyDesc = "")
        {
            if (DefaultPassiveAdding == null) DefaultPassiveAdding = new Dictionary<string, BasePassiveAbilitySO>();
            if (passive == null || passive.Equals(null)) passive = ScriptableObject.Instantiate(DefaultPassive);
            if (!passive.Equals(null) && passive != null) passive._enemyDescription = enemyDesc;
            if (!DefaultPassiveAdding.ContainsKey(id)) DefaultPassiveAdding.Add(id, passive);
        }
        public static void CopyPassiveDetails(this BasePassiveAbilitySO to, BasePassiveAbilitySO from)
        {
            to._passiveName = from._passiveName;
            to.passiveIcon = from.passiveIcon;
            to.m_PassiveID = from.m_PassiveID;
            to._enemyDescription = from._enemyDescription;
            to._characterDescription = from._characterDescription;
        }
        public static void AddPassives(CharacterCombat character, PassiveHolder passives, EnemyCombat enemy, bool OnlyHasnt = false, bool pickRandom = false)
        {
            if (OnlyHasnt) passives = passives.reduce(enemy);
            if (pickRandom) passives = passives.randomOne();
            BasePassiveAbilitySO passive;

            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Focus.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Skittish.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Slippery.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Infantile.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Infantile);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Parental.ToString()))
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.5f) enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1]);
                else enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").passiveAbilities[0]);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Unstable.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Constricting.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Formless.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Formless);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Pure.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Absorb.ToString()))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Forgetful.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Forgetful);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Withering.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Withering);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Overexert.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        enemy.AddPassiveAbility(Passives.OverexertGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) enemy.AddPassiveAbility(Passives.Overexert2);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.MultiAttack.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        enemy.AddPassiveAbility(Passives.MultiAttackGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) enemy.AddPassiveAbility(Passives.MultiAttack2);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Obscure.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Obscure);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Confusion.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Confusion);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Fleeting.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Dying.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Dying);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Inanimate.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Inanimate);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Inferno.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Enfeebled.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Enfeebled);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Immortal.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Immortal);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.TwoFaced.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Catalyst.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Anchored.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Anchored);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Delicate.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Delicate);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Leaky.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.PanicAttack.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Transfusion.ToString()))
            {
                enemy.AddPassiveAbility(Passives.Transfusion);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Abomination.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        enemy.AddPassiveAbility(Passives.AbominationGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) enemy.AddPassiveAbility(Passives.Abomination1);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.BoneSpurs.ToString(), out passive))
            {
                enemy.AddPassiveAbility(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Infestation.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        enemy.AddPassiveAbility(Passives.InfestationGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) enemy.AddPassiveAbility(Passives.Infestation1);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Masochism.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        enemy.AddPassiveAbility(Passives.MasochismGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) enemy.AddPassiveAbility(Passives.Masochism1);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Construct.ToString()))
            {
                RandomAbilityPassive instance1 = ScriptableObject.CreateInstance<RandomAbilityPassive>();
                instance1._passiveName = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._passiveName;
                instance1.passiveIcon = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0].passiveIcon;
                instance1.m_PassiveID = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0].m_PassiveID;
                instance1._enemyDescription = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._enemyDescription;
                instance1._characterDescription = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._characterDescription;
                instance1._triggerOn = new TriggerCalls[]
                {
                (TriggerCalls) 889532//old zensuke trigger
                };
                enemy.AddPassiveAbility(instance1);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Cashout.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        enemy.AddPassiveAbility(Passives.CashoutGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) enemy.AddPassiveAbility(Passives.Cashout);
            }
            if (DefaultPassiveAdding != null)
            {
                foreach (string ID in DefaultPassiveAdding.Keys)
                {
                    try
                    {
                        if (passives.ContainsPassiveAbility(ID, out passive))
                        {
                            if (DefaultPassiveAdding[ID].m_PassiveID == DefaultPassive.m_PassiveID)
                            {
                                if (DefaultPassiveAdding[ID]._enemyDescription != "nothing.") passive._enemyDescription = DefaultPassiveAdding[ID]._enemyDescription;
                                enemy.AddPassiveAbility(passive);
                            }
                            else enemy.AddPassiveAbility(DefaultPassiveAdding[ID]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("epic fail on passive ID " + ID);
                        Debug.LogError(ex.ToString());
                    }
                }
            }
            if (OtherChecks != null)
            {
                foreach (Action<PassiveHolder, CharacterCombat, EnemyCombat> action in OtherChecks)
                {
                    try
                    {
                        action(passives, character, enemy);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError("CameraEffects AddPassive action fail");
                        Debug.LogError(ex.ToString());
                    }
                }
            }
        }
        public static List<BasePassiveAbilitySO> GetPassives(CharacterCombat character, PassiveHolder passives, EnemyCombat enemy, bool OnlyHasnt = false, bool pickRandom = false)
        {
            if (OnlyHasnt) passives = passives.reduce(enemy);
            if (pickRandom) passives = passives.randomOne();
            BasePassiveAbilitySO passive;

            List<BasePassiveAbilitySO> ret = new List<BasePassiveAbilitySO>();

            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Focus.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Skittish.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Slippery.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Infantile.ToString()))
            {
                ret.Add(Passives.Infantile);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Parental.ToString()))
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.5f) ret.Add(LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1]);
                else ret.Add(LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").passiveAbilities[0]);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Unstable.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Constricting.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Formless.ToString()))
            {
                ret.Add(Passives.Formless);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Pure.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Absorb.ToString()))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Forgetful.ToString()))
            {
                ret.Add(Passives.Forgetful);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Withering.ToString()))
            {
                ret.Add(Passives.Withering);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Overexert.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        ret.Add(Passives.OverexertGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) ret.Add(Passives.Overexert2);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.MultiAttack.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        ret.Add(Passives.MultiAttackGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) ret.Add(Passives.MultiAttack2);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Obscure.ToString()))
            {
                ret.Add(Passives.Obscure);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Confusion.ToString()))
            {
                ret.Add(Passives.Confusion);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Fleeting.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Dying.ToString()))
            {
                ret.Add(Passives.Dying);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Inanimate.ToString()))
            {
                ret.Add(Passives.Inanimate);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Inferno.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Enfeebled.ToString()))
            {
                ret.Add(Passives.Enfeebled);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Immortal.ToString()))
            {
                ret.Add(Passives.Immortal);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.TwoFaced.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Catalyst.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Anchored.ToString()))
            {
                ret.Add(Passives.Anchored);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Delicate.ToString()))
            {
                ret.Add(Passives.Delicate);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Leaky.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.PanicAttack.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Transfusion.ToString()))
            {
                ret.Add(Passives.Transfusion);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Abomination.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        ret.Add(Passives.AbominationGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) ret.Add(Passives.Abomination1);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.BoneSpurs.ToString(), out passive))
            {
                ret.Add(passive);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Infestation.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        ret.Add(Passives.InfestationGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) ret.Add(Passives.Infestation1);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Masochism.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        ret.Add(Passives.MasochismGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) ret.Add(Passives.Masochism1);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Construct.ToString()))
            {
                RandomAbilityPassive instance1 = ScriptableObject.CreateInstance<RandomAbilityPassive>();
                instance1._passiveName = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._passiveName;
                instance1.passiveIcon = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0].passiveIcon;
                instance1.m_PassiveID = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0].m_PassiveID;
                instance1._enemyDescription = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._enemyDescription;
                instance1._characterDescription = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._characterDescription;
                instance1._triggerOn = new TriggerCalls[]
                {
                (TriggerCalls) 889532//old zensuke trigger
                };
                ret.Add(instance1);
            }
            if (passives.ContainsPassiveAbility(PassiveType_GameIDs.Cashout.ToString(), out passive))
            {
                bool cont = true;
                for (int i = -1; i < 13; i++)
                {
                    if (passive._passiveName.Contains("(" + i.ToString() + ")"))
                    {
                        ret.Add(Passives.CashoutGenerator(i));
                        cont = false;
                        break;
                    }
                }
                if (cont) ret.Add(Passives.Cashout);
            }
            if (DefaultPassiveAdding != null)
            {
                foreach (string ID in DefaultPassiveAdding.Keys)
                {
                    try
                    {
                        if (passives.ContainsPassiveAbility(ID, out passive))
                        {
                            if (DefaultPassiveAdding[ID].m_PassiveID == DefaultPassive.m_PassiveID)
                            {
                                if (DefaultPassiveAdding[ID]._enemyDescription != "nothing.") passive._enemyDescription = DefaultPassiveAdding[ID]._enemyDescription;
                                ret.Add(passive);
                            }
                            else ret.Add(DefaultPassiveAdding[ID]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("epic fail on passive ID " + ID);
                        Debug.LogError(ex.ToString());
                    }
                }
            }
            if (OtherChecks != null)
            {
                foreach (Action<PassiveHolder, CharacterCombat, EnemyCombat> action in OtherChecks)
                {
                    try
                    {
                        action(passives, character, enemy);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError("CameraEffects AddPassive action fail");
                        Debug.LogError(ex.ToString());
                    }
                }
            }

            return ret;
        }
        public static void RemoveAttack(Action<EnemyCombatUIInfo, int> orig, EnemyCombatUIInfo self, int attackID)
        {
            if (attackID >= self.Abilities.Count)
            {
                attackID = self.Abilities.Count - 1;
            }
            orig(self, attackID);
        }
    }
    public class MoveToClosestTargetEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            int distance = 999;
            List<int> targetSlots = new List<int>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int checkThis = caster.SlotID - target.SlotID;
                    if (checkThis < 0)
                    {
                        checkThis *= -1;
                    }
                    if (distance > 100)
                    {
                        distance = checkThis;
                        targetSlots.Clear();
                        targetSlots.Add(target.SlotID);
                    }
                    else if (checkThis < distance)
                    {
                        distance = checkThis;
                        targetSlots.Clear();
                        targetSlots.Add(target.SlotID);
                    }
                    else if (checkThis == distance)
                    {
                        distance = checkThis;
                        targetSlots.Add(target.SlotID);
                    }
                    if (distance < 0)
                    {
                        distance *= -1;
                    }
                }
            }
            if (targetSlots.Count <= 0)
            {
                return false;
            }
            int TargetSlot = targetSlots[UnityEngine.Random.Range(0, targetSlots.Count)];
            if (TargetSlot == caster.SlotID)
            {
                return true;
            }
            else if (TargetSlot < caster.SlotID)
            {
                SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goLeft._swapRight = false;
                EffectInfo effort1 = Effects.GenerateEffect(goLeft, 1, Targeting.Slot_SelfSlot);
                List<EffectInfo> effects = new List<EffectInfo>();
                for (int i = 0; i < (caster.SlotID - TargetSlot); i++)
                {

                    effects.Add(effort1);

                }
                CombatManager.Instance.AddSubAction(new EffectAction(effects.ToArray(), caster));
                return true;
            }
            else if (TargetSlot > caster.SlotID)
            {
                SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goRight._swapRight = true;
                EffectInfo effort1 = Effects.GenerateEffect(goRight, 1, Targeting.Slot_SelfSlot);
                List<EffectInfo> effects = new List<EffectInfo>();
                for (int i = 0; i < (TargetSlot - caster.SlotID); i++)
                {

                    effects.Add(effort1);

                }
                CombatManager.Instance.AddSubAction(new EffectAction(effects.ToArray(), caster));
                return true;
            }


            return exitAmount > 0;
        }
    }
    public class CopyFirstTargetDetailsEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (targets.Length <= 0) return false;
            if (!targets[0].HasUnit)
            {
                return false;
            }
            if (UnityEngine.Random.Range(0f, 1f) < 0.33f) CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Say \"Cheese!\""));
            else if (UnityEngine.Random.Range(0f, 1f) < 0.5f) CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Smile for the Camera!"));
            else CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Say \"Fuzzy Pickles\"~!"));
            CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(CustomVisuals.GetVisuals("Salt/Lens"), Targeting.Slot_Front, caster));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            if (caster.MaximumHealth != targets[0].Unit.MaximumHealth) CombatManager.Instance.AddUIAction(new PlayHealthColorSoundUIAction());
            if (caster.MaximizeHealth(targets[0].Unit.MaximumHealth))
            {
                exitAmount++;
            }
            if (caster.CurrentHealth < caster.MaximumHealth) caster.SetHealthTo(caster.MaximumHealth);
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            if (caster.ChangeHealthColor(targets[0].Unit.HealthColor))
                exitAmount++;
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            if (targets[0].Unit is CharacterCombat character && caster is EnemyCombat enemy)
            {
                string namae = "Image of ";
                namae += character._currentName;
                enemy._currentName = namae;
                string descp = namae;
                descp += " will perforn an extra ability \"Lens Flash\" each turn.";
                enemy.PassiveAbilities[0]._enemyDescription = descp;
                try
                {
                    foreach (EnemyCombatUIInfo enemyInfo in stats.combatUI._enemiesInCombat.Values)
                    {
                        if (enemyInfo.SlotID == enemy.SlotID)
                        {
                            enemyInfo.Name = namae;
                            enemyInfo.Passives[0]._enemyDescription = descp;
                        }
                    }
                }
                catch
                {
                    Debug.LogError("camera name change fail");
                }


                exitAmount++;
                try
                {
                    CameraEffects.AddPassives(character, new CameraEffects.PassiveHolder(character.PassiveAbilities.ToArray(), character), enemy);
                }
                catch (Exception ex)
                {
                    Debug.LogError("steal passives fail");
                    Debug.LogError(ex.ToString());
                }
            }
            CombatManager.Instance.AddUIAction(new PlayHealthColorSoundUIAction());
            return exitAmount > 0;
        }
    }
    public class StealRandomPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            try
            {
                if (caster is EnemyCombat enemy) foreach (TargetSlotInfo target in targets) if (target.HasUnit && target.Unit is CharacterCombat chara) CameraEffects.AddPassives(chara, new CameraEffects.PassiveHolder(chara.PassiveAbilities.ToArray(), chara), enemy, true, true);
            }
            catch
            {
                Debug.LogError("steal passive fail");
            }
            return true;
        }
    }
    public class RemoveFavoritePictureEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            if (caster.SimpleGetStoredValue("Rem_Fav_Pic") <= 0)
            {
                caster.SimpleSetStoredValue("Rem_Fav_Pic", 1);
                return false;
            }
            caster.SimpleSetStoredValue("Rem_Fav_Pic", 0);
            if (caster is EnemyCombat enemy)
            {
                foreach (CombatAbility ability in enemy.Abilities)
                {
                    try
                    {
                        if (ability.ability.GetAbilityLocData().text == "Favorite Picture")
                        {
                            enemy.Abilities.Remove(ability);
                            foreach (int enID in stats.combatUI._enemiesInCombat.Keys)
                            {
                                EnemyCombatUIInfo enemyInfo;
                                if (stats.combatUI._enemiesInCombat.TryGetValue(enID, out enemyInfo))
                                {
                                    if (enemyInfo.SlotID == enemy.SlotID)
                                    {
                                        //enemyInfo.UpdateAttacks(enemy.Abilities.ToArray());
                                        stats.combatUI.TryUpdateAllEnemyAttacks(enemy.ID, enemy.Abilities.ToArray());
                                        stats.combatUI.TryUpdateEnemyIDInformation(enID);
                                    }
                                }
                            }
                            exitAmount++;
                            break;
                        }
                    }
                    catch
                    {
                        Debug.LogError("broke somehow. fuck if i know");
                    }
                }
                //UnityEngine.Debug.Log(enemy._currentName);
                //foreach (CombatAbility ability in enemy.Abilities)
                //{
                //    UnityEngine.Debug.Log(ability.ability._locAbilityData.text + " ; " + ability.ability._abilityName);
                //}
            }

            //Timeline
            if (!caster.IsUnitCharacter) CombatManager.Instance.AddUIAction(new RefreshEnemyInfoUIAction(caster.ID));
            return exitAmount > 0;
        }
    }
    public class StealAbilityEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            //CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "*Snap*"));
            try
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(CustomVisuals.GetVisuals("Salt/Lens"), Targeting.Slot_Front, caster));
                List<CombatAbility> abilToAdd = new List<CombatAbility>();

                foreach (TargetSlotInfo target in targets)
                {
                    if (target.HasUnit)
                    {
                        if (target.Unit is CharacterCombat character)
                        {
                            if (character.CombatAbilities.Count > 0)
                            {
                                for (int i = 0; i < entryVariable; i++)
                                {
                                    CombatAbility addThis = character.CombatAbilities[UnityEngine.Random.Range(0, character.CombatAbilities.Count)];
                                    while (addThis.ability == null) addThis = character.CombatAbilities[UnityEngine.Random.Range(0, character.CombatAbilities.Count)];
                                    if (addThis.ability.priority == null)
                                    {
                                        addThis.ability.priority = ScriptableObject.CreateInstance<PrioritySO>();
                                        addThis.ability.priority.priorityValue = 0;
                                    }
                                    RaritySO rarity1 = ScriptableObject.CreateInstance<RaritySO>();
                                    rarity1.rarityValue = 10;
                                    rarity1.canBeRerolled = true;
                                    CombatAbility newThis = new CombatAbility(addThis.ability, rarity1);
                                    abilToAdd.Add(newThis);
                                }
                            }
                        }
                        if (target.Unit is EnemyCombat enemy)
                        {
                            if (enemy.Abilities.Count > 0)
                            {
                                for (int i = 0; i < entryVariable; i++)
                                {
                                    CombatAbility addThis = enemy.Abilities[UnityEngine.Random.Range(0, enemy.Abilities.Count)];
                                    while (addThis.ability == null) addThis = enemy.Abilities[UnityEngine.Random.Range(0, enemy.Abilities.Count)];
                                    if (addThis.ability.priority == null)
                                    {
                                        addThis.ability.priority = ScriptableObject.CreateInstance<PrioritySO>();
                                        addThis.ability.priority.priorityValue = 0;
                                    }
                                    RaritySO rarity1 = ScriptableObject.CreateInstance<RaritySO>();
                                    rarity1.rarityValue = 10;
                                    rarity1.canBeRerolled = true;
                                    CombatAbility newThis = new CombatAbility(addThis.ability, rarity1);
                                    abilToAdd.Add(newThis);
                                }
                            }
                        }
                    }
                }
                if (abilToAdd.Count <= 0)
                {
                    return false;
                }
                if (caster is EnemyCombat unitEN)
                {

                    CombatAbility lens = abilToAdd[0];
                    foreach (CombatAbility ability in (caster as EnemyCombat).Abilities)
                    {
                        if (ability.ability._abilityName == "Lens Flash")
                        {
                            lens = ability;
                        }
                    }
                    List<CombatAbility> abilities = unitEN.Abilities;
                    foreach (CombatAbility removeLens in new List<CombatAbility>(abilities))
                    {
                        if (removeLens.ability._abilityName == "Lens Flash")
                        {
                            abilities.Remove(removeLens);
                            //break;
                        }
                    }
                    //if (abilToAdd.Count > 0) abilities.Add(abilToAdd[0]);

                    foreach (CombatAbility ability in abilToAdd)
                    {
                        abilities.Add(ability);
                    }
                    if (lens != abilToAdd[0] && abilities.Count > 0)
                    {
                        List<CombatAbility> newList = new List<CombatAbility>();
                        //newList.Add(abilities[0]);

                        newList.Add(lens);
                        //for (int i = 1; i < abilToAdd.Count; i++) abilities.Add(abilToAdd[i]);
                        exitAmount++;
                        for (int i = 0; i < abilities.Count; i++)
                        {
                            newList.Add(abilities[i]);
                            //if (i == 0) 
                            exitAmount++;
                        }
                        unitEN.Abilities = newList;
                        CombatManager.Instance.AddUIAction(new RefreshEnemyInfoUIAction(unitEN.ID));
                        /*foreach (int enID in stats.combatUI._enemiesInCombat.Keys)
                        {
                            EnemyCombatUIInfo enemyInfo;
                            if (stats.combatUI._enemiesInCombat.TryGetValue(enID, out enemyInfo))
                            {
                                if (enemyInfo.SlotID == unitEN.SlotID)
                                {
                                    enemyInfo.Abilities = newList;
                                    enemyInfo.UpdateAttacks(enemyInfo.Abilities.ToArray());
                                    stats.combatUI.TryUpdateEnemyIDInformation(enID);
                                }
                            }
                        }*/
                    }

                    UnityEngine.Debug.Log(unitEN._currentName);
                    foreach (CombatAbility ability in unitEN.Abilities)
                    {
                        UnityEngine.Debug.Log(ability.ability._abilityName);
                    }

                }
                if (caster is CharacterCombat unitCH)
                {
                    foreach (CombatAbility ability in abilToAdd)
                    {
                        unitCH.CombatAbilities.Add(ability);
                        exitAmount++;
                    }
                }

                return exitAmount > 0;
            }
            catch
            {
                CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Somehow it broke. Whooops"));
                return false;
            }
        }
    }
    public class SayCheeseEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;


            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            EffectInfo effort1 = Effects.GenerateEffect(ScriptableObject.CreateInstance<CopyFirstTargetDetailsEffect>(), 1, Targeting.Slot_Front);
            EffectInfo effort2 = Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveFavoritePictureEffect>(), 1, Targeting.Slot_SelfSlot, didThat);
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { effort1, effort2 }, caster));


            return exitAmount > 0;
        }
    }
    public class TakePicEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;


            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            EffectInfo effort1 = Effects.GenerateEffect(ScriptableObject.CreateInstance<StealAbilityEffect>(), 1, Targeting.Slot_Front);
            EffectInfo effort2 = Effects.GenerateEffect(ScriptableObject.CreateInstance<PlayHealthColorSoundEffect>(), 1, Targeting.Slot_Front);
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { effort1, effort2 }, caster));


            return exitAmount > 0;
        }
    }
    public class LensFlashEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToClosestTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TakePicEffect>(), 1, Targeting.Slot_Front, didThat)
            }, caster));
            return true;
        }
    }
    public class FavoritePictureEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToClosestTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                //Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Lens", false, Targeting.Slot_Front), 1, null, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SayCheeseEffect>(), 1, Targeting.Slot_Front, didThat)
            }, caster));
            return true;
        }
    }
    public static class EnemyRefresher
    {
        public static string Did => "EnemyRefresherInternal";
        public static bool RefreshAbilityUse(Func<EnemyCombat, bool> orig, EnemyCombat self)
        {
            if (self.SimpleGetStoredValue(Did) > 20) return false;
            CombatManager.Instance._stats.timeline.TryAddNewExtraEnemyTurns(self, 1);
            return true;
        }
        public static void TryAddNewExtraEnemyTurns(Action<Timeline_TurnBase, ITurn, int> orig, Timeline_TurnBase self, ITurn unit, int turnsToAdd)
        {
            if (unit is IUnit iu && iu.AbilityCount <= 0) return;
            orig(self, unit, turnsToAdd);
        }
        public static void TryAddNewExtraEnemyRTTurns(Action<Timeline_RealTime, ITurn, int> orig, Timeline_RealTime self, ITurn unit, int turnsToAdd)
        {
            if (unit is IUnit iu && iu.AbilityCount <= 0) return;
            orig(self, unit, turnsToAdd);
        }
        public static bool ExhaustAbilityUse(Func<EnemyCombat, bool> orig, EnemyCombat self)
        {
            return CombatManager.Instance._stats.timeline.TryRemoveRandomEnemyTurns(self, 1) > 0;
        }
        public static bool TryPerformRandomAbility(Func<EnemyCombat, bool> orig, EnemyCombat self)
        {
            if (self.Abilities == null || self.AbilityCount <= 0)
            {
                return false;
            }

            int index = UnityEngine.Random.Range(0, self.AbilityCount);
            AbilitySO ability = self.Abilities[index].ability;
            CombatManager.Instance.AddSubAction(new ShowAttackInformationUIAction(self.ID, self.IsUnitCharacter, ability.GetAbilityLocData().text));
            CombatManager.Instance.AddSubAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, self));
            if (!self.UnitTypes.Contains("Camera")) CombatManager.Instance.AddSubAction(new EffectAction(ability.effects, self));
            else CombatManager.Instance.AddSubAction(new CameraCopyEffectAction(ability.effects, self));
            self.SetVolatileUpdateUIAction();
            return true;
        }
        public static bool TryPerformRandomGivenAbility(Func<EnemyCombat, AbilitySO, bool> orig, EnemyCombat self, AbilitySO selectedAbility)
        {
            CombatManager.Instance.AddSubAction(new ShowAttackInformationUIAction(self.ID, self.IsUnitCharacter, selectedAbility.GetAbilityLocData().text));
            CombatManager.Instance.AddSubAction(new PlayAbilityAnimationAction(selectedAbility.visuals, selectedAbility.animationTarget, self));
            if (!self.UnitTypes.Contains("Camera")) CombatManager.Instance.AddSubAction(new EffectAction(selectedAbility.effects, self));
            else CombatManager.Instance.AddSubAction(new CameraCopyEffectAction(selectedAbility.effects, self));
            self.SetVolatileUpdateUIAction();
            return true;
        }
        public delegate TResult PerformEffect<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, out T7 arg7);
        public static bool RemoveTurnPerformEffect(PerformEffect<RemoveTargetTimelineAbilityEffect, CombatStats, IUnit, TargetSlotInfo[], bool, int, int, bool> orig, RemoveTargetTimelineAbilityEffect self, CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool ret = orig(self, stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.IsTargetCharacterSlot)
                {
                    if (targetSlotInfo.Unit.ApplyStatusEffect(StatusField.Stunned, entryVariable))
                        exitAmount += Mathf.Max(1, entryVariable);
                }
            }
            return exitAmount > 0;

        }
        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.RefreshAbilityUse), ~BindingFlags.Default), typeof(EnemyRefresher).GetMethod(nameof(RefreshAbilityUse), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.ExhaustAbilityUse), ~BindingFlags.Default), typeof(EnemyRefresher).GetMethod(nameof(ExhaustAbilityUse), ~BindingFlags.Default));
            IDetour hook3 = new Hook(typeof(Timeline_TurnBase).GetMethod(nameof(Timeline_TurnBase.TryAddNewExtraEnemyTurns), ~BindingFlags.Default), typeof(EnemyRefresher).GetMethod(nameof(TryAddNewExtraEnemyTurns), ~BindingFlags.Default));
            IDetour hook4 = new Hook(typeof(Timeline_RealTime).GetMethod(nameof(Timeline_RealTime.TryAddNewExtraEnemyTurns), ~BindingFlags.Default), typeof(EnemyRefresher).GetMethod(nameof(TryAddNewExtraEnemyRTTurns), ~BindingFlags.Default));

            MethodInfo noVar = null;
            MethodInfo hasVar = null;
            MethodInfo[] list = typeof(EnemyCombat).GetMethods();
            foreach (MethodInfo check in list)
            {
                if (check.Name == nameof(EnemyCombat.TryPerformRandomAbility))
                {
                    if (check.GetParameters().Length <= 0) noVar = check;
                    else hasVar = check;
                }
            }

            IDetour hook5 = new Hook(noVar, typeof(EnemyRefresher).GetMethod(nameof(TryPerformRandomAbility), ~BindingFlags.Default));
            IDetour hook6 = new Hook(hasVar, typeof(EnemyRefresher).GetMethod(nameof(TryPerformRandomGivenAbility), ~BindingFlags.Default));

            IDetour hook7 = new Hook(typeof(RemoveTargetTimelineAbilityEffect).GetMethod(nameof(RemoveTargetTimelineAbilityEffect.PerformEffect), ~BindingFlags.Default), typeof(EnemyRefresher).GetMethod(nameof(RemoveTurnPerformEffect), ~BindingFlags.Default));
        }
    }
    public class RefreshEnemyInfoUIAction : CombatAction
    {
        public int ID;
        public RefreshEnemyInfoUIAction(int id)
        {
            ID = id;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            EnemyCombat yeah = null;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values) if (enemy.ID == ID) yeah = enemy;
            if (yeah != null)
            {
                foreach (int enID in stats.combatUI._enemiesInCombat.Keys)
                {
                    EnemyCombatUIInfo enemyInfo;
                    if (stats.combatUI._enemiesInCombat.TryGetValue(enID, out enemyInfo))
                    {
                        if (enemyInfo.SlotID == yeah.SlotID)
                        {
                            enemyInfo.Abilities = yeah.Abilities;
                            //enemyInfo.UpdateAttacks(enemyInfo.Abilities.ToArray());
                            stats.combatUI.TryUpdateAllEnemyAttacks(yeah.ID, yeah.Abilities.ToArray());
                            stats.combatUI.TryUpdateEnemyIDInformation(enID);
                        }
                    }
                }
            }
            yield return null;
        }
    }
    public class RandomAbilityPassive : BasePassiveAbilitySO
    {
        public static ExtraAbilityInfo GetRandomItemAbility()
        {
            //LoadedDBsHandler
            //CasterAddRandomExtraAbilityEffect effect = (LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility).connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect;
            Connection_PerformEffectPassiveAbility connection_PerformEffectPassiveAbility = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility;
            CasterAddRandomExtraAbilityEffect effect = connection_PerformEffectPassiveAbility.connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect;
            List<BasicAbilityChange_Wearable_SMS> changeWearableSmsList = new List<BasicAbilityChange_Wearable_SMS>(effect._slapData);
            List<ExtraAbility_Wearable_SMS> abilityWearableSmsList = new List<ExtraAbility_Wearable_SMS>(effect._extraData);
            int count1 = changeWearableSmsList.Count;
            int count2 = abilityWearableSmsList.Count;
            int index1 = UnityEngine.Random.Range(0, count1 + count2);
            ExtraAbilityInfo randomItemAbility;
            RaritySO rar = ScriptableObject.CreateInstance<RaritySO>();
            rar.canBeRerolled = true;
            rar.rarityValue = 5;
            if (index1 < changeWearableSmsList.Count)
            {
                BasicAbilityChange_Wearable_SMS changeWearableSms = changeWearableSmsList[index1];
                changeWearableSmsList.RemoveAt(index1);
                int num = count1 - 1;
                randomItemAbility = new ExtraAbilityInfo(changeWearableSms.BasicAbility);
            }
            else
            {
                int index2 = index1 - count1;
                ExtraAbility_Wearable_SMS abilityWearableSms = abilityWearableSmsList[index2];
                abilityWearableSmsList.RemoveAt(index2);
                int num = count2 - 1;
                randomItemAbility = new ExtraAbilityInfo(abilityWearableSms.ExtraAbility);
            }
            randomItemAbility.rarity = rar;
            return randomItemAbility;
        }
        private Dictionary<IUnit, ExtraAbilityInfo> extraAbilities;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit key = sender as IUnit;
            ExtraAbilityInfo extraAbilityInfo;
            if (this.extraAbilities.TryGetValue(key, out extraAbilityInfo))
            {
                key.TryRemoveExtraAbility(extraAbilityInfo);
                this.extraAbilities.Remove(key);
            }
            ExtraAbilityInfo randomItemAbility = GetRandomItemAbility();
            this.extraAbilities.Add(key, randomItemAbility);
            key.AddExtraAbility(this.extraAbilities[key]);
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            if (this.extraAbilities == null)
                this.extraAbilities = new Dictionary<IUnit, ExtraAbilityInfo>();
            ExtraAbilityInfo randomItemAbility = GetRandomItemAbility();
            this.extraAbilities.Add(unit, randomItemAbility);
            unit.AddExtraAbility(this.extraAbilities[unit]); //EnemyCombat e;
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            ExtraAbilityInfo extraAbilityInfo;
            if (!this.extraAbilities.TryGetValue(unit, out extraAbilityInfo))
                return;
            unit.TryRemoveExtraAbility(extraAbilityInfo);
            this.extraAbilities.Remove(unit);
        }
    }
    public class PlayHealthColorSoundUIAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            stats.combatUI.CombatDB.TryOneShotSoundEvent(CombatType_GameIDs.Misc_HealthColor.ToString());
            yield return null;
        }
    }
    public class PlayHealthColorSoundEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new PlayHealthColorSoundUIAction());
            return true;
        }
    }
}
