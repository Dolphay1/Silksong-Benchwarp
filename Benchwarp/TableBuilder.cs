using BepInEx;
using Benchwarp.UI;
using UnityEngine;

namespace Benchwarp;

public static class TableBuilder
{
    private static ButtonTable buttonTable;
    private static void Warp()
    {
        Plugin.Logger.LogInfo(PlayerData.instance.respawnScene);
        GameManager.instance.SaveGame(null);
        GameManager.instance.ContinueGame();
        Plugin.Logger.LogInfo(PlayerData.instance.respawnScene);
    }

    public static GameObject BuildTable()
    {
        var canvasObject = Prefabs.CanvasObject();

        var tableObj = new GameObject("Table");
        buttonTable = tableObj.AddComponent<ButtonTable>();
        buttonTable.Setup();

        var rect = tableObj.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.up;
        rect.anchorMax = Vector2.up;
        rect.pivot = Vector2.up;
        rect.sizeDelta = new Vector2(1920, 1080);
        
        AddBenchButtons();
        
        AddUtilityButtons();

        tableObj.transform.SetParent(canvasObject.transform, false);

        return canvasObject;
    }

    private static void AddUtilityButtons()
    {
        buttonTable.AddColumn("Utility", false);
        
        var toggleButton = Prefabs.UITextButton("View All", Textures.BoundingBox);
        toggleButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(buttonTable.ToggleAllColumns);

        buttonTable.AddButton(toggleButton, "Utility");
        
        var bypassButton = Prefabs.UITextButton("Enable All", Textures.BoundingBox);
        bypassButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(buttonTable.BypassBenchRequirement);

        buttonTable.AddButton(bypassButton, "Utility");
        
        
        var warpButton = Prefabs.UITextButton("Warp", Textures.BoundingBox);
        warpButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Warp);

