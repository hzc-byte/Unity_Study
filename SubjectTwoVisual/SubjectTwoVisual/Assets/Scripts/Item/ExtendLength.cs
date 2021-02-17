using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Item模块是根据字体的长度来扩展自身的Width
/// 执行顺序优先于StartNode节点
/// </summary>
public class ExtendLength : MonoBehaviour
{
    private const string TAG = "[ExtendLength]:";
    //当前物体所在的Canvas的父物体
    public RectTransform parent;
    //当前物体的RectTransform
    public RectTransform current;
    //当前物体最小长度（Canvas的宽度）
    private float minLength;
    //扩展的长度
    private float extendLength;
    //当前长度
    private float currentLength;
    //上下左右的占空,子物体的初节点与之有关（Start节点和End节点）
    [SerializeField]
    private RectOffset padding;
    //存储改变之前的值
    private RectOffset lastPadding;
    //该物体下的所有的节点
    public List<Transform> childs = new List<Transform>();

    private void Awake()
    {
        Init();
        GetCurrentLength();
        EventManager.Instance.AddEvent(EventEnum.UpdateUINodeContent, UpdateLength);
    }

    private void Start()
    {
        SetStartNodePosition();
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveEvent(EventEnum.UpdateUINodeContent, UpdateLength);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        parent = this.transform.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        current = this.transform.GetComponent<RectTransform>();
    }

    #region 自身长度根据子物体的长度进行扩展
    /// <summary>
    /// 获取当前物体的长度
    /// </summary>
    private void GetCurrentLength()
    {
        minLength = parent.sizeDelta.x;
        currentLength = parent.sizeDelta.x + current.sizeDelta.x;
    }

    /// <summary>
    /// 判断是否需要扩展长度
    /// </summary>
    private bool JudgeExtendLength()
    {
        float length = 0;
        foreach (var v in childs)
        {
            if (!v.name.Contains("End"))
            {
                length += v.GetComponent<RectTransform>().rect.width + v.Find("Line(Clone)").GetComponent<Line>().Length;
            }
            else
            {
                length += v.GetComponent<RectTransform>().rect.width;
            }
        }
        length += padding.right + padding.left;
        if (length < minLength)
        {
            return false;
        }
        else
        {
            extendLength = length - minLength;
            return true;
        }
    }

    /// <summary>
    /// 更新当前物体的子物体
    /// </summary>
    private void UpdateChildren()
    {
        //TODO:添加删除节点用到
        childs = new List<Transform>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            childs.Add(this.transform.GetChild(i));
        }
    }

    /// <summary>
    /// 更新当前的物体的长度
    /// </summary>
    public void UpdateLength(IEventParam ie)
    {
        //TODO:更新childs
        UpdateChildren();
        if (JudgeExtendLength())
        {
            current.sizeDelta = new Vector2(extendLength, current.sizeDelta.y);
            currentLength += extendLength;
        }
    }
    #endregion

    #region 修改子物体的Start节点的初始位置
    /// <summary>
    /// 如果padding被修改过，就需要修改各个节点的位置
    /// </summary>
    private void SetStartNodePosition()
    {
        Vector3 position = new Vector3(padding.left, padding.top, 0);
        EventManager.Instance.DispatchEvent(EventEnum.SetStartNodePosition, new Vector3Param(position));
    }
    #endregion
}
