using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundEffects;

    public AudioSource bgm, levelEndMusic, bossMusic;

    private void Awake()
    {
        instance = this;
    }
    
    public void PlaySoundEffect(int soundToPlay)
    {
        //先停止播放当前进行的该音效
        soundEffects[soundToPlay].Stop();

        //对音效进行调整
        soundEffects[soundToPlay].pitch = Random.Range(.8f, 1.1f);

        //再播放
        soundEffects[soundToPlay].Play();
    }

    public void PlayLevelVictory()
    {
        bgm.Stop();
        levelEndMusic.Play();
    }

    public void PlayBossMusic()
    {
        bgm.Stop();
        bossMusic.Play();
    }

    public void StopBossMusic()
    {
        bossMusic.Stop();
        bgm.Play();
    }
}
