using UnityEngine;
using System.Collections;

public class KeyboardManagerTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        KeyboardManager.registerKey(KeyCode.A, onKeyADown, true);
        KeyboardManager.registerKey(KeyCode.S, onKeySDown, true);
        KeyboardManager.registerKey(KeyCode.S, onKeySUp, false);
	}

    private void onKeySUp()
    {
        KeyboardManager.unregisterKey(KeyCode.S, false);
        print("onKeySUp s");
    }

    private void onKeySDown()
    {
        print("onKeyDown s");
    }

    void onKeyADown()
    {
        print("onKeyDown a");
    }
	
	// Update is called once per frame
	void Update () 
    {
        KeyboardManager.updateKey();
	}
}
