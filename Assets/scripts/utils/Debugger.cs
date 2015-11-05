using UnityEngine;
using System.Collections;

public class Debugger
{
    private static bool showLog = true;
    /// <summary>
    /// 非主线程使用
    /// </summary>
    public static void LogOther(object msg)
    {
        if (showLog)
        {
            Debug.Log(msg);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static void LogWarningFormat(string format, params object[] args)
    {
        if (Debug.isDebugBuild && showLog)
        {
            Debug.LogWarningFormat(format, args);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static void LogWarning(object msg)
    {
        if (Debug.isDebugBuild && showLog)
        {
            Debug.LogWarning(msg);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static void LogErrorFormat(string format, params object[] args)
    {
        if (Debug.isDebugBuild && showLog)
        {
            Debug.LogErrorFormat(format, args);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static void LogError(object msg)
    {
        if (Debug.isDebugBuild && showLog)
        {
            Debug.LogError(msg);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static void LogFormat(string format, params object[] args)
    {
        if (Debug.isDebugBuild && showLog)
        {
            Debug.LogFormat(format, args);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="msg"></param>
    public static void Log(object msg)
    {
        if (Debug.isDebugBuild && showLog)
        {
            Debug.Log(msg);
        }
    }
}
