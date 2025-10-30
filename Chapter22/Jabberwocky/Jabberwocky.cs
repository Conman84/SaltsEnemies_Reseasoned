using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Jabberwocky
    {
        public static void Add()
        {
            Enemy jabber = new Enemy("Jabberwocky", "Jabberwocky_EN")
            {
                Health = 14,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("JabberIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("JabberWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("JabberDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Indicator_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Indicator_EN").deathSound,
            };
            jabber.PrepareEnemyPrefab("Assets/Item/Jabber_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Item/Jabber_Gibs.prefab").GetComponent<ParticleSystem>());

            ObserverPassive observer = ScriptableObject.CreateInstance<ObserverPassive>();
            observer.name = "Observer_Snatch_PA";
            observer._passiveName = "Snatch";
            observer.m_PassiveID = "Observer_PA";
            observer.passiveIcon = ResourceLoader.LoadSprite("ObserverPassive.png");
            observer._enemyDescription = "Whenever a party member moves in front of this enemy, queue the ability \"Snatch.\"";
            observer._characterDescription = "nah";
            observer._triggerOn = [(TriggerCalls)AmbushManager.Patiently];
            observer.conditions = [];

            Ability snatch = new Ability("Snatch", "Snatch_A");
            snatch.Description = "Deal a Painful amount of damage to the Opposing party member.\nMove Left or Right.";
            snatch.Rarity = Rarity.Impossible;
            snatch.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)
                ];
            snatch.AddIntentsToTarget(Slots.Front, ["Damage_3_6"]);
            snatch.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            snatch.AnimationTarget = Slots.Front;
            snatch.Visuals = Visuals.Talons;

            observer._extraAbility = new ExtraAbilityInfo()
            {
                rarity = Rarity.Impossible,
                ability = snatch.GenerateEnemyAbility(true).ability,
                cost = []
            };

            jabber.AddPassives(new BasePassiveAbilitySO[] { observer });

            Ability snype = new Ability("Snype", "Snype_A");
            snype.Description = "Might deal a Painful amount of damage to the Far Far Left and Far Far Right party members.\nMove Left or Right.";
            snype.Rarity = Rarity.Common;
            snype.Effects = [Effects.GenerateEffect(ChanceZeroDamageEffect.Create(50), 4, Slots.SlotTarget([-3, 3], false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)];
            snype.AddIntentsToTarget(Slots.LeftRight, ["Misc", "Damage_3_6"]);
            snype.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            snype.Visuals = CustomVisuals.GetVisuals("Salt/Gunshot");
            snype.AnimationTarget = Slots.SlotTarget([-3, 3], false);

            Ability bander = new Ability("Bander", "Bander_A");
            bander.Description = "Focus this enemy.\nGain 2 Dodge.";
            bander.Rarity = Rarity.GetCustomRarity("rarity5");
            bander.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 2, Slots.Self),
                ];
            bander.AddIntentsToTarget(Slots.Self, ["Status_Focused", Dodge.Intent]);
            bander.AnimationTarget = Slots.Self;
            bander.Visuals = CustomVisuals.GetVisuals("Salt/Whisper");

            //ADD ENEMY
            jabber.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                snype.GenerateEnemyAbility(true),
                bander.GenerateEnemyAbility(true)
            });
            jabber.AddEnemy(true, true);
        }
    }
}
