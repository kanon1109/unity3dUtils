using UnityEngine;
public class DelayTest:MonoBehaviour
{
    void Start()
    {
        Delay.setDelay(this.gameObject, 1000, delayCompleteHandler, true, "test");
    }

    private void delayCompleteHandler(System.Object param)
    {
        print(param);
        print("delayCompleteHandler");
        Delay.setDelay(this.gameObject, 2000, delayCompleteHandler, false);
    }
}