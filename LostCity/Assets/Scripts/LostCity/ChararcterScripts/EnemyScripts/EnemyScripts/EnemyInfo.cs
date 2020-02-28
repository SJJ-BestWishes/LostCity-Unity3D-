using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 怪物所有信息
public class EnemyInfo : MonoBehaviour
{
    [Header("手动")]
    public GameObject dieVfx;
    //固定信息
    [Header("固定信息")]
    #region
    //主角的寻路Transform
    public Transform player;
    //真正的主角
    private GameObject realPlayer;
    //最大生命值
    public int maxHp;
    //攻击间隔,现在的冷却时间
    public float attackBreakTime;
    [HideInInspector]
    public float currentAttackBreakTime;
    //技能一间隔,现在的冷却时间
    public float skill1BreakTime;
    [HideInInspector]
    public float currentSkill1BreakTime;
    //技能二间隔,现在的冷却时间
    public float skill2BreakTime;
    [HideInInspector]
    public float currentSkill2BreakTime;
    //血瓶使用间隔,现在的冷却时间
    public float bloodBottleBreakTime;
    [HideInInspector]
    public float currentBloodBottleBreakTime;

    //伤害系统

    //播放一次技能最多结算伤害几次
    public int attackHurtTime = 1;
    public int skill1HurtTime = 2;
    public int skill2HurtTime = 2;
    [HideInInspector]
    public int currentAttackHurtTime = 0;
    [HideInInspector]
    public int currentSkill1HurtTime = 0;
    [HideInInspector]
    public int currentSkill2HurtTime = 0;
    //每次造成伤害多少
    public int attackHurtNumber = 5;
    public int skill1HurtNumber = 3;
    public int skill2HurtNumber = 4;
    //两次造成伤害的间隔
    public float attackHurtBreakTime = 0;
    public float skill1HurtBreakTime = 0.2f;
    public float skill2HurtBreakTime = 0.2f;
    //现在间隔冷却时间
    [HideInInspector]
    public float currentAttackHurtBreakTime = 0;
    [HideInInspector]
    public float currentSkill1HurtBreakTime = 0;
    [HideInInspector]
    public float currentSkill2HurtBreakTime = 0;
    //受到多少次攻击进入Hit打击,现在被打击多少次了
    public int attackedTimesToHit = 5;
    //[HideInInspector]
    public int currentAttackedTimes ;

    //NavMeshAgent属性设置
    //休闲时移动速度
    public float relaxedWalkSpeed = 2.0f;
    //战斗时移动速度
    public float fightWalkSpeed = 6.0f;
    //脱战回去时候的移动速度
    public float fightGoBackWalkSpeed = 10.0f;

    //休闲时转头速度
    public float relaxedAngelSpeed = 240f;
    //战斗时转头速度
    public float fightAngelSpeed = 360f;
    //回去时候的转头速度
    public float goBackAngelSpeed = 720f;

    //休闲时距离目标点停止距离
    public float relaxedStopDistance = 0.1f;
    //战斗时距离主角停止的距离
    public float fightDistance = 2f;
    //回去时候距离目标点停止距离
    public float goBackDistance = 0;
    [Header("怪物脱战距离(距离出生点的距离)")]
    public float outOfDistance = 20f;

    [Header("发现主角临界值设置")]
    //发现主角临界值设置
    //临界角度(怪物Z轴与角色的角度)
    public float FindPlayerCriticalAngel = 60;
    //临界距离
    public float FindPlayercriticalDistance = 5;

    [Header("绘制怪物血条临界值设置")]
    //绘制怪物血条临界距离
    public float drawBloodCriticalDistance;

    #endregion
    //动态信息
    [Header("动态信息")]
    #region
    public int HP = 50;
    //技能是否可用
    public bool canAttack = true;
    public bool canSkill1 = true;
    public bool canSkill2 = true;
    //是否可以结算伤害
    public bool canAttackHurt = true;
    public bool canSkill1Hurt = true;
    public bool canSkill2Hurt = true;
    //血瓶是否可用
    public bool canBloodBottle = true;
    //该状态在进入是时候可以允许别的状态进入打断
    public bool canEnter = true;
    #endregion

    private EnemyAI enemyAI;

    private void Start()
    {
        currentAttackBreakTime = attackBreakTime;
        currentSkill1BreakTime = skill1BreakTime;
        currentSkill2BreakTime = skill2BreakTime;
        InitialHitTimes();//初始化 只要被攻击一次就播放hit动画
        realPlayer = GameObject.FindGameObjectWithTag("RealPlayer");
        enemyAI = GetComponent<EnemyAI>();
        InitialHp();
    }

    private void Update()
    {
        IfEnterSkillCooling();
        IfEnterSkillHurtCooling();
        IfEnterHit();
        IfEnterDie();
        IfPlayerDie();
    }

    //public 方法
    #region
    //技能进入冷却,伤害进入冷却
    #region
    //攻击进入冷却 
    public void EnterAttackCooling()
    {
        canAttack = false;
        currentAttackBreakTime = 0;
    }

