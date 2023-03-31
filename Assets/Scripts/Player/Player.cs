using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TextCore;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    public int _hp;
    public float minHp;
    [SerializeField] Animator _faceAni;
    [SerializeField] Animator _bodyAni;
    [SerializeField] Animator _FullAni;
    [SerializeField] GameObject ShildItem;

    [SerializeField] GameUI _gameUI;
    [SerializeField] CameraMove _cameraMove;

    public int _dis;
    

    public int boom; //ÇöÀç ÆøÅº °³¼ö
    public GameObject boomEffect;
    

    Animator _ani;
    //bool MoveisIdle = true;
    bool isIdle = true;
    bool AttackisIdle = true;
    bool isAction;
    bool isDead;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    public GameObject tear;
    public float maxShotDelay;
    public float curShotDelay;
    public GameObject Shild;
   
    GameUI _uiPanel;
    public  GameObject Face;
    public GameObject FullAni;

    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    
    


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
        Boom();

        

        Vector3 curPos = transform.position;

        Vector3 target1 = new Vector3(0, 25f,0);//top
        Vector3 target2 = new Vector3(0, -25f,0);//bottom
        Vector3 target3 = new Vector3(25f,0,0);//Right
        Vector3 target4 = new Vector3(-25f, 0,0);//Left

        if (isTouchTop&& Vector3.Distance(curPos, target1) < _dis)
        {
            
            transform.position += Vector3.Lerp(curPos, target1, 1f);
            
           // isTouchTop = false;
        }
        if (isTouchBottom&& Vector3.Distance(curPos, target2) < _dis)
        {
            transform.position += Vector3.Lerp(curPos, target2, 1f);
            //isTouchBottom = false;
        }
        if (isTouchRight&& Vector3.Distance(curPos, target3) < _dis)
        {
            transform.position += Vector3.Lerp(curPos, target3, 1f);
            //isTouchRight = false;
        }
        if (isTouchLeft&& Vector3.Distance(curPos, target4) < _dis)
        {
            transform.position += Vector3.Lerp(curPos, target4, 1f);
            //isTouchLeft = false;
        }


    }
       
    
    void Boom()
    {
        if (isDead)
            return;
        if (!Input.GetKeyDown(KeyCode.E))
            return;
        if (boom == 0)
            return;
       
        boom--;
        _gameUI.minusBoom();

      GameObject _boom = Instantiate(boomEffect,transform.position,transform.rotation);
        _boom.GetComponent<Boom>().boomEffect(5);

    }
 

    public void Hitted(int dmg)
    {
         
        
        if (_hp == minHp)//Dead
        {
            isDead = true;
            Face.SetActive(false);
            FullAni.SetActive(true);
            _FullAni.SetTrigger("Dead");
            isAction = false;
           
            
        }
        else
        {
            _hp -= dmg;
            Face.SetActive(false);
            FullAni.SetActive(true);
            _FullAni.SetTrigger("Hitted");
            Invoke("ReturnFace", 0.6f);
            _gameUI.HeartIcon(dmg);

        }

        

    }

    void GetItem()
    {
        Debug.Log("¾ÆÀÌÅÛ È¹µæ");
        Face.SetActive(false);
        FullAni.SetActive(true);
        _FullAni.SetTrigger("GetItem");
        Invoke("ReturnFace", 1f);
        GameObject Temp = Instantiate(ShildItem, transform);


    }

    void ReturnFace()
    {
        Face.SetActive(true);
        FullAni.SetActive(false);
    }

   


    public void Move()
    {
        if (isDead) return;

        //bool isIdle = true;
        if (isIdle)
        {
           // _ani.SetInteger("Move", 0);


        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            //_ani.SetInteger("Move", 1);
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
            isIdle = false;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isIdle = true;
        }

        if (Input.GetKey(KeyCode.A)) //Left
        {
           // _ani.SetInteger("Move", 2);
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            isIdle = false;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.W)) //Up
        {
           // _ani.SetInteger("Move", 3);
            transform.Translate(Vector2.up * Time.deltaTime * _speed);

            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
           // _ani.SetInteger("Move", 4);
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
        if (isDead)
            return;

        if (AttackisIdle)
        {
           // _ani.SetInteger("Attack", 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            AttackisIdle = false;
            if (curShotDelay > maxShotDelay)
            {
                //_ani.SetInteger("Attack", 1);

                GameObject Bullet = Instantiate(tear, transform.position + Vector3.right , transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.right);
                //Rigidbody2D _rigid = Bullet.GetComponent<Rigidbody2D>();
                //_rigid.AddForce(Vector2.right * _speed, ForceMode2D.Impulse);  //AddForce(Vec): VecÀÇ ¹æÇâ°ú Å©±â·Î ÈûÀ» ÁÜ
                
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
               // _ani.SetInteger("Attack", 2);

                GameObject Bullet = Instantiate(tear,transform.position + Vector3.left,transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.left);               
                //Rigidbody2D _rigid = Bullet.GetComponent<Rigidbody2D>();
                //_rigid.AddForce(Vector2.left*_speed, ForceMode2D.Impulse);

                curShotDelay = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
           // AttackisIdle = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //AttackisIdle = false;
            if(curShotDelay> maxShotDelay)
            {
           // _ani.SetInteger("Attack", 3);
            

                GameObject Bullet = Instantiate(tear, transform.position + Vector3.up*3.0f, transform.rotation);
                Bullet.GetComponent <PlayerBullet>().Init(Vector2.up);
                //Rigidbody2D _rigid = Bullet.GetComponent<Rigidbody2D>();
                //_rigid.AddForce(Vector2.up*_speed, ForceMode2D.Impulse);
                

                curShotDelay = 0;
            }

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
          //  AttackisIdle = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
           // AttackisIdle = false;
            if(curShotDelay> maxShotDelay)
            {
            //_ani.SetInteger("Attack", 4);

            GameObject Bullet = Instantiate(tear,transform.position+ Vector3.down, transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.down);

                //Rigidbody2D _rigid = Bullet.GetComponent<Rigidbody2D>();
                //_rigid.AddForce(Vector2.down * _speed, ForceMode2D.Impulse);

                curShotDelay = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
           // AttackisIdle = true;
        }

    }

    //internal void Move(object isidle)
    //{
    //    throw new NotImplementedException();
    //}

  
     void OnCollisionEnter2D(Collision2D collision)
    {
        
       if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Coin":
                    _gameUI.addCoin();
                   
                    break;
                case "Bomb":
                    boom++;
                    _gameUI.addBoom();
                    break;
                case "Key":
                    _gameUI.addKey();

                    break;
                case "Shild":
                    
                  //  collision.gameObject.SetActive(false);
                    GetItem();
                    break;

            }
                    Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Damage"||collision.gameObject.tag=="Boom")
        {
            
            Hitted(5);
            _gameUI.HeartIcon(_hp);
            
           
        }
        if(collision.gameObject.GetComponent<BulletDamage>() != null)
        {
            int damage = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            collision.gameObject.GetComponent<BulletRemove>().Remove();
            Hitted(5);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;

                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;

            }
        }
    }
}

