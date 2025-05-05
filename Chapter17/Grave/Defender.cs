using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Defender
    {
        public static void Add()
        {
            Enemy mortar = new Enemy("Nobody's Defender", "Defender_EN")
            {
                Health = 9,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("DefenderIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DefenderWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DefenderDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound,
            };
            mortar.PrepareEnemyPrefab("assets/enemie/Defender_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/Defender_Gibs.prefab").GetComponent<ParticleSystem>());

            mortar.AddPassives(new BasePassiveAbilitySO[] { Passives.LeakyGenerator(2), Passives.Forgetful });

            //front
            Ability front = new Ability("Frontal Cannon", "FrontalCannon_A");
            front.Rarity = Rarity.CreateAndAddCustomRarityToPool("CannonHigh", 70);
            front.Priority = Priority.Slow;
            front.Description = "Deal a Painful amount of damage to the Opposing party member.\nApply 6 Shield to this enemy's position.";
            front.Effects = new EffectInfo[2];
            front.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_Front);
            front.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, Targeting.Slot_SelfAll);
            front.AddIntentsToTarget(Targeting.Slot_Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            front.AddIntentsToTarget(Targeting.Slot_SelfAll, [IntentType_GameIDs.Field_Shield.ToString()]);
            front.Visuals = CustomVisuals.GetVisuals("Salt/Cannon");
            front.AnimationTarget = Targeting.Slot_Front;

            //wheeling
            EnemyAbilityInfo wheeling = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("UFO_Wheeling_A"),
                rarity = front.Rarity
            };

            //blast
            Ability blast = new Ability("Grand Blast", "GrandBlast_A");
            blast.Description = "Might deal a Deadly amount of damage to all party members.";
            blast.Rarity = Rarity.CreateAndAddCustomRarityToPool("CannonLow", 1);
            blast.Effects = Effects.GenerateEffect(ChanceZeroDamageEffect.Create(0.5f), 11, Targeting.Unit_AllOpponents).SelfArray();
            blast.AddIntentsToTarget(Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], false), [IntentType_GameIDs.Damage_11_15.ToString()]);
            blast.Visuals = LoadedAssetsHandler.GetCharacterAbility("Clobber_1_A").visuals;
            blast.AnimationTarget = Targeting.GenerateGenericTarget([0, 1, 2, 3, 4], false);

            //ADD ENEMY
            mortar.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                front.GenerateEnemyAbility(true),
                wheeling,
                blast.GenerateEnemyAbility(true)
            });
            mortar.AddEnemy(true, true);
        }
    }
}
