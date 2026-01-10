using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float timeDestroy = 0.5f;
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
