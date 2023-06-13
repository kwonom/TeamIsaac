using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShadow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _speed;

    void Update()
    {
        transform.Translate((_target.position - transform.position).normalized * _speed * Time.deltaTime);
    }
}
