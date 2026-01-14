using Unity.VisualScripting;
using UnityEngine;

public class BurstAtackController : MonoBehaviour
{
    public GameObject burst;
    private GameObject burst1;
    private GameObject burst2;
    public GameObject enemy;
    private float distanceForEnemyX = 0.35f;
    private float distanceForEnemyY = 0.15f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Atack()
    {
        burst1 = Instantiate(burst, new Vector2(transform.position.x - distanceForEnemyX, transform.position.y + distanceForEnemyY), Quaternion.identity);
        burst2 = Instantiate(burst, new Vector2(transform.position.x + distanceForEnemyX, transform.position.y + distanceForEnemyY), Quaternion.identity);
        Physics2D.IgnoreCollision(burst1.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(burst2.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(burst1.GetComponent<Collider2D>(), burst2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(burst2.GetComponent<Collider2D>(), burst1.GetComponent<Collider2D>());
    }
}
