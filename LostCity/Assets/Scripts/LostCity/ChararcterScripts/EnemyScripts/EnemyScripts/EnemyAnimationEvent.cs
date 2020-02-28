using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class EnemyAnimationEvent : MonoBehaviour
{
    //private Animator animator;
    private EnemyInfo enemyInfo;
    private void Start()
    {
        //animator = GetComponent<Animator>();
        enemyInfo = GetComponentInParent<EnemyInfo>();
    }
    void Initialize()
    {
        enemyInfo.canEnter = true;
        enemyInfo.InitialHurtTime();
    }
}
