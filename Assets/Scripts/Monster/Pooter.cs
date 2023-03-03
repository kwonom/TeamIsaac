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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Face")
        {
            collision.gameObject.GetComponent<Player>().Hitted(3);
            Debug.Log("포터 삭제");
        }
    }
    public void Init(PooterController pCon, Transform hero)
    {
        gameObject.SetActive(true);
        _hero= hero;
        _pCon = pCon;
        _speed = 3;
        Vector3 ranpos = _hero.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f)).normalized * 6;
        transform.position = ranpos;
    }

    void move()
    {
        transform.Translate((_hero.position - transform.position).normalized * Time.deltaTime * _speed);
    }
}
