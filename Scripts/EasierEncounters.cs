using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using SaltEnemies_Reseasoned;

namespace SaltsEnemies_Reseasoned
{
    public class AddTo
    {
        string bundle;

        public AddTo(string _bundle) => bundle = _bundle;

        //EXAMPLE HOW TO USE
        public void Example()
        {
            AddTo bundle1 = new AddTo("H_Zone_1_PretendEnemy_Bundle");
            bundle1.AddRandomGroup("Mung_EN", "Mung_EN", "Mung_EN", "Mung_EN", "Mung_EN");
            bundle1.AddRandomGroup("Mung_EN", "Mung_EN", "Mung_EN", "Mung_EN");
            bundle1.AddRandomGroup("Mung_EN", "Mung_EN", "Mung_EN");
            bundle1.AddRandomGroup("Mung_EN", "Mung_EN");
            bundle1.AddRandomGroup("Mung_EN");

            //example how to use quick access names
            bundle1.AddRandomGroup(Jumble.Red, Jumble.Yellow, Jumble.Blue, Jumble.Purple);
            bundle1.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, Spoggle.Red, Spoggle.Purple);
        }

        //RANDOM
        public void AddRandomGroup(string enemy1 = "", string enemy2 = "", string enemy3 = "", string enemy4 = "", string enemy5 = "")
        {
            List<string> ret = new List<string>();
            if (enemy1 != "") ret.Add(enemy1);
            if (enemy2 != "") ret.Add(enemy2);
            if (enemy3 != "") ret.Add(enemy3);
            if (enemy4 != "") ret.Add(enemy4);
            if (enemy5 != "") ret.Add(enemy5);
            if (ret.Count <= 0) return;
            AddRandomGroup(ret.ToArray());
        }
        public void SimpleAddGroup(int num1 = 0, string enemy1 = "", int num2 = 0, string enemy2 = "", int num3 = 0, string enemy3 = "", int num4 = 0, string enemy4 = "", int num5 = 0, string enemy5 = "")
        {
            List<string> ret = new List<string>();
            if (enemy1 != "") for (int i = 0; i < num1; i++) ret.Add(enemy1);
            if (enemy2 != "") for (int i = 0; i < num2; i++) ret.Add(enemy2);
            if (enemy3 != "") for (int i = 0; i < num3; i++) ret.Add(enemy3);
            if (enemy4 != "") for (int i = 0; i < num4; i++) ret.Add(enemy4);
            if (enemy5 != "") for (int i = 0; i < num5; i++) ret.Add(enemy5);
            if (ret.Count <= 0) return;
            AddRandomGroup(ret.ToArray());
        }

        public void AddRandomGroup(string[] enemies)
        {
            if (!MultiENExistInternal(enemies))
            {
                if (SaltsReseasoned.DebugVer) Debug.LogWarning("Failed to add random group to " + bundle);
                return;
            }
            AddRandomGroup_Internal(new RandomEnemyGroup(enemies));
        }
        public void AddRandomGroup_Internal(RandomEnemyGroup group)
        {
            if (!BundleExist(bundle)) return;
            if (!BundleRandom(bundle, SaltsReseasoned.DebugVer)) return;
            //List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            //list2.Add(group);
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles.Add(group);
        }
        //thought about it, not making static bundle methods.

