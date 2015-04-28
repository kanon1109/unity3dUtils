using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
/*<awakens>
	<awaken awakenNo="1" price="7999" probability="0.25" dropNo="70300001"/>
	<awaken awakenNo="2" price="9999" probability="0.25" dropNo="70300002"/>
	<awaken awakenNo="3" price="19999" probability="0.2" dropNo="70300003"/>
	<awaken awakenNo="4" price="39999" probability="0.1" dropNo="70300004"/>
	<awaken awakenNo="5" price="59999" probability="0" dropNo="70300005"/>
</awakens>*/
//适用于此类型的xml 根节点的名字和文件名相同，每一个节点的数据相同的xml。
//程序会将这个xml内部的字段名称映射到vo中的属性名称，并且赋值。
class XMLUtil
{
    /// <summary>
    /// 解析xml配置并放入list中
    /// </summary>
    /// <param name="xmlFilePath">包含路径的文件名称</param>
    /// <param name="rootNodeName">根节点名字</param>
    /// <returns>序列化后的存放数据的List</returns>
    public static List<T>parse<T>(String xmlFilePath, String rootNodeName)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFilePath);
        //节点列表
        XmlNodeList nodeList = doc.SelectNodes(rootNodeName);
        if (nodeList == null) return null;
        //创建列表
        List<T> list = new List<T>();
        List<String> attributesNameList = new List<String>();
        XmlNodeList childNodeList = nodeList.Item(0).ChildNodes;
        XmlNode firstNode = childNodeList.Item(0);
        XmlAttributeCollection attributes = firstNode.Attributes;
        int count = attributes.Count;
        //遍历属性名称放入list
        for(int i = 0; i < count; ++i)
        {
            attributesNameList.Add(attributes.Item(i).Name);
        }
        //遍历整个xml
        foreach (XmlNode node in childNodeList)
        {
             //new 这个泛型 
            T s = System.Activator.CreateInstance<T>();
            for(int i = 0; i < count; ++i)
            {
                //获取属性名称
                String name = attributesNameList[i];
                //根据字段名称设置某个对象内部的值
                XMLUtil.setObjectValue<T>(s, name, node.Attributes[name].Value);
            }
            list.Add(s);
        }
        return list;
    }

    /// <summary>
    /// 解析xml配置并放入Dictionary中
    /// </summary>
    /// <param name="xmlFilePath">包含路径的文件名称</param>
    /// <param name="rootNodeName">根节点名字</param>
    /// <param name="fieldname">做完key保存使用的字段名</param>
    /// <returns序列化后的存放数据的Dictionary></returns>
    public static Dictionary<String, T> parse<T>(String xmlFilePath, String rootNodeName, String fieldname)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFilePath);
        //节点列表
        XmlNodeList nodeList = doc.SelectNodes(rootNodeName);
        if (nodeList == null) return null;
        //创建列表
        Dictionary<String, T> dict = new Dictionary<String, T>();
        List<String> attributesNameList = new List<String>();
        XmlNodeList childNodeList = nodeList.Item(0).ChildNodes;
        XmlNode firstNode = childNodeList.Item(0);
        XmlAttributeCollection attributes = firstNode.Attributes;
        int count = attributes.Count;
        //遍历属性名称放入list
        for (int i = 0; i < count; ++i)
        {
            attributesNameList.Add(attributes.Item(i).Name);
        }
        //遍历整个xml
        foreach (XmlNode node in childNodeList)
        {
            //new 这个泛型 
            T s = System.Activator.CreateInstance<T>();
            String key = null;
            for (int i = 0; i < count; ++i)
            {
                //获取属性名称
                String name = attributesNameList[i];
                if (name == fieldname) key = node.Attributes[name].Value;
                //根据字段名称设置某个对象内部的值
                XMLUtil.setObjectValue<T>(s, name, node.Attributes[name].Value);
            }
            try
            {
                 //根据字段名称取到的值作为key 保存vo对象
                 dict.Add(key, s);
            }
            catch
            {
                throw new ArgumentException("找不到key");
            }
        }
        return dict;
    }

    /// <summary>
    /// 根据字段名称设置某个对象内部的值
    /// </summary>
    /// <param name="obj">需要赋值的对象</param>
    /// <param name="fieldname">字段名称</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public static void setObjectValue<T>(T obj, String fieldname, object value)
    {
        FieldInfo info = obj.GetType().GetField(fieldname);
        if (info != null)
        {
            if (info.FieldType.Equals(typeof(Int32)) &&
                value.GetType().Equals(typeof(String)))
            {
                //如果字段的类型是int，而值的类型是string 则强转
                info.SetValue(obj, int.Parse((String)value));
            }
            else if (info.FieldType.Equals(typeof(Single)) &&
                     value.GetType().Equals(typeof(String)))
            {
                //如果字段的类型是float，而值的类型是string 则强转
                info.SetValue(obj, float.Parse((String)value));
            }
            else
            {
                info.SetValue(obj, value);
            }
        }
    }
}
