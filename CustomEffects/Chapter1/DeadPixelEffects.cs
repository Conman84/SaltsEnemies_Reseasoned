using System;
using System.Collections.Generic;
using BrutalAPI;
using SaltsEnemies_Reseasoned;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class TurnGreyTargetRandomEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool usePreviousExitValue = this._usePreviousExitValue;
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }
            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool hasUnit = targetSlotInfo.HasUnit;
                if (hasUnit)
                {
                    if (targetSlotInfo.Unit.HealthColor != Pigments.Grey)
                        list.Add(targetSlotInfo);
                }
            }
            bool flag = list.Count <= 0;
            bool result;
            if (flag)
            {
                result = false;
                return result;
            }
            else
            {
                int index = UnityEngine.Random.Range(0, list.Count);
                TargetSlotInfo targetSlotInfo2 = list[index];
                areTargetSlots = true;
                int targetSlotOffset = areTargetSlots ? (targetSlotInfo2.SlotID - targetSlotInfo2.Unit.SlotID) : -1;

                int hitHere = targetSlotInfo2.SlotID - caster.SlotID;
                AnimationVisualsEffect animIS = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animIS._animationTarget = Targeting.GenerateSlotTarget(new int[1] { hitHere }, true);
                //animIS._visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
                animIS._visuals = CustomVisuals.GetVisuals("Salt/Class");
                EffectInfo animYAY = Effects.GenerateEffect(animIS, 1, Targeting.Slot_SelfAll);

                ChangeToRandomHealthColorEffect greyYAY = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
                greyYAY._healthColors = new ManaColorSO[1] { Pigments.Grey };
                RemovePassiveEffect noPure = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                noPure.m_PassiveID = Passives.Pure.m_PassiveID;

                EffectInfo unPure = Effects.GenerateEffect(noPure, 1, Targeting.GenerateSlotTarget(new int[1] { hitHere }, true));
                EffectInfo grayify = Effects.GenerateEffect(greyYAY, 1, Targeting.GenerateSlotTarget(new int[1] { hitHere }, true));


                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { animYAY, unPure, grayify }, caster));


                exitAmount = entryVariable;
                result = (exitAmount > 0);
            }
            return result;
        }

        // Token: 0x04000022 RID: 34
        [SerializeField]
        public bool _usePreviousExitValue;

        // Token: 0x04000023 RID: 35
        [SerializeField]
        public bool _ignoreShield;

        // Token: 0x04000024 RID: 36
        [SerializeField]
        public bool _indirect = false;

        // Token: 0x04000025 RID: 37
        public int _scars;
    }
    public class TurnGreyTargetRandomAndHitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool usePreviousExitValue = this._usePreviousExitValue;
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }
            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool hasUnit = targetSlotInfo.HasUnit;
                if (hasUnit)
                {
                    if (targetSlotInfo.Unit.HealthColor != Pigments.Grey)
                        list.Add(targetSlotInfo);
                }
            }
            bool flag = list.Count <= 0;
            bool result;
            if (flag)
            {
                result = false;
                EffectInfo selfFlee = Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.Slot_SelfAll);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { selfFlee }, caster));
            }
            else
            {
                int index = UnityEngine.Random.Range(0, list.Count);
                TargetSlotInfo targetSlotInfo2 = list[index];
                areTargetSlots = true;
                int targetSlotOffset = areTargetSlots ? (targetSlotInfo2.SlotID - targetSlotInfo2.Unit.SlotID) : -1;

                int hitHere = targetSlotInfo2.SlotID - caster.SlotID;
                AnimationVisualsEffect animIS = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animIS._animationTarget = Targeting.GenerateSlotTarget(new int[] { hitHere }, false);
                animIS._visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
                Debug.Log(entryVariable);
                EffectInfo animYAY = Effects.GenerateEffect(animIS, 1, Targeting.Slot_SelfAll);

                ChangeToRandomHealthColorEffect greyYAY = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
                greyYAY._healthColors = new ManaColorSO[1] { Pigments.Grey };
                RemovePassiveEffect noPure = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                noPure.m_PassiveID = Passives.Pure.m_PassiveID;

                EffectInfo unPure = Effects.GenerateEffect(noPure, 1, Targeting.GenerateSlotTarget(new int[] { hitHere }, false));
                EffectInfo grayify = Effects.GenerateEffect(greyYAY, 1, Targeting.GenerateSlotTarget(new int[] { hitHere }, false));
                int painfulAmount = UnityEngine.Random.Range(3, 7);
                EffectInfo pain = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), painfulAmount, Targeting.GenerateSlotTarget(new int[1] { hitHere }, false), Effects.ChanceCondition(70));

                CustomChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<CustomChangeToRandomHealthColorEffect>();
                randomize._healthColors = new ManaColorSO[4]
                {
                    Pigments.Red,
                    Pigments.Blue,
                    Pigments.Yellow,
                    Pigments.Purple
                };
                EffectInfo changeHPColor = Effects.GenerateEffect(randomize, 1, Targeting.Slot_SelfAll);

                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { animYAY, unPure, grayify, pain, changeHPColor }, caster));


                exitAmount = entryVariable;
                result = (exitAmount > 0);
            }
            return result;
        }

        // Token: 0x04000022 RID: 34
        [SerializeField]
        public bool _usePreviousExitValue;

        // Token: 0x04000023 RID: 35
        [SerializeField]
        public bool _ignoreShield;

        // Token: 0x04000024 RID: 36
        [SerializeField]
        public bool _indirect = false;

        // Token: 0x04000025 RID: 37
        public int _scars;
    }
    public class CustomChangeToRandomHealthColorEffect : EffectSO
    {
        [SerializeField]
        public ManaColorSO[] _healthColors;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    List<ManaColorSO> manaColorSoList = new List<ManaColorSO>((IEnumerable<ManaColorSO>)this._healthColors);
                    bool flag1 = false;
                    bool flag2 = false;
                    while (!flag2 && manaColorSoList.Count > 0)
                    {
                        int index = UnityEngine.Random.Range(0, manaColorSoList.Count);
                        ManaColorSO manaColor = manaColorSoList[index];
                        manaColorSoList.RemoveAt(index);
                        if (manaColor != target.Unit.HealthColor)
                        {
                            flag1 = target.Unit.ChangeHealthColor(manaColor);
                            flag2 = true;
                        }
                    }
                    if (flag1)
                        ++exitAmount;
                }
            }
            return exitAmount > 0;
        }
    }
    public class IsAliveCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && unit.CurrentHealth > 0) return true;
            return false;
        }
    }
    public class NumbPassiveInfoEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Numb (1)", ResourceLoader.LoadSprite("Anesthetics.png", ppu: 32)));
            return true;
        }
    }
    public class RandomStatusEffect : EffectSO
    {
        static ApplyOilSlickedEffect _oil;
        public static ApplyOilSlickedEffect Oil
        {
            get
            {
                if (_oil == null)
                {
                    _oil = ScriptableObject.CreateInstance<ApplyOilSlickedEffect>();
                }
                return _oil;
            }
        }
        static ApplyLeftEffect _left;
        public static ApplyLeftEffect Left
        {
            get
            {
                if (_left == null)
                {
                    _left = ScriptableObject.CreateInstance<ApplyLeftEffect>();
                }
                return _left;
            }
        }//moves you left once on moving
        static ApplyFrailEffect _frail;
        public static ApplyFrailEffect Frail
        {
            get
            {
                if (_frail == null)
                {
                    _frail = ScriptableObject.CreateInstance<ApplyFrailEffect>();
                }
                return _frail;
            }
        }
        static ApplyScarsEffect _scar;
        public static ApplyScarsEffect Scar
        {
            get
            {
                if (_scar == null)
                {
                    _scar = ScriptableObject.CreateInstance<ApplyScarsEffect>();
                }
                return _scar;
            }
        }
        static ApplyCursedEffect _cursed;
        public static ApplyCursedEffect Cursed
        {
            get
            {
                if (_cursed == null)
                {
                    _cursed = ScriptableObject.CreateInstance<ApplyCursedEffect>();
                }
                return _cursed;
            }
        }
        static ApplyPaleByTenEffect _pale;
        public static ApplyPaleByTenEffect Pale
        {
            get
            {
                if (_pale == null)
                {
                    _pale = ScriptableObject.CreateInstance<ApplyPaleByTenEffect>();
                }
                return _pale;
            }
        }
        static ApplyInvertedEffect _inverted;
        public static ApplyInvertedEffect Inverted
        {
            get
            {
                if (_inverted == null)
                {
                    _inverted = ScriptableObject.CreateInstance<ApplyInvertedEffect>();
                }
                return _inverted;
            }
        }//direct healing --> indirect damage; direct damge --> indirect healing
        public static EffectSO[] Array => new EffectSO[] { Oil, Left, Frail, Scar, Cursed, Pale, Inverted };

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                List<EffectSO> list = new List<EffectSO>(Array);
                int picking = UnityEngine.Random.Range(0, list.Count);
                EffectSO first = list[picking];
                int choosing = UnityEngine.Random.Range(0, list.Count);
                while (choosing == picking)
                {
                    choosing = UnityEngine.Random.Range(0, list.Count);
                }
                EffectSO second = list[choosing];
                first.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, 1, out int exiting);
                exitAmount += exiting;
                if (UnityEngine.Random.Range(0, 100) < 50) continue;
                second.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, 1, out int grah);
                exitAmount += grah;
            }
            return exitAmount > 0;
        }
    }
    public class ApplyPaleByTenEffect : ApplyPaleEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable * 10, out exitAmount);
        }
    }

    public class GenerateFullBarManaEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public ManaColorSO mana = Pigments.Purple;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool isBarFull = stats.MainManaBar.IsManaBarFull;
            while (isBarFull == false)
            {
                int choosing = UnityEngine.Random.Range(0, 100);
                if (choosing < 30)
                    mana = Pigments.Red;
                else if (choosing < 55)
                    mana = Pigments.Blue;
                else if (choosing < 75)
                    mana = Pigments.Yellow;
                else if (choosing < 97)
                    mana = Pigments.Purple;
                else if (choosing < 100)
                    mana = Pigments.Green;
                CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(mana, entryVariable, caster.IsUnitCharacter, caster.ID));
                exitAmount++;
                isBarFull = stats.MainManaBar.IsManaBarFull;
            }
            return exitAmount > 0;
        }
    }

    public class SwapToRandomZoneEffect : EffectSO
    {

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            if (stats.combatSlots.UnitInSlotContainsFieldEffect(caster.SlotID, caster.IsUnitCharacter, StatusField_GameIDs.Constricted_ID.ToString()))
            {
                return false;
            }
            if (caster.CurrentHealth < 1)
            {
                return false;
            }
            foreach (TargetSlotInfo target in targets)
            {
                int secondSlotID = UnityEngine.Random.Range(0, 5);
                if (secondSlotID == 5)
                {
                    //Debug.Log("failed, ran again");
                    //Debug.Log("second Slot was out of bounds");
                    EffectInfo swapAgain = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { swapAgain }, caster));
                    return false;
                }
                if (secondSlotID == caster.SlotID)
                {
                    //Debug.Log("effect ran but second slot ID was caster Slot ID so it didn't move");
                    return exitAmount > 0;
                }
                if (secondSlotID != caster.SlotID)
                {
                    /*if (stats.combatSlots.CanEnemiesSwap(caster.SlotID, secondSlotID, out var firstSlotSwap, out var secondSlotSwap))
                    {*/
                    //Debug.Log("caster.SlotID:");
                    //Debug.Log(caster.SlotID);
                    //Debug.Log("secondSlotID:");
                    //Debug.Log(secondSlotID);
                    /*if (caster.SlotID != secondSlotSwap || secondSlotID != firstSlotSwap)
                    {
                        Debug.Log("failed, ran again");
                        if (caster.SlotID != secondSlotSwap)
                        {
                            Debug.Log("caster slot not equal second slot target");
                        }
                        if (secondSlotID != firstSlotSwap)
                        {
                            Debug.Log("target slot not equal caster slot target");
                        }
                        Effect swapAgain = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.Self);
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { swapAgain }), caster));
                        return false;
                    }*/
                    int thisTarget = 0;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i].SlotID == secondSlotID)
                        {
                            thisTarget = i;
                            //Debug.Log("found it");
                        }
                    }
                    TargetSlotInfo unit2 = targets[thisTarget];
                    if (unit2.HasUnit)
                    {
                        //Debug.Log(unit2.Unit.SlotID);
                    }
                    if (!unit2.HasUnit)
                    {
                        //Debug.Log("empty slot");
                    }
                    bool hasRight = false;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i].SlotID == caster.SlotID + 1)
                        {
                            //Debug.Log("found it");
                            hasRight = targets[i].HasUnit;
                        }
                    }
                    bool hasLeft = false;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i].SlotID == caster.SlotID - 1)
                        {
                            //Debug.Log("found it");
                            hasLeft = targets[i].HasUnit;
                        }
                    }



                    /*if (secondSlotID > 0)
                        {
                            Debug.Log("second slot id isnt 0");
                            CombatSlot checkIf2Tile = new CombatSlot(secondSlotID - 1, false);
                            if (checkIf2Tile.HasUnit)
                            {
                                Debug.Log("has unit");
                                if (checkIf2Tile.Unit.Size > 1)
                                {
                                    Debug.Log("big enemy");
                                    Debug.Log(checkIf2Tile.Unit.Size);
                                    {
                                        unit2 = checkIf2Tile;
                                    }
                                }
                            }
                            Debug.Log("should have checked if 2 or bigger tile");
                        }*/
                    /*if (!stats.combatSlots.CanEnemiesSwap(caster.SlotID, secondSlotID, out var firstSlotSwap, out var secondSlotSwap))
                    {
                        Debug.Log("they can't swap for whatever reason, run it again.");
                        Debug.Log("caster slot id");
                        Debug.Log(caster.SlotID);
                        Debug.Log("caster moves to slot");
                        Debug.Log(firstSlotSwap);
                        Debug.Log("target slot id");
                        Debug.Log(secondSlotID);
                        Debug.Log("target unit moves to slot");
                        Debug.Log(secondSlotSwap);
                        Effect swap2 = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, true));
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { swap2 }), caster));
                        return false;
                    }*/
                    //Debug.Log("can swap");
                    if (unit2.HasUnit == false)
                    {
                        //Debug.Log("slot is empty");
                        if (stats.combatSlots.CanEnemiesSwap(caster.SlotID, secondSlotID, out var firstSlotSwapA, out var secondSlotSwapA))
                        {
                            if (stats.combatSlots.SwapEnemies(caster.SlotID, firstSlotSwapA, secondSlotID, secondSlotSwapA))
                            {
                                //Debug.Log("moved!!");
                                exitAmount++;
                                return exitAmount > 0;
                            }
                        }
                    }
                    //Debug.Log("has unit");
                    if (caster.Size == 1 && unit2.Unit.Size == 1)
                    {
                        //Debug.Log("both are size 1");
                        if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, secondSlotID, caster.SlotID))
                        {
                            //Debug.Log("moved!!");
                            exitAmount++;
                            return exitAmount > 0;
                        }
                    }
                    if (caster.Size == 1 && unit2.Unit.Size == 2)
                    {
                        //Debug.Log("caster is size 1, target is size 2");
                        if (caster.SlotID + 1 == unit2.Unit.SlotID)
                        {
                            //Debug.Log("2 size target is 1 right from caster");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (secondSlotID == unit2.Unit.SlotID)
                            {
                                //Debug.Log("second slot id is same as unit 2 slot id");
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID + 1, unit2.Unit.SlotID, caster.SlotID))
                                {
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                            if (secondSlotID - 1 == unit2.Unit.SlotID)
                            {
                                //Debug.Log("second slot id +1 to unit 2 slot id");
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, unit2.Unit.SlotID, caster.SlotID))
                                {
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                        }
                        if (caster.SlotID - 2 == unit2.Unit.SlotID)
                        {
                            //Debug.Log("2 size target is 1 left from caster");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (secondSlotID == unit2.Unit.SlotID)
                            {
                                //Debug.Log("second slot id is same as unit 2 slot id");
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, unit2.Unit.SlotID, caster.SlotID - 1))
                                {
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                            if (secondSlotID - 1 == unit2.Unit.SlotID)
                            {
                                //Debug.Log("second slot id +1 to unit 2 slot id");
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID - 1, unit2.Unit.SlotID, caster.SlotID - 1))
                                {
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                        }
                        //Debug.Log("caster is not next to 2 size target.");
                        if (caster.SlotID == 4)
                        {
                            //Debug.Log("caster is in rightmost slot");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (hasLeft == false)
                            {
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, unit2.Unit.SlotID + 1, unit2.Unit.SlotID, caster.SlotID - 1))
                                {
                                    if (hasLeft == true)
                                    {
                                        //Debug.Log("caster has unit to the left");
                                        stats.combatSlots.SwapEnemies(caster.SlotID - 1, unit2.Unit.SlotID, unit2.Unit.SlotID, caster.SlotID - 1);
                                    }
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                        }
                        if (caster.SlotID == 0)
                        {
                            //Debug.Log("caster is in leftmost slot");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (hasRight == false)
                            {
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, unit2.Unit.SlotID, unit2.Unit.SlotID, caster.SlotID))
                                {
                                    if (hasRight == true)
                                    {
                                        //Debug.Log("caster has unit to the right");
                                        stats.combatSlots.SwapEnemies(caster.SlotID + 1, unit2.Unit.SlotID + 1, unit2.Unit.SlotID, caster.SlotID);
                                    }
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                        }
                        if (caster.SlotID != 4 && caster.SlotID != 0)
                        {
                            //Debug.Log("caster is not in rightmost or leftmost slot.");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (secondSlotID == unit2.Unit.SlotID)
                            {
                                //Debug.Log("target slot is same as unit slot");
                                if (hasRight == false)
                                {
                                    if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, unit2.Unit.SlotID, caster.SlotID))
                                    {
                                        if (hasRight == true)
                                        {
                                            //Debug.Log("caster has unit to the right");
                                            stats.combatSlots.SwapEnemies(caster.SlotID + 1, secondSlotID + 1, secondSlotID, caster.SlotID);
                                        }
                                        //Debug.Log("moved!!");
                                        exitAmount++;
                                        return exitAmount > 0;
                                    }
                                }
                                else if (hasLeft == false)
                                {
                                    if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, unit2.Unit.SlotID, caster.SlotID - 1))
                                    {
                                        //Debug.Log("moved!!");
                                        exitAmount++;
                                        return exitAmount > 0;
                                    }
                                }
                            }
                            if (secondSlotID + 1 == unit2.Unit.SlotID)
                            {
                                //Debug.Log("target slot is not same as unit slot");
                                if (hasLeft == false)
                                {
                                    if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, secondSlotID - 1, caster.SlotID - 1))
                                    {
                                        if (hasLeft == true)
                                        {
                                            //Debug.Log("caster has unit to the left");
                                            stats.combatSlots.SwapEnemies(caster.SlotID - 1, unit2.Unit.SlotID, unit2.Unit.SlotID, caster.SlotID - 1);
                                        }
                                        //Debug.Log("moved!!");
                                        exitAmount++;
                                        return exitAmount > 0;
                                    }
                                }
                                else if (hasRight == false)
                                {
                                    if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, secondSlotID - 1, caster.SlotID))
                                    {
                                        //Debug.Log("moved!!");
                                        exitAmount++;
                                        return exitAmount > 0;
                                    }
                                }
                            }
                        }
                    }
                    if (unit2.Unit.Size >= 3)
                    {
                        //Debug.Log("target unit is size 3 or greater, fuck this.");
                        //Debug.Log("Swap sides effect");
                        EffectInfo swapSides = Effects.GenerateEffect(ScriptableObject.CreateInstance<CustomSwapToSidesEffect>(), 1, Targeting.Slot_SelfAll);
                        CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { swapSides }, caster));
                        exitAmount++;
                        return exitAmount > 0;
                    }


                    //Debug.Log("failed, ran again");
                    EffectInfo swapAgain = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { swapAgain }, caster));
                    return exitAmount > 0;

                }
            }
            return exitAmount > 0;
        }
    }
    public class CustomSwapToSidesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<IUnit> list = new List<IUnit>();
            List<IUnit> list2 = new List<IUnit>();
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    IUnit unit = targets[i].Unit;
                    if (unit.IsUnitCharacter && !list.Contains(unit))
                    {
                        list.Add(unit);
                    }
                    else if (!unit.IsUnitCharacter && !list2.Contains(unit))
                    {
                        list2.Add(unit);
                    }
                }
            }

            foreach (IUnit item in list)
            {
                int num = UnityEngine.Random.Range(0, 2) * 2 - 1;
                if (item.SlotID + num >= 0 && item.SlotID + num < stats.combatSlots.CharacterSlots.Length)
                {
                    if (stats.combatSlots.SwapCharacters(item.SlotID, item.SlotID + num, isMandatory: true))
                    {
                        exitAmount++;
                        return exitAmount > 0;
                    }

                    continue;
                }

                num *= -1;
                if (item.SlotID + num >= 0 && item.SlotID + num < stats.combatSlots.CharacterSlots.Length && stats.combatSlots.SwapCharacters(item.SlotID, item.SlotID + num, isMandatory: true))
                {
                    exitAmount++;
                    return exitAmount > 0;
                }
            }

            foreach (IUnit item2 in list2)
            {
                int num = UnityEngine.Random.Range(0, 2) * (item2.Size + 1) - 1;
                if (stats.combatSlots.CanEnemiesSwap(item2.SlotID, item2.SlotID + num, out var firstSlotSwap, out var secondSlotSwap))
                {
                    if (stats.combatSlots.SwapEnemies(item2.SlotID, firstSlotSwap, item2.SlotID + num, secondSlotSwap))
                    {
                        exitAmount++;
                        return exitAmount > 0;
                    }

                    continue;
                }

                num = ((num < 0) ? item2.Size : (-1));
                if (stats.combatSlots.CanEnemiesSwap(item2.SlotID, item2.SlotID + num, out firstSlotSwap, out secondSlotSwap) && stats.combatSlots.SwapEnemies(item2.SlotID, firstSlotSwap, item2.SlotID + num, secondSlotSwap))
                {
                    exitAmount++;
                    return exitAmount > 0;
                }
            }
            Debug.Log("failed somehow");
            EffectInfo swapAgain = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { swapAgain }, caster));
            return exitAmount > 0;
        }
    }
}