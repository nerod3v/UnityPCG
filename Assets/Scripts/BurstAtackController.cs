using UnityEngine;

public class BurstAtackController : MonoBehaviour
{
    public GameObject burst;
    public GameObject player;
    private BurstAtack atackBurst;
    private float atackDelay = 2.5f;
    private float atackTime = 0;
    public float distanceEnemy = 0.05f;
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
            Instantiate(burst, new Vector2(transform.position.x - distanceEnemy, transform.position.y), Quaternion.identity);
            Instantiate(burst, new Vector2(transform.position.x + distanceEnemy, transform.position.y), Quaternion.identity);
            atackTime = 0;
        }
        atackTime += Time.deltaTime;
    }
}
