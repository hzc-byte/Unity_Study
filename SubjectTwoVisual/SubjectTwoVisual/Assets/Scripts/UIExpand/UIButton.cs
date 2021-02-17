using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : Button
{
    protected UIButton()
    {
        m_onDoubleClick = new ButtonClickedEvent();
    }

    private ButtonClickedEvent m_onDoubleClick;
    public ButtonClickedEvent OnDoubleClick
    {
        get { return m_onDoubleClick; }
        set { m_onDoubleClick = value; }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 1)
        {
            onClick.Invoke();
        }
        else if (eventData.clickCount == 2)
        {
            if (m_onDoubleClick != null)
            {
                m_onDoubleClick.Invoke();
            }
        }
    }
}

