using UnityEngine;
class Timer : MonoBehaviour
{
    public delegate void TimerCompleteHandler();
    //回调
    private TimerCompleteHandler timerCompleteHandler;
    private float delay;
    private float curTime;
    //重复次数
    private int repeatCount;
    private int _curCount;
    //是否在运行
    private bool _isRunning = false;
    //是否自动销毁
    private bool autoDestroy = false;

    /// <summary>
    /// 创建计时器
    /// </summary>
    /// <param name=delay>运行间隔秒数</param>
    /// <param name=repeatCount>重复次数</param>
    /// <param name=handler>回调函数</param>
    /// <param name=autoDestroy>是否自动销毁</param>
    /// <returns></returns>
    public void createTimer(float delay, int repeatCount, TimerCompleteHandler handler, bool autoDestroy)
    {
        this.autoDestroy = autoDestroy;
        this.delay = delay;
        this.repeatCount = repeatCount;
        this._isRunning = false;
        this.timerCompleteHandler = handler;
        this.reset();
    }

    /// <summary>
    /// 创建计时器
    /// </summary>
    /// <param name=delay>运行间隔秒数</param>
    /// <param name=repeatCount>重复次数</param>
    /// <param name=handler>回调函数</param>
    /// <returns></returns>
    public void createTimer(float delay, int repeatCount, TimerCompleteHandler handler)
    {
        this.createTimer(delay, repeatCount, handler, false);
    }

    /// <summary>
    /// 开始计时器
    /// </summary>
    /// <returns></returns>
    public void start()
    {
        this._isRunning = true;
    }

    /// <summary>
    /// 停止计时器
    /// </summary>
    /// <returns></returns>
    public void stop()
    {
        this._isRunning = false;
    }

    /// <summary>
    /// 重置计时器
    /// </summary>
    /// <returns></returns>
    public void reset()
    {
        this.curTime = 0;
        this._curCount = 0;
    }

    void FixedUpdate()
    {
        if (!this._isRunning) return;
        this.curTime += Time.deltaTime;
        if (this.curTime >= this.delay)
        {
            this._curCount++;
            if (this.repeatCount <= 0)
            {
                //无限重复
                this.curTime = 0;
            }
            else
            {
                if (this._curCount >= this.repeatCount)
                {
                    //停止执行
                    this.stop();
                    if (this.autoDestroy) Destroy(this);
                }
            }
            this.timerCompleteHandler.Invoke();
        }
    }

    //当前执行次数
    public int currentCount
    {
        get { return _curCount; }
    }

    //是否在运行
    public bool isRunning
    {
        get { return _isRunning; }
    }
}
