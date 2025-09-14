using System.Reflection;
using UnityEngine;

namespace Benchwarp.UI;

public static class Textures
{
    public static  Texture2D BoundingBox { get; private set; }

    public static void LoadTextures()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = assembly.GetManifestResourceNames()[0];
        BoundingBox = Prefabs.AssemblyTexture(resourceName);
    }
}