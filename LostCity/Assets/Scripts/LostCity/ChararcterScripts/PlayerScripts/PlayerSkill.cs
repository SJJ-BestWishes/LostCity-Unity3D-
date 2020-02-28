using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class PlayerSkill : MonoBehaviour
{
    private Animator animator;
    private PlayerInfo playerInfo;
    private PlayerAnimatorInfo playerAnimatorInfo;
    public AnimatorStateInfo animatorStateInfo;
    // private AnimatorStateInfo animatorStateInfo;
    //用来判断是否只执行一次
    private bool initialOnce = true;
    private void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();
        playerAnimatorInfo = GetComponent<PlayerAnimatorInfo>();
        animator = GameObject.FindGameObjectWithTag("RealPlayer").GetComponent<Animator>();

    }
    void Update()
    {
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //Debug.Log(animatorStateInfo.shortNameHash);
        //Debug.Log(playerAnimatorInfo.attackHash_State);
        //这几个状态只能在idel状态或者walk状态下才能进入
        if (Input.GetKeyDown(KeyCode.R) && playerInfo.canBloodBottle && playerInfo.canEnter)
        {          
            playerInfo.HP += playerInfo.bloodBottleAddNumber;
            playerInfo.EnterBloodBottleCooling();
        }       
        if (Input.GetMouseButton(0) && playerInfo.canAttack && playerInfo.canEnter)
        {
            //if (animatorStateInfo.shortNameHash == playerAnimatorInfo.attackHash_State)
            //{
            //    Debug.Log(11);
            //}
            playerInfo.canEnter = false;
            animator.speed = playerAnimatorInfo.attackAniSpeed;
            animator.SetTrigger(PlayerAnimatorInfo.attackHash);
            playerInfo.EnterAttackCooling();
        }
        if (Input.GetMouseButton(1) && playerInfo.canSkill1 && playerInfo.canEnter)
        {
            playerInfo.canEnter = false;
            animator.speed = playerAnimatorInfo.skill1AniSpeed;
            animator.SetTrigger(PlayerAnimatorInfo.skill1Hash);
            playerInfo.EnterSkill1Cooling();
        }
        if (Input.GetKeyDown(KeyCode.Q) && playerInfo.canRelax && playerInfo.canEnter)
        {
            playerInfo.canEnter = false;
            animator.speed = playerAnimatorInfo.relaxAniSpeed;
            animator.SetTrigger(PlayerAnimatorInfo.relaxHash);
            playerInfo.EnterRelaxCooling();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && playerInfo.canSkill2 && playerInfo.canEnter)
        {
            playerInfo.canEnter = false;
            animator.speed = playerAnimatorInfo.skill2AniSpeed;
            animator.SetTrigger(PlayerAnimatorInfo.skill2Hash);
            playerInfo.EnterSkill2Cooling();
        }
    }

    private void InitialBool()
    {
        playerInfo.canEnter = true;
    }

    //播放Hit动画
    public void EnterHitState()//进入一下
    {
        InitialBool();
        animator.speed = playerAnimatorInfo.hitAniSpeed;
        animator.SetTrigger(PlayerAnimatorInfo.hitHash);
        playerInfo.canEnter = false;
    }

    //播放死亡动画
    public void EnterDieState()//判断回多次进入
    {
        if (initialOnce)
        {
            initialOnce = false;
            InitialBool();
            animator.speed = playerAnimatorInfo.dieAniSpeed;
            animator.SetTrigger(PlayerAnimatorInfo.dieHash);
            playerInfo.canEnter = false;
        }
        else if (animatorStateInfo.normalizedTime >= 0.95 && animatorStateInfo.shortNameHash == playerAnimatorInfo.dieHash_State)
        {           
            Destroy(GameObject.FindGameObjectWithTag("RealPlayer"),0.5f);
        }
    }
}
