using UnityEngine;
using UnityEngine.UI;

public class UiUtilTest : MonoBehaviour
{
    public Button btn;
    public Text txt;
    public Image img;

    public GameObject btnGo;
    public GameObject txtGo;
    public GameObject imgGo;

    void Start()
    {
        UiUtil.setBtnGray(btn, false);
        UiUtil.setUIGray(txt.gameObject, true);
        UiUtil.setUIGray(img.gameObject, true);

    }
}
