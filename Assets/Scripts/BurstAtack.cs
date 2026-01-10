using UnityEngine;

public class BurstAtack : MonoBehaviour
{
    private Rigidbody2D rb;
    private BurstAtackController controllerAtackBurst;
    public GameObject player;
    private float clock = 0;
    private float increase = 0.005f;
    private float velocity = 9f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (clock >= 1)
        {
            rb.linearVelocity = new Vector2(player.transform.position.x, player.transform.position.y);
        }
    }
}
