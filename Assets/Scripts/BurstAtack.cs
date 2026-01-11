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
    void Start()
    {
        Destroy(gameObject, 4);
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
        else if (clock <= 3)
        {
            float DirectionX = playerTransform.position.x;
            float DirectionY = playerTransform.position.y;
            rb.linearVelocity = new Vector2(DirectionX - transform.position.x, DirectionY - transform.position.y);
            clock = 3.1f;
        }
    }
}
