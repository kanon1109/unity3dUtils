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
        byte[] inputBytes = Encoding.ASCII.GetBytes(input); 
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        string str = "";
        for (int i = 0; i < hash.Length; ++i)
        {
            str += Convert.ToString(hash[i], 16);
        }
        return str; 
    }
}
