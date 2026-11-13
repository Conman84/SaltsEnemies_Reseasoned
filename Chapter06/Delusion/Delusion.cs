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

            //illusion.CombatEnterEffects = [Effects.GenerateEffect(BasicEffects.SetStoreValue(IllusionHandler.State), 2, Targeting.Slot_SelfSlot)];

            

            illusion.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                IllusionHandler.Haunt.GenerateEnemyAbility(true),
                IllusionHandler.Insight.GenerateEnemyAbility(true),
                IllusionHandler.ResetDefault.GenerateEnemyAbility(false)
            });
            illusion.AddEnemy(true, true);
            illusion.enemy.AddToSynodPool();
            illusion.enemy.AddToEcstasyPool();

            SaltsReseasoned.PCall(Add_Enraged);
        }
        public static void Add_Enraged()
        {
            //IllusionHandler.Setup();

            Enemy illusion = new Enemy("Delusion", "DelusionAngry_EN")
            {
                Health = 20,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("IllusionIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("IllusionDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("IllusionWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noi3e/DelusionHit",
                DeathSound = "event:/Hawthorne/Noi3e/DelusionDie",
            };
            illusion.PrepareEnemyPrefab("Assets/group4/Illusion/Enraged_Enemy.prefab", SaltsReseasoned.Group4, LoadedAssetsHandler.GetEnemy("Delusion_EN").enemyTemplate.m_Data.m_Gibs);

            illusion.AddPassives(new BasePassiveAbilitySO[] { Passives.Formless, Passives.Forgetful });

            //Rarity.CreateAndAddCustomRarityToPool("Delusion_5", 5);

            //illusion.CombatEnterEffects = [Effects.GenerateEffect(BasicEffects.SetStoreValue(IllusionHandler.State), 2, Targeting.Slot_SelfSlot)];

            GenerateRandomManaBetweenEffect random = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            random.possibleMana = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            Ability prickle = new Ability("Prickle", "Delusion_Prickle_A");
            prickle.Description = "Deal an Agonizing amount of damage to the Opposing party member, then Heal them.\nGenerate 3 random Pigment.";
            prickle.Rarity = Rarity.Common;
            prickle.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 7, Slots.Front),
                            Effects.GenerateEffect(random, 3, Targeting.Slot_SelfSlot),
                ];
            prickle.AddIntentsToTarget(Slots.Front, ["Damage_7_10", "Heal_5_10"]);
            prickle.AddIntentsToTarget(Slots.Self, ["Mana_Generate"]);
            prickle.AnimationTarget = Slots.Front;
            prickle.Visuals = Visuals.Nibble;

            illusion.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                prickle.GenerateEnemyAbility(true),
                IllusionHandler.Gnaw.GenerateEnemyAbility(true),
                IllusionHandler.Drain.GenerateEnemyAbility(true),
                IllusionHandler.SwapSupport.GenerateEnemyAbility(false)
            });
            illusion.AddEnemy();
        }
    }
}
