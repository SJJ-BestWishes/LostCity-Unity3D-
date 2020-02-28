using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 按钮鼠标移入特效(呼吸特效)，播放移入声音
public class BtnEnterEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private EffectsSoundsPlayer effectsSoundsPlayer;
    private Text text;
    private bool mark = false;
    private float timecounter=0;
    private float halflooptime;
    private Color imaOriginalColor, textOriginalColor;
    public Color imaEndColor = new Color(0, 0, 1), textEndColor = new Color(0, 1, 0);//你呼吸到最后想要的颜色
    public float looptime = 2;//呼吸变换一次时间
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (mark==false)
        {
            mark = !mark;
            effectsSoundsPlayer.PlayAudioImmediatelyByName("移入按键音效",0.5f);
        }
        //当鼠标光标移入该对象时触发

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (mark==true)
        {
            mark = !mark;
            text.color = textOriginalColor;//离开时颜色回复正常
            timecounter = 0;//计数器归0
        }
        //当鼠标光标移出该对象时触发
    }
    private void Start()
    {
        
        //image = GetComponent<Image>();
        //imaOriginalColor = image.color;
        text = GetComponentInChildren<Text>();
        textOriginalColor = text.color;
        halflooptime = looptime / 2;
        effectsSoundsPlayer = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<EffectsSoundsPlayer>();
    }
    private void Update()
    {
        TextColorEffect();
    }
    private void TextColorEffect()
    {
        if (mark && timecounter < halflooptime)
        {
            timecounter += Time.unscaledDeltaTime;
            text.color = Color.Lerp(textOriginalColor, textEndColor, timecounter / halflooptime);
        }
        else if (mark && timecounter > halflooptime && timecounter < looptime)
        {
            timecounter += Time.unscaledDeltaTime;
            text.color = Color.Lerp(textEndColor, textOriginalColor, (timecounter - halflooptime) / halflooptime);
        }
        else if (mark && timecounter > looptime)
        {
            timecounter = 0;
        }
    }//文本颜色呼吸特效
}
