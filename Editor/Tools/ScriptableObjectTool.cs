using UnityEngine;
using UnityEditor;


namespace Meringue
{

/// <summary>
/// A tool class to create an asset file under Assets folder.
/// </summary>
/// <see cref="http://wiki.unity3d.com/index.php?title=CreateScriptableObjectAsset"/>
public class ScriptableObjectTool
{
    public static void CreateAsset< T >() where T : ScriptableObject
    {
        var asset = ScriptableObject.CreateInstance< T >();

        string path = AssetDatabase.
            GenerateUniqueAssetPath( "Assets/New" + typeof( T ).ToString() + ".asset" );

        AssetDatabase.CreateAsset( asset, path );

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}


}  // namespace Meringue
