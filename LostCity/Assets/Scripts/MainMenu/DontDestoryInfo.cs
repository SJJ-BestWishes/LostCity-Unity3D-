using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 设置要保存的数据和对象（需要调用实现）
public class DontDestoryInfo : MonoBehaviour
{
    public GameObject[] dontDestorys;//手动找到那些带有DontDestory标签的；
    [HideInInspector]
    public GameObject fpsShower;
    public float backgroundSoundsPlayerVolume, effectsSoundsPlayerVolume;
    public Color lighterPanelcolor;
    public bool fpsIsOn;
    private void Start()
    {
        //dontDestorys = GameObject.FindGameObjectsWithTag("DontDestory");//不能这么找因为很多都是未未激活的，找不到
    }
    public void UpdateInfo()
    {
        backgroundSoundsPlayerVolume = GameObject.FindGameObjectWithTag("BackgroundSoundsPlayer").GetComponent<AudioSource>().volume;
        effectsSoundsPlayerVolume = GameObject.FindGameObjectWithTag("SoundsEffectPlayer").GetComponent<AudioSource>().volume;
        lighterPanelcolor = GameObject.FindGameObjectWithTag("LighterPanel").GetComponent<Image>().color;
        fpsIsOn = fpsShower.activeInHierarchy;
    }
    public void DontDestoryOnLoad()
    {
        foreach (var item in dontDestorys)
        {
            DontDestroyOnLoad(item);
        }
    }
}
