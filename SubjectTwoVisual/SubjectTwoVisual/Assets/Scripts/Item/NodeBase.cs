using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeBase : MonoBehaviour
{
    /// <summary>
    /// 节点的ID，唯一标志
    /// </summary>
    public int ID;
    /// <summary>
    /// 节点的名字
    /// </summary>
    public string Name;
    /// <summary>
    /// 节点的长度
    /// TODO：为了计算Content的长度
    /// </summary>
    public float Width;
    /// <summary>
    /// 上一个节点
    /// Start是没有上一个节点的，所以该节点在Start的时候可以为null
    /// </summary>
    public NodeBase PreviousNode;
    /// <summary>
    /// 下一个节点
    /// Edna是没有下一个节点的，所以该节点在End的时候可以为null
    /// </summary>
    public NodeBase NextNode;
    /// <summary>
    /// 上一个节点连接到该节点的按钮
    /// 如果接触到的话，PreviousNode记录上一个节点
    /// TODO：Button重写
    /// </summary>
    public Button PreviousBtn;
    /// <summary>
    /// 该节点连接到下一个节点的按钮
    /// 如果接触到的话，NextNode记录下一个节点
    /// TODO：Button重写
    /// </summary>
    public Button NextBtn;


    /// <summary>
    /// 设置当前节点的宽度，根据已有的宽度+线段的长度
    /// </summary>
    public void SetItemWidth()
    {

    }
}
