using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;
class RandomName
{
    private static List<String> firstNameAry = null;
    private static List<String> lastNameAry = null;

    /// <summary>
    /// 初始化命名表配置
    /// </summary>
    /// <param name=xmlFilePath>xml路径+名字</param>
    /// <param name=rootNodeName>根节点名字</param>
    /// <returns></returns>
    public static void init(String xmlFilePath, String rootNodeName)
    {
        if(firstNameAry == null)
        {
            firstNameAry = new List<String>();
            lastNameAry = new List<String>();
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
                for(int i = 0; i < node.Attributes.Count; ++i)
                {
                    if(node.Attributes.Item(i).Name.Equals("prefixName"))
                      firstNameAry.Add(node.Attributes.Item(i).Value);
                    if(node.Attributes.Item(i).Name.Equals("postfixName"))
                      lastNameAry.Add(node.Attributes.Item(i).Value);
                }
            }
        }
    }

    /// <summary>
    /// 获取随机名称
    /// </summary>
    /// <returns></returns>
    public static String getRandomName()
    {
        int index = UnityEngine.Random.Range(0, lastNameAry.Count - 1);
        String lastName = lastNameAry[index];
        index = UnityEngine.Random.Range(0, firstNameAry.Count - 1);
        String firstName = firstNameAry[index];
        return firstName + lastName;
    }
}