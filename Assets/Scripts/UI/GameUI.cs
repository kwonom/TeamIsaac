using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject[] heart;
    [SerializeField] Text[] _text;
    [SerializeField] Text _TimerText;

    Animator _ani;

     int _coin;
     int _key;
     int _boom;
    float _currentTime;
    private void Start()
    {
        _boom += 3;
        _text[1].text = _boom.ToString("d2");
        _currentTime= 0;
        
    }
    private void Update()
    {
        _currentTime =_currentTime+ Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds( _currentTime );
        _TimerText.text = time.ToString(@"hh\:mm\:ss");

        OnTimer();
    }

    public void HeartIcon(int life)
    {
        switch (life)
        {
            case 25:
                heart[0].SetActive(false);
                break;
            case 20:
                heart[1].SetActive(false);
                break;
            case 15:
                heart[2].SetActive(false);
                break;
            case 10:
                heart[3].SetActive(false);
                break;
            case 5:
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

}
