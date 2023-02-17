using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public int maxHeart;
    public int currentHeart;

    public Image[] heart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Sprite fullHeart;



   // Sprite 


    // Start is called before the first frame update
    void Start()
    {
    
        
        
        

    }

    // Update is called once per frame
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
            else // _hp-=10
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
