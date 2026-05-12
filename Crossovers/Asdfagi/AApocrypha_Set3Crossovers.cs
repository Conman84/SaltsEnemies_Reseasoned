using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AApocrypha_Set3Crossovers
    {
        public static void Add()
        {
            Aggregates_Shore();
        }
        public static void Aggregates_Shore()
        {
            AddTo easy = new AddTo(Shore.H.Aggregates.Red.Easy);
            easy.AddRandomGroup(Aggregates.Red, "Minana_EN", "Minana_EN");

            easy = new AddTo(Shore.H.Aggregates.Purple.Easy);
            easy.AddRandomGroup(Aggregates.Purple, "Wall_EN");

            AddTo med = new AddTo(Shore.H.Aggregates.Red.Med);
            med.AddRandomGroup(Aggregates.Red, "Waltz_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Aggregates.Red, "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup(Aggregates.Red, "ToyUfo_EN", "LostSheep_EN");
            med.AddRandomGroup(Aggregates.Red, "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup(Aggregates.Red, "Papereater_EN", Enemies.Mungling);
            med.AddRandomGroup(Aggregates.Red, "Jabberwocky_EN", "NobodyGrave_EN");
            med.AddRandomGroup(Aggregates.Red, "MudLung_EN", "2009_EN");

            med = new AddTo(Shore.H.Aggregates.Purple.Med);
            med.AddRandomGroup(Aggregates.Purple, "VoiceTrumpet_EN", "MudLung_EN");
            med.AddRandomGroup(Aggregates.Purple, "Waltz_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Aggregates.Purple, "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup(Aggregates.Purple, "ToyUfo_EN", "LostSheep_EN");
            med.AddRandomGroup(Aggregates.Purple, "Papereater_EN", Enemies.Mungling);
            med.AddRandomGroup(Aggregates.Purple, "Jabberwocky_EN", "NobodyGrave_EN");
            med.AddRandomGroup(Aggregates.Purple, "MudLung_EN", "2009_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", Aggregates.Red, "Skyloft_EN");
            med.AddRandomGroup("ToyUfo_EN", Aggregates.Purple, "NobodyGrave_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup(Aggregates.Red, "Pinano_EN", "Pinano_EN");
            med.AddRandomGroup(Aggregates.Purple, "Pinano_EN", "Pinano_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", Aggregates.Red, "Wall_EN");
            med.AddRandomGroup("2009_EN", Aggregates.Purple, "MudLung_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.AddRandomGroup("Jabberwocky_EN", Aggregates.Red, "Arceles_EN");
            med.AddRandomGroup("Jabberwocky_EN", Aggregates.Purple, "Skyloft_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Aggregates.Red, "Snaurce_EN");
            med.AddRandomGroup("AFlower_EN", Aggregates.Purple, "LostSheep_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", Aggregates.Red, "Windle_EN");
            med.AddRandomGroup("LittleBeak_EN", Aggregates.Purple, "Flarblet_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Aggregates.Red, "Surimi_EN");
            med.AddRandomGroup("Clione_EN", Aggregates.Purple, "MudLung_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", Aggregates.Red, "Arceles_EN");
            med.AddRandomGroup("Sinker_EN", Aggregates.Purple);

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", Aggregates.Red, "Pinano_EN");
            hard.AddRandomGroup("AFlower_EN", Aggregates.Purple, "Pinano_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", Aggregates.Red, "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Tripod_EN", Aggregates.Purple, "ToyUfo_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup("Unmung_EN", Aggregates.Red);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", Aggregates.Red, "Papereater_EN");
            hard.AddRandomGroup("Warbird_EN", Aggregates.Purple, "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", Aggregates.Red, "Papereater_EN");
            hard.AddRandomGroup("Clione_EN", Aggregates.Purple, "2009_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", Aggregates.Red, "2009_EN");
            hard.AddRandomGroup("Sinker_EN", Aggregates.Purple, "2009_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", Aggregates.Red, "Waltz_EN");
            hard.AddRandomGroup("Clown_EN", Aggregates.Purple, "Waltz_EN");
        }
        public static void Aggregates_Zone2()
        {
            AddTo easy = new AddTo(Orph.H.Aggregates.Yellow.Easy);
            easy.AddRandomGroup(Aggregates.Yellow, "Foxtrot_EN", "Foxtrot_EN");
            easy.AddRandomGroup(Aggregates.Yellow, Enemies.Solvent, Enemies.Suckle, Enemies.Suckle);

            AddTo med = new AddTo(Orph.H.Aggregates.Yellow.Med);
            med.AddRandomGroup(Aggregates.Yellow, "Enigma_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup(Aggregates.Yellow, Enemies.Shooter, "LostSheep_EN");
            med.AddRandomGroup(Aggregates.Yellow, Enemies.Feaster, "Enigma_EN");
            med.AddRandomGroup(Aggregates.Yellow, "Nameless_EN", "TheWhale_EN", "TheWhale_EN");
            med.AddRandomGroup(Aggregates.Yellow, "Solitaire_EN", "Solitaire_EN", "Surrogate_EN");
            med.AddRandomGroup(Aggregates.Yellow, "Nume_EN", "LostSheep_EN");
            med.AddRandomGroup(Aggregates.Yellow, "Rabies_EN", "Romantic_EN", "Romantic_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Aggregates.Yellow, "Sigil_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Aggregates.Yellow, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Aggregates.Yellow, Enemies.Camera);

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", Aggregates.Yellow, "SingingStone_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", Aggregates.Yellow, "Wednesday_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Aggregates.Yellow, "WindSong_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", Aggregates.Yellow, "Scrungie_EN");

            AddTo hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Aggregates.Yellow, "Author_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", Aggregates.Yellow, "Author_EN");

            easy = new AddTo(Siren.H.Aggregates.Blue.Easy);
            easy.AddRandomGroup(Aggregates.Blue, "Boiler_EN", "Stalker2_EN");

            med = new AddTo(Siren.H.Aggregates.Blue.Med);
            med.AddRandomGroup(Aggregates.Blue, "Tassnn_EN", "Tassnn_EN", "Stalker2_EN");
            med.AddRandomGroup(Aggregates.Blue, "WolfColony_EN", "WolfColony_EN");

            med = new AddTo(Siren.H.Wolf.Med);
            med.AddRandomGroup("WolfColony_EN", "WolfColony_EN", Aggregates.Blue);
        }
    }
}
