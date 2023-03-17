using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooter : MonoBehaviour
{
    PooterController _pCon;
    Transform _hero;
    Animator _ani;

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

    public void Init(PooterController pCon, Transform hero)
    {
        gameObject.SetActive(true);
        _hero = hero;
        _pCon = pCon;
        _speed = 5;
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            transform.position = new Vector3(-27, 16);
        }
        else if (random == 2)
        {
            transform.position = new Vector3(27, 16);
        }
        else if (random == 3)
        {
            transform.position = new Vector3(-27, -16);
        }
        else if(random == 4) 
        {
            transform.position = new Vector3(27, -16);
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
        Debug.Log("몬스터 삭제");
        collision.gameObject.GetComponent<Player>();
    }
}
