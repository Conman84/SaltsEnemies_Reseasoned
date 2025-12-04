using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Stalker
    {
        public static void Add()
        {
            Enemy stalker = new Enemy("Stalker 2.0", "Stalker2_EN")
            {
                Health = 10,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("StalkerIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("StalkerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("StalkerDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Ssound/StalkerHit",
                DeathSound = "event:/Hawthorne/Ssound/StalkerDie",
            };
            stalker.PrepareEnemyPrefab("Assets/Siren2/Stalker_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Siren2/Stalker_Gibs.prefab").GetComponent<ParticleSystem>());

            BasePassiveAbilitySO flee = ScriptableObject.Instantiate(Passives.FleetingGenerator(2));
            flee.name = "Fleeting_2_With_Changed_Desc";
            flee._enemyDescription += "\nOn successfully fleeing, attempt to trigger \"Withering\" on all enemies.";
            flee._characterDescription += "\nOn successfully fleeing, attempt to trigger \"Withering\" on all characters.";

            stalker.AddPassives(new BasePassiveAbilitySO[] { Passives.Immortal, flee, Passives.Anchored, Passives.Inanimate });

            stalker.CombatEnterEffects = [Effects.GenerateEffect(StalkerConnectionEffect.Create(true))];
            stalker.CombatExitEffects = [Effects.GenerateEffect(CasterRootActionEffect.Create([Effects.GenerateEffect(StalkerConnectionEffect.Create(false))]))];

            Ability safe = new Ability("SafeSpace_A");
            safe.Name = "Safe Space";
            safe.Description = "Inflict 10 Slip and 1 Ruptured on the Opposing party member.";
            safe.Rarity = Rarity.Common;
            safe.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 10, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Front),
                ];
            safe.AddIntentsToTarget(Slots.Front, [Slip.Intent, "Status_Ruptured"]);
            safe.Visuals = CustomVisuals.GetVisuals("Salt/Cube");
            safe.AnimationTarget = Slots.Front;

            Ability hate = new Ability("HateSpace_A");
            hate.Name = "Hate Space";
            hate.Description = "Deal a Little damage to the Opposing party member.\nIf damage is dealt, generate 4 Pigment of their health color.";
            hate.Rarity = Rarity.Common;
            hate.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 4, Slots.Front, BasicEffects.DidThat(true)),
                ];
            hate.AddIntentsToTarget(Slots.Front, ["Damage_1_2", "Mana_Generate"]);
            hate.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            hate.AnimationTarget = Slots.Front;

            //ADD ENEMY
            stalker.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                safe.GenerateEnemyAbility(true),
                hate.GenerateEnemyAbility(true),
            });
            stalker.AddEnemy(true, false, true);

            EnemySO clone = UnityEngine.Object.Instantiate(LoadedAssetsHandler.GetEnemy("Stalker2_EN"));
            clone.passiveAbilities = [flee, Passives.Anchored, Passives.Inanimate];
            EnemyUtils.AddEnemyToHealthSpawnPool(clone, PoolList_GameIDs.Sepulchre);
        }
    }
}
