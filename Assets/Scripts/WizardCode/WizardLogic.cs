using UnityEngine;

public class WizardLogic : MonoBehaviour
{
    private BurstAtackController controllerAtackBurst;
    private float timerAtack = 5f;
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
}
