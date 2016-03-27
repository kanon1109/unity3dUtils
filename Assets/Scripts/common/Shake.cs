using System.Collections.Generic;
using UnityEngine;
public class Shake : MonoBehaviour
{
    //定义相机的震幅
    private float shakeDelta;
    //震动间隔
    private float delay;
    //震动对象
    private GameObject shakeTarget = null;
    //原始位置
    private Vector3 originPosition;

    /// <summary>
    /// 震动
    /// </summary>
    /// <param name=target>震动对象</param>
    /// <param name=delay>震动间隔</param>
    /// <param name=shakeDelta>震动幅度</param>
    /// <returns></returns>
    public void shake(GameObject target, float delay = 0.3f, float shakeDelta = 20.0f)
    {
        this.originPosition = target.transform.position;
        this.delay = delay;
        this.shakeDelta = shakeDelta;
        this.shakeTarget = target;
    }

    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                delay = 0;
                shakeTarget.transform.position = originPosition;
            }
            else
            {
                shakeTarget.transform.position = new Vector3(originPosition.x - shakeDelta * Random.value,
                                                             originPosition.y - shakeDelta * Random.value);
            }
        }
    }
}