using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundManagerTest : MonoBehaviour 
{
    public Button btn;

    public Button musicSwitchBtn;

    public Button soundSwitchBtn;

    public Button clearBtn;
	// Use this for initialization
	void Start ()
    {
        print(PlayerPrefs.GetString("musicSwitch"));
        SoundManager.playBackgroundMusic("click", true, .2f);
        musicSwitchBtn.onClick.AddListener(musicSwitchBtnClickHandler);
        soundSwitchBtn.onClick.AddListener(soundSwitchBtnClickHandler);
        clearBtn.onClick.AddListener(clearBtnClickHandler);
        btn.onClick.AddListener(clickHandler);
	}

    private void clearBtnClickHandler()
    {
        PlayerPrefs.DeleteAll();
    }

    private void soundSwitchBtnClickHandler()
    {
        SoundManager.setSoundSwitch(false);
    }

    private void musicSwitchBtnClickHandler()
    {
        SoundManager.setMusicSwitch(false);
    }

    void clickHandler()
    {
        SoundManager.playBackgroundMusic("2", true, .2f);
        SoundManager.playEffect("click", false, .2f);
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
