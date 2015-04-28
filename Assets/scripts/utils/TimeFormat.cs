using System;
class TimeFormat
{

    /// <summary>
    /// 秒数转换为时间形式。
    /// </summary>
    /// <param name="time">秒数</param>
    /// <param name="partition">分隔符</param>
    /// <param name="showHour">是否显示小时</param>
    /// <returns>返回一个以分隔符分割的时, 分, 秒</returns>
    /// 比如: time = 4351; secondToTime(time)返回字符串01:12:31;
    public static String secondToTime(int time, String partition, bool showHour)
    {
        int hours = time / 3600;
        int minutes = time % 3600 / 60;
        int seconds = time % 3600 % 60;
        
        String h = hours.ToString();
        String m = minutes.ToString();
        String s = seconds.ToString();
        
        if (hours < 10)  h = "0" + h;
        if (minutes < 10) m = "0" + m;
        if (seconds < 10) s = "0" + s;
		
		String timeStr;
		if (showHour) timeStr = h + partition + m + partition + s;
		else timeStr = m + partition + s;
        return  timeStr;
    }

    /// <summary>
    /// 秒数转换为时间形式
    /// </summary>
    /// <param name="time">秒数</param>
    /// <returns>返回一个以分隔符分割的时, 分, 秒</returns>
    public static String secondToTime(int time)
    {
        return TimeFormat.secondToTime(time, ":", true);
    }

    /// <summary>
    /// 秒数转换为时间形式
    /// </summary>
    /// <param name="time">秒数</param>
    /// <param name="showHour">是否显示小时</param>
    /// <returns>返回一个以分隔符分割的时, 分, 秒</returns>
    public static String secondToTime(int time, bool showHour)
    {
        return TimeFormat.secondToTime(time, ":", showHour);
    }

    /// <summary>
    /// 时间形式转换为毫秒数。
    /// </summary>
    /// <param name="time">以指定分隔符分割的时间字符串</param>
    /// <param name="partition">分隔符</param>
    /// <returns>毫秒数显示的字符串</returns>
    /// MillisecondTransform.timeToMillisecond("00:60:00") 
    /// 3600000
    public static String timeToMillisecond(String time, Char partition)
    {
        string[] _ary = time.Split(new Char[] { partition });
        int timeNum = 0;
        int len = _ary.Length;
        for (int i = 0; i < len; i++)
        {
            int n = int.Parse(_ary[i]);
            timeNum += n * (int)Math.Pow(60, (len - 1 - i));
        }
        timeNum *= 1000;
        return timeNum.ToString();
    }
}
