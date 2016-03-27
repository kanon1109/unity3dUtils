using UnityEngine;
using System.Collections;

public class QualityStarTest : MonoBehaviour 
{

	// Use this for initialization
    public GameObject ui;
	void Start ()
    {
        GameObject go = QualityStar.create(ui.transform, "star", 5);

        go.transform.localPosition = new Vector3(100, -100);

        go = QualityStar.create(ui.transform, "star", 3);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
