using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Waltz
    {
        public static void Add()
        {
            Enemy waltz = new Enemy("Waltz", "Waltz_EN")
            {
                Health = 7,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("WaltzIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WaltzWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WaltzDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Delusion_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Starless_EN").deathSound,
            };
            waltz.PrepareEnemyPrefab("assets/enem4/Waltz_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/enem4/Waltz_Gibs.prefab").GetComponent<ParticleSystem>());

            ExtraAbilityInfo nibble = new ExtraAbilityInfo();
            nibble.rarity = Rarity.Impossible;
            nibble.ability = LoadedAssetsHandler.GetEnemyAbility("Nibble_A");

            waltz.AddPassives(new BasePassiveAbilitySO[] { Passives.Infantile, Passives.ParentalGenerator(nibble) });

            AbilitySelector_Bots selector = ScriptableObject.CreateInstance<AbilitySelector_Bots>();
            selector.Isolate = ["Salt_Exhaustion_A"];
            waltz.AbilitySelector = selector;

            Ability exhaust = new Ability("Exhaustion", "Salt_Exhaustion_A");
            exhaust.Description = "Move to the Left or Right and inflict 2 Constricted on this enemy.";
            exhaust.Rarity = Rarity.GetCustomRarity("rarity5");
            exhaust.Effects = new EffectInfo[2];
            exhaust.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            exhaust.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, Slots.Self);
            exhaust.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Field_Constricted.ToString()]);
            exhaust.Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;
            exhaust.AnimationTarget = Slots.Self;

            Ability collapse = new Ability("Collapse", "Salt_Collapse_A");
            collapse.Description = "Deal a Painful amount of damage to this enemy.";
            collapse.Rarity = Rarity.GetCustomRarity("rarity5");
            collapse.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Self).SelfArray();
            collapse.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_3_6.ToString()]);
            collapse.Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            collapse.AnimationTarget = Slots.Self;

            //ADD ENEMY
            waltz.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                exhaust.GenerateEnemyAbility(true),
                collapse.GenerateEnemyAbility(true)
            });
            waltz.AddEnemy(true, true);
        }
    }
}
