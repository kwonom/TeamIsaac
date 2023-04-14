using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{

    

     RectTransform _rectTransform;
   
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float y = GetComponent<RectTransform>().anchoredPosition.y;

        if(_rectTransform.anchoredPosition.y==0)  //첫화면일때
        {
           
            if (Input.anyKeyDown)
            {
                y+= 1080f;
                _rectTransform.anchoredPosition = Vector3.Lerp(_rectTransform.anchoredPosition, new Vector3(0,y), 1f);
            }
        }


    }
}
