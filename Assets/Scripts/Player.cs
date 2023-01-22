using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    Animator _ani;
    bool isIdle = true;
    float h;
    float v;
   
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    
    //Vector2 v2 = Vector2.zero;
    // Start is called before the first frame update

    void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        rigid=gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
      

    }

    // Update is called once per frame
    void Update()
    {


        Move();

        Body();

        Attack();

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

    
        



    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * _speed;
        
    }


    void Move()
    {
        if (isIdle)
        {
            _ani.SetInteger("Move", 0);


        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            _ani.SetInteger("Move", 1);
            ;
            //transform.Translate(Vector2.right* Time.deltaTime*_speed);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isIdle = true;
        }

        if (Input.GetKey(KeyCode.A)) //Left
        {
            _ani.SetInteger("Move", 2);

            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.W)) //Up
        {
            _ani.SetInteger("Move", 3);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
            _ani.SetInteger("Move", 4);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isIdle = true;
        }
    }

    void Body()
    {
       
        if (isIdle)
        {
            _ani.SetInteger("MoveBody", 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            _ani.SetInteger("MoveBody", 1); //Right
            
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _ani.SetInteger("MoveBody", 1); //Left
            
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isIdle = true;
        }

        if (Input.GetKey(KeyCode.W))//Up
        {
            _ani.SetInteger("MoveBody", 4);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.W))//Up
        {
            isIdle= true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _ani.SetInteger("MoveBody", 4); //Down
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isIdle = true;
        }


    }


    void Attack()
    {
        
        if (isIdle)
        {
            _ani.SetInteger("Attack", 0);


        }
     
        if(Input.GetKey(KeyCode.RightArrow))
        {
            _ani.SetInteger("Attack", 1);

            isIdle = false;
            
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            isIdle= true;
            
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _ani.SetInteger("Attack", 2);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
           isIdle= true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _ani.SetInteger("Attack", 3);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isIdle = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _ani.SetInteger("Attack",4);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isIdle = true;
        }

    }   

}
