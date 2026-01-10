using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public InputActionReference inputMove;
    private Vector2 moveDirection;
    private RoomsManager managerRooms;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        managerRooms = FindFirstObjectByType<RoomsManager>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        moveDirection = inputMove.action.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);      
    }
    public void TeleportRoom(Vector2 positionRoom, DetectorPlayer.detectorTypes thisdetector)
    {
        switch (thisdetector)
        {
            case DetectorPlayer.detectorTypes.Up:
                transform.position = new Vector2(transform.position.x, transform.position.y + 5);
                break;
            case DetectorPlayer.detectorTypes.Down:
                transform.position = new Vector2(transform.position.x, transform.position.y - 5);
                break;
            case DetectorPlayer.detectorTypes.Left:
                transform.position = new Vector2(transform.position.x - 4.7f, transform.position.y);
                break;
            case DetectorPlayer.detectorTypes.Right:
                transform.position = new Vector2(transform.position.x + 4.7f, transform.position.y);
                break;
            default:
                break;
        }
    }
}
