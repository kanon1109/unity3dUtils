using System;
using UnityEngine;
class SoundManager
{
    //bgm只有一个
    public static GameObject bgm = null;
    //背景音乐开关
    public static bool musicSwitch = true;
    //音效开关
    public static bool soundSwitch = true;

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name">音效名称</param>
    /// <param name="loop">是否循环</param>
    /// <param name="volume">音量</param>
    /// <returns></returns>
    public static void playBackgroundMusic(String name, bool loop, float volume)
    {
        initSwitch();
        if(!musicSwitch) return;
        AudioClip clip = (AudioClip)Resources.Load(name, typeof(AudioClip));
        if (clip != null)
        {
            if (bgm == null) bgm = new GameObject();
            AudioSource audio = bgm.GetComponent<AudioSource>();
            if (audio == null) audio = bgm.AddComponent<AudioSource>();
            audio.Stop();
            audio.clip = clip;
            audio.loop = loop;
            audio.volume = volume;
            audio.name = "bgm" + name;
            audio.Play();
            if (!loop) GameObject.Destroy(bgm, clip.length);
        }
    }

    /// <summary>
    /// 暂停背景音乐
    /// </summary>
    /// <returns></returns>
    public static void pauseBackgroundMusic()
    {
        if (!musicSwitch) return;
        if (bgm == null) return;
        AudioSource audio = bgm.GetComponent<AudioSource>();
        if (audio == null) return;
        audio.Pause();
    }

    /// <summary>
    /// 取消暂停背景音乐
    /// </summary>
    /// <returns></returns>
    public static void unPauseBackgroundMusic()
    {
        if (!musicSwitch) return;
        if (bgm == null) return;
        AudioSource audio = bgm.GetComponent<AudioSource>();
        if (audio == null) return;
        audio.UnPause();
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name">音效名称</param>
    /// <param name="loop">是否循环</param>
    /// <returns></returns>
    public static void playBackgroundMusic(String name, bool loop)
    {
        SoundManager.playBackgroundMusic(name, loop, 1);
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name">音效名称</param>
    /// <param name="loop">是否循环如果为true则不销毁</param>
    /// <param name="volume">音量</param>
    /// <returns></returns>
    public static void playEffect(String name, bool loop, float volume)
    {
        initSwitch();
        if(!soundSwitch) return;
        //加载AudioClip资源
        AudioClip clip = (AudioClip) Resources.Load(name, typeof(AudioClip));
        if (clip != null)
        {
            GameObject effectSound = new GameObject();
            AudioSource audio = effectSound.AddComponent<AudioSource>();
            audio.clip = clip;
            audio.loop = loop;
            audio.volume = volume;
            audio.name = "soundEffect" + name;
            audio.Play();
            if (!loop) GameObject.Destroy(effectSound, clip.length);
        }
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name">音效名称</param>
    /// <param name="loop">是否循环如果为true则不销毁</param>
    /// <returns></returns>
    public static void playEffect(String name, bool loop)
    {
        SoundManager.playEffect(name, loop, 1);
    }

    /// <summary>
    /// 设置音乐开关
    /// </summary>
    /// <param name="flag">是否开启</param>
    /// <returns></returns>
    public static void setMusicSwitch(bool flag)
    {
        String value = "off";
        if (flag) value = "on";
        PlayerPrefs.SetString("musicSwitch", value);
        musicSwitch = flag;
    }

    /// <summary>
    /// 设置音效开关
    /// </summary>
    /// <param name="flag">是否开启</param>
    /// <returns></returns>
    public static void setSoundSwitch(bool flag)
    {
        String value = "off";
        if (flag) value = "on";
        PlayerPrefs.SetString("soundSwitch", value);
        soundSwitch = flag;
    }
    
    /// <summary>
    /// 初始化开关
    /// </summary>
    /// <returns></returns>
    private static void initSwitch()
    {
        String value = PlayerPrefs.GetString("musicSwitch");
        if (value == "" || value == "on") musicSwitch = true;
        else musicSwitch = false;

        value = PlayerPrefs.GetString("soundSwitch");
        if (value == "" || value == "on") soundSwitch = true;
        else soundSwitch = false;
    }
}
