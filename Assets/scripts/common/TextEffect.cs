using UnityEngine;
using UnityEngine.UI;
//文本效果
public class TextEffect:MonoBehaviour
{
    private Timer timer = null;
    //字符串数组
    private char[] strAry;
    //文本框
    private Text txt;
    //文字索引
    private int index;
    //效果回调
    public delegate void ShowCompleteHandler();
    //回调
    private ShowCompleteHandler showCompleteHandler;
    //内容文字
    private string contentStr;
    //效果是否结束
    private bool isComplete = false;
    /// <summary>
    /// 逐字显示
    /// </summary>
    /// <param name="text">文本库</param>
    /// <param name="content">内容文字</param>
    /// <param name="delay">显示间隔(秒)</param>
    /// <returns></returns>
    public void progressShow(Text text, string content, float delay, ShowCompleteHandler handler = null)
    {
        this.index = 0;
        this.isComplete = false;
        this.txt = text;
        this.contentStr = content;
        this.txt.text = "";
        this.strAry = content.ToCharArray();
        this.showCompleteHandler = handler;
        this.createTimer(delay);
    }

    /// <summary>
    /// 创建计时器
    /// </summary>
    /// <param name="delay">秒数</param>
    /// <returns></returns>
    private void createTimer(float delay)
    {
        if (this.timer == null)
            this.timer = this.gameObject.AddComponent<Timer>();
        this.timer.createTimer(delay, -1, timerCompleteHandler);
        this.timer.start();
    }

    private void timerCompleteHandler()
    {
        this.txt.text += this.strAry[this.index];
        this.index++;
        if (this.index > this.strAry.Length - 1)
        {
            this.timer.stop();
            this.isComplete = true;
            if (this.showCompleteHandler != null) 
                this.showCompleteHandler.Invoke();
        }
    }

    /// <summary>
    /// 删除计时器
    /// </summary>
    /// <returns></returns>
    private void removeTimer()
    {
        if (this.timer != null)
        {
            this.timer.stop();
            GameObject.Destroy(this.timer);
            this.timer = null;
        }
    }

    /// <summary>
    /// 销毁
    /// </summary>
    /// <returns></returns>
    public void destroy()
    {
        this.removeTimer();
    }

    /// <summary>
    /// 显示完成
    /// </summary>
    /// <returns></returns>
    public void showComplete()
    {
        this.removeTimer();
        this.txt.text = this.contentStr;
        if (this.showCompleteHandler != null)
            this.showCompleteHandler.Invoke();
    }

    /// <summary>
    /// 暂停
    /// </summary>
    /// <returns></returns>
    public void pause()
    {
        if (this.timer != null)
            this.timer.stop();
    }

    /// <summary>
    /// 播放
    /// </summary>
    /// <returns></returns>
    public void unPause()
    {
        if (this.timer != null)
            this.timer.start();
    }
}