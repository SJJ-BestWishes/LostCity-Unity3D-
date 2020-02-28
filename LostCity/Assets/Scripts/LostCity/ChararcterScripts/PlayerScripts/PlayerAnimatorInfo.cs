using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class PlayerAnimatorInfo : MonoBehaviour
{
    //动画名称
    public string stand;
    public string walk;
    public string run;
    public string hit;
    public string attack;
    public string skill1;
    public string skill2;
    public string die;
    public string relax;
    //每个动画播放速度
    public float standAniSpeed = 1;
    public float walkAniSpeed = 1;
    public float hitAniSpeed = 1;
    public float attackAniSpeed = 1;
    public float skill1AniSpeed = 1;
    public float skill2AniSpeed = 1;
    public float dieAniSpeed = 1;
    public float relaxAniSpeed = 1;
    //跑步动画播放速度根据 物体的走路速度和跑步速度决定
    [HideInInspector]
    public float runAniSpeed;
    private PlayerInfo playerInfo;

    #region
    [HideInInspector]
    public int standHash_State;
    [HideInInspector]
    public int walkHash_State;
    [HideInInspector]
    public int runHash_State;
    [HideInInspector]
    public int hitHash_State;
    [HideInInspector]
    public int attackHash_State;
    [HideInInspector]
    public int skill1Hash_State;
    [HideInInspector]
    public int skill2Hash_State;
    [HideInInspector]
    public int dieHash_State;
    [HideInInspector]
    public int relaxHash_State;

    public static int standHash = Animator.StringToHash("stand");
    public static int walkHash = Animator.StringToHash("walk");
    public static int runHash = Animator.StringToHash("run");
    public static int hitHash = Animator.StringToHash("hit");
    public static int attackHash = Animator.StringToHash("attack");
    public static int skill1Hash = Animator.StringToHash("skill1");
    public static int skill2Hash = Animator.StringToHash("skill2");
    public static int dieHash = Animator.StringToHash("die");
    public static int relaxHash = Animator.StringToHash("relax");
    #endregion
    private void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();
        runAniSpeed = playerInfo.runSpeed / playerInfo.walkSpeed;

        standHash_State = Animator.StringToHash(stand);
        walkHash_State = Animator.StringToHash(walk);
        runHash_State = Animator.StringToHash(run);
        hitHash_State = Animator.StringToHash(hit);
        attackHash_State = Animator.StringToHash(attack);
        skill1Hash_State = Animator.StringToHash(skill1);
        skill2Hash_State = Animator.StringToHash(skill2);
        dieHash_State = Animator.StringToHash(die);
        relaxHash_State = Animator.StringToHash(relax);
    }

}

