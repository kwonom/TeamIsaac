using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{


    [SerializeField] float _speed;
    [SerializeField] ButtonUI _button;
     RectTransform _rectTransform;
   
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float y;// = GetComponent<RectTransform>().anchoredPosition.y;

        if(_rectTransform.anchoredPosition.y==0)  //첫화면일때
        {
            
            if (Input.anyKeyDown)
            {
                y = 1080f;
                StartCoroutine(CoMoveToNext(y));
                //_rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y,0), _speed);
            }
        }
        if (_rectTransform.anchoredPosition.y==1080)
        {
            //_cursor.choice= true;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                y = 0f;
                StartCoroutine(CoMoveToforward(y));
                //_rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0), _speed);
            }
            else if (_button.clickOption == true)
            {
                y = 2160f;
                StartCoroutine(CoMoveToNext(y));
                //_rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0), _speed);
                _button.clickOption = false;
            }

        }
        if(_rectTransform.anchoredPosition.y == 2160)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                y = 1080f;
                StartCoroutine(CoMoveToforward(y));
               // _rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0), _speed);
            }

        }


    }
    IEnumerator CoMoveToNext(float y)//내려갈때
    {
        while(_rectTransform.anchoredPosition.y < y)//  0<1080f || 1080<2160 
        {
            _rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0), 1.5f);
            yield return null;
        }
    }
    IEnumerator CoMoveToforward(float y)//올라갈때
    {
        while (_rectTransform.anchoredPosition.y > y)
        {
            _rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0), 1.5f);
            yield return null;
        }
    }
}
