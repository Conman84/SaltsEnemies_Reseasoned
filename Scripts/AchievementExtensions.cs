using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AchievementExtensions
    {
        public static void AddHiddenAchievement(this ModdedAchievements self)
        {
            LoadedDBsHandler.AchievementDB._steamAchievements.TryAddModdedAchievement(self.achievement);
        }
    }
}
