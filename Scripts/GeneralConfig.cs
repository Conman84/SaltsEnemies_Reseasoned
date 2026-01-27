using BepInEx;
using BepInEx.Configuration;
using System.IO;

namespace SaltsEnemies_Reseasoned
{
    public static class GeneralConfig
    {
        public static ConfigEntry<bool> MidnightStoplightTrainAnimation;
        public static void Setup()
        {
            ConfigFile seatbelt = new ConfigFile(Path.Combine(Paths.ConfigPath, "SaltEnemiesTMConfigurationFile.cfg"), true);
            MidnightStoplightTrainAnimation = seatbelt.Bind<bool>("Specific", "MidnightStoplight_TrainAnimation", true, "While true, the enemy Mindight Traffic Light will use a custom Train animation. While false, it will use Clobber's animation instead.");
        }
    }
}
