using System;
class StringUtil
{
    /// <summary>
    /// 是否是空白字符串
    /// </summary>
    /// <param name="str">目标字符串</param>
    /// <returns>返回该字符是否为空白字符</returns>
    public static bool isWhiteSpace(String str)
    {
        if (str == " " || 
            str == "\t" || 
            str == "\r" || 
            str == "\n")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 翻转字符串
    /// </summary>
    /// <param name="str">目标字符串</param>
    /// <returns></returns>
    public static String reverse(String str)
    {
        if (str.Length > 1) return reverse(str.Substring(1)) + str.Substring(0, 1);  
        else return str;
	}

    /// <summary>
    /// 给数字字符前面添 "0"
    /// </summary>
    /// <param name="str">要进行处理的字符串</param>
    /// <param name="width">处理后字符串的长度，如果str.length >= width，将不做任何处理直接返回原始的str。</param>
    /// <returns></returns>
    /// StringFormat.zfill('1')     01
    /// StringFormat.zfill('16', 5) 00016
    /// StringFormat.zfill('-3', 3) -03
    public static String zfill(String str, int width)
    {
        if( str == null || str == "") return str;
        
        int slen = str.Length;
        if( slen >= width ) return str;
        
        bool negative = false;
        if( str.Substring(0, 1) == "-" ) 
        {
            negative = true;
            str = str.Substring(1);
        }
        
        int len = width - slen;
        for( int i = 0; i < len; i++ )
        {
            str = '0' + str;
        }
        
        if( negative )
        {
            str = '-' + str;
        }
        return str;
    }
}
