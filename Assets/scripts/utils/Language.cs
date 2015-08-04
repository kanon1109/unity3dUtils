using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Linq;
using System.Collections;
//语言表 用于项目多语言
//xml格式如下：
/*<language>
	<!-- 系统提示 -->
	<test>恢复####点体力########</test>
	<welcome>欢迎来到掌三国</welcome>
	<alert_netClose>主公,您的网络不给力啦,请点击确定重返三国</alert_netClose>
	<alert_levelShort>主公,您的等级不足####级</alert_levelShort>
	<alert_fomation_levelMax>主公,该阵型等级已达上限</alert_fomation_levelMax>
	<recover_hp>恢复####点体力</recover_hp>
	<recover_mp>恢复####点精力</recover_mp>
</language>*/
class Language
{
    private static Dictionary<String, String> dict = null;

    /// <summary>
    /// 初始化语言表配置
    /// </summary>
    /// <param name=xmlFilePath>文件名称</param>
    /// <param name=rootNodeName>根节点名字</param>
    /// <returns></returns>
    public static void init(String xmlFileName)
    {
        if (dict == null)
        {
            TextAsset t = Resources.Load("cfg/" + xmlFileName) as TextAsset;
            MonoBehaviour.print(t);
            dict = new Dictionary<String, String>();
            var xe = XElement.Parse(t.text);
            var es = xe.Elements();
            foreach (var v in es)
            {
                dict[v.Name.LocalName] = v.Value;
            }
        }
    }

    /// <summary>
    /// 根据配置字段名称获取值
    /// </summary>
    /// <param name=key>字段名称</param>
    /// <returns></returns>
    public static String getValue(String key)
    {
        if (dict == null) return null;
        if (!dict.ContainsKey(key)) return key + "@error";
        return dict[key];
    }

    /// <summary>
    /// 根据配置字段名称获取值
    /// </summary>
    /// <param name=key>字段名称</param>
    /// <param name=obj>替换字符串中的占位符</param>
    /// <returns></returns>
    /// 使用格式 <test>恢复{0}点体力{1}</test> Language.getValue("test", "kanon", "tb");
    /// 打印：恢复kanon点体力tb
    public static String getValue(String key, params System.Object[] obj)
    {
        if (dict == null) return null;
        if (!dict.ContainsKey(key)) return key + "@error";
        String str = dict[key];
        return String.Format(str, obj);
    }
}
