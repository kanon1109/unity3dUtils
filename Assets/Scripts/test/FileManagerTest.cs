using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;

public class FileManagerTest : MonoBehaviour
{
    public GameObject infoTxt;
    public GameObject infoTxt2;
    public WebManager wm;
	// Use this for initialization
    void Start() 
    {
        FileManager.downLoadByte(this.wm, "http://127.0.0.1/test/cfg/cfg_001.zip", downLoadByteComplete);
	}

    public void downLoadByteComplete(object data)
    {
        infoTxt.GetComponent<Text>().text += FileManager.pathURL + "cfg_001.zip" + "\n";
        FileManager.saveByte("cfg_001.zip", data);
        infoTxt.GetComponent<Text>().text += "saveByte" + "\n";
        FileManager.unzip(FileManager.pathURL + "cfg_001.zip");
        infoTxt.GetComponent<Text>().text += "unzip" + "\n";

        List<TestVo2> list = XMLUtil.parse<TestVo2>(FileManager.pathURL + "cfg/break.xml", "breaks");
        Dictionary<string, TestVo2> dict = XMLUtil.parse<TestVo2>(FileManager.pathURL + "cfg/break.xml", "breaks", "id");
        print("id = " + dict[list[0].id.ToString()].id);

        infoTxt.GetComponent<Text>().text += "id: " + list[0].id + "\n";
        infoTxt.GetComponent<Text>().text += "type: " + list[0].type + "\n";
        infoTxt.GetComponent<Text>().text += "quality: " + list[0].quality + "\n";
        infoTxt.GetComponent<Text>().text += "level: " + list[0].level + "\n";
        infoTxt.GetComponent<Text>().text += "material1: " + list[0].material1 + "\n";
        infoTxt.GetComponent<Text>().text += "name1: " + list[0].name1 + "\n";
    }
	
	// Update is called once per frame
	void Update () 
    {

	}
}
public class TestVo2
{
    public int id;
    public int type;
    public float quality;
    public int level;
    public string material1;
    public string name1;
}
