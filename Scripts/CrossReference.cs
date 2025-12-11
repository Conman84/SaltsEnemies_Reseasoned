using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SaltsEnemies_Reseasoned
{
    public static class LunopticonHandler
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(Gatekeeper).GetMethod(nameof(Gatekeeper.AllowEnemy), ~BindingFlags.Default), typeof(LunopticonHandler).GetMethod(nameof(Gatekeeper_AllowEnemy), ~BindingFlags.Default));
        }

        public static bool Gatekeeper_AllowEnemy(Func<string, bool> orig, string enemy)
        {
            if (!Legacy.Check && Salt.Hidden.Contains(enemy)) return false;

            return orig(enemy);
        }
    }
}
