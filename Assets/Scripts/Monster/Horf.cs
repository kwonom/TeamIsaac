using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horf : MonoBehaviour
{
    [SerializeField] GameObject _horfBullet;
    [SerializeField] Transform _target;
    [SerializeField] int _attack;
    
    Animator _ani;
    [SerializeField] int _hp = 20;
    bool _isLive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;

    }

    void Awake()
    {
        _horfBullet = Resources.Load("Prefabs/Monsters/HorfBullet") as GameObject;
        _ani = GetComponent<Animator>();
        StartCoroutine(CoHorfFire());
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Horf"), LayerMask.NameToLayer("HorfBullet"));
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CoHorfFire()
    {
        while (true)
        {
            GameObject temp = Instantiate(_horfBullet, transform.position, transform.rotation);
            temp.transform.position = transform.position;
            temp.GetComponent<HorfBullet>().Init(_target);
            yield return new WaitForSeconds(3);
        }
    }

    void Hitted(int hitPower)
    {
        _hp -= hitPower;
        
        if(_hp < 0)
        {
            _isLive = false;
            Destroy(this.gameObject);
        }
    }

    public int getAttack()
    {
        return _attack;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }
}