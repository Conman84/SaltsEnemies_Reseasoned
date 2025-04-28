using BrutalAPI;
using System.IO;
using System.Linq;
using System.Reflection;
using System;
using UnityEngine;
using MonoMod.RuntimeDetour;

namespace SaltsEnemies_Reseasoned
{
    public static class ResourceLoaderHook
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(ResourceLoader).GetMethod(nameof(ResourceLoader.LoadTexture), BindingFlags.Static | BindingFlags.Public), typeof(ResourceLoaderHook).GetMethod(nameof(ResourceLoader_LoadTexture), ~BindingFlags.Default));
        }
        public static Texture2D ResourceLoader_LoadTexture(Func<string, Assembly, Texture2D> orig, string sprite, Assembly assembly)
        {
            Texture2D ret = orig(sprite, assembly);
            if (ret == null || ret.Equals(null)) Debug.LogError("resourceloader error: sprite name: " + sprite);
            return ret;
        }
    }
}
