using BrutalAPI;
using UnityEngine;

//finish the SaltPassivesCamera.Setup(). you need to do this because I dont have the passive ids for the salt enemies

namespace SaltEnemies_Reseasoned
{
    public static class SaltPassivesCamera
    {
        public static void Setup()
        {
            CameraEffects.AddPassive("FreakOut_PA");
            CameraEffects.AddPassive("Jumpy_PA");
            CameraEffects.AddPassive("Lightweight_PA");
            CameraEffects.AddPassive("DontTouchMe_PA");
            CameraEffects.AddPassive("Revenge_PA");
            CameraEffects.AddPassive("Coda_PA");
            CameraEffects.AddPassive(ClockTowerManager.Acceleration);
            CameraEffects.AddPassive("MissFaced_PA");
            CameraEffects.AddPassive("Unmasking_PA");
            //Add Every single passive ID you've made for all salt enemies thus far. and also do this in the future too. unless it shares a passiveID with a base game passive. or if its like a unique passive to the enemy or something. or a bonus attack
            //Specifically:
            /*
            Lightweight DONE
            Dont Touch Me DONE
            Revenge DONE
            Splatter DONE
            Overgrowth DONE
            Survival Instinct DONE
            Cowardice
            Coda DONE
            Cold Blooded DONE
            Warning DONE
            Acceleration DONE
            Heavily Armored
            Algophobia
            Unbreakable
            Enruptured
            Disabled
            Evasive
            Well Preserved
            Ethereal
            Unmasking DONE
            Asphyxiation DONE
            Salinity DONE
            Locked In DONE
            Incomprehensible
            Hunter
            Rejuvination
            Burning
            Nervous
            Repression
            Lazy
            Miss-Faced DONE
            Turbulent
            Compulsory
            Bad Dog
            Waves
            Whimsy
            Pillar
            Hemochromia
            Sweet Tooth
            Fluttery
            Warping
            Jittery
            Punisher
            Divisible
            Lonely
            */
        }
    }
    public static class ModCamera
    {
        public static void Setup()
        {
            CameraEffects.AddPassive("Pyrophilia");
            CameraEffects.AddPassive("Marmo_Exchange_PA");
            CameraEffects.AddPassive("Impetus");
            CameraEffects.AddPassive("Bloodlust");
            CameraEffects.AddPassive("Marmo_InvisibleBystander_PA");
            CameraEffects.AddPassive("Marmo_Docile_PA");
            CameraEffects.AddPassive("Marmo_Chaotic_PA");
            CameraEffects.AddPassive("TwoFaced_Nuzzles_PA");
            CameraEffects.AddPassive("Nuzzles_Kidcore_5_PA");
            CameraEffects.AddPassive("Marmo_Grating_3_PA");
            CameraEffects.AddPassive("Marmo_Everchanging_PA");
            CameraEffects.AddPassive("Clueless_TornApart");
            CameraEffects.AddPassive("Volatile");
            CameraEffects.AddPassive("Metallurgy");
            CameraEffects.AddPassive("Humorous");
            CameraEffects.AddPassive("Connoisseur", enemyDesc: "This enemy deals 1/3 extra damage for each status effect on on the target.");
            CameraEffects.AddPassive("Sweeping");
            CameraEffects.AddPassive("Interpolated");
            CameraEffects.AddPassive("Grinding");
            CameraEffects.AddPassive("Billiard");
            CameraEffects.AddPassive("Mirage");
            CameraEffects.AddPassive("Conviction");
            CameraEffects.AddPassive("Clueless_Tempered");
            CameraEffects.AddPassive("Classic_PA");
            CameraEffects.AddPassive("YordanPureImmolation");
            CameraEffects.AddPassive("YordanFirestorm");
            CameraEffects.AddPassive("CaigSlugstonPassiveID");
            CameraEffects.AddPassive("CombustiblePassiveID");
            CameraEffects.AddPassive("DovPassiveID", enemyDesc: "Upon taking direct damage, increase this enemy's Concussion by 1-2.");
            CameraEffects.AddPassive("CowardlyPassiveID");
            CameraEffects.AddPassive("ponaPassiveAID");
            CameraEffects.AddPassive("AdamMultiattackID", Passives.MultiAttackGenerator(2));
            CameraEffects.AddPassive("Showstopper_ID");
            CameraEffects.AddPassive("Apoptosis_PA");
            CameraEffects.AddPassive("FakeFocus_PA");
            CameraEffects.AddPassive("PartyInfantile", Passives.Infantile);
            CameraEffects.AddPassive(PartyParental);
            CameraEffects.AddPassive("CleansingMucus_PA");
            CameraEffects.AddPassive("ThickSkin_PA");
            CameraEffects.AddPassive("Crystallize");
            CameraEffects.AddPassive(Intimidating);
            CameraEffects.AddPassive("Chaos", enemyDesc: "At the end of the turn, perform a random effect for each Chaos level this enemy has.");
        }
        public static void PartyParental(CameraEffects.PassiveHolder passives, CharacterCombat chara, EnemyCombat enemy)
        {
            if (passives.ContainsPassiveAbility("PartyParental"))
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.5f) enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1]);
                else enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").passiveAbilities[0]);
            }
        }
        public static void Intimidating(CameraEffects.PassiveHolder passives, CharacterCombat chara, EnemyCombat enemy)
        {
            if (passives.ContainsPassiveAbility("Intimidating", out BasePassiveAbilitySO passive))
            {
                BasePassiveAbilitySO add = ScriptableObject.Instantiate(passive);
                add._enemyDescription = "When performing an action or moving there's a 5% chance to inflict 1 Stunned on the Opposing Party Member.";
                (add as PerformEffectPassiveAbility).effects[0].effect = ScriptableObject.CreateInstance<ApplyStunnedEffect>();
            }
        }
    }
}
