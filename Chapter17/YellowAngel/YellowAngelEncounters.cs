using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class YellowAngelEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_YellowAngelEncounter_Sign", ResourceLoader.LoadSprite("HarpoonPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.YellowAngel.Med, "Salt_YellowAngelEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/YellowAngelTheme";
            med.RoarEvent = "event:/Hawthorne/Noisy/YA_Roar";

            med.SimpleAddEncounter(1, "YellowAngel_EN", 3, "Enigma_EN");
            med.AddRandomEncounter("YellowAngel_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("YellowAngel_EN", "Scrungie_EN", "Scrungie_EN");
            med.AddRandomEncounter("YellowAngel_EN", "Something_EN", Jumble.Blue);
            med.AddRandomEncounter("YellowAngel_EN", "Freud_EN", Spoggle.Purple);
            med.AddRandomEncounter("YellowAngel_EN", Bots.Red, Bots.Yellow);
            med.AddRandomEncounter("YellowAngel_EN", Spoggle.Red, "TheCrow_EN");
            med.AddRandomEncounter("YellowAngel_EN", Enemies.Solvent, Flower.Yellow);
            med.AddRandomEncounter("YellowAngel_EN", "WindSong_EN", "SingingStone_EN", "SingingStone_EN", "SingingStone_EN");
            med.AddRandomEncounter("YellowAngel_EN", "Evileye_EN", "Sigil_EN");
            med.AddRandomEncounter("YellowAngel_EN", "ManicMan_EN", "ManicMan_EN");
            if (Winter.Chance) med.AddRandomEncounter("YellowAngel_EN", "Crystal_EN", "LostSheep_EN");
            med.SimpleAddEncounter(1, "YellowAngel_EN", 4, "TortureMeNot_EN");
            med.AddRandomEncounter("YellowAngel_EN", Enemies.Camera, Enemies.Camera, Spoggle.Red);
            med.AddRandomEncounter("YellowAngel_EN", "MusicMan_EN", Flower.Purple);
            med.AddRandomEncounter("YellowAngel_EN", "Scrungie_EN", Bots.Blue);
            med.AddRandomEncounter("YellowAngel_EN", "Delusion_EN", "Delusion_EN", "LostSheep_EN");
            med.AddRandomEncounter("YellowAngel_EN", "Enigma_EN", Jumble.Purple, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomEncounter("YellowAngel_EN", "Something_EN", Bots.Purple);
            med.AddRandomEncounter("YellowAngel_EN", "Evileye_EN", Enemies.Suckle, Enemies.Suckle);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.YellowAngel.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "YellowAngel_EN", Enemies.Suckle);
            med.AddRandomGroup("Maw_EN", "YellowAngel_EN", "TortureMeNot_EN");

            AddTo hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "YellowAngel_EN", "WindSong_EN");
            hard.AddRandomGroup("Maw_EN", "YellowAngel_EN", "Evileye_EN");
            if (Winter.Chance) hard.AddRandomGroup("Maw_EN", "YellowAngel_EN", "Crystal_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "YellowAngel_EN", Bots.Blue);

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "YellowAngel_EN", "Enigma_EN", "Enigma_EN");
            hard.AddRandomGroup(Enemies.Sacrifice, "YellowAngel_EN", "YellowAngel_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "YellowAngel_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "YellowAngel_EN", "SingingStone_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "YellowAngel_EN", "WindSong_EN");
        }
    }
}
