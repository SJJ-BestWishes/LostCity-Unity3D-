using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// TopNameText实现文字渐隐效果,启用MainBtnManger
public class NameTextFade : MonoBehaviour
{
    public float fadeTime = 5.0f;
    public GameObject MainBtnManger,BtnUp,BtnDown;
    private Text text;
    float proportion;
    Color color;
    // Update is called once per frame
    private void Start()
    {
        text = GetComponent<Text>();
        color = text.color;
        MainBtnManger.SetActive(false);
        BtnUp.SetActive(false);
        BtnDown.SetActive(false);
    }
    void Update()
    {
        if (Time.time < fadeTime)//游戏运行时间
        {
            proportion = (Time.time / fadeTime);
            color.a = Mathf.Lerp(0, 1, proportion);
            text.color = color;
        }
        else if (Time.time >= fadeTime)
        {
            MainBtnManger.SetActive(true);
            BtnUp.SetActive(true);
            BtnDown.SetActive(true);
        }
    }
}
