using Unity.VisualScripting;
using UnityEngine;

public class BurstAtackController : MonoBehaviour
{
    public GameObject burst;
    private BurstAtack atackBurst;
    private GameObject burst1;
    private GameObject burst2;
    public GameObject enemy;
    private float atackDelay = 2.5f;
    private float atackTime = 0;
    public float distanceForEnemyX = 0.35f;
    public float distanceForEnemyY = 0.15f;
    void Start()
    {
        atackBurst = FindAnyObjectByType<BurstAtack>();
    }

    void Update()
    {
        Atack();
    }
    void Atack()
    {
        if (atackTime >= atackDelay){
            burst1 = Instantiate(burst, new Vector2(transform.position.x - distanceForEnemyX, transform.position.y + distanceForEnemyY), Quaternion.identity);
            burst2 = Instantiate(burst, new Vector2(transform.position.x + distanceForEnemyX, transform.position.y + distanceForEnemyY), Quaternion.identity);
            Physics2D.IgnoreCollision(burst1.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(burst2.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
            atackTime = 0;
        }
        atackTime += Time.deltaTime;
    }
}
