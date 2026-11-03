using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MelderEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_MelderEncounter_Sign", ResourceLoader.LoadSprite("MelderWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Melder.Med, "Salt_MelderEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/MelderTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/MelderRoar";

            med.AddRandomEncounter("Melder_EN", "Melder_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("Melder_EN", "Melder_EN", "Freud_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 1, "Scrungie_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 1, Spoggle.Red, 1, Spoggle.Yellow);
            med.AddRandomEncounter("Melder_EN", "Melder_EN", "LostSheep_EN", Jumble.Purple);
            med.SimpleAddEncounter(2, "Melder_EN", 2, "Enigma_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 1, "Rabies_EN");
            med.AddRandomEncounter("Melder_EN", "Melder_EN", Bots.Red);
            med.SimpleAddEncounter(2, "Melder_EN", 1, "Something_EN");
            if (SaltsReseasoned.rando < 22) med.SimpleAddEncounter(2, "Melder_EN", 2, "Spectre_EN");
            med.SimpleAddEncounter(3, "Melder_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 1, "TheWhale_EN", 1, "Nameless_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 1, "Delusion_EN", 1, "FakeAngel_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 3, "Foxtrot_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 3, "TortureMeNot_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 1, "MusicMan_EN", 2, Enemies.Suckle);
            med.SimpleAddEncounter(2, "Melder_EN", 1, "MusicMan_EN", 1, "SingingStone_EN");
            med.SimpleAddEncounter(2, "Melder_EN", 1, "Sigil_EN", 1, "Scrungie_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Melder.Med, 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(3, "MusicMan_EN", 1, "Melder_EN");
            med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 2, "SingingStone_EN");
            if (SaltsReseasoned.trolling < 33) med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Jumble.Purple);
            else if (SaltsReseasoned.trolling < 33) med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Spoggle.Purple);
            else med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Spoggle.Red);
            if (SaltsReseasoned.silly < 50) med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Flower.Purple);
            else med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Flower.Yellow);
            if (SaltsReseasoned.rando < 50)
            {
                med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Bots.Red);
                med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Bots.Yellow);
            }
            else
            {
                med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Bots.Blue);
                med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Bots.Purple);
            }
            med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "Scrungie_EN");
            if (SaltsReseasoned.trolling > 50) med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "Enigma_EN");
            else med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, Enemies.Camera);
            if (SaltsReseasoned.silly > 50) med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "Sigil_EN");
            else med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "WindSong_EN");
            if (SaltsReseasoned.rando > 50) med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "Nume_EN");
            else med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "TheWhale_EN");
            if (SaltsReseasoned.silly < 33) med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "Wednesday_EN");
            else if (SaltsReseasoned.silly < 33) med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "Solitaire_EN");
            else med.SimpleAddGroup(2, "MusicMan_EN", 1, "Melder_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            med.SimpleAddGroup(3, "Scrungie_EN", 1, "Melder_EN");
            med.SimpleAddGroup(2, "Scrungie_EN", 1, "Melder_EN", 1, "Wednesday_EN");
            med.SimpleAddGroup(2, "Scrungie_EN", 1, "Melder_EN", 1, Enemies.Shooter);

            AddTo hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Melder_EN", "Melder_EN");
            hard.AddRandomGroup("Revola_EN", "Melder_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, "Melder_EN", Jumble.Red, Jumble.Yellow);
            med.AddRandomGroup(Jumble.Purple, "Melder_EN", "MusicMan_EN", Enemies.Suckle, Enemies.Suckle);
            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, "Melder_EN", Jumble.Red, Jumble.Yellow);
            med.AddRandomGroup(Jumble.Blue, "Melder_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Melder_EN");
            med.AddRandomGroup(Spoggle.Red, "Melder_EN", "WindSong_EN");
            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Melder_EN");
            med.AddRandomGroup(Spoggle.Purple, "Melder_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, "Melder_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "Melder_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Sigil_EN", "Melder_EN", "Melder_EN", "Something_EN");

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Melder_EN");
            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Melder_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Red, Bots.Blue, "Melder_EN");
            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Red, Bots.Purple, "Melder_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.SimpleAddGroup(1, "Evileye_EN", 2, "Melder_EN");
            med.AddRandomGroup("Evileye_EN", "Melder_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Evileye_EN", "Melder_EN", "Solitaire_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Shooter.Med);
            med.SimpleAddGroup(2, Enemies.Shooter, 1, "Melder_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Melder_EN", Enemies.Suckle, Enemies.Suckle);

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "Melder_EN", "Melder_EN");
            hard.AddRandomGroup("Conductor_EN", "Melder_EN", Spoggle.Purple);
            hard.AddRandomGroup("Conductor_EN", "Melder_EN", Bots.Yellow);
            hard.AddRandomGroup("Conductor_EN", "Melder_EN", Flower.Purple);
            hard.AddRandomGroup("Conductor_EN", "Melder_EN", Jumble.Purple);

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.SimpleAddGroup(1, "Sacrifice_EN", 3, "Melder_EN");
            hard.SimpleAddGroup(1, "Sacrifice_EN", 1, "Melder_EN", 2, "MusicMan_EN");
            hard.SimpleAddGroup(1, "Sacrifice_EN", 1, "Melder_EN", 2, "TheWhale_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Melder_EN", "Enigma_EN");
            med.AddRandomGroup("Something_EN", "Melder_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup("Something_EN", "Melder_EN", Jumble.Purple);
            med.AddRandomGroup("Something_EN", "Melder_EN", Flower.Yellow);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Melder_EN", Jumble.Blue);
            med.AddRandomGroup("Freud_EN", "Melder_EN", Bots.Purple);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Melder_EN", Spoggle.Red);
            med.AddRandomGroup("TheCrow_EN", "Melder_EN", Bots.Red);

            med = new AddTo(Orph.H.Camera.Med);
            med.SimpleAddGroup(2, Enemies.Camera, 1, "Melder_EN", 1, "LostSheep_EN");
            med.SimpleAddGroup(2, Enemies.Camera, 1, "Melder_EN", 1, Enemies.Solvent);

            med = new AddTo(Orph.H.Delusion.Med);
            med.SimpleAddGroup(2, "Delusion_EN", 1, "FakeAngel_EN", 1, "Melder_EN");
            med.SimpleAddGroup(2, "Delusion_EN", 1, Enemies.Solvent, 1, "Melder_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, "Melder_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup(Flower.Yellow, "Melder_EN", "TheWhale_EN", "TheWhale_EN");
            med.AddRandomGroup(Flower.Yellow, "Melder_EN", "Something_EN");
            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, "Melder_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup(Flower.Purple, "Melder_EN", "TheWhale_EN", "TheWhale_EN");
            med.AddRandomGroup(Flower.Purple, "Melder_EN", "Something_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Melder_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("WindSong_EN", "Melder_EN", "TheWhale_EN", "TheWhale_EN");
            med.AddRandomGroup("WindSong_EN", "Melder_EN", "Scrungie_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Nameless.Med);
            med.SimpleAddGroup(2, "Nameless_EN", 1, "Melder_EN", 1, "TheWhale_EN");
            med.SimpleAddGroup(2, "Nameless_EN", 1, "Melder_EN", 1, "MusicMan_EN");
            med.SimpleAddGroup(2, "Nameless_EN", 1, "Melder_EN", 1, Spoggle.Red);
            med.SimpleAddGroup(2, "Nameless_EN", 1, "Melder_EN", 1, "Something_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Melder_EN", "Scrungie_EN");
            med.AddRandomGroup("Crystal_EN", "Melder_EN", "Something_EN");
            med.AddRandomGroup("Crystal_EN", "Melder_EN", "Evileye_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Melder_EN", "TheWhale_EN");
            hard.AddRandomGroup("TheDragon_EN", "Melder_EN", "Nume_EN");
            hard.AddRandomGroup("TheDragon_EN", "Melder_EN", Spoggle.Red);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Melder_EN", "Scrungie_EN");
            med.AddRandomGroup("YellowAngel_EN", "Melder_EN", "Something_EN");
            med.AddRandomGroup("YellowAngel_EN", "Melder_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("YellowAngel_EN", "Melder_EN", "Solitaire_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", "Melder_EN");
            med.AddRandomGroup("Wednesday_EN", "TheWhale_EN", "TheWhale_EN", "Melder_EN");
            med.AddRandomGroup("Wednesday_EN", "Scrungie_EN", "Scrungie_EN", "Melder_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Melder_EN", "LostSheep_EN");
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Melder_EN", "Scrungie_EN");
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Melder_EN", Bots.Red);

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", "Melder_EN", "Spectre_EN");
            med.AddRandomGroup("Author_EN", "Author_EN", "Melder_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", "Melder_EN", "Scrungie_EN");
            med.AddRandomGroup("Nume_EN", "Melder_EN", "Something_EN");
            med.AddRandomGroup("Nume_EN", "Melder_EN", Bots.Red);

            med = new AddTo(Orph.H.Whale.Med);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, "Melder_EN", 1, Spoggle.Red);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, "Melder_EN", 1, Jumble.Purple);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, "Melder_EN", 1, Flower.Yellow);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, "Melder_EN", 1, Bots.Blue);

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", "Melder_EN", "Melder_EN");
            med.AddRandomGroup("ILoveYou_EN", "Melder_EN", "Solitaire_EN", "Solitaire_EN");

            hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", "Melder_EN", "Melder_EN");
            hard.AddRandomGroup("ILoveYou_EN", "Melder_EN", "Melder_EN", "Melder_EN");
            hard.AddRandomGroup("ILoveYou_EN", "Melder_EN", "Melder_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Melder_EN", Jumble.Purple);
            med.AddRandomGroup("Maw_EN", "Melder_EN", Flower.Yellow);

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Melder_EN", "Melder_EN");
            hard.SimpleAddGroup(1, "Maw_EN", 1, "Melder_EN", 2, "MusicMan_EN");
            hard.SimpleAddGroup(1, "Maw_EN", 1, "Melder_EN", 2, "Solitaire_EN");
            hard.SimpleAddGroup(1, "Maw_EN", 1, "Melder_EN", 2, "TheWhale_EN");
        }
    }
}
