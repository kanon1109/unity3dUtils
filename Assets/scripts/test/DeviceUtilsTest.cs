using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeviceUtilsTest : MonoBehaviour 
{
    public GameObject infoTxt;
	// Use this for initialization
	void Start () 
    {
        infoTxt.GetComponent<Text>().text = "info:\n";
        infoTxt.GetComponent<Text>().text += "GetDeviceID: " + DeviceUtils.GetDeviceID() + "\n";
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
