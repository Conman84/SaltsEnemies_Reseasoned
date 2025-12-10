using BrutalAPI;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Lunoscope
    {
        public static void Add()
        {
            Enemy lunoscope = new Enemy("Lunoscope", "Lunoscope_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("LunoscopeIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("LunoscopeWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("LunoscopeDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            lunoscope.PrepareEnemyPrefab("assets/group4/Lunoscope/Lunoscope_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Lunoscope/Lunoscope_Gibs.prefab").GetComponent<ParticleSystem>());

            lunoscope.AddPassives(new BasePassiveAbilitySO[] { Passives.Leaky1, Passives.Withering });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            lunoscope.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            lunoscope.AddEnemy(true, true);
        }
    }
}
