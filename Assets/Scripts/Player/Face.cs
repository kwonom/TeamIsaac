using UnityEngine;

public class Face : MonoBehaviour
{
    Animator _ani;
    bool isIdle = true;
    bool AttackisIdle = true;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Attack();
    }

    public void Move()
    {
        if (_ani.GetInteger("Attack") != 0)
        {
            _ani.SetLayerWeight(1,1);
        }
        else
        {
            _ani.SetLayerWeight(1,0);
        }

        if (isIdle)
        {
            _ani.SetInteger("Move", 0);
        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            _ani.SetInteger("Move", 1);
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

    void Attack()
    {
        if (AttackisIdle)
        {
            _ani.SetInteger("Attack", 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AttackisIdle = false;
            _ani.SetInteger("Attack", 1);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            AttackisIdle = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AttackisIdle = false;
            _ani.SetInteger("Attack", 2);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            AttackisIdle = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            AttackisIdle = false;
            _ani.SetInteger("Attack", 3);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            AttackisIdle = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _ani.SetInteger("Attack", 4);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            AttackisIdle = true;
        }
    }
}
