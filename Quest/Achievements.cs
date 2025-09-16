using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Achievements
    {
        public static void AddBosses()
        {
            UnlockableModData deadgod = new UnlockableModData("DeadGod");
            deadgod.hasModdedAchievementUnlock = true;
            deadgod.moddedAchievementID = AchievementIDs.DeadGod;
            deadgod.hasItemUnlock = true;
            deadgod.items = ["Salt_ItsWings_TW"];
            ModdedAchievements deadgodach = new ModdedAchievements("No One Cares", "Extinguish the Embers of a Dead God.", ResourceLoader.LoadSprite("DGAch.png"), AchievementIDs.DeadGod);
            deadgodach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);
            EnemyDeathUnlockCheck deadgodkill = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            deadgodkill.enemyID = "EmbersofaDeadGod_EN";
            deadgodkill.usesSimpleDeathData = true;
            deadgodkill.simpleDeathData = deadgod;
            Unlocks.AddUnlock_EnemyDeath(deadgodkill);

            UnlockableModData shiny = new UnlockableModData("Shiny");
            shiny.hasModdedAchievementUnlock = true;
            shiny.moddedAchievementID = AchievementIDs.Shiny;
            shiny.hasItemUnlock = true;
            shiny.items = ["Salt_ChocolateCoin_TW"];
            ModdedAchievements shinyach = new ModdedAchievements("Wealthy Surprise", "Hunt the Coin Hunter.", ResourceLoader.LoadSprite("CoinAch.png"), AchievementIDs.Shiny);
            shinyach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);
            EnemyDeathUnlockCheck shinykill = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            shinykill.enemyID = "CoinHunter_EN";
            shinykill.usesSimpleDeathData = true;
            shinykill.simpleDeathData = shiny;
            Unlocks.AddUnlock_EnemyDeath(shinykill);

            UnlockableModData deep = new UnlockableModData("Deep");
            deep.hasModdedAchievementUnlock = true;
            deep.moddedAchievementID = AchievementIDs.Deep;
            deep.hasItemUnlock = true;
            deep.items = ["Salt_DeepWater_TW"];
            ModdedAchievements deepach = new ModdedAchievements("Drink The Ocean", "Submerge The Deep.", ResourceLoader.LoadSprite("DeepAch.png"), AchievementIDs.Deep);
            deepach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);
            EnemyDeathUnlockCheck deepkill = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            deepkill.enemyID = "TheDeep_EN";
            deepkill.usesSimpleDeathData = true;
            deepkill.simpleDeathData = deep;
            Unlocks.AddUnlock_EnemyDeath(deepkill);

            UnlockableModData postmodern = new UnlockableModData("Postmodern");
            postmodern.hasModdedAchievementUnlock = true;
            postmodern.moddedAchievementID = AchievementIDs.Postmodern;
            postmodern.hasItemUnlock = true;
            postmodern.items = ["Salt_NineKey_TW"];
            ModdedAchievements postach = new ModdedAchievements("2000", "Undo Postmodern.", ResourceLoader.LoadSprite("PMAch.png"), AchievementIDs.Postmodern);
            postach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);
            EnemyDeathUnlockCheck postkill = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            postkill.enemyID = "Postmodern_EN";
            postkill.usesSimpleDeathData = true;
            postkill.simpleDeathData = postmodern;
            Unlocks.AddUnlock_EnemyDeath(postkill);

            UnlockableModData snake = new UnlockableModData("SnakeGod");
            snake.hasModdedAchievementUnlock = true;
            snake.moddedAchievementID = AchievementIDs.SnakeGod;
            snake.hasItemUnlock = true;
            snake.items = ["Salt_CardboardSign_SW"];
            ModdedAchievements snakeach = new ModdedAchievements("Not Scary", "Chase away Kyotlokutla.", ResourceLoader.LoadSprite("SnakeAch.png"), AchievementIDs.SnakeGod);
            snakeach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);
            EnemyDeathUnlockCheck snakekill = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            snakekill.enemyID = "SnakeGod_EN";
            snakekill.usesSimpleDeathData = true;
            snakekill.simpleDeathData = snake;
            Unlocks.AddUnlock_EnemyDeath(snakekill);

            UnlockableModData miriam = new UnlockableModData("Miriam");
            miriam.hasModdedAchievementUnlock = true;
            miriam.moddedAchievementID = AchievementIDs.Miriam;
            miriam.hasItemUnlock = true;
            miriam.items = ["Salt_Echo_TW"];
            ModdedAchievements miriamach = new ModdedAchievements("Miriam Achievement", "Kill Miriam.", ResourceLoader.LoadSprite("MiriamAch.png"), AchievementIDs.Miriam);
            miriamach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);
            EnemyDeathUnlockCheck miriamkill = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            miriamkill.enemyID = "Miriam_EN";
            miriamkill.usesSimpleDeathData = true;
            miriamkill.simpleDeathData = miriam;
            Unlocks.AddUnlock_EnemyDeath(miriamkill);

            UnlockableModData smiler = new UnlockableModData("Smiler");
            smiler.hasModdedAchievementUnlock = true;
            smiler.moddedAchievementID = AchievementIDs.Smilers;
            smiler.hasItemUnlock = true;
            smiler.items = ["Salt_SmilerMask_TW"];
            ModdedAchievements smilerach = new ModdedAchievements("Smiler Achievement", "Murder the Smilers.", ResourceLoader.LoadSprite("SmilerAch.png"), AchievementIDs.Smilers);
            smilerach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);
            ListedUnlockCheck smilerkill = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            smilerkill.unlockID = "Smilers_BOSS";
            smilerkill.unlockData = smiler;
            Unlocks.AddUnlock_BeatBoss(smilerkill);

            UnlockableModData crow = new UnlockableModData("CrowChild");
            crow.hasModdedAchievementUnlock = true;
            crow.moddedAchievementID = AchievementIDs.Crow;
            crow.hasItemUnlock = true;
            crow.items = ["Salt_Grudge_TW"];
            ModdedAchievements crowach = new ModdedAchievements("Crow Child Achievement", "Murder the Crow Child.", ResourceLoader.LoadSprite("CrowAch.png"), AchievementIDs.Crow);
            crowach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);
            ListedUnlockCheck crowkill = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            crowkill.unlockID = "CrowChild_BOSS";
            crowkill.unlockData = crow;
            Unlocks.AddUnlock_BeatBoss(crowkill);

            UnlockableModData black = new UnlockableModData("BlackAndBlue");
            black.hasModdedAchievementUnlock = true;
            black.moddedAchievementID = AchievementIDs.Black;
            black.hasItemUnlock = true;
            black.items = ["Salt_Bodybag_TW"];
            ModdedAchievements blackach = new ModdedAchievements("Black And Blue Achievement", "Murder Black And Blue.", ResourceLoader.LoadSprite("BBAch.png"), AchievementIDs.Black);
            blackach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);
            ListedUnlockCheck blackkill = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            blackkill.unlockID = "BlackAndBlue_BOSS";
            blackkill.unlockData = black;
            Unlocks.AddUnlock_BeatBoss(blackkill);

            UnlockableModData tv = new UnlockableModData("Megalania");
            tv.hasModdedAchievementUnlock = true;
            tv.moddedAchievementID = AchievementIDs.Tv;
            tv.hasItemUnlock = true;
            tv.items = ["Salt_RGB_TW"];
            ModdedAchievements tvach = new ModdedAchievements("MEGALANIA Achievement", "Slay MEGALANIA.", ResourceLoader.LoadSprite("TvAch.png"), AchievementIDs.Tv);
            tvach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);
            ListedUnlockCheck tvkill = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            tvkill.unlockID = "Megalania_BOSS";
            tvkill.unlockData = tv;
            Unlocks.AddUnlock_BeatBoss(tvkill);

            UnlockableModData invention = new UnlockableModData("Invention");
            invention.hasModdedAchievementUnlock = true;
            invention.moddedAchievementID = AchievementIDs.Invention;
            invention.hasItemUnlock = true;
            invention.items = ["Salt_GlassDiamond_TW"];
            ModdedAchievements inventionach = new ModdedAchievements("Invention Achievement", "Slay the Invention.", ResourceLoader.LoadSprite("InventionAch.png"), AchievementIDs.Invention);
            inventionach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);
            ListedUnlockCheck inventkill = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            inventkill.unlockID = "Invention_BOSS";
            inventkill.unlockData = invention;
            Unlocks.AddUnlock_BeatBoss(inventkill);

            UnlockableModData blue = new UnlockableModData("BlueSkies");
            blue.hasModdedAchievementUnlock = true;
            blue.moddedAchievementID = AchievementIDs.Blue;
            blue.hasItemUnlock = true;
            blue.items = ["Salt_RedDream_TW"];
            ModdedAchievements blueach = new ModdedAchievements("The Dreamer", "Awaken Blue Skies.", ResourceLoader.LoadSprite("BSAch.png"), AchievementIDs.Blue);
            blueach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);
            ListedUnlockCheck bluekill = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            bluekill.unlockID = "BlueSky_BOSS";
            bluekill.unlockData = blue;
            Unlocks.AddUnlock_BeatBoss(bluekill);





        }
        public static void AddChapters()
        {
            AddSaltEnemiesQuest(AchievementIDs.Chapter1, "Salt_PomPoms_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter2, "Salt_SilverBullet_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter3, "Salt_Dues_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter4, "Salt_CheatingMaterials_TW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter6, "Salt_UnknownFossil_TW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter7, "Salt_TinCan_EW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter8, "Salt_FeedingFrenzy_TW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter9, "Salt_SpareEar_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter10, "Salt_Torturepedia_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter11, "Salt_LittleBell_TW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter12, "Salt_FeatherGun_TW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter13, "Salt_StageFright_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter14, "Salt_Coelacanth_EW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter15, "Salt_HormoneGasses_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter16, "Salt_GlowingHat_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter17, "Salt_Strepnut_SW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter18, "Salt_Angel_TW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter19, "Salt_ImperfectLullaby_TW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter20, "Salt_KarmicOffloading_TW");
            AddSaltEnemiesQuest(AchievementIDs.Chapter21, "Salt_GlueEye_SW");
            AddSaltEnemiesQuest(AchievementIDs.ChapterBoss, "Salt_Knife_SW");
            AddSaltEnemiesQuest(AchievementIDs.HelpMe, "AbandonedArtifact_TW");
        }

        public static void AddSaltEnemiesQuest(string name, string item)
        {
            UnlockableModData data = new UnlockableModData(name);
            data.hasModdedAchievementUnlock = true;
            data.moddedAchievementID = name;
            data.hasItemUnlock = true;
            data.items = [item];
            ModdedAchievements ach = new ModdedAchievements(name, "Progress Defacer's Quest", null, name);
            ach.AddHiddenAchievement();
            Unlocks.AddUnlock_ByID(data);
        }
    }
}
