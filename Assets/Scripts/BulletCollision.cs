using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float timeDestroy = 0.5f;
    public float damage = 1f;
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
        if (other.CompareTag("Enemy")){
            
        }
    }
}
