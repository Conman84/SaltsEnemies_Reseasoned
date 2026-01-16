using BrutalAPI;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace SaltsEnemies_Reseasoned
{
    public static class Help
    {
        public static DamageInfo GenerateDamageInfo(int exit, int entry, bool killed)
        {
            DamageInfo ret = new DamageInfo();
            ret.damageAmount = exit;
            ret.beenKilled = killed;

            if (typeof(DamageInfo).GetField("attemptedDamageAmount") != null)
            {
                typeof(DamageInfo).GetField("attemptedDamageAmount").SetValue(ret, entry);

                if (SaltsReseasoned.DebugVer) Debug.Log("exists attempteddamageamount in damageinfo");
            }

            return ret;
        }

        public static IntegerReference GenerateDamageIntReference(int amount, string damageTypeID, bool directDamage, bool ignoreShield, int affectedStartSlot, int affectedEndSlot, IUnit possibleSourceUnit, IUnit damagedUnit)
        {
            if (typeof(IntegerReference).Assembly.GetType("IntegerReference_Damage", false) != null)
            {
                object ret = typeof(IntegerReference).Assembly.GetType("IntegerReference_Damage").GetConstructor([typeof(int), typeof(string), typeof(bool), typeof(bool), typeof(int), typeof(int), typeof(IUnit), typeof(IUnit)]).Invoke([amount, damageTypeID, directDamage, ignoreShield, affectedStartSlot, affectedEndSlot, possibleSourceUnit, damagedUnit]);

                if (SaltsReseasoned.DebugVer) Debug.Log("exists integerreference_damage");

                return ret as IntegerReference;
            }

            return new IntegerReference(amount);
        }

        public static DamageReceivedValueChangeException GenerateDamageTakenException(int amount, string damageTypeID, string deathTypeID, bool directDamage, bool ignoreShield, int affectedStartSlot, int affectedEndSlot, IUnit possibleSourceUnit, IUnit damagedUnit)
        {
            ConstructorInfo[] constructors = typeof(DamageReceivedValueChangeException).GetConstructors();

            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.GetParameters().Length == 9)
                {
                    return constructor.Invoke([amount, damageTypeID, deathTypeID, directDamage, ignoreShield, affectedStartSlot, affectedEndSlot, possibleSourceUnit, damagedUnit]) as DamageReceivedValueChangeException;
                }
                if (constructor.GetParameters().Length == 8)
                {
                    return constructor.Invoke([amount, damageTypeID, directDamage, ignoreShield, affectedStartSlot, affectedEndSlot, possibleSourceUnit, damagedUnit]) as DamageReceivedValueChangeException;
                }
            }
            Debug.LogError("versioncompatability:damagereceivedexception. tldr, WHAT THE FUCK");
            return null;
        }

        public static void AnyAbilityHasFinished(IUnit unit, int caster, bool isChara, AbilitySO ability)
        {
            if (unit is CharacterCombat chara)
            {
                MethodInfo method = typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.AnyAbilityHasFinished));
                if (method.GetParameters().Length == 0)
                    method.Invoke(unit, []);
                else if (method.GetParameters().Length == 1)
                {
                    try
                    {
                        _subHelper_AnyAbilityHasFinished(unit, caster, isChara, ability);
                    }
                    catch
                    {
                        Debug.LogWarning("idk");
                    }
                }
            }
            if (unit is EnemyCombat enemy)
            {
                MethodInfo method = typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.AnyAbilityHasFinished));
                if (method.GetParameters().Length == 0)
                    method.Invoke(unit, []);
                else if (method.GetParameters().Length == 1)
                {
                    try
                    {
                        _subHelper_AnyAbilityHasFinished(unit, caster, isChara, ability);
                    }
                    catch
                    {
                        Debug.LogWarning("idk");
                    }
                }
            }
        }

        public static void _subHelper_AnyAbilityHasFinished(IUnit unit, int caster, bool isChara, AbilitySO ability)
        {
            if (unit is CharacterCombat chara)
            {
                chara.AnyAbilityHasFinished(new AbilityUsageReference(caster, isChara, ability));
            }
            if (unit is EnemyCombat enemy)
            {
                enemy.AnyAbilityHasFinished(new AbilityUsageReference(caster, isChara, ability));
            }
        }
        
        public static bool GenericDirectDeath(this IUnit self, IUnit killer, bool obliteration = false)
        {
            MethodInfo method = typeof(IUnit).GetMethod(nameof(IUnit.DirectDeath));
            if (method.GetParameters().Length == 2)
                return (bool)method.Invoke(self, [killer, obliteration]);
            else
            {
                try
                {
                    return _subHelper_DirectDeath(self, killer, obliteration);
                }
                catch
                {
                    Debug.LogWarning("idk");
                }
            }
            return false;
        }
        public static bool _subHelper_DirectDeath(IUnit target, IUnit killer, bool obliteration)
        {
            return target.DirectDeath(killer, obliteration, out int num);
        }


        public class CompatibleEndAbilityAction : CombatAction
        {
            public int _unitID;

            public bool _isUnitCharacter;

            public AbilitySO _ability;

            public CompatibleEndAbilityAction(int unitID, bool isUnitCharacter, AbilitySO ability)
            {
                _unitID = unitID;
                _isUnitCharacter = isUnitCharacter;
                _ability = ability;
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                if (_isUnitCharacter)
                {
                    CharacterCombat characterCombat = stats.TryGetCharacterOnField(_unitID);
                    if (characterCombat != null)
                    {
                        if (characterCombat.IsAlive)
                        {
                            characterCombat.AbilityHasFinished();
                        }

                        characterCombat.FinalizeAbilityActions();
                    }
                }
                else
                {
                    EnemyCombat enemyCombat = stats.TryGetEnemyOnField(_unitID);
                    if (enemyCombat != null && enemyCombat.IsAlive)
                    {
                        enemyCombat.AbilityHasFinished();
                    }
                    else
                    {
                        CombatManager.Instance.AddRootAction(new NextTurnAction());
                    }
                }

                foreach (CharacterCombat value in stats.CharactersOnField.Values)
                {
                    Help.AnyAbilityHasFinished(value, _unitID, _isUnitCharacter, _ability);
                }

                foreach (EnemyCombat value2 in stats.EnemiesOnField.Values)
                {
                    Help.AnyAbilityHasFinished(value2, _unitID, _isUnitCharacter, _ability);
                }

                yield return null;
            }
        }
    }

    public static class DataManager
    {
        public static string[] Start = ["LostSheep_EN", "Enigma_EN", "DeadPixel_EN", "LittleAngel_EN", "EmbersofaDeadGod_EN"];
        public static string[] Beginner = ["TeachaMantoFish_EN", "Satyr_EN", "Something_EN", "Derogatory_EN", "TheCrow_EN", "Freud_EN", "AFlower_EN", "StarGazer_EN", Enemies.Camera];
        public static string[] Easy = ["Delusion_EN", "FakeAngel_EN", Bots.Red, Bots.Yellow, "Sigil_EN", "WindSong_EN", Enemies.Solvent, "LittleBeak_EN", "Pinano_EN", "Minana_EN", "Evileye_EN", Ecstasy.Red, Ecstasy.Blue, Ecstasy.Yellow, Ecstasy.Purple];
        public static string[] EM = [Flower.Yellow, Flower.Purple, "EyePalm_EN", "BlackStar_EN", "Singularity_EN", "Skyloft_EN", "ToyUfo_EN", "Wall_EN", "Smilers_BOSS"];
        public static string[] Med = [Jumble.Grey, "Grandfather_EN", Flower.Red, Flower.Blue, Bots.Blue, Bots.Purple, "Rabies_EN", "NobodyGrave_EN", "YellowAngel_EN", "Windle_EN", "MiniReaper_EN", "Megalania_BOSS"];
        public static string[] MH = [Spoggle.Grey, "CoinHunter_EN", "TheDeep_EN", "SnakeGod_EN", "Spectre_EN", Bots.Grey, "Tripod_EN", "Maw_EN", "Arceles_EN", "Clione_EN", "Sinker_EN", "VoiceTrumpet_EN", "Waltz_EN", "Foxtrot_EN", "PawnA_EN", "CrowChild_BOSS"];
        public static string[] Hard = [Flower.Grey, "StalwartTortoise_EN", "Merced_EN", "Shua_EN", Enemies.Shooter, "2009_EN", "Crystal_EN", "TortureMeNot_EN", "CandyStone_EN", "Invention_BOSS"];
        public static string[] Harder = ["Chiito_EN", "Complimentary_EN", "Wednesday_EN", "Hunter_EN", "Warbird_EN", "Indicator_EN", "GlassedSun_EN", "Stoplight_EN", "Clown_EN", "BlackAndBlue_BOSS"];
        public static string[] Hardest = ["Postmodern_EN", "War_EN", "ClockTower_EN", Enemies.Tank, "Miriam_EN", "33_EN", "Author_EN", "Monster_EN", "Starless_EN", "Yang_EN", "Cruelties1_EN", "YNL_EN", "Firebird_EN"];
        public static string[] Expert = ["Damocles_EN", "GlassFigurine_EN", "Nameless_EN", "Children6_EN", "TheDragon_EN", "OdeToHumanity_EN", "EvilDog_EN", "PersonalAngel_EN", "Yin_EN", "Eyeless_EN", "Solitaire_EN", "Spades_EN", "WolfColony_EN", "WolfLarvae_EN", "Stalker2_EN", "ReverseFalseHydra_EN"];
        public static string[] Hidden = ["Hauntling_EN", "Insider_EN", "Jabberwocky_EN", "Nume_EN", "Papereater_EN", "TheWhale_EN"];
        public static string[] Secret = ["CorpseChan_EN", "Untitled_EN", "InTheDark_EN", "Sundowner_EN", "Lunoscope_EN", "Panopticon_EN"];


        public static string[] VersionCompatability = [Orph.H.Insider.Med, Garden.H.Insider.Med, Shore.H.Jabber.Med, Orph.H.Nume.Med, Shore.H.Papereater.Easy, Shore.H.Papereater.Med, Orph.H.Whale.Med];
        public static string[] Insiders = [Shore.H.Hauntling.Med, Garden.H.Hauntling.Easy, Garden.H.CorpseChan.Med, Orph.H.Untitled.Hard, Garden.H.Dark.Med, Garden.H.Dark.Hard, Garden.H.Sundowner.Med, Garden.H.Lunoscope.Med, Garden.H.Lunoscope.Hard, Garden.H.Panopticon.Med];
    }
}
