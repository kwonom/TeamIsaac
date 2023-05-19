using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _faceAni;
    [SerializeField] Animator _bodyAni;
    [SerializeField] Animator _FullAni;
    [SerializeField] GameObject ShildItem;
    [SerializeField] float _speed;

    [SerializeField] GameUI _gameUI;
    [SerializeField] CameraMove _cameraMove;

    [SerializeField] GameObject tear;
    [SerializeField] GameObject Shild;
    [SerializeField] GameObject Face;
    [SerializeField] GameObject FullAni;

    [SerializeField] float maxShotDelay;
    [SerializeField] float curShotDelay;

    [SerializeField]int _hp;
    [SerializeField] int minHp;
    [SerializeField] int _dis;
    [SerializeField] int boom; //���� ��ź ����
    [SerializeField]GameObject boomEffect;

    bool isIdle = true;
    bool AttackisIdle = true;
    protected bool isDead;
    public bool IsDead{get{return isDead;}set{isDead=value;}}

    protected bool isTouchTop;
    public bool IsTouchTop { get { return isTouchTop; } set { isTouchTop = value; } }
    
    protected bool isTouchBottom;
    public bool IsTouchBottom { get { return isTouchBottom; } set { isTouchBottom = value; } }
    
    protected bool isTouchRight;
    public bool IsTouchRight { get { return isTouchRight; } set { isTouchRight = value; } }
    
    protected bool isTouchLeft;
    public bool IsTouchLeft { get { return isTouchLeft; } set { isTouchLeft = value; } }

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Wall"), LayerMask.NameToLayer("Shield"));
    }

    void Update()
    {
        curShotDelay += Time.deltaTime;
        Move();
        Attack();
        Boom();

        Vector3 curPos = transform.position;
        Vector3 target1 = new Vector3(0, 25f, 0);//top
        Vector3 target2 = new Vector3(0, -25f, 0);//bottom
        Vector3 target3 = new Vector3(25f, 0, 0);//Right
        Vector3 target4 = new Vector3(-25f, 0, 0);//Left


        if (isTouchTop && Vector3.Distance(curPos, target1) < _dis)
        {
            transform.position += Vector3.Lerp(curPos, target1, 1f);
        }
        if (isTouchBottom && Vector3.Distance(curPos, target2) < _dis)
        {
            transform.position += Vector3.Lerp(curPos, target2, 1f);
        }
        if (isTouchRight && Vector3.Distance(curPos, target3) < _dis)
        {
            transform.position += Vector3.Lerp(curPos, target3, 1f);
        }
        if (isTouchLeft && Vector3.Distance(curPos, target4) < _dis)
        {
            transform.position += Vector3.Lerp(curPos, target4, 1f);
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
        GameObject _boom = Instantiate(boomEffect, transform.position, transform.rotation);
        //_boom.GetComponent<Boom>().getDamage();
    }

    public void Hitted(int dmg)
    {
        if (_hp == minHp)//Dead
        {
            isDead = true;
            Face.SetActive(false);
            FullAni.SetActive(true);
            _FullAni.SetTrigger("Dead");
        }
        else
        {
            _hp -= dmg;
            Face.SetActive(false);
            FullAni.SetActive(true);
            _FullAni.SetTrigger("Hitted");
            Invoke("ReturnFace", 0.6f);
            _gameUI.HeartIcon(_hp);
        }

        
    }
    void GetItem()
    {
        Debug.Log("아이템 획득!");
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
        if (Input.GetKey(KeyCode.D)) //Right
        {
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.A)) //Left
        {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.W)) //Up
        {
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
            isIdle = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isIdle = true;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AttackisIdle = false;
            if (curShotDelay > maxShotDelay)
            {
                GameObject Bullet = Instantiate(tear, transform.position + Vector3.right, transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.right);
                curShotDelay = 0;
            }
        }
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AttackisIdle = false;
            if (curShotDelay > maxShotDelay)
            {
                GameObject Bullet = Instantiate(tear, transform.position + Vector3.left, transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.left);
                curShotDelay = 0;
            }
        }
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (curShotDelay > maxShotDelay)
            {
                GameObject Bullet = Instantiate(tear, transform.position + Vector3.up * 3.0f, transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.up);
                curShotDelay = 0;
            }
        }
      
        if (Input.GetKey(KeyCode.DownArrow))
        {
            AttackisIdle = false;
            if (curShotDelay > maxShotDelay)
            {
                GameObject Bullet = Instantiate(tear, transform.position + Vector3.down*3.0f, transform.rotation);
                Bullet.GetComponent<PlayerBullet>().Init(Vector2.down);
                curShotDelay = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Item"))
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
                    GetItem();
                    break;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Damage"))
        {
            Hitted(5);
            _gameUI.HeartIcon(_hp);
        }
        if (collision.gameObject.GetComponent<BulletDamage>() != null)
        {
            int damage = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            collision.gameObject.GetComponent<BulletRemove>().Remove();
            Hitted(damage);
            _gameUI.HeartIcon(_hp);
        }
        if (collision.gameObject.CompareTag("BossRoom"))
        {
            SceneManager.LoadScene("BossIntro");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
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
        else if (collision.gameObject.CompareTag("Boom"))
        {

            Hitted(5);
            _gameUI.HeartIcon(_hp);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
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

