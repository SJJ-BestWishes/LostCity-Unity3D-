using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
//播放动画，加载场景，保存不要摧毁数据
public class InsertVideoPanelManger : MonoBehaviour
{
    /*
    //获取视频总时长
    public static int GetVideoTimeCount(this VideoPlayer vp)
    {
        return vp.frameCount / vp.frameRate;等于vp.length
    }
    /// <summary>
    /// 获取视频进度
    /// </summary>
    /// <param name="vsp"></param>
    /// <returns></returns>
    public static float GetVideoProgression(this VideoPlayer vp)
    {
       return vp.time;
    }

    /// <summary>
    /// 设置视频进度
    /// </summary>
    /// <param name="vp"></param>
    /// <param name="progression"></param>
    public static void SetVideoProgression(this VideoPlayer vp, float progression)
    {
        vp.time=progression;
    }
    */
    private VideoPlayer videoPlayer;
    private VideoClip videoClip;
    private RenderTexture renderTexture;
    private RawImage rawImage;
    private DontDestoryInfo dontDestoryInfo;
    private AudioSource backgroundSoundsAudioSource;
    private bool mark = true;
    [HideInInspector]
    public GameObject dontDestory, loadingPanelManger;
    private void OnEnable()//物体被激活时调用
    {
        dontDestoryInfo = dontDestory.GetComponent<DontDestoryInfo>();//找到不需要销毁的物体
        backgroundSoundsAudioSource = GameObject.FindGameObjectWithTag("BackgroundSoundsPlayer").GetComponent<AudioSource>();

        videoPlayer = GetComponent<VideoPlayer>();
        SetVideoClip("黑暗之魂3开场CG");
        SetRenderTexture("黑暗之魂3开场CGRenderTexture");

        rawImage = GetComponent<RawImage>();
        rawImage.texture = renderTexture;
        rawImage.color = new Color(1, 1, 1, 1);
        rawImage.enabled = true;

        videoPlayer.clip = videoClip;
        videoPlayer.playOnAwake = false;
        videoPlayer.waitForFirstFrame = false;//如果为ture要等第一帧所以再判断是否播放时，可能在还没开始播放的时候就是false，导致提前加载场景
        videoPlayer.isLooping = false;
        videoPlayer.skipOnDrop = true;//是否允许VideoPlayer跳过帧以赶上当前时间 即是否可以拉进度条；
        videoPlayer.playbackSpeed = 1.0f;//基本回放速率乘以的因子。(倍速)
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.aspectRatio = VideoAspectRatio.FitHorizontally;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
        
        SetVideoProgression(7f);//设置当前时间
    }

    private void Start()//激活之后调用
    {
        LateUpDateOnce();
    }
    private void Update()
    {
        //加载场景,并且只会执行一次
        if (mark&&(Input.GetKeyDown(KeyCode.Escape)||!videoPlayer.isPlaying))
        {
            mark = !mark;
            loadingPanelManger.GetComponent<LoadingPanelManger>().LoadSceneByName("FloodedGround");
            gameObject.SetActive(false);
        }
    }

    //在物体被激活后才会做这个一次
    private void LateUpDateOnce()
    {
        videoPlayer.SetDirectAudioVolume(0, backgroundSoundsAudioSource.volume);
        videoPlayer.Play();
        dontDestoryInfo.UpdateInfo();
        dontDestoryInfo.DontDestoryOnLoad();
    }

    private void SetVideoClip(string name)
    {
        videoClip = Resources.Load<VideoClip>("Video/"+name);
    }

    private void SetRenderTexture(string name)
    {
        renderTexture = Resources.Load<RenderTexture>("Video/" + name);
    }

    //设置视频进度
    private void SetVideoProgression(float time)
    {
        videoPlayer.time = time;
    }
}
