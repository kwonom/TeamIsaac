using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Animator _ani;
    MonsterController _mc;
    Transform _hero;

    float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void init(MonsterController mc, Transform hero)
    {
        gameObject.SetActive(true);
        _hero = hero;
        _mc = mc;
        _speed = 2;
        Vector3 ranPos = _hero.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 6;
        transform.position = ranPos;
    }

    void move()
    {
        transform.Translate((_hero.position - transform.position).normalized * Time.deltaTime * _speed);
    }
}
