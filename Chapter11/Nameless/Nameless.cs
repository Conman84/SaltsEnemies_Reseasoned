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
                Health = 41,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("NamelessIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("NamelessWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("NamelessDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sosn2/NamelessHit",
                DeathSound = "event:/Hawthorne/Sosn2/NamelessDie",
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Nameless>()
            };
            template.PrepareEnemyPrefab("assets/group4/Nameless/Nameless_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Nameless/Nameless_Gibs.prefab").GetComponent<ParticleSystem>());

            GenerateRandomManaBetweenEffect randomize = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            randomize.possibleMana = [Pigments.Red, Pigments.Blue, Pigments.Blue, Pigments.Yellow, Pigments.Yellow, Pigments.Purple, Pigments.Purple];

            PerformEffectPassiveAbility fractal = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fractal.name = "Fractal_3_PA";
            fractal._passiveName = "Fractal (3)";
            fractal.passiveIcon = ResourceLoader.LoadSprite("FractalPassive.png");
            fractal.m_PassiveID = "Fractal_PA";
            fractal._enemyDescription = "At the end of the timeline, generate 3 random pigment.";
            fractal._characterDescription = fractal._enemyDescription;
            fractal.conditions = [];
            fractal._triggerOn = [StarlessPassiveAbility.Call];
            fractal.effects = [Effects.GenerateEffect(randomize, 3, Slots.Self)];

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
            //uses flithering instead of withering for the purpose of not fucking earraping you

            template.AddPassives(new BasePassiveAbilitySO[] { fractal, Passives.Fleeting4, flither });
            //template.CombatExitEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnCasterGibsEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsDieCondition>()).SelfArray();


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

            Ability cubism = new Ability("Cubibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibibism", "Cubism_A");
            cubism.Description = "Inflict 10 Entropy on the Opposing party member.";
            cubism.Rarity = Rarity.CreateAndAddCustomRarityToPool("nameless_low", 2);
            cubism.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 10, Slots.Front)];
            cubism.AddIntentsToTarget(Slots.Front, [Entropy.Intent]);
            cubism.Visuals = CustomVisuals.GetVisuals("Salt/Class");
            cubism.AnimationTarget = Slots.Front;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                nameless.GenerateEnemyAbility(true),
                nobody.GenerateEnemyAbility(true),
                cubism.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true, true);
        }
    }
}
