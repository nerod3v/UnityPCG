using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class projectileController : MonoBehaviour
{
    private Rigidbody2D rb;
    public InputActionReference inputAtack;
    private Vector2 atackDirection;
    public GameObject bullet;
    private GameObject bullet1;
    public GameObject player;
    public float shotDelay = 0.5f;
    public float shotTime = 0.5f;
    private float shotSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        shot();
    }
    void shot()
    {
        if (inputAtack.action.ReadValue<Vector2>() != Vector2.zero && shotTime >= shotDelay)
        {
            bullet1 = Instantiate(bullet, transform.position, transform.rotation);
            Physics2D.IgnoreCollision(bullet1.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            atackDirection = inputAtack.action.ReadValue<Vector2>();
            if (atackDirection.x != 0)
            {
                bullet1.transform.Rotate( 0 , 0 , -atackDirection.x * 90);
            }
            else if (atackDirection.y != 1 )
            {
                bullet1.transform.Rotate( 0 , 0 , 180);
            }
            Rigidbody2D rbBullet1 = bullet1.GetComponent<Rigidbody2D>();
            
            rbBullet1.linearVelocity = new Vector2(atackDirection.x * shotSpeed ,atackDirection.y * shotSpeed);
            shotTime = 0;
        }
        
        if (shotTime <= shotDelay)
        {
            shotTime += Time.deltaTime;
        }
    }
}