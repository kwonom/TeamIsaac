using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    protected bool clickOption = false;
    public bool ClickOption { get { return clickOption; }set { clickOption = value; } }

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

