using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XMLUtilTest : MonoBehaviour
{
    public GameObject infoTxt;
	// Use this for initialization
	void Start ()
    {
        List<TestVo> list = XMLUtil.parse<TestVo>(Application.persistentDataPath + "/cfg/break.xml", "breaks");
        print(list[0].id);
        print(list[0].type);
        print(list[0].quality);
        print(list[0].level);
        print(list[0].material1);

        Dictionary<string, TestVo> dict = XMLUtil.parse<TestVo>(Application.persistentDataPath + "/cfg/break.xml", "breaks", "id");
        print("id = " + dict[list[0].id.ToString()].id);

        infoTxt.GetComponent<Text>().text = list[0].id + "\n";
        infoTxt.GetComponent<Text>().text = list[0].type + "\n";
        infoTxt.GetComponent<Text>().text = list[0].quality + "\n";
        infoTxt.GetComponent<Text>().text = list[0].level + "\n";
        infoTxt.GetComponent<Text>().text = list[0].material1 + "\n";
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}

public class TestVo
{
    public int id;
    public int type;
    public float quality;
    public int level;
    public string material1;
}
