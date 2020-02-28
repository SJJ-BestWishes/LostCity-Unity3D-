using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class PlayerWeapon : MonoBehaviour
{
    private PlayerSkill playerSkill;
    private PlayerAnimatorInfo playerAnimatorInfo;
    private PlayerInfo playerInfo;

    private SkinnedMeshRenderer meshRenderer;
    private MeshCollider collider;
    private void Start()
    {
        playerInfo = GetComponentInParent<PlayerInfo>();
        playerSkill = GetComponentInParent<PlayerSkill>();
        playerAnimatorInfo = GetComponentInParent<PlayerAnimatorInfo>();

        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        collider = GetComponent<MeshCollider>();
    }

    void Update()
    {

        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh); //更新mesh
        collider.sharedMesh = null;
        collider.sharedMesh = colliderMesh; //将新的mesh赋给meshcollider
    }

    private void OnCollisionEnter(Collision collision)//由于mesh时刻更新所以Enter 就等于Stay
    {
        if (collision.transform.tag == "Enemy01")
        {
            EnemyInfo enemyInfo = collision.transform.GetComponent<EnemyInfo>();
            if (playerSkill.animatorStateInfo.shortNameHash == playerAnimatorInfo.attackHash_State && playerInfo.canAttackHurt)
            {
                playerInfo.EnterAttackHurtCooling();
                enemyInfo.HP -= playerInfo.attackHurtNumber;
                enemyInfo.currentAttackedTimes++;
                //Debug.Log("attack");
            }
            else if (playerSkill.animatorStateInfo.shortNameHash == playerAnimatorInfo.skill1Hash_State && playerInfo.canSkill1Hurt)
            {
                playerInfo.EnterSkill1HurtCooling();
                enemyInfo.HP -= playerInfo.skill1HurtNumber;
                enemyInfo.currentAttackedTimes++;
                //Debug.Log("skill1");
            }
            else if (playerSkill.animatorStateInfo.shortNameHash == playerAnimatorInfo.skill2Hash_State && playerInfo.canSkill2Hurt)
            {
                playerInfo.EnterSkill2HurtCooling();
                enemyInfo.HP -= playerInfo.skill2HurtNumber;
                enemyInfo.currentAttackedTimes++;
                //Debug.Log("skill2");
            }
        }
    }

}
