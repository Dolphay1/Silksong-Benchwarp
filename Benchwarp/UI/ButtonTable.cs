using System;
using System.Collections.Generic;
using GlobalEnums;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Collections;

namespace Benchwarp.UI;

public class ButtonTable : MonoBehaviour
{
    private Dictionary<string, ButtonColumn> columns = new();
    private bool columnsEnabled = false;

    public void Setup()
    {
        var layoutGroup = gameObject.AddComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandWidth = false;
        layoutGroup.spacing = 5;
        
        var contentSizer = gameObject.AddComponent<ContentSizeFitter>();
        contentSizer.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;

        GameManager.instance.GameStateChange += ToggleMenu;
        GameManager.instance.UnloadingLevel += OnUnloadLevel;
        
        ToggleMenu(GameManager.instance.GameState);
    }
    
    

    public void BypassBenchRequirement()
    {
        foreach (var column in columns.Values)
        {
            column.GetComponent<ButtonColumn>().bypassBenchRequirement = true;
        }
    }

    public void ToggleMenu(GameState state)
    {
        gameObject.SetActive(state == GameState.PAUSED);
    }

    public void ToggleAllColumns()
    {
        columnsEnabled = !columnsEnabled;
        foreach (var column in columns.Values)
        {
            column.GetComponent<ButtonColumn>().ToggleColumn(columnsEnabled);
        }
    }

    public void OnUnloadLevel()
    {
        gameObject.SetActive(false);
    }
    
    public void AddColumn(string header, bool addHeaderButton = true)
    {
        var column = new GameObject(header);
        
        var script = column.AddComponent<ButtonColumn>();
        script.Setup();
        
        column.transform.SetParent(transform, false);
        
        if (addHeaderButton) script.AddHeaderButton(Prefabs.UITextButton(header, Textures.BoundingBox));
        
        columns.Add(header, script);
    }

    public void AddButton(GameObject button, string header)
    {
        columns.Get(header).AddButton(button);
    }

    public void OnDestroy()
    {
        GameManager.instance.GameStateChange -= ToggleMenu;
        GameManager.instance.UnloadingLevel -= OnUnloadLevel;
    }
}