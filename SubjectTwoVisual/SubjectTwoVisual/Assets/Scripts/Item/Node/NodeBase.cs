using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBase : MonoBehaviour
{
    //唯一标识
    public int ID;
    //节点名字
    public string Name;
    /// <summary>
    /// 当前节点的线
    /// </summary>
    public Line NodeLine;
    //上一个节点，若Start则null
    public NodeBase LastNode;
    //下一个节点，若End则null
    public NodeBase NextNode;
    //节点长度，用来计算位置的
    public float Length;
    //计算得到当前的位置
    protected Vector2 position;

    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    private void Start()
    {
        EventManager.Instance.AddEvent(EventEnum.SetNodeName, SetNodeName);
        OnStart();
    }

    protected virtual void OnStart()
    {

    }

    private void Update()
    {
        OnUpdate();
    }
    protected virtual void OnUpdate() { }

    protected virtual void OnDestroy()
    {
        EventManager.Instance.RemoveEvent(EventEnum.SetNodeName, SetNodeName);
    }

    private void OnApplicationQuit()
    {
        OnQuit();
    }

    protected virtual void OnQuit()
    {

    }

    private void SetNodeName(IEventParam ie)
    {
        if (ie is StringParam sp)
        {
            Name = sp.str;
        }
    }
}
