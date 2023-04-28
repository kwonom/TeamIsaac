using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject after;
    public GameObject BoomItem;
    [SerializeField] BoxCollider2D boxCollider;

    public void boomEffect(int dmg)
    {
        BoomItem.SetActive(true);
        Invoke("afterEffect", 1.2f);
        Invoke("offEffect", 2.9f);
        boxCollider.enabled = false;
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

}
