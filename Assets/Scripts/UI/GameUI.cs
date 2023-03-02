using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public int maxHeart;
    public int currentHeart;

    public Image[] heart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Sprite fullHeart;

  
    public Text[] _text;
    


   
    void Update()
    {
        for(int i=0;i<heart.Length;i++)
        {
            if (i< currentHeart)
            {
                heart[i].sprite = fullHeart;
            }
            //else if (i < currentHeart -5) //_hp-=5
            //{
            //    heart[i].sprite = halfHeart;
            //}
            else
            {
                heart[i].sprite = emptyHeart;
            }

            if (i < maxHeart)
            {
                heart[i].enabled=true;
            }
            else
            {
                heart[i].enabled=false;
            }




        }


    }




}
