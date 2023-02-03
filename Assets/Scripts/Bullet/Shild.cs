using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shild : MonoBehaviour
{
    float _time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
