using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject[] heart;
    [SerializeField] Text[] _text;
    [SerializeField] Text _TimerText;
    [SerializeField] GameObject _GameOver;
    [SerializeField] GameObject _OpenOption;
    Player player;
    public Player _player { set { player = value; } }
    public int _key;
    int _coin;
    int _boom;
    float _currentTime = 0;
    public static GameUI instance;
    bool _isGameOverPanelOn  = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetInit(int key, int coin, int boom)
    {
        _isGameOverPanelOn = false;
        _boom = boom;
        _key = key;
        _coin = coin;
        _text[1].text = _boom.ToString("d2");//두자리 정수 표시
        _text[0].text = _coin.ToString("d2");
        _text[2].text = _key.ToString("d2");
        HeartIcon(player._hp);

    }
    private void Start()
    {
       

    }

    private void Update()
    {
        _currentTime = _currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _TimerText.text = time.ToString(@"hh\:mm\:ss");
        OpenOption();
        OnTimer();
        GameOver();
    }
    public void BossRoomInit()
    {
       
        int hp = player._hp;
        int coin2 = 0;
        int boom2 = 0;
        int key2 = 0;
        bool shieldBool = false;
        float currentTime2 = 0;
        SoundController.instance.getBossSceneData(ref hp, ref coin2, ref boom2, ref key2, ref shieldBool,ref currentTime2);
        Debug.Log(hp + ", " + key2 + ", " + coin2 + ", " + boom2 + ", " + shieldBool+", "+currentTime2);
        _coin = coin2;
        _boom= boom2;
        _key = key2;
        _currentTime= currentTime2;
        _text[0].text = coin2.ToString("d2");
        _text[1].text = boom2.ToString("d2");
        _text[2].text = key2.ToString("d2");
        _TimerText.text = currentTime2.ToString(@"Time: hh\:mm\:ss");
    }

    public void HeartIcon(int life)
    {
        switch (life)
        {
            case >= 90:
                {
                    for(int i = 0; i < heart.Length; i++)
                    {
                        heart[i].SetActive(true);
                    }
                }
                break;
            case <= 0:
                heart[5].SetActive(false);
                heart[4].SetActive(false);
                heart[3].SetActive(false);
                heart[2].SetActive(false);
                heart[1].SetActive(false);
                heart[0].SetActive(false);
                break;
            case <= 15:
                heart[4].SetActive(false);
                heart[3].SetActive(false);
                heart[2].SetActive(false);
                heart[1].SetActive(false);
                heart[0].SetActive(false);
                break;
            case <= 30:
                heart[3].SetActive(false);
                heart[2].SetActive(false);
                heart[1].SetActive(false);
                heart[0].SetActive(false);
                break;
            case <= 45:
                heart[2].SetActive(false);
                heart[1].SetActive(false);
                heart[0].SetActive(false);
                break;
            case <= 60:
                heart[1].SetActive(false);
                heart[0].SetActive(false);
                break;
            case <= 75:
                heart[0].SetActive(false);
                break;
        }

    }

    public int getCoin()
    {
        return _coin;
    }

    public int getKey()
    {
        return _key;
    }
    public float getTime()
    {
        return _currentTime;
    }
  

    public void addCoin()
    {
        SoundController.instance.SFXPlay(SoundController.sfx.Coin);
        _coin++;
        _text[0].text = _coin.ToString("d2");
    }
    public void addBoom()
    {
        SoundController.instance.SFXPlay(SoundController.sfx.BoomItem);
        _boom++;
        _text[1].text = _boom.ToString("d2");
    }
    public void addKey()
    {
        SoundController.instance.SFXPlay(SoundController.sfx.Key);
        _key++;
        _text[2].text = _key.ToString("d2");//d2 소수점 위로  / f2 소수점 아래로
                                            
    }

    public void minusBoom()
    {
        _boom--;
        _text[1].text = _boom.ToString("d2");
    }
    public void OnTimer()
    {
        Animator _ani =_TimerText.GetComponent<Animator>();
       

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _ani.SetBool("OnTimer",true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            _ani.SetBool("OnTimer", false);
        }

    }

    void GameOver()
    {
        if(player.IsDead == true&& _isGameOverPanelOn == false)
        {
            _isGameOverPanelOn = true;
            Invoke("Option", 3.5f);
        }
    }

    public void Option()
    {
        _GameOver.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnBtnEXIT()
    {
        Time.timeScale = 1f;
        _GameOver.SetActive(false);
        SceneManager.LoadScene("Lobby");
    }
    public void OnBtnRESTART()
    {
        Time.timeScale = 1f;
        _GameOver.SetActive(false);
        SceneManager.LoadScene("Main");
    }


    public void OpenOption()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _OpenOption.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnBtnCloseOption()
    {
        _OpenOption.SetActive(false);
        Time.timeScale = 1;
    }
}
