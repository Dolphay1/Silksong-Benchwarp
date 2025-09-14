using BepInEx;
using BepInEx.Logging;
using Benchwarp.UI;
using UnityEngine;

namespace Benchwarp;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        
        Textures.LoadTextures();
        
        DontDestroyOnLoad(TableBuilder.BuildTable());
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        GameObject.Destroy(GameObject.Find("_Benchwarp Root Canvas"));
    }
}
