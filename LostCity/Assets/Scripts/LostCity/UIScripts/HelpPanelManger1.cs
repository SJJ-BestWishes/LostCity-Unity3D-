using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class HelpPanelManger1 : MonoBehaviour
{
    public Button returnButton;
    private EffectsSoundsPlayer effectsSoundsPlayer;
    void Start()
    {
        effectsSoundsPlayer = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<EffectsSoundsPlayer>();
        returnButton.onClick.AddListener(MainUI);
    }

    private void MainUI()
    {
        effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
        gameObject.SetActive(false);
    }
}
