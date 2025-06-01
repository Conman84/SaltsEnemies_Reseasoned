using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

namespace SaltsEnemies_Reseasoned
{
    public static class TortureMeNot
    {
        public static void Add()
        {
            //forget
            NormalAndConnection_PerformEffectPassiveAbility forget = ScriptableObject.CreateInstance<NormalAndConnection_PerformEffectPassiveAbility>();
            forget._passiveName = "Forgetting";
            forget.passiveIcon = ResourceLoader.LoadSprite("ForgettingPassive.png");
            forget.m_PassiveID = "Forgetting_PA";
            forget._enemyDescription = "On dying except from Withering, spawn a random 1-tile enemy from this area.";
            forget._characterDescription = "eh";
            forget.doesPassiveTriggerInformationPanel = true;
            forget.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyFromAreaEffect>(), 0, Slots.Self).SelfArray();
            forget._triggerOn = [TriggerCalls.OnDeath];
            forget.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IsntWitheringDeathCondition>() };
            forget.disconnectionEffects = [];
            forget.connectionEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ForgettingConnectionEffect>(), 0, Slots.Self, ScriptableObject.CreateInstance<ForgettingEffectCondition>()).SelfArray();


            //hallucination
            Ability hallu = new Ability("Hallucination", "Hallucination_A");
            hallu.Description = "Move the Opposing party member to a random position.";
            hallu.Rarity = Rarity.GetCustomRarity("rarity5");
            hallu.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneFoolEffect>(), 0, Slots.Front).SelfArray();
            hallu.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Swap_Mass.ToString()]);
            hallu.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            hallu.AnimationTarget = Slots.Front;

            //addiction
            Ability addi = new Ability("Addiction", "Addiction_A");
            addi.Description = "Inflict 1 Acid on the Opposing party member.";
            addi.Rarity = hallu.Rarity;
            addi.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyAcidEffect>(), 1, Slots.Front).SelfArray();
            addi.AddIntentsToTarget(Slots.Front, [Acid.Intent]);
            addi.Visuals = CustomVisuals.GetVisuals("Salt/Shush");
            addi.AnimationTarget = Slots.Front;

            EnemyAbilityInfo[] abilities = [hallu.GenerateEnemyAbility(true), addi.GenerateEnemyAbility(true)];

            //generate default
            Generate("TortureMeNot_EN", "ForgetWorld.png", forget, abilities);

            //generate cruelties
            Generate("Cruelties_1_EN", "Cruelties_1.png", forget, abilities);
            Generate("Cruelties_2_EN", "Cruelties_2.png", forget, abilities);
            Generate("Cruelties_3_EN", "Cruelties_3.png", forget, abilities);
            Generate("Cruelties_4_EN", "Cruelties_4.png", forget, abilities);
            Generate("Cruelties_5_EN", "Cruelties_5.png", forget, abilities);

        }
        public static void Generate(string id, string overworld, BasePassiveAbilitySO passive, EnemyAbilityInfo[] abilities)
        {
            Enemy torture = new Enemy("Torture-Me-Not", id)
            {
                Health = 3,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("ForgetIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite(overworld, new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ForgetWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN").deathSound,
            };
            
            if (LoadedAssetsHandler.LoadedEnemies.Keys.Contains("TortureMeNot_EN"))
            {
                torture.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("TortureMeNot_EN").enemyTemplate;
            }
            else
            {
                torture.PrepareMultiEnemyPrefab("assets/16/Forget_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/16/Forget_Gibs.prefab").GetComponent<ParticleSystem>());
                (torture.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
                {
                torture.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").Find("f1").GetComponent<SpriteRenderer>(),
                torture.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").Find("f2").GetComponent<SpriteRenderer>(),
                torture.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").Find("f3").GetComponent<SpriteRenderer>(),
                torture.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").Find("f4").GetComponent<SpriteRenderer>(),
                torture.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").Find("f5").GetComponent<SpriteRenderer>(),
                };
            }



            torture.AddPassives(new BasePassiveAbilitySO[] { passive, Passives.Withering });



            //ADD ENEMY
            torture.AddEnemyAbilities(abilities);
            torture.AddEnemy(true, false, true);
        }
    }
}
