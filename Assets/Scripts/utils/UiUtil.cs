using UnityEngine;
using UnityEngine.UI;

public class UiUtil : MonoBehaviour
{
    /// <summary>
    /// 设置按钮变灰色
    /// </summary>
    /// <returns>直接返回传入参数</returns>
	public static bool setBtnGray(Button btn, bool bl)
    {
        btn.interactable = bl;
        Material m = null;
        if ( !bl ) m = Resources.Load("Material/UIGray") as Material;
        btn.GetComponent<Image>().material = m;
		if (btn.GetComponentInChildren<Text>() != null)
			btn.GetComponentInChildren<Text>().color = new Color(144f / 255f, 144f / 255f, 144f / 255f);
        return bl;
    }

    /// <summary>
    /// 变灰Ui对象(Image或Text)
    /// </summary>
    /// <param name="Go"></param>
    public static void setUIGray(GameObject obGo, bool bl)
    {
        Material m = null;
        if (bl) m = Resources.Load("Material/UIGray") as Material;
        Image img = obGo.GetComponent<Image>();
        if (img != null)
        {
            img.material = m;
        }
        else
        {
            Text tf = obGo.GetComponent<Text>();
            if (tf != null)
                tf.material = m;
        }
    }
}
