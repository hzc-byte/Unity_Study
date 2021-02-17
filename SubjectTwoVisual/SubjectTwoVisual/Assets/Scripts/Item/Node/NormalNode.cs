using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalNode : NodeBase
{
    private const string TAG = "[NormalNode]:";
    /// <summary>
    /// 正常节点的唯一标识,与SiblingIndex保持一致性
    /// </summary>
    private int id;
    public int ID { get => id; set => id = value; }
    /// <summary>
    /// 所有的步骤
    /// </summary>
    private EventListItem eventListItem;
    /// <summary>
    /// 判断是否存在eventListItem列表
    /// 用于UI界面的开关
    /// </summary>
    private bool existEventListitem;
    /// <summary>
    /// 红点的步骤
    /// </summary>
    private PointShowListItem pointShowListItem;
    /// <summary>
    /// 判断是否存在pointShowListItem列表
    /// 用于UI界面的开关
    /// </summary>
    private bool existPointShowListItem;
    /// <summary>
    /// 小视窗的步骤
    /// </summary>
    private WindowListItem windowListItem;
    /// <summary>
    /// 判断是否存在windowListItem列表
    /// 用于UI界面的开关
    /// </summary>
    private bool existWindowListItem;
    /// <summary>
    /// 双击的按钮
    /// </summary>
    [SerializeField]
    private UIButton clickBtn;
    /// <summary>
    /// 生成的数据UI
    /// </summary>
    private GameObject Content;

    protected override void OnStart()
    {
        base.OnStart();
        SetPosition();
        clickBtn.OnDoubleClick.AddListener(delegate
        {
            //生成内容UI
            if (Content == null)
            {
                InstantiateContent();
                HideOtherContent();
                AddContentToContents();
            }
            else
            {
                HideOtherContent();
                Content.SetActive(true);
            }
            if (existWindowListItem)
            {
                EventManager.Instance.DispatchEvent(EventEnum.SetWindowListItem, new WindowListItemParam(windowListItem));
                Content.transform.Find("WindowListBG").gameObject.SetActive(true);
            }
            else
            {
                Content.transform.Find("WindowListName").gameObject.SetActive(false);
            }
            if (existPointShowListItem)
            {
                //EventManager.Instance.DispatchEvent(EventEnum.SetPointShowListItem, new PointShowListItemParam(pointShowListItem));
            }
            else
            {
                Content.transform.Find("PointShowListName").gameObject.SetActive(false);
            }
            if (existEventListitem)
            {
                //EventManager.Instance.DispatchEvent(EventEnum.SetEventListItem, new EventListItemParam(eventListItem));
            }
            else
            {
                Content.transform.Find("stageListName").gameObject.SetActive(false);
            }
        });
    }

    /// <summary>
    /// 设置节点的位置
    /// </summary>
    /// <param name="ie"></param>
    private void SetPosition()
    {
        Vector3 position = LastNode.transform.GetComponent<RectTransform>().anchoredPosition3D + new Vector3(LastNode.Length + LastNode.NodeLine.Length, 0, 0);
        this.GetComponent<RectTransform>().anchoredPosition3D = position;
    }

    #region 设置节点内容
    /// <summary>
    /// 设置eventListItem值
    /// 该值是对应节点的内容
    /// 供外部调用
    /// </summary>
    public void SetEventList(EventListItem m_eventListItem)
    {
        if (m_eventListItem == null)
        {
            existEventListitem = false;
            Debug.Log(TAG + $"id = {id} , the node dont exist eventListItem");
            return;
        }
        existEventListitem = true;
        eventListItem = m_eventListItem;
    }

    /// <summary>
    /// 设置windowListItem值
    /// 该值是对应节点的内容
    /// 供外部调用
    /// </summary>
    public void SetWindowList(WindowListItem m_windowListItem)
    {
        if (m_windowListItem == null)
        {
            existWindowListItem = false;
            Debug.Log(TAG + $"id = {id} , the node dont exist windowListItem");
            return;
        }
        existWindowListItem = true;
        windowListItem = m_windowListItem;
    }

    /// <summary>
    /// 设置pointShowListItem值
    /// 该值是对应节点的内容
    /// 供外部调用
    /// </summary>
    public void SetPointShowList(PointShowListItem m_pointShowListItem)
    {
        if (m_pointShowListItem == null)
        {
            existPointShowListItem = false;
            Debug.Log(TAG + $"id = {id} , the node dont exist pointShowListItem");
            return;
        }
        existPointShowListItem = true;
        pointShowListItem = m_pointShowListItem;
    }
    #endregion

    #region Content面板的生成与显示
    /// <summary>
    /// 生成Content面板
    /// </summary>
    private void InstantiateContent()
    {
        Transform parent = GameObject.Find("DataPanel/BG/AddConditionPanel").transform;
        Content = Instantiate(Resources.Load<GameObject>("JsonPrefabs/ItemContent/Content"), parent);
        Debug.Log(TAG + "existEventListitem = " + existEventListitem);
        if (existEventListitem)
        {
            Content.name = eventListItem.name;
        }
        if (parent.GetComponent<ScrollRect>() != null)
        {
            parent.GetComponent<ScrollRect>().content = Content.GetComponent<RectTransform>();
        }
    }

    /// <summary>
    /// 显示当前选中的Content
    /// </summary>
    private void HideOtherContent()
    {
        foreach (var v in ConditionPanel.Contents)
        {
            v.SetActive(false);
        }
    }

    /// <summary>
    /// 把当前的面板添加进Contents中
    /// </summary>
    private void AddContentToContents()
    {
        if (!ConditionPanel.Contents.Contains(Content))
        {
            ConditionPanel.Contents.Add(Content);
        }
    }
    #endregion
}
