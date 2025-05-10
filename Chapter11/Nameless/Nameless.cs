using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public static class Nameless
    {
        public static void Add()
        {
            Enemy template = new Enemy("", "Nameless_EN")
            {
                Health = 6,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("NamelessIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("NamelessWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("NamelessDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound,
            };
            template.PrepareEnemyPrefab("assets/group4/Nameless/Nameless_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Nameless/Nameless_Gibs.prefab").GetComponent<ParticleSystem>());

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
            }), 1, Slots.Self) };
            flither._triggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy, TriggerCalls.OnRoundFinished };
            flither.conditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<CowardCondition>()
            };

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Immortal, Passives.Fleeting4, flither });
            template.CombatExitEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnCasterGibsEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsDieCondition>()).SelfArray();


            //Nameless
            Ability nameless = new Ability("TheVolumeOfABeatingHeart_A")
            {
                Name = "The Volume of a Beating Heart",
                Description = "If the file Desktop/Nameless/Nameless.txt exists, this enemy will apply 50 Pale to all party members. Otherwise, they will do nothing. \nYou can manually delete that file to disable this ability.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(SubActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(BasicEffects.GetVisuals("DrippingsOfTheGarden_A", false, Targetting_By_NamelessFile.Create(MultiTargetting.Create(Slots.Self, Targetting.AllEnemy))), 1, Slots.Self),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, Targetting_By_NamelessFile.Create(Targetting.AllEnemy))
                    }), 1, Targetting_By_NamelessFile.Create(Slots.Self)),
                    Effects.GenerateEffect(BasicEffects.Empty, 0, Targetting_By_NamelessFile.Create(Targetting.AllEnemy))
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            nameless.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            nameless.AddIntentsToTarget(Targetting_By_NamelessFile.Create(Targetting.AllEnemy), [Pale.Intent]);


            //nobody move handler
            Ability nobody = new Ability("IfNobodyMoves_A")
            {
                Name = "If Nobody Moves",
                Description = "Inflict 1 Ruptured on every party member who moved since the start of the last turn.\n\"Nobody will get hurt\"",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Targetting_By_Moved.Create(false)),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("ThePact_A").visuals,
                AnimationTarget = Targetting_By_Moved.Create(false),
            };
            nobody.AddIntentsToTarget(Targetting.Everything(false), [IntentType_GameIDs.Misc_Hidden.ToString()]);
            nobody.AddIntentsToTarget(Targetting_By_Moved.Create(false), [IntentType_GameIDs.Status_Ruptured.ToString()]);

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                nameless.GenerateEnemyAbility(true),
                nobody.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true, true);
        }
    }
}
