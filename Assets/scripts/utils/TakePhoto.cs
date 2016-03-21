using System.Collections;
using System.IO;
using UnityEngine;
/// <summary>
/// 截图保存
/// </summary>
public class TakePhoto
{
    public static IEnumerator takeAndSave(string name)
    {
        //一定先要调用这个
        yield return new WaitForEndOfFrame();
        Texture2D photoTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        photoTex.ReadPixels(new Rect(0.0f, 0.0f, Screen.width * 1.0f, Screen.height * 1.0f), 0, 0);
        photoTex.Apply();
        //将图片转成2进制流
        byte[] bytes = photoTex.EncodeToPNG();
        //保持至本地
        FileManager.saveByte(name, bytes);
    }
}