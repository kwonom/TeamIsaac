using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] float _speed;
    bool isIdle = true;
    Animator _ani;
    SpriteRenderer spriterenderer;
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

        if (isIdle)
        {
            _ani.SetInteger("MoveBody", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _ani.SetInteger("MoveBody", 1); //Right

            isIdle = false;
            spriterenderer.flipX = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            
            _ani.SetInteger("MoveBody", 1); //Left

            isIdle = false;
            spriterenderer.flipX = true;
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
            isIdle = true;
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
}
