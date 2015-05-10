using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlertTest : MonoBehaviour
{
    public Canvas ui;
    public Button btn;
	// Use this for initialization
	void Start () 
    {
        Alert.initParent(ui.transform);
        btn.onClick.AddListener(clickHandler);
	}
	
    void clickHandler()
    {
        Alert.show(0, 100, 400, 300, 310, 230, "asasdw阿斯大声", true, confirmHandler, cancelHandler);
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
