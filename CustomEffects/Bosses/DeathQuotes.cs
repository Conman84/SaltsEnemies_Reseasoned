using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class DeathQuotes
    {
        public static void Add()
        {
            string[] lines = ["Be cautious, they can still get you when theyre down.", "Avoid getting Ruptured if you can. They'll hit you harder if you're already bleeding."];
            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("Smilers_BOSS", lines);

            string[] lines2 = ["Take your time against this one and use your head.", "Once it starts moving, it won't end up in the same spot again."];
            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("CrowChild_BOSS", lines2);

            string[] lines3 = ["Let's get some fresh air.", "Let's take our time to catch our breaths.", "It's hard to move in water, so only move if you have to."];
            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("BlackAndBlue_BOSS", lines3);

            string[] lines4 = ["The Green Lights will make you deal double damage.", "The Red Lights will try to force you out of them.", "The Blue Lights will randomize your pigment."];
            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("Megalania_BOSS", lines4);

            string[] lines5 = ["Only hit it as many times as you need to.", "Make sure you have some other way to drain pigment."];
            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("Invention_BOSS", lines5);

            string[] lines6 = ["Nowak! Wake up!", "Nowak, is this even real?", "Nowak, are we done yet?", "Nowak, are we dreaming?"];
            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("BlueSky_BOSS", lines6);
        }
    }
}
