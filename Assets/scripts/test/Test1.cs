using UnityEngine;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    public Text txt;
    void Start()
    {
        print("this is in test1");
        txt.text = "this is in test1";
    }
}
