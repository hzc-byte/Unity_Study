using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : NodeBase
{
    private const string TAG = "[StartNode]:";

    //存储json中的公用的数据
    private string itemCode;
    private string itemName;
    private string mirrorConfig;
    private string stageCode;
    private string stageName;

    public string ItemCode { get => itemCode; set => itemCode = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public string MirrorConfig { get => mirrorConfig; set => mirrorConfig = value; }
    public string StageCode { get => stageCode; set => stageCode = value; }
    public string StageName { get => stageName; set => stageName = value; }

    protected override void OnAwake()
    {
        base.OnAwake();
        EventManager.Instance.AddEvent(EventEnum.SetStartNodePosition, SetPosition);//不放在Start中的原因是跟ExtendLength的时序发生冲突
    }

    protected override void OnStart()
    {
        base.OnStart();
        EventManager.Instance.DispatchEvent(EventEnum.SetNodeName, new StringParam("Start"));
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        EventManager.Instance.RemoveEvent(EventEnum.SetStartNodePosition, SetPosition);
    }

    /// <summary>
    /// 设置节点的位置
    /// </summary>
    /// <param name="ie"></param>
    private void SetPosition(IEventParam ie)
    {
        if (ie is Vector3Param v3p)
        {
            this.GetComponent<RectTransform>().anchoredPosition3D = v3p.position;
        }
    }
}
