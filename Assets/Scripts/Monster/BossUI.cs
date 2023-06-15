using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] Slider _BossHp;
    [SerializeField] GameObject _icon;

    float _iconMax = 960;
    float _iconMin = -70;

    void Start()
    {
        _BossHp.value = 1;
        //Vector2 pos = _icon.transform.position;
        //pos.x = _iconMax;
        //_icon.transform.position = pos;
    }

    public void BossHpChange(float value)
    {
        _BossHp.value = value;
        //Vector2 pos = _icon.transform.position;
        //pos.x = Mathf.Lerp(_iconMin,_iconMax,value);
        //_icon.transform.position = pos;
    }
}
