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
    
    public void HeartIcon()
    {
         Player player=GetComponent<Player>();
        switch (player._hp)
        {
            case 25 :
                heart[0].SetActive(false);
                heart[1].SetActive(true);
                break;
            case 20 :
                heart[1].SetActive(false);
                heart[2].SetActive(true);
                break;
            case 15:
                heart[2].SetActive(false);
                heart[3].SetActive(true);
                break;
            case 10:
                heart[3].SetActive(false);
                heart[4].SetActive(true);
                break;
            case 5:
                heart[4].SetActive(false);
                heart[5].SetActive(true);
                break;

    
        }

       

    }

    public void scoreText()
    {
        for(int index=0;index<_text.Length;index++)
        {
            
        }
    }




    void Update()
    {
      //  HeartIcon();


    }
}
