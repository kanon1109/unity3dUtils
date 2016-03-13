#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 批量创建Prefab名称与gameObject同名
/// </summary>
public class BatchCreatePrefab
{
    private const string ORIGIN_DIR = "\\Atlas"; //需要转换的目录(手动修改目录)
    private const string TARGET_DIR = "\\Resources\\prefabs"; //转换后放入prefab的目录 
    /// <summary>
    /// 将某个gameObject下的所有子对象批量转换Sprite prefab
    /// </summary>
    [MenuItem("Tools/batchCreatePrefab All Children")]
    public static void batchCreateSpritePrefab()
    {
        string targetDir = Application.dataPath + TARGET_DIR;
        //如果目录不存在创建空的目标目录
        if (!Directory.Exists(targetDir)) 
            Directory.CreateDirectory(targetDir);
        //获取选中的对象
        Transform tParent = ((GameObject)Selection.activeObject).transform;
        Object tempPrefab;
        foreach (Transform t in tParent)
        {
            MonoBehaviour.print(t.gameObject.name);
            tempPrefab = PrefabUtility.CreateEmptyPrefab("Assets" + TARGET_DIR.Replace("\\", "/") + "/" + t.gameObject.name + ".prefab");
            tempPrefab = PrefabUtility.ReplacePrefab(t.gameObject, tempPrefab);
        }
    }

    /// <summary>
    /// 将目录下所有图片转成Sprite prefab 
    /// </summary>
    [MenuItem("Tools/batchCreateSpritePrefabInPath")]
    public static void batchCreateSpritePrefabInPath()
    {
        string targetDir = Application.dataPath + TARGET_DIR;
        string originDir = Application.dataPath + ORIGIN_DIR;
        if (!Directory.Exists(originDir))
        {
            EditorUtility.DisplayDialog("错误", originDir.Replace("\\", "/") + "目录不存在", "确定");
            return;
        }
        if (!File.Exists(targetDir)) Directory.CreateDirectory(targetDir); //如果目录不存在创建空的目标目录
        DirectoryInfo originDirInfo = new DirectoryInfo(originDir);
        //创建prefab
        makeSpritePrefabs(originDirInfo.GetFiles("*.jpg", SearchOption.AllDirectories), targetDir);
        makeSpritePrefabs(originDirInfo.GetFiles("*.png", SearchOption.AllDirectories), targetDir);
        EditorUtility.ClearProgressBar();
    }

    /// <summary>
    /// 将目录下所有图片转成prefab 
    /// </summary>
    [MenuItem("Tools/batchCreateImagePrefabInPath")]
    public static void batchCreateImagePrefabInPath()
    {
        string targetDir = Application.dataPath + TARGET_DIR;
        string originDir = Application.dataPath + ORIGIN_DIR;
        if (!Directory.Exists(originDir))
        {
            EditorUtility.DisplayDialog("错误", originDir.Replace("\\", "/") + "目录不存在", "确定");
            return;
        } 
        if (!File.Exists(targetDir)) Directory.CreateDirectory(targetDir); //如果目录不存在创建空的目标目录
        DirectoryInfo originDirInfo = new DirectoryInfo(originDir);
        //创建prefab
        makeImagePrefabs(originDirInfo.GetFiles("*.jpg", SearchOption.AllDirectories), targetDir);
        makeImagePrefabs(originDirInfo.GetFiles("*.png", SearchOption.AllDirectories), targetDir);
        EditorUtility.ClearProgressBar();
    }

    /// <summary>
    /// 创建image的Prefabs
    /// </summary>
    /// <param name="files">文件数据</param>
    /// <param name="targetDir">目标目录</param>
    private static void makeImagePrefabs(FileInfo[] files, string targetDir)
    {
        foreach (FileInfo file in files)
        {
            //获取全路径
            string allPath = file.FullName;
            MonoBehaviour.print(allPath);
            //获取资源路径
            string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
            MonoBehaviour.print("assetPath " + assetPath);
            //加载贴图
            Sprite sprite = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Sprite)) as Sprite;
            //创建绑定了贴图的 GameObject 对象
            GameObject go = new GameObject(sprite.name);
            go.AddComponent<Image>().sprite = sprite;
            go.GetComponent<RectTransform>().sizeDelta = new Vector2(sprite.rect.width, 
                                                                     sprite.rect.height);
            EditorUtility.DisplayProgressBar("创建" + sprite.name, "创建" + sprite.name, 1f);
            //获取图片名称
            string imageName = assetPath.Replace("Assets" + ORIGIN_DIR + "\\", "");
            //去掉后缀
            imageName = imageName.Substring(0, imageName.IndexOf("."));
            //得到最终路径
            string prefabPath = targetDir + "\\" + imageName + ".prefab";
            //得到应用当前目录的路径
            prefabPath = prefabPath.Substring(prefabPath.IndexOf("Assets"));
            //创建目录
            Directory.CreateDirectory(prefabPath.Substring(0, prefabPath.LastIndexOf("\\")));
            //生成预制件
            PrefabUtility.CreatePrefab(prefabPath.Replace("\\", "/"), go);
            //销毁对象
            GameObject.DestroyImmediate(go);
        }
        EditorUtility.ClearProgressBar();
    }

    /// <summary>
    /// 创建sprite的Prefabs
    /// </summary>
    /// <param name="files">文件数据</param>
    /// <param name="targetDir">目标目录</param>
    private static void makeSpritePrefabs(FileInfo[] files, string targetDir)
    {
        foreach(FileInfo file in files)
        {
            //获取全路径
            string allPath = file.FullName;
            MonoBehaviour.print(allPath);
            //获取资源路径
            string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
            MonoBehaviour.print("assetPath " + assetPath);
            //加载贴图
            Sprite sprite = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Sprite)) as Sprite;
            //创建绑定了贴图的 GameObject 对象
            GameObject go = new GameObject(sprite.name);
            go.AddComponent<SpriteRenderer>().sprite = sprite;
            EditorUtility.DisplayProgressBar("创建" + sprite.name, "创建" + sprite.name, 1f);
            //获取图片名称
            string imageName = assetPath.Replace("Assets" + ORIGIN_DIR + "\\", "");
            //去掉后缀
            imageName = imageName.Substring(0, imageName.IndexOf("."));
            //得到最终路径
            string prefabPath = targetDir + "\\" + imageName + ".prefab";
            //得到应用当前目录的路径
            prefabPath = prefabPath.Substring(prefabPath.IndexOf("Assets"));
            //创建目录
            Directory.CreateDirectory(prefabPath.Substring(0, prefabPath.LastIndexOf("\\")));
            //生成预制件
            PrefabUtility.CreatePrefab(prefabPath.Replace("\\", "/"), go);
            //销毁对象
            GameObject.DestroyImmediate(go);
        }
        EditorUtility.ClearProgressBar();
    }
}
#endif
