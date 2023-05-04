using UnityEngine;

public class PlayerBulletDamage : MonoBehaviour
{
    [SerializeField] int _damage;

    public int getDamage()
    {
        return _damage;
    }
}
