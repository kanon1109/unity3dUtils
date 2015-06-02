using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
class IllegalWord
{
    //存放关键字的字典
    private static List<String> list = null;

    /// <summary>
    /// 初始化语言表配置
    /// </summary>
    /// <param name=xmlFilePath>文件路径 + 名称</param>
    /// <param name=rootNodeName>根节点名字</param>
    /// <returns></returns>
    public static void init(String xmlFilePath, String rootNodeName)
    {
        if (list == null)
        {
            list = new List<String>();
            XmlReaderSettings settings = new XmlReaderSettings();
            //忽略注释
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(xmlFilePath, settings);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            //节点列表
            XmlNodeList nodeList = doc.SelectNodes(rootNodeName);
            if (nodeList == null) return;
            XmlNodeList childNodeList = nodeList.Item(0).ChildNodes;
            //遍历整个xml
            foreach (XmlNode node in childNodeList)
            {
                list.Add(node.Attributes.Item(0).Value);
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
