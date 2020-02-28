using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 实现在鼠标移动到Btns图片上才能用滚轮翻页的效果
public class MainBtnScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Scrollbar scrollText;
    public int Step = 3;
    private float eachStepNumber;
    private bool mark = false;
    private float timeCounter = 0;
    private void Start()
    {
        eachStepNumber = 1.0f/(Step-1.0f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!mark)
        {
            mark = !mark;           
        }
        //当鼠标光标移入该对象时触发

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (mark)
            mark = !mark;
        //当鼠标光标移出该对象时触发
    }
    private void Update()
    {
        MouseWheelCtrl();
        KeyCtrl();
    }

    private void KeyCtrl()
    {
        timeCounter += Time.deltaTime;
        if (Input.GetAxis("Vertical") < 0 && mark && timeCounter > 0.3f)
        {
            scrollText.value -= eachStepNumber;
            timeCounter = 0;
        }
        if (Input.GetAxis("Vertical") > 0 && mark && timeCounter > 0.3f)
        {
            scrollText.value += eachStepNumber;
            timeCounter = 0;
        }
    }

    private void MouseWheelCtrl()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && mark)
        {
            scrollText.value -= eachStepNumber;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && mark)
        {
            scrollText.value += eachStepNumber;
        }
    }

    //给外部提供鼠标滚轮控制
    public void CtrlUp()
    {
        scrollText.value += eachStepNumber;       
    }
    public void CtrlDown()
    {
        scrollText.value -= eachStepNumber;
    }


}
