using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject _bullet;

    int _hp = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Input.mousePosition;
        }               

        if(Input.GetKey(KeyCode.Space))
        {

        }

        if(_hp<=0)
        {
            GetComponent<ScenesChange>().Dead();
        }
    }
   
}
