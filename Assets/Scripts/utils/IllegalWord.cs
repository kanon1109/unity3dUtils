using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
class IllegalWord
{
    //存放关键字的字典
    private static List<String> list = null;

    /// <summary>
    /// 初始化语言表配置
    /// </summary>
    /// <param name=xmlFileName>文件名称</param>
    /// <param name=rootNodeName>根节点名字</param>
    /// <returns></returns>
    public static void init(String xmlFileName)
    {
        if (list == null)
        {
            TextAsset t = Resources.Load("cfg/" + xmlFileName) as TextAsset;
            list = new List<String>();
            var xe = XElement.Parse(t.text);
            var es = xe.Elements();
            foreach (var v in es)
            {
                list.Add(v.Attribute("name").Value);
            }
        }
    }


    /// <summary>
    /// 过滤关键字
    /// </summary>
    /// <param name=target>目标字符串</param>
    /// <returns>过滤后的字符串</returns>
    public static String filter(String target)
    {
        if (list != null)
        {
            int count = list.Count;
            String keyWordStr = "";
            for (int i = 0; i < count; ++i)
            {
                keyWordStr = list[i];
                target = target.Replace(keyWordStr, "**");
            }
        }
        return target;
    }

    /// <summary>
    /// 是否包含关键字
    /// </summary>
    /// <param name=target>目标字符串</param>
    /// <returns>是否包含</returns>
    public static bool hasKeyWord(String target)
    {
        if (list == null) return false;
        int count = list.Count;
        String keyWordStr = "";
        for (int i = 0; i < count; ++i)
        {
            keyWordStr = list[i];
            if (target.IndexOf(keyWordStr) != -1)
            {
                return true;
            }
        }
        return false;
    }
}
