using UnityEngine;

public class BurstAtackController : MonoBehaviour
{
    public GameObject burst;
    public GameObject player;
    private BurstAtack atackBurst;
    private float atackDelay = 2.5f;
    private float atackTime = 0;
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
            Instantiate(burst, transform.position, Quaternion.identity);
            atackTime = 0;
        }
        atackTime += Time.deltaTime;
    }
}
