using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


namespace Benchwarp.UI;

public static class Prefabs
{
    public static GameObject CanvasObject()
    {
        var canvasObject = new GameObject("_Benchwarp Root Canvas");
        canvasObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        
        var scaler = canvasObject.AddComponent<CanvasScaler>();
        scaler.referenceResolution = new Vector2(1920f, 1080f);
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        
        canvasObject.AddComponent<GraphicRaycaster>();

        
        return canvasObject;
    }

    public static GameObject UIImage(Texture2D texture, GameObject parent)
    {
        var image = new GameObject("Image");
        image.AddComponent<CanvasRenderer>();
        image.AddComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        
        image.transform.SetParent(parent.transform, false);
        
        return image;
    }
    
    public static GameObject UIButton(Texture2D texture = null)
    {
        var buttonObj = new GameObject("Button");
        buttonObj.AddComponent<CanvasRenderer>();
        var rectTransform = buttonObj.AddComponent<RectTransform>();
        
        
        if (texture != null)
        {
            buttonObj.AddComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
        }
        
        buttonObj.AddComponent<Button>();
        
        return buttonObj;
    }
    
    public static GameObject UITextButton(string buttonText, Texture2D texture = null)
    {
        var buttonObj = new GameObject("Button");
        buttonObj.AddComponent<CanvasRenderer>();
        var rectTransform = buttonObj.AddComponent<RectTransform>();
        
        var textObject = new GameObject("Text");
        var text = textObject.AddComponent<Text>();
        
        text.text = buttonText;
        
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.alignment = TextAnchor.MiddleCenter;
        text.fontSize = 12;
        text.text = buttonText;
        
        
        if (texture != null)
        {
            buttonObj.AddComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
            
            textObject.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width - 5, texture.height - 5);
        }
        
        
        buttonObj.AddComponent<Button>();
        
        
        textObject.transform.SetParent(buttonObj.transform, false);
        
        return buttonObj;
    }

    public static Texture2D AssemblyTexture(string textureId, string textureName = null)
    {
        if (string.IsNullOrEmpty(textureName)) textureName = textureId;
        
        var assembly = Assembly.GetExecutingAssembly();
        var stream = assembly.GetManifestResourceStream(textureId);

        if (stream == null) return null;
        
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        
        var texture = new Texture2D(1, 1);
        texture.LoadImage(buffer.ToArray());
        texture.name = Regex.Match(textureId, @"^(?:.+\.)?(.+)\.(?:.+)$").Groups[1].Value;

        return texture;
    }
}