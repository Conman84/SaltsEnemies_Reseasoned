using BepInEx.Configuration;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class RemovesPure
    {
        public static ConfigEntry<bool> OtherMods;
        public static void Spoggles()
        {
            LoadedAssetsHandler.GetEnemy(Spoggle.Yellow).passiveAbilities.Remove(Passives.Pure);
            LoadedAssetsHandler.GetEnemy(Spoggle.Blue).passiveAbilities.Remove(Passives.Pure);
            LoadedAssetsHandler.GetEnemy(Spoggle.Red).passiveAbilities.Remove(Passives.Pure);
            LoadedAssetsHandler.GetEnemy(Spoggle.Purple).passiveAbilities.Remove(Passives.Pure);

            if (OtherMods.Value)
            {
                if (Check.EnemyExist(Spoggle.Unstable)) LoadedAssetsHandler.GetEnemy(Spoggle.Unstable).passiveAbilities.Remove(Passives.Pure);
            }
        }
        public static void Jumbles()
        {
            //make transfusion not affect other transfusers?? altho.. do they need it. hmm. idk
        }
    }
}
