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
}
#endif
