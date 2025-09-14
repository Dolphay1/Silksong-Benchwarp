using System;
using TeamCherry.DebugMenu;
using UnityEngine;
using UnityEngine.UI;

namespace Benchwarp.UI;

public class SetSpawnButton : MonoBehaviour
{
    public string respawnScene;
    public ButtonState state = ButtonState.Inactive;
    public ButtonColumn column;

    public void Update()
    {
        if(PlayerData.instance.respawnScene == respawnScene) SetState(ButtonState.Active);
        else if (PlayerData.instance.scenesVisited.Contains(respawnScene) || (column != null && column.bypassBenchRequirement)) SetState(ButtonState.Inactive);
        else SetState(ButtonState.Disabled);
    }

    public void OnClick()
    {
        if (state == ButtonState.Disabled) return;
        PlayerData.instance.respawnScene = respawnScene;
        PlayerData.instance.respawnMarkerName = "RestBench";
        SetState(ButtonState.Active);
    }

    private void SetColor(Color color)
    {
        // transform.GetComponent<Image>().canvasRenderer.SetColor(color);
        transform.GetComponentInChildren<Text>().color = color;
    }

    public void SetState(ButtonState state)
    {
        if (state == this.state) return;
        
        switch (state)
        {
            case ButtonState.Active:
                SetColor(Color.green);
                break;
            case ButtonState.Inactive:
                SetColor(Color.white);
                break;
            case ButtonState.Disabled:
                SetColor(Color.red);
                break;
        }
        
        this.state = state;
    }

    public static GameObject Generate(string buttonText, string respawnScene)
    {
        var buttonObject = Prefabs.UITextButton(buttonText, Textures.BoundingBox);
        var spawnButton = buttonObject.AddComponent<SetSpawnButton>();
        
        spawnButton.respawnScene = respawnScene;
        buttonObject.GetComponent<Button>().onClick.AddListener(spawnButton.OnClick);
        
        return buttonObject;
    }
}

public enum ButtonState
{
    Active,
    Inactive,
    Disabled
}