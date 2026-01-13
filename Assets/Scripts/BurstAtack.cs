using UnityEngine;

public class BurstAtack : MonoBehaviour
{
    private Rigidbody2D rb;
    private BurstAtackController controllerAtackBurst;
    private GameObject player;
    public GameObject Enemy;
    private Transform playerTransform;
    private float clock = 0;
    private float increase = 0.005f;
    private float velocity = 9f;
    public float burstDuration = 4f;
    void Start()
    {
        Destroy(gameObject, burstDuration);
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
        
        if (clock <= burstDuration/3)
        {
            transform.localScale += new Vector3(increase, increase, increase);
        }
        else if (clock <= burstDuration/2)
        {
            Vector2 directionNormalized = (playerTransform.position - transform.position).normalized;
            rb.linearVelocity = directionNormalized * velocity;
            clock = 2f;
        }
        else if(clock >= burstDuration - 0.5f)
        {
            rb.linearVelocity = Vector2.zero;
            transform.localScale += new Vector3(increase * 2, increase * 2, increase * 2);
        }
    }
    void Expliod()
    {
        rb.linearVelocity = Vector2.zero;
        transform.localScale += new Vector3(increase * 2, increase * 2, increase * 2);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Expliod();

    }
}
