using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class EnemyUI : MonoBehaviour
{
    [Header("设置血条缩放比例")]
    public float scale = 1;
    //真实设置缩放比例(按照2:1)再乘以系数
    private Vector2 realScale = new Vector2(2, 1);
    //摄像机
    private Camera camera;
    //NPC模型高度
    private float npcHeight;
    //红色血条贴图
    public Texture2D blood_red;
    //黑色血条贴图
    public Texture2D blood_black;
    private EnemyInfo enemyInfo;

    void Start()
    {
        realScale *= scale;
        enemyInfo = GetComponent<EnemyInfo>();
        //得到摄像机对象
        camera = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
        
        //注解1
        //得到模型原始高度
        float size_y = GetComponent<Collider>().bounds.size.y;
        //得到模型缩放比例
        float scal_y = transform.localScale.y;
        //它们的乘积就是高度
        npcHeight = size_y * scal_y;
    }

    void OnGUI()
    {
        //在特定距离和角度看的到血条
        if (Vector3.Distance(enemyInfo.player.position, transform.position) <= enemyInfo.drawBloodCriticalDistance)
        {
            //得到NPC头顶在3D世界中的坐标
            //默认NPC坐标点在脚底下，所以这里加上npcHeight它模型的高度即可
            Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + npcHeight, transform.position.z);
            //根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标
            Vector2 position = camera.WorldToScreenPoint(worldPosition);
            //得到真实NPC头顶的2D坐标
            position = new Vector2(position.x, Screen.height - position.y);

            //注解2
            //计算出血条的宽高

            //黑色血条的宽
            Vector2 bloodSize = GUI.skin.label.CalcSize(new GUIContent(blood_red)) * realScale;
            //通过血值计算红色血条显示区域
            float blood_width = (blood_red.width * enemyInfo.HP / enemyInfo.maxHp) * realScale.x;

            //先绘制黑色血条
            GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y, bloodSize.x, bloodSize.y), blood_black);
            //在绘制红色血条
            GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y, blood_width, bloodSize.y), blood_red);
        }
    }
}
