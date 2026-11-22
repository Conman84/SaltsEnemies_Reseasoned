using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Chapter27Crossover
    {
        public static void Add()
        {
            AddTo med = new AddTo(Garden.H.Vessel.Med);
            med.AddRandomGroup(Enemies.Vessel, Enemies.Troller, Enemies.Troller);
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "NeverMind_EN");

            AddTo hard = new AddTo(Garden.H.Vessel.Hard);
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, Enemies.Troller, Enemies.Troller);
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Troller, Enemies.Troller, "Vivarium_EN");
            hard.AddRandomGroup(Enemies.Vessel, "NeverMind_EN", "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Troller, Enemies.Troller, "Romantic_EN");

            med = new AddTo(Garden.H.Sisters.Med);
            med.AddRandomGroup(Enemies.MainSister, Enemies.Troller, "GlassFigurine_EN");
            med.AddRandomGroup(Enemies.MainSister, Enemies.Troller, "EyePalm_EN");
            med.AddRandomGroup(Enemies.MainSister, Enemies.Troller, "Indicator_EN");

            hard = new AddTo(Garden.H.Sisters.Hard);
            hard.AddRandomGroup(Enemies.MainSister, Enemies.Troller, Enemies.Troller);
            hard.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, Enemies.Troller);

            med = new AddTo(Garden.H.Phobia.Med);
            med.SimpleAddGroup(1, Enemies.Phobia, 2, Enemies.Troller);
            med.AddRandomGroup(Enemies.Phobia, "NeverMind_EN");
            hard = new AddTo(Garden.H.Phobia.Hard);
            hard.SimpleAddGroup(1, Enemies.Phobia, 3, Enemies.Troller);
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, Enemies.Troller);
            hard.AddRandomGroup(Enemies.Phobia, "NeverMind_EN", Enemies.Minister);
            hard.AddRandomGroup(Enemies.Phobia, "NeverMind_EN", "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Phobia, "NeverMind_EN", "OdeToHumanity_EN");

            med = new AddTo(Garden.H.NeverMind.Med);
            med.AddRandomGroup("NeverMind_EN", Enemies.MainSister);
            med.SimpleAddGroup(2, "NeverMind_EN", 1, "EggKeeper_EN");
            med.AddRandomGroup("NeverMind_EN", "EggKeeper_EN", "Celebration_EN");
            med.AddRandomGroup("NeverMind_EN", "Idiotware_EN");
            med.AddRandomGroup("NeverMind_EN", "Idiotware_EN", "BlackStar_EN");
            med.AddRandomGroup("NeverMind_EN", "Idiotware_EN", "Drippings_EN");
            med.SimpleAddGroup(2, "NeverMind_EN", 1, Enemies.Screaming);
            med.SimpleAddGroup(1, "NeverMind_EN", 2, "Attrition_EN");
            med.SimpleAddGroup(1, "NeverMind_EN", 2, "Git_EN");
            med.SimpleAddGroup(1, "NeverMind_EN", 2, "Allusion_EN");
            med.AddRandomGroup("NeverMind_EN", "NeverMind_EN", "Surrogate_EN");
            med.AddRandomGroup("NeverMind_EN", "NeverMind_EN", "Romantic_EN");
            med.AddRandomGroup("NeverMind_EN", Enemies.Polyp, "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomGroup("NeverMind_EN", Jumble.Mythos, Jumble.Mythos);
            med.AddRandomGroup("NeverMind_EN", Spoggle.Mythos, Spoggle.Mythos);
            med.AddRandomGroup("NeverMind_EN", "Beakart_EN", "Indicator_EN");

            hard = new AddTo(Garden.H.NeverMind.Hard);
            hard.AddRandomGroup("NeverMind_EN", "SomeoneSister_EN", "SomeoneSister_EN");
            hard.AddRandomGroup("NeverMind_EN", Enemies.MainSister, "CorpseChan_EN");
            hard.AddRandomGroup("NeverMind_EN", "EggKeeper_EN", "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomGroup("NeverMind_EN", "EggKeeper_EN", Enemies.Eclipse, Enemies.Eclipse);
            hard.AddRandomGroup("NeverMind_EN", "NeverMind_EN", "Idiotware_EN");
            hard.AddRandomGroup("NeverMind_EN", "NeverMind_EN", "Drippings_EN", "Drippings_EN");
            hard.AddRandomGroup("NeverMind_EN", Enemies.Screaming, Enemies.Shivering, Enemies.Shivering);
            hard.SimpleAddGroup(1, "NeverMind_EN", 2, "Bonsai_EN");
            hard.SimpleAddGroup(1, "NeverMind_EN", 3, "Git_EN");
            hard.SimpleAddGroup(1, "NeverMind_EN", 3, "Attrition_EN");
            hard.SimpleAddGroup(2, "NeverMind_EN", 1, "Allusion_EN");
            hard.AddRandomGroup("NeverMind_EN", Enemies.Polyp, Enemies.Polyp);
            hard.AddRandomGroup("NeverMind_EN", Enemies.Polyp, "PawnA_EN", "PawnA_EN");
            hard.SimpleAddGroup(2, "NeverMind_EN", 1, Enemies.Polyp);
            hard.SimpleAddGroup(1, "NeverMind_EN", 3, "Bonsai_EN");
            hard.SimpleAddGroup(2, "NeverMind_EN", 2, "Bonsai_EN");
            hard.SimpleAddGroup(2, "NeverMind_EN", 1, "Bonsai_EN");
            hard.SimpleAddGroup(2, "NeverMind_EN", 1, "Beakart_EN");


            hard = new AddTo(Garden.H.Portrait.Hard);
            hard.AddRandomGroup(Enemies.Portrait, Enemies.Troller, Enemies.Troller);
            hard.AddRandomGroup(Enemies.Portrait, "NeverMind_EN", Enemies.Shivering);

            med = new AddTo(Garden.H.Troller.Reckoner.Med);
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, Enemies.Prior);
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, Enemies.Prioress);
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, "Drippings_EN");
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, "Romantic_EN");
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, "Surrogate_EN");
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, "Git_EN");
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, "Bonsai_EN");
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, "Attrition_EN");
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, "Allusion_EN");
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, Jumble.Mythos);
            med.SimpleAddGroup(3, Enemies.Reckoner, 1, Spoggle.Mythos);
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, Jumble.Mythos, 1, "Surrogate_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, Spoggle.Mythos, 1, "Surrogate_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Attrition_EN", 1, "Git_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Attrition_EN", 1, Jumble.Mythos);
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Attrition_EN", 1, Spoggle.Mythos);
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Attrition_EN", 1, "EggKeeper_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Attrition_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Bonsai_EN", 1, "Git_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Bonsai_EN", 1, "GlassFigurine_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Bonsai_EN", 1, "Indicator_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Bonsai_EN", 1, "PawnA_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Bonsai_EN", 1, Enemies.Prior);
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Allusion_EN", 1, "Damocles_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Allusion_EN", 1, "MiniReaper_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Allusion_EN", 1, "BlackStar_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Allusion_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, "Allusion_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, Enemies.Prior, 1, Spoggle.Mythos);
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, Enemies.Prioress, 1, Jumble.Mythos);
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, Enemies.Prior, 1, "Vivarium_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, Enemies.Prioress, 1, "LittleAngel_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, Enemies.Prior, 1, "Git_EN");
            med.SimpleAddGroup(2, Enemies.Reckoner, 1, Enemies.Prioress, 1, "Drippings_EN");
            med = new AddTo(Garden.H.Troller.Help.Med);
            med.SimpleAddGroup(3, Enemies.Help, 1, Enemies.Prior);
            med.SimpleAddGroup(3, Enemies.Help, 1, Enemies.Prioress);
            med.SimpleAddGroup(3, Enemies.Help, 1, "Drippings_EN");
            med.SimpleAddGroup(3, Enemies.Help, 1, "Romantic_EN");
            med.SimpleAddGroup(3, Enemies.Help, 1, "Surrogate_EN");
            med.SimpleAddGroup(3, Enemies.Help, 1, "Git_EN");
            med.SimpleAddGroup(3, Enemies.Help, 1, "Bonsai_EN");
            med.SimpleAddGroup(3, Enemies.Help, 1, "Attrition_EN");
            med.SimpleAddGroup(3, Enemies.Help, 1, "Allusion_EN");
            med.SimpleAddGroup(3, Enemies.Help, 1, Jumble.Mythos);
            med.SimpleAddGroup(3, Enemies.Help, 1, Spoggle.Mythos);
            med.SimpleAddGroup(2, Enemies.Help, 1, Jumble.Mythos, 1, "Surrogate_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, Spoggle.Mythos, 1, "Surrogate_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Attrition_EN", 1, "Git_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Attrition_EN", 1, Jumble.Mythos);
            med.SimpleAddGroup(2, Enemies.Help, 1, "Attrition_EN", 1, Spoggle.Mythos);
            med.SimpleAddGroup(2, Enemies.Help, 1, "Attrition_EN", 1, "EggKeeper_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Attrition_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Bonsai_EN", 1, "Git_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Bonsai_EN", 1, "GlassFigurine_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Bonsai_EN", 1, "Indicator_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Bonsai_EN", 1, "PawnA_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Bonsai_EN", 1, Enemies.Prior);
            med.SimpleAddGroup(2, Enemies.Help, 1, "Allusion_EN", 1, "Damocles_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Allusion_EN", 1, "MiniReaper_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Allusion_EN", 1, "BlackStar_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Allusion_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, "Allusion_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, Enemies.Prior, 1, Spoggle.Mythos);
            med.SimpleAddGroup(2, Enemies.Help, 1, Enemies.Prioress, 1, Jumble.Mythos);
            med.SimpleAddGroup(2, Enemies.Help, 1, Enemies.Prior, 1, "Vivarium_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, Enemies.Prioress, 1, "LittleAngel_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, Enemies.Prior, 1, "Git_EN");
            med.SimpleAddGroup(2, Enemies.Help, 1, Enemies.Prioress, 1, "Drippings_EN");

            med = new AddTo(Garden.H.Leviat.Med);
            med.AddRandomGroup(Enemies.Leviat, Enemies.Troller, Enemies.Troller);
            med.SimpleAddGroup(2, Enemies.Leviat, 1, Enemies.Troller);

            hard = new AddTo(Garden.H.Leviat.Hard);
            hard.SimpleAddGroup(1, Enemies.Leviat, 3, Enemies.Troller);
            hard.SimpleAddGroup(2, Enemies.Leviat, 2, Enemies.Troller);

            med = new AddTo(Garden.H.Shambler.Med);
            med.AddRandomGroup(Enemies.Shambler, Enemies.Troller, Enemies.Troller);
            med.AddRandomGroup(Enemies.Shambler, "NeverMind_EN", Enemies.Shivering);
            med.AddRandomGroup(Enemies.Shambler, Enemies.Troller, Enemies.Polyp);

            hard = new AddTo(Garden.H.Shambler.Hard);
            hard.AddRandomGroup(Enemies.Shambler, Enemies.Troller, "Ascendant_EN");
            hard.AddRandomGroup(Enemies.Shambler, "NeverMind_EN", Enemies.Troller);
            hard.AddRandomGroup(Enemies.Shambler, "NeverMind_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Cthonian.Hard);
            hard.SimpleAddGroup(1, Enemies.Cthonian, 2, Enemies.Troller);
            hard.AddRandomGroup(Enemies.Cthonian, Enemies.Troller, Enemies.Troller, "Ascendant_EN");
            hard.AddRandomGroup(Enemies.Cthonian, Enemies.Troller, Enemies.Troller, "Vivarium_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.SimpleAddGroup(1, "Beakart_EN", 2, Enemies.Troller);

            AddTo easy = new AddTo(Garden.H.Idiotware.Easy);
            easy.AddRandomGroup("Idiotware_EN", Enemies.Troller);
            easy.AddRandomGroup("Idiotware_EN", Enemies.Troller, "GlassFigurine_EN");
            easy.AddRandomGroup("Idiotware_EN", Enemies.Troller, "BlackStar_EN");
            med = new AddTo(Garden.H.Idiotware.Med);
            med.SimpleAddGroup(1, "Idiotware_EN", 2, Enemies.Troller);
            med.SimpleAddGroup(1, "Idiotware_EN", 2, Enemies.Troller, 1, "Vivarium_EN");

            easy = new AddTo(Garden.H.Attrition.Easy);
            easy.SimpleAddGroup(2, "Attrition_EN", 1, Enemies.Troller);
            easy = new AddTo(Garden.H.Git.Easy);
            easy.SimpleAddGroup(2, "Git_EN", 1, Enemies.Troller);
            easy = new AddTo(Garden.H.Bonsai.Easy);
            easy.SimpleAddGroup(2, "Bonsai_EN", 1, Enemies.Troller);

            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(3, "Attrition_EN", 1, Enemies.Troller);
            med.SimpleAddGroup(2, "Attrition_EN", 2, Enemies.Troller);
            med.SimpleAddGroup(2, "Attrition_EN", 1, Enemies.Troller, 1, "Surrogate_EN");
            med = new AddTo(Garden.H.Git.Med);
            med.SimpleAddGroup(3, "Git_EN", 1, Enemies.Troller);
            med.SimpleAddGroup(2, "Git_EN", 2, Enemies.Troller);
            med.SimpleAddGroup(2, "Git_EN", 1, Enemies.Troller, 1, "Romantic_EN");
            med = new AddTo(Garden.H.Bonsai.Med);
            med.SimpleAddGroup(3, "Bonsai_EN", 1, Enemies.Troller);
            med.SimpleAddGroup(2, "Bonsai_EN", 2, Enemies.Troller);
            med.SimpleAddGroup(2, "Bonsai_EN", 1, Enemies.Troller, 1, "Surrogate_EN");

        }
    }
}
