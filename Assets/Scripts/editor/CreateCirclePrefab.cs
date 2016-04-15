using UnityEngine;
using UnityEditor;
public class CreateCirclePrefab : ScriptableObject
{
    private const string TARGET_DIR = "\\Resources\\Prefabs\\"; //转换后放入prefab的目录 
    //单个cube所占的角度(角度越小，圆形越平滑)
    private static int angle = 10;
    //半径
    private static float r = 1f;
    //环的厚度
    private static float thickness = .1f;
    //环的宽度
    private static float width = .1f;
    [MenuItem("Tools/create/CreateCirclePrefab")]
    public static void createCirclePrefab()
    {
        if (Selection.activeObject == null)
        {
            EditorUtility.DisplayDialog("错误", "请先在目录下选择一个cube prefab对象，用于制作环形。", "确定");
            return;
        }
        
        if (PrefabUtility.GetPrefabType(Selection.activeObject) != PrefabType.Prefab) return;
        //创建一个空的对象
        GameObject circleGo = new GameObject("Circle");
        int count = (int)360 / angle;
        int curAngle = 0;
        float dis = Mathf.Sin((angle + 2) * Mathf.Deg2Rad) * r;
        for (int i = 0; i < count; i++)
        {
            float rad = curAngle * Mathf.Deg2Rad;
            float x = Mathf.Cos(rad) * r;
            float y = Mathf.Sin(rad) * r;
            GameObject cube = PrefabUtility.InstantiatePrefab(Selection.activeObject as GameObject) as GameObject;
            cube.transform.SetParent(circleGo.transform);
            cube.transform.localPosition = new Vector3(x, y + r, 0);
            cube.transform.localScale = new Vector3(thickness, dis, width);
            cube.transform.localRotation = new Quaternion(0, 0, Mathf.Sin(curAngle / 2 * Mathf.Deg2Rad), Mathf.Cos(curAngle / 2 * Mathf.Deg2Rad));
            curAngle += angle;
        }
        //将新建的环创建成prefab
        PrefabUtility.CreatePrefab("Assets" + TARGET_DIR.Replace("\\", "/") + "Circle.prefab", circleGo);
        GameObject.DestroyImmediate(circleGo);
    }
}