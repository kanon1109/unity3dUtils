
using UnityEngine;
public class GameObjectUtil
{
    /// <summary>
    /// 根据名称获取子对象
    /// </summary>
    /// <param name="parent">父对象</param>
    /// <param name="name">子对象名称</param>
    /// <returns></returns>
    public static GameObject findChildByName(GameObject parent, string name)
    {
        if (parent == null) { return null; }
        Transform[] trans = parent.GetComponentsInChildren<Transform>();
        int len = trans.Length;
        for (int i = 0; i < len; i++)
        {
            Transform t = trans[i];
            if (t.name == name)
                return t.gameObject;
        }
        return null;
    }
}