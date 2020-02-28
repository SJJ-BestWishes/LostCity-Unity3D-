using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 一个路点(包含多条路线)
public class GetWayPoints : MonoBehaviour
{
    public GameObject enemy;

    public OneWayPath[] lines;
    void Awake()
    {
        InitializeLines();
        enemy.GetComponentInParent<EnemyMotor>().lines=lines;      
    }
    private void InitializeLines()//初始化路线，创建路线，并给每条路线赋予路点
    {
        lines = new OneWayPath[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform transforms = transform.GetChild(i);
            int cout = transforms.childCount;
            lines[i] = new OneWayPath(cout);
            for (int j = 0; j < cout; j++)
            {
                lines[i].Waypoints[j] = transforms.GetChild(j).position;
            }
        }
    }

}
