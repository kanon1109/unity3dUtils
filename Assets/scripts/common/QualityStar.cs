using System;
using UnityEngine;
using UnityEngine.UI;
public class QualityStar
{

    /// <summary>
    /// 创建一个品质星星
    /// </summary>
    /// <param name=parent>父级</param>
    /// <param name=path>图片路径+名字</param>
    /// <param name=num>数量</param>
    /// <param name=gap>间隔</param>
    /// <returns></returns>
    public static GameObject create(Transform parent, String path, int num, float gap)
    {
        GameObject qs = new GameObject();
        qs.name = "qualityStar";
        for (int i = 0; i < num; ++i)
        {
            GameObject star = new GameObject();
            star.name = "star" + i;
            Image image = star.AddComponent<Image>();
            //添加图片资源
            image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
            //设置成原始大小
            image.SetNativeSize();
            star.transform.parent = qs.transform;
            //image.sprite.rect.width 获取图片原始宽度
            star.transform.position = new Vector3((image.sprite.rect.width + gap) * i, 0);
        }
        qs.transform.parent = parent;
        qs.transform.localPosition = new Vector3();
        //设置本地的坐标
        return qs;
    }


    /// <summary>
    /// 创建一个品质星星
    /// </summary>
    /// <param name=parent>父级</param>
    /// <param name=path>图片路径+名字</param>
    /// <param name=num>数量</param>
    /// <returns></returns>
    public static GameObject create(Transform parent, String path, int num)
    {
        return QualityStar.create(parent, path, num, 0);
    }

}
