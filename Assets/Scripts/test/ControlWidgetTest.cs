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
        float dx = Mathf.Cos(cw.controlRad) * this.speed * cw.controlRate;
        float dy = Mathf.Sin(cw.controlRad) * this.speed * cw.controlRate;

        img.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, cw.controlAngle - 90));
        ball.transform.localPosition += new Vector3(dx, dy);
    }
}
