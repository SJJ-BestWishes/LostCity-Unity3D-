using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 背景渐渐出现特效 
public class BackGroundFade : MonoBehaviour
{
    public float fadeTime = 3.0f;
    private  Image image;
    float proportion;
    float timmer;
    Color color;
    // Update is called once per frame
    private void Start()
    {
        image = GetComponent<Image>();
        color = image.color;
    }
    void Update()
    {
        if (Time.time < fadeTime)//游戏运行时间
        {
            proportion = (Time.time / fadeTime);
            color.a = Mathf.Lerp(0, 1, proportion);
            image.color = color;
        }
    }
}
