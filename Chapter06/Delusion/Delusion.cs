using BrutalAPI;
using SaltEnemies_Reseasoned;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Delusion
    {
        public static void Add()
        {
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

            illusion.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, IllusionHandler.Illusion, Passives.Formless });

            Rarity.CreateAndAddCustomRarityToPool("Delusion_5", 5);

            illusion.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                IllusionHandler.Drain.GenerateEnemyAbility(true),
                IllusionHandler.Gnaw.GenerateEnemyAbility(false),
                IllusionHandler.SwapSupport.GenerateEnemyAbility(false)
            });
            illusion.AddEnemy(true, true);
        }
    }
}
