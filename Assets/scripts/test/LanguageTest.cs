using UnityEngine;
using System.Collections;

public class LanguageTest : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
        Language.init("Assets/xml/language.xml", "language");
        print(Language.getValue("test"));
        print(Language.getValue("test", "kanon", "tb"));
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
