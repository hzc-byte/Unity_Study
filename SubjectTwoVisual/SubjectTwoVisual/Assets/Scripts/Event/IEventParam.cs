using UnityEngine;

public interface IEventParam
{

}

public class StringParam : IEventParam
{
    public string str;
    public StringParam(string m_str)
    {
        str = m_str;
    }
}

/// <summary>
/// 用于Start节点的位置
/// </summary>
public class RectOffestParam : IEventParam
{
    public RectOffset rect;
    public RectOffestParam(RectOffset m_rect)
    {
        rect = m_rect;
    }
}

public class Vector3Param : IEventParam
{
    public Vector3 position;
    public Vector3Param(Vector3 m_position)
    {
        position = m_position;
    }
}

public class WindowListItemParam : IEventParam
{
    public WindowListItem item;
    public WindowListItemParam(WindowListItem m_item)
    {
        item = m_item;
    }
}

public class PointShowListItemParam : IEventParam
{
    public PointShowListItem item;
    public PointShowListItemParam(PointShowListItem m_item)
    {
        item = m_item;
    }
}

public class EventListItemParam : IEventParam
{
    public EventListItem item;
    public EventListItemParam(EventListItem m_item)
    {
        item = m_item;
    }
}