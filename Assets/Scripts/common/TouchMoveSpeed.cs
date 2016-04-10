using UnityEngine;
/// <summary>
/// 判断鼠标（移动平台点击屏幕后滑动的速度）移动速度工具
/// </summary>
public class TouchMoveSpeed : MonoBehaviour
{
    private Vector2 prevPos = new Vector2();
    private bool isDown = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.isDown = true;
            this.prevPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
            this.isDown = false;

        if (this.isDown)
        {
            float speedX = Mathf.Abs(Input.mousePosition.x - this.prevPos.x);
            float speedY = Mathf.Abs(Input.mousePosition.y - this.prevPos.y);
            float speed = speedX + speedY;
            this.prevPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Debug.Log(speed);
        }
    }
}