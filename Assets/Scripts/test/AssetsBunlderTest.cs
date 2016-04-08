using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AssetsBunlderTest : MonoBehaviour
{
    public GameObject infoTxt;
    public GameObject ui;
    private WebManager wm;
    void Start()
    {
        if (this.gameObject.GetComponent<WebManager>() == null)
            this.gameObject.AddComponent<WebManager>();

        if (this.wm == null)
            this.wm = this.gameObject.GetComponent<WebManager>();

        this.wm.addDownload(DownloadType.type_assetBundle, "http://192.168.1.50/abs/ABs.zip", requestCallBack);
    }

    private void requestCallBack(object data)
    {
        FileManager.saveByte("ABs.zip", data);
        infoTxt.GetComponent<Text>().text += "saveByte" + "\n";

        FileManager.unzip(FileManager.pathURL + "ABs.zip");
        infoTxt.GetComponent<Text>().text += "unzip" + "\n";

        AssetBundle ab = AssetBundle.CreateFromFile(FileManager.pathURL + "test.assetbundle");
        infoTxt.GetComponent<Text>().text += "CreateFromFile" + "\n";
        infoTxt.GetComponent<Text>().text += "prevLoadAsset" + "\n";

        AudioClip clip = (AudioClip)ab.LoadAsset<AudioClip>("test.mp3");
        if (clip != null)
        {
            GameObject soundGo = new GameObject();
            AudioSource audio = soundGo.AddComponent<AudioSource>();
            audio.clip = clip;
            audio.loop = true;
            audio.volume = 1;
            audio.name = name;
            audio.Play();
        }

        GameObject prefab = ab.LoadAsset<GameObject>("1.prefab") as GameObject;

        infoTxt.GetComponent<Text>().text += "LoadAsset" + "\n";

        GameObject go = Instantiate(prefab, new Vector3(), new Quaternion()) as GameObject;
        go.transform.localPosition = new Vector3(200, 100);
        go.transform.SetParent(ui.transform);
        ab.Unload(false);
    }
}