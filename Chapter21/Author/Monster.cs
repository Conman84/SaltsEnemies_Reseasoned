using BrutalAPI;
using HarmonyLib;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Monster
    {
        public static void Add()
        {
            Enemy monster = new Enemy("Monster", "Monster_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("MonsterIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MonsterDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MonsterWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("LongLiver_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("LongLiver_CH").deathSound,
            };
            monster.PrepareEnemyPrefab("Assets/enem3/Monster_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Monster_Gibs.prefab").GetComponent<ParticleSystem>());

            //scary
            PerformEffectPassiveAbility scary = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            scary._passiveName = "Scary";
            scary.passiveIcon = ResourceLoader.LoadSprite("ScaryPassive.png");
            scary.m_PassiveID = "Scary_PA";
            scary._enemyDescription = "On being directly damaged, Curse the Opposing party member.";
            scary._characterDescription = "On being directly damaged, Curse the Opposing enemy";
            scary.doesPassiveTriggerInformationPanel = true;
            scary.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Front).SelfArray();
            scary._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };


            monster.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.MultiAttack2, scary });

            //selector
            AbilitySelector_Bots selector = ScriptableObject.CreateInstance<AbilitySelector_Bots>();
            selector.Isolate = new string[] { "Stereotype_A" };
            monster.AbilitySelector = selector;

            //music
            MonsterSongEffect increase = ScriptableObject.CreateInstance<MonsterSongEffect>();
            increase.Add = true;
            MonsterSongEffect decrease = ScriptableObject.CreateInstance<MonsterSongEffect>();
            decrease.Add = false;

            monster.CombatEnterEffects = Effects.GenerateEffect(increase).SelfArray();
            monster.CombatExitEffects = Effects.GenerateEffect(decrease).SelfArray();

            //lick
            Ability lick = new Ability("Lick", "Monster_Lick_A");
            lick.Description = "Deal a Little damage to the Opposing party member and inflict 2 Frail and 4 Oil-Slicked on them.";
            lick.Rarity = Rarity.GetCustomRarity("rarity5");
            lick.Effects = new EffectInfo[3];
            lick.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front);
            lick.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Slots.Front);
            lick.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, Slots.Front);
            lick.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Frail.ToString(), IntentType_GameIDs.Status_OilSlicked.ToString()]);
            lick.Visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals;
            lick.AnimationTarget = Slots.Front;

            //idealism
            Ability ideal = new Ability("Idealism", "Idealism_A");
            ideal.Description = "Deal a Painful amount of damage and inflict 1 Scar on the Opposing party member.";
            ideal.Rarity = Rarity.GetCustomRarity("rarity5");
            ideal.Effects = new EffectInfo[2];
            ideal.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Front);
            ideal.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Front);
            ideal.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Status_Scars.ToString()]);
            ideal.Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;
            ideal.AnimationTarget = Slots.Front;

            //brutal
            Ability brutal = new Ability("Brutalist Complex", "BrutalistComplex_A");
            brutal.Description = "Deal an Agonizing amount of damage to the Opposing party member.\nHeal the Opposing party member.";
            brutal.Rarity = Rarity.GetCustomRarity("rarity5");
            brutal.Effects = new EffectInfo[2];
            brutal.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front);
            brutal.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 10, Slots.Front);
            brutal.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Heal_5_10.ToString()]);
            brutal.Visuals = LoadedAssetsHandler.GetCharacterAbility("Conversion_1_A").visuals;
            brutal.AnimationTarget = Slots.Front;

            //stereo
            Ability stereo = new Ability("Stereotype", "Stereotype_A");
            stereo.Description = "Curse the Opposing and Left party members.";
            stereo.Rarity = Rarity.GetCustomRarity("rarity5");
            stereo.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, MultiTargetting.Create(Slots.Front, Slots.Left)).SelfArray();
            stereo.AddIntentsToTarget(MultiTargetting.Create(Slots.Front, Slots.Left), [IntentType_GameIDs.Status_Cursed.ToString()]);
            stereo.Visuals = CustomVisuals.GetVisuals("Salt/Whisper");
            stereo.AnimationTarget = MultiTargetting.Create(Slots.Front, Slots.Left);


            //ADD ENEMY
            monster.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                lick.GenerateEnemyAbility(true),
                ideal.GenerateEnemyAbility(true),
                brutal.GenerateEnemyAbility(true),
                stereo.GenerateEnemyAbility(true)
            });
            monster.AddEnemy(true, true);
        }
    }
}
