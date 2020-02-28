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
/// 事件统一管理
public class MainPanelListenerManger : MonoBehaviour
{
    public Button[] button;
    public Toggle[] toggle;
    public Slider[] slider;
    public Text[] text;
    public Image[] image;
    private EffectsSoundsPlayer effectsSoundsPlayer;
    private MainBtnScroll mainBtnScroll;
    [HideInInspector]
    public GameObject settingsPlane, insertVideoPlane, lighterPlane;
    private void Start()
    {       
        mainBtnScroll = GetComponentInChildren<MainBtnScroll>();
        /*
        settingsPlane = GameObject.FindGameObjectWithTag("SettingsPlane");
        insertVideoPlane = GameObject.FindGameObjectWithTag("InsertVideoPlane");
        *///最好不要这么写因为被禁用的物体检测不到
        effectsSoundsPlayer = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<EffectsSoundsPlayer>();
        foreach (var item in button)//点击
        {    
            //ChangeBtnIma(item,0);//修改
            //ChangeBtnChildText(item, BtnChildTextcolor, BtnCildTextFront, 39);//修改
            item.onClick.AddListener(delegate ()//void
            {
                effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
                OnClick(item.gameObject);
            });
        }
        foreach (var item in toggle)//勾选
        {
            item.onValueChanged.AddListener(delegate (bool selected)//bool=状态
            {
                OnClick(item.gameObject);
            });
        }
        foreach (var item in slider)//滚动条
        {
            item.onValueChanged.AddListener(delegate (float value)//float,valve
            {
                OnClick(item.gameObject);
            });
        }
    }
    //具体编辑点击事件方法
    void OnClick(GameObject obj)
    {
        //开始游戏
        if (obj == button[0].gameObject)
        {
            lighterPlane.GetComponent<LighterPanelFunctionManger>().ImageFade(new Color(1, 1, 1, 1), new Color(0, 0, 0, 1), 2);
            insertVideoPlane.SetActive(true);
            GetComponent<AudioSource>().mute = true;
            goto end;
        }
        //继续游戏
        if (obj == button[1].gameObject)
        {
            goto end;
        }
        //加载游戏
        if (obj == button[2].gameObject)
        {
            goto end;
        }
        //设置
        if (obj == button[3].gameObject)
        {
            settingsPlane.transform.DOMove(transform.position, 0.3f);
            goto end;
        }
        //帮助
        if (obj == button[4].gameObject)
        {
            GameObject.FindGameObjectWithTag("HelpPanel").transform.DOMove(transform.position, 0.3f);
            goto end;
        }
        //退出
        if (obj == button[5].gameObject)
        {
            Application.Quit();
            goto end;
        }
        //up
        if (obj == button[6].gameObject)
        {
            mainBtnScroll.CtrlUp();
            goto end;
        }
        //down
        if (obj == button[7].gameObject)
        {
            mainBtnScroll.CtrlDown();
            goto end;
        }
    end:;
    }

}
