using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 播放特效声音
public class EffectsSoundsPlayer : MonoBehaviour
{
    private AudioSource audiosource;
    private float volume = 0.5f;
    void Start()
    {
        audiosource = gameObject.AddComponent<AudioSource>();
        audiosource.playOnAwake = false;  //playOnAwake设为false时，通过调用play()方法启用
        audiosource.volume = volume;
    }

    //在指定位置播放音频 PlayClipAtPoint()
    public void PlayAudioImmediatelyByName(string name)
    {
        //这里目标文件处在 Resources/Sounds/MainUISounds/目标文件name
        AudioClip clip = Resources.Load<AudioClip>("Sounds/MainUISounds/" + name);
        audiosource.clip = clip;
        audiosource.Play();
        //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);//在哪里放
    }
    public void PlayAudioImmediatelyByName(string name,float volume)//test用
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/MainUISounds/" + name);
        audiosource.clip = clip;
        audiosource.Play();
    }

    //如果当前有其他音频正在播放，停止当前音频，播放下一个
    public void PlayMusicPauseByName(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/MainUISounds/" + name);
        if (audiosource.isPlaying)
        {
            audiosource.Stop();
        }
        audiosource.clip = clip;
        audiosource.Play();
    }
}
