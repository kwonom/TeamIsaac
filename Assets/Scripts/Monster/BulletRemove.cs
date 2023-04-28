using UnityEngine;

public class BulletRemove : MonoBehaviour
{
    float _timer = 0f;

    void Update()
    {
        if(_timer > 5f)
        {
            Remove();
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
