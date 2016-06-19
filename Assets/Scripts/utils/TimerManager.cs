using System.Collections.Generic;
using UnityEngine;
public class TimerManager:MonoBehaviour
{
    //时间数据字典
    private Dictionary<string, TimerVo> timeVoDict = new Dictionary<string,TimerVo>();
    //单利
    private static TimerManager _instance;
    public static TimerManager getInstance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<TimerManager>();
                if(_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "TimerManager";
                    _instance = go.AddComponent<TimerManager>();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// 添加一个时间对象
    /// </summary>
    /// <param name="key">键值</param>
    /// <param name="vo">时间对象</param>
    public void addTimer(string key, TimerVo vo)
    {
        this.timeVoDict.Add(key, vo);
    }

    /// <summary>
    /// 删除时间
    /// </summary>
    /// <param name="key">键值</param>
    public void removeTimer(string key)
    {
        if (!this.timeVoDict.ContainsKey(key)) return;
        this.timeVoDict.Remove(key);
    }

    /// <summary>
    /// 结束一个时间
    /// </summary>
    /// <param name="key">键值</param>
    public void finishTimer(string key)
    {
        if (!this.timeVoDict.ContainsKey(key)) return;
        TimerVo tVo = this.timeVoDict[key];
        if (tVo.isIncrement)
            tVo.leftSecond = tVo.endSecond;
        else
            tVo.leftSecond = 0;
    }

    /// <summary>
    /// 获取一个时间数据
    /// </summary>
    /// <param name="key">键值</param>
    /// <returns></returns>
    public TimerVo getTimer(string key)
    {
        if (!this.timeVoDict.ContainsKey(key)) return null;
        return this.timeVoDict[key];
    }

    /// <summary>
    /// 清理
    /// </summary>
    public void clear()
    {
        this.timeVoDict.Clear();
    }

    /// <summary>
    /// 调用timerVo的回调函数
    /// </summary>
    /// <param name="tVo">时间数据</param>
    private void callTimerVoCallBackHandler(TimerVo tVo)
    {
        if (tVo == null) return;
        List<TimerVo.CallBackHandler> list = tVo.callBackList;
        if (list == null) return;
        int length = list.Count;
        for (int i = 0; i < length; i++)
        {
            TimerVo.CallBackHandler callBack = list[i];
            callBack.Invoke();
        }
    }

    public void FixedUpdate()
    {
        List<string> keys = new List<string>(this.timeVoDict.Keys);
        for (int i = 0; i < this.timeVoDict.Count; ++i)
        {
            string key = keys[i];
            TimerVo tVo = this.timeVoDict[key];
            if (!tVo.isIncrement)
            {
                tVo.leftSecond -= Time.deltaTime;
                if (tVo.leftSecond <= 0)
                {
                    this.callTimerVoCallBackHandler(tVo);
                    this.timeVoDict.Remove(key);
                }
            }
            else
            {
                tVo.leftSecond += Time.deltaTime;
                if (tVo.leftSecond >= tVo.endSecond)
                {
                    this.callTimerVoCallBackHandler(tVo);
                    this.timeVoDict.Remove(key);
                }
            }
        }
    }
}

public class TimerVo
{
    //剩余时间（秒）
    public float leftSecond;
    //结束时间（秒）
    public float endSecond;
    //用于显示的时间（秒）
    public int displaySecond;
    //是否是增长型
    public bool isIncrement = false;
    //回调函数代理
    public delegate void CallBackHandler();
    //回调列表
    public List<CallBackHandler> callBackList;
    /// <summary>
    /// 添加回调函数
    /// </summary>
    /// <param name="callBack"></param>
    public void addCallBackHandler(CallBackHandler callBack)
    {
        if (this.callBackList == null) this.callBackList = new List<CallBackHandler>();
        this.callBackList.Add(callBack);
    }
}