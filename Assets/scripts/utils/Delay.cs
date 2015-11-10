using UnityEngine;
public class Delay : MonoBehaviour
{
    //回调
    public delegate void DelayCompleteHandler();
    private static DelayCompleteHandler delayCompleteHandler = null;
    private static float millisecond = 0;
    private static bool isComplete = false;
    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="go">需要绑定此脚本的对象</param>
    /// <returns></returns>
    public static void create(GameObject go)
    {
        if (go == null) return;
        Delay delay = go.GetComponent<Delay>();
        if (delay == null)
            delay = go.AddComponent<Delay>();
    }

    /// <summary>
    /// 设置间隔
    /// </summary>
    /// <param name="millisecond">毫秒数</param>
    /// <param name="delayCompleteHandler">回调</param>
    /// <returns></returns>
    public static void setDelay(float millisecond, DelayCompleteHandler delayCompleteHandler)
    {
        Delay.isComplete = false;
        Delay.millisecond = millisecond;
        Delay.delayCompleteHandler = delayCompleteHandler;
    }

    void FixedUpdate()
    {
        if (Delay.isComplete) return;
        Delay.millisecond -= Time.deltaTime * 1000;
        if (Delay.millisecond <= 0)
        {
            Delay.isComplete = true;
            Delay.millisecond = 0;
            if (Delay.delayCompleteHandler != null)
                Delay.delayCompleteHandler.Invoke();
        }
    }
}