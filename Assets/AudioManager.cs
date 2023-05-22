using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    static AudioSource sfxInstance;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    public bool IsMute { get => bgm.mute; }
    public float BgmVolume { get => bgm.volume; }
    public float SfxVolume { get => sfx.volume; } 

    private void Start() 
    {
        if (bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        }
        else
        {
            bgmInstance = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }

        if (sfxInstance != null)
        {
            Destroy(sfx.gameObject);
            sfx = sfxInstance;
        }
        else
        {
            sfxInstance = sfx;
            sfx.transform.SetParent(null);
            DontDestroyOnLoad(sfx.gameObject);
        }

        LoadAudioSettings();
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if(bgm.isPlaying)
            bgm.Stop();
        
        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
    
    public void SetMute(bool value)
    {
        bgm.mute = value;
        sfx.mute = value;
        SaveAudioSettings();
    }

    public void SetBgmVolume(float value)
    {
        bgm.volume = value;
        SaveAudioSettings();
    }

    public void SetSfxVolume(float value)
    {
        sfx.volume = value;
        SaveAudioSettings();
    }

    public void SaveAudioSettings()
    {
        PlayerPrefs.SetInt("IsMuted", IsMute ? 1 : 0);
        PlayerPrefs.SetFloat("BgmVolume", BgmVolume);
        PlayerPrefs.SetFloat("SfxVolume", SfxVolume);
        PlayerPrefs.Save();
    }

    public void LoadAudioSettings()
    {
        int isMutedValue = PlayerPrefs.GetInt("IsMuted", 0);
        bool isMuted = isMutedValue == 1;
        float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f);

        SetMute(isMuted);
        SetBgmVolume(bgmVolume);
        SetSfxVolume(sfxVolume);
    }

}
