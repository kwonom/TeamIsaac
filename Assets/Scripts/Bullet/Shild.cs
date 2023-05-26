using UnityEngine;

public class Shild : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] int _dmg;
    float _time = 0f;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("PlayerBullet"), LayerMask.NameToLayer("Shield"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Wall"), LayerMask.NameToLayer("Shield"));
    }

    void Update()
    {
       
            ShildItem();
        
    }    
    public void ShildItem()
    {        
        _time += Time.deltaTime*2;
        transform.localPosition = new Vector3(Mathf.Cos(_time), Mathf.Sin(_time), 0) * 2.5f;
    }

    public int getDamage()
    {
        return _dmg;
    }


}
