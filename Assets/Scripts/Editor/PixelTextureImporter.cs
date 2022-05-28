using UnityEngine;
using UnityEditor;

internal sealed class PixelTextureImporter : AssetPostprocessor
{
    void OnPreprocessTexture()
    {

        var targetFolder = "Assets/Textures/PixelArt";
        var importer = assetImporter as TextureImporter;
        Object asset = AssetDatabase.LoadAssetAtPath(importer.assetPath, typeof(Texture2D));
        if (asset) return;
        if (!importer.assetPath.StartsWith(targetFolder)) return;

        var settings = new TextureImporterSettings();
        importer.ReadTextureSettings(settings);

        settings.spritePixelsPerUnit = 16;
        settings.filterMode = FilterMode.Point;

        importer.SetTextureSettings(settings);

        var platformSettings = new TextureImporterPlatformSettings();
        platformSettings.textureCompression = TextureImporterCompression.Uncompressed;

        importer.SetPlatformTextureSettings(platformSettings);
    }
}
