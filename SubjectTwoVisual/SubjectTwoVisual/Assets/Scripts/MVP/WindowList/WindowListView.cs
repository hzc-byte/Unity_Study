using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowListView : ViewBase
{
    /// <summary>
    /// 小视窗在UI上的左边还是右边
    /// </summary>
    private Dropdown position;
    /// <summary>
    /// 使用的是左相机还是右相机
    /// </summary>
    private Dropdown camera;
    /// <summary>
    /// 显示设置每次生成的时候所在的SiblingIndex
    /// </summary>
    private int showStateSiblingIndex = 3;
    /// <summary>
    /// 隐藏设置每次生成的时候所在的SiblingIndex
    /// </summary>
    private int hideStateSiblingIndex = 4;

    private void InstantiateCondition(List<object> conditionList)
    {

    }
}
