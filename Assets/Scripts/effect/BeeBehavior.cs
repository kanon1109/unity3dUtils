using System.Collections.Generic;
using UnityEngine;
public class BeeBehavior : MonoBehaviour
{
    private List<Bee> list; 
	//随机范围
	private float rangeX;
    private float rangeY;
    private float rangeZ;
	//摩擦力
	private float friction = .96f;

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="rangeX">x范围</param>
    /// <param name="rangeY">y范围</param>
    public void init(float rangeX, float rangeY, float rangeZ)
	{
		this.rangeX = rangeX;
        this.rangeY = rangeY;
        this.rangeZ = rangeZ;
        this.list = new List<Bee>();
	}

    /// <summary>
    /// 添加蜜蜂
    /// </summary>
    /// <param name="bee">蜜蜂对象</param>
	public void addBee(Bee bee)
	{
        if (this.list.IndexOf(bee) == -1)
            this.list.Add(bee);
	}
    
    /// <summary>
    /// 销毁一个蜜蜂对象
    /// </summary>
    /// <param name="bee">蜜蜂对象</param>
    public void removeBee(Bee bee)
    {
        if(bee == null) return;
        if (this.list == null) return;
        int index = this.list.IndexOf(bee);
        if(index == -1) return;
        this.list.RemoveAt(index);
        GameObject.Destroy(bee.gameObject);
        bee = null;
    }

    /// <summary>
    /// 主循环
    /// </summary>
    void Update()
    {
        if (this.list == null) return;
        int count = this.list.Count;
        for(int i = 0; i < count; ++i)
        {
            Bee bee = this.list[i];
            if(bee != null)
            {
                bee.vx += Random.Range(0f, 1f) * this.rangeX - this.rangeX * .5f;
                bee.vy += Random.Range(0f, 1f) * this.rangeY - this.rangeY * .5f;
                bee.vz += Random.Range(0f, 1f) * this.rangeZ - this.rangeZ * .5f;
                bee.transform.localPosition = new Vector3(bee.transform.localPosition.x + bee.vx, 
                                                          bee.transform.localPosition.y + bee.vy,
                                                          bee.transform.localPosition.z + bee.vz);
                bee.vx *= this.friction;
                bee.vy *= this.friction;
                bee.vz *= this.friction;
            }
        }
    }

    /// <summary>
    /// 销毁
    /// </summary>
    public void destroy()
    {
        if (this.list == null) return;
        int count = this.list.Count;
        for(int i = count - 1; i >= 0; --i)
        {
            Bee bee = this.list[i];
            GameObject.Destroy(bee.gameObject);
        }
        this.list.Clear();
        this.list = null;
    }
}
