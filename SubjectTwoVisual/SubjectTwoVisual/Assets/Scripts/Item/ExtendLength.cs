using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Item模块是根据字体的长度来扩展自身的Width
/// </summary>
public class ExtendLength : MonoBehaviour
{
    public RectTransform parent;
    //最小长度，保证背景图拉满全屏
    private float minLength;
    //上下左右的占空
    public RectOffset Padding;

    public List<RectTransform> childs = new List<RectTransform>();

    private void Start()
    {
        minLength = this.transform.GetComponentInParent<Canvas>().GetComponent<RectTransform>().rect.width;
        for (int i = 0; i < transform.childCount; i++)
        {
            childs.Add(transform.GetChild(i).GetComponent<RectTransform>());
        }
        UpdateLength();
    }

    public void UpdateLength()
    {
        float childLengths = 0;
        //先得到子物体的长度
        foreach (var v in childs)
        {
           
        }
        childLengths += Padding.left + Padding.right;
        Debug.Log("childLengths = " + childLengths);
        Debug.Log("minLength = " + minLength);
        if (childLengths < minLength)
        {
            return;
        }
        else
        {
            Debug.Log("x = " + parent.sizeDelta.x);
            Debug.Log("y = " + parent.sizeDelta.y);
        }
    }
}
