using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource _bgmPlayer;
    [SerializeField] AudioClip[] _bgms;

    [SerializeField] AudioSource[] _sfxPlayer;//동시에 여러가지 효과음이 재생이 되도록 배열로 만들어준다.
    [SerializeField] AudioClip[] _sfxs;
    public enum sfx 
    {
        Attack,
        Hurt,
        GetItem,
        Die,
        horf,
        pooter,
        MonDie,
        Key,
        BoomItem,
        Coin,
        Boom,
        LockBreak,
        BossDoor,
        Whoosh,
        BossMove,
        BossAttack,
        BossJump,
        BossLanding,
        BossHurt
    };
    int sfxIndex;

    Slider _fxSlider;
    Slider _bgmSlider;
    Toggle _fxMute;
    Toggle _bgmMute;

 

    public void setBGMUI(Slider bgmSlider, Toggle bgmToggle)
    {
        _bgmSlider = bgmSlider;
        _bgmMute = bgmToggle;
    }
    public void setSFXUI(Slider sfxSlider, Toggle sfxToggle)
    {
        _fxSlider = sfxSlider;
        _fxMute = sfxToggle;
    }

    public static SoundController instance;
    float _currentTime = 0;
    int _hp = 0;
    int _coin = 0;
    int _bomb = 0;
    int _key = 0;
    bool _shield = false;

    float _fxVolume = 1;
    bool _isFxMute = false;

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

    public void OnBgmVolumeChange(float f)
    {
        _bgmPlayer.volume = _bgmSlider.value;
    }
    public void OnSfxVolumeChange(float f)
    {
//        _sfxPlayer[sfxIndex].volume = _fxSlider.value;
        _fxVolume = _fxSlider.value;
    }
    public void FxMute(bool b)
    {
        _isFxMute = !_isFxMute;
        //_sfxPlayer[sfxIndex].mute = !_sfxPlayer[sfxIndex].mute;
    }
    public void BgmMute(bool b)
    {
        _bgmPlayer.mute = !_bgmPlayer.mute;
    }
    private void Awake()
    {
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
    public void SFXPlay(sfx type)
    {
        switch (type)
        {
            //Player 효과음
            case sfx.Attack://Player 눈물공격
                _sfxPlayer[sfxIndex].clip = _sfxs[0];
                break;
            case sfx.Hurt://Player Hurt
                _sfxPlayer[sfxIndex].clip = _sfxs[1];
                break;
            case sfx.GetItem://Player GetItem
                _sfxPlayer[sfxIndex].clip = _sfxs[2];
                break;
            case sfx.Die://Player Die
                _sfxPlayer[sfxIndex].clip = _sfxs[3];
                break;
            //Monster 효과음
            case sfx.horf:
                _sfxPlayer[sfxIndex].clip = _sfxs[4];
                break;
            case sfx.pooter:
                _sfxPlayer[sfxIndex].clip = _sfxs[Random.Range(5,6)];
                break;
            case sfx.MonDie:
                _sfxPlayer[sfxIndex].clip = _sfxs[7];
                break;
            case sfx.Key:
                _sfxPlayer[sfxIndex].clip = _sfxs[8];
                break;
            case sfx.BoomItem:
                _sfxPlayer[sfxIndex].clip = _sfxs[9];
                break;
            case sfx.Coin:
                _sfxPlayer[sfxIndex].clip = _sfxs[10];
                break;
            case sfx.Boom:
                _sfxPlayer[sfxIndex].clip = _sfxs[11];
                break;
            case sfx.LockBreak:
                _sfxPlayer[sfxIndex].clip = _sfxs[12];
                break;
            case sfx.BossDoor:
                _sfxPlayer[sfxIndex].clip = _sfxs[13];
                break;
            case sfx.Whoosh:
                _sfxPlayer[sfxIndex].clip = _sfxs[14];
                break;
            case sfx.BossMove:
                _sfxPlayer[sfxIndex].clip = _sfxs[15];
                break;
            case sfx.BossAttack:
                _sfxPlayer[sfxIndex].clip = _sfxs[16];
                break;
            case sfx.BossJump:
                _sfxPlayer[sfxIndex].clip = _sfxs[17];
                break;
            case sfx.BossLanding:
                _sfxPlayer[sfxIndex].clip = _sfxs[18];
                break;
            case sfx.BossHurt:
                _sfxPlayer[sfxIndex].clip = _sfxs[19];
                break;

        }
        //Debug.Log("index : "+sfxIndex+", "+_fxVolume+", mute : "+ _isFxMute);
        _sfxPlayer[sfxIndex].volume = _fxVolume;
        _sfxPlayer[sfxIndex].mute = _isFxMute;
        _sfxPlayer[sfxIndex].Play();
        sfxIndex =(sfxIndex + 1)%_sfxPlayer.Length;//나머지 0으로 다시 초기화된다.
    }
   
    public void BgSoundPlay(AudioClip _clip)
    {
        _bgmPlayer.clip= _clip;
        _bgmPlayer.loop = true;
        _bgmPlayer.playOnAwake = false;
        _bgmPlayer.volume =1f;
        _bgmPlayer.mute = false;
        _bgmPlayer.Play();
    }
}
