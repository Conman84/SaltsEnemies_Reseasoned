using BepInEx;
using BepInEx.Configuration;
using System.IO;

namespace SaltsEnemies_Reseasoned
{
    public static class GeneralConfig
    {
        public static ConfigEntry<bool> MidnightStoplightTrainAnimation;
        public static ConfigEntry<bool> PossibleNeverMindArachnophobiaCensor;
        public static void Setup()
        {
            ConfigFile seatbelt = new ConfigFile(Path.Combine(Paths.ConfigPath, "SaltEnemiesTmConfigurationFile.cfg"), true);
            MidnightStoplightTrainAnimation = seatbelt.Bind<bool>("Specific", "MidnightStoplight_TrainAnimation", true, "While true, the enemy Mindight Traffic Light will use a custom Train animation. While false, it will use Clobber's animation instead.");
            PossibleNeverMindArachnophobiaCensor = seatbelt.Bind<bool>("Specific", "NeverMind_ArachnophobiaCensor", false, "While true, censors the Never Mind's enemy sprite. The Never Mind is not very spider-like and contains no direct insect anatomy but it emulates the general shape of a spider.");
        }
    }
}