    //攻击伤害间隔进入冷却
    public void EnterAttackHurtCooling()
    {
        canAttackHurt = false;
        currentAttackHurtBreakTime = 0;
        currentAttackHurtTime++;
    }

    //技能1进入冷却
    public void EnterSkill1Cooling()
    {
        canSkill1 = false;
        currentSkill1BreakTime = 0;
    }

    //技能1伤害间隔进入冷却
    public void EnterSkill1HurtCooling()
    {
        canSkill1Hurt = false;
        currentSkill1HurtBreakTime = 0;
        currentSkill1HurtTime++;
    }

    //技能2进入冷却
    public void EnterSkill2Cooling()
    {
        canSkill2 = false;
        currentSkill2BreakTime = 0;
    }

    //技能2伤害间隔进入冷却
    public void EnterSkill2HurtCooling()
    {
        canSkill2Hurt = false;
        currentSkill2HurtBreakTime = 0;
        currentSkill2HurtTime++;
    }

    //血瓶进入冷却
    public void EnterBloodBottleCooling()
    {
        canBloodBottle = false;
        currentBloodBottleBreakTime = 0;
    }
    #endregion

    //重置伤害次数
    public void InitialHurtTime()
    {
        currentAttackHurtTime = 0;
        currentSkill1HurtTime = 0;
        currentSkill2HurtTime = 0;
    }

    //重置生命
    public void InitialHp()
    {
        HP = maxHp;
    }

    //初始化被击打次数
    public void InitialHitTimes()
    {
        currentAttackedTimes = attackedTimesToHit-1;
    }

    //进入Hit状态
    public void EnterHitState()
    {
        currentAttackedTimes = attackedTimesToHit;
    }
    #endregion

    //private方法
    #region

    //技能是否进入冷却
    private void IfEnterSkillCooling()
    {
        if (!canAttack)//canAttack==false 要进入冷却
        {
            currentAttackBreakTime += Time.deltaTime;
            if (currentAttackBreakTime >= attackBreakTime)//冷却完
            {
                canAttack = true;
                currentAttackBreakTime = attackBreakTime;
            }
        }
        if (!canSkill1)//canSkill1==false 要进入冷却
        {
            currentSkill1BreakTime += Time.deltaTime;
            if (currentSkill1BreakTime >= skill1BreakTime)//冷却完
            {
                canSkill1 = true;
                currentSkill1BreakTime = skill1BreakTime;
            }
        }
        if (!canSkill2)//canSkill2==false 要进入冷却
        {
            currentSkill2BreakTime += Time.deltaTime;
            if (currentSkill2BreakTime >= skill2BreakTime)//冷却完
            {
                canSkill2 = true;
                currentSkill2BreakTime = skill2BreakTime;
            }
        }
        if (!canBloodBottle)//canBloodBottle==false 要进入冷却
        {
            currentBloodBottleBreakTime += Time.deltaTime;
            if (currentBloodBottleBreakTime >= bloodBottleBreakTime)//冷却完
            {
                canBloodBottle = true;
                currentBloodBottleBreakTime = bloodBottleBreakTime;
            }
        }
    }

    //现在伤害间隔是否进入冷却
    private void IfEnterSkillHurtCooling()
    {
        if (!canAttackHurt)//Skill1Hurt == false 要进入冷却
        {
            currentAttackHurtBreakTime += Time.deltaTime;
            if (currentAttackHurtBreakTime >= attackHurtBreakTime && currentAttackHurtTime <= attackHurtTime - 1)//冷却完,并且要小于最大限制次数-1(因为先结算伤害再增加次数)
            {
                canAttackHurt = true;
            }
        }

        if (!canSkill1Hurt)//canSkill1Hurt == false 要进入冷却
        {
            currentSkill1HurtBreakTime += Time.deltaTime;
            if (currentSkill1HurtBreakTime >= skill1HurtBreakTime && currentSkill1HurtTime <= skill1HurtTime - 1)//冷却完,并且要小于最大限制次数-1(因为先结算伤害再增加次数)
            {
                canSkill1Hurt = true;
            }
        }

        if (!canSkill2Hurt)//canSkill2Hurt == false 要进入冷却
        {
            currentSkill2HurtBreakTime += Time.deltaTime;
            if (currentSkill2HurtBreakTime >= skill2HurtBreakTime && currentSkill2HurtTime <= skill2HurtTime - 1)//冷却完,并且要小于最大限制次数-1(因为先结算伤害再增加次数)
            {
                canSkill2Hurt = true;
            }
        }
    }

    //是否进入打击状态
    private void IfEnterHit()
    {
        if (currentAttackedTimes >= attackedTimesToHit)
        {
            currentAttackedTimes = 0;
            enemyAI.EnterHitState();
        }
    }

    //是否死亡
    private void IfEnterDie()
    {
        if (HP <= 0)
        {
            HP = 0;
            dieVfx.SetActive(true);
            enemyAI.EnterDieState();
        }
    }

    //主角死否死亡
    private void IfPlayerDie()
    {
        if (!realPlayer)
        {
            enemyAI.EnterFightGoBack();
            Destroy(gameObject, 5f);
        }
    }
    #endregion

}
