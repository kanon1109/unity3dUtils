using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 带冷却效果的icon
/// </summary>
public class CdIcon : MonoBehaviour
{
    //黑遮
    public Image mask;
    //时间文本
    public Text timeTxt;
    //持续时间
    private float duration = 0;
    /// <summary>
    /// 设置cd百分比
    /// </summary>
    /// <param name="value">百分比值</param>
    public void setValue(float value)
    {
        if (this.mask == null) return;
        this.mask.fillAmount = value;
    }

    /// <summary>
    /// 显示时间文本
    /// </summary>
    /// <param name="flag">是否显示</param>
    public void showTimeTxt(bool flag)
    {
        if (this.timeTxt != null)
            this.timeTxt.gameObject.SetActive(flag);
    }

    /// <summary>
    /// 开始
    /// </summary>
    /// <param name="duration">持续时间（秒数）</param>
    public void start(float duration)
    {
        this.duration = duration;
        if (this.timeTxt != null) 
            this.timeTxt.gameObject.SetActive(true);
        this.setValue(1f);
    }

    void FixedUpdate()
    {
        if (this.mask.fillAmount == 0) return;
        this.mask.fillAmount -= 1 / this.duration * Time.deltaTime;
        if (this.timeTxt != null)
        {
            this.timeTxt.text = Mathf.CeilToInt(this.duration * this.mask.fillAmount).ToString();
            if (this.mask.fillAmount == 0)
                this.timeTxt.gameObject.SetActive(false);
        }
    }
}
