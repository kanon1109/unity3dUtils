using UnityEngine;
//延迟工具
public class Delay : MonoBehaviour
{
    //回调
    public delegate void DelayCompleteHandler(System.Object param);
    private static DelayCompleteHandler delayCompleteHandler = null;
    private static float millisecond = 0;
    private static bool isComplete = false;
    //是否自动销毁
    private static bool autoDestroy = false;
    private static Delay delay = null;
    private static System.Object param = null;

    /// <summary>
    /// 设置间隔
    /// </summary>
    /// <param name="targetGo">需要绑定此脚本的对象</param>
    /// <param name="millisecond">毫秒数</param>
    /// <param name="delayCompleteHandler">回调</param>
    /// <param name="autoDestroy">是否在结束时销毁脚本</param>
    /// <param name="param">需要在回调函数中获取的参数</param>
    /// <returns></returns>
    public static void setDelay(GameObject targetGo, 
                                float millisecond, 
                                DelayCompleteHandler delayCompleteHandler, 
                                bool autoDestroy = true, 
                                System.Object param = null)
    {
        if (targetGo == null) return;
        Delay.delay = targetGo.GetComponent<Delay>();
        if (Delay.delay == null) Delay.delay = targetGo.AddComponent<Delay>();
        Delay.isComplete = false;
        Delay.millisecond = millisecond;
        Delay.delayCompleteHandler = delayCompleteHandler;
        Delay.autoDestroy = autoDestroy;
        Delay.param = param;
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
                Delay.delayCompleteHandler.Invoke(Delay.param);
            if (Delay.autoDestroy)
            {
                //销毁
                GameObject.Destroy(Delay.delay);
                Delay.delay = null;
            }
        }
    }
}