using UnityEngine;
/// <summary>
/// 延迟隐藏
/// </summary>
public class DelayActive : MonoBehaviour
{
    //延迟毫秒数
    public float millisecond = 0;
    //是否自动销毁
    public bool autoDestroy = false;
    //是否结束
    private bool isComplete = true;
    /// <summary>
    /// 开始
    /// </summary>
    public void start(float millisecond = 1000)
    {
        this.millisecond = millisecond;
        this.isComplete = false;
    }

    void FixedUpdate()
    {
        if (this.isComplete) return;
        this.millisecond -= Time.deltaTime * 1000;
        if (this.millisecond <= 0)
        {
            this.gameObject.SetActive(false);
            this.isComplete = true;
            this.millisecond = 0;
            if (this.autoDestroy)
                GameObject.Destroy(this);
        }
    }

}