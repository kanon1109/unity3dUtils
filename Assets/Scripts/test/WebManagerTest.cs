using UnityEngine;
using System;
using System.Collections;

public class WebManagerTest : MonoBehaviour
{
    private WebManager wm;
	// Use this for initialization
	void Start ()
    {
        //WebManager.Instance.addDownload(DownloadType.type_txt, "http://gs2.zsg.ecngame.com/apple/server_list_appstore.xml", downLoadCallBackHandler);
        
        if (this.gameObject.GetComponent<WebManager>() == null)
            this.gameObject.AddComponent<WebManager>();

        if (this.wm == null)
            this.wm = this.gameObject.GetComponent<WebManager>();

        //测试请求
        this.wm.addHttpRequest("http://127.0.0.1/t/test.php", "test", requestCallBack);
        this.wm.errorHandlerDelegate = errorHandlerCallBack;
    }

    void errorHandlerCallBack(System.Object param)
    {
        print("errorHandlerCallBack " + param.ToString());
    }

    void requestCallBack(System.Object param)
    {
        print("requestCallBack " + param.ToString());
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
