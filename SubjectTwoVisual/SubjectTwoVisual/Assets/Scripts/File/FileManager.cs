using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager
{
    private const string TAG = "[FileManager]:";
    /// <summary>
    /// 文件写入
    /// </summary>
    public static void Write(string path, string content)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        StreamWriter sw = new StreamWriter(path);
        sw.Write(content);
        sw.Close();
    }

    /// <summary>
    /// 读取文件
    /// </summary>
    public static string Read(string path)
    {
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            string content = sr.ReadToEnd();
            sr.Close();
            return content;
        }
        else
        {
            Debug.LogError(TAG + $"the path = {path} dont exist this file");
            return "error path!";
        }
    }
}
