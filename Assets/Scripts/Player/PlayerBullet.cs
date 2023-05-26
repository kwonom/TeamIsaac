using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float _bulletSpeed;
    Rigidbody2D _rigid;

    public void Init(Vector2 dir)
    {
        Rigidbody2D _rigid = GetComponent<Rigidbody2D>();
        _rigid.AddForce(dir * _bulletSpeed, ForceMode2D.Impulse);  //AddForce(Vec): Vec�� ����� ũ��� ���� ��
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("HorfBullet"), LayerMask.NameToLayer("PlayerBullet"));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("Damage"))
        {
            Destroy(gameObject);
        }
    }
}
