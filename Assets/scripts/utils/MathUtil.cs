using System;
using System.Collections.Generic;
using System.Reflection;
class MathUtil
{
    /// <summary>
    /// 弧度转换成角度  radians -> degrees
    /// </summary>
    /// <param name="radians">弧度</param>
    /// <returns>相应的角度</returns>
    public static double rds2dgs(float radians)
    {
        return fixAngle(radians * 180 / Math.PI);
    }

    /// <summary>
    /// 角度转换成弧度 degrees -> radians
    /// </summary>
    /// <param name="degrees">角度</param>
    /// <returns>弧度</returns>
    public static double dgs2rds(float degrees)
    {
        return degrees * Math.PI / 180;
    }

    /// <summary>
    /// 该方法详情可查看 《Flash MX 编程与创意实现》的第69页。
    /// 标准化角度值，将传入的角度值返回成一个确保落在 0 ~ 360 之间的数字。
    /// </summary>
    /// <param name="angle">需要转换的角度</param>
    /// <returns></returns>
    /// MathUtil.fixAngle(380); // 返回 20
    /// MathUtil.fixAngle(-340); // 返回 20
    public static double fixAngle(double angle)
    {
        angle %= 360;
        if (angle < 0) return angle + 360;
        return angle;
    }


    /// <summary>
    /// 修正数字 在一个范围内
    /// </summary>
    /// <param name="num">需要修正的数字</param>
    /// <param name="min">最小的范围</param>
    /// <param name="range">最大范围</param>
    /// <returns>修正后的数字</returns>
    public static double fixNumber(float num, float min, float range)
	{
		num %= range;
        if (num < min) return num + range;
        return num;
	}

    /// <summary>
    /// 修正半角
    /// </summary>
    /// <param name="angle">需要修正的角度</param>
    /// <returns>修正半角后的角度</returns>
    public static double fixHalfAngle(double angle)
    {
        angle %= 180;
        if (angle < 0) return angle + 180;
        return angle;
    }

    /// <summary>
    /// 求取阶乘
    /// </summary>
    /// <param name="num">需要求阶乘的数字</param>
    /// <returns></returns>
    /// MathUtil.getFactorial(4) = 4 * 3 * 2 * 1 = 24
    public static uint getFactorial(uint num)
    {
        if(num == 0) return 1;
        return num * getFactorial(num - 1);
    }

    /// <summary>
    /// 返回参数mainNum除以divided的余数
    /// </summary>
    /// <param name="mainNum"></param>
    /// <param name="divided"></param>
    /// <returns>返回参数mainNum除以divided的余数</returns>
    public static int getRemainedNum(int mainNum, int divided)
    {
        return mainNum - ((mainNum / divided) >> 0) * divided;
    }

	/// <summary>
    /// 得到num除以divided后得到的余数
	/// </summary>
	/// <param name="num"></param>
	/// <param name="divided"></param>
	/// <returns></returns>
	public static int isEvenByDivided(int num, int divided)
	{
		return num & (divided - 1);
	}

    /// <summary>
    /// 判断参数num是否是偶数
    /// </summary>
    /// <param name="num">需要判断的数</param>
    /// <returns>是否是偶数</returns>
    public static bool isEven(int num)
	{
        return isEvenByDivided(num, 2) == 0 ? true : false;
	}


    /// <summary>
    /// 斜率公式
    /// </summary>
    /// <param name="x1">x1 坐标点1x坐标</param>
    /// <param name="y1">y1 坐标点1y坐标</param>
    /// <param name="x2">x2 坐标点2x坐标</param>
    /// <param name="y2">y2 坐标点2y坐标</param>
    /// <returns>相应的斜率</returns>
    public static float getSlope(float x1, float y1, float x2, float y2)
    {
		return (y1 - y2) / (x1 - x2);
    }

    /// <summary>
    /// 余弦公式
    /// CosC=(a^2+b^2-c^2)/2ab
    /// CosB=(a^2+c^2-b^2)/2ac
    /// CosA=(c^2+b^2-a^2)/2bc 
    /// 已知3边求出某边对应的角的角度
    /// </summary>
    /// <param name="a">a 边</param>
    /// <param name="b">b 边</param>
    /// <param name="c">c 边</param>
    /// <returns>一个对象包含三个对应的角度</returns>
    public static List<double> threeSidesMathAngle(float a, float b, float c)
	{
		float cosA = (c * c + b * b - a * a) / (2 * b * c);
		double A = Math.Round(MathUtil.rds2dgs((float)Math.Acos(cosA)));
		
		float cosB = (a * a + c * c - b * b) / (2 * a * c);
		double B = Math.Round(MathUtil.rds2dgs((float)Math.Acos(cosB)));
		
		float cosC = (a * a + b * b - c * c) / (2 * a * b);
		double C = Math.Round(MathUtil.rds2dgs((float)Math.Acos(cosC)));

        List<double> list = new List<double>();
        list.Add(A);
        list.Add(B);
        list.Add(C);
        return list;
	}

    /// <summary>
    /// 正弦公式
    /// a/sinA=b/sinB=c/sinC=2R
    /// 已知一个角度以及角度对应的边长 可以求出三角外接圆半径R的2倍
    /// </summary>
    /// <param name="angle">弧度</param>
    /// <param name="line">弧度应的变长</param>
    /// <returns>三角外接圆半径R</returns>
    public static double sineLaw(float angle, float line)
    {
        return line / Math.Sin(angle) / 2;
    }

    /// <summary>
    /// 坐标旋转公式
    /// </summary>
    /// <param name="cx">中心点x坐标</param>
    /// <param name="cy">中心点y坐标</param>
    /// <param name="x">需要旋转的物体的x坐标</param>
    /// <param name="y">需要旋转的物体的y坐标</param>
    /// <param name="sin">sin(旋转角度)</param>
    /// <param name="cos">cos(旋转角度)</param>
    /// <param name="reverse">是否逆时针旋转</param>
    /// <returns>旋转后坐标</returns>
    public static List<float> rotate(float cx, float cy, float x, float y, float sin, float cos, bool reverse)
	{
		float px;
        float py;
		float dx = x - cx;
		float dy = y - cy;
		if (reverse) 
		{
			px = dx * cos + dy * sin + cx;
            py = dy * cos - dx * sin + cy;
		}
		else 
		{
            px = dx * cos - dy * sin + cx;
            py = dy * cos + dx * sin + cy;
		}
        List<float> list = new List<float>();
        list.Add(px);
        list.Add(py);
        return list;
	}

    /// <summary>
    /// 计算距离
    /// </summary>
    /// <param name="x1">点1的x坐标</param>
    /// <param name="y1">点1的y坐标</param>
    /// <param name="x2">点2的x坐标</param>
    /// <param name="y2">点2的y坐标</param>
    /// <returns></returns>
    public static double distance(float x1, float y1, float x2, float y2)
	{
		return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
	}

    /// <summary>
    /// 获取角度象限值
    /// </summary>
    /// <param name="angle">角度</param>
    /// <returns>象限值</returns>
    public static uint getAngleQuadrant(double angle)
	{
		angle = MathUtil.fixAngle(angle);
		if (angle >= 0 && angle < 90) return 1;
		if (angle >= 90 && angle < 180) return 2;
		if (angle >= 180 && angle < 270) return 3;
		return 4;
	}
}
