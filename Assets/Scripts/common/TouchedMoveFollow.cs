using UnityEngine;
/// <summary>
/// 点击移动跟随
/// </summary>
public class TouchedMoveFollow:MonoBehaviour
{
    //是否初始化
    private bool isInt = false;
    //鼠标按下
    private bool isMouseDown = false;
    //鼠标位置x坐标
    private float mouseX;
    //鼠标位置y坐标
    private float mouseY;
    //鼠标位置z坐标（如果小于0 则会产生反向的方向）
    public float mouseZ = 10f;
    //需要跟随的对象
    public GameObject targetGo;
    //缓动系数
    public float ease = .04f;
    //是否作用到target z坐标上
    public bool usePosZ = true;
    /// <summary>
    /// 更新鼠标（点击后拖动）控制
    /// </summary>
    private void updateMouseControl()
    {
        if (!this.isInt)
        {
            this.mouseX = Input.mousePosition.x;
            this.mouseY = Input.mousePosition.y;
            this.isInt = true;
        }
        if (Input.GetMouseButtonDown(0)) this.isMouseDown = true;
        if (Input.GetMouseButtonUp(0)) this.isMouseDown = false;

        if (this.isMouseDown)
        {
            this.mouseX = Input.mousePosition.x;
            this.mouseY = Input.mousePosition.y;
        }

        if (this.targetGo != null)
        {
            Vector3 mousePos = new Vector3(this.mouseX,
                                           this.mouseY,
                                           this.mouseZ); //必须把z坐标带入才能转化世界坐标
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //缓动鼠标跟随公式
            float vx = (mousePos.x - this.targetGo.transform.localPosition.x) * this.ease;
            float vy = (mousePos.y - this.targetGo.transform.localPosition.y) * this.ease;
            float vz = vy;
            if (this.usePosZ) vy = 0;
            else vz = 0;
            this.targetGo.transform.localPosition = new Vector3(this.targetGo.transform.localPosition.x + vx,
                                                                this.targetGo.transform.localPosition.y + vy,
                                                                this.targetGo.transform.localPosition.z + vz);
        }
    }

    void Update()
    {
        this.updateMouseControl();
    }
}
