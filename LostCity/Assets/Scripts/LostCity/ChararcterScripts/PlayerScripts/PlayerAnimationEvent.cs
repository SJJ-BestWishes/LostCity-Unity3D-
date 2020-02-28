using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class PlayerAnimationEvent : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private void Start()
    {
        playerInfo = GetComponentInParent<PlayerInfo>();
    }
    void ShowBattleShoutVfx()
    {
        if (playerInfo.battleShoutVfx.activeSelf == false)
        {
            playerInfo.battleShoutVfx.SetActive(true);
            playerInfo.EnterRelaxState();
        }
    }
    void Initialize()
    {
        playerInfo.canEnter = true;
        playerInfo.InitialHurtTime();
    }
}
