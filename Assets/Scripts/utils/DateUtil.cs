using System;
public class DateUtil
{
    /// <summary>
    /// 根据毫秒数 获取date数据对象
    /// </summary>
    /// <param name="millisecond">毫秒数</param>
    /// <returns>时间对象</returns>
    public static DateTime getDateByMillisecond(long millisecond)
    {
        return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddMilliseconds((double)millisecond);
    }

    /// <summary>
    /// 根据毫秒数 获取date数据对象
    /// </summary>
    /// <param name="second">秒数</param>
    /// <returns>时间对象</returns>
    public static DateTime getDateBySecond(long second)
    {
        return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)second);
    }

    /// <summary>
    /// 根据2个时间戳计算出2个时间段相差的天数
    /// </summary>
    /// <param name="prevMillisecond">上一个时间段的毫秒数</param>
    /// <param name="nextMillisecond">下一个时间段的毫秒数</param>
    /// <param name="actual">如果为true 会根据2个时间戳相减得出的毫秒计算出这个毫秒所占据的天数 
    /// 如果为false 会计算2个从1970年开始到这个时间戳所有的天数并且相减 （比如 2015,12,9,23:59 和 2015,12,10,0:01 之间相差为2天）</param>
    /// <returns>相差天数</returns>
    public static int getDiffDaysByMillisecond(long prevMillisecond, long nextMillisecond, bool actual = false)
    {
        DateTime dt1 = DateUtil.getDateByMillisecond(prevMillisecond);
        DateTime dt2 = DateUtil.getDateByMillisecond(nextMillisecond);
        int diffDay;
        if (!actual)
            diffDay = (dt2 - dt1.Date).Days;
        else
            diffDay = (dt2 - dt1).Days;
        return diffDay;
    }

    /// <summary>
    /// 获取当前月份中的天数
    /// </summary>
    /// <returns>天数</returns>
    public static int getDaysInCurMonth()
    {
        DateTime dtNow = DateTime.Now;
        return DateTime.DaysInMonth(dtNow.Year ,dtNow.Month);
    }

    /// <summary>  
    /// 获取当前时间戳
    /// </summary>  
    /// <returns>毫秒数</returns>  
    public static long getCurTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds);
    }
}