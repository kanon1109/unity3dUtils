using System;
using UnityEngine;
using UnityEngine.UI;
public class QualityStar
{

    public static GameObject create(String path, int num, float gap)
    {
        GameObject qs = new GameObject();
        qs.name = "qualityStar";
        for (int i = 0; i < num; ++i)
        {
            GameObject star = new GameObject();
            star.name = "star" + i;
            Image image = star.AddComponent<Image>();
            //添加图片资源
            image.overrideSprite = Resources.Load(path, typeof(Sprite)) as Sprite;
            star.transform.parent = qs.transform;
        }
        return qs;
    }

}
