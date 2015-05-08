using UnityEngine;
using System.Collections;

public class QualityStarTest : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
        QualityStar.create("star", 3, 1);
        QualityStar.create("star", 1, 1);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
