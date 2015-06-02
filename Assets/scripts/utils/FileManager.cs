using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using UnityEngine;
//用于下载文件 并且保存至 Resources目录下，再由XMLUtil读取配置并序列化。
public class FileManager
{
    //下载完成回调
    public delegate void HandlerDelegate(object data);
    //下载保存路径
    public static readonly string pathURL = 
#if UNITY_ANDROID                                   //安卓  
        "jar:file://" + Application.persistentDataPath + "/";
#elif UNITY_IPHONE                                  //iPhone
        Application.persistentDataPath + "/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR          //windows平台和web平台
        Application.persistentDataPath + "/";
#else  
        string.Empty;  
#endif

    /// <summary>
    /// 下载文件
    /// </summary>
    /// <param name="path">文件地址</param>
    /// <param name="completeHandler">下载回调</param>
    /// <returns></returns>
    public static void downLoadTxt(String path, WebManager.HandlerDelegate completeHandler)
    {
        WebManager.Instance.addDownload(DownloadType.type_txt, path, completeHandler);
    }

    /// <summary>
    /// 下载二进制文件
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="completeHandler">下载回调</param>
    /// <returns></returns>
    public static void downLoadByte(String path, WebManager.HandlerDelegate completeHandler)
    {
        WebManager.Instance.addDownload(DownloadType.type_bytes, path, completeHandler);
    }

    /// <summary>
    /// 保存二进制文件
    /// </summary>
    /// <param name="fileName">文件名称</param>
    /// <param name="data">文件二进制数据</param>
    /// <returns></returns>
    public static void saveByte(String fileName, object data)
    {
        String filePath = pathURL + fileName;
        //删除已有文件
        deleteFile(filePath);
        //创建文件
        createByteFile(filePath, data as byte[]);
    }

    /// <summary>
    /// 创建二进制文件
    /// </summary>
    /// <param name="filePath">文件名称</param>
    /// <param name="data">文件二进制数据</param>
    /// <returns></returns>
    public static void createByteFile(String filePath, byte[] data)
    {
        //文件流信息  
        FileInfo fi = new FileInfo(filePath);
        Stream sw = fi.Create();
        sw.Write(data, 0, data.Length);
        //关闭流  
        sw.Close();
        //销毁流  
        sw.Dispose();
    }
    
    /// <summary>
    /// 保存文本文件
    /// </summary>
    /// <param name="fileName">文件名称</param>
    /// <param name="data">文件数据</param>
    /// <returns></returns>
    public static void saveTxt(String fileName, object data)
    {
        String filePath = pathURL + fileName;
        //删除已有文件
        deleteFile(filePath);
        //创建文件
        createTxtFile(filePath, data.ToString());
    }

    /// <summary>
    /// 创建文本文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="data">文件数据</param>
    /// <returns></returns>
    public static void createTxtFile(String filePath, String data)
    {
        //文件流信息
        StreamWriter sw;
        FileInfo t = new FileInfo(filePath);
        sw = t.CreateText();
        //以行的形式写入信息
        sw.WriteLine(data);
        //关闭流
        sw.Close();
        //销毁流
        sw.Dispose();
    }


    /// <summary>
    /// 用第三方工具去解压 zip ,保存到本地
    /// </summary>
    /// <param name="zipFilePath">文件路径</param>
    /// <returns></returns>
    public static void unzip(String zipFilePath)
    {
        //解压zip文件
        using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
        {
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(theEntry.Name);
                string fileName = Path.GetFileName(theEntry.Name);

                //有文件夹路径，创建文件夹
                if (directoryName.Length > 0)
                    Directory.CreateDirectory(pathURL + "/" + directoryName);

                if (fileName != string.Empty)
                {
                    //读取文件数据，保存文件
                    using (FileStream streamWriter = File.Create(pathURL + "/" + theEntry.Name))
                    {
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0) streamWriter.Write(data, 0, size);
                            else break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns></returns>
    public static void deleteFile(String filePath)
    {
        File.Delete(filePath);
    }
}
