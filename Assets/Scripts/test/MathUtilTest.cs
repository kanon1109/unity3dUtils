using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MathUtilTest : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        print("MathUtil.dgs2rds " + MathUtil.dgs2rds(90));
        print("MathUtil.rds2dgs " + MathUtil.rds2dgs(Mathf.PI));
        print("MathUtil.fixAngle " + MathUtil.fixAngle(390));
        print("MathUtil.getFactorial " + MathUtil.getFactorial(4));
        print("MathUtil.getRemainedNum " + MathUtil.getRemainedNum(14, 3));
        print("MathUtil.isEven " + MathUtil.isEven(14) + " " + MathUtil.isEven(13));
        print("MathUtil.getSlope " + MathUtil.getSlope(0, 0, 1, 1));

        List<double> list = MathUtil.threeSidesMathAngle(317, 131, 343);
        print("threeSidesMathAngle A:" + list[0] + " B:" + list[1] + " C:" + list[2]);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
