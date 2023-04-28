using UnityEngine;

public class Pooter : MonoBehaviour
{
    PooterController _pCon;
    Transform _hero;
    Animator _ani;
    SpriteRenderer _render;

    float _speed;
    float _timer = 0f;
    int _hp;
    bool _isHitted = false;
    bool _isDead = false;

    void Start()
    {
        _ani = GetComponent<Animator>();
        _render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move();
        ColorChange();
    }

    public void Init(PooterController pCon, Transform hero)
    {
        gameObject.SetActive(true);
        _hero = hero;
        _pCon = pCon;
        _speed = 5;
        _hp = 10;

        int random = Random.Range(1, 4);

        switch (random)
        {
            case 1:
                {
                    transform.position = new Vector3(-24, -40);
                }
                break;
            case 2:
                {
                    transform.position = new Vector3(-24, -51);
                }
                break;
            case 3:
                {
                    transform.position = new Vector3(-18, -33);
                }
                break;
            case 4:
                {
                    transform.position = new Vector3(27, -60);
                }
                break;
        }
    }

    void move()
    {
        transform.Translate((_hero.position - transform.position).normalized * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().Hitted(5);
        }
        if(collision.gameObject.GetComponent<BulletDamage>() != null)
        {
            int damage = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            collision.gameObject.GetComponent<BulletRemove>().Remove();
            OnHitted(damage);
        }
    }

    void OnHitted(int hitPower)
    {
        _hp -= hitPower;
        _isHitted = true;
        if (_hp < 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Destroy(this.gameObject);
    }

    void ColorChange()
    {
        if(_isHitted == true)
        {
            _timer += Time.deltaTime;
            _render.color = Color.red;
            if(_timer > 0.1f)
            {
                _isHitted = false;
                _render.color = Color.white;
                _timer = 0f;
            }
        }
    }
}
