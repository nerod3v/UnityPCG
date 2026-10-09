using UnityEngine;

public class WizardLogic : MonoBehaviour
{
    public float health = 3f;
    private BurstAtackController controllerAtackBurst;
    private float timerAtack = 3f;
    private float cooldownAtack =5f;

    void Start()
    {
        controllerAtackBurst = FindFirstObjectByType<BurstAtackController>();
    }

    void Update()
    {
        Atack();
    }

    void Atack()
    {
        if (timerAtack >= cooldownAtack)
        {
            controllerAtackBurst.Atack();
            timerAtack = 0;
        }
        timerAtack += Time.deltaTime;
    }
    void takeDamage(int damage){
        health -= damage;
    }
}
