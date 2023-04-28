using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float _bulletSpeed;
    Rigidbody2D _rigid;

    public void Init(Vector2 dir)
    {
        Rigidbody2D _rigid = GetComponent<Rigidbody2D>();
        _rigid.AddForce(dir * _bulletSpeed, ForceMode2D.Impulse);  //AddForce(Vec): Vec의 방향과 크기로 힘을 줌
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("wall")||collision.gameObject.CompareTag("Boulder"))
        {
            Destroy(gameObject);
        }
    }
}
