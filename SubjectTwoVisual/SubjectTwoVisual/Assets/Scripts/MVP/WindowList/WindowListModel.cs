using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowListModel : ModelBase
{
    private WindowListItem windowListItem;

    public WindowListItem WindowListItem { get => windowListItem; set => windowListItem = value; }

    protected override void OnAwake()
    {
        base.OnAwake();
        EventManager.Instance.AddEvent(EventEnum.SetWindowListItem, SetWindowListItem);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        EventManager.Instance.RemoveEvent(EventEnum.SetWindowListItem, SetWindowListItem);
    }

    private void SetWindowListItem(IEventParam ie)
    {
        if (ie is WindowListItem wli)
        {
            windowListItem = wli;
        }
    }
}
