using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeInOut : MonoBehaviour
{
    public Image _black;
    float time = 0f;//0~1���� deltatime�� ���Ͽ� ���ӽð�
    float FadeTime = 0.5f;//���ʰ� ���ӵɰ���
  public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        _black.gameObject.SetActive(true);
        time = 0f;
        Color alpha = _black.color;//�ʱ�ȭ
        while (alpha.a < 1f)
        {
            //deltatime�� FadeTime���� ���� ���� time�� ����
            time += Time.deltaTime / FadeTime;
            //lerp�� ����Ͽ� 0���� 1���� �ε巴�� ���ϰ� ����
            alpha.a = Mathf.Lerp(0, 1, time);
            //alpha���� �� ������ �̹����� �÷� ���� ����
            _black.color = alpha;
            yield return null;
        }
        SceneManager.LoadScene("Loading");//fadeout >>loadingScence �̵�
        Debug.Log("������");

        yield return null;
    }
}
