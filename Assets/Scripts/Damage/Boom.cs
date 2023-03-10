using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{

    public GameObject after;
    public GameObject BoomItem;
    // Start is called before the first frame update
    void Start()
    {

        
       
    }
    public void boomEffect(int dmg)
    {
        BoomItem.SetActive(true);
        Invoke("afterEffect", 1.2f);
        Invoke("offEffect", 2.9f);
    }
    void afterEffect()
    {
        after.SetActive(true);
    }
    void offEffect()
    {
        after.SetActive(false);
    }

   

    // Update is called once per frame
    void Update()
    {
        boomEffect(5);
    }
}
