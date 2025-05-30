using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Foxtrot
    {
        public static void Add()
        {
            Enemy foxtrot = new Enemy("Foxtrot", "Foxtrot_EN")
            {
                Health = 15,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("FoxtrotIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("FoxtrotDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("FoxtrotWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sund/FoxtrotHit",
                DeathSound = "event:/Hawthorne/Sund/FoxtrotDie"
            };
            foxtrot.PrepareMultiEnemyPrefab("Assets/enem3/Foxtrot_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Foxtrot_Gibs.prefab").GetComponent<ParticleSystem>());
            (foxtrot.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                foxtrot.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Handle").Find("Outline").GetComponent<SpriteRenderer>(),
            };

            //RUPTURE
            Connection_PerformEffectPassiveAbility rupture = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            rupture._passiveName = "Enruptured";
            rupture.passiveIcon = ResourceLoader.LoadSprite("enrupture");
            rupture.m_PassiveID = "Enruptured_PA";
            rupture._enemyDescription = "Permanently applies Ruptured to this enemy.";
            rupture._characterDescription = "Permanently applies Ruptured to this character.";
            rupture.doesPassiveTriggerInformationPanel = true;
            rupture.connectionEffects = Effects.GenerateEffect(CasterSubActionEffect.Create(Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPermanentRupturedEffect>(), 1, Slots.Self).SelfArray()), 1, Slots.Self).SelfArray();
            rupture.disconnectionEffects = new EffectInfo[0];
            rupture._triggerOn = new TriggerCalls[] { TriggerCalls.Count };

            //Marching
            MarchingHandler.Setup();
            PerformEffectPassiveAbility march = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            march._passiveName = "Marching";
            march.passiveIcon = ResourceLoader.LoadSprite("MarchingPassive.png");
            march.m_PassiveID = MarchingHandler.Passive;
            march._enemyDescription = "On any enemy without \"Marching\" as a passive moving, move Left or Right.";
            march._characterDescription = "On any party member without \"Marching\" as a passive moving, move Left or Right.";
            march.doesPassiveTriggerInformationPanel = false;
            march.effects = new EffectInfo[2];
            march.effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<MarchingEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsAliveEffectCondition>());
            march.effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsAliveEffectCondition>());
            march.conditions = [ScriptableObject.CreateInstance<IsAliveEffectorCondition>()];
            march._triggerOn = [MarchingHandler.Call];

            foxtrot.AddPassives(new BasePassiveAbilitySO[] { march, rupture });
            AbilitySelector_Foxtrot selector = ScriptableObject.CreateInstance<AbilitySelector_Foxtrot>();
            selector._passive = MarchingHandler.Passive;
            selector._hasPassive = "TakeRoot_A";
            selector._hasntPassive = "BlowUp_A";
            foxtrot.AbilitySelector = selector;

            //pokey
            Ability pokey = new Ability("Pokey-Pokey", "PokeyPokey_A");
            pokey.Description = "Deal a Little damage to the Opposing party member.";
            pokey.Rarity = Rarity.CreateAndAddCustomRarityToPool("fox10", 10);
            pokey.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front).SelfArray();
            pokey.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_1_2.ToString()]);
            pokey.Visuals = CustomVisuals.GetVisuals("Salt/Needle");
            pokey.AnimationTarget = Slots.Front;

            //root
            //can only be used when has "marching" passive
            Ability root = new Ability("Take Root", "TakeRoot_A");
            root.Description = "Remove \"Marching\" as a passive from this enemy.\nApply 6 Power to this enemy.";
            root.Rarity = Rarity.CreateAndAddCustomRarityToPool("fox_low", 5);
            root.Effects = new EffectInfo[3];
            root.Priority = Priority.Slow;
            RemovePassiveEffect anti = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            anti.m_PassiveID = MarchingHandler.Passive;
            root.Effects[0] = Effects.GenerateEffect(anti, 1, Slots.Self);
            root.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<MarchingRemovedEffect>(), 1, Slots.Self);
            root.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 6, Slots.Self);
            Intents.CreateAndAddCustom_Basic_IntentToPool("Marching_PA", ResourceLoader.LoadSprite("MarchingPassive.png"), Color.white);
            root.AddIntentsToTarget(Slots.Self, ["Marching_PA", Power.Intent]);
            root.Visuals = LoadedAssetsHandler.GetCharacterAbility("Thorns_1_A").visuals;
            root.AnimationTarget = Slots.Self;

            //explode
            //can only be used when does not have "marching" passive
            Ability bomb = new Ability("Blow Up", "BlowUp_A");
            bomb.Description = "Deal almost no damage to the Left, Right, and Opposing party members.\nInstantly kill this enemy.";
            bomb.Rarity = Rarity.CreateAndAddCustomRarityToPool("fox_high", 25);
            bomb.Effects = new EffectInfo[2];
            bomb.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Slots.FrontLeftRight);
            bomb.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self);
            bomb.AddIntentsToTarget(Slots.FrontLeftRight, [IntentType_GameIDs.Damage_1_2.ToString()]);
            bomb.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_Death.ToString()]);
            bomb.Visuals = CustomVisuals.GetVisuals("Salt/Gears");
            bomb.AnimationTarget = Slots.Self;

            //ADD ENEMY
            foxtrot.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                pokey.GenerateEnemyAbility(true),
                root.GenerateEnemyAbility(true),
                bomb.GenerateEnemyAbility(true)
            });
            foxtrot.AddEnemy(true, true);
        }
    }
}
