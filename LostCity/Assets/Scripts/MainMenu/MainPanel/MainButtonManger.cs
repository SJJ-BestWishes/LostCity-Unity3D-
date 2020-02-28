using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 主界面按钮属性设置,并给他们添加呼吸特效的脚本
public class MainButtonManger : MonoBehaviour
{
    public Font BtnCildTextFront;
    public Button Up, Down;
    private Color BtnImacolor;//BtnImacolor
    private Color BtnChildTextColor= new Color(1.0f, 0.0f, 0.0f);//BtnChildtext.color
    private Color BtnUpDownColor = new Color(0.0f, 1.0f, 1.0f);//BtnUpDowntext.color
    private Image[] images;
    private Text[] texts;
    void Start()
    {
        images = GetComponentsInChildren<Image>();//获取Btn组件下的Ima images[0]是自身的Image
        texts = new Text[transform.childCount + 2];//Btn+2UP,DOWN
        for (int i = 0; i < transform.childCount; i++)
        {
            texts[i] = images[i + 1].GetComponentInChildren<Text>();//获取Btn下的Text的Text组件
            ChangeBtnChildText(texts[i], BtnChildTextColor, BtnCildTextFront, 39);//修改
        }
        ChangeBtnUpAndDown();
        for (int i = 1; i < images.Length; i++)
        {
            ChangeIma(images[i], 0);//修改
            images[i].gameObject.AddComponent<BtnEnterEffects>();
        }
    }

    private void ChangeBtnUpAndDown()
    {
        texts[texts.Length - 2] = Up.GetComponentInChildren<Text>();
        texts[texts.Length - 1] = Down.GetComponentInChildren<Text>();
        texts[texts.Length - 2].gameObject.AddComponent<BtnEnterEffects>();
        texts[texts.Length - 1].gameObject.AddComponent<BtnEnterEffects>();
        ChangeBtnChildText(texts[texts.Length - 2], BtnUpDownColor, BtnCildTextFront, 30);//up            
        ChangeBtnChildText(texts[texts.Length - 1], BtnUpDownColor, BtnCildTextFront, 30);//down
    }

    /// <param name="item"btn></param>
    /// <param name="size"text.fontsize></param>
    /// <param name="colr"text.color></param>
    private static void ChangeBtnChildText(Text item, Color color, Font font, int fontsize)
    {
        item.color = color;
        item.fontSize = fontsize;
        item.font = font;
    }

    /// <param name="item"btn></param>
    /// <param name="a"btn.color.a></param>
    private void ChangeIma(Image item, float a)
    {
        BtnImacolor = item.color;
        BtnImacolor.a = a;
        item.color = BtnImacolor;
    }
}
