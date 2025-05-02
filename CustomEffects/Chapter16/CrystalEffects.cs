using UnityEngine;
using System.Collections;
using BrutalAPI;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public class PowerByDamageCondition : EffectorConditionSO
    {
        public static Sprite sprite;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && args is IntegerReference reference)
            {
                CombatStats stats = CombatManager.Instance._stats;
                if (sprite == null) sprite = ResourceLoader.LoadSprite("SweetTooth.png");
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, "Sweet Tooth", sprite));

                int amount = reference.value;

                if (Power.Object == null || Power.Object.Equals(null)) Power.Add();
                unit.ApplyStatusEffect(Power.Object, amount);
            }
            return false;
        }
    }
    public class CrystalDecayCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                int amount = 0;
                foreach (IStatusEffect status in (unit as IStatusEffector).StatusEffects)
                {
                    if (status.StatusID == Power.StatusID) amount = status.StatusContent;
                }
                SpawnEnemyWithPowerEffect e = SpawnEnemyWithPowerEffect.Create("CandyStone_EN", amount, true);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowDecayInfoEffect>(), 1, Slots.Self), Effects.GenerateEffect(e, 0, Slots.Self) }, unit));
                return false;
            }
            return true;
        }
    }
    public class SpawnEnemyWithPowerEffect : SpawnEnemyInSlotFromEntryStringNameEffect
    {
        public int Power;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Check.EnemyExist(en)) return false;
            EnemySO enemy = LoadedAssetsHandler.GetEnemy(en);
            for (int num = targets.Length - 1; num >= 0; num--)
            {
                int preferredSlot = entryVariable + targets[num].SlotID;
                CombatManager.Instance.AddSubAction(new CrystalDecayHandler.SpawnEnemyWithPowerAction(enemy, preferredSlot, givesExperience, trySpawnAnywhereIfFail, _spawnType, Power));
            }

            exitAmount = targets.Length;
            return true;
        }
        public static SpawnEnemyWithPowerEffect Create(string enemy, int power, bool anyways = false)
        {
            SpawnEnemyWithPowerEffect ret = ScriptableObject.CreateInstance<SpawnEnemyWithPowerEffect>();
            ret.en = enemy;
            ret.Power = power;
            ret.trySpawnAnywhereIfFail = anyways;
            return ret;
        }
    }
    public static class CrystalDecayHandler
    {
        public static bool AddNewEnemyWithPower(this CombatStats self, EnemySO enemy, int slot, bool givesExperience, string spawnType, int power)
        {
            int firstEmptyEnemyFieldID = self.GetFirstEmptyEnemyFieldID();
            if (firstEmptyEnemyFieldID == -1)
            {
                return false;
            }

            int count = self.Enemies.Count;
            EnemyCombat enemyCombat = new EnemyCombat(count, firstEmptyEnemyFieldID, enemy, givesExperience);
            self.Enemies.Add(count, enemyCombat);
            self.AddEnemyToField(count, firstEmptyEnemyFieldID);
            self.combatSlots.AddEnemyToSlot(enemyCombat, slot);
            self.timeline.AddEnemyToTimeline(enemyCombat);
            CombatManager.Instance.AddUIAction(new EnemySpawnUIAction(enemyCombat.ID, spawnType));
            enemyCombat.ConnectPassives();
            enemyCombat.InitializationEnd();
            CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), power, Slots.Self) }, enemyCombat));
            return true;
        }
        public class SpawnEnemyWithPowerAction : CombatAction
        {
            public int _preferredSlot;

            public EnemySO _enemy;

            public bool _givesExperience;

            public bool _trySpawnAnyways;

            public string _spawnType;
            public int power;

            public SpawnEnemyWithPowerAction(EnemySO enemy, int preferredSlot, bool givesExperience, bool trySpawnAnyways, string spawnType, int power)
            {
                _preferredSlot = preferredSlot;
                _givesExperience = givesExperience;
                _enemy = enemy;
                _trySpawnAnyways = trySpawnAnyways;
                _spawnType = spawnType;
                this.power = power;
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                int num;
                if (_preferredSlot >= 0)
                {
                    num = stats.combatSlots.GetEnemyFitSlot(_preferredSlot, _enemy.size);
                    if (num == -1 && _trySpawnAnyways)
                    {
                        num = stats.GetRandomEnemySlot(_enemy.size);
                    }
                }
                else
                {
                    num = stats.GetRandomEnemySlot(_enemy.size);
                }

                if (num != -1)
                {
                    stats.AddNewEnemyWithPower(_enemy, num, _givesExperience, _spawnType, power);
                }

                yield return null;
            }
        }
    }
    public class ShowDecayInfoEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Decay", Passives.Example_Decay_MudLung.passiveIcon));
            return true;
        }
    }
    public class DamageScarIfMissEffect : ApplyScarsEffect
    {
        [SerializeField]
        public string _deathType = DeathType_GameIDs.Basic.ToString();

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public int IntendedTargets = 2;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            for (int i = targets.Length; i < IntendedTargets; i++)
            {
                base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int exi);
            }

            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                    }

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
                else
                {
                    base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int exi);
                }
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }
        public static DamageScarIfMissEffect Create(int targets)
        {
            DamageScarIfMissEffect ret = ScriptableObject.CreateInstance<DamageScarIfMissEffect>();
            ret.IntendedTargets = targets;
            return ret;
        }
    }
    public class ApplyBoneSpursByTwoCasterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!caster.ContainsPassiveAbility(PassiveType_GameIDs.BoneSpurs.ToString())) caster.AddPassiveAbility(Passives.BoneSpurs2);
            else caster.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.BoneSpursPA.ToString(), caster.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.BoneSpursPA.ToString()) + 2);
            return true;
        }
    }
}
