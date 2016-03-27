using UnityEngine;
using System.Collections;

public class TimerTest : MonoBehaviour 
{
	// Use this for initialization
    Timer timer;
	void Start ()
    {
        timer = this.gameObject.AddComponent<Timer>();
        timer.createTimer(.3f, -1, timerComplete);
        //timer.createTimer(.3f, 2, timerComplete, true);
        timer.start();
	}
	
    void timerComplete()
    {
        print("timer.currentCount " + timer.currentCount);
        /*if (timer.currentCount == 2)
        {
            timer.reset();
            timer.start();
        }*/
    }

	// Update is called once per frame
	void Update () 
    {
	
	}
}
