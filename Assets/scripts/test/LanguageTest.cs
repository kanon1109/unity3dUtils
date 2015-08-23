using UnityEngine;
using UnityEngine.UI;

public class LanguageTest : MonoBehaviour 
{
	// Use this for initialization
	public Text infoTxt;
	void Start () 
    {
        Language.init("language");
        infoTxt.text += Language.getValue("test");
        infoTxt.text += Language.getValue("test", "kanon", "tb");
	}

	// Update is called once per frame
	void Update () 
    {
	
	}
}
