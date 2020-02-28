using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class FailPanelManger : MonoBehaviour
{
    public Button returnToMainUIBtn;
    [HideInInspector]
    public GameObject loadingPanel;
    private EffectsSoundsPlayer effectsSoundsPlayer;
    private LoadingPanelManger loadingPanelManger;
    void Start()
    {
        effectsSoundsPlayer = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<EffectsSoundsPlayer>();
        returnToMainUIBtn.onClick.AddListener(ReturnToMainUIBtn);
        loadingPanelManger = loadingPanel.GetComponent<LoadingPanelManger>();
        GetComponent<Image>().DOColor(new Color(1,1,1,1),5);
        Cursor.visible = true;
    }
    void ReturnToMainUIBtn()
    {
        effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
        loadingPanelManger.LoadSceneByName("1MainUI");
        gameObject.SetActive(false);//避免多次加载场景
    }

}
