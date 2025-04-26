using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class MechanicalLens
    {
        public static void Add()
        {
            //ADD THE NEW ICON FOR FAV PICTURE
            //Enemy Code
            Enemy MechanicalLens = new Enemy("Mechanical Lens", "MechanicalLens_EN")
            {
                Health = 1000,
                HealthColor = Pigments.Grey,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("DroneIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DroneDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DroneIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Nois2/CameraHurt",
                DeathSound = "event:/Hawthorne/Nois2/CameraDeath",
            };
            MechanicalLens.PrepareMultiEnemyPrefab("assets/camera/Camera_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/camera/Camera_Gibs.prefab").GetComponent<ParticleSystem>());
            (MechanicalLens.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                MechanicalLens.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Wings").GetComponent<SpriteRenderer>()
            };
            MechanicalLens.AddPassives(new BasePassiveAbilitySO[]
            {
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1]
            });

            //Lens Flash
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;

            Ability lens = new Ability("Lens Flash", "Salt_LensFlash_A");
            lens.Description = "Move towards the closest party member. Add one of the opposing party member's ability to this enemy's moveset and attempt to copy a random passive from them.";
            lens.Rarity = Rarity.GetCustomRarity("rarity5");
            lens.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveFavoritePictureEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<LensFlashEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<StealRandomPassiveEffect>(), 1, Targeting.Slot_Front, didThat),
            };
            lens.Visuals = null;
            lens.AnimationTarget = Targeting.Slot_SelfSlot;
            lens.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Sides"
            });
            lens.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Misc"
            });

            //Favorite Picture
            Ability picture = new Ability("Favorite Picture", "Salt_FavoritePicture_A");
            picture.Description = "Move towards the closest party member. \nCopy the max health and health color of the opposing party member. Attempt to copy their passives as well; does not copy more complex passives. \nIf successful, remove this ability from this enemy's ability pool.";
            picture.Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity999", 999);
            picture.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<FavoritePictureEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            picture.Visuals = null;
            picture.AnimationTarget = Targeting.Slot_SelfSlot;
            picture.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Sides"
            });
            picture.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Misc_Picture"
            });

            MechanicalLens.enemy.passiveAbilities[0] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(MechanicalLens.enemy.passiveAbilities[0]);
            MechanicalLens.enemy.passiveAbilities[0]._passiveName = "Lens Flash";
            MechanicalLens.enemy.passiveAbilities[0]._enemyDescription = "Mechanical Lens will perforn an extra ability \"Lens Flash\" each turn.";
            ((ExtraAttackPassiveAbility)MechanicalLens.enemy.passiveAbilities[0])._extraAbility.ability = lens.GenerateEnemyAbility(true).ability;

            //Add
            MechanicalLens.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                picture.GenerateEnemyAbility(true)
            });
            MechanicalLens.AddEnemy(true, false, false);
        }
    }
}
