using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //float _speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StrBullet();
    }

    public void StrBullet()
    {
        //Vector2 v2 = gameObject.GetComponent<Player>().transform.position;
        //v2 += Vector2.left * Time.deltaTime * _speed;
    }
}
