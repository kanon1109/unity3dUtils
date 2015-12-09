using System;
using UnityEngine;

public class DateUtilTest : MonoBehaviour
{
    //DateUtil.getDateByMillisecond();
    void Start()
    {
        DateTime dt = DateUtil.getDateByMillisecond(973011661000);
        DateTime dt2 = DateUtil.getDateBySecond(973011661);
        print("dt " + dt.ToLocalTime().ToString());
        print("dt2 " + dt2.ToLocalTime().ToString());
        print("getCurTimeStamp 当前时间戳 " + DateUtil.getCurTimeStamp());
        print("getDaysInCurMonth 当前月份天数 " + DateUtil.getDaysInCurMonth());
        print("getDiffDaysByMillisecond false 天数差 " + DateUtil.getDiffDaysByMillisecond(973007940000, 973011661000));
        print("getDiffDaysByMillisecond true 天数差 " + DateUtil.getDiffDaysByMillisecond(973007940000, 973011661000, true));
    }

    // Update is called once per frame
    void Update()
    {

    }
}