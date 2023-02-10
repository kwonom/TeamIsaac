using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    Animator _moveAni;
    Animator _attackAni;
    //bool MoveisIdle = true;
    bool isIdle = true;
    bool AttackisIdle = true;
   
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    
    //Vector2 v2 = Vector2.zero;
    // Start is called before the first frame update

    void Start()
    {
        _moveAni = gameObject.GetComponent<Animator>();
        _attackAni = gameObject.GetComponent<Animator>();
        rigid =gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {


        Move();
        Attack();

    
        



    }


    public void Move()
    {
        //bool isIdle = true;
        if (isIdle)
        {
            _moveAni.SetInteger("Move", 0);


        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            _moveAni.SetInteger("Move", 1);
           transform.Translate(Vector2.right* Time.deltaTime*_speed);
            isIdle = false;
           
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isIdle = true;
        }

        if (Input.GetKey(KeyCode.A)) //Left
        {
            _moveAni.SetInteger("Move", 2);
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            isIdle = false;
            
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.W)) //Up
        {
            _moveAni.SetInteger("Move", 3);
            transform.Translate(Vector2.up * Time.deltaTime * _speed);

            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
            _moveAni.SetInteger("Move", 4);
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
            _attackAni.SetInteger("Attack", 0);


        }
     
        if(Input.GetKey(KeyCode.RightArrow))
        {
            _attackAni.SetInteger("Attack", 1);

            AttackisIdle = false;
            
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            AttackisIdle = true;
            
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _attackAni.SetInteger("Attack", 2);
            AttackisIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            AttackisIdle = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _attackAni.SetInteger("Attack", 3);
            AttackisIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            AttackisIdle = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _attackAni.SetInteger("Attack",4);
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
