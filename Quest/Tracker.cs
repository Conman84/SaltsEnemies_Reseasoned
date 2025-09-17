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

                Check();
            }

            if (name == TriggerCalls.OnDeath.ToString())
            {
                if (args is DeathReference reference && reference.witheringDeath) return;

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
            "ToyUfo_EN",
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

        public static void Check()
        {
            InGameDataSO game = LoadedDBsHandler.InfoHolder.Game;

            if (game.GetBoolData("LostSheep_EN") && game.GetBoolData("Enigma_EN") && game.GetBoolData("DeadPixel_EN") && game.GetBoolData("LittleAngel_EN") && game.GetBoolData("DeadGod_EN"))
                game.SetBoolData("Chapter1", true);

            if (game.GetBoolData("Satyr_EN") && game.GetBoolData("Unmung_EN") && game.GetBoolData("Something_EN") && game.GetBoolData("Derogatory_EN") && game.GetBoolData("Denial_EN"))
                game.SetBoolData("Chapter2", true);

            if (game.GetBoolData("TheCrow_EN") && game.GetBoolData("Freud_EN") && game.GetBoolData("AFlower_EN") && game.GetBoolData("StarGazer_EN"))
                game.SetBoolData("Chapter3", true);

            if (game.GetBoolData("CoinHunter_EN") && game.GetBoolData(Jumble.Grey) && game.GetBoolData(Spoggle.Grey) && game.GetBoolData(Enemies.Camera))
                game.SetBoolData("Chapter4", true);

            if (game.GetBoolData("Delusion_EN") && game.GetBoolData("FakeAngel_EN") && game.GetBoolData(Flower.Red) && game.GetBoolData(Flower.Blue) && game.GetBoolData(Flower.Yellow) && game.GetBoolData(Flower.Purple))
                game.SetBoolData("Chapter6", true);

            if (game.GetBoolData("TheDeep_EN") && game.GetBoolData("Postmodern_EN") && game.GetBoolData("War_EN"))
                game.SetBoolData("Chapter7", true);

            if (game.GetBoolData("Sigil_EN") && game.GetBoolData("ClockTower_EN") && game.GetBoolData(Enemies.Tank) && game.GetBoolData(Enemies.Solvent) && game.GetBoolData("WindSong_EN"))
                game.SetBoolData("Chapter8", true);

            if (game.GetBoolData("Grandfather_EN") && game.GetBoolData(Flower.Grey) && game.GetBoolData("StalwartTortoise_EN") && game.GetBoolData("Butterfly_EN"))
                game.SetBoolData("Chapter9", true);

            if (game.GetBoolData("MiniReaper_EN") && game.GetBoolData("EyePalm_EN") && game.GetBoolData("Merced_EN") && game.GetBoolData("Miriam_EN") && game.GetBoolData("Skyloft_EN") && game.GetBoolData("Shua_EN"))
                game.SetBoolData("Chapter10", true);

            if (game.GetBoolData("Tripod_EN") && game.GetBoolData("Nameless_EN") && game.GetBoolData("Damocles_EN") && game.GetBoolData("GlassFigurine_EN") && game.GetBoolData("Rabies_EN") && game.GetBoolData("SnakeGod_EN"))
                game.SetBoolData("Chapter11", true);

            if (game.GetBoolData("LittleBeak_EN") && game.GetBoolData("Hunter_EN") && game.GetBoolData("Firebird_EN") && game.GetBoolData("Warbird_EN"))
                game.SetBoolData("Chapter12", true);

            if (game.GetBoolData("Windle_EN") && game.GetBoolData("BlackStar_EN") && game.GetBoolData("Singularity_EN") && game.GetBoolData("Indicator_EN") && game.GetBoolData("Maw_EN"))
                game.SetBoolData("Chapter13", true);

            if (game.GetBoolData("Clione_EN") && game.GetBoolData("YNL_EN") && game.GetBoolData("Arceles_EN") && game.GetBoolData("Stoplight_EN") && game.GetBoolData("Children_EN") && game.GetBoolData("Minana_EN") && game.GetBoolData("Pinano_EN"))
                game.SetBoolData("Chapter14", true);

            if (game.GetBoolData(Bots.Red) && game.GetBoolData(Bots.Yellow) && game.GetBoolData(Bots.Blue) && game.GetBoolData(Bots.Purple) && game.GetBoolData(Bots.Grey) && game.GetBoolData("GlassedSun_EN"))
                game.SetBoolData("Chapter15", true);

            if (game.GetBoolData("Crystal_EN") && game.GetBoolData("CandyStone_EN") && game.GetBoolData("TortureMeNot_EN") && game.GetBoolData("TheDragon_EN") && game.GetBoolData("OdeToHumanity_EN"))
                game.SetBoolData("Chapter16", true);

            if (game.GetBoolData("ToyUfo_EN") && game.GetBoolData("Evileye_EN") && game.GetBoolData("YellowAngel_EN") && game.GetBoolData("NobodyGrave_EN") && game.GetBoolData("Defender_EN") && game.GetBoolData("EvilDog_EN"))
                game.SetBoolData("Chapter17", true);

            if (game.GetBoolData("Sinker_EN") && game.GetBoolData(Enemies.Shooter) && game.GetBoolData("SkeletonHead_EN") && game.GetBoolData("PersonalAngel_EN") && game.GetBoolData("Complimentary_EN"))
                game.SetBoolData("Chapter18", true);

            if (game.GetBoolData("Wednesday_EN") && game.GetBoolData("Starless_EN") && game.GetBoolData("Eyeless_EN") && game.GetBoolData("Yin_EN") && game.GetBoolData("Yang_EN") && game.GetBoolData("PawnA_EN"))
                game.SetBoolData("Chapter19", true);

            if (game.GetBoolData("2009_EN") && game.GetBoolData("Chiito_EN") && game.GetBoolData("Solitaire_EN") && game.GetBoolData("Spades_EN") && game.GetBoolData("Foxtrot_EN"))
                game.SetBoolData("Chapter20", true);

            if (game.GetBoolData("Author_EN") && game.GetBoolData("Monster_EN") && game.GetBoolData("Wall_EN") && game.GetBoolData("Clown_EN") && game.GetBoolData("Waltz_EN") && game.GetBoolData("VoiceTrumpet_EN") && game.GetBoolData("Amalga_EN"))
                game.SetBoolData("Chapter21", true);

            if (game.GetBoolData("Smilers_BOSS") && game.GetBoolData("CrowChild_BOSS") && game.GetBoolData("BlackAndBlue_BOSS") && game.GetBoolData("Megalania_BOSS") && game.GetBoolData("Invention_BOSS") && game.GetBoolData("BlueSky_BOSS"))
                game.SetBoolData("ChapterBoss", true);
        }
    }
}
