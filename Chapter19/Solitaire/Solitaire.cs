using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Solitaire
    {
        public static void Add()
        {
            SolitaireHandler.Setup();
            Enemy tv = new Enemy("Solitaire", "Solitaire_EN")
            {
                Health = 20,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("PawnIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PawnWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PawnDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/DeadPixelHurt",
                DeathSound = "event:/Hawthorne/Die/DeadPixelDie",
            };
            tv.PrepareEnemyPrefab("Assets/enem3/Solitaire_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Pawn_Gibs.prefab").GetComponent<ParticleSystem>());

            AbilitySelector_Heaven selector = ScriptableObject.CreateInstance<AbilitySelector_Heaven>();
            selector._ComeHomeAbility = "Dreamers_A";
            selector._useAfterTurns = 1;
            tv.AbilitySelector = selector;
            tv.AddPassives(new BasePassiveAbilitySO[] { Passives.TwoFaced, Passives.Forgetful });

            //tp garden cuz fuck you
            Ability dreamers = new Ability("A Dream Within A Dream", "Dreamers_A");
            dreamers.Description = "\"Somewhere better than here\"";
            dreamers.Rarity = Rarity.GetCustomRarity("rarity5");
            dreamers.Priority = Priority.CreateAndAddCustomPriorityToPool("SUPERFUCKINGSLOW", -99);
            dreamers.Effects = new EffectInfo[5];
            dreamers.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 2, Slots.Self);
            dreamers.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToGardenEffect>(), 1, Slots.Self);
            dreamers.Effects[2] = Effects.GenerateEffect(SolitaireSpawnGardenEnemiesEffect.Create(true), 2, Slots.Self, ScriptableObject.CreateInstance<TwoTileEnemySpacesEffectCondition>());
            dreamers.Effects[3] = Effects.GenerateEffect(SolitaireSpawnGardenEnemiesEffect.Create(false), 2, Slots.Self, DoubleCondition.Create(ScriptableObject.CreateInstance<TwoEnemySpacesEffectCondition>(), BasicEffects.DidThat(false), true));
            dreamers.Effects[4] = Effects.GenerateEffect(SolitaireSpawnGardenEnemiesEffect.Create(false), 1, Slots.Self, ScriptableObject.CreateInstance<NotTwoEnemySpacesEffectCondition>());
            dreamers.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc.ToString()]);
            dreamers.Visuals = CustomVisuals.GetVisuals("Salt/Curtains");
            dreamers.AnimationTarget = Slots.Self;


            //ADD ENEMY
            tv.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                dreamers.GenerateEnemyAbility(true),
            });
            tv.AddEnemy(true, true);
        }
    }
}
