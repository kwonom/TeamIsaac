using UnityEngine;

public class Body : MonoBehaviour
{
    bool BodyisIdle = true;
    Animator _ani;
    SpriteRenderer spriterenderer;

    void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }
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
            BodyisIdle = false;
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
