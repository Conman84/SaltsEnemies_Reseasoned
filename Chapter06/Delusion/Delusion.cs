using BrutalAPI;
using SaltEnemies_Reseasoned;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Delusion
    {
        public static void Add()
        {
            IllusionHandler.Setup();

            Enemy illusion = new Enemy("Delusion", "Delusion_EN")
            {
                Health = 20,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("IllusionIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("IllusionDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("IllusionWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noi3e/DelusionHit",
                DeathSound = "event:/Hawthorne/Noi3e/DelusionDie",
            };
            illusion.PrepareEnemyPrefab("assets/group4/Illusion/Illusion_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Illusion/Illusion_Gibs.prefab").GetComponent<ParticleSystem>());

            illusion.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Forgetful });

            Rarity.CreateAndAddCustomRarityToPool("Delusion_5", 5);

            illusion.CombatEnterEffects = [Effects.GenerateEffect(BasicEffects.SetStoreValue(IllusionHandler.State), 2, Targeting.Slot_SelfSlot)];

            Ability prickle = new Ability("Prickle", "Delusion_Prickle_A");
            prickle.Description = "Deal an Agonizing amount of damage to the Opposing party member, then Heal them.";
            prickle.Rarity = Rarity.CreateAndAddCustomRarityToPool("Delusion_2", 3);
            prickle.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 7, Slots.Front)
                ];
            prickle.AddIntentsToTarget(Slots.Front, ["Damage_7_10", "Heal_5_10"]);
            prickle.AnimationTarget = Slots.Front;
            prickle.Visuals = Visuals.Nibble;

            illusion.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                IllusionHandler.Haunt.GenerateEnemyAbility(true),
                IllusionHandler.Insight.GenerateEnemyAbility(true),
                prickle.GenerateEnemyAbility(true),
                IllusionHandler.ResetDefault.GenerateEnemyAbility(false)
            });
            illusion.AddEnemy(true, true);
            illusion.enemy.AddToSynodPool();
        }
    }
}
