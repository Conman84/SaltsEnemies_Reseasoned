using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class RedBotEncounters
    {
        public static void Add()
        {
            Add_Normal();
            Add_Hardnode();
        }
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_RedBotEncounter_Sign", ResourceLoader.LoadSprite("RedBotWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.Bot.Red.Med, "Salt_RedBotEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ApparatusSong";
            med.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "MusicMan_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "SingingStone_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "LostSheep_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "Enigma_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "Sigil_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.Bot.Red.Med, 6, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Medium);
        }
        public static void Add_Hardnode()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Bot.Red.Med, "Salt_RedBotEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ApparatusSong";
            med.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "MusicMan_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "SingingStone_EN", "SingingStone_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "LostSheep_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "Enigma_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "Sigil_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, Enemies.Camera);
            med.SimpleAddEncounter(1, Bots.Red, 1, Bots.Yellow, 3, Enemies.Suckle);
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, Enemies.Solvent);
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "Delusion_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "Rabies_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "Butterfly_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, "WindSong_EN");
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, Bots.Blue);
            med.AddRandomEncounter(Bots.Red, Bots.Yellow, Bots.Purple);
            med.AddRandomEncounter(Bots.Red, Bots.Blue, Bots.Purple);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Bot.Red.Med, 5, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Something_EN", Bots.Red, "MusicMan_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("TheCrow_EN", Bots.Red, "Scrungie_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Freud_EN", Bots.Red, "Enigma_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", Bots.Red, Bots.Yellow);
            med.SimpleAddGroup(3, "Delusion_EN", 1, Bots.Red);

            med = new AddTo(Orph.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", Bots.Red, "MusicMan_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Sigil_EN", Bots.Red, "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("WindSong_EN", Bots.Red, "Delusion_EN", "Delusion_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", Bots.Red, Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Maw_EN", Bots.Red, "MusicMan_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Bots.Red, Bots.Yellow, Bots.Blue);
            hard.AddRandomGroup("Maw_EN", Bots.Red, Bots.Yellow, Bots.Purple);
            hard.AddRandomGroup("Maw_EN", Bots.Red, "Delusion_EN", "Delusion_EN");

            med = new AddTo(Orph.MusicMan.Med);
            med.AddRandomGroup("MusicMan_EN", "MusicMan_EN", Bots.Red);

            med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(3, "MusicMan_EN", 1, Bots.Red);

            hard = new AddTo(Orph.Scrungie.Hard);
            hard.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Bots.Red, Bots.Yellow);

            med = new AddTo(Orph.H.Scrungie.Med);
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Bots.Red, Bots.Yellow);

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, Bots.Red, Bots.Yellow, Bots.Blue, Bots.Purple);

            hard = new AddTo(Orph.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Bots.Red);

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Bots.Red, Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Conductor_EN", Bots.Red, "MusicMan_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", Bots.Red, Bots.Blue);
            hard.AddRandomGroup("Conductor_EN", Bots.Red, Bots.Purple);
        }
    }
}
