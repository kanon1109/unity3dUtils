using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 文本工具
/// </summary>
public class TextUtil
{
    /// <summary>
    /// 设置自动缩放，使文本可以完整的填充整个文字区域。
    /// </summary>
    /// <param name="text">文本</param>
    public static void setAutoScale(Text text)
    {
        int size = text.fontSize;
        Vector2 vect2 = text.GetComponent<RectTransform>().sizeDelta;
        float maxWidth = vect2.x;
        float maxHeight = vect2.y;
        while (text.preferredWidth > maxWidth || 
               text.preferredHeight > maxHeight)
        {
            if (size <= 4) break;
            text.fontSize--;
        }
    }
}