using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class UnmungPassiveAbility : BasePassiveAbilitySO
    {
        [SerializeField]
        private int _floorVal = 0;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            //Debug.Log("passive started");
            IUnit unit = sender as IUnit;

            if (args is DamageReceivedValueChangeException HitBy && HitBy.directDamage == true && HitBy.amount > _floorVal)
            {
                IPassiveEffector passiveEffector = sender as IPassiveEffector;
                HitBy.AddModifier((IntValueModifier)new UnmungTrigger(unit, passiveEffector));
            }
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class UnmungTrigger : IntValueModifier
    {
        public readonly IUnit unit;
        public readonly IPassiveEffector effector;

        public UnmungTrigger(IUnit thisUnit, IPassiveEffector thisEffector)
          : base(1000)
        {
            this.unit = thisUnit;
            this.effector = thisEffector;
        }

        public override int Modify(int value)
        {
            if (value > 0)
            {
                AnimationVisualsEffect animIs = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animIs._visuals = LoadedAssetsHandler.GetEnemyAbility("Mungle_A").visuals;
                animIs._animationTarget = Targeting.Slot_SelfAll;
                EffectInfo animYAY = Effects.GenerateEffect(animIs, 1, Targeting.Slot_SelfAll);
                SpawnRandomEnemyAnywhereEffect selector = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereEffect>();
                selector._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
                string fishQuote = "\"Feed Him for a Day\"";
                selector._enemies = new List<EnemySO> { LoadedAssetsHandler.GetEnemy("Mung_EN") };
                if (value >= 16)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("TeachaMantoFish_EN");
                    fishQuote = "\"As He Enters a Whole New World of Misery\"";
                }
                else if (value >= 11 && value < 16)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("MunglingMudLung_EN");
                    fishQuote = "\"Put Him out of His Current Suffering\"";
                }
                else if (value >= 7 && value < 11)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("MudLung_EN");
                    fishQuote = "\"Teach a Man to Fish\"";
                }
                else if (value >= 3 && value < 7)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("Mung_EN");
                    fishQuote = "\"Feed Him for a Day\"";
                }
                else if (value >= 1 && value < 3)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("Mungie_EN");
                    fishQuote = "\"Give a Man a Fish\"";
                }
                EffectInfo fishSpawn = Effects.GenerateEffect(selector, 1, Targeting.Slot_SelfAll);
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(this.effector.ID, this.effector.IsUnitCharacter, fishQuote, ResourceLoader.LoadSprite("Fishing.png")));
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { animYAY, fishSpawn }, this.unit));
            }
            return value;
        }
    }
}
