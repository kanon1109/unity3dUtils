using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ControlWidgetTest:MonoBehaviour
{
    public ControlWidget cw;
    public Image img;
    public Image ball;
    private float speed = 3;

    void Start()
    {
        this.cw.setOnMouseMoveHandler(onMouseMoveHandler);
    }

    private void onMouseMoveHandler()
    {
        print("cw.controlAngle " + cw.controlRad);
        img.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, cw.controlAngle - 90));
        print("cw.controlDy " + cw.controlDy + "cw.controlDx " + cw.controlDx);
        float angle = Mathf.Atan2(cw.controlDy, cw.controlDx);
        float dx = Mathf.Cos(angle) * this.speed * cw.controlRate;
        float dy = Mathf.Sin(angle) * this.speed * cw.controlRate;
        ball.transform.localPosition += new Vector3(dx, dy);
    }
}
