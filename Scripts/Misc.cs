using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using UnityEngine;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public static class April
    {
        public static bool Birthday
        {
            get
            {
                //return true;
                if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1) return true;
                return false;
            }
        }
        public static int Mod
        {
            get
            {
                if (Birthday) return 5;
                return 1;
            }
        }
        public static int MoreMod
        {
            get
            {
                if (Birthday) return 50;
                return 1;
            }
        }
        public static int LessMod
        {
            get
            {
                if (Birthday) return 25;
                return 0;
            }
        }

        public static string AppData => Application.persistentDataPath;
        public static bool Custom
        {
            get
            {
                if (Birthday) return true;
                bool ret = Directory.Exists(AppData + "/Mods/") && Directory.Exists(AppData + "/Mods/SaltHawthorne/") && File.Exists(AppData + "/Mods/SaltHawthorne/custom.txt");

                if (SaltsReseasoned.DebugVer) Debug.Log("custom:" + ret.ToString());
                return ret;

                string path = Assembly.GetExecutingAssembly().Location;
                return File.Exists(path.Replace("SaltsEnemies_Reseasoned.dll", "custom.txt"));
            }
        }
    }
}

/*---------------------CURRENT  BIRTHDAY  POOL--------------------------*/
//Lost Sheep
//Enigma
//Dead Pixel
//Little Angel
//Unmung
//Stargazer
//Crow
//Freud
//Camera
//Postmodern
//Clock Tower
//Wind Song
//Solvent
//Sigil
//Mini-Reaper
//Shua
//Skyloft
//Damocles
//Hunter
//Warbird
//Blackstar
//Maw
//Clione
//Stoplight
//Pinano
//Projector
//Grey Bot
//Crystal
//Dragon
//Cruelties
//Evileye
//Grave
//Yellow Angel
//Chien
//Shooter
//Pawn
//Starless
//Wednesday
//Yang
//Yin
//Solitaire
//Author
//Clown
//Amalga
//Hauntling
//Insider
//Corpse Chan
//Jabberwocky
//In The Dark
//Sundowner