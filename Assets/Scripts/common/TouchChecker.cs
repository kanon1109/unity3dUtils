using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 点击判断 用于判断点击ugui界面的同时不触发3d对象的点击
/// </summary>
public class TouchChecker : MonoBehaviour
{
    //ugui的画布组件
    public GraphicRaycaster graphicRaycaster;
    //ugui的点击事件管理
    public EventSystem eventSystem;
    /// <summary>
    /// 判断ugui是否被点击
    /// </summary>
    /// <returns></returns>
    public bool checkGuiRaycastObjects()
    {
        if (this.graphicRaycaster == null || this.eventSystem == null) return false;
        PointerEventData pointEventData = new PointerEventData(this.eventSystem);
        pointEventData.pressPosition = Input.mousePosition;
        pointEventData.position = Input.mousePosition;
        List<RaycastResult> resultList = new List<RaycastResult>();
        this.graphicRaycaster.Raycast(pointEventData, resultList);
        return resultList.Count > 0;
    }

    /// <summary>
    /// 获取点击的对象
    /// </summary>
    /// <param name="checkGui">是否判断gui被点击，如果设为true时gui点击将覆盖3d对象的点击事件</param>
    /// <returns></returns>
    public GameObject getTouchObj(bool checkGui = true)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (checkGui && this.checkGuiRaycastObjects()) return null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
                return hitInfo.transform.gameObject;
        }
        return null;
    }
}
