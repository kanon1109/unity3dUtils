using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CommonTest : MonoBehaviour
{
    public Button btn;
    public Canvas ui;
    private GameObject button;
	// Use this for initialization
	void Start ()
    {
        LockScreen.initParent(ui.transform);
        btn.onClick.AddListener(clickHandler);
	}
	
    void clickHandler()
    {
        LockScreen.show();
        if (button == null)
        {
            button = Resources.Load("prefabs/Button") as GameObject;
            button = MonoBehaviour.Instantiate(button, new Vector3(0, 50), new Quaternion()) as GameObject;
            //将锁屏添加进画布中
            button.transform.SetParent(GameObject.Find("ui").transform);
            button.GetComponent<Button>().onClick.AddListener(clickHandler2);
        }
    }

    void clickHandler2()
    {
        LockScreen.show();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LockScreen.hide();
        }
	}
}
