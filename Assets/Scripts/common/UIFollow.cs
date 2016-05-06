using UnityEngine;
using System.Collections;
/// <summary>
/// 2d ui跟随3d 对象（例血条跟随角色） 
/// </summary>
public class UIFollow : MonoBehaviour
{
    //跟随的目标
    public Transform targetTransform;
    //ui
    public Transform uiTransform;
    //偏移
    public Vector2 offset = Vector2.zero;
    //目标与摄像机的前后距离
    private float disZ;
    // Use this for initialization
    void Start()
    {
        if (this.targetTransform == null || this.uiTransform == null) return;
        this.disZ = Mathf.Abs(this.targetTransform.position.z - Camera.main.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.targetTransform == null || this.uiTransform == null) return;
        float newDisZ = this.disZ / Mathf.Abs(this.targetTransform.position.z - Camera.main.transform.position.z);
        Vector2 newOffset = new Vector2(this.offset.x * newDisZ, this.offset.y * newDisZ);
        this.uiTransform.localScale = Vector3.one * newDisZ;
        Vector3 newPos = Camera.main.WorldToScreenPoint(this.targetTransform.position);
        this.uiTransform.position = new Vector3(newPos.x + newOffset.x, newPos.y + newOffset.y, 0f);
    }
}
