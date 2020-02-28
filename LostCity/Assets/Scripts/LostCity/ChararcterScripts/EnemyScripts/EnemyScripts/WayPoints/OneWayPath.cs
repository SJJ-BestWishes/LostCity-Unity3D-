using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class OneWayPath//不用继承，一条路线
{
    /// <summary>
    /// 当前路线的左右路点坐标,Waypoints[0]为怪物出生点坐标
    /// </summary>
    public Vector3[] Waypoints { get; set; }
    /// <summary>
    /// 是否可用
    /// </summary>
    public bool IsUsable { get; set; }
    public OneWayPath(int points)//路点个数
    {
        Waypoints = new Vector3[points];
        IsUsable = true;
    }
}