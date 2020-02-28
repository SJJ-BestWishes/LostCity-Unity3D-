using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class EnemyWeapon : MonoBehaviour
{
    private EnemyAI enemyAI;
    private EnemyAnimatorInfo enemyAnimatorInfo;
    private EnemyInfo enemyInfo;

    private void Start()
    {
        enemyInfo = GetComponentInParent<EnemyInfo>();
        enemyAI = GetComponentInParent<EnemyAI>();
        enemyAnimatorInfo = GetComponentInParent<EnemyAnimatorInfo>();
    }
    private void OnCollisionStay(Collision collision)//由于mesh时刻更新所以Enter 就等于Stay
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log(11);
            PlayerInfo playerInfo = collision.transform.GetComponent<PlayerInfo>();
            if (enemyAI.animatorStateInfo.shortNameHash == enemyAnimatorInfo.attackHash_State && enemyInfo.canAttackHurt)
            {
                enemyInfo.EnterAttackHurtCooling();
                playerInfo.HP -= enemyInfo.attackHurtNumber;
                playerInfo.currentAttackedTimes++;
                Debug.Log("attack");
            }
            else if (enemyAI.animatorStateInfo.normalizedTime>0.5 /*因为播放到一半才真的开始攻击*/&& enemyAI.animatorStateInfo.shortNameHash == enemyAnimatorInfo.skill1Hash_State && enemyInfo.canSkill1Hurt)
            { 
                enemyInfo.EnterSkill1HurtCooling();
                playerInfo.HP -= enemyInfo.skill1HurtNumber;
                playerInfo.currentAttackedTimes++;
                Debug.Log("skill1");
            }
        }
    }
}
