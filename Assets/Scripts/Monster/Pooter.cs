using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Pooter : MonoBehaviour
{
    PooterController _pCon;
    Transform _hero;
    Animator _ani;

    float _speed;
    int _hp;
    
    bool _isLive = false;
    

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
        _hp = 10;
        int random = Random.Range(1, 4);
        //if (random == 1)
        //{
        //    transform.position = new Vector3(-27, 16);
        //}
        //else if (random == 2)
        //{
        //    transform.position = new Vector3(27, 16);
        //}
        //else if (random == 3)
        //{
        //    transform.position = new Vector3(-27, -16);
        //}
        //else if(random == 4) 
        //{
        //    transform.position = new Vector3(27, -16);
        //}

        switch (random)
        {
            case 1:
                transform.position = new Vector3(-27, 16);
                break;
                case 2:
                transform.position = new Vector3(27, 16);
                break;
                case 3:
                transform.position = new Vector3(-27, -16);
                break;
                case 4:
                transform.position = new Vector3(27, -16);
                break;
        }

        //Vector3 ranpos = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        //transform.position = ranpos;
    }

    
    void move()
    {
        transform.Translate((_hero.position - transform.position).normalized * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "PlayerBullet")
        {
            OnHitted(5);
        }
    }

    void OnHitted(int hitPower)
    {
        _hp -= hitPower;

        if(_hp < 0)
        {
            Destroy(gameObject);
            _isLive = false;
        }
    }
}
