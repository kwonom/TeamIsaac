using System.Collections;
using UnityEngine;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    [SerializeField] ButtonUI _button;
     RectTransform _rectTransform;
   
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        float y;
        if(_rectTransform.anchoredPosition.y==0)  //첫화면일때
        {
            if (Input.anyKeyDown)
            {
                SoundController.instance.SFXPlay(SoundController.sfx.Whoosh);
                y = 1080f;
                StartCoroutine(CoMoveToNext(y));
            }
        }
        if (_rectTransform.anchoredPosition.y==1080)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SoundController.instance.SFXPlay(SoundController.sfx.Whoosh);
                y = 0f;
                StartCoroutine(CoMoveToforward(y));

            }
            else if (_button.ClickOption == true)
            {
                SoundController.instance.SFXPlay(SoundController.sfx.Whoosh);
                y = 2160f;
                StartCoroutine(CoMoveToNext(y));
                _button.ClickOption = false;

            }
        }
        if(_rectTransform.anchoredPosition.y == 2160)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SoundController.instance.SFXPlay(SoundController.sfx.Whoosh);
                y = 1080f;
                StartCoroutine(CoMoveToforward(y));
            }
        }
    }

    IEnumerator CoMoveToNext(float y)//내려갈때
    {
        while(_rectTransform.anchoredPosition.y < y)//  0<1080f || 1080<2160 
        {
            _rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0), 1.8f);
            yield return null;
        }
    }

    IEnumerator CoMoveToforward(float y)//올라갈때
    {
        while (_rectTransform.anchoredPosition.y > y)
        {
            _rectTransform.anchoredPosition = Vector3.MoveTowards(_rectTransform.anchoredPosition, new Vector3(0, y, 0), 1.8f);
            yield return null;
        }
    }
}
