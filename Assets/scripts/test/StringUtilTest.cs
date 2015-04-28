using UnityEngine;
using System.Collections;

public class StringUtilTest : MonoBehaviour 
{
	// Use this for initialization
	void Start ()
    {
        print("  asa sass ssd  ".Trim());
        print("reverse:=" + StringUtil.reverse("123456"));
        print("zfill:=" + StringUtil.zfill("-3", 3));
        print("zfill:=" + StringUtil.zfill("16", 5));
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
