using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{
    public enum detectorTypes
    {
        Up,
        Down,
        Left,
        Right
    }
    public detectorTypes thisDetectorType;
    public Vector2Int originRoom;
    private RoomsManager managerRooms;
    void Start()
    {
        managerRooms = FindFirstObjectByType<RoomsManager>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            switch (thisDetectorType)
            {
                case detectorTypes.Up:
                    managerRooms.PlayerDetected(thisDetectorType, originRoom);
                    break;
                case detectorTypes.Down:
                    managerRooms.PlayerDetected(thisDetectorType, originRoom);
                    break;
                case detectorTypes.Left:
                    managerRooms.PlayerDetected(thisDetectorType, originRoom);
                    break;
                case detectorTypes.Right:
                    managerRooms.PlayerDetected(thisDetectorType, originRoom);
                    break;
            }
        }
        
    }
}
