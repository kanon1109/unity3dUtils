using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LockScreen
{
    private static GameObject panel = null;
    //默认的画布
    private static Transform parent = null;
    /// <summary>
    /// 设置父节点
    /// </summary>
    /// <param name=canvasName></param>
    /// <returns></returns>
    public static void initParent(Transform parent)
    {
        LockScreen.parent = parent;
    }

    /// <summary>
    /// 显示
    /// </summary>
    /// <returns></returns>
    public static void show()
    {
        LockScreen.show(.3f);
    }

    /// <summary>
    /// 显示
    /// </summary>
    /// <param name=alpha>透明度</param>
    /// <returns></returns>
    public static void show(float alpha)
    {
        if (panel == null)
        {
            panel = new GameObject();
            panel.name = "lockScreen";
            Image image = panel.AddComponent<Image>();
            image.sprite = Resources.Load("lockScreenBg", typeof(Sprite)) as Sprite;
            //将锁屏添加进画布中
            panel.transform.SetParent(parent);
            panel.transform.localPosition = new Vector3();
            panel.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        }
        panel.SetActive(true);
        //设置深度节点
        panel.transform.SetSiblingIndex(-1);
        //设置透明度
        if (alpha >= 0)
        {
            Image image = panel.GetComponent<Image>();
            Color hey;
            hey.a = alpha;
            hey.r = image.color.r;
            hey.g = image.color.g;
            hey.b = image.color.b;
            image.color = hey;
        }
    }

    /// <summary>
    /// 隐藏
    /// </summary>
    /// <returns></returns>
    public static void hide()
    {
        if (panel == null) return;
        panel.SetActive(false);
    }
}
