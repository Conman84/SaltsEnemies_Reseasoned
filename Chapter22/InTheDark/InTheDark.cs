using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class InTheDark
    {
        public static void Add()
        {
            Enemy dark = new Enemy("In The Dark", "InTheDark_EN")
            {
                Health = 50,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("DarkIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DarkWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DarkDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("BlackStar_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("BlackStar_EN").deathSound,
            };
            dark.PrepareEnemyPrefab("Assets/Item/Dark_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Item/Dark_Gibs.prefab").GetComponent<ParticleSystem>());
            dark.enemy.enemyTemplate.m_Data.m_Renderer = dark.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>();

            PerformEffectPassiveAbility altruistic = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            altruistic.name = "Altruistic_PA";
            altruistic._passiveName = "Altruistic";
            altruistic.m_PassiveID = "Altruistic_PA";
            altruistic.passiveIcon = ResourceLoader.LoadSprite("AltruisticPassive.png");
            altruistic._enemyDescription = "On being directly damaged, apply 1 Determined to the Opposing party member.";
            altruistic._characterDescription = "On being directly damaged, apply 1 Determined to the Opposing enemy.";
            altruistic.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 1, Slots.Front)];
            altruistic._triggerOn = [TriggerCalls.OnDirectDamaged];
            altruistic.conditions = [];

            dark.AddPassives(new BasePassiveAbilitySO[] { altruistic, Passives.Forgetful, Passives.Fleeting4});

            AbilitySelector_Heaven selector = ScriptableObject.CreateInstance<AbilitySelector_Heaven>();
            selector._ComeHomeAbility = "Absurdism_A";
            dark.AbilitySelector = selector;

            RemoveStatusEffectEffect rem_frail = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            rem_frail._status = StatusField.Frail;

            Ability absurd = new Ability("Absurdism", "Absurdism_A");
            absurd.Description = "Deal an Agonizing amount of damage to all party members and remove all Frail from them.\nHeal all party members that survive.";
            absurd.Rarity = Rarity.Common;
            absurd.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Targeting.Unit_AllOpponents),
                Effects.GenerateEffect(rem_frail, 1, Targeting.Unit_AllOpponents),
                Effects.GenerateEffect(CasterRootActionEffect.Create([
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 10, Targeting.Unit_AllOpponents)
                    ]), 1, Slots.Self)
                ];
            absurd.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Damage_7_10", "Rem_Status_Frail", "Heal_5_10"]);
            absurd.AnimationTarget = Targetting.Everything(false);
            absurd.Visuals = LoadedAssetsHandler.GetCharacterAbility("Conversion_1_A").visuals;

            Ability knight = new Ability("Knight Knight Knight Knight", "4Knight_A");
            knight.Description = "Remove all Status Effects from the Opposing party member. Inflict 3 Frail on all party members not Opposing this enemy if they have no Frail.\nMove Left or Right.";
            knight.Rarity = Rarity.Common;
            knight.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailIfNoFrailEffect>(), 3, Slots.SlotTarget([-4, -3, -2, -1, 1, 2, 3, 4], false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)
                ];
            knight.AddIntentsToTarget(Slots.Front, ["Misc"]);
            knight.AddIntentsToTarget(Slots.SlotTarget([-4, -3, -2, -1, 1, 2, 3, 4], false), ["Status_Frail"]);
            knight.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            knight.AnimationTarget = Slots.Front;
            knight.Visuals = CustomVisuals.GetVisuals("Salt/Nailing");
            knight.Priority = Priority.Fast;

            Ability kill = new Ability("Killing", "Killing_A");
            kill.Description = "\"The Opposing party member suffers immensly as their skin dissolves and their flesh melts off.\"\nLower the Opposing party member's maximum health to their current health, then instantly kill them.";
            kill.Rarity = Rarity.Common;
            kill.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeMaxHealthByCurrentHealthEffect>(), 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Front)
                ];
            kill.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Other_MaxHealth_Alt.ToString(), "Damage_Death"]);
            kill.Visuals = CustomVisuals.GetVisuals("Salt/Monster");
            kill.AnimationTarget = Slots.Front;

            //ADD ENEMY
            dark.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                absurd.GenerateEnemyAbility(true),
                knight.GenerateEnemyAbility(true),
                kill.GenerateEnemyAbility(true)
            });
            dark.AddEnemy(true, true);
        }
    }
}
