using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WednesdayEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WednesdayEncounter_Sign", ResourceLoader.LoadSprite("PhoneWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Wednesday.Med, "Salt_WednesdayEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PhoneSong";
            med.RoarEvent = "event:/Hawthorne/Noise/TrainRoar";

            med.SimpleAddEncounter(1, "Wednesday_EN", 3, "MusicMan_EN");
            med.AddRandomEncounter("Wednesday_EN", "Scrungie_EN", "Scrungie_EN", Enemies.Suckle, Enemies.Suckle);
            med.AddRandomEncounter("Wednesday_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomEncounter("Wednesday_EN", Bots.Yellow, Bots.Red);
            med.AddRandomEncounter("Wednesday_EN", "Something_EN", Jumble.Blue);
            med.AddRandomEncounter("Wednesday_EN", "Rabies_EN", "Rabies_EN", "LostSheep_EN");
            med.SimpleAddEncounter(1, "Wednesday_EN", 3, "Enigma_EN");
            med.AddRandomEncounter("Wednesday_EN", "Delusion_EN", "Delusion_EN", "FakeAngel_EN");
            med.AddRandomEncounter("Wednesday_EN", "Delusion_EN", "Delusion_EN", Enemies.Solvent);
            med.AddRandomEncounter("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Shooter);
            med.AddRandomEncounter("Wednesday_EN", "Delusion_EN", "Delusion_EN", "Enigma_EN");
            med.AddRandomEncounter("Wednesday_EN", Spoggle.Red, Enemies.Shooter);
            med.AddRandomEncounter("Wednesday_EN", Jumble.Purple, "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter("Wednesday_EN", "Something_EN", Flower.Yellow);
            med.AddRandomEncounter("Wednesday_EN", "TheCrow_EN", Bots.Red);
            med.AddRandomEncounter("Wednesday_EN", "WindSong_EN", "MusicMan_EN", "MusicMan_EN");
            med.SimpleAddEncounter(1, "Wednesday_EN", 3, "Spectre_EN");
            med.AddRandomEncounter("Wednesday_EN", Enemies.Camera, "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Camera);
            med.AddRandomEncounter("Wednesday_EN", "Scrungie_EN", Enemies.Shooter);
            med.AddRandomEncounter("Wednesday_EN", "Scrungie_EN", Bots.Blue, "TortureMeNot_EN");
            med.AddRandomEncounter("Wednesday_EN", "Sigil_EN", "MusicMan_EN", "MusicMan_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Wednesday.Med, 8, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, "Wednesday_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Something_EN", "Wednesday_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Wednesday_EN", Spoggle.Red, Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Wednesday_EN", "Scrungie_EN", "Scrungie_EN");
            med.AddRandomGroup("Freud_EN", "Wednesday_EN", "Rabies_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, "Wednesday_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "FakeAngel_EN", "Wednesday_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, "Wednesday_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Wednesday_EN", "Rabies_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Wednesday_EN", Bots.Yellow);

            AddTo hard = new AddTo(Orph.H.Maw.Hard);
            if (Winter.Chance) hard.AddRandomGroup("Maw_EN", "Wednesday_EN", "Crystal_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, "Wednesday_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Wednesday_EN", "Freud_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Wednesday_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Wednesday_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Wednesday_EN", "Something_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "Wednesday_EN", "Scrungie_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Wednesday_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Wednesday_EN", Enemies.Suckle, Enemies.Suckle, Enemies.Suckle);

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "Wednesday_EN", "YellowAngel_EN");
        }
    }
}
