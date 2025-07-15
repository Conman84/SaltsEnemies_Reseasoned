using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Colophon16_18
    {
        public static void Add()
        {
            //SHORE
            AddTo med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", Colophon.Red, Colophon.Blue);
            med.AddRandomGroup("ToyUfo_EN", "Pinano_EN", Colophon.Red);
            med.AddRandomGroup("ToyUfo_EN", "MudLung_EN", Colophon.Blue);
            med.AddRandomGroup("ToyUfo_EN", "Skyloft_EN", Colophon.Blue, "MudLung_EN");
            med.AddRandomGroup("ToyUfo_EN", "MudLung_EN", "MudLung_EN", Colophon.Red);
            med.AddRandomGroup("ToyUfo_EN", "DeadPixel_EN", "DeadPixel_EN", Colophon.Blue);

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", Colophon.Red, Colophon.Blue);
            med.AddRandomGroup("Sinker_EN", "ToyUfo_EN", Colophon.Blue);
            med.AddRandomGroup("Sinker_EN", "Pinano_EN", Colophon.Blue);
            med.AddRandomGroup("Sinker_EN", "MudLung_EN", "MudLung_EN", Colophon.Red);
            med.AddRandomGroup("Sinker_EN", Enemies.Mungling, Colophon.Red);

            AddTo hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "LittleBeak_EN", Colophon.Blue);
            hard.AddRandomGroup("Sinker_EN", "FlaMinGoa_EN", Colophon.Blue);
            hard.AddRandomGroup("Sinker_EN", "AFlower_EN", Colophon.Red);
            hard.AddRandomGroup("Sinker_EN", Colophon.Red, Colophon.Blue, "Skyloft_EN");
            hard.AddRandomGroup("Sinker_EN", Colophon.Red, Colophon.Blue, "TortureMeNot_EN", "TortureMeNot_EN");

            AddTo easy = new AddTo(Shore.H.Colophon.Red.Easy);
            easy.AddRandomGroup(Colophon.Red, Colophon.Red, "NobodyGrave_EN");
            easy.AddRandomGroup(Colophon.Red, "NobodyGrave_EN", "Arceles_EN");

            easy = new AddTo(Shore.H.Colophon.Blue.Easy);
            easy.AddRandomGroup(Colophon.Blue, "NobodyGrave_EN");
            easy.SimpleAddGroup(1, Colophon.Blue, 3, "TortureMeNot_EN");

            med = new AddTo(Shore.H.Colophon.Red.Med);
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, Colophon.Red, "NobodyGrave_EN");
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            med = new AddTo(Shore.H.Colophon.Blue.Med);
            med.AddRandomGroup(Colophon.Blue, Colophon.Red, "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup(Colophon.Blue, Colophon.Red, Colophon.Blue, "NobodyGrave_EN");
            med.SimpleAddGroup(2, Colophon.Blue, 3, "TortureMeNot_EN");

            med = new AddTo(Shore.H.DeadPixel.Med);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", Colophon.Blue, "NobodyGrave_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", Colophon.Red, "ToyUfo_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Colophon.Red, "MudLung_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Sinker_EN", Colophon.Red);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", Colophon.Blue, "ToyUfo_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", Colophon.Red, Colophon.Blue);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", Colophon.Blue, "NobodyGrave_EN");

            //ORPHEUM

            easy = new AddTo(Orph.H.Shooter.Easy);
            easy.AddRandomGroup(Enemies.Shooter, Colophon.Red, Colophon.Red);
            easy.AddRandomGroup(Enemies.Shooter, Colophon.Red, Colophon.Blue);
            easy.AddRandomGroup(Enemies.Shooter, Colophon.Blue);
            easy.AddRandomGroup(Enemies.Shooter, Colophon.Blue, Enemies.Solvent);

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Crystal_EN", Colophon.Red);
            med.AddRandomGroup("Crystal_EN", "MusicMan_EN", Colophon.Yellow);
            med.AddRandomGroup("Crystal_EN", "Scrungie_EN", Colophon.Purple);
            med.AddRandomGroup("Crystal_EN", "Something_EN", Colophon.Purple);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", Colophon.Yellow, Colophon.Purple);
            med.AddRandomGroup("Evileye_EN", "MusicMan_EN", Colophon.Purple);
            med.AddRandomGroup("Evileye_EN", "TheCrow_EN", Colophon.Yellow);
            med.AddRandomGroup("Evileye_EN", Colophon.Yellow, "WindSong_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", Colophon.Yellow, "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("YellowAngel_EN", Colophon.Purple, "Freud_EN");
            med.AddRandomGroup("YellowAngel_EN", Colophon.Purple, "Spectre_EN", "Spectre_EN");
            med.AddRandomGroup("YellowAngel_EN", Colophon.Blue, "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, Colophon.Yellow);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, Colophon.Purple);
            med.AddRandomGroup(Enemies.Shooter, "MusicMan_EN", Colophon.Red, Colophon.Blue);
            med.AddRandomGroup(Enemies.Shooter, Colophon.Yellow, "Enigma_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", Colophon.Yellow, Colophon.Purple);
            hard.AddRandomGroup("TheDragon_EN", Colophon.Blue, Colophon.Red, Colophon.Blue);
            hard.AddRandomGroup("TheDragon_EN", Colophon.Purple, "Maw_EN");
            hard.AddRandomGroup("TheDragon_EN", Colophon.Yellow, "Evileye_EN");

            med = new AddTo(Orph.H.Colophon.Yellow.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, Enemies.Shooter);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomGroup(Colophon.Yellow, "Enigma_EN", "Enigma_EN", Enemies.Shooter);
            med.AddRandomGroup(Colophon.Yellow, "Scrungie_EN", Enemies.Shooter, "LostSheep_EN");

            med = new AddTo(Orph.H.Colophon.Purple.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, Enemies.Shooter);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomGroup(Colophon.Purple, "MusicMan_EN", "MusicMan_EN", "TortureMeNot_EN");
            med.AddRandomGroup(Colophon.Purple, "WindSong_EN", Enemies.Shooter);

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Colophon.Yellow, "Crystal_EN");
            hard.AddRandomGroup("Revola_EN", Colophon.Purple, Enemies.Shooter);
        }
    }
}
