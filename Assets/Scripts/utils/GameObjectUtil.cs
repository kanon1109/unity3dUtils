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

    /// <summary>
    /// 碰撞检测（3d物品的碰撞）
    /// </summary>
    /// <param name="position">碰撞点</param>
    /// <param name="layerMask">只选定Layermask层内的碰撞器，其它层内碰撞器忽略 (1 -- layerMask.NameToLayer("xxx"))</param>
    /// <returns></returns>
    public static GameObject hitTestPoint(Vector3 position, int layerMask = -1)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hitInfo;
        //仅找第一个对象,可以设置layer过滤
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
            return hitInfo.transform.gameObject;

        return null;
    }
}