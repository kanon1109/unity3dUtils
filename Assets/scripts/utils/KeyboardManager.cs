using System.Collections.Generic;
using UnityEngine;
public class KeyboardManager 
{
    //按键代理
    public delegate void HandlerDelegate();
    //根据key存放按下回调
    private static Dictionary<KeyCode, List<HandlerDelegate>> keyDownDict;
    //根据key存放弹起回调
    private static Dictionary<KeyCode, List<HandlerDelegate>> keyUpDict;

    /// <summary>
    /// 注册key
    /// </summary>
    /// <param name="key">按键值</param>
    /// <param name="handler">回调</param>
    /// <param name="type">是否是按下</param>
    /// <returns></returns>
    public static void registerKey(KeyCode key, HandlerDelegate handler, bool type)
    {
        if (keyUpDict == null) keyUpDict = new Dictionary<KeyCode, List<HandlerDelegate>>();
        if (keyDownDict == null) keyDownDict = new Dictionary<KeyCode, List<HandlerDelegate>>();
        List<HandlerDelegate> list;
        Dictionary<KeyCode, List<HandlerDelegate>> dict = type ? keyDownDict : keyUpDict;
        if (!dict.ContainsKey(key)) dict[key] = new List<HandlerDelegate>();
        list = dict[key];
        list.Add(handler);
    }

    /// <summary>
    /// 取消注册
    /// </summary>
    /// <param name="key">按键值</param>
    /// <param name="type">是否是按下</param>
    /// <returns></returns>
    public static void unregisterKey(KeyCode key, bool type)
    {
        Dictionary<KeyCode, List<HandlerDelegate>> dict = type ? keyDownDict : keyUpDict;
        if (!dict.ContainsKey(key)) return;
        List<HandlerDelegate> list = dict[key];
        list.Clear();
        dict.Remove(key);
    }

    /// <summary>
    /// 实时监听key
    /// </summary>
    /// <returns></returns>
    public static void updateKey()
    {
        List<KeyCode> keys = new List<KeyCode>(keyDownDict.Keys);
        foreach (KeyCode key in keys)
        {
            List<HandlerDelegate> list = keyDownDict[key];
            if (list != null && Input.GetKeyDown(key))
            {
                for (int i = list.Count - 1; i >= 0; --i)
                {
                    HandlerDelegate handler = list[i];
                    handler.Invoke();
                }
            }
        }

        keys = new List<KeyCode>(keyUpDict.Keys);
        foreach (KeyCode key in keys) 
        {
            List<HandlerDelegate> list = keyUpDict[key];
            if (list != null && Input.GetKeyUp(key))
            {
                for (int i = list.Count - 1; i >=0 ; --i)
                {
                    HandlerDelegate handler = list[i];
                    handler.Invoke();
                }
            }
        }
    }
	
    /// <summary>
    /// 销毁
    /// </summary>
    /// <returns></returns>
    public static void destroy()
    {
        keyUpDict.Clear();
        keyDownDict.Clear();
    }
}
