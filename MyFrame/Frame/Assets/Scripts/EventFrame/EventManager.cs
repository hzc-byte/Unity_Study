using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private const string TAG = "[EventManager]:";
    public delegate void EventCallback(IEventParam ie);
    public Dictionary<EventEnum, List<EventCallback>> events = new Dictionary<EventEnum, List<EventCallback>>();

    /// <summary>
    /// 事件注册
    /// </summary>
    public void AddEvent(EventEnum eventEnum, EventCallback eventCallback)
    {
        if (eventCallback == null)
        {
            Debug.Log(TAG + $"the eventCallback {eventCallback.ToString()} is null,please check your registered name");
            return;
        }
        List<EventCallback> list = new List<EventCallback>();
        if (events.TryGetValue(eventEnum, out list))
        {
            if (list.Contains(eventCallback))
            {
                Debug.LogWarning(TAG + $"the events {eventCallback.ToString()} has been registered！");
            }
            else
            {
                events[eventEnum].Add(eventCallback);
            }
        }
        else
        {
            events.Add(eventEnum, new List<EventCallback>() { eventCallback });
        }
    }

    /// <summary>
    /// 注销eventEnum下的所有的事件
    /// </summary>
    public void RemoveAllEvent(EventEnum eventEnum)
    {
        if (events.ContainsKey(eventEnum))
        {
            events.Remove(eventEnum);
        }
    }

    /// <summary>
    /// 注销eventEnum下的对应的事件
    /// </summary>
    public void RemoveEvent(EventEnum eventEnum, EventCallback eventCallback)
    {
        if (eventCallback == null)
        {
            Debug.Log(TAG + $"the eventCallback {eventCallback.ToString()} is null,please check your registered name");
            return;
        }
        List<EventCallback> list = new List<EventCallback>();
        if (events.TryGetValue(eventEnum, out list))
        {
            if (list.Contains(eventCallback))
            {
                events[eventEnum].Remove(eventCallback);
            }
            else
            {
                Debug.Log(TAG + $"the events dont contains this eventCallback,please check the events");
            }
        }
        else
        {
            Debug.Log(TAG + $"the events dont contains this eventCallback,please check the events");
        }
    }
}
