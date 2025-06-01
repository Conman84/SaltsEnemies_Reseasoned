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
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.Shooter.Med, 10, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Medium);
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
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Shooter.Med, 12, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
    }
}
