using UnityEngine;
using UnityEngine.UI;
public class ColorUtilTest:MonoBehaviour
{
    public Image img;
    void Start()
    {
        img.material.SetColor("_Color", ColorUtil.uint2Color(ColorUtil.GOLD));
        Debug.Log(ColorUtil.uint2Color(ColorUtil.GOLD));
    }
}