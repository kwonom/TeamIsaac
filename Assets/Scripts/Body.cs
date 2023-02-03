using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] float _speed;
    bool BodyisIdle = true;
    Animator _ani;
    SpriteRenderer spriterenderer;

    
    
    
<<<<<<< HEAD
    
=======
>>>>>>> parent of cb61fb7 (재커밋)
    //Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        //rigid = gameObject.GetComponent<Rigidbody2D>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        body();
        
    }

    void body()
    {

        if (BodyisIdle)
        {
            _ani.SetInteger("MoveBody", 0);
        }


        if (Input.GetKey(KeyCode.D))
        {
            _ani.SetInteger("MoveBody", 1); //Right
<<<<<<< HEAD

            BodyisIdle = false;
=======
            
            isIdle = false;
>>>>>>> parent of cb61fb7 (재커밋)
            spriterenderer.flipX = false;
           
         }
       
        if (Input.GetKeyUp(KeyCode.D))
        {
            BodyisIdle = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            
            _ani.SetInteger("MoveBody", 1); //Left

            BodyisIdle = false;
            spriterenderer.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            BodyisIdle = true;
        }

        if (Input.GetKey(KeyCode.W))//Up
        {
            _ani.SetInteger("MoveBody", 4);
            BodyisIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.W))//Up
        {
            BodyisIdle = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _ani.SetInteger("MoveBody", 4); //Down
            BodyisIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            BodyisIdle = true;
        }


    }
}
