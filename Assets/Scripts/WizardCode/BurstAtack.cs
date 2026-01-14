using UnityEngine;

public class BurstAtack : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private Transform playerTransform;
    private float timer = 0;
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
        
        burstActions();
    }
    void burstActions()
    {
        if (timer <= burstDuration/3)
        {
            Increment();
        }
        else if (timer <= burstDuration/2)
        {
            Shot();     
        }
        else if(timer >= burstDuration - 0.5f)
        {
            Expliod();
            
        }
        timer += Time.deltaTime;
    }
    void Increment()
    {
        transform.localScale += new Vector3(increase, increase, increase);

    }
    void Shot()
    {
        Vector2 directionNormalized = (playerTransform.position - transform.position).normalized;
        rb.linearVelocity = directionNormalized * velocity;
        
    }
    void Expliod()
    {
        transform.localScale += new Vector3(increase * 3, increase * 3, increase * 3);
        rb.linearVelocity = Vector2.zero;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Expliod();
    }
}

