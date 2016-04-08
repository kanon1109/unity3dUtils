using UnityEngine;
public class ColorUtil
{
    public const uint BLACK = 0xFF000000;
    public const uint BLUE = 0xFF0000FF;
    public const uint BROWN = 0xFFA52A2A;
    public const uint CYAN = 0xFF00FFFF;
    public const uint DARKGRAY = 0xFFA9A9A9;
    public const uint GRAY = 0xFF808080;
    public const uint GREEN = 0xFF008000;
    public const uint LIGHTGRAY = 0xFFD3D3D3;
    public const uint LIGHTGREEN = 0xFF00FF00;
    public const uint MAGENTA = 0xFFFF00FF;
    public const uint ORANGE = 0xFFFFA500;
    public const uint PURPLE = 0xFF800080;
    public const uint RED = 0xFFFF0000;
    public const uint TRANSPARENT = 0x00FFFFFF;
    public const uint WHITE = 0xFFFFFFFF;
    public const uint YELLOW = 0xFFFFFF00;
    public const uint GOLD = 0xFFD700;
    public const uint LIGHTBLUE = 0x208DC1;

    /// <summary>
    /// 16进制转换为颜色对象
    /// </summary>
    /// <param name="colorValue">16进制颜色</param>
    /// <returns>颜色对象</returns>
    public static Color uint2Color(uint colorValue)
    {
        uint b = colorValue & 0xff;
        uint g = (colorValue >> 8) & 0xff;
        uint r = (colorValue >> 16) & 0xff;
        uint a = (colorValue >> 24) & 0xff;
        if (a == 0) a = 0xff;
        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    /// <summary>
    /// 颜色对象转换为16进制
    /// </summary>
    /// <param name="color">颜色对象</param>
    /// <returns>16进制颜色</returns>
    public static uint color2Uint(Color color)
    {
        return (uint)(color.b) + ((uint)color.g << 8) + ((uint)color.r << 16) + ((uint)color.a << 24);
    }
}