using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    private const string TAG = "[EventManager]:";

    private static EventManager instance;

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
            return instance;
        }
    }

    public delegate void EventCallback(IEventParam ie);
    public Dictionary<EventEnum, List<EventCallback>> events = new Dictionary<EventEnum, List<EventCallback>>();

    public void test() { }
    /// <summary>
    /// 事件注册
    /// </summary>
    public void AddEvent(EventEnum eventEnum, EventCallback eventCallback)
    {
        if (eventCallback == null)
        {
            Debug.LogError(TAG + $"the eventCallback {eventCallback.ToString()} is null,please check your registered name");
            return;
        }
        List<EventCallback> list = new List<EventCallback>();
        if (events.TryGetValue(eventEnum, out list))
        {
            if (list.Contains(eventCallback))
            {
                Debug.LogError(TAG + $"the events {eventCallback.ToString()} has been registered！");
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
            Debug.LogError(TAG + $"the eventCallback {eventCallback.ToString()} is null,please check your registered name");
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
                Debug.LogError(TAG + $"the events dont contains this eventCallback,please check the events");
            }
        }
        else
        {
            Debug.LogError(TAG + $"the events dont contains this eventCallback,please check the events");
        }
    }

    /// <summary>
    /// 执行事件
    /// </summary>
    public void DispatchEvent(EventEnum eventEnum, IEventParam ie = null)
    {
        if (events.ContainsKey(eventEnum))
        {
            foreach (var v in events[eventEnum])
            {
                if (v != null)
                {
                    v(ie);
                }
            }
        }
        else
        {
            Debug.LogError(TAG + $"the events dont contains this eventCallback({eventEnum}),please check the events");
        }
    }
}
