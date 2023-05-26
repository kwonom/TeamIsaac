using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject[] heart;
    [SerializeField] Text[] _text;
    [SerializeField] Text _TimerText;
    [SerializeField] GameObject _GameOver;
    [SerializeField] GameObject _OpenOption;
    [SerializeField] Player _player;


     int _coin;
     public int _key;
     int _boom;
    float _currentTime;
    private void Start()
    {
        _boom += 3;
        _text[1].text = _boom.ToString("d2");//두자리 정수 표시
        _currentTime= 0;
        
    }
    private void Update()
    {
        _currentTime =_currentTime+ Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds( _currentTime );
        _TimerText.text = time.ToString(@"hh\:mm\:ss");

        OnTimer();
        GameOver();
    }

    public void HeartIcon(int life)
    {
        switch (life)
        {
            case 75:
                heart[0].SetActive(false);
                break;
            case 60:
                heart[1].SetActive(false);
                break;
            case 45:
                heart[2].SetActive(false);
                break;
            case 30:
                heart[3].SetActive(false);
                break;
            case 15:
                heart[4].SetActive(false);
                break;
            case 0:
                heart[5].SetActive(false);
                break;
        }
    }

   
    public void addCoin()
    {
        _coin++;
        _text[0].text = _coin.ToString("d2");
    }
    public void addBoom()
    {
        _boom++;
        _text[1].text = _boom.ToString("d2");
    }
    public void addKey()
    {
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
        if(_player.IsDead == true)
        {
            Invoke("Option", 3.5f);
        }
    }

    void Option()
    {
        _GameOver.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnBtnEXIT()
    {
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1;
    }
    public void OnBtnRESTART()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }

    void OpenOption()
    {
        _OpenOption.SetActive(true);
    }
}
