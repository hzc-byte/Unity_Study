using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager
{
    private const string TAG = "[JsonManager]:";

    /// <summary>
    /// 供外部调用
    /// </summary>
    public static void ToJson(string path, object serialze)
    {
        string content = ToJson(serialze);
        FileManager.Write(path, content);
    }
    /// <summary>
    /// 转化成Json
    /// </summary>
    private static string ToJson(object serialze)
    {
        string json = JsonConvert.SerializeObject(serialze);
        Debug.Log(TAG + $"output json = {json}");
        return json;
    }

    /// <summary>
    /// 供外部调用
    /// </summary>
    public static T FromJson<T>(string path)
    {
        string content = FileManager.Read(path);
        Debug.Log(TAG + $"read content = {content}");
        return PrivateFromJson<T>(content);
    }

    /// <summary>
    /// 转化成Json代表的方法
    /// </summary>
    private static T PrivateFromJson<T>(string json)
    {
        T t = JsonConvert.DeserializeObject<T>(json);
        return t;
    }
}
