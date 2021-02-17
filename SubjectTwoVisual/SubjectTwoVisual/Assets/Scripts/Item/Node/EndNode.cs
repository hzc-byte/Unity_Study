using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : NodeBase
{
    private const string TAG = "[EndNode]:";

    protected override void OnStart()
    {
        base.OnStart();
        EventManager.Instance.DispatchEvent(EventEnum.SetNodeName, new StringParam("End"));
        SetPosition();
    }

    protected override void OnQuit()
    {
        base.OnQuit();
    }

    /// <summary>
    /// 设置节点的位置
    /// </summary>
    /// <param name="ie"></param>
    private void SetPosition()
    {
        Vector3 position = LastNode.transform.GetComponent<RectTransform>().anchoredPosition3D + new Vector3(LastNode.Length + Length + LastNode.NodeLine.Length, 0, 0);
        this.GetComponent<RectTransform>().anchoredPosition3D = position;
    }
}
