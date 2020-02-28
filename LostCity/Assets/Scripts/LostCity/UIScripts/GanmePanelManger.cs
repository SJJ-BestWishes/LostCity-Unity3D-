using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 显示技能冷却，加血冷却，更新人物状态信息
public class GanmePanelManger : MonoBehaviour
{
    public Image[] skillIma;
    public Image addHpIma;
    public Slider hpSlider;
    public Slider expSlider;
    private PlayerInfo playerInfo;
    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        //初始化滑块最大值,最小值默认为0
        hpSlider.maxValue = playerInfo.maxHp;
        expSlider.maxValue = playerInfo.maxExp;
    }
    private void Update()
    {
        hpSlider.value = playerInfo.HP;
        expSlider.value = playerInfo.EXP;

        skillIma[0].fillAmount = playerInfo.currentRelaxBreakTime / playerInfo.relaxBreakTime;
        skillIma[1].fillAmount = playerInfo.currentSkill1BreakTime / playerInfo.skill1BreakTime;
        skillIma[2].fillAmount = playerInfo.currentSkill2BreakTime / playerInfo.skill2BreakTime;

        addHpIma.fillAmount = playerInfo.currentBloodBottleBreakTime / playerInfo.bloodBottleBreakTime;
    }
}
