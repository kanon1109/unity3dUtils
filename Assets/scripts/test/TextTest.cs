using UnityEngine;
using UnityEngine.UI;

public class TextTest : MonoBehaviour 
{
    public Text txt;


    void Start()
    {
        print("preferredWidth" + this.txt.preferredWidth);
        print("flexibleWidth" + this.txt.flexibleWidth);
        print(this.txt.GetPixelAdjustedRect().width);
        print(this.txt.GetComponent<RectTransform>().sizeDelta.x);
        TextUtil.setAutoScale(this.txt);
    }

    void Update()
    {
        TextUtil.setAutoScale(this.txt);
    }
}