        //DEBUGGING
        public static List<string> Printeds = new List<string>();
        public static bool EnemyExist(string name)
        {
            if (!LoadedAssetsHandler.LoadedEnemies.Keys.Contains(name) && LoadedAssetsHandler.LoadEnemy(name) == null) { if (!Printeds.Contains(name) && SaltsReseasoned.DebugVer) { Debug.LogWarning("Enemy: " + name + " is null"); Printeds.Add(name); } return false; }
            return LoadedAssetsHandler.GetEnemy(name) != null;
        }
        public static bool BundleExist(string name)
        {
            if (!LoadedAssetsHandler.LoadedEnemyBundles.Keys.Contains(name) && LoadedAssetsHandler.LoadEnemyBundle(name) == null) { if (!Printeds.Contains(name) && SaltsReseasoned.DebugVer) { Debug.LogWarning("Bundle: " + name + " is null"); Printeds.Add(name); } return false; }
            return LoadedAssetsHandler.GetEnemyBundle(name) != null;
        }
        public static bool BundleRandom(string name, bool DoDebug = true)
        {
            if (!BundleExist(name)) return false;
            if (!(LoadedAssetsHandler.GetEnemyBundle(name) is RandomEnemyBundleSO) && DoDebug) Debug.LogWarning("Bundle: " + name + " is not random, checked for random");
            return LoadedAssetsHandler.GetEnemyBundle(name) is RandomEnemyBundleSO;
        }
        public static bool BundleStatic(string name)
        {
            if (!BundleExist(name)) return false;
            if (SaltsReseasoned.DebugVer) if (BundleRandom(name, false)) Debug.LogWarning("Bundle: " + name + "is random, checked for static");
            return !BundleRandom(name, false);
        }
        public static bool MultiENExistInternal(string[] names)
        {
            foreach (string name in names)
            {
                if (!EnemyExist(name)) return false;
            }
            return true;
        }
    }

    //ENEMY NAMES QUICK ACCESS
    public static class Jumble
    {
        public static string Red => "JumbleGuts_Clotted_EN";
        public static string Yellow => "JumbleGuts_Waning_EN";
        public static string Blue => "JumbleGuts_Hollowing_EN";
        public static string Purple => "JumbleGuts_Flummoxing_EN";
        public static string Grey => "RusticJumbleguts_EN";
        public static string Gray => Grey;
        public static string Unstable => "JumbleGuts_Digital_EN";
    }
    public static class Spoggle
    {
        public static string Yellow => "Spoggle_Spitfire_EN";
        public static string Blue => "Spoggle_Ruminating_EN";
        public static string Red => "Spoggle_Writhing_EN";
        public static string Purple => "Spoggle_Resonant_EN";
        public static string Grey => "MortalSpoggle_EN";
        public static string Gray => Grey;
        public static string Unstable => "Spoggle_Mechanical_EN";
    }
    public static class Flower
    {
        public static string Yellow => "YellowFlower_EN";
        public static string Purple => "PurpleFlower_EN";
        public static string Red => "RedFlower_EN";
        public static string Blue => "BlueFlower_EN";
        public static string Grey => "GreyFlower_EN";
        public static string Gray => Grey;
    }
    public static class Noses
    {
        public static string Red => "ProlificNosestone_EN";
        public static string Blue => "ScatterbrainedNosestone_EN";
        public static string Yellow => "SweatingNosestone_EN";
        public static string Purple => "MesmerizingNosestone_EN";
        public static string Grey => "UninspiredNosestone_EN";
        public static string Gray => Grey;
    }
    public static class Colophon
    {
        public static string Red => "ColophonDefeated_EN";
        public static string Blue => "ColophonComposed_EN";
        public static string Yellow => "ColophonMaladjusted_EN";
        public static string Purple => "ColophonDelighted_EN";
    }
    public static class Bots
    {
        public static string Yellow => "YellowBot_EN";
        public static string Purple => "PurpleBot_EN";
        public static string Red => "RedBot_EN";
        public static string Blue => "BlueBot_EN";
        public static string Grey => "GreyBot_EN";
        public static string Gray => Grey;
    }
    public static class Ecstasy
    {
        public static string Yellow => "Ecstasy_Yellow_EN";
        public static string Purple => "Ecstasy_Purple_EN";
        public static string Red => "Ecstasy_Red_EN";
        public static string Blue => "Ecstasy_Blue_EN";
        public static string Gray => "Ecstasy_Gray_EN";


        public static string Random => List.GetRandom();
        public static string[] List = [Red, Blue, Yellow, Purple];
    }
    public static class Humor
    {
        public static string Yellow => "HumourCholeric_EN";
        public static string Purple => "HumourMelancholy_EN";
        public static string Red => "HumourSanguine_EN";
        public static string Blue => "HumourPhlegmatic_EN";
    }
    public static class Enemies
    {
        public static string Skinning => "SkinningHomunculus_EN";
        public static string Shivering => "ShiveringHomunculus_EN";
        public static string Minister => "GigglingMinister_EN";
        public static string Sacrifice => "WrigglingSacrifice_EN";
        public static string Solvent => "LivingSolvent_EN";
        public static string Tank => "RealisticTank_EN";
        public static string Suckle => "SilverSuckle_EN";
        public static string Camera => "MechanicalLens_EN";
        public static string Unmung => "TeachaMantoFish_EN";
        public static string Mungling => "MunglingMudLung_EN";
        public static string Shooter => "SkeletonShooter_EN";
        public static string Shuffler => "Shawled_Shuffler_EN";
        public static string Swine => "UnculturedSwine_EN";
        public static string Polyp => "SpectralPolyp_EN";
        public static string Puker => "PetrifiedPuker_EN";
        public static string Phalaris => "GreatPhalaris_EN";
        public static string Foundling => "ProdigalFoundling_EN";
    }
}
