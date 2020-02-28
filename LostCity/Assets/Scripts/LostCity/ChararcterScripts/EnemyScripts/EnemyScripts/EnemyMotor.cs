using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class EnemyMotor : MonoBehaviour
{
    //已经再GetWayPoints中初始化
    public OneWayPath[] lines;
    //当前路径
    private OneWayPath line;
    //移动到的当前点
    private int currentIndex=0;

    private NavMeshAgent navMeshAgent;
    private EnemyInfo enemyInfo;

    //状态
    public enum State
    {
        FightFindPath,
        RelaxedFindPath,
        RelaxGoBack,
        FightGoback,
        Initial//初始化状态
    }
    State state= State.Initial;


    private void Start()
    {
        enemyInfo = GetComponent<EnemyInfo>();
        line = RandomLines();
        //设置navMeshAgent初始属性
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = true;
        navMeshAgent.acceleration = 100;//加速度设置              
    }
    //休闲寻路
    public void Findpath()
    {
        if (state != State.RelaxedFindPath)
        {
            state = State.RelaxedFindPath;
            navMeshAgent.speed = enemyInfo.relaxedWalkSpeed;
            navMeshAgent.angularSpeed = enemyInfo.relaxedAngelSpeed;
            navMeshAgent.stoppingDistance = enemyInfo.relaxedStopDistance;
        }
        if (Vector3.Distance(transform.position, line.Waypoints[currentIndex]) <= enemyInfo.relaxedStopDistance && currentIndex<line.Waypoints.Length-1)
        {
            currentIndex++;
            navMeshAgent.SetDestination(line.Waypoints[currentIndex]); 
        }
        else if (currentIndex == line.Waypoints.Length - 1 && navMeshAgent.remainingDistance/*Vector3.Distance(transform.position,line.Waypoints[currentIndex])*/<= enemyInfo.relaxedStopDistance && line.IsUsable)//找完路了
            line.IsUsable = false;
    }

    //找到敌人
    public void FightFindPath()
    {
        if (state != State.FightFindPath)
        {
            state = State.FightFindPath;
            navMeshAgent.speed = enemyInfo.fightWalkSpeed;
            navMeshAgent.angularSpeed = enemyInfo.fightAngelSpeed;
            navMeshAgent.stoppingDistance = enemyInfo.fightDistance;
        }
        if (Vector3.Distance(transform.position, enemyInfo.player.position) >= enemyInfo.fightDistance)
        {
            navMeshAgent.SetDestination(enemyInfo.player.position);
        }
    }

    //休闲状态下寻找完路
    public void RelaxGoBack()
    {
        if (state != State.RelaxGoBack)
        {
            state = State.RelaxGoBack;
            navMeshAgent.speed = enemyInfo.relaxedWalkSpeed;
            navMeshAgent.angularSpeed = enemyInfo.goBackAngelSpeed;
            navMeshAgent.stoppingDistance = enemyInfo.goBackDistance;
        }
        currentIndex = 0;
        line.IsUsable = true;
        navMeshAgent.SetDestination(line.Waypoints[0]);
    }

    public void FightGoBack()
    {
        if (state != State.FightGoback)
        {
            state = State.FightGoback;
            navMeshAgent.speed = enemyInfo.fightGoBackWalkSpeed;
            navMeshAgent.angularSpeed = enemyInfo.goBackAngelSpeed;
            navMeshAgent.stoppingDistance = enemyInfo.goBackDistance;
        }
        currentIndex = 0;
        line.IsUsable = true;
        navMeshAgent.SetDestination(line.Waypoints[0]);
    }

    public bool IsFindPathOver()
    {
        if (line.IsUsable == false)
            return true;
        else
            return false;
    }
    //判断是否找到敌人
    public bool IsFindPlayer()
    {
        if (Vector3.Distance(enemyInfo.player.position, transform.position) <= enemyInfo.FindPlayercriticalDistance && Vector3.Angle(transform.forward,enemyInfo.player.position-transform.position) <= enemyInfo.FindPlayerCriticalAngel)
            return true;
        return false;
    }

    //判断怪物距离出生点的距离
    public bool IsOutOfDistance()
    {
        if (Vector3.Distance(line.Waypoints[0], transform.position) >= enemyInfo.outOfDistance)
            return true;
        return false;
    }

    //判断有没有回原位
    public bool IsBack()
    {
        if (/*Vector3.Distance(line.Waypoints[0], transform.position)*/navMeshAgent.remainingDistance <= enemyInfo.relaxedStopDistance)
        {
            currentIndex = 0;//初始化RelaxedFindPath()路点
            line.IsUsable = true;
            return true;
        }
        return false;
    }

    //判断是否应该攻击
    public bool IsAttack()
    {
        if (Vector3.Distance(transform.position, enemyInfo.player.position) <= enemyInfo.fightDistance)
        {
            return true;
        }
        return false;
    }

    //public void Attack()
    //{
    //    if (state != State.FightFindPath)
    //    {
    //        state = State.FightFindPath;
    //        navMeshAgent.speed = enemyInfo.fightWalkSpeed;
    //        navMeshAgent.angularSpeed = enemyInfo.fightAngelSpeed;
    //        navMeshAgent.stoppingDistance = enemyInfo.fightDistance;
    //    }
    //}

    public bool LookPlayer()
    {
        Vector3 ignoreY = new Vector3(enemyInfo.player.position.x - transform.position.x, enemyInfo.player.position.y - transform.position.y, enemyInfo.player.position.z - transform.position.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(ignoreY), enemyInfo.fightAngelSpeed / 120 * Time.timeScale * 100);
        if (Quaternion.Angle(transform.rotation,Quaternion.LookRotation(ignoreY))<3f)
            return true;
        return false;
    }

    OneWayPath RandomLines()
    {
        if (lines != null)
        {            
            return lines[Random.Range(0, lines.Length)];
        }
        return null;//没有路线
    }

}
