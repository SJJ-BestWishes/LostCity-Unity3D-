using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class EnemyAI : MonoBehaviour
{
    //属性设置
    //普攻间隔
    //public float attackBreak = 3;
    //public bool isAttack;//外部获取
    //private float currentAttackTime = 0;
    //技能间隔
    //public float skillBreak = 6;
    //public bool isSkill;//外部获取
    //private float currentSkillTime = 0;

    private EnemyMotor enemyMotor;
    private Animator animator;
    private EnemyAnimatorInfo enemyAnimatorInfo;
    private EnemyInfo enemyInfo;
    public AnimatorStateInfo animatorStateInfo;

    private bool initialOnce = true;
    public enum State
    { 
        RelaxedFindPath,
        FightFindPath,
        RelaxGoBack,
        FightGoBack,
        Relax,
        Attack,
        Hit,
        Die,
    }
   private State currentState = State.RelaxedFindPath;

    private void Start()
    {
        enemyMotor = GetComponent<EnemyMotor>();
        enemyAnimatorInfo = GetComponent<EnemyAnimatorInfo>();
        enemyInfo = GetComponent<EnemyInfo>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);//需要时刻更新
        switch (currentState)
        {
            case State.RelaxedFindPath:
                RelaxedFindPath();
                break;

            case State.Relax:
                Relax();
                break;

            case State.RelaxGoBack:
                RelaxGoBack();
                break;

            case State.FightFindPath:
                FightFindPath();
                break;

            case State.FightGoBack:
                FightGoBack();
                break;

            case State.Attack:
                Attack();
                break;

            case State.Hit:
                Hit();
                break;

            case State.Die:
                Die();
                break;
        }   
    }

    private void RelaxedFindPath()
    {
        enemyMotor.Findpath();
        animator.speed = enemyAnimatorInfo.walkAniSpeed;
        animator.SetBool(EnemyAnimatorInfo.walkHash, true);
        //Debug.Log(animatorStateInfo.shortNameHash == enemyAnimatorInfo.walkHash_State);
        if (enemyMotor.IsFindPathOver())
        {
            currentState = State.Relax;
            animator.SetBool(EnemyAnimatorInfo.walkHash, false);//从RelaxedFindPath退出，进入Relax时，要禁用走路(需要切换动画)
        }
        else if (enemyMotor.IsFindPlayer())
        {
            currentState = State.FightFindPath;//不需要切换动画
        }
    }

    private void Relax()
    {
        animator.speed = enemyAnimatorInfo.relaxAniSpeed;
        animator.SetBool(EnemyAnimatorInfo.relaxHash,true);
        //Debug.Log(animatorStateInfo.shortNameHash == enemyAnimatorInfo.relaxHash_State);
        if ((animatorStateInfo.normalizedTime >= 0.95f) && (animatorStateInfo.shortNameHash == enemyAnimatorInfo.relaxHash_State))//normalizedTime：0-1在播放、0开始、1结束 
        {
            animator.SetBool(EnemyAnimatorInfo.relaxHash, false);//要切动画
            currentState = State.RelaxGoBack;
        }
        else if (enemyMotor.IsFindPlayer())
        {
            animator.SetBool(EnemyAnimatorInfo.relaxHash, false);//要切动画
            currentState = State.FightFindPath;
        }
    }

    private void RelaxGoBack()
    {
        animator.speed = enemyAnimatorInfo.walkAniSpeed;
        animator.SetBool(EnemyAnimatorInfo.walkHash, true);
        enemyMotor.RelaxGoBack();
        if (enemyMotor.IsBack())
        {
            enemyInfo.InitialHp();
            enemyInfo.InitialHitTimes();
            currentState = State.RelaxedFindPath;//不用切动画
        }
        else if (enemyMotor.IsFindPlayer())
            currentState = State.FightFindPath;//不用切动画
    }

    private void FightFindPath()
    {
        animator.speed = enemyAnimatorInfo.walkAniSpeed;
        animator.SetBool(EnemyAnimatorInfo.walkHash, true);
        enemyMotor.FightFindPath();
        if (enemyMotor.IsOutOfDistance())
            currentState = State.FightGoBack;//不用切动画
        else if (enemyMotor.IsAttack())
        {
            animator.SetBool(EnemyAnimatorInfo.walkHash, false);//要切换动画
            currentState = State.Attack;
        }
    }

    private void FightGoBack()
    {
        animator.speed = enemyAnimatorInfo.walkAniSpeed;
        animator.SetBool(EnemyAnimatorInfo.walkHash, true);
        enemyMotor.FightGoBack();

        //if (enemyMotor.IsFindPlayer())
        //    currentState = State.FightFindPath;怪物以很快的速度回去，不用找主角
        if (enemyMotor.IsBack())
        {
            enemyInfo.InitialHp();
            enemyInfo.InitialHitTimes();
            currentState = State.RelaxedFindPath;//不用切动画
        }
    }

    private void Attack()
    {

        if (!enemyMotor.IsAttack() && enemyInfo.canEnter)//脱离了攻击距离并且，已经播放完攻击动画了
            currentState = State.FightFindPath;
        if (enemyMotor.LookPlayer() && enemyInfo.canSkill1 && enemyInfo.canEnter /*&& enemyMotor.LookPlayer()*/)//每次播放动画的时候都要朝向玩家要写在前面,优先使用技能
        {
            enemyInfo.canEnter = false;
            animator.speed = enemyAnimatorInfo.skill1AniSpeed;
            animator.SetTrigger(EnemyAnimatorInfo.skill1Hash);
            enemyInfo.EnterSkill1Cooling();
        }
        else if (enemyMotor.LookPlayer() && enemyInfo.canAttack && enemyInfo.canEnter /*&& enemyMotor.LookPlayer()*/)//其次攻击
        {
            enemyInfo.canEnter = false;
            animator.speed = enemyAnimatorInfo.attackAniSpeed;
            animator.SetTrigger(EnemyAnimatorInfo.attackHash);
            enemyInfo.EnterAttackCooling();

        }
    }

    private void Hit()
    {
        //非自然条件下进入需要重置所有bool和canEnter只能初始化一次
        if (initialOnce)
        {
            initialOnce = false;           
            animator.speed = enemyAnimatorInfo.hitAniSpeed;
            animator.SetTrigger(EnemyAnimatorInfo.hitHash);
            enemyInfo.canEnter = false;
        }
        else if ((animatorStateInfo.normalizedTime >= 0.90f) && (animatorStateInfo.shortNameHash == enemyAnimatorInfo.hitHash_State))//normalizedTime：0-1在播放、0开始、1结束 
        {
            initialOnce = true;
            currentState = State.FightFindPath;
        }
    }

    private void Die()
    {
        if (initialOnce)//一次
        {
            InitialBool();
            animator.speed = enemyAnimatorInfo.dieAniSpeed;
            animator.SetTrigger(EnemyAnimatorInfo.dieHash);
            initialOnce = false;
        }
        else if ((animatorStateInfo.normalizedTime >= 0.90f) && (animatorStateInfo.shortNameHash == enemyAnimatorInfo.dieHash_State) && !initialOnce)//一次
        {
            Destroy(gameObject,1f);
        }
    }

    private void InitialBool()
    {
        animator.SetBool(EnemyAnimatorInfo.walkHash,false);
        animator.SetBool(EnemyAnimatorInfo.relaxHash, false);
        animator.speed = 1;
        enemyInfo.canEnter = true;
    }

    //public方法
    #region

    //进入被击打状态,只进入一次
    public void EnterHitState()
    {
        InitialBool();
        currentState = State.Hit;
    }

    //进入死亡状态，多次进入
    public void EnterDieState()
    {
        currentState = State.Die;
    }

    //进入FightGoBack状态,只进入一次
    public void EnterFightGoBack()
    {
        if (initialOnce)
        {
            initialOnce = false;
            InitialBool();
            currentState = State.FightGoBack;
        }
    }
    #endregion
}
