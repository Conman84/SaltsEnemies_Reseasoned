using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Warbird
    {
        public static void Add()
        {
            Enemy scarecrow = new Enemy("Warbird", "Warbird_EN")
            {
                Health = 20,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("ScarecrowIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ScarecrowWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ScarecrowDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("RealisticTank_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("RealisticTank_EN").deathSound,
            };
            scarecrow.PrepareEnemyPrefab("assets/group4/Scarecrow/Scarecrow_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Scarecrow/Scarecrow_Gibs.prefab").GetComponent<ParticleSystem>());

            //REPRESSION
            RepressionPassiveAbility.Setup();
            PainCondition.Setup();
            RepressionPassiveAbility repression = ScriptableObject.CreateInstance<RepressionPassiveAbility>();
            repression._passiveName = "Repression";
            repression.passiveIcon = ResourceLoader.LoadSprite("repression.png");
            repression.m_PassiveID = "Repression_PA";
            repression._enemyDescription = "If this enemy took no damage of any kind last turn, this enemy gains another action per turn for the rest of combat.";
            repression._characterDescription = "won't work. oops!";
            repression.doesPassiveTriggerInformationPanel = false;
            repression.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(RepressionPassiveAbility.bonusTurns);
            repression._triggerOn = Passives.MultiAttack2._triggerOn;
            repression._isItAdditive = ((IntegerSetterPassiveAbility)Passives.MultiAttack2)._isItAdditive;
            repression.integerValue = 1;

            scarecrow.AddPassives(new BasePassiveAbilitySO[] { Passives.Formless, repression });
            scarecrow.UnitTypes = new List<string> { "Bird" };

            //statue
            Ability statue = new Ability("Scarecrow_Statue_A")
            {
                Name = "Statue",
                Description = "Apply 1 Constricted to this position. Apply 1 Shield to this position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 1, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Cube"),
                AnimationTarget = Slots.Self,
            };
            statue.AddIntentsToTarget(Slots.Self, new string[] { IntentType_GameIDs.Field_Constricted.ToString(), IntentType_GameIDs.Field_Shield.ToString() });

            //screech
            Ability screech = new Ability("Scarecrow_HellScreech_A")
            {
                Name = "Hell Screech",
                Description = "Deal a Little bit of damage and inflict 2 Ruptured on every party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targetting.AllEnemy),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Targetting.AllEnemy)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Rupture_A").visuals,
                AnimationTarget = Targetting.AllEnemy,
            };
            screech.AddIntentsToTarget(Targetting.AllEnemy, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });

            //ADD ENEMY
            scarecrow.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                statue.GenerateEnemyAbility(true),
                screech.GenerateEnemyAbility(true)
            });
            scarecrow.AddEnemy(true, true);
        }
    }
}
