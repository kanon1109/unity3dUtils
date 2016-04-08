using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//下载返回值类型
public enum DownloadType
{
    type_bytes,         //2进制压缩包
    type_txt,           //文本
    type_url,           //http请求
    type_assetBundle    //资源包
}

public class WebManager : MonoBehaviour 
{
    //下载对象
    struct DownloadItem
    {
        public DownloadType         downloadType;
        public String               url;
        public HandlerDelegate      callBack;
        public byte[]               requestParams;
        
    }

    private static WebManager instance = null;

    private WWW _www;                                                  //Http组件
    public WWW www { get { return _www; }}
    public delegate void HandlerDelegate(System.Object param);

    private List<DownloadItem> downloadList = new List<DownloadItem>(); //下载队列
    private DownloadType downloadType = DownloadType.type_bytes;      //下载文件类型
    private String url = "";                                          //下载的地址
    private HandlerDelegate handlerDelegate = null;                          //回调方法

    private bool bIsBeginRequest = false;                             //是否开始请求了
    private bool bIsDone = true;                                      //是否请求结束了

    public static WebManager Instance
    {
        get { return instance; }
    }

	// Use this for initialization
	void Start () 
    {
        if (instance != null && 
            instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //查看http请求是否有返回了
        if (bIsBeginRequest)
        {
            //下载是否结束了
            if (_www.isDone)
            {
                if (_www.error != null)
                {
                    Debug.Log(_www.error);
                }
                else
                {
                    if (handlerDelegate != null)
                    {
                        if (downloadType == DownloadType.type_bytes || 
                            downloadType == DownloadType.type_assetBundle)
                        {
                            //二进制
                            handlerDelegate.Invoke(_www.bytes);
                        }
                        else if (downloadType == DownloadType.type_txt || 
                                 downloadType == DownloadType.type_url)
                        {
                            //文本
                            handlerDelegate.Invoke(_www.text);
                        }
                    }
                }
                bIsDone = true;
                bIsBeginRequest = false;
                handlerDelegate = null;
            }
        }
        else
        {
            //空闲时，开始下一个下载
            if (bIsDone)
            {
                if (downloadList.Count > 0)
                {
                    //取第一个下载项
                    DownloadItem downloadItem = downloadList[0];
                    downloadType = downloadItem.downloadType;
                    url = downloadItem.url;
                    handlerDelegate = downloadItem.callBack;
                    downloadList.RemoveAt(0);
                    if (downloadType == DownloadType.type_url)
                    {
                        byte[] requestParams = downloadItem.requestParams;
                        _www = new WWW(url, requestParams);//发送请求  
                    }
                    else
                    {
                        _www = new WWW(url);
                    }
                    bIsBeginRequest = true;
                    bIsDone = false;
                }
            }
        }
	}

    /// <summary>
    /// 添加一个下载对象到下载队列
    /// </summary>
    /// <param name="downloadType">下载的类型</param>
    /// <param name="url">url地址</param>
    /// <param name="callBack">回调的对象</param>
    /// <returns></returns>
    public void addDownload(DownloadType downloadType, String url, HandlerDelegate callBack)
    {
        DownloadItem downloadItem = new DownloadItem();
        downloadItem.downloadType = downloadType;
        downloadItem.url = url;
        downloadItem.callBack = callBack;
        downloadList.Add(downloadItem);
    }

    /// <summary>
    /// 添加一个http请求
    /// </summary>
    /// <param name="url">请求地址</param>
    /// <param name="requestParams">请求参数</param>
    /// <param name="callBack">请求回调</param>
    public void addHttpRequest(String url, String requestParams, HandlerDelegate callBack)
    {
        DownloadItem downloadItem = new DownloadItem();
        downloadItem.downloadType = DownloadType.type_url;
        downloadItem.url = url;
        downloadItem.callBack = callBack;
        downloadItem.requestParams = UTF8Encoding.UTF8.GetBytes(requestParams);
        downloadList.Add(downloadItem);
    }
}