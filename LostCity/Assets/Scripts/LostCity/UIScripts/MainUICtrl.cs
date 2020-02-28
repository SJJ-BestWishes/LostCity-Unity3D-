using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 控制esc的检测以及隐藏鼠标
public class MainUICtrl : MonoBehaviour
{
    public GameObject escPanel;
    private void Start()
    {
        //隐藏鼠标
        Cursor.visible = false;
    }
    private void Update()
    {
        //检测ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escPanel.SetActive(true);
            Time.timeScale = 0;
            if (Cursor.visible == false)
                Cursor.visible = true;
        }
    }
}
