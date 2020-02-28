using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class LoadingPanelManger : MonoBehaviour
{
    private AsyncOperation rateOfProgress;
    private float showProgress = 0;
    private float timecounter = 0;
    private float halflooptime;
    private Color textOriginalColor;
    private Slider slider;
    private Text text;

    public float looptime = 2;//呼吸变换一次时间
    public Color textEndColor = new Color(1, 1, 1);//你呼吸到最后想要的颜色

    private void Awake()
    {
        //恢复时间
        Time.timeScale = 1;
        //恢复鼠标
        Cursor.visible = true;
        //滑块，文本初始化
        slider = GetComponentInChildren<Slider>();
        text = slider.GetComponentInChildren<Text>();
        slider.interactable = false;
        slider.maxValue = 100;
        //呼吸特效初始化
        halflooptime = looptime / 2;
        textOriginalColor = text.color;
    }
    private void TextColorEffect()
    {
        if (timecounter < halflooptime)
        {
            timecounter += Time.deltaTime;
            text.color = Color.Lerp(textOriginalColor, textEndColor, timecounter / halflooptime);
        }
        else if (timecounter > halflooptime && timecounter < looptime)
        {
            timecounter += Time.deltaTime;
            text.color = Color.Lerp(textEndColor, textOriginalColor, (timecounter - halflooptime) / halflooptime);
        }
        else if (timecounter > looptime)
        {
            timecounter = 0;
        }
    }//文本颜色呼吸特效
   
    public void LoadSceneByName(string name)
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadScene(name));
    }

    IEnumerator LoadScene(string name)
    {
        rateOfProgress = SceneManager.LoadSceneAsync(name);
        rateOfProgress.allowSceneActivation = false;
        yield return null;
    }

    private void Update()
    {
        if (rateOfProgress == null)
        {
            return;
        }
        else
        {
            if (showProgress < rateOfProgress.progress * 100 / 0.9f)
            {
                showProgress++;
                slider.value = showProgress;
                text.text = "Progress: " + showProgress.ToString() + "%";
            }
            else if (showProgress >= 100)
            {
                TextColorEffect();
                text.text = "按空格键进入场景";
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    rateOfProgress.allowSceneActivation = true;
                }
            }
        }

    }

}
