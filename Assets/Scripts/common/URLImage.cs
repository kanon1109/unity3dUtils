using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 动态加载的图片（tips：需要先添加一个WebManager的组件到空对象上或者当前GameObject上）
/// </summary>
public class URLImage : Image
{
    //下载地址
    private string url;
    //图片的名称
    private string name;
    //使用图片原始大小
    private bool useNativeSize = true;
    /// <summary>
    /// 加载图片
    /// </summary>
    /// <param name="url">加载图片的地址</param>
    /// <param name="saveName">图片名称（自定义用于保存图片时的名称）</param>
    /// <param name="useNativeSize">使用图片原始大小</param>
    public void load(string url, string saveName = "", bool useNativeSize = true)
    {
        this.url = url;
        this.name = saveName;
        this.useNativeSize = useNativeSize;
        //如果名称为空取md5
        if (saveName == "") this.name = MD5Util.hash(url);
        //下载文件
        FileManager.downLoadByte(url, downCompleteHandler);
    }

    //下载完成
    private void downCompleteHandler(object param)
    {
        FileManager.saveByte(this.name, param);
        Texture2D tex2d = WebManager.Instance.www.texture;
        this.sprite = Sprite.Create(tex2d, 
                                    new Rect(0, 0, tex2d.width, tex2d.height), 
                                    new Vector2(0, 0));
        if (this.useNativeSize) this.SetNativeSize();
    }
}
