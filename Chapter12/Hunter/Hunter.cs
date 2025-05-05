using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Hunter
    {
        public static void Add()
        {
            Enemy hunting = new Enemy("Hunter", "Hunter_EN")
            {
                Health = 28,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("HunterIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("HunterWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("HunterDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            hunting.PrepareEnemyPrefab("assets/group4/Hunter/Hunter_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Hunter/Hunter_Gibs.prefab").GetComponent<ParticleSystem>());

            //hunting
            NormalAndConnection_PerformEffectPassiveAbility hunter = ScriptableObject.CreateInstance<NormalAndConnection_PerformEffectPassiveAbility>();
            hunter._passiveName = "Horrifying";
            hunter.passiveIcon = ResourceLoader.LoadSprite("hunterpassive.png");
            hunter.m_PassiveID = "Horrifying_PA";
            hunter._enemyDescription = "At the start of combat, apply Terror to a random party member. At the end of each of this enemy's turns, if the Opposing party member has Terror instantly kill them.";
            hunter._characterDescription = "At the start of combat, apply Terror to a random enemy. At the end of each turn, if the Opposing enemy has Terror instantly kill them.";
            hunter.doesPassiveTriggerInformationPanel = false;
            hunter.effects = ExtensionMethods.ToEffectInfoArray(new Effect[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<TerrorDeathEffect>(), 1, null, Slots.Front) });
            hunter._triggerOn = new TriggerCalls[1] { TriggerCalls.OnTurnFinished };
            hunter.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                        new Effect(ScriptableObject.CreateInstance<ApplyTerrorEffect>(), 1, null, Targetting.Random(false))
            });

            hunting.AddPassives(new BasePassiveAbilitySO[] { Passives.Leaky1, Passives.Withering });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            hunting.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            hunting.AddEnemy(true, true);
        }
    }
}
