using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shild : MonoBehaviour
{
    [SerializeField] Transform _player;
    float _time = 0f;
    int _hp;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Wall"), LayerMask.NameToLayer("Shield"));

    }

    // Update is called once per frame
    void Update()
    {
        ShildItem();
    }    
    public void ShildItem()
    {        
        _time += Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Cos(_time), Mathf.Sin(_time), 0) * 1.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            _hp -= 10;
        }
    }
}
