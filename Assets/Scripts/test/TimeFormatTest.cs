using UnityEngine;
using System.Collections;

public class TimeFormatTest : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        print(TimeFormat.secondToTime(3600, ":", true));
        print(TimeFormat.timeToMillisecond(TimeFormat.secondToTime(4351, ":", true), ':'));
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
