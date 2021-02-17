using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllBase : MonoBehaviour
{
    private void Awake()
    {
        OnAwake();
    }
    protected virtual void OnAwake() { }

    private void Start()
    {
        OnStart();
    }
    protected virtual void OnStart() { }

    protected virtual void OnEnable() { }

    private void Update()
    {
        OnUpdate();
    }

    protected virtual void OnUpdate() { }

    protected virtual void OnDisable() { }

    protected virtual void OnDestroy() { }

    private void OnApplicationQuit()
    {
        OnQuit();
    }

    /// <summary>
    /// 退出应用的的时候执行
    /// 目的是做推出应用保存数据用的
    /// </summary>
    protected virtual void OnQuit() { }
}
