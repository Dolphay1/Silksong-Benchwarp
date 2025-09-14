using System;
using UnityEngine;
using UnityEngine.UI;

namespace Benchwarp.UI;

public class ButtonColumn : MonoBehaviour
{
    static readonly string BUTTON_COLUMN_SUB_OBJECT_NAME = "SubButtonGroup";
    public bool bypassBenchRequirement = false;
    private bool headerEnabled = false;
    public void Setup()
    {
        
        var buttonGroupObj = new GameObject(BUTTON_COLUMN_SUB_OBJECT_NAME);
        
        buttonGroupObj.AddComponent<RectTransform>();
        
        var parentLayoutGroup = gameObject.AddComponent<VerticalLayoutGroup>();
        parentLayoutGroup.childForceExpandHeight = false;
        parentLayoutGroup.spacing = 5;
        
        gameObject.AddComponent<LayoutElement>().preferredWidth = 100;
        
        var subLayoutGroup = buttonGroupObj.AddComponent<VerticalLayoutGroup>();
        subLayoutGroup.childForceExpandHeight = false;
        subLayoutGroup.spacing = 5;
        
        gameObject.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        buttonGroupObj.transform.SetParent(transform, false);
        
    }

    public void AddHeaderButton(GameObject headerButton)
    {
        var rectTransform = headerButton.GetComponent<RectTransform>();

        var parentRectTransform = gameObject.GetComponent<RectTransform>();
        parentRectTransform.sizeDelta = parentRectTransform.sizeDelta + new Vector2(0, rectTransform.rect.height + 5);

        headerButton.transform.SetParent(transform, false);
        headerButton.transform.SetAsFirstSibling();
        
        rectTransform.anchorMin = Vector2.up;
        rectTransform.anchorMax = Vector2.up;
        rectTransform.pivot = Vector2.up;
        
        headerButton.GetComponent<Button>().onClick.AddListener(ToggleColumn);
        
        var layoutElement = headerButton.AddComponent<LayoutElement>();
        layoutElement.preferredHeight = rectTransform.rect.height;
        layoutElement.preferredWidth = rectTransform.rect.width;
        
        
        var fitter = headerButton.AddComponent<ContentSizeFitter>();
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;

        headerEnabled = true;
        ToggleColumn(false);
    }

    public void ToggleColumn(bool active)
    {
        if (!headerEnabled) return;
        
        var subButtonGroup = transform.Find(BUTTON_COLUMN_SUB_OBJECT_NAME).gameObject;
        subButtonGroup.SetActive(active);
    }

    public void ToggleColumn()
    {
        var subButtonGroup = transform.Find(BUTTON_COLUMN_SUB_OBJECT_NAME).gameObject;
        ToggleColumn(!subButtonGroup.activeSelf);
    }

    public void AddButton(GameObject button)
    {
        var parentRectTransform = gameObject.GetComponent<RectTransform>();
        var buttonRectTransform = button.GetComponent<RectTransform>();
        
        var addedSize = new Vector2(Math.Max(parentRectTransform.rect.width, buttonRectTransform.rect.width) - parentRectTransform.rect.width, buttonRectTransform.rect.height + 10);
        parentRectTransform.sizeDelta += addedSize;
        gameObject.GetComponent<LayoutElement>().preferredWidth = parentRectTransform.rect.width;
        
        button.transform.SetParent(transform.Find(BUTTON_COLUMN_SUB_OBJECT_NAME), false);
        
        
        var layoutElement = button.AddComponent<LayoutElement>();
        layoutElement.preferredHeight = buttonRectTransform.rect.height;
        layoutElement.preferredWidth = buttonRectTransform.rect.width;
        
        
        var fitter = button.AddComponent<ContentSizeFitter>();
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        
        var spawnButton = button.GetComponent<SetSpawnButton>();
        if (spawnButton != null) spawnButton.column = this;
    }
}