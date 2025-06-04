using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SkeletonShooterEncounters
    {
        public static void Add()
        {
            Add_Normal_Easy();
            Add_Normal_Med();
            Add_Hardmode_Easy();
            Add_Hardmode_Med();
        }
        public static void Add_Normal_Easy()
        {
            Portals.AddPortalSign("Salt_SkeletonShooterEncounter_Sign", ResourceLoader.LoadSprite("ShooterWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Orph.Shooter.Easy, "Salt_SkeletonShooterEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/ShooterSong";
            easy.RoarEvent = "event:/Hawthorne/Noisy/Bone_Roar";

            easy.SimpleAddEncounter(2, "SkeletonShooter_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", "MusicMan_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", "Enigma_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "LostSheep_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", Jumble.Yellow);
            easy.AddRandomEncounter("SkeletonShooter_EN", Jumble.Red);

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.Shooter.Easy, 3, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Easy);
        }
        public static void Add_Hardmode_Easy()
        {
            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Orph.H.Shooter.Easy, "Salt_SkeletonShooterEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/ShooterSong";
            easy.RoarEvent = "event:/Hawthorne/Noisy/Bone_Roar";

            easy.SimpleAddEncounter(2, "SkeletonShooter_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "MusicMan_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "Enigma_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "LostSheep_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Jumble.Yellow);
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Jumble.Red);
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "Delusion_EN");
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Enemies.Solvent);
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Bots.Red);
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Bots.Yellow);
            easy.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "TortureMeNot_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Shooter.Easy, 5, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Normal_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.Shooter.Med, "Salt_SkeletonShooterEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ShooterSong";
            med.RoarEvent = "event:/Hawthorne/Noisy/Bone_Roar";

            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "MusicMan_EN");
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Jumble.Blue);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Jumble.Purple);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Spoggle.Red);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Spoggle.Purple);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "Sigil_EN");
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "Rabies_EN");
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Bots.Red);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Bots.Yellow);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.Shooter.Med, 12, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Medium);
        }
        public static void Add_Hardmode_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Shooter.Med, "Salt_SkeletonShooterEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ShooterSong";
            med.RoarEvent = "event:/Hawthorne/Noisy/Bone_Roar";

            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "SkeletonShooter_EN");
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Jumble.Blue);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Jumble.Purple);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Spoggle.Red);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Spoggle.Purple);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "Sigil_EN");
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "Rabies_EN");
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Bots.Blue);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Bots.Purple);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", "WindSong_EN");
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Enemies.Camera);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Flower.Yellow);
            med.AddRandomEncounter("SkeletonShooter_EN", "SkeletonShooter_EN", Flower.Purple);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Shooter.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, "SkeletonShooter_EN");

            AddTo easy = new AddTo(Orph.H.Something.Easy);
            easy.AddRandomGroup("Something_EN", "SkeletonShooter_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", "MusicMan_EN");
            med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", "Scrungie_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Bots.Yellow);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Bots.Red);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Jumble.Blue);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Jumble.Purple);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Spoggle.Red);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Spoggle.Purple);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Flower.Yellow);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Flower.Purple);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Bots.Blue);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Something_EN", "SkeletonShooter_EN", Bots.Purple);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "SkeletonShooter_EN", "SkeletonShooter_EN");
            med.AddRandomGroup("TheCrow_EN", Enemies.Shooter, "Scrungie_EN");
            med.AddRandomGroup("TheCrow_EN", Enemies.Shooter, "MusicMan_EN");
            med.AddRandomGroup("TheCrow_EN", Enemies.Shooter, Bots.Yellow);
            med.AddRandomGroup("TheCrow_EN", Enemies.Shooter, Flower.Yellow);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomGroup("Freud_EN", Enemies.Shooter, "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Freud_EN", Enemies.Shooter, Enemies.Camera);
            med.AddRandomGroup("Freud_EN", Enemies.Shooter, Spoggle.Red);
            med.AddRandomGroup("Freud_EN", Enemies.Shooter, Jumble.Blue);

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Shooter, "LostSheep_EN");
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Shooter, "Enigma_EN");
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Shooter, "MusicMan_EN");

            easy = new AddTo(Orph.H.Delusion.Med);
            easy.AddRandomGroup("Delusion_EN", Enemies.Shooter, "FakeAngel_EN");
            easy.AddRandomGroup("Delusion_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Enemies.Shooter, "FakeAngel_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Enemies.Shooter);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Delusion_EN", Enemies.Shooter);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Enemies.Shooter, Enemies.Solvent);

            easy = new AddTo(Orph.H.Flower.Yellow.Easy);
            easy.AddRandomGroup(Flower.Yellow, Enemies.Shooter, "SingingStone_EN");
            easy.AddRandomGroup(Flower.Yellow, Enemies.Shooter, "MusicMan_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, Enemies.Shooter);
            med.AddRandomGroup(Flower.Yellow, Enemies.Shooter, "Scrungie_EN");
            med.AddRandomGroup(Flower.Yellow, Enemies.Shooter, "Rabies_EN");
            med.AddRandomGroup(Flower.Yellow, Enemies.Shooter, "WindSong_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, Flower.Yellow, Enemies.Shooter);
            med.AddRandomGroup(Flower.Purple, Enemies.Shooter, "Scrungie_EN");
            med.AddRandomGroup(Flower.Purple, Enemies.Shooter, "Rabies_EN");
            med.AddRandomGroup(Flower.Purple, Enemies.Shooter, "WindSong_EN");

            med = new AddTo(Orph.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, "MusicMan_EN");
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, "Enigma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, "Scrungie_EN");
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, "Something_EN");
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, Spoggle.Red);
            med.AddRandomGroup("Sigil_EN", Enemies.Shooter, Bots.Yellow);

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", Enemies.Shooter, "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("WindSong_EN", Enemies.Shooter, "Scrungie_EN");
            med.AddRandomGroup("WindSong_EN", Enemies.Shooter, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("WindSong_EN", Enemies.Shooter, Bots.Red, Bots.Yellow);
            med.AddRandomGroup("WindSong_EN", Enemies.Shooter, "Something_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", Enemies.Shooter);
            hard.AddRandomGroup("StalwartTortoise_EN", Enemies.Shooter, "LostSheep_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", Enemies.Shooter, "Nameless_EN");

            med = new AddTo(Orph.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", Enemies.Shooter);
            med.AddRandomGroup("Rabies_EN", Enemies.Shooter, "Enigma_EN");
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", Enemies.Shooter, "LostSheep_EN");
            med.AddRandomGroup("Rabies_EN", Enemies.Shooter, "Spectre_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Enemies.Shooter, Enemies.Shooter);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Maw_EN", Enemies.Shooter, Bots.Red);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Maw_EN", Enemies.Shooter, Bots.Yellow);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Maw_EN", Enemies.Shooter, Jumble.Blue);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Maw_EN", Enemies.Shooter, Jumble.Purple);
            med.AddRandomGroup("Maw_EN", Enemies.Shooter, "Scrungie_EN");
            med.AddRandomGroup("Maw_EN", Enemies.Shooter, "Something_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Enemies.Shooter, Spoggle.Red, Spoggle.Purple);
            hard.AddRandomGroup("Maw_EN", Enemies.Shooter, Flower.Yellow, Flower.Purple);
            hard.AddRandomGroup("Maw_EN", Enemies.Shooter, "Rabies_EN", "LostSheep_EN");
            if (Winter.Chance) hard.AddRandomGroup("Maw_EN", Enemies.Shooter, "Crystal_EN");
            hard.AddRandomGroup("Maw_EN", Enemies.Shooter, "Evileye_EN");
            hard.AddRandomGroup("Maw_EN", Enemies.Shooter, "YellowAngel_EN");
            hard.AddRandomGroup("Maw_EN", Enemies.Shooter, "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, Enemies.Shooter);
            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, Enemies.Shooter);

            med = new AddTo(Orph.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, Enemies.Shooter);
            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, Enemies.Shooter);

            med = new AddTo(Orph.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, Enemies.Shooter);
            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, Enemies.Shooter);

            med = new AddTo(Orph.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, Enemies.Shooter);
            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, Enemies.Shooter);

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomGroup("Crystal_EN", Enemies.Shooter, "Scrungie_EN");
            med.AddRandomGroup("Crystal_EN", Enemies.Shooter, Spoggle.Red);
            med.AddRandomGroup("Crystal_EN", Enemies.Shooter, "Enigma_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", Enemies.Shooter, "Scrungie_EN");
            hard.AddRandomGroup("TheDragon_EN", Enemies.Shooter, "Enigma_EN");
            hard.AddRandomGroup("TheDragon_EN", Enemies.Shooter, Bots.Blue);

            hard = new AddTo(Orph.Evileye.Hard);
            hard.AddRandomGroup("Evileye_EN", Enemies.Shooter, Enemies.Shooter);
            hard.AddRandomGroup("Evileye_EN", Enemies.Shooter, Jumble.Blue);
            hard.AddRandomGroup("Evileye_EN", Enemies.Shooter, "Enigma_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomGroup("Evileye_EN", Enemies.Shooter, Jumble.Blue);
            med.AddRandomGroup("Evileye_EN", Enemies.Shooter, "Enigma_EN");
            med.AddRandomGroup("Evileye_EN", Enemies.Shooter, Enemies.Camera);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Shooter, "WindSong_EN");
            med.AddRandomGroup("YellowAngel_EN", Enemies.Shooter, "Scrungie_EN");
            med.AddRandomGroup("YellowAngel_EN", Enemies.Shooter, Spoggle.Red);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Shooter, Bots.Yellow);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Shooter, "Evileye_EN");
           if (Winter.Chance) med.AddRandomGroup("YellowAngel_EN", Enemies.Shooter, "Crystal_EN");

            easy = new AddTo(Orph.MusicMan.Easy);
            easy.AddRandomGroup("MusicMan_EN", Enemies.Shooter);
            easy = new AddTo(Orph.H.MusicMan.Easy);
            easy.AddRandomGroup("MusicMan_EN", "MusicMan_EN", Enemies.Shooter);

            med = new AddTo(Orph.MusicMan.Med);
            med.AddRandomGroup("MusicMan_EN", "MusicMan_EN", Enemies.Shooter);
            med.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Shooter);
            med = new AddTo(Orph.H.MusicMan.Med);
            med.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Shooter);
            med.AddRandomGroup("MusicMan_EN", "MusicMan_EN", Enemies.Shooter, Bots.Red);
            med.AddRandomGroup("MusicMan_EN", "MusicMan_EN", Enemies.Shooter, Bots.Yellow);

            hard = new AddTo(Orph.Scrungie.Hard);
            hard.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Enemies.Shooter, "SingingStone_EN");
            hard.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Enemies.Shooter, "Scrungie_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            hard.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Enemies.Shooter, "Scrungie_EN");
            hard.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Enemies.Shooter, Enemies.Solvent);
            hard.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Enemies.Shooter, Jumble.Blue);

            med = new AddTo(Orph.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Purple, Enemies.Shooter);
            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Purple, Enemies.Shooter);
            med.AddRandomGroup(Jumble.Blue, Enemies.Shooter, "Scrungie_EN");

            med = new AddTo(Orph.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Purple, Enemies.Shooter);
            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Purple, Enemies.Shooter);
            med.AddRandomGroup(Jumble.Purple, Enemies.Shooter, "Rabies_EN");

            med = new AddTo(Orph.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, Enemies.Shooter);
            med.AddRandomGroup(Spoggle.Red, Enemies.Shooter, Enemies.Shooter);
            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, Enemies.Shooter);
            med.AddRandomGroup(Spoggle.Red, Enemies.Shooter, Enemies.Shooter);

            med = new AddTo(Orph.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, Enemies.Shooter);
            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, Enemies.Shooter);
            med.AddRandomGroup(Spoggle.Purple, Enemies.Shooter, "Something_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, Enemies.Shooter, Enemies.Shooter);
            hard.AddRandomGroup(Enemies.Sacrifice, Enemies.Shooter, "YellowAngel_EN");

            hard = new AddTo(Orph.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Enemies.Shooter);
            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Enemies.Shooter, "LostSheep_EN");
            hard.AddRandomGroup("Revola_EN", Enemies.Shooter, Jumble.Purple);
            hard.AddRandomGroup("Revola_EN", Enemies.Shooter, Flower.Yellow);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomGroup("Conductor_EN", Enemies.Shooter, "LostSheep_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", Enemies.Shooter, "MusicMan_EN", "MusicMan_EN");
            hard.AddRandomGroup("Conductor_EN", Enemies.Shooter, "Scrungie_EN");
            hard.AddRandomGroup("Conductor_EN", Enemies.Shooter, Jumble.Blue);
            hard.AddRandomGroup("Conductor_EN", Enemies.Shooter, Bots.Purple);
            hard.AddRandomGroup("Conductor_EN", Enemies.Shooter, "Freud_EN");
            hard.AddRandomGroup("Conductor_EN", Enemies.Shooter, "TheCrow_EN");
            hard.AddRandomGroup("Conductor_EN", Enemies.Shooter, Enemies.Camera, Enemies.Camera);
        }
    }
}
