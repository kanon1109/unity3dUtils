using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 打包assetbunldes工具
/// </summary>
public class CreateAssetBunldes
{
    //assetbunldes目录
    private const string ASSET_BUNLDES_DIR = "\\ABs";
    [MenuItem("Tools/CreateAssetBunldes")]
    public static void createAssetBunldes()
    {
        string targetDir = Application.dataPath + ASSET_BUNLDES_DIR;
        if (Directory.Exists(targetDir)) Directory.Delete(targetDir, true); //删除目标目录
        if (File.Exists(targetDir + ".meta")) File.Delete(targetDir + ".meta"); //删除目录的.meta文件
        Directory.CreateDirectory(targetDir);
        // Create the array of bundle build details.
        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];
        buildMap[0].assetBundleName = "test.assetbundle";//打包的资源包名称 随便命名
        string resStr = "Assets/Resources/prefabs/1.prefab,Assets/Resources/prefabs/2.prefab";
        buildMap[0].assetNames = resStr.Split(',');
        BuildPipeline.BuildAssetBundles(targetDir.Replace("\\", "/"), buildMap, 
                                        BuildAssetBundleOptions.UncompressedAssetBundle, 
                                        BuildTarget.StandaloneWindows);
    }
}
