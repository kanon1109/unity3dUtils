using UnityEngine;
using System;
using System.Collections;

public class WebManagerTest : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        WebManager.Instance.addDownload(DownloadType.type_txt, "http://gs2.zsg.ecngame.com/apple/server_list_appstore.xml", downLoadCallBackHandler);
	}


    void downLoadCallBackHandler(System.Object param)
    {
        print(param);
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
