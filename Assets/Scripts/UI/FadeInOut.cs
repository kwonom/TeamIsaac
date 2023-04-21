using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeInOut : MonoBehaviour
{
    public Image _black;
    float time = 0f;//0~1까지 deltatime을 더하여 지속시간
    float FadeTime = 0.5f;//몇초간 지속될건지
  public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        _black.gameObject.SetActive(true);
        time = 0f;
        Color alpha = _black.color;//초기화
        while (alpha.a < 1f)
        {
            //deltatime을 FadeTime으로 나눈 값을 time에 더함
            time += Time.deltaTime / FadeTime;
            //lerp를 사용하여 0부터 1가지 부드럽게 변하게 만듦
            alpha.a = Mathf.Lerp(0, 1, time);
            //alpha값을 매 프레임 이미지의 컬러 값에 대입
            _black.color = alpha;
            yield return null;
        }
        SceneManager.LoadScene("Loading");//fadeout >>loadingScence 이동
        Debug.Log("새게임");

        yield return null;
    }
}
