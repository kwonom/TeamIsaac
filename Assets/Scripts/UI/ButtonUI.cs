using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    protected bool clickOption = false;
    public bool ClickOption { get { return clickOption; }set { clickOption = value; } }

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

