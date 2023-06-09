using System.Collections;
using UnityEngine;

public class Horf : MonoBehaviour
{
    [SerializeField] GameObject _horfBullet;
    [SerializeField] Transform _target;
    [SerializeField] GameObject[] _items;
    SpriteRenderer _render;

    Animator _ani;
    [SerializeField] int _hp = 20;
    bool _isHitted = false;
    float _timer = 0f;
    bool isDead { get; set; }
    void Awake()
    {
        _horfBullet = Resources.Load("Prefabs/Monsters/HorfBullet") as GameObject;
        _render = GetComponent<SpriteRenderer>();
        _ani = GetComponent<Animator>();
        StartCoroutine(CoHorfFire());
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Horf"), LayerMask.NameToLayer("HorfBullet"));
    }
    
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    void Update()
    {
        ColorChange();
    }

    IEnumerator CoHorfFire()
    {
        while (true)
        {
            SoundController.instance.SFXPlay(SoundController.sfx.horf);     
            GameObject temp = Instantiate(_horfBullet, transform.position, transform.rotation);
            temp.transform.position = transform.position;
            temp.GetComponent<HorfBullet>().Init(_target);
            yield return new WaitForSeconds(3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().Hitted(5);
        }
        if (collision.gameObject.GetComponent<PlayerBulletDamage>() != null)
        {
            int damage = collision.gameObject.GetComponent<PlayerBulletDamage>().getDamage();
            collision.gameObject.GetComponent<BulletRemove>().Remove();
            OnHitted(damage);
        }
       
    }

    public void OnHitted(int damage)
    {
        _hp -= damage;
        _isHitted = true;
        if(_hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;
        SoundController.instance.SFXPlay(SoundController.sfx.MonDie);
        Destroy(this.gameObject);
        int ran = Random.Range(0, 10);
        Debug.Log(ran + " is ran");
        if (ran < 5)//20%
        {
            Debug.Log("Not Item");
        }
        else if(ran < 7)//20%
        {
           
            GameObject temp = Instantiate(_items[2]);//key
            temp.transform.position = transform.position;
        }
        else if(ran < 8)//20%
        {
            GameObject temp = Instantiate(_items[0]);//boom
            temp.transform.position = transform.position;

        }
        else if(ran < 9)//10%
        {
            GameObject temp = Instantiate(_items[1]);//coin
            temp.transform.position = transform.position;

        }
    }

    public void ColorChange()
    {
        if (_isHitted == true)
        {
            _timer += Time.deltaTime;
            _render.color = Color.red;
            if (_timer > 0.1f)
            {
                _isHitted = false;
                _render.color = Color.white;
                _timer = 0f;
            }
        }
    }
}
