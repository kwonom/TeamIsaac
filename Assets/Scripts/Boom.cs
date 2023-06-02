using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject after;
    public GameObject BoomItem;
    [SerializeField] BoxCollider2D boxCollider;
   
    public void boomEffect()
    {
        BoomItem.SetActive(true);
        Invoke("afterEffect", 2f);
        Invoke("offEffect", 3.5f);
        after.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void afterEffect()
    {
        after.SetActive(true);
        after.GetComponent<BoxCollider2D>().enabled = true;
       // Invoke("Remove", 0.1f);
        Destroy(BoomItem);
    }
    //void Remove()
    //{
    //    after.GetComponent<BoxCollider2D>().enabled = false;
    //}
    void offEffect()
    {
        after.SetActive(false);
        Destroy(gameObject);
    }

}
