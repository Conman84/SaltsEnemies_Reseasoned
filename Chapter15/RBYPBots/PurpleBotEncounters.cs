using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PurpleBotEncounters
    {
        public static void Add()
        {
            Add_Normal();
            Add_Hardmode();
        }
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_PurpleBotEncounter_Sign", ResourceLoader.LoadSprite("PurpleBotWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.Bot.Purple.Med, "Salt_PurpleBotEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ApparatusSong";
            med.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "MusicMan_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "SingingStone_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "LostSheep_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "Enigma_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.Bot.Purple.Med, 4, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Medium);
        }
        public static void Add_Hardmode()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Bot.Purple.Med, "Salt_PurpleBotEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ApparatusSong";
            med.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "MusicMan_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "SingingStone_EN", "SingingStone_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "LostSheep_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "Enigma_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "Sigil_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, Enemies.Camera);
            med.SimpleAddEncounter(1, Bots.Blue, 1, Bots.Purple, 3, Enemies.Suckle);
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, Enemies.Solvent);
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "Delusion_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "Rabies_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, "Spectre_EN");
            med.AddRandomEncounter(Bots.Blue, Bots.Purple, Bots.Red);
            med.AddRandomEncounter(Bots.Blue, Bots.Yellow, Bots.Red);
            med.AddRandomEncounter(Bots.Blue, Bots.Purple);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Bot.Purple.Med, 5, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Bots.Purple, "MusicMan_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Bots.Purple, "Scrungie_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Bots.Purple, "Enigma_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Bots.Purple, "FakeAngel_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", Bots.Purple, "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", Bots.Purple, "MusicMan_EN", "MusicMan_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", Bots.Purple, Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Bots.Purple, "MusicMan_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Bots.Purple, Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", Bots.Purple, "MusicMan_EN");
        }
    }
}
