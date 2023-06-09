using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject after;
    public GameObject BoomItem;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] AudioClip _sfx;
   
    public void boomEffect()
    {
        BoomItem.SetActive(true);
        Invoke("afterEffect",1.8f);
        Invoke("offEffect", 3.5f);
        after.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void afterEffect()
    {
        SoundController.instance.SFXPlay(SoundController.sfx.Boom);
        after.SetActive(true);
        after.GetComponent<BoxCollider2D>().enabled = true;
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
