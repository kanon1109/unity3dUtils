using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FileManagerTest : MonoBehaviour
{
    public GameObject infoTxt;
	// Use this for initialization
	void Start () 
    {
        infoTxt.GetComponent<Text>().text = Application.persistentDataPath.ToString() + "\n";
        //FileManager.downLoadTxt("localhost/test/xml/language.xml", downLoadComplete);
        FileManager.downLoadByte("http://192.168.18.63/test/cfg/cfg_001.zip", downLoadByteComplete);
	}

    public void downLoadByteComplete(object data)
    {
        infoTxt.GetComponent<Text>().text += "downLoadByteComplete" + "\n";
        FileManager.saveByte("cfg_001.zip", data);
        infoTxt.GetComponent<Text>().text += "saveByte" + "\n";
        FileManager.unzip(Application.persistentDataPath + "/cfg_001.zip");
        infoTxt.GetComponent<Text>().text += "unzip" + "\n";

        List<TestVo2> list = XMLUtil.parse<TestVo2>(Application.persistentDataPath + "/cfg/break.xml", "breaks");
        print(list[0].id);
        print(list[0].type);
        print(list[0].quality);
        print(list[0].level);
        print(list[0].material1);
        print(list[0].name1);

        Dictionary<string, TestVo2> dict = XMLUtil.parse<TestVo2>(Application.persistentDataPath + "/cfg/break.xml", "breaks", "id");
        print("id = " + dict[list[0].id.ToString()].id);

        infoTxt.GetComponent<Text>().text += "id: " + list[0].id + "\n";
        infoTxt.GetComponent<Text>().text += "type: " + list[0].type + "\n";
        infoTxt.GetComponent<Text>().text += "quality: " + list[0].quality + "\n";
        infoTxt.GetComponent<Text>().text += "level: " + list[0].level + "\n";
        infoTxt.GetComponent<Text>().text += "material1: " + list[0].material1 + "\n";
        infoTxt.GetComponent<Text>().text += "name1: " + list[0].name1 + "\n";
    }

    public void downLoadComplete(object data)
    {
        //保存
        FileManager.saveTxt("language.xml",data);
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
