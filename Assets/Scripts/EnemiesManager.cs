using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void GenerateEnemy(Vector2 roomPosition)
    {
        Instantiate(enemy, roomPosition, Quaternion.identity);
    }
}
