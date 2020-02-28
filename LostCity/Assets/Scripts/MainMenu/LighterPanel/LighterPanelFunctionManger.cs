using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 有一个方法在SettingsPlaneListenerManger的设置显示亮度
/// 亮度特效
public class LighterPanelFunctionManger : MonoBehaviour
{
    private Image image;
    private Color originalColor;
    private void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }
    private void ResetColor()
    {
        image.color = originalColor;
    }
    public void ImageFade(Color beginColor, Color endColor , float time)
    {
        image.color = beginColor;
        image.DOColor(endColor, time);
        Invoke("ResetColor", time+0.1f);
    }
    public void ImageFade(Color beginlColor, float time)
    {
        image.color = beginlColor;
        image.DOColor(originalColor,time);
    }
    
}
