using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ILoveYouEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_LullabyEncounter_Sign", ResourceLoader.LoadSprite("LullabyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.ILoveYou.Med, "Salt_LullabyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ILoveYouTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/LullabyRoar";

            med.AddRandomEncounter("ILoveYou_EN", "MusicMan_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Scrungie_EN", "Scrungie_EN");
            med.AddRandomEncounter("ILoveYou_EN", Jumble.Purple, Jumble.Red);
            med.AddRandomEncounter("ILoveYou_EN", Jumble.Blue, Jumble.Red);
            med.AddRandomEncounter("ILoveYou_EN", Spoggle.Red, Spoggle.Blue);
            med.AddRandomEncounter("ILoveYou_EN", Spoggle.Red, Spoggle.Yellow);
            med.SimpleAddEncounter(1, "ILoveYou_EN", 3, "Enigma_EN");
            med.AddRandomEncounter("ILoveYou_EN", "MusicMan_EN", "MusicMan_EN", "Sigil_EN");
            med.AddRandomEncounter("ILoveYou_EN", Spoggle.Blue, Spoggle.Yellow, "LostSheep_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Rabies_EN", "LostSheep_EN");
            med.AddRandomEncounter("ILoveYou_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomEncounter("ILoveYou_EN", Bots.Red, Bots.Yellow);
            med.AddRandomEncounter("ILoveYou_EN", Bots.Red, Bots.Blue);
            med.AddRandomEncounter("ILoveYou_EN", Bots.Red, Bots.Purple);
            med.AddRandomEncounter("ILoveYou_EN", "Something_EN", "Enigma_EN");
            med.AddRandomEncounter("ILoveYou_EN", "TheCrow_EN", Bots.Red);
            med.AddRandomEncounter("ILoveYou_EN", Flower.Purple, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("ILoveYou_EN", Flower.Yellow, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Delusion_EN", "Delusion_EN", "FakeAngel_EN");
            med.AddRandomEncounter("ILoveYou_EN", Enemies.Camera, Enemies.Camera);
            med.AddRandomEncounter("ILoveYou_EN", Enemies.Solvent, Jumble.Blue);
            med.AddRandomEncounter("ILoveYou_EN", "WindSong_EN", "Something_EN");
            if (SaltsReseasoned.rando <= 50) med.SimpleAddEncounter(1, "ILoveYou_EN", 3, "Spectre_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Nameless_EN", "Rabies_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Crystal_EN", "Scrungie_EN");
            med.SimpleAddEncounter(1, "ILoveYou_EN", 4, "TortureMeNot_EN");
            //med.AddRandomEncounter("ILoveYou_EN", "YellowAngel_EN", "SingingStone_EN", "SingingStone_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Wednesday_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Foxtrot_EN", "Foxtrot_EN", "WindSong_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Author_EN", "Author_EN", "LostSheep_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Insider_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Nume_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomEncounter("ILoveYou_EN", "TheWhale_EN", "TheWhale_EN", "SingingStone_EN");
            med.AddRandomEncounter("ILoveYou_EN", "Evileye_EN", "Enigma_EN", "Enigma_EN");
            med.SimpleAddEncounter(2, "ILoveYou_EN", 3, Enemies.Suckle);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.ILoveYou.Med, 15 * April.Mod, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Orph.H.ILoveYou.Hard, "Salt_LullabyEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/ILoveYouTheme";
            hard.RoarEvent = "event:/Hawthorne/Snound1/LullabyRoar";

            hard.AddRandomEncounter("ILoveYou_EN", "ILoveYou_EN", Spoggle.Red, Spoggle.Purple);
            hard.SimpleAddEncounter(1, "ILoveYou_EN", 3, "Scrungie_EN");
            hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, Jumble.Blue, 1, Jumble.Purple);
            hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, Flower.Yellow, 1, Flower.Purple);
            if (SaltsReseasoned.trolling <= 33) hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, Bots.Blue, 1, Bots.Purple);
            else if (SaltsReseasoned.trolling <= 67) hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, Bots.Blue, 1, Bots.Yellow);
            else hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, Bots.Yellow, 1, Bots.Purple);
            hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, "Evileye_EN");
            hard.SimpleAddEncounter(3, "ILoveYou_EN", 2, Enemies.Suckle);
            hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, "Freud_EN", 1, "TheCrow_EN");
            hard.SimpleAddEncounter(1, "ILoveYou_EN", 3, Enemies.Camera);
            hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, "WindSong_EN");
            //hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, "YellowAngel_EN");
            hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, "Crystal_EN", 1, "CandyStone_EN");
            hard.SimpleAddEncounter(1, "ILoveYou_EN", 3, "Solitaire_EN");
            hard.SimpleAddEncounter(1, "ILoveYou_EN", 3, "Author_EN");
            hard.SimpleAddEncounter(1, "ILoveYou_EN", 3, "TheWhale_EN");
            hard.SimpleAddEncounter(2, "ILoveYou_EN", 1, "Nume_EN", 1, "LostSheep_EN");
            hard.SimpleAddEncounter(2, "ILoveYou_EN", 2, "Insider_EN");
            hard.SimpleAddEncounter(1, "ILoveYou_EN", 3, "ManicMan_EN");


            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.ILoveYou.Hard, 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "ILoveYou_EN", Enemies.Suckle, Enemies.Suckle);

            AddTo hard = new AddTo(Orph.H.Conductor.Hard);
            hard.SimpleAddGroup(1, "Conductor_EN", 2, "ILoveYou_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "ILoveYou_EN", Enemies.Suckle, Enemies.Suckle);

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.SimpleAddGroup(2, Enemies.Sacrifice, 1, "ILoveYou_EN", 2, Enemies.Suckle);

            hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "ILoveYou_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "ILoveYou_EN", Spoggle.Blue);
            med.AddRandomGroup("Maw_EN", "ILoveYou_EN", Spoggle.Yellow);

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "ILoveYou_EN", "ILoveYou_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "ILoveYou_EN", "LostSheep_EN");
            hard.AddRandomGroup("TheDragon_EN", "ILoveYou_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("ILoveYou_EN", "YellowAngel_EN", "SingingStone_EN", "SingingStone_EN");
            med.AddRandomGroup("YellowAngel_EN", "ILoveYou_EN", Enemies.Camera);
        }
    }
}
