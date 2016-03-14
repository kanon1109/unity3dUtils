using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 进度条
/// </summary>
public class ProgressBar : MonoBehaviour
{
    //进度条的图片
    public Image barImg;
    //速度
    public float speed = 0.02f;
    //最大宽度
    private float maxWidth = 0.0f;
    //百分比
    private float percent = 0;
    //目标百分比
    private float targetPercent = 0;
    //循环后最终的目标百分比
    private float finalPercent = 0;
    //目标循环次数
    private int targetLoop = 0;
    //当前循环
    private int curLoop = 0;
    public void Awake()
    {
        this.maxWidth = barImg.rectTransform.sizeDelta.x;
        this.setValue(0);
    }

    /// <summary>
    /// 设置条的进度
    /// </summary>
    /// <param name="p">进度百分比</param>
    public void setValue(float p)
    {
        this.percent = p;
        this.targetPercent = p;
        this.targetLoop = 0;
        this.updateBar();
    }

    /// <summary>
    /// 移动到某个进度
    /// </summary>
    /// <param name="p">百分比</param>
    /// <param name="loop">循环数</param>
    public void moveToValue(float p, int loop = 0)
    {
        //当前循环设为0
        this.curLoop = 0;
        //目标循环
        this.targetLoop = loop;
        if (loop > 0)
        {
            //如果比上一次小，循环一圈。
            this.targetPercent = 1.0f;
            this.finalPercent = p;
        }
        else
        {
            this.targetPercent = p;
        }
    }

    /// <summary>
    /// 更新条的宽度
    /// </summary>
    public void updateBar()
    {
        float width = this.maxWidth * this.percent;
        this.barImg.rectTransform.sizeDelta =
            new Vector2(width, this.barImg.rectTransform.sizeDelta.y);
    }

    /// <summary>
    /// 更新百分比
    /// </summary>
    private void updatePercent()
    {
        if (this.targetPercent - this.percent > this.speed)
            this.percent += this.speed;
        else
            this.percent += this.targetPercent - this.percent;
    }

    /// <summary>
    /// 更新循环
    /// </summary>
    private void updateLoop()
    {
        if (this.targetLoop > 0)
        {
            this.curLoop++;
            if (this.curLoop < this.targetLoop)
            {
                //循环未到重置百分比
                this.targetPercent = 1.0f;
                this.percent = 0.0f;
            }
            else
            {
                //到达循环数量设置最终百分比
                this.targetLoop = 0;
                this.targetPercent = this.finalPercent;
                this.percent = 0.0f;
            }
        }
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void Update()
    {
        if (this.percent < this.targetPercent)
        {
            this.updatePercent();
            this.updateBar();
        }
        else
        {
            this.updateLoop();
        }
    }
}
