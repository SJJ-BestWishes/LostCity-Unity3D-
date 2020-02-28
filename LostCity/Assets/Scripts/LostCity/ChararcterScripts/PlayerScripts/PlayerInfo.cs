using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 人物所有信息
public class PlayerInfo : MonoBehaviour
{
    [Header("手动")]
    //失败面板
    public GameObject failPanel;
    //战吼特效
    public GameObject battleShoutVfx;
    //战吼持续时间
    public float battleShoutVfxDuration;
    //加速特效
    public GameObject runVfx;
    [Header("固定信息")]
    //固定信息
    #region
    //最大生命值
    public int maxHp;
    //升级最大经验值
    public int maxExp;
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
    //战吼冷却时间,持续时间(这里用relax)
    public float relaxBreakTime;
    [HideInInspector]
    public float currentRelaxBreakTime;

    //血瓶使用间隔,现在的冷却时间
    public float bloodBottleBreakTime;
    [HideInInspector]
    public float currentBloodBottleBreakTime;

    //player Motor
    //走路时候的速度
    public float walkSpeed;
    //跑步时候的速度
    public float runSpeed;
    //人物转速度(度数)
    public float rotateSpeed = 0.1f;
    //摄像机围绕人物旋转MouseX速度
    public float cameraXSpeed;
    //摄像机围绕人物旋转MouseY速度
    public float cameraYSpeed;
    //摄像机仰角最大值(camrea.localRotation.x)
    public float cameraAngleOfElevation = 60.0f;
    //摄像机俯角最小值
    public float cameraAngleOfDepression = -20.0f;
    //摄像机距离人物的距离(localposition)
    public Vector3 cameraLocalPosition;
    //摄像机角度(localRotation)
    public Vector3 cameraLocalRotation;
    #endregion

    //伤害系统

    //血瓶恢复血量
    public int bloodBottleAddNumber = 10;
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
    public int currentAttackedTimes;

    //动态信息
    [Header("动态信息")]
    #region
    public int HP = 50;
    public int EXP = 0;
    //技能是否可用
    public bool canAttack = true;
    public bool canSkill1 = true;
    public bool canSkill2 = true;
    public bool canRelax = true;
    //是否可以结算伤害
    public bool canAttackHurt = true;
    public bool canSkill1Hurt = true;
    public bool canSkill2Hurt = true;
    //血瓶是否可用
    public bool canBloodBottle = true;
    //该状态在进入是时候可以允许别的状态进入打断
    public bool canEnter = true;
    #endregion

    private PlayerSkill playerSkill;
    private bool initialOnce = true;

    private void Start()
    {
        currentAttackBreakTime = attackBreakTime;
        currentSkill1BreakTime = skill1BreakTime;
        currentSkill2BreakTime = skill2BreakTime;
        currentRelaxBreakTime = relaxBreakTime;
        currentBloodBottleBreakTime = bloodBottleBreakTime;

        playerSkill = GetComponent<PlayerSkill>();
        InitialHp();
    }

    private void Update()
    {
        IfEnterSkillCooling();
        IfEnterSkillHurtCooling();
        IfEnterHit();
        IfEnterDie();
        IfEnterBattleShoutCooling();
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

    //Relax进入冷却
    public void EnterRelaxCooling()
    {
        canRelax = false;
        currentRelaxBreakTime = 0;
    }

    #endregion
    //重置伤害次数
    public void InitialHurtTime()
    {
        currentAttackHurtTime = 0;
        currentSkill1HurtTime = 0;
        currentSkill2HurtTime = 0;
    }

    //进入Hit状态
    public void EnterHitState()
    {
        currentAttackedTimes = attackedTimesToHit;
    }

    //重置生命
    public void InitialHp()
    {
        HP = maxHp;
    }

    //进入战吼状态,攻击翻倍
    public void EnterRelaxState()
    {
        attackHurtNumber *= 2;
        skill1HurtNumber *= 2;
        skill2HurtNumber *= 2;
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
        if (!canRelax)//canRelax==false 要进入冷却
        {
            currentRelaxBreakTime += Time.deltaTime;
            if (currentRelaxBreakTime >= relaxBreakTime)//冷却完
            {
                canRelax = true;
                currentRelaxBreakTime = relaxBreakTime;
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

    //战吼进入冷却
    private void IfEnterBattleShoutCooling()
    {
        if (currentRelaxBreakTime >= battleShoutVfxDuration && battleShoutVfx.activeSelf)
        {
            battleShoutVfx.SetActive(false);
            InitialHurtNumber();
        }
    }

    //是否进入打击状态
    private void IfEnterHit()
    {
        if (currentAttackedTimes >= attackedTimesToHit && HP>0)
        {
            currentAttackedTimes = 0;
            playerSkill.EnterHitState();
        }
    }

    //是否死亡
    private void IfEnterDie()
    {
        if (HP <= 0)
        {
            HP = 0;
            playerSkill.EnterDieState();
            if (initialOnce)//只有一次
            {
                initialOnce = false;
                failPanel.SetActive(true);
            }
        }
    }

    //战吼状态结束,攻击减半
    private void InitialHurtNumber()
    {
        attackHurtNumber /= 2;
        skill1HurtNumber /= 2;
        skill2HurtNumber /= 2;
    }
    #endregion




}