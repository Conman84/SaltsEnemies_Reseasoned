using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace SaltsEnemies_Reseasoned
{
    public class KonamiHandler : MonoBehaviour
    {
        public static string ID => "KonamiCode";
        public static Key[] _passkey = [
            Key.UpArrow,
            Key.UpArrow,
            Key.DownArrow,
            Key.DownArrow,
            Key.LeftArrow,
            Key.RightArrow,
            Key.LeftArrow,
            Key.RightArrow,
            Key.B,
            Key.A,
            ];
        public static int place = 0;
        public static bool Solved = false;

        public void Awake()
        {
            if (Keyboard.current == null)
            {
                //Debug.LogWarning("Keyboard null?");
            }
            if (LoadedDBsHandler.InfoHolder.Game.GetBoolData(ID))
            {
                Solved = true;
                //Debug.Log("already solved");
                return;
            }
            if (Solved)
            {
                LoadedDBsHandler.InfoHolder.Game.SetBoolData(ID, true);
                //Debug.Log("already solved");
            }
        }

        public void Update()
        {
            if (!Solved && Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
            {
                //check save
                if (LoadedDBsHandler.InfoHolder.Game.GetBoolData(ID))
                {
                    Solved = true;
                    //Debug.Log("already solved");
                    return;
                }

                if (place >= _passkey.Length)
                {
                    if (Keyboard.current[Key.Enter].wasPressedThisFrame || Keyboard.current[Key.Space].wasPressedThisFrame || Keyboard.current[Key.NumpadEnter].wasPressedThisFrame)
                    {
                        Solved = true;
                        LoadedDBsHandler.InfoHolder.Game.SetBoolData(ID, true);
                        //Debug.Log("FUCKING HI GUYSSS");
                    }
                }
                else if (Keyboard.current[_passkey[place]].wasPressedThisFrame)
                {
                    place++;
                }
                else
                {
                    place = 0;
                }
            }
        }

    }
}
