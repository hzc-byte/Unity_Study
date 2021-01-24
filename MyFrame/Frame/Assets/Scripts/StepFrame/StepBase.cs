using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StepBase : ScriptableObject
{
    private const string TAG = "[StepBase]:";
    /// <summary>
    /// 步骤的ID，唯一标识
    /// </summary>
    public int ID
    {
        set { }
        get { return LastStep == null ? 0 : LastStep.ID + 1; }
    }

    /// <summary>
    /// 上一步骤
    /// </summary>
    public StepBase LastStep;

    /// <summary>
    /// 步骤结束的回调
    /// </summary>
    public Action<StepBase> OnCompleteEvent = null;

    /// <summary>
    /// 判断步骤是否结束
    /// </summary>
    public bool IsCompleted = false;

    #region 生命周期
    public virtual void OnAwake() { }

    public virtual void OnStart() { }

    public virtual void OnUpdate() { }

    public virtual void OnComplete() { IsCompleted = true; }

    public virtual void OnReset() { IsCompleted = false; }
    #endregion

    /// <summary>
    /// 判断步骤是否结束
    /// </summary>
    public virtual bool Check() { return IsCompleted; }
}