        buttonTable.AddButton(warpButton, "Utility");
    }

    private static void AddBenchButtons()
    {
        buttonTable.AddColumn("Moss Grotto");
        buttonTable.AddButton(SetSpawnButton.Generate("Ruined Chappel", "Tut_03"), "Moss Grotto");
        buttonTable.AddButton(SetSpawnButton.Generate("Bone Bottom", "Bonetown"), "Moss Grotto");
        buttonTable.AddButton(SetSpawnButton.Generate("Mosshome 1", "Mosstown_02c"), "Moss Grotto");
        buttonTable.AddButton(SetSpawnButton.Generate("Mosshome 2", "Mosstown_03"), "Moss Grotto");
        buttonTable.AddButton(SetSpawnButton.Generate("Zylotol Wormways", "Crawl_08"), "Moss Grotto");
        buttonTable.AddButton(SetSpawnButton.Generate("Weavenest Atla", "Weave_07"), "Moss Grotto");
        
        buttonTable.AddColumn("The Marrow");
        buttonTable.AddButton(SetSpawnButton.Generate("Bell Shrine", "Bellshrine"), "The Marrow");
        buttonTable.AddButton(SetSpawnButton.Generate("Sherma Door", "Bone_01c"), "The Marrow");
        buttonTable.AddButton(SetSpawnButton.Generate("Shakra", "Bone_04"), "The Marrow");
        buttonTable.AddButton(SetSpawnButton.Generate("Fleas", "Bone_10"), "The Marrow");
        buttonTable.AddButton(SetSpawnButton.Generate("Grindle", "Bone_12"), "The Marrow");
        
        buttonTable.AddColumn("Deep Docks");
        buttonTable.AddButton(SetSpawnButton.Generate("Bell Shrine", "Bellshrine_05"), "Deep Docks");
        buttonTable.AddButton(SetSpawnButton.Generate("Swift Step", "Dock_01"), "Deep Docks");
        buttonTable.AddButton(SetSpawnButton.Generate("Diving Bell Entrance", "Dock_10"), "Deep Docks");
        buttonTable.AddButton(SetSpawnButton.Generate("Forge Daughter", "Room_Forge"), "Deep Docks");
        
        buttonTable.AddColumn("Far Fields");
        buttonTable.AddButton(SetSpawnButton.Generate("Bellway", "Bellway_03"), "Far Fields");
        buttonTable.AddButton(SetSpawnButton.Generate("Pilgrims Rest", "Bone_East_10_Room"), "Far Fields");
        buttonTable.AddButton(SetSpawnButton.Generate("Bell Bench", "Bone_East_15"), "Far Fields");
        buttonTable.AddButton(SetSpawnButton.Generate("Weavenest Cindril", "Bone_East_Weavehome"), "Far Fields");
        buttonTable.AddButton(SetSpawnButton.Generate("Seamstress", "Bone_East_Umbrella"), "Far Fields");
        buttonTable.AddButton(SetSpawnButton.Generate("Sprintmaster", "Sprintmaster_Cave"), "Far Fields");
        buttonTable.AddButton(SetSpawnButton.Generate("Skarrsinger Karmelita", "Bone_East_27"), "Far Fields");
        
        buttonTable.AddColumn("The Slab");
        buttonTable.AddButton(SetSpawnButton.Generate("Bellway", "Slab_06"), "The Slab");
        buttonTable.AddButton(SetSpawnButton.Generate("Neck Snap", "Slab_16"), "The Slab");
        buttonTable.AddButton(SetSpawnButton.Generate("Map", "Slab_20"), "The Slab");
        buttonTable.AddButton(SetSpawnButton.Generate("Mount Fay Shakra", "Peak_02"), "The Slab");
        buttonTable.AddButton(SetSpawnButton.Generate("Mount Fay Bell Bench", "Bellway_Peak"), "The Slab");
        buttonTable.AddButton(SetSpawnButton.Generate("Mount Fey Face", "Peak_07"), "The Slab");
        
        buttonTable.AddColumn("Greymoor");
        buttonTable.AddButton(SetSpawnButton.Generate("Bell Shrine", "Bellshrine_02"), "Greymoor");
        buttonTable.AddButton(SetSpawnButton.Generate("Halfway Home", "Halfway_01"), "Greymoor");
        buttonTable.AddButton(SetSpawnButton.Generate("Shakra", "Greymoor_02"), "Greymoor");
        buttonTable.AddButton(SetSpawnButton.Generate("Fleas", "Greymoor_08"), "Greymoor");
        buttonTable.AddButton(SetSpawnButton.Generate("Wisp Thicket", "Wisp_04"), "Greymoor");
        buttonTable.AddButton(SetSpawnButton.Generate("Verdania", "Clover_20"), "Greymoor");
        
        buttonTable.AddColumn("Bellhart");
        buttonTable.AddButton(SetSpawnButton.Generate("Bellhart", "Belltown"), "Bellhart");
        buttonTable.AddButton(SetSpawnButton.Generate("Bell Shrine", "Belltown_Shrine"), "Bellhart");
        buttonTable.AddButton(SetSpawnButton.Generate("Hornets Home", "Belltown_Room_Spare"), "Bellhart");
        
        buttonTable.AddColumn("Shellwood");
        buttonTable.AddButton(SetSpawnButton.Generate("Bell Shrine", "Bellshrine_03"), "Shellwood");
        buttonTable.AddButton(SetSpawnButton.Generate("East Bell Bench", "Shellwood_01b"), "Shellwood");
        buttonTable.AddButton(SetSpawnButton.Generate("West Bell Bench", "Shellwood_08c"), "Shellwood");
        
        buttonTable.AddColumn("Blasted Steps");
        buttonTable.AddButton(SetSpawnButton.Generate("Steps Entrance", "Coral_02"), "Blasted Steps");
        buttonTable.AddButton(SetSpawnButton.Generate("Bellway", "Bellway_08"), "Blasted Steps");
        buttonTable.AddButton(SetSpawnButton.Generate("Judge Arena", "Coral_Judge_Arena"), "Blasted Steps");
        buttonTable.AddButton(SetSpawnButton.Generate("Sands Of Karak", "Bellshrine_Coral"), "Blasted Steps");
        buttonTable.AddButton(SetSpawnButton.Generate("Coral Tower", "Coral_Tower_01"), "Blasted Steps");
        buttonTable.AddButton(SetSpawnButton.Generate("Pinstress", "Room_Pinstress"), "Blasted Steps");
        
        buttonTable.AddColumn("Bilewater");
        buttonTable.AddButton(SetSpawnButton.Generate("Bellway", "Bellway_Shadow"), "Bilewater");
        buttonTable.AddButton(SetSpawnButton.Generate("Sinners Road", "Dust_10"), "Bilewater");
        buttonTable.AddButton(SetSpawnButton.Generate("Exhaust Organ", "Organ_01"), "Bilewater");
        buttonTable.AddButton(SetSpawnButton.Generate("Rundown Bell", "Shadow_15"), "Bilewater");
        buttonTable.AddButton(SetSpawnButton.Generate("Bilehaven", "Shadow_18"), "Bilewater");
        
        buttonTable.AddColumn("Putrified Ducts");
        buttonTable.AddButton(SetSpawnButton.Generate("Bellway", "Bellway_Aqueduct"), "Putrified Ducts");
        buttonTable.AddButton(SetSpawnButton.Generate("Huntress", "Room_Huntress"), "Putrified Ducts");
        
        buttonTable.AddColumn("Whispering Vaults");
        buttonTable.AddButton(SetSpawnButton.Generate("Vaultkeeper Cardinius", "Library_08"), "Whispering Vaults");
        buttonTable.AddButton(SetSpawnButton.Generate("Pious Isamor", "Library_10"), "Whispering Vaults");
        
        buttonTable.AddColumn("Southern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Grand Bellway", "Bellway_City"), "Southern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Underworks Entrance", "Under_07b"), "Southern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Citidel Spa", "Song_10"), "Southern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("West Toll Bench", "Under_01b"), "Southern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("North Toll Bench", "Under_08"), "Southern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Architect", "Under_17"), "Southern Citadel");
        
        buttonTable.AddColumn("Northern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("First Shrine", "Bellshrine_Enclave"), "Northern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Crossover", "Song_18"), "Northern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Songclave", "Song_Enclave"), "Northern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Terminus", "Tube_Hub"), "Northern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("High Halls Climb", "Hang_01"), "Northern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("The Forum", "Hang_06b"), "Northern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Memorium", "Arborium_04"), "Northern Citadel");
        buttonTable.AddButton(SetSpawnButton.Generate("Cogwork Core", "Cog_Bench"), "Northern Citadel");
        
        buttonTable.AddColumn("The Abyss");
        buttonTable.AddButton(SetSpawnButton.Generate("Climb Bench", "Abyss_09"), "The Abyss");
        buttonTable.AddButton(SetSpawnButton.Generate("Void Room", "Abyss_12"), "The Abyss");
    }
}