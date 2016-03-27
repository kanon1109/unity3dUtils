using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

class Alert
{
    private static GameObject alertGo = null;
    //默认的画布
    private static Transform parent = null;
    //文本容器
    private static GameObject textGo;
    //内容文本
    private static Text contentText;
    //确定按钮
    private static Button confirmBtn;
    //取消按钮
    private static Button cancelBtn;
    private static Text confirmBtnLabel;
    private static Text cancelBtnLabel;
    /// <summary>
    /// 设置父节点
    /// </summary>
    /// <param name=canvasName></param>
    /// <returns></returns>
    public static void initParent(Transform parent)
    {
        Alert.parent = parent;
    }


    /// <summary>
    /// 显示弹出框
    /// </summary>
    /// <param name=x>x位置</param>
    /// <param name=y>y位置</param>
    /// <param name=bgWidth>背景宽度</param>
    /// <param name=bgHeight>背景高度</param>
    /// <param name=textWidth>文本宽度</param>
    /// <param name=textHeight>文本高度</param>
    /// <param name=content>文字内容</param>
    /// <param name=showCancel>是否显示取消按钮</param>
    /// <param name=confirmHandler>确认回调</param>
    /// <param name=cancelHandler>取消回调</param>
    /// <returns></returns>
    public static void show(float x, float y, 
                            float bgWidth, float bgHeight,
                            float textWidth, float textHeight,
                            String content, bool showCancel,
                            UnityAction confirmHandler, 
                            UnityAction cancelHandler)
    {
        if (alertGo == null)
        {
            alertGo = Resources.Load("prefabs/Alert") as GameObject;
            alertGo = MonoBehaviour.Instantiate(alertGo, new Vector3(), new Quaternion()) as GameObject;
            alertGo.name = "alert";
            alertGo.transform.SetParent(parent);
            alertGo.transform.localPosition = new Vector3(x, y);
            alertGo.transform.localScale = Vector3.one;
        
            //背景
            textGo = alertGo.transform.FindChild("contentTxt").gameObject;
            contentText = textGo.GetComponent<Text>();
            confirmBtn = alertGo.transform.FindChild("confirmBtn").gameObject.GetComponent<Button>();
            cancelBtn = alertGo.transform.FindChild("cancelBtn").gameObject.GetComponent<Button>();
            confirmBtnLabel = confirmBtn.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>();
            cancelBtnLabel = cancelBtn.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>();
            confirmBtnLabel.text = Language.getValue("confirmBtn");
            cancelBtnLabel.text = Language.getValue("cancelBtn");
        }

        alertGo.GetComponent<RectTransform>().sizeDelta = new Vector2(bgWidth, bgHeight);
        textGo.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth, textHeight);
        contentText.text = content;

        confirmBtn.onClick.RemoveAllListeners();
        cancelBtn.onClick.RemoveAllListeners();
        confirmBtn.onClick.AddListener(confirmHandler);
        cancelBtn.onClick.AddListener(cancelHandler);
        cancelBtn.onClick.AddListener(cancelClickHandler);

        cancelBtn.gameObject.SetActive(showCancel);
        if (!showCancel)
            confirmBtn.gameObject.transform.localPosition = new Vector3(0, cancelBtn.gameObject.transform.localPosition.y);
        else
            confirmBtn.gameObject.transform.localPosition = new Vector3(-cancelBtn.gameObject.transform.localPosition.x,
                                                                         cancelBtn.gameObject.transform.localPosition.y);

        alertGo.SetActive(true);
        //设置深度节点
        alertGo.transform.SetSiblingIndex(-1);
    }


    /// <summary>
    /// 显示弹出框
    /// </summary>
    /// <param name=x>x位置</param>
    /// <param name=y>y位置</param>
    /// <param name=bgWidth>背景宽度</param>
    /// <param name=bgHeight>背景高度</param>
    /// <param name=textWidth>文本宽度</param>
    /// <param name=textHeight>文本高度</param>
    /// <param name=content>文字内容</param>
    /// <param name=showCancel>是否显示取消按钮</param>
    /// <param name=confirmHandler>确认回调</param>
    /// <returns></returns>
    public static void show(float x, float y,
                            float bgWidth, float bgHeight,
                            float textWidth, float textHeight,
                            String content, bool showCancel,
                            UnityAction confirmHandler)
    {

        Alert.show(x, y, bgWidth, bgHeight, textWidth, textHeight, content, showCancel, confirmHandler, null);
    }

    private static void cancelClickHandler()
    {
        alertGo.SetActive(false);
    }
}


