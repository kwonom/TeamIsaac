using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator _ani;
    bool isIdle = true;
    // Start is called before the first frame update
    void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        if (isIdle)
        {
            _ani.SetInteger("Attack", 0);


        }
        if (Input.GetKey("d"))
        {
           
        }



    }

    void move()
    {
       
    }

    void Attack()
    {
        
        if (isIdle)
        {
            _ani.SetInteger("Attack", 0);


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _ani.SetInteger("Attack", 1);
            isIdle = false;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _ani.SetInteger("Attack", 1);

            isIdle = false;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            isIdle= true;
        }


    }   

}
