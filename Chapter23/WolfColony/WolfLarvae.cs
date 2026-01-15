using BrutalAPI;
using SaltEnemies_Reseasoned;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class WolfLarvae
    {
        public static void Add()
        {
            Enemy larva = new Enemy("Wolf Larvae", "WolfLarvae_EN")
            {
                Health = 8,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("LarvaeIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("LarvaeWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("LarvaeDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Ssound/PupHit",
                DeathSound = "event:/Hawthorne/Ssound/PupDie",
            };
            larva.PrepareEnemyPrefab("Assets/Siren2/WolfLarvae_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Siren2/WolfLarvae_Gibs.prefab").GetComponent<ParticleSystem>());

            larva.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Enfeebled, Passives.Withering });

            Ability reverse = new Ability("ReverseChomp_A");
            reverse.Name = "Reverse Chomp";
            reverse.Description = "Slightly heal the Opposing party member.\nIf no healing is dealt, deal a Painful amount of damage to them.";
            reverse.Rarity = Rarity.GetCustomRarity("rarity5");
            reverse.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 4, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front, BasicEffects.DidThat(false))
                ];
            reverse.AddIntentsToTarget(Slots.Front, ["Heal_1_4", "Damage_3_6"]);
            reverse.Visuals = Visuals.Chomp;
            reverse.AnimationTarget = Slots.Front;

            Ability marrow = new Ability("MarrowRot_A");
            marrow.Name = "Marrow Rot";
            marrow.Description = "Curse the Opposing and Right party members and this enemy.";
            marrow.Rarity = Rarity.GetCustomRarity("rarity5");
            marrow.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Targeting.Slot_FrontAndRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Self)];
            marrow.AddIntentsToTarget(Targeting.Slot_FrontAndRight, ["Status_Cursed"]);
            marrow.AddIntentsToTarget(Slots.Self, ["Status_Cursed"]);
            marrow.Visuals = CustomVisuals.GetVisuals("Salt/Keyhole");
            marrow.AnimationTarget = Slots.Front;

            DamageEffect onkill = ScriptableObject.CreateInstance<DamageEffect>();
            onkill._returnKillAsSuccess = true;
            ExtraLootEffect shops = ScriptableObject.CreateInstance<ExtraLootEffect>();
            shops._isTreasure = false;
            Ability anticanine = new Ability("Anticanine_A");
            anticanine.Name = "Anticanine";
            anticanine.Description = "Deal a Little damage to the Opposing party member.\nIf this move kills, produce 20 Shop items.";
            anticanine.Rarity = Rarity.CreateAndAddCustomRarityToPool("larvaeLow", 1);
            anticanine.Effects = [
                Effects.GenerateEffect(onkill, 2, Slots.Front),
                Effects.GenerateEffect(shops, 20, Slots.Self, BasicEffects.DidThat(true))
                ];
            anticanine.AddIntentsToTarget(Slots.Front, ["Damage_1_2"]);
            anticanine.AddIntentsToTarget(Slots.Self, ["Misc"]);
            anticanine.Visuals = Visuals.Nibble;
            anticanine.AnimationTarget = Slots.Front;

            //ADD ENEMY
            larva.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                reverse.GenerateEnemyAbility(true),
                marrow.GenerateEnemyAbility(true),
                anticanine.GenerateEnemyAbility(true)
            });
            larva.AddEnemy(true, true, true);
        }
    }
}
