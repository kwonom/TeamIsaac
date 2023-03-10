using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooter : MonoBehaviour
{
    float _speed;
    PooterController _pCon;
    Transform _hero;
    Animator _ani;



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

    public void Init(PooterController pCon, Transform hero)
    {
        gameObject.SetActive(true);
        _hero = hero;
        _pCon = pCon;
        _speed = 5;
        Vector3 ranpos = _hero.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f)).normalized * 6;
        transform.position = ranpos;
    }

    void move()
    {
        transform.Translate((_hero.position - transform.position).normalized * Time.deltaTime * _speed);
    }
}
