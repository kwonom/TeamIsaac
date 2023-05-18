using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource _bgmPlayer;

    [SerializeField] AudioSource _sfxPlayer;

    [SerializeField] AudioClip[] _bgms;

    [SerializeField] Slider _fxSlider;
    [SerializeField] Slider _bgmSlider;

    [SerializeField] Toggle _fxMute;
    [SerializeField] Toggle _bgmMute;

    public static SoundController instance;

   
    public void OnBgmVolumeChange()
    {
        _bgmPlayer.volume = _bgmSlider.value;
    }
    public void OnSfxVolumeChange()
    {
        _sfxPlayer.volume = _fxSlider.value;
    }
    public void FxMute()
    {
        _sfxPlayer.mute = !_sfxPlayer.mute;
    }
    public void BgmMute()
    {
        _bgmPlayer.mute = !_bgmPlayer.mute;
    }
    private void Awake()
    {
        _fxSlider.value = 1;
        _bgmSlider.value = 1;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnsceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnsceneLoaded(Scene _scene, LoadSceneMode _scene1)
    {
        for(int i=0;i<_bgms.Length;i++)
        {
            if (_scene.name == _bgms[i].name)
            {
               
                BgSoundPlay(_bgms[i]);
               
            }
        }
    }
    public void SFXPlay(AudioClip _clip)
    {
        _sfxPlayer.clip = _clip;
        _sfxPlayer.spatialBlend = 1f;
        _sfxPlayer.volume = 1f;
        _sfxPlayer.mute = false;
        _sfxPlayer.Play();
    }
    public void BgSoundPlay(AudioClip _clip)
    {
        
        _bgmPlayer.clip= _clip;
        _bgmPlayer.loop = true;
        _bgmPlayer.volume =1f;
        _bgmPlayer.mute = false;
        _bgmPlayer.Play();
    }
}
