using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    //public int maxHeart;
    //public int currentHeart;

    public GameObject[] heart;
    public Text[] _text;

    public int life;

     int _coin;
     int _key;
     int _boom;
    private void Start()
    {
        _boom += 3;
        _text[1].text = _boom.ToString("d2");
    }
    public void HeartIcon()
    {
        Player player = GetComponent<Player>();
        player._hp = life;
        for(int index = 0; index < life; index++)
        {

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
        _text[2].text = _key.ToString("d2");//d2 �Ҽ��� ����  / f2 �Ҽ��� �Ʒ��� 
    }



    void Update()
    {
     


    }
}
