using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class HelpPanelManger : MonoBehaviour
{
    public Button returnButton;
    private EffectsSoundsPlayer effectsSoundsPlayer;
    private Vector3 OriginalPosition = new Vector3(1700, 0, 0);
    void Start()
    {
        effectsSoundsPlayer = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<EffectsSoundsPlayer>();
        returnButton.onClick.AddListener(MainUI);
    }

    private void MainUI()
    {
        effectsSoundsPlayer.PlayAudioImmediatelyByName("点击按钮");//每一个按钮都会触发写在这里
        transform.DOLocalMove(OriginalPosition, 0.3f);
    }
}
