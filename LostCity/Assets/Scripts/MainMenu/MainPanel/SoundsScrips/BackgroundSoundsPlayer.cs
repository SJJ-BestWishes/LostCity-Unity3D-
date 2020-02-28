using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
/// 播放背景音乐
public class BackgroundSoundsPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip backgroundSound;
    private float volume=0.5f;
    void Start()
    {
        audioSource=gameObject.AddComponent<AudioSource>();
        PlayAudioImmediatelyByName("黑魂3界面背景音乐");
        audioSource.loop = true;
        audioSource.volume = volume;
    }
    public void PlayAudioImmediatelyByName(string name)
    {
        //这里目标文件处在 Resources/Sounds/MainUISounds/目标文件name
        AudioClip clip = Resources.Load<AudioClip>("Sounds/MainUISounds/" + name);
        audioSource.clip = clip;
        audioSource.Play();
        //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);//在哪里放
    }
}
