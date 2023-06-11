using System.Text;
using System.Security.Cryptography;
using System;
using UnityEngine;
public class MD5Util
{
    private static MD5 md5 = null;
    public static string hash(string input)
    {
        if (md5 == null) md5 = MD5.Create(); 
        byte[] sor = Encoding.UTF8.GetBytes(input);
        byte[] result = md5.ComputeHash(sor);
        StringBuilder strbul = new StringBuilder(40);
        for (int i = 0; i < result.Length; i++) {
            strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
        }
        return strbul.ToString();
    }
}
