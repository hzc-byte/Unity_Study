using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollRect : ScrollRect
{
    protected override void SetNormalizedPosition(float value, int axis)
    {
        if (content == null) return;
        base.SetNormalizedPosition(value, axis);
    }
}
