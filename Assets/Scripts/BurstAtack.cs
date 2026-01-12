using UnityEngine;

public class BurstAtack : MonoBehaviour
{
    private Rigidbody2D rb;
    private BurstAtackController controllerAtackBurst;
    private GameObject player;
    private Transform playerTransform;
    private float clock = 0;
    private float increase = 0.005f;
    private float velocity = 9f;
    float DirectionX = 0f;
    float DirectionY = 0f;
    void Start()
    {
        Destroy(gameObject, 3.5f);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }
    void Update()
    {
        clock += Time.deltaTime;
        burstActions();
    }
    void burstActions()
    {
        
        if (clock <= 1)
        {
            transform.localScale += new Vector3(increase, increase, increase);
        }
        else if (clock <= 2)
        {
            Vector2 directionNormalized = (playerTransform.position - transform.position).normalized;
            rb.linearVelocity = directionNormalized * velocity;
            clock = 2f;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            transform.localScale += new Vector3(increase * 2, increase * 2, increase * 2);
            clock = 0f;
        }
    }
}
