using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//下载返回值类型
public enum DownloadType
{
    type_bytes,         //2进制压缩包
    type_txt            //文本
}

public class WebManager : MonoBehaviour 
{
    //下载对象
    struct DownloadItem
    {
        public DownloadType         downloadType;
        public String               url;
        public HandlerDelegate      callBack;
    }

    private static WebManager instance = null;

    private WWW m_www;                                                  //Http组件
    public delegate void HandlerDelegate(System.Object param);

    private List<DownloadItem> downloadList = new List<DownloadItem>(); //下载队列
    private DownloadType m_downloadType = DownloadType.type_bytes;      //下载文件类型
    private String m_url = "";                                          //下载的地址
    private HandlerDelegate m_delegate = null;                          //回调方法

    private bool m_bIsBeginRequest = false;                             //是否开始请求了
    private bool m_bIsDone = true;                                      //是否请求结束了

    public GameObject infoTxt;
    public static WebManager Instance
    {
        get { return instance; }
    }

	// Use this for initialization
	void Start () 
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //查看http请求是否有返回了
        if (m_bIsBeginRequest)
        {
            //下载是否结束了
            if (m_www.isDone)
            {
                if (m_www.error != null)
                {
                    Debug.Log(m_www.error);
                }
                else
                {
                    if (m_delegate != null)
                    {
                        if (m_downloadType == DownloadType.type_bytes)
                        {
                            //二进制
                            m_delegate.Invoke(m_www.bytes);
                        }
                        else if (m_downloadType == DownloadType.type_txt)
                        {
                            //文本
                            m_delegate.Invoke(m_www.text);
                        }
                    }
                }
                m_bIsDone = true;
                m_bIsBeginRequest = false;
                m_delegate = null;
            }
        }
        //空闲时，开始下一个下载
        else
        {
            if (m_bIsDone)
            {
                if (downloadList.Count > 0)
                {
                    //取第一个下载项
                    DownloadItem downloadItem = downloadList[0];
                    m_downloadType = downloadItem.downloadType;
                    m_url = downloadItem.url;
                    m_delegate = downloadItem.callBack;
                    downloadList.RemoveAt(0);

                    m_www = new WWW(m_url);
                    m_bIsBeginRequest = true;
                    m_bIsDone = false;
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
}