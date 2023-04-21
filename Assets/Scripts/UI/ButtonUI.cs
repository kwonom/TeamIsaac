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
        Debug.Log("새게임");
    }
    public void OnBtnSecondClick()//continue
    {
        Debug.Log("이어하기");
    }
    public void OnBtnThirdClick()//option
    {
        Debug.Log("옵션이동");
        clickOption = true;
    }


    }

