using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    float _currentTime = 0;
    int _hp = 0;
    int _coin = 0;
    int _bomb = 0;
    int _key = 0;
    bool _shield = false;

    public void setBossSceneData(int hp, int coin, int bomb, int key, bool shield,float currentTime)
    {
        _hp = hp;
        _coin = coin;
        _bomb = bomb;
        _key = key;
        _shield = shield;
        _currentTime = currentTime;
    }

    public void getBossSceneData(ref int hp, ref int coin, ref int bomb, ref int key, ref bool shield,ref float currentTime)
    {
        hp = _hp;
        coin = _coin;
        bomb = _bomb;
        key = _key;
        shield = _shield;
        currentTime = _currentTime;
    }

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
    private void Update()
    {

        if (_bgms[3] == true)
        {
            _bgmPlayer.loop = false;
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
        //_sfxPlayer.spatialBlend = 1f;
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
