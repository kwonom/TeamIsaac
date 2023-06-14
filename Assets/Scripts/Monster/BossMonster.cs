using System.Collections;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public enum EBossState
{
    Idle,
    Attack,
    Jump,
    Landing,
    Hitted,
    Die,
}

public class BossMonster : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] GameObject _bossBullet;
    [SerializeField] GameObject _boss;
    [SerializeField] GameObject _shadow;
    [SerializeField] float _speed;
    [SerializeField] int _count;
    [SerializeField] float _gap;
    [SerializeField] float _deg;
    Collider2D _collider;
    
    EBossState _estate = EBossState.Idle;

    Animator _ani;
    SpriteRenderer _render;

    [SerializeField] int _hp;
    float _attacktimer = 0;
    float _jumptimer = 0;
    float _timer = 0;
    float _landingtimer = 0;
    float _attackcool = 3f;
    float _timercool = 1f;
    float _jumpcool = 1f;
    float _ladingcool = 5f;

    bool _isAtttack = false;
    bool _isHitted = false;
    bool _isJumping = false;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Boss"), LayerMask.NameToLayer("BossBullet"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("PlayerBullet"), LayerMask.NameToLayer("BossBullet"));
        _ani = _boss.GetComponent<Animator>();
        _render = _boss.GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
        StartCoroutine(CoSpawn());
    }

    void Update()
    {
        ColorChange();

        switch (_estate)
        {
            case EBossState.Idle:
                BossMove();
                _isAtttack = false;
                break;
            case EBossState.Attack:
                BossAttack();
                _isJumping = false;
                break;
            case EBossState.Jump:
                BossJump();
                break;
            case EBossState.Landing:
                BossLanding();
                break;
        }
    }

    public void BossMove()
    {
        _ani.Play("BossMove");

        transform.Translate((_target.position - transform.position).normalized * _speed * Time.deltaTime);

        _attacktimer += Time.deltaTime;

        if (_attacktimer >= _attackcool)
        {
            _attacktimer = 0;
            _estate = EBossState.Attack;
        }
    }

    public void BossAttack()
    {
        _ani.Play("BossAttack");

        _jumptimer += Time.deltaTime;
        float degx = _target.position.x - transform.position.x;
        float degy = _target.position.y - transform.position.y;
        float degAdd = Mathf.Atan2(degy,degx);
        if (!_isAtttack)
        {
            _isAtttack = true;
            for(int i = -_count/2; i < _count; i++)
            {
                StartCoroutine(CoBossAttack(Mathf.Deg2Rad * ( i * _deg) + degAdd));
            }
        }
        if (_jumptimer >= _jumpcool)
        {
            _jumptimer = 0;
            _estate = EBossState.Jump;
        }
    }

    public void BossJump()
    {
        _ani.Play("BossJump");

        _landingtimer += Time.deltaTime;

        if(!_isJumping)
        {
            _isJumping = true;
            _collider.enabled = false;
        }
        if(_landingtimer > 0.5f && _shadow.activeSelf == false)
        {
            _shadow.SetActive(true);
        }
        if (_landingtimer >= _ladingcool)
        {
            _landingtimer = 0;
            _estate = EBossState.Landing;
        }
    }

    public void BossLanding()
    {
        _ani.Play("BossLanding");
        _shadow.SetActive(false);
        _timer += Time.deltaTime;

        Vector2 pos = transform.position;
        pos.x = _shadow.transform.position.x;
        transform.position = pos;

        if (_timer >= _timercool)
        {
            _timercool = 0;
            _estate = EBossState.Idle;
            _collider.enabled = true;
        }
    }

    public void DieEnd()
    {
        _boss.SetActive(false);
        GameUI.instance.Option();
    }

    public void Hitted(int damage)
    {
        _isHitted = true;
        _hp--;
        Debug.Log("now hp : "+_hp);
        if(_hp <= 0)
        {
            _ani.Play("BossDie");
            _estate = EBossState.Die;
            _collider.enabled = false;
        }
        else
        {
            _ani.Play("BossHitted");
        }
    }

    public void Spawn()
    {
        //_hp = 3;
        _boss.SetActive(true);
        _estate = EBossState.Idle;
        _collider.enabled = true;
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

    IEnumerator CoBossAttack(float _deg)
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.8f));

        GameObject temp = Instantiate(_bossBullet);
        temp.transform.position = transform.position;
        Vector3 dir = new Vector3(Mathf.Cos(_deg), Mathf.Sin(_deg), 0);
        temp.GetComponent<BossBullet>().Init(dir);
    }

    IEnumerator CoSpawn()
    {
        int rand = Random.Range(1, 3);
        yield return new WaitForSeconds(rand);
        Spawn();
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
            Hitted(5);
        }
    }
}
