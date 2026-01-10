using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePosition(Vector2 newPosition)
    {
        transform.position = new Vector3(newPosition.x + 0.5f, newPosition.y + 0.5f, -10);
    }
}
