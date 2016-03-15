using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlertTest : MonoBehaviour
{
    public Transform parent;
    public Button btn;
	// Use this for initialization
	void Start () 
    {
        Language.init("language");
        Alert.initParent(parent);
        btn.onClick.AddListener(clickHandler);
	}
	
    void clickHandler()
    {
        Alert.show(0, 0, 400, 300, 310, 230, "阿斯大声阿斯大声阿斯大声阿斯大声阿斯大声阿斯大声阿斯大声阿斯大声阿斯大声", true, confirmHandler, cancelHandler);
    }

    void confirmHandler()
    {
        print("confirmHandler");
    }

    void cancelHandler()
    {
        print("cancelHandler");

    }

	// Update is called once per frame
	void Update () {
	
	}
}
