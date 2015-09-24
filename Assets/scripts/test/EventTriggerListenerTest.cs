using UnityEngine;
using UnityEngine.UI;

public class EventTriggerListenerTest : MonoBehaviour
{
    public GameObject btn;
    void Start()
    {
        EventTriggerListener.Get(btn).onDown = onDownHandler;
    }

    private void onDownHandler(GameObject go)
    {
        print("onDownHandler");
    }
}
