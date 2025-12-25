using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HydraEffects
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(Blacklister).GetMethod(nameof(Blacklister.AllowEnemy), ~BindingFlags.Default), typeof(HydraEffects).GetMethod(nameof(Blacklister_AllowEnemy), ~BindingFlags.Default));
        }

        public static bool Blacklister_AllowEnemy(Func<string, bool> orig, string enemy)
        {
            if (enemy == Sub) return false;

            return orig(enemy);
        }

        public static string Sub => "ReverseFalseHydra_EN";
    }
}
