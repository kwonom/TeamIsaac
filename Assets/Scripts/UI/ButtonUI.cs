using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonUI : MonoBehaviour
{
    public bool clickOption = false;

    public void OnBtnFirstClick()//newrun
    {
        Debug.Log("������");
    }
    public void OnBtnSecondClick()//continue
    {
        Debug.Log("�̾��ϱ�");
    }
    public void OnBtnThirdClick()//option
    {
        Debug.Log("�ɼ��̵�");
        clickOption = true;
    }


    }

