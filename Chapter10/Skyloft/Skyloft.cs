using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Skyloft
    {
        public static void Add()
        {
            Enemy skyloft = new Enemy("Skyloft", "Skyloft_EN")
            {
                Health = 2,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("SkyloftIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SkyloftDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SkyloftWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("WindSong_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("WindSong_EN").deathSound,
            };
            skyloft.PrepareEnemyPrefab("assets/group4/Skyloft/Skyloft_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Skyloft/Skyloft_Gibs.prefab").GetComponent<ParticleSystem>());


            //EVASIVE
            Connection_PerformEffectPassiveAbility evasive = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            evasive._passiveName = "Evasive";
            evasive.passiveIcon = ResourceLoader.LoadSprite("Dodge.png");
            evasive.m_PassiveID = "Evasive_PA";
            evasive._enemyDescription = "Permanently applies Dodge to this enemy.";
            evasive._characterDescription = "Permanently applies Dodge to this character.";
            evasive.doesPassiveTriggerInformationPanel = true;
            evasive.connectionEffects = new EffectInfo] { Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPermanentDodgeEffect>(), 1, Slots.Self) }), 1, Slots.Self) });
            evasive.disconnectionEffects = new EffectInfo[0];
            evasive._triggerOn = new TriggerCalls[] { TriggerCalls.Count };

            //LAZY
            PerformEffectPassiveAbility ethereal = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            ethereal._passiveName = "Lazy";
            ethereal.passiveIcon = ResourceLoader.LoadSprite("Lazy.png");
            ethereal._enemyDescription = "When fleeing, this enemy will return at the end of the next 2 rounds if combat hasn't ended.";
            ethereal._characterDescription = "When fleeing, this character will return at the end of the next 2 rounds if combat hasn't ended.";
            ethereal.m_PassiveID = ButterflyUnboxer.SkyloftPassive;
            ethereal.doesPassiveTriggerInformationPanel = true;
            ethereal._triggerOn = new TriggerCalls[] { TriggerCalls.OnFleeting };
            ethereal.effects = new EffectInfo[0];
            ethereal.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<NotFlitheringCondition>() };

            //FLITHERING
            PerformEffectPassiveAbility flither = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            flither._passiveName = "Flithering";
            flither.passiveIcon = ResourceLoader.LoadSprite("FlitheringIcon.png");
            flither.m_PassiveID = FlitheringHandler.Flithering;
            flither._enemyDescription = "On any enemy dying, if there are no other enemies without \"Withering\" or \"Flithering\" as passives, instantly flee.\n" +
                "At the start and end of the enemies' turn, if there are no other enemies without \"Cowardice\" or \"Flithering\" as passives, instantly flee.";
            flither._characterDescription = "doesnt work";
            flither.doesPassiveTriggerInformationPanel = false;
            flither.effects = new EffectInfo[] { Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CowardEffect>(), 1, Slots.Self)
            }), 1, Slots.Self) });
            flither._triggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy, TriggerCalls.OnRoundFinished };
            flither.conditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<CowardCondition>()
            };
        }
    }
}
