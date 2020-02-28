using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 控制FPS显示
public class ShowFpsManger : MonoBehaviour
{
    public float fpsUpdateTime = 0.1f;
    private float timeCounter = 0;
    private int FPS;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= fpsUpdateTime)
        {
            FPS = Convert.ToInt16(Time.timeScale / Time.deltaTime);
            text.text = "FPS: " + FPS.ToString();
            timeCounter = 0;
        }
    }
    public void ShowFps()
    {
        gameObject.SetActive(true);
    }
    public void OffFps()
    {
        gameObject.SetActive(false);
    }
}
