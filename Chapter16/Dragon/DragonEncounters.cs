using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class DragonEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_DragonEncounter_Sign", ResourceLoader.LoadSprite("DragonWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Orph.H.Dragon.Hard, "Salt_DragonEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/DragonSong";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle")._roarReference.roarEvent;

            hard.AddRandomEncounter("TheDragon_EN", Bots.Red, Bots.Yellow);
            hard.AddRandomEncounter("TheDragon_EN", Spoggle.Red, Spoggle.Yellow);
            hard.AddRandomEncounter("TheDragon_EN", Bots.Red, Bots.Blue);
            hard.AddRandomEncounter("TheDragon_EN", "Something_EN", Jumble.Blue);
            hard.AddRandomEncounter("TheDragon_EN", "MusicMan_EN", Bots.Purple);
            hard.AddRandomEncounter("TheDragon_EN", "Freud_EN", Jumble.Purple);
            hard.AddRandomEncounter("TheDragon_EN", "TheCrow_EN", Spoggle.Red);
            hard.AddRandomEncounter("TheDragon_EN", "WindSong_EN", "Freud_EN");
            if (Winter.Chance) hard.AddRandomEncounter("TheDragon_EN", "Crystal_EN", "MusicMan_EN");
            hard.AddRandomEncounter("TheDragon_EN", "Maw_EN", Bots.Red);
            hard.SimpleAddEncounter(1, "TheDragon_EN", 3, "Enigma_EN");
            hard.AddRandomEncounter("TheDragon_EN", "Scrungie_EN", "WindSong_EN");
            hard.AddRandomEncounter("TheDragon_EN", "Scrungie_EN", Spoggle.Purple);
            hard.AddRandomEncounter("TheDragon_EN", "Scrungie_EN", Flower.Purple);
            hard.AddRandomEncounter("TheDragon_EN", Enemies.Solvent, "Maw_EN");
            if (Winter.Chance) hard.AddRandomEncounter("TheDragon_EN", Enemies.Solvent, "Crystal_EN");
            hard.AddRandomEncounter("TheDragon_EN", "Delusion_EN", Spoggle.Red);
            hard.AddRandomEncounter("TheDragon_EN", "Delusion_EN", "Freud_EN");
            hard.AddRandomEncounter("TheDragon_EN", "Something_EN", Flower.Yellow);
            hard.AddRandomEncounter("TheDragon_EN", "TheCrow_EN", "Enigma_EN");
            hard.AddRandomEncounter("TheDragon_EN", Enemies.Solvent, Flower.Purple);
            hard.AddRandomEncounter("TheDragon_EN", "Spectre_EN", "Spectre_EN");
            hard.AddRandomEncounter("TheDragon_EN", "MusicMan_EN", "MusicMan_EN");
            hard.AddRandomEncounter("TheDragon_EN", "Scrungie_EN", "Scrungie_EN");
            hard.AddRandomEncounter("TheDragon_EN", "StalwartTortoise_EN");


            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Dragon.Hard, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }

        public static void Post()
        {
            AddTo hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "TheDragon_EN", "TheDragon_EN");
        }
    }
}
