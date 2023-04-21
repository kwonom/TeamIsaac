using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{


    [SerializeField] float _speed = 10f;
    [SerializeField] CursorMove _cursor;
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
                y= 1080f;
                _rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y,0), _speed);
            }
        }
        if (_rectTransform.anchoredPosition.y==1080)
        {
            //_cursor.choice= true;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                y = 0f;
                _rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0),_speed);
            }
        
        }
        if(_rectTransform.anchoredPosition.y == 2160)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                y = 1080f;
                _rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0), _speed);
            }

        }


    }
}
