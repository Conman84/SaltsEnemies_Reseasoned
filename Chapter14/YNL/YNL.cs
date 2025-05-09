using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public static class YNL
    {
        public static void Add()
        {
            Enemy lobotomy = new Enemy("Your New Life!", "YNL_EN")
            {
                Health = 35,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("LobotomyIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("LobotomyWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("LobotomyDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound,
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_YNL>()
            };
            lobotomy.PrepareMultiEnemyPrefab("assets/Lobotomy/Lobotomy_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Lobotomy/Lobotomy_Gibs.prefab").GetComponent<ParticleSystem>());
            (lobotomy.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (4)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (6)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (7)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (8)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (9)").GetComponent<SpriteRenderer>(),
                lobotomy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (10)").GetComponent<SpriteRenderer>(),
            };

            //APPOINTMENT
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            DoubleExtraAttackPassiveAbility point = ScriptableObject.CreateInstance<DoubleExtraAttackPassiveAbility>();
            point.conditions = baseExtra.conditions;
            point.passiveIcon = baseExtra.passiveIcon;
            point.specialStoredData = baseExtra.specialStoredData;
            point.doesPassiveTriggerInformationPanel = baseExtra.doesPassiveTriggerInformationPanel;
            point.m_PassiveID = baseExtra.m_PassiveID;
            point._extraAbility = new ExtraAbilityInfo();
            point._extraAbility.rarity = baseExtra._extraAbility.rarity;
            point._extraAbility.cost = baseExtra._extraAbility.cost;
            point._secondExtraAbility = new ExtraAbilityInfo();
            point._secondExtraAbility.rarity = point._extraAbility.rarity;
            point._secondExtraAbility.cost = point._extraAbility.cost;
            point._passiveName = "Appointment";
            point._enemyDescription = "This enemy will perforn an extra ability \"Appointment\" each turn.";
            point._characterDescription = baseExtra._characterDescription;
            point._triggerOn = baseExtra._triggerOn;

            Ability bonus = new Ability("Appointment_A");
            bonus.Name = "Appointment";
            bonus.Description = "If there is no Opposing party member, queue \"Procedure\" as an additional action next turn.";
            bonus.Effects = new EffectInfo[3];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<IsUnitEffect>(), 1, Slots.Front);
            bonus.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Weep_A", false, Slots.Self), 1, Slots.Front, BasicEffects.DidThat(false));
            bonus.Effects[2] = Effects.GenerateEffect(BasicEffects.SetStoreValue(DoubleExtraAttackPassiveAbility.value), 1, Slots.Self, BasicEffects.DidThat(false, 2));
            bonus.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            bonus.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc_Additional.ToString()]);
            bonus.Visuals = null;
            bonus.AnimationTarget = Slots.Front;
            point._extraAbility.ability = bonus.GenerateEnemyAbility(true).ability;

            Ability bins = new Ability("Procedure_A");
            bins.Name = "Procedure";
            bins.Description = "Produce pigment of the Opposing party member's health color for their current health.";
            bins.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ProcedureEffect>(), 1, Slots.Front),
            };
            bins.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Mana_Generate.ToString()]);
            bins.Visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals;
            bins.AnimationTarget = Slots.Front;
            point._secondExtraAbility.ability = bins.GenerateEnemyAbility(true).ability;


            lobotomy.AddPassives(new BasePassiveAbilitySO[] { point, Passives.Withering });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            lobotomy.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            lobotomy.AddEnemy(true, true);
        }
    }
}
