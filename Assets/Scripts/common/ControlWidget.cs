using UnityEngine;
using UnityEngine.UI;
public class ControlWidget : MonoBehaviour
{
    //控制类型
    public enum fixedType
    {
        UNFIXED,   //不固定摇杆
        HALFFIXED, //半固定摇杆
        FIXED      //固定摇杆
    }
    //鼠标事件
    public delegate void OnMouseEventHandler();
    public OnMouseEventHandler onMouseMoveHandler = null;
    public OnMouseEventHandler onMouseDownHandler = null;
    public OnMouseEventHandler onMouseUpHandler = null;
    //摇杆图片
    public Image controlImage;
    //底座
    public Image baseboard;
    //是否按下
    private bool isDown = false;
    private RectTransform rt;
    //鼠标移动最大距离
    public float maxMoveDis = 20;
    //上一次的位置
    private float prevPosX = 0;
    private float prevPosY = 0;
    //当前的位置
    private float nowPosX = 0;
    private float nowPosY = 0;
    //角度
    private float angle;
    //摇杆输出的角度
    public float controlAngle
    {
        get { return angle * Mathf.Rad2Deg; }
    }
    //获取摇杆输出的弧度
    public float controlRad
    {
        get { return angle; }
    }
    //与上一次鼠标位置的差值
    private float dx;
    private float dy;
    //控制器的差值
    public float controlDx
    {
        get { return dx; }
    }
    public float controlDy
    {
        get { return dy; }
    }
    //控制类型
    public fixedType controlType = fixedType.FIXED;
    //是否设置移动比例（用于移动摇杆的速度控制移动快慢）
    public bool isSetRate = false;
    //摇杆移动比例
    private float rate = 0;
    public float controlRate
    {
        get { return rate; }
    }

    public void Start()
    {
        if (!this.isSetRate) this.rate = 1;
        this.rt = this.GetComponent<RectTransform>();
        EventTriggerListener.Get(this.gameObject).onDown = onDownHandler;
        EventTriggerListener.Get(this.gameObject).onUp = onUpHandler;
    }

    private void onUpHandler(GameObject go)
    {
        this.isDown = false;
        this.dx = 0;
        this.dy = 0;

        if (this.controlImage != null)
            this.controlImage.transform.localPosition = Vector3.zero;
        if (this.baseboard != null)
            this.baseboard.transform.localPosition = Vector3.zero;

        if (this.isSetRate) this.rate = 0;
        if (this.onMouseUpHandler != null)
            this.onMouseUpHandler.Invoke();
    }

    private void onDownHandler(GameObject go)
    {
        if (this.controlType == fixedType.UNFIXED ||
            this.controlType == fixedType.HALFFIXED)
        {
            this.prevPosX = Input.mousePosition.x;
            this.prevPosY = Input.mousePosition.y;
        }
        else
        {
            this.prevPosX = this.transform.position.x;
            this.prevPosY = this.transform.position.y;
        }
        this.isDown = true;
        //底座跟随鼠标
        if (this.baseboard != null)
            this.baseboard.transform.position = new Vector3(this.prevPosX, this.prevPosY);

        if (this.onMouseDownHandler != null)
            this.onMouseDownHandler.Invoke();
    }

    void FixedUpdate()
    {
        if (!this.isSetRate) this.rate = 1;
        if (this.isDown)
        {
            //通过鼠标一次update前后的坐标差 计算角度和距离，再用距离和角度算出新的位置
            //这种做法可以通过控制距离，来限制摇杆的移动范围。
            this.nowPosX = Input.mousePosition.x;
            this.nowPosY = Input.mousePosition.y;
            //计算上一次到当前的横纵移动距离
            this.dx = this.nowPosX - this.prevPosX;
            this.dy = this.nowPosY - this.prevPosY;
            //根据坐标差计算出鼠标角度
            this.angle = Mathf.Atan2(this.dy, this.dx);
            //计算距离
            float dis = Vector2.Distance(new Vector2(this.nowPosX, this.nowPosY), 
                                         new Vector2(this.prevPosX, this.prevPosY));
            //如果是固定摇杆或者半固定的
            if (this.controlType == fixedType.FIXED ||
                this.controlType == fixedType.HALFFIXED)
            {
                //如果超过最大距离
                if (dis > maxMoveDis) dis = maxMoveDis;
            }

            //计算出摇杆新的位置
            float x = Mathf.Cos(this.angle) * dis + prevPosX;
            float y = Mathf.Sin(this.angle) * dis + prevPosY;

            if (this.controlImage != null)
                this.controlImage.transform.position = new Vector3(x, y);

            //如果不固定摇杆，重新设置上一次位置
            if (this.controlType == fixedType.UNFIXED)
            {
                if (dis >= this.maxMoveDis)
                {
                    float sx = Mathf.Cos(this.angle) * this.maxMoveDis;
                    float sy = Mathf.Sin(this.angle) * this.maxMoveDis;
                    this.prevPosX = x - sx;
                    this.prevPosY = y - sy;

                    //底座跟随鼠标
                    if (this.baseboard != null)
                        this.baseboard.transform.position = new Vector3(this.prevPosX, this.prevPosY);
                }
            }

            if (this.isSetRate) 
                this.rate = dis / this.maxMoveDis;

            //调用移动回调
            if (this.onMouseMoveHandler != null)
                this.onMouseMoveHandler.Invoke();
        }
    }
}