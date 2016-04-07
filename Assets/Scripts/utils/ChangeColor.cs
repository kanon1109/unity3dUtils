using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 切换颜色工具
/// </summary>
public class ChangeColor : MonoBehaviour
{
    //切换间隔
    public int fps = 30;
    //间隔
    private float delay = 0;
    //当前间隔
    private float curDelay = 0;
    //颜色数组
    public Color[] colorSet = new Color[] { Color.white, Color.red, Color.green, Color.blue };
    //材质列表
    private List<Material> matList = new List<Material>();
    //颜色的数量
    private int colorCount = 0;
    //当前颜色索引
    private int fromIndex = 0;
    //过度颜色索引
    private int toIndex = 1;
    //0到1之间的值。当lerpT是0时返回颜色colorSet[fromIndex]。当lerpT是1时返回颜色colorSet[fromIndex]。
    private float lerpT = 0.0f;
    private float lerpSwitch = 1.0f;
    void Start()
    {
        this.colorCount = this.colorSet.Length;
        this.delay = 1.0f / (float)this.fps;
        this.curDelay = 0;
        this.fromIndex = 0;
        this.toIndex = 1;
    }
    /// <summary>
    /// 添加需要变色的材质
    /// </summary>
    /// <param name="mat">材质</param>
    public void addMaterial(Material mat)
    {
        this.matList.Add(mat);
    }

    void Update()
    {
        if (this.matList.Count > 0 && this.colorCount > 1)
        {
            this.curDelay += Time.deltaTime;
            if (this.curDelay >= this.delay)
            {
                this.curDelay = 0f;
                //变色
                int count = this.matList.Count;
                for (int i = 0; i < count; i++)
                {
                    //计算出2个颜色中间的颜色值
                    Color newColor = Color.Lerp(this.colorSet[this.fromIndex],
                                                this.colorSet[this.toIndex],
                                                this.lerpT);
                    this.matList[i].SetColor("_Color", newColor);
                    this.lerpT += this.lerpSwitch * Time.deltaTime;
                    if (this.lerpT >= this.lerpSwitch)
                    {
                        this.lerpT = 0.0f;
                        this.updateIndex();
                    }
                }
            }
        }
    }

    /// <summary>
    /// 更新颜色索引
    /// </summary>
    private void updateIndex()
    {
        this.toIndex++;
        if (this.toIndex == this.colorCount)
            this.toIndex = 0;

        this.fromIndex = this.toIndex - 1;
        if (this.fromIndex < 0)
            this.fromIndex = this.colorCount - 1;
    }
}