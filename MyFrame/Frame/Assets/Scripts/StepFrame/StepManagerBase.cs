using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManagerBase : MonoBehaviour
{
    private const string TAG = "[StepManagerBase]:";

    public StepBase[] Steps;

    public int CurrentStepID = -1;

    /// <summary>
    /// 判断步骤是否开始
    /// </summary>
    private bool isStart = true;

    private void Awake()
    {
        for (int i = 0; i < Steps.Length; i++)
        {
            if (i != 0)
            {
                Steps[i].LastStep = Steps[i - 1];
            }
            Steps[i].OnAwake();
        }
    }

    private void Update()
    {
        //整体流程结束
        if (CurrentStepID >= Steps.Length)
        {
            CurrentStepID = -1;
            OnComplete();
            return;
        }
        if (isStart)
        {
            isStart = false;
            OnStart();
        }
        OnUpdate();
    }

    private void OnStart()
    {
        if (CurrentStepID >= 0 && CurrentStepID < Steps.Length)
        {
            for (int i = 0; i < Steps.Length; i++)
            {
                Steps[CurrentStepID].OnStart();
                Steps[CurrentStepID].OnCompleteEvent += OnStepCompleted;
            }
        }
    }

    private void OnUpdate()
    {
        if (CurrentStepID >= 0 && CurrentStepID < Steps.Length)
        {
            Steps[CurrentStepID].OnUpdate();
        }
    }

    /// <summary>
    /// 当前步骤完成
    /// </summary>
    /// <param name="step"></param>
    private void OnStepCompleted(StepBase step)
    {
        if (step.Check())
        {
            isStart = true;
            CurrentStepID = step.ID + 1;
        }
    }

    /// <summary>
    /// 这个需要重载，是整个流程结束的位置，用于处理整体的流程
    /// </summary>
    protected virtual void OnComplete()
    {
        Debug.Log(TAG + "OnComplete");
    }
}
