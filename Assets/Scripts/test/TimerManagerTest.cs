using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerManagerTest : MonoBehaviour
{
    public Button btn;
    // Use this for initialization
    void Start()
    {
        TimerVo tVo = new TimerVo();
        tVo.leftSecond = 300;
        tVo.addCallBackHandler(test1Handler);
        TimerManager.getInstance.addTimer("time1", tVo);

        tVo = new TimerVo();
        tVo.leftSecond = 100;
        tVo.addCallBackHandler(test2Handler);
        TimerManager.getInstance.addTimer("time2", tVo);

        btn.onClick.AddListener(btnClickHandler);
    }

    private void test1Handler()
    {
        print("test1");
    }

    private void test2Handler()
    {
        print("test2");
    }

    private void btnClickHandler()
    {
        //TimerManager.getInstance.clear();
        TimerManager.getInstance.finishTimer("time1");
    }

    // Update is called once per frame
    void Update()
    {
        TimerVo tVo = TimerManager.getInstance.getTimer("time1");
        if (tVo != null) print("time1 leftSecond" + tVo.leftSecond);

        tVo = TimerManager.getInstance.getTimer("time2");
        if (tVo != null) print("time2 leftSecond" + tVo.leftSecond);

    }

}
