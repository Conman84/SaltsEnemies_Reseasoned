using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MythosMoreCrossovers
    {
        public delegate TResult EffectHook<T1, T2, T3, T4, T5,T6,  T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, out T7 arg7);
        public static void MungedOneHookSetup()
        {
            //MungedOneTransformationEffect
            if (Check.EnemyExist("MungedOne_EN"))
            {
                IDetour hook = new Hook(LoadedAssetsHandler.GetEnemy("MungedOne_EN").abilities[0].ability.effects[0].effect.GetType().GetMethod("PerformEffect", ~BindingFlags.Default), typeof(MythosMoreCrossovers).GetMethod(nameof(Run_Effect), ~BindingFlags.Default));
            }
        }
        public static bool Run_Effect(EffectHook<EffectSO, CombatStats, IUnit, TargetSlotInfo[], bool, int, int, bool> orig, EffectSO self, CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.IsAlive)
                {
                    if (num < 0)
                    {
                        list.Add(targetSlotInfo);
                        num = targetSlotInfo.Unit.CurrentHealth;
                    }
                    else if (targetSlotInfo.Unit.CurrentHealth < num)
                    {
                        list.Clear();
                        list.Add(targetSlotInfo);
                        num = targetSlotInfo.Unit.CurrentHealth;
                    }
                    else if (targetSlotInfo.Unit.CurrentHealth == num)
                    {
                        list.Add(targetSlotInfo);
                    }
                }
            }
            foreach (TargetSlotInfo item in list)
            {
                if (!item.HasUnit || !item.Unit.UnitTypes.Contains(UnitType_GameIDs.Fish.ToString()))
                {
                    continue;
                }
                if (item.Unit.EntityID == "Minana_EN")
                {
                    EnemySO enemy = LoadedAssetsHandler.GetEnemy("Pinano_EN");
                    return stats.TryTransformEnemy(item.Unit.ID, enemy, (bool)self.GetType().GetField("_fullyHeal").GetValue(self), (bool)self.GetType().GetField("_maintainTimelineAbilities").GetValue(self), (bool)self.GetType().GetField("_maintainMaxHealth").GetValue(self), (bool)self.GetType().GetField("_currentToMaxHealth").GetValue(self));
                }
                if (item.Unit.EntityID == "Dangler_EN")
                {
                    EnemySO enemy = LoadedAssetsHandler.GetEnemy("Sinker_EN");
                    return stats.TryTransformEnemy(item.Unit.ID, enemy, (bool)self.GetType().GetField("_fullyHeal").GetValue(self), (bool)self.GetType().GetField("_maintainTimelineAbilities").GetValue(self), (bool)self.GetType().GetField("_maintainMaxHealth").GetValue(self), (bool)self.GetType().GetField("_currentToMaxHealth").GetValue(self));
                }
                if (item.Unit.EntityID == Enemies.Unmung)
                {
                    EnemySO enemy = LoadedAssetsHandler.GetEnemy(Enemies.Unmung);
                    return stats.TryTransformEnemy(item.Unit.ID, enemy, true, (bool)self.GetType().GetField("_maintainTimelineAbilities").GetValue(self), (bool)self.GetType().GetField("_maintainMaxHealth").GetValue(self), (bool)self.GetType().GetField("_currentToMaxHealth").GetValue(self));
                }
            }

            return orig(self, stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
        public static void UpdateUngodFollowersGlitch()
        {
            if (Check.EnemyExist("BackupDancer_EN")) LoadedAssetsHandler.GetEnemy("BackupDancer_EN").unitTypes.Add("Ungod_Follower");
            if (Check.EnemyExist("Metronome_EN")) LoadedAssetsHandler.GetEnemy("Metronome_EN").unitTypes.Add("Ungod_Follower");
            if (Check.EnemyExist("Loudhailer_EN")) LoadedAssetsHandler.GetEnemy("Loudhailer_EN").unitTypes.Add("Ungod_Follower");
            if (Check.EnemyExist("StageLight_EN")) LoadedAssetsHandler.GetEnemy("StageLight_EN").unitTypes.Add("Ungod_Follower");
        }
        
        public static void _Shore()
        {
            SaltsReseasoned.PCall(MungedOneHookSetup);

            AddTo med = new AddTo(Shore.H.Munged.Med);
            med.SimpleAddGroup(1, "MungedOne_EN", 2, "Pinano_EN");
            med.SimpleAddGroup(1, "MungedOne_EN", 4, "Minana_EN");
            med.SimpleAddGroup(1, "MungedOne_EN", 2, "MudLung_EN", 1, "NobodyGrave_EN");
            med.SimpleAddGroup(1, "MungedOne_EN", 2, "Minana_EN", 1, "ToyUfo_EN");
            med.SimpleAddGroup(1, "MungedOne_EN", 2, "MudLung_EN", 1, "Windle_EN");
            med.SimpleAddGroup(1, "MungedOne_EN", 2, "MudLung_EN", 1, "2009_EN");
            med.AddRandomGroup("MungedOne_EN", Enemies.Mungling, "Papereater_EN");
            med.AddRandomGroup("MungedOne_EN", Enemies.Mungling, "Hauntling_EN");
            med.AddRandomGroup("MungedOne_EN", "Sinker_EN", "Arceles_EN");
            med.AddRandomGroup("MungedOne_EN", "AFlower_EN", "Goa_EN");

            AddTo hard = new AddTo(Shore.H.Munged.Hard);
            hard.AddRandomGroup("MungedOne_EN", "MudLung_EN", "MudLung_EN", "LittleBeak_EN");
            hard.SimpleAddGroup(1, "MungedOne_EN", 3, "Pinano_EN");
            hard.AddRandomGroup("MungedOne_EN", "Sinker_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("MungedOne_EN", "AFlower_EN", Enemies.Mungling);
            hard.AddRandomGroup("MungedOne_EN", "Sinker_EN", Spoggle.Yellow);
            hard.AddRandomGroup("MungedOne_EN", "Sinker_EN", "Pinano_EN");
            hard.AddRandomGroup("MungedOne_EN", "Clione_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomGroup("MungedOne_EN", "Sinker_EN", "Jabberwocky_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "MungedOne_EN", "Goa_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "MungedOne_EN", "Minana_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            med.AddRandomGroup("Sinker_EN", "MungedOne_EN", "MudLung_EN");
            med.AddRandomGroup("Sinker_EN", "MungedOne_EN", "Minana_EN", "Minana_EN", "Minana_EN");
            med.AddRandomGroup("Sinker_EN", "MungedOne_EN", "Goa_EN", "Goa_EN", "Goa_EN");
            med.AddRandomGroup("Sinker_EN", "MungedOne_EN", "Dangler_EN", "Dangler_EN", "Dangler_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            med.AddRandomGroup("AFlower_EN", "MungedOne_EN", "MudLung_EN");
            med.AddRandomGroup("AFlower_EN", "MungedOne_EN", "Minana_EN", "Minana_EN", "Minana_EN");
            med.AddRandomGroup("AFlower_EN", "MungedOne_EN", "Goa_EN", "Goa_EN", "Goa_EN");
            med.AddRandomGroup("AFlower_EN", "MungedOne_EN", Spoggle.Yellow);

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "MungedOne_EN", "Goa_EN", "Goa_EN");
            med.AddRandomGroup("Clione_EN", "MungedOne_EN", "Minana_EN", "Minana_EN");
            med.AddRandomGroup("Clione_EN", "MungedOne_EN", "Mung_EN", "Mung_EN");
            med.AddRandomGroup("Clione_EN", "MungedOne_EN", "Mungie_EN", "Mungie_EN", "Mungie_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "MungedOne_EN", "Goa_EN", "Goa_EN", "Goa_EN");
            hard.AddRandomGroup("Clione_EN", "MungedOne_EN", "Minana_EN", "Minana_EN", "Minana_EN");
            hard.AddRandomGroup("Clione_EN", "MungedOne_EN", "Mung_EN", "Mung_EN", "Mung_EN");
            hard.AddRandomGroup("Clione_EN", "MungedOne_EN", "Pinano_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "MungedOne_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomGroup("Tripod_EN", "MungedOne_EN", "Pinano_EN", "Minana_EN");
            hard.AddRandomGroup("Tripod_EN", "MungedOne_EN", "Sinker_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "MungedOne_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "MudLung_EN", "MudLung_EN", "RatThing_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "RatThing_EN");

            med = new AddTo(Shore.H.Wall.Med);
            med.AddRandomGroup("Wall_EN", "Wall_EN", "RatThing_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "RatThing_EN", Jumble.Yellow, Jumble.Red);

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "RatThing_EN", Jumble.Yellow, Jumble.Red);

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, Enemies.Mungling, "MudLung_EN", "RatThing_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "MudLung_EN", "MudLung_EN", "RatThing_EN");
            med.SimpleAddGroup(1, "LittleBeak_EN", 4, "RatThing_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Sinker_EN", "RatThing_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "Pinano_EN", "RatThing_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Enemies.Mungling, "RatThing_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "FlaMinGoa_EN", "RatThing_EN", "RatThing_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "RatThing_EN", "RatThing_EN");

            med = new AddTo(Shore.H.Trumpet.Med);
            med.AddRandomGroup("VoiceTrumpet_EN", "VoiceTrumpet_EN", "RatThing_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.AddRandomGroup("Jabberwocky_EN", "RatThing_EN", Jumble.Yellow);

            med = new AddTo(Shore.H.Papereater.Med);
            med.AddRandomGroup("Papereater_EN", "RatThing_EN", Jumble.Red);

            EcstasyPool.Add("MungedOne_EN");
            EcstasyPool.Add("RatThing_EN");
        }
        public static void _Orph()
        {
            UpdateUngodFollowersGlitch();

            AddTo med = new AddTo(Orph.H.Jumble.Mythos.Med);
            med.SimpleAddGroup(1, Jumble.Mythos, 3, "Enigma_EN");
            med.SimpleAddGroup(1, Jumble.Mythos, 2, "MusicMan_EN", 1, "LostSheep_EN");
            med.SimpleAddGroup(1, Jumble.Mythos, 2, "TheWhale_EN", 1, Enemies.Solvent);
            med.AddRandomGroup(Jumble.Mythos, "Nameless_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Spoggle.Mythos.Med);
            med.SimpleAddGroup(1, Spoggle.Mythos, 3, "Enigma_EN");
            med.SimpleAddGroup(1, Spoggle.Mythos, 2, "MusicMan_EN", 1, "Nameless_EN");
            med.SimpleAddGroup(1, Spoggle.Mythos, 2, "Solitaire_EN", 1, "Sigil_EN");
            med.SimpleAddGroup(1, Spoggle.Mythos, 2, Enemies.Camera, 1, "Wednesday_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "Scrungie_EN", "Scrungie_EN", Spoggle.Mythos);
            med.AddRandomGroup("Sigil_EN", Jumble.Mythos, "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", Spoggle.Mythos, "WindSong_EN");
            med.AddRandomGroup("Evileye_EN", Jumble.Mythos, "Something_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Jumble.Mythos, "Enigma_EN");
            med.AddRandomGroup("Something_EN", Spoggle.Mythos, "Enigma_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Spoggle.Mythos, "MusicMan_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Jumble.Mythos, Enemies.Shooter);

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", Spoggle.Mythos, "MusicMan_EN", "MusicMan_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", Spoggle.Mythos, "LostSheep_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", Jumble.Mythos, "LostSheep_EN");

            med = new AddTo(Orph.H.Nameless.Med);
            med.AddRandomGroup("Nameless_EN", "Nameless_EN", Jumble.Mythos, Enemies.Solvent);

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", Spoggle.Mythos, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Jumble.Mythos, "Rabies_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Jumble.Mythos, Jumble.Mythos);
            hard.AddRandomGroup("Maw_EN", Spoggle.Mythos, Spoggle.Mythos);

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", Spoggle.Mythos, Spoggle.Mythos);
            hard.AddRandomGroup("TheDragon_EN", Jumble.Mythos, "TheWhale_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", Spoggle.Mythos, "Solitaire_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", Jumble.Mythos);

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, Spoggle.Mythos);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, Jumble.Mythos);

            med = new AddTo(Orph.H.Author.Med);
            med.SimpleAddGroup(2, "Author_EN", 1, Jumble.Mythos, 1, "LostSheep_EN");
            med.SimpleAddGroup(2, "Author_EN", 1, Spoggle.Mythos, 1, "Wednesday_EN");

            med = new AddTo(Orph.H.Insider.Med);
            med.AddRandomGroup("Insider_EN", "Insider_EN", Spoggle.Mythos);

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", Jumble.Mythos, "Scrungie_EN");

            med = new AddTo(Orph.H.Whale.Med);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, Jumble.Mythos, 1, "Sigil_EN");
            med.SimpleAddGroup(2, "TheWhale_EN", 1, Spoggle.Mythos, 1, "WindSong_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", Jumble.Mythos, Enemies.Camera);

            med = new AddTo(Orph.H.Melder.Med);
            med.AddRandomGroup("Melder_EN", "Melder_EN", Spoggle.Mythos);

            hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", Jumble.Mythos);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", Spoggle.Mythos);

            EcstasyPool.Add(Jumble.Mythos);
            EcstasyPool.Add(Spoggle.Mythos);
        }
        public static void _Garden()
        {
            AddTo med = new AddTo(Garden.H.Shambler.Med);
            med.AddRandomGroup(Enemies.Shambler, "BlackStar_EN", "Satyr_EN");
            med.AddRandomGroup(Enemies.Shambler, Enemies.Foundling, Jumble.Gray);
            med.SimpleAddGroup(1, Enemies.Shambler, 2, "EyePalm_EN");
            med.AddRandomGroup(Enemies.Shambler, Flower.Blue, "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomGroup(Enemies.Shambler, Bots.Gray, "Merced_EN");
            med.AddRandomGroup(Enemies.Shambler, "Sundowner_EN", "Children6_EN");

            AddTo hard = new AddTo(Garden.H.Shambler.Hard);
            hard.AddRandomGroup(Enemies.Shambler, Spoggle.Gray, "Indicator_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Grandfather_EN", Flower.Red);
            hard.AddRandomGroup(Enemies.Shambler, "WindSong_EN", "Yang_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Celebration_EN", "Insider_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Lunoscope_EN", "Shua_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Stoplight_EN", "GlassFigurine_EN");
            hard.AddRandomGroup(Enemies.Shambler, "OdeToHumanity_EN", "Damocles_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Starless_EN", "YNL_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Eyeless_EN", "EyePalm_EN");
            hard.AddRandomGroup(Enemies.Shambler, "CorpseChan_EN", Enemies.Shivering);
            hard.AddRandomGroup(Enemies.Shambler, Enemies.Eclipse, "LittleAngel_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Hunter_EN", "MiniReaper_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Firebird_EN", Enemies.Foundling);
            hard.AddRandomGroup(Enemies.Shambler, Ecstasy.Gray, "Lightbulbkin_EN");
            hard.AddRandomGroup(Enemies.Shambler, "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Panopticon_EN", "Panopticon_EN");
            hard.AddRandomGroup(Enemies.Shambler, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Complimentary_EN");
            hard.AddRandomGroup(Enemies.Shambler, "PersonalAngel_EN", "Hauntling_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.AddRandomGroup("InTheDark_EN", Enemies.Shambler, Enemies.Shivering);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Shambler, Enemies.Minister);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Shambler);

            //everything else now.
            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Jumble.Mythos, "Ascendant_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Spoggle.Mythos, "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, Spoggle.Mythos, "Grandfather_EN");
            med.AddRandomGroup(Spoggle.Grey, "Ascendant_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Gray, "Ascendant_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Ascendant_EN");
            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Ascendant_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Ascendant_EN", "Ascendant_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", Jumble.Mythos);
            med.AddRandomGroup("MiniReaper_EN", "PawnA_EN", "PawnA_EN", "Ascendant_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Jumble.Mythos);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Spoggle.Mythos);

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Ascendant_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Shua_EN", Jumble.Mythos, "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Ascendant_EN", "Damocles_EN");
            med.AddRandomGroup("Hunter_EN", Spoggle.Mythos, "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", Jumble.Mythos, "Insider_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Ascendant_EN", "Celebration_EN");
            med.AddRandomGroup("YNL_EN", "Ascendant_EN", Flower.Red);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup("Ascendant_EN", Enemies.Tank);
            hard.AddRandomGroup(Enemies.Tank, Jumble.Mythos);

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Spoggle.Mythos);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Jumble.Mythos);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Ascendant_EN", "EggKeeper_EN");
            med.AddRandomGroup("Stoplight_EN", Jumble.Mythos, "WindSong_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Ascendant_EN", "Ascendant_EN", "Children6_EN");
            hard.AddRandomGroup("Stoplight_EN", Spoggle.Grey, Spoggle.Mythos, "Damocles_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Ascendant_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "Ascendant_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", Spoggle.Mythos, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Jumble.Mythos, "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Ascendant_EN");
            med.SimpleAddGroup(3, "EvilDog_EN", 1, Spoggle.Mythos);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, Jumble.Mythos);

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Ascendant_EN");
            med.AddRandomGroup("Complimentary_EN", Spoggle.Mythos);
            med.AddRandomGroup("Complimentary_EN", Jumble.Mythos);

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Ascendant_EN", Spoggle.Mythos);

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Ascendant_EN", "Children6_EN");
            med.AddRandomGroup("Starless_EN", Spoggle.Mythos, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("Starless_EN", Jumble.Mythos, "EyePalm_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Ascendant_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Eyeless_EN", Spoggle.Mythos, Enemies.Minister);
            hard.AddRandomGroup("Eyeless_EN", Jumble.Mythos, Enemies.Minister);

            med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(3, "PawnA_EN", 1, Jumble.Mythos);
            med.SimpleAddGroup(3, "PawnA_EN", 1, Spoggle.Mythos);

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Spoggle.Mythos);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Jumble.Mythos);

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", "Yang_EN", "Ascendant_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Spoggle.Mythos);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Jumble.Mythos);

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Ascendant_EN", Jumble.Mythos);
            med.AddRandomGroup("CorpseChan_EN", "Ascendant_EN", Spoggle.Mythos);

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "Ascendant_EN", "Indicator_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, "Ascendant_EN");
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, Jumble.Mythos);
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, Spoggle.Mythos);

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Ascendant_EN", "GlassFigurine_EN");
            med.AddRandomGroup("Lunoscope_EN", Jumble.Mythos, "Grandfather_EN");
            med.AddRandomGroup("Lunoscope_EN", Spoggle.Mythos, "WindSong_EN");

            hard = new AddTo(Garden.H.Lunoscope.Med);
            hard.AddRandomGroup("Lunoscope_EN", "Ascendant_EN", Enemies.Foundling);

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, Jumble.Mythos);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, Spoggle.Mythos);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, "Ascendant_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(3, Ecstasy.Gray, 1, "Ascendant_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, "Ascendant_EN", Flower.Blue);
            med.AddRandomGroup(Enemies.Eclipse, "Ascendant_EN", Flower.Red);

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Jumble.Mythos);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Spoggle.Mythos);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, "Ascendant_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 1, "Ascendant_EN");

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.SimpleAddGroup(3, "Celebration_EN", 1, "Ascendant_EN");

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "Lightbulbkin_EN", "Ascendant_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "InHerImage_EN", "InHisImage_EN", Spoggle.Mythos);
            med.AddRandomGroup("Lightbulbkin_EN", "InHerImage_EN", "InHisImage_EN", Jumble.Mythos);
            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "InHerImage_EN", "InHisImage_EN", Spoggle.Mythos);
            med.AddRandomGroup("Lightbulbkin_EN", "InHerImage_EN", "InHisImage_EN", Jumble.Mythos);

            EcstasyPool.Add(Enemies.Shambler);
            EcstasyPool.Add("Ascendant_EN");
        }
    }
}
