using UnityEngine;
public class DeviceUtils
{
    private static string deviceID = null;

    //初始化标记 所有数据只取一次
    private static bool deviceIDInitialized = false;

    /// <summary>
    /// 获取设备ID
    /// </summary>
    /// <returns></returns>
    public static string GetDeviceID()
    {
        if (deviceIDInitialized)
        {
            return deviceID;
        }
        deviceID = SystemInfo.deviceUniqueIdentifier;
        deviceIDInitialized = true;
        return deviceID;
    }

}
