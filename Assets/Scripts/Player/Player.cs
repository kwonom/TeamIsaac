using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] Life _life;

    Animator _ani;
    //bool MoveisIdle = true;
    bool isIdle = true;
    bool AttackisIdle = true;
   
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    public GameObject tear;
    public float maxShotDelay;
    public float curShotDelay;

        PlayerBullet pb = new PlayerBullet();



    //Vector2 v2 = Vector2.zero;
    // Start is called before the first frame update

    void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        rigid =gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        curShotDelay += Time.deltaTime;


        Move();
        Attack();
    }

    


    public void Move()
    {
        //bool isIdle = true;
        if (isIdle)
        {
            _ani.SetInteger("Move", 0);


        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            _ani.SetInteger("Move", 1);
           transform.Translate(Vector2.right* Time.deltaTime*_speed);
            isIdle = false;
           
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isIdle = true;
        }

        if (Input.GetKey(KeyCode.A)) //Left
        {
            _ani.SetInteger("Move", 2);
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            isIdle = false;
            
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.W)) //Up
        {
            _ani.SetInteger("Move", 3);
            transform.Translate(Vector2.up * Time.deltaTime * _speed);

            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
            _ani.SetInteger("Move", 4);
            transform.Translate(Vector2.down * Time.deltaTime * _speed);

            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isIdle = true;
        }
    }

   

    void Attack()
    {

        
        if (AttackisIdle)
        {
            _ani.SetInteger("Attack", 0);
           


        }
     
        if(Input.GetKey(KeyCode.RightArrow))
        {
            AttackisIdle = false;
            if (curShotDelay > maxShotDelay)
            {
            _ani.SetInteger("Attack", 1);

                GameObject Bullet = Instantiate(tear, transform.position + Vector3.right*0.4f, transform.rotation);
                Rigidbody2D rigid = Bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.right * _speed, ForceMode2D.Impulse);  //AddForce(Vec): Vec¿« πÊ«‚∞˙ ≈©±‚∑Œ »˚¿ª ¡‹

                curShotDelay = 0;
            }
            
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            AttackisIdle = true;
            
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _ani.SetInteger("Attack", 2);
            AttackisIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            AttackisIdle = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _ani.SetInteger("Attack", 3);
            AttackisIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            AttackisIdle = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _ani.SetInteger("Attack",4);
            AttackisIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            AttackisIdle = true;
        }

    }

    internal void Move(object isidle)
    {
        throw new NotImplementedException();
    }
}
