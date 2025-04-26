using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{

    public static class CustomVisuals
    {
        public static Dictionary<string, AttackVisualsSO> Visuals;
        public static void Prepare()
        {
            Visuals = new Dictionary<string, AttackVisualsSO>();
        }
        public static void LoadVisuals(string name, AssetBundle bundle, string path, string sound, bool full = false)
        {
            try
            {
                AttackVisualsSO ret = ScriptableObject.CreateInstance<AttackVisualsSO>();
                ret.name = name;
                ret.animation = bundle.LoadAsset<AnimationClip>(path);
                ret.audioReference = sound;
                ret.isAnimationFullScreen = full;
                if (Visuals == null) Prepare();
                if (!Visuals.ContainsKey(name)) Visuals.Add(name, ret);
                else Debug.LogWarning("animation for " + name + " already exists!");
            }
            catch (Exception ex)
            {
                Debug.LogError("visuals failed to load: " + name);
                Debug.LogError("asset path: " + path);
                Debug.LogError("audio path: " + sound);
                Debug.LogError(ex.ToString());
            }
        }
        public static AttackVisualsSO GetVisuals(string name)
        {
            if (Visuals == null) Prepare();
            if (Visuals.TryGetValue(name, out AttackVisualsSO ret)) return ret;
            else Debug.LogWarning("missing animation for " + name);
            return null;
        }
        public static void Duplicate(string newname, string oldname, string audio)
        {
            try
            {
                AttackVisualsSO old = GetVisuals(oldname);
                if (old == null) return;
                AttackVisualsSO ret = ScriptableObject.CreateInstance<AttackVisualsSO>();
                ret.name = newname;
                ret.animation = old.animation;
                ret.audioReference = audio;
                ret.isAnimationFullScreen = old.isAnimationFullScreen;
                if (Visuals == null) Prepare();
                if (!Visuals.ContainsKey(newname)) Visuals.Add(newname, ret);
                else Debug.LogWarning("animation for " + newname + " already exists!");
            }
            catch
            {
                Debug.LogError("visuals failed to load: " + newname);
                Debug.LogError("failed to copy off: " + oldname);
            }
        }

        public static void Setup()
        {
            LoadVisuals("Salt/Static", SaltsReseasoned.saltsAssetBundle, "assets/pretty/StaticAnim.anim", "event:/Hawthorne/Attack/Static", true);
            LoadVisuals("Salt/Rose", SaltsReseasoned.saltsAssetBundle, "assets/pretty/FlowerAttackAnim.anim", "event:/Hawthorne/Attack/FlowerBell");
            LoadVisuals("Salt/Sprout", SaltsReseasoned.saltsAssetBundle, "assets/pretty/FlowerBoneBreak.anim", "event:/Hawthorne/Attack/FlowerBone");
            LoadVisuals("Salt/Cannon", SaltsReseasoned.saltsAssetBundle, "assets/pretty/CannonAnim.anim", "event:/Hawthorne/Attack/Cannon");
            LoadVisuals("Salt/Gaze", SaltsReseasoned.saltsAssetBundle, "assets/pretty/EyeScare.anim", "event:/Hawthorne/Attack/EyeScare");
            LoadVisuals("Salt/Decapitate", SaltsReseasoned.saltsAssetBundle, "assets/pretty/CutAnim.anim", "event:/Hawthorne/Attack/Decapitate");
            LoadVisuals("Salt/Class", SaltsReseasoned.saltsAssetBundle, "assets/pretty/ClassAnim.anim", "event:/Hawthorne/Attack/Class");
            LoadVisuals("Salt/Needle", SaltsReseasoned.saltsAssetBundle, "assets/pretty/NeedleAnim.anim", "event:/Hawthorne/Attack/Needle");
            LoadVisuals("Salt/Claws", SaltsReseasoned.saltsAssetBundle, "assets/pretty/ClawingAnim.anim", "event:/Hawthorne/Attack/Clawing");
            LoadVisuals("Salt/Stars", SaltsReseasoned.saltsAssetBundle, "assets/pretty/StarryAnim.anim", "event:/Hawthorne/Attack/PointGet");
            Duplicate("Salt/Skyloft/Stars", "Salt/Stars", "event:/Hawthorne/Hurt/BirdSound");
            LoadVisuals("Salt/Hung", SaltsReseasoned.saltsAssetBundle, "assets/pretty/HUNG.anim", "event:/Hawthorne/Attack/Noosed");
            LoadVisuals("Salt/Crush", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/PressAnim.anim", "event:/Hawthorne/Attack2/Press");
            LoadVisuals("Salt/Ads", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/Ads.anim", "event:/Hawthorne/Attack2/Popup");
            LoadVisuals("Salt/Door", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/DoorAnim.anim", "event:/Hawthorne/Attack2/DoorSlam");
            LoadVisuals("Salt/Keyhole", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/KeyholeAnim.anim", "event:/Hawthorne/Attack2/Blink");
            LoadVisuals("Salt/Notif", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/AlertAnim.anim", "event:/Hawthorne/Attack2/Quest");
            LoadVisuals("Salt/Wheel", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/Sail.anim", "event:/Hawthorne/Attack2/Wheel");
            LoadVisuals("Salt/Swirl", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/Waves1Anim.anim", "event:/Hawthorne/Attack2/Waves1");
            LoadVisuals("Salt/Pop", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/Waves2Anim.anim", "event:/Hawthorne/Attack2/Waves2");
            LoadVisuals("Salt/Smile", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/SmileScare.anim", "event:/Hawthorne/Attack2/Smiley");
            LoadVisuals("Salt/Fog", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/FoggyLens.anim", "event:/Hawthorne/Attack2/Fog", true);
            LoadVisuals("Salt/Ash", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/AshAnim.anim", "event:/Hawthorne/Attack2/Ash");
            LoadVisuals("Salt/Four", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/FourAnim.anim", "event:/Hawthorne/Attack2/Four");
            LoadVisuals("Salt/Ribbon", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/Ribbon.anim", "event:/Hawthorne/Attack2/Ribbon");
            LoadVisuals("Salt/Bullet", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/BulletsAnim.anim", "event:/Hawthorne/Attack2/Gun");
            LoadVisuals("Salt/Shatter", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/ShatterAnim.anim", "event:/Hawthorne/Attack2/Shatter");
            LoadVisuals("Salt/Insta/Shatter", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/ImmediateShatter.anim", "event:/Hawthorne/Attack2/Shatter");
            LoadVisuals("Salt/Zap", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/Electric.anim", "event:/Hawthorne/Attack2/Zap");
            LoadVisuals("Salt/Alarm", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/ClockAnim.anim", "event:/Hawthorne/Attack2/WakeUp");
            LoadVisuals("Salt/Piano", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/HammerKeys.anim", "event:/Hawthorne/Attack2/Piano");
            LoadVisuals("Salt/Think", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/IdeaAnim.anim", "event:/Hawthorne/Attack2/Thought");
            LoadVisuals("Salt/Whisper", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/Speak.anim", "event:/Hawthorne/Attack2/Whisper");
            LoadVisuals("Salt/Cube", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/CubeAnim.anim", "event:/Hawthorne/Attack2/Construct");
            LoadVisuals("Salt/Snap", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/SnapRose.anim", "event:/Hawthorne/Attack2/Snaps");
            LoadVisuals("Salt/Rain", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/RainingAnim.anim", "event:/Hawthorne/Attack2/Rainy");
            LoadVisuals("Salt/Coda", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/CodaAnim.anim", "event:/Hawthorne/Attack2/Coda");
            LoadVisuals("Salt/Forest", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/TheForest.anim", "event:/Hawthorne/Attack2/Forest", true);
            LoadVisuals("Salt/Shush", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/ShushAnim.anim", "event:/Hawthorne/Attack2/Shush");
            LoadVisuals("Salt/Lens", SaltsReseasoned.saltsAssetBundle, "assets/Attack2/Picture.anim", "event:/Hawthorne/Attack2/Shutter");
            LoadVisuals("Salt/Train", SaltsReseasoned.saltsAssetBundle, "assets/train/HitAndRun.anim", "event:/Hawthorne/Attack3/FUCKINGTRAIN");
            LoadVisuals("Salt/Censor", SaltsReseasoned.saltsAssetBundle, "assets/Attack3/CensoredAnimation.anim", "event:/Hawthorne/Attack3/Censored");
            LoadVisuals("Salt/Unlock", SaltsReseasoned.saltsAssetBundle, "assets/Attack3/UnlockAnim.anim", "event:/Hawthorne/Attack3/Unlocking");
            LoadVisuals("Salt/Spotlight", SaltsReseasoned.saltsAssetBundle, "assets/Attack3/SpotlightAnim.anim", "event:/Hawthorne/Attack3/Spotlight");
            LoadVisuals("Salt/Scorch", SaltsReseasoned.saltsAssetBundle, "assets/16/ScorchAnim.anim", "event:/Hawthorne/Attack3/Scorch");
            
            LoadVisuals("Salt/Curse", SaltsReseasoned.Meow, "assets/ani/thecurse.anim", LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals.audioReference);
            LoadVisuals("Salt/Nailing", SaltsReseasoned.Meow, "Assets/ani/Nailing.anim", "event:/Hawthorne/Attack3/Nailing");

            LoadVisuals("Salt/Stop", SaltsReseasoned.saltsAssetBundle, "Assets/train/NewTrain/StopSignAnim.anim", "event:/Hawthorne/Attack3/Stop");
            LoadVisuals("Salt/Sign", SaltsReseasoned.saltsAssetBundle, "Assets/train/NewTrain/SignSlamAnim.anim", "event:/Hawthorne/Attack3/Sign");
        }
    }
}
