using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorfBullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Transform _target = null;
    Vector3 _dir;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_dir * Time.deltaTime * _speed);
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
}
