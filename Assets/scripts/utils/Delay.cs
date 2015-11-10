using UnityEngine;
//延迟工具
public class Delay : MonoBehaviour
{
    //回调
    public delegate void DelayCompleteHandler();
    private static DelayCompleteHandler delayCompleteHandler = null;
    private static float millisecond = 0;
    private static bool isComplete = false;
    //是否自动销毁
    private static bool autoDestroy = false;
    private static Delay delay = null;

    /// <summary>
    /// 设置间隔
    /// </summary>
    /// <param name="targetGo">需要绑定此脚本的对象</param>
    /// <param name="millisecond">毫秒数</param>
    /// <param name="delayCompleteHandler">回调</param>
    /// <param name="autoDestroy">是否在结束时销毁脚本</param>
    /// <returns></returns>
    public static void setDelay(GameObject targetGo, float millisecond, 
                                DelayCompleteHandler delayCompleteHandler, 
                                bool autoDestroy = true)
    {
        if (targetGo == null) return;
        Delay.delay = targetGo.GetComponent<Delay>();
        if (Delay.delay == null) Delay.delay = targetGo.AddComponent<Delay>();
        Delay.isComplete = false;
        Delay.millisecond = millisecond;
        Delay.delayCompleteHandler = delayCompleteHandler;
        Delay.autoDestroy = autoDestroy;
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
            if (Delay.autoDestroy)
            {
                //销毁
                GameObject.Destroy(Delay.delay);
                Delay.delay = null;
            }
        }
    }
}