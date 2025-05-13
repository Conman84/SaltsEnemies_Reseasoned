using BrutalAPI;
using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine.UIElements.Experimental;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class SunColorEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.HealthColor == Pigments.Red) exitAmount = 1;
            else if (caster.HealthColor == Pigments.Blue) exitAmount = 2;
            else if (caster.HealthColor == Pigments.Yellow) exitAmount = 3;
            else if (caster.HealthColor == Pigments.Purple) exitAmount = 4;
            else if (caster.HealthColor == Pigments.Grey) exitAmount = 5;
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "light", exitAmount));
            return exitAmount > 0;
        }
    }
    public class GlassedSunEffect : CasterTransformationEffect
    {
        public static GlassedSunEffect Instance;
        public void Setup()
        {
            _fullyHeal = false;
            _maintainMaxHealth = true;
            _maintainTimelineAbilities = false;
            _currentToMaxHealth = false;
            List<EnemySO> red = new List<EnemySO>()
            {
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Clotted_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Writhing_EN"),
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Clotted_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Writhing_EN"),
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Clotted_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Writhing_EN"),
            };
            List<EnemySO> blue = new List<EnemySO>()
            {
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Ruminating_EN"),
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Ruminating_EN"),
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Ruminating_EN"),
            };
            List<EnemySO> yellow = new List<EnemySO>()
            {
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Waning_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Spitfire_EN"),
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Waning_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Spitfire_EN"),
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Waning_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Spitfire_EN"),
            };
            List<EnemySO> purple = new List<EnemySO>()
            {
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN"),
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN"),
                LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN"),
                LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN"),
            };
            List<EnemySO> grey = new List<EnemySO>();
            if (Check.EnemyExist("DesiccatingJumbleguts_EN")) grey.Add(LoadedAssetsHandler.GetEnemy("DesiccatingJumbleguts_EN"));
            if (Check.EnemyExist("PerforatedSpoggle_EN")) grey.Add(LoadedAssetsHandler.GetEnemy("PerforatedSpoggle_EN"));
            if (Check.EnemyExist("RusticJumbleguts_EN")) for (int i = 0; i < 2; i++) grey.Add(LoadedAssetsHandler.GetEnemy("RusticJumbleguts_EN"));
            if (Check.EnemyExist("MortalSpoggle_EN")) for (int i = 0; i < 2; i++) grey.Add(LoadedAssetsHandler.GetEnemy("MortalSpoggle_EN"));
            if (Check.MultiENExistInternal([Flower.Red, Flower.Blue, Flower.Purple, Flower.Yellow, Flower.Grey]))
            {
                for (int i = 0; i < 3; i++) red.Add(LoadedAssetsHandler.GetEnemy("RedFlower_EN"));
                for (int i = 0; i < 3; i++) blue.Add(LoadedAssetsHandler.GetEnemy("BlueFlower_EN"));
                for (int i = 0; i < 3; i++) yellow.Add(LoadedAssetsHandler.GetEnemy("YellowFlower_EN"));
                for (int i = 0; i < 3; i++) purple.Add(LoadedAssetsHandler.GetEnemy("PurpleFlower_EN"));
                for (int i = 0; i < 2; i++) grey.Add(LoadedAssetsHandler.GetEnemy("GreyFlower_EN"));
            }
            if (Check.MultiENExistInternal([Bots.Red, Bots.Blue, Bots.Yellow, Bots.Purple, Bots.Gray]))
            {
                for (int i = 0; i < 3; i++) red.Add(LoadedAssetsHandler.GetEnemy("RedBot_EN"));
                for (int i = 0; i < 3; i++) blue.Add(LoadedAssetsHandler.GetEnemy("BlueBot_EN"));
                for (int i = 0; i < 3; i++) yellow.Add(LoadedAssetsHandler.GetEnemy("YellowBot_EN"));
                for (int i = 0; i < 3; i++) purple.Add(LoadedAssetsHandler.GetEnemy("PurpleBot_EN"));
                for (int i = 0; i < 2; i++) grey.Add(LoadedAssetsHandler.GetEnemy("GreyBot_EN"));
            }
            if (Check.EnemyExist("GlassedSun_EN"))
            {
                EnemySO first = LoadedAssetsHandler.GetEnemy("GlassedSun_EN");
                EnemySO rE = ScriptableObject.Instantiate(first);
                rE.enterEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<SunColorEffect>(), 1, Slots.Self) };
                rE.healthColor = Pigments.Red;
                for (int i = 0; i < 20; i++) red.Add(rE);
                EnemySO bE = ScriptableObject.Instantiate(rE);
                bE.healthColor = Pigments.Blue;
                for (int i = 0; i < 20; i++) blue.Add(bE);
                EnemySO yE = ScriptableObject.Instantiate(rE);
                yE.healthColor = Pigments.Yellow;
                for (int i = 0; i < 20; i++) yellow.Add(yE);
                EnemySO pE = ScriptableObject.Instantiate(rE);
                pE.healthColor = Pigments.Purple;
                for (int i = 0; i < 20; i++) purple.Add(pE);
                EnemySO gE = ScriptableObject.Instantiate(rE);
                gE.healthColor = Pigments.Grey;
                for (int i = 0; i < 20; i++) grey.Add(gE);
            }
            if (Check.MultiENExistInternal([Colophon.Red, Colophon.Blue, Colophon.Yellow, Colophon.Purple]))
            {
                for (int i = 0; i < 3; i++) red.Add(LoadedAssetsHandler.GetEnemy("DefeatedColophon_EN"));
                for (int i = 0; i < 3; i++) blue.Add(LoadedAssetsHandler.GetEnemy("ComposedColophon_EN"));
                for (int i = 0; i < 3; i++) yellow.Add(LoadedAssetsHandler.GetEnemy("MaladjustedColophon_EN"));
                for (int i = 0; i < 3; i++) purple.Add(LoadedAssetsHandler.GetEnemy("DelightedColophon_EN"));
            }
            if (Check.MultiENExistInternal([Noses.Red, Noses.Blue, Noses.Yellow, Noses.Purple, Noses.Grey]))
            {
                for (int i = 0; i < 3; i++) red.Add(LoadedAssetsHandler.GetEnemy("ProlificNosestone_EN"));
                for (int i = 0; i < 3; i++) blue.Add(LoadedAssetsHandler.GetEnemy("ScatterbrainedNosestone_EN"));
                for (int i = 0; i < 3; i++) yellow.Add(LoadedAssetsHandler.GetEnemy("SweatingNosestone_EN"));
                for (int i = 0; i < 3; i++) purple.Add(LoadedAssetsHandler.GetEnemy("MesmerizingNosestone_EN"));
                for (int i = 0; i < 2; i++) grey.Add(LoadedAssetsHandler.GetEnemy("UninspiredNosestone_EN"));
            }
            Red = red.ToArray();
            Blue = blue.ToArray();
            Yellow = yellow.ToArray();
            Purple = purple.ToArray();
            Grey = grey.ToArray();
        }
        public EnemySO[] Red;
        public EnemySO[] Blue;
        public EnemySO[] Yellow;
        public EnemySO[] Purple;
        public EnemySO[] Grey;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter) return false;
            try
            {
                if (caster.HealthColor == Pigments.Red) _enemyTransformation = Red.GetRandom();
                else if (caster.HealthColor == Pigments.Blue) _enemyTransformation = Blue.GetRandom();
                else if (caster.HealthColor == Pigments.Yellow) _enemyTransformation = Yellow.GetRandom();
                else if (caster.HealthColor == Pigments.Purple) _enemyTransformation = Purple.GetRandom();
                else if (caster.HealthColor == Pigments.Grey) _enemyTransformation = Grey.GetRandom();
                else _enemyTransformation = Grey.GetRandom();

                if (caster is EnemyCombat enemy)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (_enemyTransformation != null && !_enemyTransformation.Equals(null) && enemy.Enemy._enemyName != _enemyTransformation._enemyName) break;
                        if (caster.HealthColor == Pigments.Red) _enemyTransformation = Red.GetRandom();
                        else if (caster.HealthColor == Pigments.Blue) _enemyTransformation = Blue.GetRandom();
                        else if (caster.HealthColor == Pigments.Yellow) _enemyTransformation = Yellow.GetRandom();
                        else if (caster.HealthColor == Pigments.Purple) _enemyTransformation = Purple.GetRandom();
                        else if (caster.HealthColor == Pigments.Grey) _enemyTransformation = Grey.GetRandom();
                        else _enemyTransformation = Grey.GetRandom();
                    }
                }

            }
            catch
            {
                return false;
            }
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public static class GlassedSunHandler
    {
        public static IEnumerator Execute(Func<TimelineEndReachedAction, CombatStats, IEnumerator> orig, TimelineEndReachedAction self, CombatStats stats)
        {
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                CombatManager.Instance.PostNotification(TriggerCalls.TimelineEndReached.ToString(), enemy, null);
            }
            return orig(self, stats);
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(TimelineEndReachedAction).GetMethod(nameof(TimelineEndReachedAction.Execute), ~BindingFlags.Default),
                typeof(GlassedSunHandler).GetMethod(nameof(Execute), ~BindingFlags.Default));
        }
    }
    public class PriorityPerformEffectPassiveAbility : PerformEffectPassiveAbility
    {
        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            CombatManager.Instance.AddPrioritySubAction(new EffectAction(effects, caster));
        }
    }
    public class SunColorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is BooleanReference && effector is IUnit unit)
            {
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<SunColorEffect>(), 1, Slots.Self) }, unit));
                return false;
            }
            return true;
        }
    }
}
