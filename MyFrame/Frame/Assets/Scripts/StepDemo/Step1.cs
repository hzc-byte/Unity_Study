using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Step1")]
public class Step1 : StepBase
{
    public override void OnAwake()
    {
        base.OnAwake();
        Debug.Log("Step1 OnAwake");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("Step1 OnUpdate");
    }
}
