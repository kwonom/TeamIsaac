using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Transform _target = null;
    Vector3 _dir;

    float _lifeTimer = 0f;

    void Update()
    {
        transform.Translate(_dir * Time.deltaTime * _speed);
        _lifeTimer += Time.deltaTime;
        if (_lifeTimer > 2f)
        {
            ReMove();
        }
    }

    public void Init(Transform target)
    {
        _target = target;
        _dir = (_target.position - transform.position).normalized;
    }

    public void Init(Vector3 dir)
    {
        _dir = dir;
    }

    public void ReMove()
    {
        Destroy(gameObject);
    }
}
