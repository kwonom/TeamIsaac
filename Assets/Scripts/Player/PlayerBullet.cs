using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float _bulletSpeed;
    Rigidbody2D _rigid;
    float _timer;
    public void Init(Vector2 dir)
    {
        Rigidbody2D _rigid = GetComponent<Rigidbody2D>();
        _rigid.AddForce(dir * _bulletSpeed, ForceMode2D.Impulse);  //AddForce(Vec): VecÀÇ ¹æÇâ°ú Å©±â·Î ÈûÀ» ÁÜ
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("HorfBullet"), LayerMask.NameToLayer("PlayerBullet"));

    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("Damage") || collision.gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }
    }
}
