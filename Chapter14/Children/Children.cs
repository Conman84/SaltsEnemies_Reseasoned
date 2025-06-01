using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Children
    {
        public static void Add()
        {
            //pasives
            ChildrenPassiveAbility whimsy = ScriptableObject.CreateInstance<ChildrenPassiveAbility>();
            whimsy._passiveName = "Whimsy";
            whimsy.m_PassiveID = "Whimsy_PA";
            whimsy.passiveIcon = ResourceLoader.LoadSprite("WileyPassive.png");
            whimsy._enemyDescription = "Most Status Effects and some Field Effects will no longer decrease while this unit is in combat.";
            whimsy._characterDescription = whimsy._enemyDescription;
            whimsy.doesPassiveTriggerInformationPanel = false;
            whimsy._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged, TriggerCalls.OnRoundFinished, TriggerCalls.OnDeath };

            PerformEffectPassiveAbility degay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            degay._passiveName = "Decay";
            degay.m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            degay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            degay._enemyDescription = "On death, lose a part of yourself.";
            degay._characterDescription = degay._enemyDescription;
            degay.doesPassiveTriggerInformationPanel = false;
            degay._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
            degay.effects = new EffectInfo[0];


            //abilities
            Ability slop = new Ability("Slop", "Children_Slop_A");
            slop.Description = "Inflict 1 Mold on this position and on the Opposing position.";
            slop.Rarity = Rarity.GetCustomRarity("rarity5");
            slop.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMoldFieldEffect>(), 1, MultiTargetting.Create(Slots.Self, Slots.Front)).SelfArray();
            slop.AddIntentsToTarget(Slots.Front, [Mold.Intent]);
            slop.AddIntentsToTarget(Slots.Self, [Mold.Intent]);
            slop.Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            slop.AnimationTarget = MultiTargetting.Create(Slots.Self, Slots.Front);

            Ability pingo = new Ability("Pingo_A")
            {
                Name = "Pingo",
                Description = "Inflict 1 Parasitism on the Opposing party member. If successful, instantly kill this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ParasiteEffection.apply, 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self, BasicEffects.DidThat(true))
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals,
                AnimationTarget = Slots.Front,
            };
            pingo.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.PA_Parasitism.ToString()]);
            pingo.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_Death.ToString()]);

            Ability war = new Ability("War", "Children_War_A");
            war.Description = "Inflict 1 Frail, Oil-Slicked, and Ruptured on the Opposing party member.";
            war.Rarity = Rarity.GetCustomRarity("rarity5");
            war.Effects = new EffectInfo[3];
            war.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, Slots.Front);
            war.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 1, Slots.Front);
            war.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Front);
            war.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Status_Frail.ToString(), IntentType_GameIDs.Status_OilSlicked.ToString(), IntentType_GameIDs.Status_Ruptured.ToString()]);
            war.Visuals = LoadedAssetsHandler.GetCharacterAbility("Clobber_1_A").visuals;
            war.AnimationTarget = Slots.Front;

            EnemyAbilityInfo[] abilis = 
                [slop.GenerateEnemyAbility(true),
                pingo.GenerateEnemyAbility(true),
                war.GenerateEnemyAbility(true)];


            //add

            Add6([whimsy, degay, Passives.Withering], abilis);
            Add5([whimsy, degay, Passives.Withering], abilis);
            Add4([whimsy, degay, Passives.Withering], abilis);
            Add3([whimsy, degay, Passives.Withering], abilis);
            Add2([whimsy, degay, Passives.Withering], abilis);
            Add1([whimsy, Passives.Withering], abilis);
            Add0([whimsy, Passives.Withering], abilis);
            Add00([whimsy, Passives.Withering], abilis);
        }

        public static void Add6(BasePassiveAbilitySO[] passives, EnemyAbilityInfo[] abilities)
        {
            Enemy child = new Enemy("Children of God", "Children6_EN");
            child.Health = 1;
            child.HealthColor = Pigments.Grey;
            child.OverworldAliveSprite = ResourceLoader.LoadSprite("Children6World.png", new Vector2(0.5f, 0));
            child.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", new Vector2(0.5f, 0));
            child.CombatSprite = ResourceLoader.LoadSprite("Children6Icon.png");
            child.DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound;
            child.DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;
            child.PrepareMultiEnemyPrefab("assets/Children/Children6_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>());
            (child.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (4)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            child.AddPassives(passives);
            child.AddEnemyAbilities(abilities);
            child.AddEnemy(true, false, true);
        }
        public static void Add5(BasePassiveAbilitySO[] passives, EnemyAbilityInfo[] abilities)
        {
            Enemy child = new Enemy("Children of God", "Children5_EN");
            child.Health = 1;
            child.HealthColor = Pigments.Grey;
            child.OverworldAliveSprite = ResourceLoader.LoadSprite("Children5World.png");
            child.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png");
            child.CombatSprite = ResourceLoader.LoadSprite("Children5Icon.png");
            child.DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound;
            child.DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;
            child.PrepareMultiEnemyPrefab("assets/Children/Children5_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>());
            (child.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            child.AddPassives(passives);
            child.AddEnemyAbilities(abilities);
            child.AddEnemy();
        }
        public static void Add4(BasePassiveAbilitySO[] passives, EnemyAbilityInfo[] abilities)
        {
            Enemy child = new Enemy("Children of God", "Children4_EN");
            child.Health = 1;
            child.HealthColor = Pigments.Grey;
            child.OverworldAliveSprite = ResourceLoader.LoadSprite("Children4World.png");
            child.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png");
            child.CombatSprite = ResourceLoader.LoadSprite("Children4Icon.png");
            child.DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound;
            child.DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;
            child.PrepareMultiEnemyPrefab("assets/Children/Children4_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>());
            (child.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            child.AddPassives(passives);
            child.AddEnemyAbilities(abilities);
            child.AddEnemy();
        }
        public static void Add3(BasePassiveAbilitySO[] passives, EnemyAbilityInfo[] abilities)
        {
            Enemy child = new Enemy("Children of God", "Children3_EN");
            child.Health = 1;
            child.HealthColor = Pigments.Grey;
            child.OverworldAliveSprite = ResourceLoader.LoadSprite("Children3World.png");
            child.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png");
            child.CombatSprite = ResourceLoader.LoadSprite("Children3Icon.png");
            child.DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound;
            child.DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;
            child.PrepareMultiEnemyPrefab("assets/Children/Children3_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>());
            (child.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            child.AddPassives(passives);
            child.AddEnemyAbilities(abilities);
            child.AddEnemy();
        }
        public static void Add2(BasePassiveAbilitySO[] passives, EnemyAbilityInfo[] abilities)
        {
            Enemy child = new Enemy("Children of God", "Children2_EN");
            child.Health = 1;
            child.HealthColor = Pigments.Grey;
            child.OverworldAliveSprite = ResourceLoader.LoadSprite("Children2World.png");
            child.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png");
            child.CombatSprite = ResourceLoader.LoadSprite("Children2Icon.png");
            child.DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound;
            child.DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;
            child.PrepareMultiEnemyPrefab("assets/Children/Children2_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>());
            (child.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            child.AddPassives(passives);
            child.AddEnemyAbilities(abilities);
            child.AddEnemy();
        }
        public static void Add1(BasePassiveAbilitySO[] passives, EnemyAbilityInfo[] abilities)
        {
            Enemy child = new Enemy("Child of God", "Children1_EN");
            child.Health = 1;
            child.HealthColor = Pigments.Grey;
            child.OverworldAliveSprite = ResourceLoader.LoadSprite("Children1World.png");
            child.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png");
            child.CombatSprite = ResourceLoader.LoadSprite("Children1Icon.png");
            child.DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound;
            child.DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;
            child.PrepareEnemyPrefab("assets/Children/Children1_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>());
            child.AddPassives(passives);
            child.AddEnemyAbilities(abilities);
            child.AddEnemy();
        }
        public static void Add0(BasePassiveAbilitySO[] passives, EnemyAbilityInfo[] abilities)
        {
            Enemy child = new Enemy("Ghost of Child of God", "Children0_EN");
            child.Health = 1;
            child.HealthColor = Pigments.Grey;
            child.OverworldAliveSprite = ResourceLoader.LoadSprite("Children0World.png");
            child.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png");
            child.CombatSprite = ResourceLoader.LoadSprite("Children0Icon.png");
            child.DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound;
            child.DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;
            child.PrepareEnemyPrefab("assets/Children/Children0_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/Children/Children_Ghost_Gibs.prefab").GetComponent<ParticleSystem>());
            child.AddPassives(passives);
            child.AddEnemyAbilities(abilities);
            child.AddEnemy();
        }
        public static void Add00(BasePassiveAbilitySO[] passives, EnemyAbilityInfo[] abilities)
        {
            Enemy child = new Enemy("PrayerFool_BOMOD", "ChildrenPrayer_EN");
            child.Health = 1;
            child.HealthColor = Pigments.Grey;
            child.OverworldAliveSprite = ResourceLoader.LoadSprite("Children00World.png");
            child.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png");
            child.CombatSprite = ResourceLoader.LoadSprite("Children00Icon.png");
            child.DamageSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
            child.DeathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound;
            child.PrepareEnemyPrefab("assets/Children/Children00_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/Children/Children_Prayer_Gibs.prefab").GetComponent<ParticleSystem>());
            child.AddPassives(passives);
            child.AddEnemyAbilities(abilities);
            child.AddEnemy();
        }
    }
}
