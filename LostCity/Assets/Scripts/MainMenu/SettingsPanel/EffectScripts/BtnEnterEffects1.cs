using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 播放移入声音
public class BtnEnterEffects1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private EffectsSoundsPlayer effectsSoundsPlayer;
    private bool mark = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (mark == false)
        {
            mark = !mark;
            effectsSoundsPlayer.PlayAudioImmediatelyByName("移入按键音效", 0.5f);
        }
        //当鼠标光标移入该对象时触发
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (mark == true)
        {
            mark = !mark;
        }
        //当鼠标光标移出该对象时触发
    }
    private void Start()
    {
        effectsSoundsPlayer = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<EffectsSoundsPlayer>();
    }
}
