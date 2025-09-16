using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Tracker
    {
        public static void Setup()
        {
            Killed = new List<string>();
            NotificationHook.AddAction(NotifCheck);
        }
        public static List<string> Killed;
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnBeforeCombatStart.ToString()) Killed.Clear();
            if (name == TriggerCalls.OnCombatEnd.ToString())
            {
                foreach (string value in Killed)
                {
                    LoadedDBsHandler.InfoHolder.Game.SetBoolData(value, true);
                }
                Killed.Clear();
            }

            if (name == TriggerCalls.OnDeath.ToString())
            {
                if (sender is EnemyCombat enemy)
                {
                    if (enemy.Enemy.name == "EmbersofaDeadGod_EN") Killed.Add("DeadGod_EN");
                    if (enemy.Enemy.name == "TeachaMantoFish_EN") Killed.Add("Unmung_EN");
                    if (enemy.Enemy.name == "Spectre_EN") Killed.Add("Butterfly_EN");

                    if (enemy.Enemy.name == "Children6_EN") Killed.Add("Children_EN");
                    if (enemy.Enemy.name == "Children5_EN") Killed.Add("Children_EN");
                    if (enemy.Enemy.name == "Children4_EN") Killed.Add("Children_EN");
                    if (enemy.Enemy.name == "Children3_EN") Killed.Add("Children_EN");
                    if (enemy.Enemy.name == "Children2_EN") Killed.Add("Children_EN");
                    if (enemy.Enemy.name == "Children1_EN") Killed.Add("Children_EN");
                    if (enemy.Enemy.name == "Children0_EN") Killed.Add("Children_EN");
                    if (enemy.Enemy.name == "ChildrenPrayer_EN") Killed.Add("Children_EN");

                    if (enemy.Enemy.name == "Cruelties_1_EN") Killed.Add("TortureMeNot_EN");
                    if (enemy.Enemy.name == "Cruelties_2_EN") Killed.Add("TortureMeNot_EN");
                    if (enemy.Enemy.name == "Cruelties_3_EN") Killed.Add("TortureMeNot_EN");
                    if (enemy.Enemy.name == "Cruelties_4_EN") Killed.Add("TortureMeNot_EN");
                    if (enemy.Enemy.name == "Cruelties_5_EN") Killed.Add("TortureMeNot_EN");

                    if (enemy.Enemy.name == "Wall_2_EN") Killed.Add("Wall_EN");
                    if (enemy.Enemy.name == "33_EN") Killed.Add("Wall_EN");
                    if (enemy.Enemy.name == "Amalga_Alt_EN") Killed.Add("Amalga_EN");

                    if (enemy.Enemy.name == "Smiler_Corpse_BOSS") Killed.Add("Smilers_BOSS");
                    if (enemy.Enemy.name == "RedSky_BOSS") Killed.Add("BlueSky_BOSS");

                    if (enemy.ContainsPassiveAbility("Stained_PA")) Killed.Add("GlassedSun_EN");

                    if (Normals.Contains(enemy.Enemy.name)) Killed.Add(enemy.Enemy.name);
                }
                if (sender is CharacterCombat chara)
                {
                    if (chara.Character.name == "Windle_CH") Killed.Add("Windle_EN");
                }
            }
        }
        public static string[] Normals = [
            "LostSheep_EN",
            "Enigma_EN",
            "DeadPixel_EN",
            "LittleAngel_EN",
            "Satyr_EN",
            "Something_EN",
            "Derogatory_EN",
            "Denial_EN",
            "AFlower_EN",
            "TheCrow_EN",
            "Freud_EN",
            "StarGazer_EN",
            "CoinHunter_EN",
            "MechanicalLens_EN",
            "MortalSpoggle_EN",
            "RusticJumbleguts_EN",
            "Delusion_EN",
            "FakeAngel_EN",
            Flower.Red,
            Flower.Blue,
            Flower.Yellow,
            Flower.Purple,
            "TheDeep_EN",
            "Postmodern_EN",
            "War_EN",
            "ClockTower_EN",
            Enemies.Tank,
            "Sigil_EN",
            Enemies.Solvent,
            "WindSong_EN",
            "Grandfather_EN",
            Flower.Grey,
            "StalwartTortoise_EN",
            "EyePalm_EN",
            "Merced_EN",
            "Miriam_EN",
            "MiniReaper_EN",
            "Shua_EN",
            "Skyloft_EN",
            "Damocles_EN",
            "GlassFigurine_EN",
            "SnakeGod_EN",
            "Nameless_EN",
            "Rabies_EN",
            "Tripod_EN",
            "Firebird_EN",
            "Hunter_EN",
            "LittleBeak_EN",
            "Warbird_EN",
            "BlackStar_EN",
            "Singularity_EN",
            "Indicator_EN",
            "Maw_EN",
            "Windle_EN",
            "Clione_EN",
            "Arceles_EN",
            "Stoplight_EN",
            "Pinano_EN",
            "Minana_EN",
            "YNL_EN",
            Bots.Red,
            Bots.Blue,
            Bots.Yellow, 
            Bots.Purple,
            Bots.Grey,
            "GlassedSun_EN",
            "Crystal_EN",
            "CandyStone_EN",
            "TheDragon_EN",
            "OdeToHumanity_EN",
            "TortureMeNot_EN",
            "EvilDog_EN",
            "Evileye_EN",
            "NobodyGrave_EN",
            "Defender_EN",
            "YellowAngel_EN",
            "Complimentary_EN",
            "PersonalAngel_EN",
            Enemies.Shooter,
            "SkeletonHead_EN",
            "Sinker_EN",
            "PawnA_EN",
            "Starless_EN",
            "Eyeless_EN",
            "Wednesday_EN",
            "Yin_EN",
            "Yang_EN",
            "2009_EN",
            "Chiito_EN",
            "Foxtrot_EN",
            "Solitaire_EN",
            "Spades_EN",
            "Author_EN",
            "Monster_EN",
            "Clown_EN",
            "Waltz_EN",
            "VoiceTrumpet_EN",
            "Wall_EN",
            "Amalga_EN",
            "Smilers_BOSS",
            "CrowChild_BOSS",
            "BlackAndBlue_BOSS",
            "Megalania_BOSS",
            "Invention_BOSS",
            ];
    }
}
