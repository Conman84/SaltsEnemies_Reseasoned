using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Yarn.Compiler;

namespace SaltsEnemies_Reseasoned
{
    public static class Defacer
    {
        public static YarnProgram Yarn;
        public static void Add()
        {
            Yarn = SaltsReseasoned.Meow.LoadAsset<YarnProgram>("Assets/Defacer/Defacer.yarn");

            SpeakerBundle speaker = new SpeakerBundle();
            speaker.bundleTextColor = new Color32(241, 235, 232, 255);
            speaker.dialogueSound = LoadedAssetsHandler.GetEnemy("SnakeGod_EN").damageSound;
            speaker.portrait = ResourceLoader.LoadSprite("DefacerFront.png");

            Dialogues.CreateAndAddCustom_SpeakerData("Defacer_SpeakerData", speaker, true, false, []);

            Dialogues.CreateAndAddCustom_DialogueSO("Salt.Defacer.Quest", Yarn, "Salt.Defacer", "Salt.Defacer.Quest");
            Dialogues.CreateAndAddCustom_DialogueSO("Salt.Defacer.Garden", Yarn, "Salt.Defacer", "Salt.Defacer.Garden");

            Portals.AddPortalSign("Defacer_Sign", ResourceLoader.LoadSprite("DefacerWorld.png"), Portals.NPCIDColor);

            OldPatch_Prepare_NPC_RoomPrefab("Assets/Defacer/DefacerRoom.prefab", "Salt.Defacer.Room", SaltsReseasoned.Meow);

            ConditionEncounterSO quest = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            quest.name = "Salt_Defacer_Quest";
            quest.m_QuestName = "Defacer_Quest";
            quest.m_QuestsCompletedNeeded = [];
            quest.encounterEntityIDs = ["Defacer"];
            quest.signID = "Defacer_Sign";
            quest._dialogue = "Salt.Defacer.Quest";
            quest.encounterRoom = "Salt.Defacer.Room";

            ModdedNPCs.AddCustom_ConditionEncounter("Salt_Defacer_Quest", quest);

            ZoneBGDataBaseSO zone2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;
            zone2._QuestPool.Add("Salt_Defacer_Quest");

            ConditionEncounterSO garden = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            garden.name = "Salt_Defacer_Garden";
            garden.m_QuestsCompletedNeeded = ["Defacer_Quest"];
            garden.encounterEntityIDs = ["Defacer"];
            garden.signID = "Defacer_Sign";
            garden._dialogue = "Salt.Defacer.Garden";
            garden.encounterRoom = "Salt.Defacer.Room";

            ModdedNPCs.AddCustom_ConditionEncounter("Salt_Defacer_Garden", garden);

            ZoneBGDataBaseSO zone3 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
            zone3._SpecialQuestPool.Add("Salt_Defacer_Garden");

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.QuestSpecial, pilePosition = PilePositionType.Any };
            card._minimumAmount = 1;
            card._maximumAmount = 1;
            card._usePercentage = false;

            card._cardInfo.specialID = zone3._SpecialQuestPool.Count - 1;
            card._cardInfo.specialString = "Defacer_Sign";
            List<CardTypeInfo> oldHC = zone3._deckInfo._possibleCards.ToList();
            oldHC.Add(card);
            zone3._deckInfo._possibleCards = oldHC.ToArray();
        }
        public static void OldPatch_Prepare_NPC_RoomPrefab(string prefabBundlePath, string roomID, AssetBundle fileBundle)
        {
            NPCRoomHandler room = fileBundle.LoadAsset<GameObject>(prefabBundlePath).AddComponent<NPCRoomHandler>();

            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            room._npcSelectable._detector = room._npcSelectable.transform.GetComponent<BoxCollider2D>();

            room._npcSelectable.SetMaterials(LoadedDBsHandler.MiscDB.GetMaterial(Misc.MaterialIDs.Outline.ToString()));

            LoadedAssetsHandler.TryAddExternalOWRoom(roomID, room);
        }
    }
}
