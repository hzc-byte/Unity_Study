using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Root
{
    /// <summary>
    /// 根节点ItemListItem
    /// </summary>
    public List<ItemListItem> itemList { get; set; }

    public Root()
    {
        itemList = new List<ItemListItem>();
    }
}

[Serializable]
public class ItemListItem
{
    /// <summary>
    /// Json编号
    /// </summary>
    public string itemCode { get; set; }
    /// <summary>
    /// Json类型
    /// </summary>
    public string itemName { get; set; }
    /// <summary>
    /// 左右后视镜的参数
    /// </summary>
    public string mirrorConfig { get; set; }
    /// <summary>
    /// 左右小视窗的参数
    /// </summary>
    public List<WindowListItem> windowList { get; set; }
    /// <summary>
    /// 红色点位参数
    /// </summary>
    public List<PointShowListItem> pointShowList { get; set; }
    /// <summary>
    /// 车辆判定条件参数
    /// </summary>
    public List<StageListItem> stageList { get; set; }
}

#region StageListItem
[Serializable]
public class StageListItem
{
    /// <summary>
    /// 编号(不知道干啥用的)
    /// </summary>
    public string stageCode { get; set; }
    /// <summary>
    /// 步骤名字(不知道干啥用的)
    /// </summary>
    public string stageName { get; set; }
    /// <summary>
    /// 车辆判定条件(感觉多了一层)
    /// </summary>
    public List<PointListItem> pointList { get; set; }
}

[Serializable]
public class PointListItem
{
    /// <summary>
    /// 车辆判定条件
    /// </summary>
    public List<EventListItem> eventList { get; set; }
}

[Serializable]
public class EventListItem
{
    /// <summary>
    /// 编号
    /// </summary>
    public string code { get; set; }
    /// <summary>
    /// 具有唯一性，目前与code一致
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 当前的在代码中的回调事件的名称
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 下一个触发的事件
    /// </summary>
    public string nextEventCode { get; set; }
    /// <summary>
    /// 某些事件的指令，可以自己设置
    /// </summary>
    public List<CommondListItem> commondList { get; set; }
    /// <summary>
    /// 条件
    /// </summary>
    public List<object> conditionList { get; set; }
}

[Serializable]
public class CommondListItem
{
    /// <summary>
    /// 指令类型
    /// </summary>
    public string commondType { get; set; }
    /// <summary>
    /// 指令值
    /// </summary>
    public string commondValue { get; set; }
}
#endregion

#region pointShowList
[Serializable]
public class PointShowListItem
{
    /// <summary>
    /// 条件
    /// </summary>
    public List<object> conditionList { get; set; }
    /// <summary>
    /// 代码中的回调函数名称
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 设置场景中的那个红点或者车上的红点属性
    /// </summary>
    public List<PointOptItem> pointOpt { get; set; }
}

[Serializable]
public class PointOptItem
{
    /// <summary>
    /// 场景中的那个红点或者车上的红点
    /// </summary>
    public string code { get; set; }
    /// <summary>
    /// 是否展示
    /// </summary>
    public string isShow { get; set; }
    /// <summary>
    /// 区别车上的红点还是场景的红点
    /// </summary>
    public string type { get; set; }
}
#endregion

#region windowList
/// <summary>
/// 小视窗属性
/// </summary>
[Serializable]
public class WindowListItem
{
    /// <summary>
    /// 类似于ID具有唯一性
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 区别左右小视窗
    /// </summary>
    public string orderNo { get; set; }
    /// <summary>
    /// 小视窗在界面上的左边还是右边
    /// </summary>
    public string postion { get; set; }
    /// <summary>
    /// 小视窗所使用的相机名称
    /// </summary>
    public string cameraName { get; set; }
    /// <summary>
    /// 显示属性，包括条件，点位，车的状态等
    /// </summary>
    public ShowState showState { get; set; }
    /// <summary>
    /// 隐藏属性，包括条件，点位，车的状态等
    /// </summary>
    public HideState hideState { get; set; }
    /// <summary>
    /// 小视窗的摄像机的位置
    /// eg."{\r\n\t\t\t\t\t\t\"positionX\": \"-0.362\",\r\n\t\t\t\t\t\t\"positionY\": \"1.2\",\r\n\t\t\t\t\t\t\"positionZ\": \"-0.017\",\r\n\t\t\t\t\t\t\"rotationX\": \"32.3\",\r\n\t\t\t\t\t\t\"rotationY\": \"276.1\",\r\n\t\t\t\t\t\t\"rotationZ\": \"0\",\r\n\t\t\t\t\t\t\"fieldOfView\": \"70\"\r\n\t\t\t\t\t}"
    /// </summary>
    public string showConfig { get; set; }
}

[Serializable]
public class ShowState
{
    /// <summary>
    /// 显示属性，包括条件，点位，车的状态等
    /// </summary>
    public List<object> conditionList { get; set; }
}

[Serializable]
public class HideState
{
    /// <summary>
    /// 隐藏属性，包括条件，点位，车的状态等
    /// </summary>
    public List<object> conditionList { get; set; }
}
#endregion

#region 通用
#region conditionList专用
[Serializable]
public class CarConditionFirstType
{
    /// <summary>
    /// 指令类型
    /// </summary>
    public string conditionType { get; set; }
    /// <summary>
    /// 车与线的距离
    /// </summary>
    public string distance { get; set; }
    /// <summary>
    /// 判断是否过线
    /// </summary>
    public string isOverLine { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string isShow { get; set; }
    /// <summary>
    /// 判断距离是大于还是小于 0，1
    /// </summary>
    public string compareType { get; set; }
    /// <summary>
    /// 那两个点组成的线段
    /// </summary>
    public Line1 line1 { get; set; }
    /// <summary>
    /// 车上的点
    /// </summary>
    public Point point { get; set; }
}

[Serializable]
public class CarConditionSecondType
{
    /// <summary>
    /// 指令类型
    /// </summary>
    public string conditionType { get; set; }
    /// <summary>
    /// 选择车前进还是倒退的状态
    /// </summary>
    public int carStatus;
}

[Serializable]
public class Line1
{
    /// <summary>
    /// 
    /// </summary>
    public string point1 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string point2 { get; set; }
    /// <summary>
    /// 区分是车上的点还是场景的点
    /// </summary>
    public string type { get; set; }
}

[Serializable]
public class Point
{
    /// <summary>
    /// 
    /// </summary>
    public string point { get; set; }
    /// <summary>
    /// 区分是车上的点还是场景的点
    /// </summary>
    public string type { get; set; }
}
#endregion

#endregion

