using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private const string TAG = "[Test]:";
    public ScrollRect scrollRect;//不同的五项滑动条的Content不一样
    public Transform ContentParent;//五项的Content所在的父物体
    private Transform NodeParent;//节点所在的父物体
    private Root root;//json内容
    private string path;//json路径
    private void Awake()
    {
        ReadJson();
        InstantiateNodeParent();
        InstantiateItemPrefabs();
    }

    /// <summary>
    /// 获取到json内容
    /// </summary>
    private void ReadJson()
    {
        path = Application.dataPath + "/Resources/GuideConfig/20100.json";
        root = JsonManager.FromJson<Root>(path);
    }

    /// <summary>
    /// 生成父物体
    /// </summary>
    private void InstantiateNodeParent()
    {
        NodeParent = Instantiate(Resources.Load<GameObject>("JsonPrefabs/Content/Content"), ContentParent).transform;
        scrollRect.content = NodeParent.GetComponent<RectTransform>();
    }

    /// <summary>
    /// 生成节点
    /// </summary>
    private void InstantiateItemPrefabs()
    {
        GameObject start = Instantiate(Resources.Load<GameObject>("ItemPrefabs/Start"), NodeParent);
        #region 给json中公用的不好处理的数据赋值
        StartNode startNode = start.GetComponent<StartNode>();
        startNode.ItemCode = root.itemList[0].itemCode;
        startNode.ItemName = root.itemList[0].itemName;
        startNode.MirrorConfig = root.itemList[0].mirrorConfig;
        startNode.StageCode = root.itemList[0].stageList[0].stageCode;
        startNode.StageName = root.itemList[0].stageList[0].stageName;
        #endregion
        for (int i = 0; i < root.itemList[0].stageList[0].pointList[0].eventList.Count; i++)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>("ItemPrefabs/Item"), NodeParent);
            item.SetActive(false);
            item.transform.SetAsLastSibling();
            item.name = root.itemList[0].stageList[0].pointList[0].eventList[i].name;
            item.SetActive(true);
            NormalNode normalNode = item.GetComponent<NormalNode>();
            normalNode.Name = item.name;
            normalNode.ID = i + 1;
            #region 给节点中的列表赋值
            normalNode.SetEventList(root.itemList[0].stageList[0].pointList[0].eventList[i]);
            normalNode.SetWindowList(root.itemList[0].windowList.Find(windowList => windowList.name == root.itemList[0].stageList[0].pointList[0].eventList[i].name));
            normalNode.SetPointShowList(root.itemList[0].pointShowList.Find(pointList => pointList.name == root.itemList[0].stageList[0].pointList[0].eventList[i].name));
            #endregion
        }
        GameObject end = Instantiate(Resources.Load<GameObject>("ItemPrefabs/End"), NodeParent);
        end.transform.SetAsLastSibling();
        //给每个节点赋值LastNode和NextNode
        for (int i = 0; i < NodeParent.childCount; i++)
        {
            if (i != NodeParent.childCount - 1)
            {
                Line line = InstantiateLine(NodeParent.GetChild(i));
                NodeParent.GetChild(i).GetComponent<NodeBase>().NodeLine = line;
            }
            if (i == 0)
            {
                NodeParent.GetChild(i).GetComponent<NodeBase>().LastNode = null;
                NodeParent.GetChild(i).GetComponent<NodeBase>().NextNode = NodeParent.GetChild(i + 1).GetComponent<NodeBase>();
            }
            else if (i == NodeParent.childCount - 1)
            {
                NodeParent.GetChild(i).GetComponent<NodeBase>().LastNode = NodeParent.GetChild(i - 1).GetComponent<NodeBase>();
                NodeParent.GetChild(i).GetComponent<NodeBase>().NextNode = null;//最后一个节点是没有下一个节点以及线的
            }
            else
            {
                NodeParent.GetChild(i).GetComponent<NodeBase>().LastNode = NodeParent.GetChild(i - 1).GetComponent<NodeBase>();
                NodeParent.GetChild(i).GetComponent<NodeBase>().NextNode = NodeParent.GetChild(i + 1).GetComponent<NodeBase>();
            }
        }
        //TODO:会有个跟节点执行顺序的问题
        EventManager.Instance.DispatchEvent(EventEnum.UpdateUINodeContent);
    }

    /// <summary>
    /// 生成线
    /// </summary>
    /// <returns></returns>
    private Line InstantiateLine(Transform parent)
    {
        GameObject line = Instantiate(Resources.Load<GameObject>("ItemPrefabs/Line"));
        line.name.Replace("(Clone)", "");
        Vector3 position = new Vector3(parent.GetComponent<NodeBase>().Length + parent.GetComponent<RectTransform>().anchoredPosition3D.x, 0f, 0);
        line.GetComponent<RectTransform>().anchoredPosition3D = position;
        line.transform.SetParent(parent);
        line.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(line.GetComponent<RectTransform>().anchoredPosition3D.x, 36.53f, 0);
        line.transform.SetAsLastSibling();
        return line.GetComponent<Line>();
    }
}
