using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class RoomsManager : MonoBehaviour
{
    public List<GameObject> initialsRooms;
    public List<GameObject> Rooms;
    public List<GameObject> FinalsRooms;
    private List<Vector2Int> RoomsPositions = new List<Vector2Int>();
    private PlayerActions actionsPlayer;
    private CameraLogic logicCamera;
    private EnemiesManager managerEnemies;
    public Grid MotherGrid;
    private Transform destineRoom;
    public float RoomsHeight = 11f;
    public float RoomsWeight = 19f;
    public float CounterRooms = 0f;
    public float MaximRooms = 8f;

    void Start()
    { 
        actionsPlayer = FindFirstObjectByType<PlayerActions>();
        logicCamera = FindFirstObjectByType<CameraLogic>(); 
        managerEnemies  = FindFirstObjectByType<EnemiesManager>();
        Vector2 initialPosition = new Vector2(0,0);
        RoomsPositions.Add(new Vector2Int(0,0));
        GameObject initialroom = Instantiate(RandomRoom(initialsRooms), initialPosition, Quaternion.identity, MotherGrid.transform);
        DetectorPlayer[] detectors = initialroom.GetComponentsInChildren<DetectorPlayer>();
        foreach(DetectorPlayer detector in detectors)
        {
            detector.originRoom = new Vector2Int(Mathf.RoundToInt(initialPosition.x), Mathf.RoundToInt(initialPosition.y));
        }
        
    }

    void Update()
    {
        
    }
    GameObject RandomRoom(List<GameObject> Rooms)
    {
        return Rooms[UnityEngine.Random.Range(0, Rooms.Count)];
    }
    public Vector2Int PlayerDetected(DetectorPlayer.detectorTypes thisDetector, Vector2Int Room)
    {
        switch (thisDetector)
        {
            case DetectorPlayer.detectorTypes.Up:
                return CreateNewRoom(new Vector2Int(Room.x, Room.y + 1), thisDetector);
            case DetectorPlayer.detectorTypes.Down:
                return CreateNewRoom(new Vector2Int(Room.x, Room.y - 1), thisDetector);
            case DetectorPlayer.detectorTypes.Left:
                return CreateNewRoom(new Vector2Int(Room.x - 1, Room.y), thisDetector);
            case DetectorPlayer.detectorTypes.Right:
                return CreateNewRoom(new Vector2Int(Room.x + 1, Room.y), thisDetector);
            default:
                return new Vector2Int(0,0);
        }
    }
    Vector2Int CreateNewRoom(Vector2Int positionGrid, DetectorPlayer.detectorTypes thisDetector)
    {
        Vector2 worldPosition = new Vector2(positionGrid.x * RoomsWeight, positionGrid.y * RoomsHeight);
        if (!RoomsPositions.Contains(positionGrid))
        {
            bool bestRoom = false;
            RoomsPositions.Add(positionGrid);
            List<GameObject> RoomList = Rooms;
            while (bestRoom == false)
            {
                if (CounterRooms >= MaximRooms)
                {
                    RoomList = FinalsRooms;
                }
                GameObject newRoom = RandomRoom(RoomList);
                DetectorPlayer[] detectors = newRoom.GetComponentsInChildren<DetectorPlayer>();
                foreach(DetectorPlayer detector in detectors)
                {
                    if (matchDetector(thisDetector) == detector.thisDetectorType)
                    {
                        bestRoom = true;
                    }
                }
                if (bestRoom == true)
                {
                    GameObject createNewRoom = Instantiate(newRoom, worldPosition, Quaternion.identity, MotherGrid.transform);
                    DetectorPlayer[] detectors1 = createNewRoom.GetComponentsInChildren<DetectorPlayer>();
                    foreach(DetectorPlayer detector in detectors1)
                    {
                        detector.originRoom = positionGrid;
                    }
                    CounterRooms += 1;
                    actionsPlayer.TeleportRoom(worldPosition, thisDetector);
                    logicCamera.ChangePosition(worldPosition);
                    managerEnemies.GenerateEnemy(worldPosition);
                }
            }
        }
        else
        {
            bool correctDetector = false;
            foreach (Transform Room in MotherGrid.transform)
            {
                Vector2 positionRoom = new Vector2(Room.transform.position.x, Room.transform.position.y);
                if (positionRoom == worldPosition)
                {
                    destineRoom = Room;
                }
            }
            DetectorPlayer[] detectorsDestine = destineRoom.GetComponentsInChildren<DetectorPlayer>();
            foreach(DetectorPlayer detectorDestine in detectorsDestine)
            {
                if (detectorDestine.thisDetectorType == matchDetector(thisDetector))
                {
                    correctDetector = true;
                }
            }
            if (correctDetector == true)
            {
                actionsPlayer.TeleportRoom(worldPosition, thisDetector);
                logicCamera.ChangePosition(worldPosition);
            }
        }
        return positionGrid;
    }
    DetectorPlayer.detectorTypes matchDetector(DetectorPlayer.detectorTypes type)
    {
        switch (type)
        {
            case DetectorPlayer.detectorTypes.Up:
                return DetectorPlayer.detectorTypes.Down;
            case DetectorPlayer.detectorTypes.Down:
                return DetectorPlayer.detectorTypes.Up;
            case DetectorPlayer.detectorTypes.Left:
                return DetectorPlayer.detectorTypes.Right;
            case DetectorPlayer.detectorTypes.Right:
                return DetectorPlayer.detectorTypes.Left;
            default:
                return type;
        }
    }
}
