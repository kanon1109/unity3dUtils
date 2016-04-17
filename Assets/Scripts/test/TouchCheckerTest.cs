using UnityEngine;
using System.Collections;

public class TouchCheckerTest : MonoBehaviour
{
    public TouchChecker touchChecker;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = touchChecker.getTouchObj();
        if (go != null)
        {
            print(go);
        }
    }
}
