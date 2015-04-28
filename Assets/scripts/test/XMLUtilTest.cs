using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class XMLUtilTest : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        List<TestVo> list = XMLUtil.parse<TestVo>("Assets/xml/awakens.xml", "awakens");
        print(list[0].awakenNo);
        print(list[0].price);
        print(list[0].probability);
        print(list[0].dropNo);
        print(list[0].name);

        Dictionary<string, TestVo>dict = XMLUtil.parse<TestVo>("Assets/xml/awakens.xml", "awakens", "awakenNo");
        print("awakenNo = " + dict[list[0].awakenNo.ToString()].awakenNo);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class TestVo
{
    public int awakenNo;
    public int price;
    public float probability;
    public int dropNo;
    public string name;
}
