using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// SettingsPlane按钮的实现
public class SettingsPanelLisnerManger : MonoBehaviour
{
    public Button[] button;
    public Toggle[] toggle;
    public Scrollbar[] scrollbar;
    public Text[] text;
    public Image[] image;
    public GameObject voiceLayout, screenLayout, keyChangeLayout, fpsShower, lighterPlane;
    private ShowFpsManger showFpsManger;
    private Color lighterPanelShowColor = new Color(0, 0, 0, 0), lighterPanelOriginalColor;
    private Vector3 originalPositon = new Vector3(1700,0,0);//settingsPanel原始位置
    private EffectsSoundsPlayer effectsSoundsPlayer;
    private BackgroundSoundsPlayer backgroundSoundsPlayer;
    private void Start()
    {
        showFpsManger = fpsShower.GetComponent<ShowFpsManger>();
        lighterPanelOriginalColor = lighterPlane.GetComponent<Image>().color;
        effectsSoundsPlayer = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<EffectsSoundsPlayer>();
        backgroundSoundsPlayer= GameObject.FindGameObjectWithTag("BackgroundSoundsPlayer").GetComponent<BackgroundSoundsPlayer>();

        foreach (var item in button)//点击
        {
            item.gameObject.AddComponent<BtnEnterEffects1>();//每个按钮添加移入声音特效
            item.onClick.AddListener(delegate ()//void
            {
                effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
                OnClick(item.gameObject);
            });
        }
        foreach (var item in toggle)//勾选
        {
            item.gameObject.AddComponent<BtnEnterEffects1>();//每个按钮添加移入声音特效
            item.onValueChanged.AddListener(delegate (bool selected)//bool=状态
            {
                effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
                OnClick(item);
            });
        }
        foreach (var item in scrollbar)//滚动条
        {
            item.gameObject.AddComponent<BtnEnterEffects1>();//每个按钮添加移入声音特效
            item.onValueChanged.AddListener(delegate (float value)//float,valve
            {
                effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里               
                OnClick(item);
            });
        }
    }
    //具体编辑点击事件方法
    void OnClick(GameObject obj)
    {
        //关闭
        if (obj == button[0].gameObject)
        {           
            transform.DOLocalMove(originalPositon, 0.3f);
            goto end;
        }
        //恢复
        if (obj == button[1].gameObject)
        {
            if (!button[2].GetComponent<Image>().IsActive())//现在处于设置音频
            {
                effectsSoundsPlayer.GetComponent<AudioSource>().volume = 0.5f;
                scrollbar[0].value = 0.5f;
                backgroundSoundsPlayer.GetComponent<AudioSource>().volume = 0.5f;
                scrollbar[1].value = 0.5f;
                //少语音音量
                goto end;
            }
            if (!button[3].GetComponent<Image>().IsActive())//现在处于设置显示
            {
                lighterPlane.GetComponent<Image>().color = lighterPanelOriginalColor;
                scrollbar[3].value = 1f;
                toggle[0].isOn = false;
                goto end;
            }

        }
        //设置音频
        if (obj == button[2].gameObject)
        {
            if(button[2].GetComponent<Image>().IsActive())
            {
                button[2].GetComponent<Image>().enabled = false;
                button[3].GetComponent<Image>().enabled = true;
                button[4].GetComponent<Image>().enabled = true;
                voiceLayout.SetActive(true);
                screenLayout.SetActive(false);
                keyChangeLayout.SetActive(false);
            }
            goto end;
        }
        //设置显示
        if (obj == button[3].gameObject)
        {
            if (button[3].GetComponent<Image>().IsActive())
            {
                button[2].GetComponent<Image>().enabled = true;
                button[3].GetComponent<Image>().enabled = false;
                button[4].GetComponent<Image>().enabled = true;
                voiceLayout.SetActive(false);
                screenLayout.SetActive(true);
                keyChangeLayout.SetActive(false);
            }
            goto end;
        }
        //设置按键
        if (obj == button[4].gameObject)
        {
            if (button[4].GetComponent<Image>().IsActive())
            {
                button[2].GetComponent<Image>().enabled = true;
                button[3].GetComponent<Image>().enabled = true;
                button[4].GetComponent<Image>().enabled = false;
                voiceLayout.SetActive(false);
                screenLayout.SetActive(false);
                keyChangeLayout.SetActive(true);
            }
            goto end;
        }
    end:;
    }
    void OnClick(Scrollbar obj)
    {
        //设置背景音乐
        if (obj == scrollbar[0])
        {
            backgroundSoundsPlayer.gameObject.GetComponent<AudioSource>().volume = scrollbar[0].value;
            text[0].text = (scrollbar[0].value*100).ToString();
            goto end;
        }
        //设置游戏特效声音
        if (obj == scrollbar[1])
        {
            effectsSoundsPlayer.GetComponent<AudioSource>().volume = scrollbar[1].value;
            text[1].text = (scrollbar[1].value * 100).ToString();
            goto end;
        }

        //少设置游戏语音声音
        if (obj == scrollbar[2])
        {
            text[2].text = (scrollbar[2].value * 100).ToString();
            goto end;
        }
        //设置游戏屏幕亮度
        if (obj == scrollbar[3])
        {
            lighterPanelShowColor.a = (200 - scrollbar[3].value * 200) / 255;
            lighterPlane.GetComponent<Image>().color = lighterPanelShowColor;
            text[3].text = (scrollbar[3].value * 100).ToString();
            goto end;
        }       
    end:;
    }
    void OnClick(Toggle obj)
    {
        //设置显示FPS
        if (obj == toggle[0])
        {
            if (toggle[0].isOn)
                showFpsManger.ShowFps();
            else
                showFpsManger.OffFps();
            goto end;
        }
    end:;
    }
}
