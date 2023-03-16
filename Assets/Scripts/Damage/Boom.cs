using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{

    public GameObject after;
    public GameObject BoomItem;
    [SerializeField] BoxCollider2D boxCollider;
    


    void Start()
    {

        
       
    }
    public void boomEffect(int dmg)
    {
        BoomItem.SetActive(true);
        Invoke("afterEffect", 1.2f);
        Invoke("offEffect", 2.9f);
        boxCollider.enabled = false;
        //BoxCollider2D boxcollider = after.GetComponent<BoxCollider2D>();
        //boxcollider.enabled = false;
    
    }
    public void afterEffect()
    {
        
        after.SetActive(true);
        BoxCollider2D boxcollider = after.GetComponent<BoxCollider2D>();
        boxCollider.enabled = true;
     


    }
    void offEffect()
    {
        after.SetActive(false);
        Destroy(gameObject);
      
    }

   

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
