using System.Collections;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    [SerializeField] GameObject _bossBullet;
    [SerializeField] Transform _target;
    [SerializeField] float _speed;
    [SerializeField] int _count;
    [SerializeField] float _gap;
    [SerializeField] float _deg;

    Animator _ani;

    void Start()
    {
        _bossBullet = Resources.Load("Prefabs/Monsters/HorfBullet") as GameObject;
        _ani = GetComponent<Animator>();
        StartCoroutine(CoBossAttack());

    }

    void Update()
    {
        BossMove();
    }

    public void BossMove()
    {
        transform.Translate((_target.position - transform.position).normalized * _speed * Time.deltaTime);
    }

    IEnumerator CoBossAttack()
    {
        while(true)
        {
            Vector3 v3temp = _target.position - transform.position;
            float degtemp = Mathf.Atan2(v3temp.y, v3temp.x);
            float raddeg = degtemp * Mathf.Rad2Deg;
            for(int i = 0; i < _count; i++)
            {
                GameObject temp = Instantiate(_bossBullet);
                temp.transform.position = transform.position;
                float deg = i * (_deg / (_count - 1))+ raddeg - _deg / 2f;
                Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf .Deg2Rad), 0);
                temp.GetComponent<HorfBullet>().Init(dir);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
