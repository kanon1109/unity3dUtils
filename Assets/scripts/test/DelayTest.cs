using UnityEngine;
public class DelayTest:MonoBehaviour
{
    void Start()
    {
        Delay.create(this.gameObject);
        Delay.setDelay(1000, delayCompleteHandler);
    }

    private void delayCompleteHandler()
    {
        print("delayCompleteHandler");
        Delay.setDelay(1000, delayCompleteHandler);
    }
}