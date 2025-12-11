using UnityEngine;
using System.IO;
using System.Reflection;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Legacy
    {
        public static bool Check
        {
            get
            {
                bool ret = Directory.Exists(OldData + "/Mods/");

                if (SaltsReseasoned.Testing) Debug.Log("legacy:" + ret.ToString());
                return ret;
            }
        }
        public static string OldData => Application.persistentDataPath.Replace("ItsTheTalia", "ItsTheMaceo");
    }
}
