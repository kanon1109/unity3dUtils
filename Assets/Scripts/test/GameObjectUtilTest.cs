using UnityEngine;
public class GameObjectUtilTest:MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = GameObjectUtil.hitTestPoint(Input.mousePosition);
            print(go);
        }
    }

}
