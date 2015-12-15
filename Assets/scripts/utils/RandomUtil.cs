using System.Collections.Generic;
using UnityEngine;
public class RandomUtil
{
    /// <summary>
    /// 在 start 与 stop之间取一个随机整数，可以用step指定间隔， 但不包括较大的端点（start与stop较大的一个）
    /// Random.randrange(1, 10, 3) 
    /// 则返回的可能是   1 或  4 或  7  , 注意 这里面不会返回10，因为是10是大端点
    /// </summary>
    /// <param name="start"></param>
    /// <param name="stop"></param>
    /// <param name="step"></param>
    /// <returns>假设 start < stop,  [start, stop) 区间内的随机整数</returns>
    public static int randrange(int start, int stop, int step)
    {
        if (step <= 0)
            throw new System.Exception("step 不能为 0");
            
        int width = stop - start;
        if (width == 0)
            throw new System.Exception("没有可用的范围(" + start + "," + stop + ")");
        if (width < 0)
            width = start - stop;
        int n = (int)((width + step - 1) / step);
        return (int)(random() * n) * step + System.Math.Min(start, stop);
    }

    /// <summary>
    /// 返回a 到 b直间的随机整数，包括 a 和 b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>[a, b] 直接的随机整数</returns>
    public static int randint(int a, int b)
    {
        return Random.Range(a, b + 1);
    }

    /// <summary>
    /// 打乱列表
    /// </summary>
    /// <param name="list">列表指针</param>
    /// <returns></returns>
    public static void shuffle<T>(ref List<T> list)
    {
        int size = list.Count;
        System.Random random = new System.Random();
        for (int i = 0; i < size; i++)
        {
            // 获取随机位置
            int randomPos = random.Next(size);
            // 当前元素与随机元素交换
            T temp = list[i];
            list[i] = list[randomPos];
            list[randomPos] = temp;
        }
    }

    /// <summary>
    /// 从序列中随机取一个元素
    /// </summary>
    /// <param name="list">列表</param>
    /// <returns></returns>
    public static T choice<T>(List<T> list)
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }

    /// <summary>
    ///  对列表中的元素进行随机采样
    ///  Random.sample([1, 2, 3, 4, 5],  3)  // Choose 3 elements
    ///  [4, 1, 5]
    /// </summary>
    /// <param name="list"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public static List<T> sample<T>(List<T> list, uint num)
    {
        int len = list.Count;
        if (num <= 0 || len < num)
            throw new System.Exception("采样数量不够");
        //最终输出的list
        List<T> selected = new List<T>();
        //存放已经放入元素的索引的list
        List<int> indices = new List<int>();
        for (int i = 0; i < num; ++i)
        {
            int index = Random.Range(0, len);
            while (indices.IndexOf(index) >= 0)
                index = Random.Range(0, len);
            selected.Add(list[index]);
            indices.Add(index);
        }
        return selected;
    }

    /// <summary>
    ///  对列表中的元素进行随机采样
    ///  Random.sample([1, 2, 3, 4, 5],  3)  // Choose 3 elements
    ///  [4, 1, 5]
    /// </summary>
    /// <param name="list">需要采样的列表</param>
    /// <param name="num">采样数量</param>
    /// <param name="ignoreList">忽略列表</param>
    /// <returns></returns>
    public static List<T> sample<T>(List<T> list, uint num, List<T> ignoreList)
    {
        int len = list.Count;
        if (num <= 0 || len < num)
            throw new System.Exception("采样数量不够");
        //最终输出的list
        List<T> selected = new List<T>();
        //存放已经放入元素的索引的list
        List<int> indices = new List<int>();
        for (int i = 0; i < num; ++i)
        {
            int index = Random.Range(0, len);
            while (indices.IndexOf(index) >= 0 || (ignoreList != null &&
                                                   ignoreList.IndexOf(list[index]) >= 0))
                index = Random.Range(0, len);
            selected.Add(list[index]);
            indices.Add(index);
        }
        return selected;
    }

    /// <summary>
    /// 返回 a - b之间的随机数，不包括  Math.max(a, b)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>假设 a < b, [a, b)</returns>
    public static float randnum(float a, float b)
    {
        return random() * (b - a) + a;
    }

    /// <summary>
    /// 随机
    /// </summary>
    /// <returns></returns>
    public static float random()
    {
        return Random.Range(0.0f, 1.0f);
    }

	/// <summary>
	/// 计算是否抵达概率
	/// </summary>
    /// <param name="chance">chance 概率</param>
	/// <returns></returns>
	public static bool boolean(float chance = .5f)
	{
        return (random() < chance) ? true : false;
	}
}