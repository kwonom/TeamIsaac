using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    public float minHp;
    [SerializeField] GameObject ShildItem;
    [SerializeField] PooterController _pooterCon;

    Animator _ani;
    //bool MoveisIdle = true;
    bool isIdle = true;
    bool AttackisIdle = true;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    public GameObject tear;
    public float maxShotDelay;
    public float curShotDelay;
    GameObject Shild;
    GameUI _uiPanel;
    public GameObject Body;
    



    
    void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Wall"), LayerMask.NameToLayer("Shield"));
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();



    }

    // Update is called once per frame
    void Update()
    {
        curShotDelay += Time.deltaTime;

        

        Move();
        Attack();
       
    }

  

    public void Hitted(int dmg)
    {
        
            _hp -= dmg;
        _ani.SetTrigger("Hitted");
        Body.SetActive(false);
        if (_hp <minHp)
        {
            _ani.SetTrigger("Dead");
            Body.SetActive(false);

                       // SceneManager.LoadScene("Main");
        }
    }
    void bodyControl()
    {
        Body.SetActive(true);
        //Hitted Dead EatItem 애니메이션 실행할때 false
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
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
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



    public void Attack()
    {


        if (AttackisIdle)
        {
            _ani.SetInteger("Attack", 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            AttackisIdle = false;
            if (curShotDelay > maxShotDelay)
            {
                _ani.SetInteger("Attack", 1);

                GameObject Bullet = Instantiate(tear, transform.position + Vector3.right , transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.right);
                //Rigidbody2D _rigid = Bullet.GetComponent<Rigidbody2D>();
                //_rigid.AddForce(Vector2.right * _speed, ForceMode2D.Impulse);  //AddForce(Vec): Vec의 방향과 크기로 힘을 줌
                
                curShotDelay = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            AttackisIdle = true;

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AttackisIdle = false;
            if (curShotDelay > maxShotDelay)
            {
                _ani.SetInteger("Attack", 2);

                GameObject Bullet = Instantiate(tear,transform.position + Vector3.left,transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.left);               
                //Rigidbody2D _rigid = Bullet.GetComponent<Rigidbody2D>();
                //_rigid.AddForce(Vector2.left*_speed, ForceMode2D.Impulse);

                curShotDelay = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            AttackisIdle = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            AttackisIdle = false;
            if(curShotDelay> maxShotDelay)
            {
            _ani.SetInteger("Attack", 3);
            

                GameObject Bullet = Instantiate(tear, transform.position + Vector3.up*3.0f, transform.rotation);
                Bullet.GetComponent <PlayerBullet>().Init(Vector2.up);
                //Rigidbody2D _rigid = Bullet.GetComponent<Rigidbody2D>();
                //_rigid.AddForce(Vector2.up*_speed, ForceMode2D.Impulse);
                

                curShotDelay = 0;
            }

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            AttackisIdle = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            AttackisIdle = false;
            if(curShotDelay> maxShotDelay)
            {
            _ani.SetInteger("Attack", 4);

            GameObject Bullet = Instantiate(tear,transform.position+ Vector3.down, transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.down);

                //Rigidbody2D _rigid = Bullet.GetComponent<Rigidbody2D>();
                //_rigid.AddForce(Vector2.down * _speed, ForceMode2D.Impulse);

                curShotDelay = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            AttackisIdle = true;
        }

    }

    //internal void Move(object isidle)
    //{
    //    throw new NotImplementedException();
    //}

  
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ShildItem")
        {
            Debug.Log("아이템 획득");
            GameObject Temp= Instantiate(ShildItem,transform);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Item")
        {
            Item item=collision.gameObject.GetComponent<Item>();
            switch(item.type)
            {
                case "Coin":
                    
                    break;
                case "Bomb":
                    break;
                case "Key":
                    break;
            }
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Damage")
        {
            Hitted(5);

        }
    }
}
