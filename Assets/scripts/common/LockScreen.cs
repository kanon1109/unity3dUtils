using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LockScreen
{
    private static GameObject panel = null;
    //默认的画布
    private static GameObject canvas = GameObject.Find("Canvas");
    /// <summary>
    /// 设置父节点
    /// </summary>
    /// <param name=canvasName></param>
    /// <returns></returns>
    public static void initParent(String canvasName)
    {
        canvas = GameObject.Find(canvasName);
    }

    /// <summary>
    /// 显示
    /// </summary>
    /// <returns></returns>
    public static void show()
    {
        LockScreen.show(-1);
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
            panel = Resources.Load("prefabs/lockScreen") as GameObject;
            panel = MonoBehaviour.Instantiate(panel, new Vector3(), new Quaternion()) as GameObject;
            //将锁屏添加进画布中
            panel.transform.SetParent(canvas.transform);
            //设置rectTransfrom的 left right 和 bottom top
            panel.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 0.0f);
            panel.GetComponent<RectTransform>().offsetMax = new Vector2(0.0f, 0.0f);
        }
        panel.SetActive(true);
        //设置深度节点
        panel.transform.SetSiblingIndex(canvas.transform.GetSiblingIndex());
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
