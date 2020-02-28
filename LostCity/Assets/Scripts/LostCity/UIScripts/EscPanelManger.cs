using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class EscPanelManger : MonoBehaviour
{
    public Button continueGanmeBtn;
    public Button helpBtn;
    public Button returnToMainUIBtn;
    [HideInInspector]
    public GameObject loadingPanel;
    public GameObject helpPanel;
    private LoadingPanelManger loadingPanelManger;
    private EffectsSoundsPlayer effectsSoundsPlayer;
    void Start()
    {
        effectsSoundsPlayer = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<EffectsSoundsPlayer>();
        continueGanmeBtn.onClick.AddListener(ContinueGanmeBtn);
        helpBtn.onClick.AddListener(HelpBtn);
        returnToMainUIBtn.onClick.AddListener(ReturnToMainUIBtn);
        loadingPanelManger = loadingPanel.GetComponent<LoadingPanelManger>();
    }
    void ContinueGanmeBtn()
    {
        effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
        gameObject.SetActive(false);
        Time.timeScale = 1;
        //隐藏鼠标
        Cursor.visible = false;
    }
    void HelpBtn()
    {
        effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
        helpPanel.SetActive(true);
    }
    void ReturnToMainUIBtn()
    {
        effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
        loadingPanelManger.LoadSceneByName("1MainUI");
        gameObject.SetActive(false); //避免多次加载场景
    }

}
